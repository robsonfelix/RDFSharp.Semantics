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
using System.Collections.Generic;
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFBASERuleset implements a subset of RDFS/OWL-DL entailment rules
    /// </summary>
    public static class RDFBASERuleset {

        #region Properties

        /// <summary>
        /// Counter of rules contained in the BASE ruleset
        /// </summary>
        public static readonly Int32 RulesCount = 15; 

		#region RDFS
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
		
		#region OWL-DL
		/// <summary>
        /// EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule EquivalentClassTransitivity { get; internal set; }

        /// <summary>
        /// DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule DisjointWithEntailment { get; internal set; }

        /// <summary>
        /// EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule EquivalentPropertyTransitivity { get; internal set; }

        /// <summary>
        /// SameAsTransitivity implements structural entailments based on 'owl:SameAs' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule SameAsTransitivity { get; internal set; }

        /// <summary>
        /// DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule DifferentFromEntailment { get; internal set; }

        /// <summary>
        /// InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule InverseOfEntailment { get; internal set; }

        /// <summary>
        /// SameAsEntailment implements data entailments based on 'owl:SameAs' taxonomy
        /// </summary>
        public static RDFOntologyReasonerRule SameAsEntailment { get; internal set; }

        /// <summary>
        /// SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom
        /// </summary>
        public static RDFOntologyReasonerRule SymmetricPropertyEntailment { get; internal set; }

        /// <summary>
        /// TransitivePropertyEntailment implements data entailments based on 'owl:TransitiveProperty' axiom
        /// </summary>
        public static RDFOntologyReasonerRule TransitivePropertyEntailment { get; internal set; }
		#endregion
		
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to initialize the RDFS ruleset
        /// </summary>
        static RDFBASERuleset() {

			#region RDFS
            //SubClassTransitivity (rdfs11)
            SubClassTransitivity     = new RDFOntologyReasonerRule("SubClassTransitivity",
                                                                   "SubClassTransitivity (rdfs11) implements structural entailments based on 'rdfs:subClassOf' taxonomy:" +
                                                                   "((C1 SUBCLASSOF C2)      AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)" +
                                                                   "((C1 SUBCLASSOF C2)      AND (C2 EQUIVALENTCLASS C3)) => (C1 SUBCLASSOF C3)" +
                                                                   "((C1 EQUIVALENTCLASS C2) AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)",
                                                                   2,
                                                                   SubClassTransitivityExec);

            //SubPropertyTransitivity (rdfs5)
            SubPropertyTransitivity  = new RDFOntologyReasonerRule("SubPropertyTransitivity",
                                                                   "SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                   "((P1 SUBPROPERTYOF P2)      AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)" +
                                                                   "((P1 SUBPROPERTYOF P2)      AND (P2 EQUIVALENTPROPERTY P3)) => (P1 SUBPROPERTYOF P3)" +
                                                                   "((P1 EQUIVALENTPROPERTY P2) AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)",
                                                                   5,
                                                                   SubPropertyTransitivityExec);

            //ClassTypeEntailment (rdfs9)
            ClassTypeEntailment      = new RDFOntologyReasonerRule("ClassTypeEntailment",
                                                                   "ClassTypeEntailment (rdfs9) implements structural entailments based on 'rdf:type' taxonomy:" +
                                                                   "((F TYPE C1) AND (C1 SUBCLASSOF C2))      => (F TYPE C2)" +
                                                                   "((F TYPE C1) AND (C1 EQUIVALENTCLASS C2)) => (F TYPE C2)",
                                                                   10,
                                                                   ClassTypeEntailmentExec);

            //PropertyEntailment (rdfs7)
            PropertyEntailment       = new RDFOntologyReasonerRule("PropertyEntailment",
                                                                   "PropertyEntailment (rdfs7) implements data entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                   "((F1 P1 F2) AND (P1 SUBPROPERTYOF P2))      => (F1 P2 F2)" +
                                                                   "((F1 P1 F2) AND (P1 EQUIVALENTPROPERTY P2)) => (F1 P2 F2)",
                                                                   14,
                                                                   PropertyEntailmentExec);

            //DomainEntailment (rdfs2)
            DomainEntailment         = new RDFOntologyReasonerRule("DomainEntailment",
                                                                   "DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy:" +
                                                                   "((F1 P F2) AND (P RDFS:DOMAIN C)) => (F1 RDF:TYPE C)",
                                                                   8,
                                                                   DomainEntailmentExec);

            //RangeEntailment (rdfs3)
            RangeEntailment          = new RDFOntologyReasonerRule("RangeEntailment",
                                                                   "RangeEntailment (rdfs3) implements structural entailments based on 'rdfs:range' taxonomy:" +
                                                                   "((F1 P F2) AND (P RDFS:RANGE C)) => (F2 RDF:TYPE C)",
                                                                   9,
                                                                   RangeEntailmentExec);
			#endregion

			#region OWL-DL
			//EquivalentClassTransitivity
            EquivalentClassTransitivity     = new RDFOntologyReasonerRule("EquivalentClassTransitivity",
                                                                          "EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy:" +
                                                                          "((C1 EQUIVALENTCLASS C2) AND (C2 EQUIVALENTCLASS C3)) => (C1 EQUIVALENTCLASS C3)",
                                                                          1,
                                                                          EquivalentClassTransitivityExec);

            //DisjointWithEntailment
            DisjointWithEntailment          = new RDFOntologyReasonerRule("DisjointWithEntailment",
                                                                          "DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy:" +
                                                                          "((C1 EQUIVALENTCLASS C2) AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                          "((C1 SUBCLASSOF C2)      AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                          "((C1 DISJOINTWITH C2)    AND (C2 EQUIVALENTCLASS C3)) => (C1 DISJOINTWITH C3)",
                                                                          3,
                                                                          DisjointWithEntailmentExec);

            //EquivalentPropertyTransitivity
            EquivalentPropertyTransitivity  = new RDFOntologyReasonerRule("EquivalentPropertyTransitivity",
                                                                          "EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy:" +
                                                                          "((P1 EQUIVALENTPROPERTY P2) AND (P2 EQUIVALENTPROPERTY P3)) => (P1 EQUIVALENTPROPERTY P3)",
                                                                          4,
                                                                          EquivalentPropertyTransitivityExec);

            //SameAsTransitivity
            SameAsTransitivity              = new RDFOntologyReasonerRule("SameAsTransitivity",
                                                                          "SameAsTransitivity implements structural entailments based on 'owl:SameAs' taxonomy:" +
                                                                          "((F1 SAMEAS F2) AND (F2 SAMEAS F3)) => (F1 SAMEAS F3)",
                                                                          6,
                                                                          SameAsTransitivityExec);

            //DifferentFromEntailment
            DifferentFromEntailment         = new RDFOntologyReasonerRule("DifferentFromEntailment",
                                                                          "DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy:" +
                                                                          "((F1 SAMEAS F2)        AND (F2 DIFFERENTFROM F3)) => (F1 DIFFERENTFROM F3)" +
                                                                          "((F1 DIFFERENTFROM F2) AND (F2 SAMEAS F3))        => (F1 DIFFERENTFROM F3)",
                                                                          7,
                                                                          DifferentFromEntailmentExec);

            //InverseOfEntailment
            InverseOfEntailment             = new RDFOntologyReasonerRule("InverseOfEntailment",
                                                                          "InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy:" +
                                                                          "((F1 P1 F2) AND (P1 INVERSEOF P2)) => (F2 P2 F1)",
                                                                          11,
                                                                          InverseOfEntailmentExec);

            //SameAsEntailment
            SameAsEntailment                = new RDFOntologyReasonerRule("SameAsEntailment",
                                                                          "SameAsEntailment implements data entailments based on 'owl:SameAs' taxonomy:" +
                                                                          "((F1 P F2) AND (F1 SAMEAS F3)) => (F3 P F2)" +
                                                                          "((F1 P F2) AND (F2 SAMEAS F3)) => (F1 P F3)",
                                                                          15,
                                                                          SameAsEntailmentExec);

            //SymmetricPropertyEntailment
            SymmetricPropertyEntailment     = new RDFOntologyReasonerRule("SymmetricPropertyEntailment",
                                                                          "SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom:" +
                                                                          "((F1 P F2) AND (P TYPE SYMMETRICPROPERTY)) => (F2 P F1)",
                                                                          12,
                                                                          SymmetricPropertyEntailmentExec);

            //TransitivePropertyEntailment
            TransitivePropertyEntailment    = new RDFOntologyReasonerRule("TransitivePropertyEntailment",
                                                                          "TransitivePropertyEntailment implements data entailments based on 'owl:TransitiveProperty' axiom:" +
                                                                          "((F1 P F2) AND (F2 P F3) AND (P TYPE TRANSITIVEPROPERTY)) => (F1 P F3)",
                                                                          13,
                                                                          TransitivePropertyEntailmentExec);
			#endregion
			
        }
        #endregion

        #region Methods
		
		#region RDFS
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
		
		#region OWL-DL
		/// <summary>
        /// EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy:
        /// ((C1 EQUIVALENTCLASS C2) AND (C2 EQUIVALENTCLASS C3)) => (C1 EQUIVALENTCLASS C3)
        /// </summary>
        internal static Int64 EquivalentClassTransitivityExec(RDFOntology ontology,
                                                              RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var equivalentClass  = RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty();
            foreach (var c      in ontology.Model.ClassModel) {

                //Enlist the equivalent classes of the current class
                var equivclasses = ontology.Model.ClassModel.EnlistEquivalentClassesOf(c);
                foreach (var ec in equivclasses) {

                    //Create the inference as a taxonomy entry
                    var sem_infA = new RDFOntologyTaxonomyEntry(c, equivalentClass, ec).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                    var sem_infB = new RDFOntologyTaxonomyEntry(ec, equivalentClass, c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Model.ClassModel.Relations.EquivalentClass.AddEntry(sem_infA)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "EquivalentClassTransitivity", sem_infA));
                    }
                    if (ontology.Model.ClassModel.Relations.EquivalentClass.AddEntry(sem_infB)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "EquivalentClassTransitivity", sem_infB));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy:
        /// ((C1 EQUIVALENTCLASS C2) AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)
        /// ((C1 SUBCLASSOF C2)      AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)
        /// ((C1 DISJOINTWITH C2)    AND (C2 EQUIVALENTCLASS C3)) => (C1 DISJOINTWITH C3)
        /// </summary>
        internal static Int64 DisjointWithEntailmentExec(RDFOntology ontology,
                                                         RDFOntologyReasonerReport report) {
            var inferenceCounter  = 0;
            var disjointWith      = RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty();
            foreach (var c       in ontology.Model.ClassModel) {

                //Enlist the disjoint classes of the current class
                var disjclasses   = ontology.Model.ClassModel.EnlistDisjointClassesWith(c);
                foreach (var dwc in disjclasses) {

                    //Create the inference as a taxonomy entry
                    var sem_infA  = new RDFOntologyTaxonomyEntry(c, disjointWith, dwc).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                    var sem_infB  = new RDFOntologyTaxonomyEntry(dwc, disjointWith, c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Model.ClassModel.Relations.DisjointWith.AddEntry(sem_infA)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "DisjointWithEntailment", sem_infA));
                    }
                    if (ontology.Model.ClassModel.Relations.DisjointWith.AddEntry(sem_infB)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "DisjointWithEntailment", sem_infB));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy:
        /// ((P1 EQUIVALENTPROPERTY P2) AND (P2 EQUIVALENTPROPERTY P3)) => (P1 EQUIVALENTPROPERTY P3)
        /// </summary>
        internal static Int64 EquivalentPropertyTransitivityExec(RDFOntology ontology,
                                                                 RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var equivProperty    = RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToRDFOntologyObjectProperty();

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                  !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p      in availableprops) {

                //Enlist the equivalent properties of the current property
                var equivprops   = ontology.Model.PropertyModel.EnlistEquivalentPropertiesOf(p);
                foreach (var ep in equivprops) {

                    //Create the inference as a taxonomy entry
                    var sem_infA = new RDFOntologyTaxonomyEntry(p, equivProperty, ep).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                    var sem_infB = new RDFOntologyTaxonomyEntry(ep, equivProperty, p).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Model.PropertyModel.Relations.EquivalentProperty.AddEntry(sem_infA)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "EquivalentPropertyTransitivity", sem_infA));
                    }
                    if (ontology.Model.PropertyModel.Relations.EquivalentProperty.AddEntry(sem_infB)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "EquivalentPropertyTransitivity", sem_infB));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// SameAsTransitivity implements structural entailments based on 'owl:sameAs' taxonomy:
        /// ((F1 SAMEAS F2) AND (F2 SAMEAS F3)) => (F1 SAMEAS F3)
        /// </summary>
        internal static Int64 SameAsTransitivityExec(RDFOntology ontology,
                                                     RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var sameAs           = RDFVocabulary.OWL.SAME_AS.ToRDFOntologyObjectProperty();
            foreach (var f      in ontology.Data) {

                //Enlist the same facts of the current fact
                var samefacts    = ontology.Data.EnlistSameFactsAs(f);
                foreach (var sf in samefacts) {

                    //Create the inference as a taxonomy entry
                    var sem_infA = new RDFOntologyTaxonomyEntry(f, sameAs, sf).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                    var sem_infB = new RDFOntologyTaxonomyEntry(sf, sameAs, f).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Data.Relations.SameAs.AddEntry(sem_infA)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsTransitivity", sem_infA));
                    }
                    if (ontology.Data.Relations.SameAs.AddEntry(sem_infB)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsTransitivity", sem_infB));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy:
        /// ((F1 SAMEAS F2)        AND (F2 DIFFERENTFROM F3)) => (F1 DIFFERENTFROM F3)
        /// ((F1 DIFFERENTFROM F2) AND (F2 SAMEAS F3))        => (F1 DIFFERENTFROM F3)
        /// </summary>
        internal static Int64 DifferentFromEntailmentExec(RDFOntology ontology,
                                                          RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;
            var differentFrom    = RDFVocabulary.OWL.DIFFERENT_FROM.ToRDFOntologyObjectProperty();
            foreach (var f      in ontology.Data) {

                //Enlist the different facts of the current fact
                var differfacts  = ontology.Data.EnlistDifferentFactsFrom(f);
                foreach (var df in differfacts) {

                    //Create the inference as a taxonomy entry
                    var sem_infA = new RDFOntologyTaxonomyEntry(f, differentFrom, df).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                    var sem_infB = new RDFOntologyTaxonomyEntry(df, differentFrom, f).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                    //Add the inference to the ontology and to the report
                    if (ontology.Data.Relations.DifferentFrom.AddEntry(sem_infA)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DifferentFromEntailment", sem_infA));
                    }
                    if (ontology.Data.Relations.DifferentFrom.AddEntry(sem_infB)) {
                        inferenceCounter++;
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DifferentFromEntailment", sem_infB));
                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy:
        /// ((F1 P1 F2) AND (P1 INVERSEOF P2)) => (F2 P2 F1)
        /// </summary>
        internal static Int64 InverseOfEntailmentExec(RDFOntology ontology,
                                                      RDFOntologyReasonerReport report) {
            var inferenceCounter = 0;

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and annotation/datatype properties)
            var availableprops   = ontology.Model.PropertyModel.Where(prop => prop.IsObjectProperty() &&
                                                                                  !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p1     in availableprops) {

                //Filter the assertions using the current property (F1 P1 F2)
                var p1Asns       = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p1);

                //Enlist the inverse properties of the current property
                var inverseprops = ontology.Model.PropertyModel.EnlistInversePropertiesOf((RDFOntologyObjectProperty)p1);
                foreach (var p2 in inverseprops) {

                    //Iterate the compatible assertions
                    foreach (var p1Asn in p1Asns) {

                        //Taxonomy-check for securing inference consistency
                        if (p2.IsObjectProperty() && p1Asn.TaxonomyObject.IsFact()) {

                            //Create the inference as a taxonomy entry
                            var sem_inf = new RDFOntologyTaxonomyEntry(p1Asn.TaxonomyObject, p2, p1Asn.TaxonomySubject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the ontology and to the report
                            if (ontology.Data.Relations.Assertions.AddEntry(sem_inf)) {
                                inferenceCounter++;
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "InverseOfEntailment", sem_inf));
                            }

                        }

                    }

                }
            }

            return inferenceCounter;
        }

        /// <summary>
        /// SameAsEntailment implements data entailments based on 'owl:sameAs' taxonomy:
        /// ((F1 P F2) AND (F1 SAMEAS F3)) => (F3 P F2)
        /// ((F1 P F2) AND (F2 SAMEAS F3)) => (F1 P F3)
        /// </summary>
        internal static Int64 SameAsEntailmentExec(RDFOntology ontology,
                                                   RDFOntologyReasonerReport report) {
            var inferenceCounter         = 0;
            foreach (var f1             in ontology.Data) {

                //Enlist the same facts of the current fact
                var sameFacts            = ontology.Data.EnlistSameFactsAs(f1);
                if (sameFacts.FactsCount > 0) {

                    //Filter the assertions using the current fact
                    var f1AsnsSubj       = ontology.Data.Relations.Assertions.SelectEntriesBySubject(f1);
                    var f1AsnsObj        = ontology.Data.Relations.Assertions.SelectEntriesByObject(f1);

                    //Enlist the same facts of the current fact
                    foreach (var f2     in sameFacts) {

                        #region Subject-Side
                        //Iterate the assertions having the current fact as subject
                        foreach (var f1Asn  in f1AsnsSubj) {

                            //Taxonomy-check for securing inference consistency
                            if (f1Asn.TaxonomyPredicate.IsObjectProperty() && f1Asn.TaxonomyObject.IsFact()) {

                                //Create the inference as a taxonomy entry
                                var sem_infA = new RDFOntologyTaxonomyEntry(f2, f1Asn.TaxonomyPredicate, f1Asn.TaxonomyObject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the ontology and to the report
                                if (ontology.Data.Relations.Assertions.AddEntry(sem_infA)) {
                                    inferenceCounter++;
                                    report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsEntailment", sem_infA));
                                }

                            }

                        }
                        #endregion

                        #region Object-Side
                        //Iterate the assertions having the current fact as object
                        foreach (var f1Asn  in f1AsnsObj) {

                            //Taxonomy-check for securing inference consistency
                            if (f1Asn.TaxonomyPredicate.IsObjectProperty() && f2.IsFact()) {

                                //Create the inference as a taxonomy entry
                                var sem_infB = new RDFOntologyTaxonomyEntry(f1Asn.TaxonomySubject, f1Asn.TaxonomyPredicate, f2).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the ontology and to the report
                                if (ontology.Data.Relations.Assertions.AddEntry(sem_infB)) {
                                    inferenceCounter++;
                                    report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsEntailment", sem_infB));
                                }

                            }

                        }
                        #endregion

                    }

                }

            }
            return inferenceCounter;
        }

        /// <summary>
        /// SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom:
        /// ((F1 P F2) AND (P TYPE SYMMETRICPROPERTY)) => (F2 P F1)
        /// </summary>
        internal static Int64 SymmetricPropertyEntailmentExec(RDFOntology ontology,
                                                              RDFOntologyReasonerReport report) {
            var inferenceCounter   = 0;

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and not-symmetric properties)
            var availableprops      = ontology.Model.PropertyModel.Where(prop => prop.IsSymmetricProperty() &&
                                                                                   !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p         in availableprops) {

                //Filter the assertions using the current property (F1 P F2)
                var pAsns           = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                //Iterate those assertions
                foreach (var pAsn  in pAsns) {

                    //Taxonomy-check for securing inference consistency
                    if (pAsn.TaxonomyObject.IsFact()) {

                        //Create the inference as a taxonomy entry
                        var sem_inf = new RDFOntologyTaxonomyEntry(pAsn.TaxonomyObject, p, pAsn.TaxonomySubject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the ontology and to the report
                        if (ontology.Data.Relations.Assertions.AddEntry(sem_inf)) {
                            inferenceCounter++;
                            report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SymmetricPropertyEntailment", sem_inf));
                        }

                    }

                }

            }

            return inferenceCounter;
        }

        /// <summary>
        /// TransitivePropertyEntailment implements data entailments based on 'owl:TransitiveProperty' axiom:
        /// ((F1 P F2) AND (F2 P F3) AND (P TYPE TRANSITIVEPROPERTY)) => (F1 P F3)
        /// </summary>
        internal static Int64 TransitivePropertyEntailmentExec(RDFOntology ontology,
                                                               RDFOntologyReasonerReport report) {
            var inferenceCounter   = 0;
            var transPropCache     = new Dictionary<Int64, RDFOntologyData>();

            //Calculate the set of available properties on which to perform the reasoning (exclude BASE properties and not-transitive properties)
            var availableprops     = ontology.Model.PropertyModel.Where(prop => prop.IsTransitiveProperty() &&
                                                                                  !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID)).ToList();
            foreach (var p        in availableprops) {

                //Filter the assertions using the current property (F1 P F2)
                var pAsns          = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                //Iterate those assertions
                foreach (var pAsn in pAsns) {

                    //Taxonomy-check for securing inference consistency
                    if (pAsn.TaxonomyObject.IsFact()) {

                        if (!transPropCache.ContainsKey(pAsn.TaxonomySubject.PatternMemberID)) {
                             transPropCache.Add(pAsn.TaxonomySubject.PatternMemberID, ontology.Data.EnlistTransitiveAssertionsOf((RDFOntologyFact)pAsn.TaxonomySubject, (RDFOntologyObjectProperty)p));
                        }
                        foreach (var te in transPropCache[pAsn.TaxonomySubject.PatternMemberID]) {

                            //Create the inference as a taxonomy entry
                            var sem_inf  = new RDFOntologyTaxonomyEntry(pAsn.TaxonomySubject, p, te).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the ontology and to the report
                            if (ontology.Data.Relations.Assertions.AddEntry(sem_inf)) {
                                inferenceCounter++;
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "TransitivePropertyEntailment", sem_inf));
                            }

                        }

                    }

                }
                transPropCache.Clear();

            }
            return inferenceCounter;
        }
		#endregion
		
		#endregion

    }

}