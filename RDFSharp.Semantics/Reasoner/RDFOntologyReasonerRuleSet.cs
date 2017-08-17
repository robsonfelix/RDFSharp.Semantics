/*
   Copyright 2015-2017 Marco De Salvo

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

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyReasonerRuleSet represents a collection of rules available to reasoners.
    /// </summary>
    public class RDFOntologyReasonerRuleSet {

        #region RDFS
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
                SubClassTransitivity    = new RDFOntologyReasonerRule("SubClassTransitivity",
                                                                       "SubClassTransitivity (rdfs11) implements structural entailments based on 'rdfs:subClassOf' taxonomy:" +
                                                                       "((C1 SUBCLASSOF C2)      AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)" +
                                                                       "((C1 SUBCLASSOF C2)      AND (C2 EQUIVALENTCLASS C3)) => (C1 SUBCLASSOF C3)" +
                                                                       "((C1 EQUIVALENTCLASS C2) AND (C2 SUBCLASSOF C3))      => (C1 SUBCLASSOF C3)",
                                                                       SubClassTransitivityExec);

                //SubPropertyTransitivity (rdfs5)
                SubPropertyTransitivity = new RDFOntologyReasonerRule("SubPropertyTransitivity",
                                                                       "SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                       "((P1 SUBPROPERTYOF P2)      AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)" +
                                                                       "((P1 SUBPROPERTYOF P2)      AND (P2 EQUIVALENTPROPERTY P3)) => (P1 SUBPROPERTYOF P3)" +
                                                                       "((P1 EQUIVALENTPROPERTY P2) AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)",
                                                                       SubPropertyTransitivityExec);

                //ClassTypeEntailment (rdfs9)
                ClassTypeEntailment     = new RDFOntologyReasonerRule("ClassTypeEntailment",
                                                                       "ClassTypeEntailment (rdfs9) implements structural entailments based on 'rdf:type' taxonomy:" +
                                                                       "((F TYPE C1) AND (C1 SUBCLASSOF C2))      => (F TYPE C2)" +
                                                                       "((F TYPE C1) AND (C1 EQUIVALENTCLASS C2)) => (F TYPE C2)",
                                                                       ClassTypeEntailmentExec);

                //PropertyEntailment (rdfs7)
                PropertyEntailment      = new RDFOntologyReasonerRule("PropertyEntailment",
                                                                       "PropertyEntailment (rdfs7) implements data entailments based on 'rdfs:subPropertyOf' taxonomy:" +
                                                                       "((F1 P1 F2) AND (P1 SUBPROPERTYOF P2))      => (F1 P2 F2)" +
                                                                       "((F1 P1 F2) AND (P1 EQUIVALENTPROPERTY P2)) => (F1 P2 F2)",
                                                                       PropertyEntailmentExec);

                //DomainEntailment (rdfs2)
                DomainEntailment        = new RDFOntologyReasonerRule("DomainEntailment",
                                                                       "DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy:" +
                                                                       "((F1 P F2) AND (P RDFS:DOMAIN C)) => (F1 RDF:TYPE C)",
                                                                       DomainEntailmentExec);

                //RangeEntailment (rdfs3)
                RangeEntailment         = new RDFOntologyReasonerRule("RangeEntailment",
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
            internal static void SubClassTransitivityExec(RDFOntology ontology,
                                                          RDFOntologyReasonerReport report) {
                var subClassOf       = RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty();
                foreach(var c       in ontology.Model.ClassModel) {
                    foreach(var sc  in RDFOntologyReasonerHelper.EnlistSuperClassesOf(c, ontology.Model.ClassModel)) {

                        //Create the inference as a taxonomy entry
                        var sem_inf  = new RDFOntologyTaxonomyEntry(c, subClassOf, sc).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "SubClassTransitivity", sem_inf));

                    }
                }
            }

            /// <summary>
            /// SubPropertyTransitivity (rdfs5) implements structural entailments based on 'rdfs:subPropertyOf' taxonomy:
            /// ((P1 SUBPROPERTYOF P2)      AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)
            /// ((P1 SUBPROPERTYOF P2)      AND (P2 EQUIVALENTPROPERTY P3)) => (P1 SUBPROPERTYOF P3)
            /// ((P1 EQUIVALENTPROPERTY P2) AND (P2 SUBPROPERTYOF P3))      => (P1 SUBPROPERTYOF P3)
            /// </summary>
            internal static void SubPropertyTransitivityExec(RDFOntology ontology,
                                                             RDFOntologyReasonerReport report) {
                var subPropertyOf    = RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToRDFOntologyObjectProperty();
                foreach(var p       in ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                       !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {
                    foreach(var sp  in RDFOntologyReasonerHelper.EnlistSuperPropertiesOf(p, ontology.Model.PropertyModel)) {

                        //Create the inference as a taxonomy entry
                        var sem_inf  = new RDFOntologyTaxonomyEntry(p, subPropertyOf, sp).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "SubPropertyTransitivity", sem_inf));

                    }
                }
            }

            /// <summary>
            /// ClassTypeEntailment (rdfs9) implements structural entailments based on 'rdf:type' taxonomy:
            /// ((F TYPE C1) AND (C1 SUBCLASSOF C2))      => (F TYPE C2)
            /// ((F TYPE C1) AND (C1 EQUIVALENTCLASS C2)) => (F TYPE C2)
            /// </summary>
            internal static void ClassTypeEntailmentExec(RDFOntology ontology,
                                                         RDFOntologyReasonerReport report) {
                var type            = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();
                foreach(var c      in ontology.Model.ClassModel.Where(cls => !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(cls.PatternMemberID)
                                                                                && !RDFOntologyReasonerHelper.IsLiteralCompatibleClass(cls, ontology.Model.ClassModel))) {
                    foreach(var f  in RDFSemanticsUtilities.EnlistMembersOfNonLiteralCompatibleClass(c, ontology)) {

                        //Create the inference as a taxonomy entry
                        var sem_inf = new RDFOntologyTaxonomyEntry(f, type, c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "ClassTypeEntailment", sem_inf));

                    }
                }
            }

            /// <summary>
            /// "PropertyEntailment (rdfs7) implements data entailments based on 'rdfs:subPropertyOf' taxonomy:"
            /// "((F1 P1 F2) AND (P1 SUBPROPERTYOF P2))      => (F1 P2 F2)"
            /// "((F1 P1 F2) AND (P1 EQUIVALENTPROPERTY P2)) => (F1 P2 F2)"
            /// </summary>
            internal static void PropertyEntailmentExec(RDFOntology ontology,
                                                        RDFOntologyReasonerReport report) {
                foreach(var p1             in ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                            !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {

                    //Filter the assertions using the current property (F1 P1 F2)
                    var p1Asns              = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p1);

                    //Enlist the compatible properties of the current property (P1 [SUBPROPERTYOF|EQUIVALENTPROPERTY] P2)
                    foreach(var p2         in RDFOntologyReasonerHelper.EnlistSuperPropertiesOf(p1, ontology.Model.PropertyModel)
                                                    .UnionWith(RDFOntologyReasonerHelper.EnlistEquivalentPropertiesOf(p1, ontology.Model.PropertyModel))) {

                        //Iterate the compatible assertions
                        foreach(var p1Asn  in p1Asns) {

                            //Taxonomy-check for securing inference consistency
                            if((p2.IsObjectProperty()   && p1Asn.TaxonomyObject.IsFact())     || 
                               (p2.IsDatatypeProperty() && p1Asn.TaxonomyObject.IsLiteral()))  {

                                //Create the inference as a taxonomy entry
                                var sem_inf = new RDFOntologyTaxonomyEntry(p1Asn.TaxonomySubject, p2, p1Asn.TaxonomyObject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the report
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "PropertyEntailment", sem_inf));

                            }

                        }

                    }

                }

            }

            /// <summary>
            /// "DomainEntailment (rdfs2) implements structural entailments based on 'rdfs:domain' taxonomy:"
            /// "((F1 P F2) AND (P RDFS:DOMAIN C)) => (F1 RDF:TYPE C)"
            /// </summary>
            internal static void DomainEntailmentExec(RDFOntology ontology,
                                                      RDFOntologyReasonerReport report) {
                var type                  = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();
                foreach(var p            in ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                            !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {
                    if (p.Domain         != null) {

                        //Filter the assertions using the current property (F1 P1 F2)
                        var pAsns         = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                        //Iterate the related assertions
                        foreach(var pAsn in pAsns) {

                            //Create the inference as a taxonomy entry
                            var sem_inf   = new RDFOntologyTaxonomyEntry(pAsn.TaxonomySubject, type, p.Domain).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the report
                            report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DomainEntailment", sem_inf));

                        }

                    }
                }
            }

            /// <summary>
            /// "RangeEntailment (rdfs3) implements structural entailments based on 'rdfs:range' taxonomy:"
            /// "((F1 P F2) AND (P RDFS:RANGE C)) => (F2 RDF:TYPE C)"
            /// </summary>
            internal static void RangeEntailmentExec(RDFOntology ontology,
                                                     RDFOntologyReasonerReport report) {
                var type                    = RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty();
                foreach(var p              in ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                            !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {
                    if (p.Range            != null) {

                        //Filter the assertions using the current property (F1 P1 F2)
                        var pAsns           = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                        //Iterate the related assertions
                        foreach(var pAsn   in pAsns) {

                            //Taxonomy-check for securing inference consistency
                            if (pAsn.TaxonomyObject.IsFact()) {

                                //Create the inference as a taxonomy entry
                                var sem_inf = new RDFOntologyTaxonomyEntry(pAsn.TaxonomyObject, type, p.Range).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the report
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "RangeEntailment", sem_inf));

                            }

                        }

                    }
                }
            }
            #endregion

        }
        #endregion

        #region OWL_DL
        /// <summary>
        /// OWL_DL implements a subset of OWL-DL entailment rules
        /// </summary>
        public static class OWL_DL {

            #region Properties
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

            #region Ctors
            /// <summary>
            /// Static-ctor to initialize the OWL_DL ruleset
            /// </summary>
            static OWL_DL() {

                //EquivalentClassTransitivity
                EquivalentClassTransitivity    = new RDFOntologyReasonerRule("EquivalentClassTransitivity",
                                                                              "EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy:" +
                                                                              "((C1 EQUIVALENTCLASS C2) AND (C2 EQUIVALENTCLASS C3)) => (C1 EQUIVALENTCLASS C3)",
                                                                              EquivalentClassTransitivityExec);

                //DisjointWithEntailment
                DisjointWithEntailment         = new RDFOntologyReasonerRule("DisjointWithEntailment",
                                                                              "DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy:" +
                                                                              "((C1 EQUIVALENTCLASS C2) AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                              "((C1 SUBCLASSOF C2)      AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                              "((C1 DISJOINTWITH C2)    AND (C2 EQUIVALENTCLASS C3)) => (C1 DISJOINTWITH C3)",
                                                                              DisjointWithEntailmentExec);

                //EquivalentPropertyTransitivity
                EquivalentPropertyTransitivity = new RDFOntologyReasonerRule("EquivalentPropertyTransitivity",
                                                                              "EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy:" +
                                                                              "((P1 EQUIVALENTPROPERTY P2) AND (P2 EQUIVALENTPROPERTY P3)) => (P1 EQUIVALENTPROPERTY P3)",
                                                                              EquivalentPropertyTransitivityExec);

                //SameAsTransitivity
                SameAsTransitivity             = new RDFOntologyReasonerRule("SameAsTransitivity",
                                                                              "SameAsTransitivity implements structural entailments based on 'owl:SameAs' taxonomy:" +
                                                                              "((F1 SAMEAS F2) AND (F2 SAMEAS F3)) => (F1 SAMEAS F3)",
                                                                              SameAsTransitivityExec);

                //DifferentFromEntailment
                DifferentFromEntailment        = new RDFOntologyReasonerRule("DifferentFromEntailment",
                                                                              "DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy:" +
                                                                              "((F1 SAMEAS F2)        AND (F2 DIFFERENTFROM F3)) => (F1 DIFFERENTFROM F3)" +
                                                                              "((F1 DIFFERENTFROM F2) AND (F2 SAMEAS F3))        => (F1 DIFFERENTFROM F3)",
                                                                              DifferentFromEntailmentExec);

                //InverseOfEntailment
                InverseOfEntailment            = new RDFOntologyReasonerRule("InverseOfEntailment",
                                                                              "InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy:" +
                                                                              "((F1 P1 F2) AND (P1 INVERSEOF P2)) => (F2 P2 F1)",
                                                                              InverseOfEntailmentExec);

                //SameAsEntailment
                SameAsEntailment               = new RDFOntologyReasonerRule("SameAsEntailment",
                                                                              "SameAsEntailment implements data entailments based on 'owl:SameAs' taxonomy:" +
                                                                              "((F1 P F2) AND (F1 SAMEAS F3)) => (F3 P F2)" +
                                                                              "((F1 P F2) AND (F2 SAMEAS F3)) => (F1 P F3)",
                                                                              SameAsEntailmentExec);

                //SymmetricPropertyEntailment
                SymmetricPropertyEntailment    = new RDFOntologyReasonerRule("SymmetricPropertyEntailment",
                                                                              "SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom:" +
                                                                              "((F1 P F2) AND (P TYPE SYMMETRICPROPERTY)) => (F2 P F1)",
                                                                              SymmetricPropertyEntailmentExec);

                //TransitivePropertyEntailment
                TransitivePropertyEntailment   = new RDFOntologyReasonerRule("TransitivePropertyEntailment",
                                                                              "TransitivePropertyEntailment implements data entailments based on 'owl:TransitiveProperty' axiom:" +
                                                                              "((F1 P F2) AND (F2 P F3) AND (P TYPE TRANSITIVEPROPERTY)) => (F1 P F3)",
                                                                              TransitivePropertyEntailmentExec);

            }
            #endregion

            #region Methods
            /// <summary>
            /// EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy:
            /// ((C1 EQUIVALENTCLASS C2) AND (C2 EQUIVALENTCLASS C3)) => (C1 EQUIVALENTCLASS C3)
            /// </summary>
            internal static void EquivalentClassTransitivityExec(RDFOntology ontology,
                                                                 RDFOntologyReasonerReport report) {
                var equivalentClass  = RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty();
                foreach(var c       in ontology.Model.ClassModel) {
                    foreach(var ec  in RDFOntologyReasonerHelper.EnlistEquivalentClassesOf(c, ontology.Model.ClassModel)) {

                        //Create the inference as a taxonomy entry
                        var sem_infA = new RDFOntologyTaxonomyEntry(c,  equivalentClass, ec).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                        var sem_infB = new RDFOntologyTaxonomyEntry(ec, equivalentClass,  c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "EquivalentClassTransitivity", sem_infA));
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "EquivalentClassTransitivity", sem_infB));

                    }
                }
            }

            /// <summary>
            /// DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy:
            /// ((C1 EQUIVALENTCLASS C2) AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)
            /// ((C1 SUBCLASSOF C2)      AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)
            /// ((C1 DISJOINTWITH C2)    AND (C2 EQUIVALENTCLASS C3)) => (C1 DISJOINTWITH C3)
            /// </summary>
            internal static void DisjointWithEntailmentExec(RDFOntology ontology,
                                                            RDFOntologyReasonerReport report) {
                var disjointWith     = RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty();
                foreach(var c       in ontology.Model.ClassModel) {
                    foreach(var dwc in RDFOntologyReasonerHelper.EnlistDisjointClassesWith(c, ontology.Model.ClassModel)) {

                        //Create the inference as a taxonomy entry
                        var sem_infA = new RDFOntologyTaxonomyEntry(c,   disjointWith, dwc).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                        var sem_infB = new RDFOntologyTaxonomyEntry(dwc, disjointWith,   c).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "DisjointWithEntailment", sem_infA));
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.ClassModel, "DisjointWithEntailment", sem_infB));

                    }
                }
            }

            /// <summary>
            /// EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy:
            /// ((P1 EQUIVALENTPROPERTY P2) AND (P2 EQUIVALENTPROPERTY P3)) => (P1 EQUIVALENTPROPERTY P3)
            /// </summary>
            internal static void EquivalentPropertyTransitivityExec(RDFOntology ontology,
                                                                    RDFOntologyReasonerReport report) {
                var equivProperty    = RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToRDFOntologyObjectProperty();
                foreach(var p       in ontology.Model.PropertyModel.Where(prop => !prop.IsAnnotationProperty() &&
                                                                                       !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {
                    foreach(var ep  in RDFOntologyReasonerHelper.EnlistEquivalentPropertiesOf(p, ontology.Model.PropertyModel)) {

                        //Create the inference as a taxonomy entry
                        var sem_infA = new RDFOntologyTaxonomyEntry(p,  equivProperty, ep).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                        var sem_infB = new RDFOntologyTaxonomyEntry(ep, equivProperty,  p).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "EquivalentPropertyTransitivity", sem_infA));
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.PropertyModel, "EquivalentPropertyTransitivity", sem_infB));

                    }
                }
            }

            /// <summary>
            /// SameAsTransitivity implements structural entailments based on 'owl:sameAs' taxonomy:
            /// ((F1 SAMEAS F2) AND (F2 SAMEAS F3)) => (F1 SAMEAS F3)
            /// </summary>
            internal static void SameAsTransitivityExec(RDFOntology ontology,
                                                        RDFOntologyReasonerReport report) {
                var sameAs           = RDFVocabulary.OWL.SAME_AS.ToRDFOntologyObjectProperty();
                foreach(var f       in ontology.Data) {
                    foreach(var sf  in RDFOntologyReasonerHelper.EnlistSameFactsAs(f, ontology.Data)) {

                        //Create the inference as a taxonomy entry
                        var sem_infA = new RDFOntologyTaxonomyEntry(f,  sameAs, sf).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                        var sem_infB = new RDFOntologyTaxonomyEntry(sf, sameAs,  f).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsTransitivity", sem_infA));
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsTransitivity", sem_infB));

                    }
                }
            }

            /// <summary>
            /// DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy:
            /// ((F1 SAMEAS F2)        AND (F2 DIFFERENTFROM F3)) => (F1 DIFFERENTFROM F3)
            /// ((F1 DIFFERENTFROM F2) AND (F2 SAMEAS F3))        => (F1 DIFFERENTFROM F3)
            /// </summary>
            internal static void DifferentFromEntailmentExec(RDFOntology ontology,
                                                             RDFOntologyReasonerReport report) {
                var differentFrom    = RDFVocabulary.OWL.DIFFERENT_FROM.ToRDFOntologyObjectProperty();
                foreach(var f       in ontology.Data) {
                    foreach(var df  in RDFOntologyReasonerHelper.EnlistDifferentFactsFrom(f, ontology.Data)) {

                        //Create the inference as a taxonomy entry
                        var sem_infA = new RDFOntologyTaxonomyEntry(f,  differentFrom, df).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);
                        var sem_infB = new RDFOntologyTaxonomyEntry(df, differentFrom,  f).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                        //Add the inference to the report
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DifferentFromEntailment", sem_infA));
                        report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "DifferentFromEntailment", sem_infB));

                    }
                }
            }

            /// <summary>
            /// InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy:
            /// ((F1 P1 F2) AND (P1 INVERSEOF P2)) => (F2 P2 F1)
            /// </summary>
            internal static void InverseOfEntailmentExec(RDFOntology ontology,
                                                         RDFOntologyReasonerReport report) {
                foreach(var p1             in ontology.Model.PropertyModel.Where(prop => prop.IsObjectProperty() &&
                                                                                            !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {

                    //Filter the assertions using the current property (F1 P1 F2)
                    var p1Asns              = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p1);

                    //Enlist the inverse properties of the current property
                    foreach(var p2         in RDFOntologyReasonerHelper.EnlistInversePropertiesOf((RDFOntologyObjectProperty)p1, ontology.Model.PropertyModel)) {

                        //Iterate the compatible assertions
                        foreach(var p1Asn  in p1Asns) {

                            //Taxonomy-check for securing inference consistency
                            if (p2.IsObjectProperty() && p1Asn.TaxonomyObject.IsFact()) {

                                //Create the inference as a taxonomy entry
                                var sem_inf = new RDFOntologyTaxonomyEntry(p1Asn.TaxonomyObject, p2, p1Asn.TaxonomySubject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the report
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "InverseOfEntailment", sem_inf));

                            }

                        }

                    }
                }
            }

            /// <summary>
            /// SameAsEntailment implements data entailments based on 'owl:sameAs' taxonomy:
            /// ((F1 P F2) AND (F1 SAMEAS F3)) => (F3 P F2)
            /// ((F1 P F2) AND (F2 SAMEAS F3)) => (F1 P F3)
            /// </summary>
            internal static void SameAsEntailmentExec(RDFOntology ontology,
                                                      RDFOntologyReasonerReport report) {
                foreach(var f1                 in ontology.Data) {
                    var sameFacts               = RDFOntologyReasonerHelper.EnlistSameFactsAs(f1, ontology.Data);
                    if (sameFacts.FactsCount    > 0) {

                        //Filter the assertions using the current fact
                        var f1AsnsSubj          = ontology.Data.Relations.Assertions.SelectEntriesBySubject(f1);
                        var f1AsnsObj           = ontology.Data.Relations.Assertions.SelectEntriesByObject(f1);

                        //Enlist the same facts of the current fact
                        foreach(var f2         in sameFacts) {

                            #region Subject-Side
                            //Iterate the assertions having the current fact as subject
                            foreach(var f1Asn  in f1AsnsSubj) {

                                //Taxonomy-check for securing inference consistency
                                if (f1Asn.TaxonomyPredicate.IsObjectProperty() && f1Asn.TaxonomyObject.IsFact()) {

                                    //Create the inference as a taxonomy entry
                                    var sem_infA = new RDFOntologyTaxonomyEntry(f2, f1Asn.TaxonomyPredicate, f1Asn.TaxonomyObject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                    //Add the inference to the report
                                    report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsEntailment", sem_infA));

                                }

                            }
                            #endregion

                            #region Object-Side
                            //Iterate the assertions having the current fact as object
                            foreach(var f1Asn  in f1AsnsObj) {

                                //Taxonomy-check for securing inference consistency
                                if (f1Asn.TaxonomyPredicate.IsObjectProperty() && f2.IsFact()) {

                                    //Create the inference as a taxonomy entry
                                    var sem_infB = new RDFOntologyTaxonomyEntry(f1Asn.TaxonomySubject, f1Asn.TaxonomyPredicate, f2).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                    //Add the inference to the report
                                    report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SameAsEntailment", sem_infB));

                                }

                            }
                            #endregion

                        }

                    }
                }
            }

            /// <summary>
            /// SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom:
            /// ((F1 P F2) AND (P TYPE SYMMETRICPROPERTY)) => (F2 P F1)
            /// </summary>
            internal static void SymmetricPropertyEntailmentExec(RDFOntology ontology,
                                                                 RDFOntologyReasonerReport report) {
                foreach(var p          in ontology.Model.PropertyModel.Where(prop => prop.IsSymmetricProperty() &&
                                                                                         !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {

                    //Filter the assertions using the current property (F1 P F2)
                    var pAsns           = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                    //Iterate those assertions
                    foreach(var pAsn   in pAsns) {

                        //Taxonomy-check for securing inference consistency
                        if (pAsn.TaxonomyObject.IsFact()) {

                            //Create the inference as a taxonomy entry
                            var sem_inf = new RDFOntologyTaxonomyEntry(pAsn.TaxonomyObject, p, pAsn.TaxonomySubject).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                            //Add the inference to the report
                            report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "SymmetricPropertyEntailment", sem_inf));

                        }

                    }

                }
            }

            /// <summary>
            /// TransitivePropertyEntailment implements data entailments based on 'owl:TransitiveProperty' axiom:
            /// ((F1 P F2) AND (F2 P F3) AND (P TYPE TRANSITIVEPROPERTY)) => (F1 P F3)
            /// </summary>
            internal static void TransitivePropertyEntailmentExec(RDFOntology ontology,
                                                                  RDFOntologyReasonerReport report) {
                var transPropCache      = new Dictionary<Int64, RDFOntologyData>();
                foreach(var p          in ontology.Model.PropertyModel.Where(prop => prop.IsTransitiveProperty() &&
                                                                                         !RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(prop.PatternMemberID))) {

                    //Filter the assertions using the current property (F1 P F2)
                    var pAsns           = ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p);

                    //Iterate those assertions
                    foreach(var pAsn   in pAsns) {

                        //Taxonomy-check for securing inference consistency
                        if (pAsn.TaxonomyObject.IsFact()) {

                            if(!transPropCache.ContainsKey(pAsn.TaxonomySubject.PatternMemberID)) {
                                transPropCache.Add(pAsn.TaxonomySubject.PatternMemberID, RDFOntologyReasonerHelper.EnlistTransitiveAssertionsOf((RDFOntologyFact)pAsn.TaxonomySubject, (RDFOntologyObjectProperty)p, ontology.Data));
                            }
                            foreach(var te in transPropCache[pAsn.TaxonomySubject.PatternMemberID]) {

                                //Create the inference as a taxonomy entry
                                var sem_inf = new RDFOntologyTaxonomyEntry(pAsn.TaxonomySubject, p, te).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner);

                                //Add the inference to the report
                                report.AddEvidence(new RDFOntologyReasonerEvidence(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory.Data, "TransitivePropertyEntailment", sem_inf));

                            }

                        }

                    }
                    transPropCache.Clear();

                }
            }
            #endregion

        }        
        #endregion

    }

}