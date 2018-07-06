/*
   Copyright 2015-2018 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics.Reasoner.RuleSets
{

    /// <summary>
    /// RDFS implements a subset of RDFS entailment rules
    /// </summary>
    public static class RDFS {

        #region Properties
        /// <summary>
        /// SubClassTransitivity (rdfs11) implements structural entailments based on 'rdfs:subClassOf' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule SubClassTransitivity { get; internal set; }

        /// <summary>
        /// SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule SubPropertyTransitivity { get; internal set; }

        /// <summary>
        /// ClassTypeEntailment (rdfs9) implements data entailments based on 'rdf:type' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule ClassTypeEntailment { get; internal set; }

        /// <summary>
        /// PropertyEntailment (rdfs7) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule PropertyEntailment { get; internal set; }

        /// <summary>
        /// DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule DomainEntailment { get; internal set; }

        /// <summary>
        /// RangeEntailment (rdfs3) implements structural entailments based on 'rdfs:range' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule RangeEntailment { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to initialize the RDFS ruleset
        /// </summary>
        static RDFS() {

            //SubClassTransitivity (rdfs11)
            SubClassTransitivity     = new RDFOntologyReasonerRule("SubClassTransitivity",
                                                                   "SubClassTransitivity (rdfs11) implements structural entailments based on 'rdfs:subClassOf' taxonomy:" +
                                                                   "((C1 SUBCLASSOF C2)      AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)" +
                                                                   "((C1 SUBCLASSOF C2)      AND (C2 EQUIVALENTCLASS C3)) => (C1 SUBCLASSOF C3)" +
                                                                   "((C1 EQUIVALENTCLASS C2) AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)",
                                                                   SubClassTransitivityExec);

            //SubPropertyTransitivity (rdfs5)
            SubPropertyTransitivity  = new RDFOntologyReasonerRule("SubPropertyTransitivity",
                                                                   "SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                   "((P1 SUBPROPERTYOF P2)      AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)" +
                                                                   "((P1 SUBPROPERTYOF P2)      AND (P2 EQUIVALENTPROPERTY P3)) => (P1 SUBPROPERTYOF P3)" +
                                                                   "((P1 EQUIVALENTPROPERTY P2) AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)",
                                                                   SubPropertyTransitivityExec);

            //ClassTypeEntailment (rdfs9)
            ClassTypeEntailment      = new RDFOntologyReasonerRule("ClassTypeEntailment",
                                                                   "ClassTypeEntailment (rdfs9) implements structural entailments based on 'rdf:type' taxonomy:" +
                                                                   "((F TYPE C1) AND (C1 SUBCLASSOF C2))      => (F TYPE C2)" +
                                                                   "((F TYPE C1) AND (C1 EQUIVALENTCLASS C2)) => (F TYPE C2)",
                                                                   ClassTypeEntailmentExec);

            //PropertyEntailment (rdfs7)
            PropertyEntailment       = new RDFOntologyReasonerRule("PropertyEntailment",
                                                                   "PropertyEntailment (rdfs7) implements data entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                   "((F1 P1 F2) AND (P1 SUBPROPERTYOF P2))      => (F1 P2 F2)" +
                                                                   "((F1 P1 F2) AND (P1 EQUIVALENTPROPERTY P2)) => (F1 P2 F2)",
                                                                   PropertyEntailmentExec);

            //DomainEntailment (rdfs2)
            DomainEntailment         = new RDFOntologyReasonerRule("DomainEntailment",
                                                                   "DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy:" +
                                                                   "((F1 P F2) AND (P RDFS:DOMAIN C)) => (F1 RDF:TYPE C)",
                                                                   DomainEntailmentExec);

            //RangeEntailment (rdfs3)
            RangeEntailment          = new RDFOntologyReasonerRule("RangeEntailment",
                                                                   "RangeEntailment (rdfs3) implements structural entailments based on 'rdfs:range' taxonomy:" +
                                                                   "((F1 P F2) AND (P RDFS:RANGE C)) => (F2 RDF:TYPE C)",
                                                                   RangeEntailmentExec);

        }
        #endregion

        #region Methods
        /// <summary>
        /// SubClassTransitivity (rdfs11) implements structural entailments based on 'rdfs:subClassOf' taxonomy:
        /// ((C1 SUBCLASSOF C2)      AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)
        /// ((C1 SUBCLASSOF C2)      AND (C2 EQUIVALENTCLASS C3)) => (C1 SUBCLASSOF C3)
        /// ((C1 EQUIVALENTCLASS C2) AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)
        /// </summary>
        internal static Int64 SubClassTransitivityExec(RDFOntology ontology,
                                                       RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var subClassOf       = RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty();
            foreach (var c      in ontology.Model.ClassModel) {

                //Enlist the superclasses of the current class
                var superclasses = ontology.Model.ClassModel.EnlistSuperClassesOf(c);
                foreach (var sc in superclasses) {

                    //Create the inference as a taxonomy entry
                    var sem_inf  = new RDFOntologyTaxonomyEntry(c, subClassOf, sc).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Model.ClassModel.Relations.SubClassOf.AddEntry(sem_inf)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "SubClassTransitivity", sem_inf));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy:
        /// ((P1 SUBPROPERTYOF P2)      AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)
        /// ((P1 SUBPROPERTYOF P2)      AND (P2 EQUIVALENTPROPERTY P3)) => (P1 SUBPROPERTYOF P3)
        /// ((P1 EQUIVALENTPROPERTY P2) AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)
        /// </summary>
        internal static Int64 SubPropertyTransitivityExec(RDFOntology ontology,
                                                          RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var subPropertyOf    = RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToRDFOntologyObjectProperty();

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                 !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p      in availableprops) {

                //Enlist the superproperties of the current property
                var superprops   = ontology.Model.PropertyModel.EnlistSuperPropertiesOf(p);
                foreach (var sp in superprops) {

                    //Create the inference as a taxonomy entry
                    var sem_inf  = new RDFOntologyTaxonomyEntry(p, subPropertyOf, sp).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Model.PropertyModel.Relations.SubPropertyOf.AddEntry(sem_inf)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "SubPropertyTransitivity", sem_inf));
                    }

                }
            }
            return inferenceCounter;
        }

        /// <summary>
        /// ClassTypeEntailment (rdfs9) implements structural entailments based on 'rdf:type' taxonomy:
        /// ((F TYPE C1) AND (C1 SUBCLASSOF C2))      => (F TYPE C2)
        /// ((F TYPE C1) AND (C1 EQUIVALENTCLASS C2)) => (F TYPE C2)
        /// </summary>
        internal static Int64 ClassTypeEntailmentExec(RDFOntology ontology,
                                                      RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var type             = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();

            //Calculate the set of available classes on which to perform the reasoning (exclude BASE classes and literal-compatible classes)
            var availableclasses = ontology.Model.ClassModel.Where(cls => !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(cls.PatternMemberID)
                                                                             && !ontology.Model.ClassModel.IsLiteralCompatibleClass(cls));
            foreach (var c      in availableclasses) {

                //Enlist the members of the current class
                var clsMembers   = ontology.EnlistMembersOfNonLiteralCompatibleClass(c);
                foreach (var f  in clsMembers) {

                    //Create the inference as a taxonomy entry
                    var sem_inf  = new RDFOntologyTaxonomyEntry(f, type, c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Data.Relations.ClassType.AddEntry(sem_inf)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "ClassTypeEntailment", sem_inf));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// "PropertyEntailment (rdfs7) implements data entailments based on 'rdfs:subPropertyOf' taxonomy:"
        /// "((F1 P1 F2) AND (P1 SUBPROPERTYOF P2))      => (F1 P2 F2)"
        /// "((F1 P1 F2) AND (P1 EQUIVALENTPROPERTY P2)) => (F1 P2 F2)"
        /// </summary>
        internal static Int64 PropertyEntailmentExec(RDFOntology ontology,
                                                     RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();

            foreach (var p1     in availableprops) {

                //Filter the assertions using the current property (F1 P1 F2)
                var p1Asns       = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p1);

                //Enlist the compatible properties of the current property (P1 [SUBPROPERTYOF|EQUIVALENTPROPERTY] P2)
                foreach (var p2 in ontology.Model.PropertyModel.EnlistSuperPropertiesOf(p1)
                                                               .UnionWith(ontology.Model.PropertyModel.EnlistEquivalentPropertiesOf(p1))) {

                    //Iterate the compatible assertions
                    foreach (var p1Asn in p1Asns) {

                        //Taxonomy-check for securing inference consistency
                        if ((p2.IsObjectProperty()  && p1Asn.TaxonomyObject.IsFact())     ||
                           (p2.IsDatatypeProperty() && p1Asn.TaxonomyObject.IsLiteral()))  {

                            //Create the inference as a taxonomy entry
                            var sem_inf = new RDFOntologyTaxonomyEntry(p1Asn.TaxonomySubject, p2, p1Asn.TaxonomyObject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the ontology and to the report
                            if (ontology.Data.Relations.Assertions.AddEntry(sem_inf)) {
                                inferenceCounter++;
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "PropertyEntailment", sem_inf));
                            }

                        }

                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// "DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy:"
        /// "((F1 P F2) AND (P RDFS:DOMAIN C)) => (F1 RDF:TYPE C)"
        /// </summary>
        internal static Int64 DomainEntailmentExec(RDFOntology ontology,
                                                   RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var type             = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                 !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p      in availableprops) {
                if (p.Domain    != null) {

                    //Filter the assertions using the current property (F1 P1 F2)
                    var pAsns    = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                    //Iterate the related assertions
                    foreach (var pAsn in pAsns) {

                        //Create the inference as a taxonomy entry
                        var sem_inf    = new RDFOntologyTaxonomyEntry(pAsn.TaxonomySubject, type, p.Domain).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the ontology and to the report
                        if (ontology.Data.Relations.ClassType.AddEntry(sem_inf)) {
                            inferenceCounter++;
                            report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DomainEntailment", sem_inf));
                        }

                    }

                }
            }
            return inferenceCounter;
        }

        /// <summary>
        /// "RangeEntailment (rdfs3) implements structural entailments based on 'rdfs:range' taxonomy:"
        /// "((F1 P F2) AND (P RDFS:RANGE C)) => (F2 RDF:TYPE C)"
        /// </summary>
        internal static Int64 RangeEntailmentExec(RDFOntology ontology,
                                                  RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var type             = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                 !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p      in availableprops) {
                if (p.Range     != null) {

                    //Filter the assertions using the current property (F1 P1 F2)
                    var pAsns    = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                    //Iterate the related assertions
                    foreach (var pAsn in pAsns) {

                        //Taxonomy-check for securing inference consistency
                        if (pAsn.TaxonomyObject.IsFact()) {

                            //Create the inference as a taxonomy entry
                            var sem_inf = new RDFOntologyTaxonomyEntry(pAsn.TaxonomyObject, type, p.Range).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the ontology and to the report
                            if (ontology.Data.Relations.ClassType.AddEntry(sem_inf)) {
                                inferenceCounter++;
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "RangeEntailment", sem_inf));
                            }

                        }

                    }

                }
            }
            return inferenceCounter;
        }
        #endregion

    }

}