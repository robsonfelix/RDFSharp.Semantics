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

namespace RDFSharp.Semantics.Reasoner.RuleSets
{

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
            EquivalentClassTransitivity     = new RDFOntologyReasonerRule("EquivalentClassTransitivity",
                                                                          "EquivalentClassTransitivity implements structural entailments based on 'owl:EquivalentClass' taxonomy:" +
                                                                          "((C1 EQUIVALENTCLASS C2) AND (C2 EQUIVALENTCLASS C3)) => (C1 EQUIVALENTCLASS C3)",
                                                                          EquivalentClassTransitivityExec);

            //DisjointWithEntailment
            DisjointWithEntailment          = new RDFOntologyReasonerRule("DisjointWithEntailment",
                                                                          "DisjointWithEntailment implements structural entailments based on 'owl:DisjointWith' taxonomy:" +
                                                                          "((C1 EQUIVALENTCLASS C2) AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                          "((C1 SUBCLASSOF C2)      AND (C2 DISJOINTWITH C3))    => (C1 DISJOINTWITH C3)" +
                                                                          "((C1 DISJOINTWITH C2)    AND (C2 EQUIVALENTCLASS C3)) => (C1 DISJOINTWITH C3)",
                                                                          DisjointWithEntailmentExec);

            //EquivalentPropertyTransitivity
            EquivalentPropertyTransitivity  = new RDFOntologyReasonerRule("EquivalentPropertyTransitivity",
                                                                          "EquivalentPropertyTransitivity implements structural entailments based on 'owl:EquivalentProperty' taxonomy:" +
                                                                          "((P1 EQUIVALENTPROPERTY P2) AND (P2 EQUIVALENTPROPERTY P3)) => (P1 EQUIVALENTPROPERTY P3)",
                                                                          EquivalentPropertyTransitivityExec);

            //SameAsTransitivity
            SameAsTransitivity              = new RDFOntologyReasonerRule("SameAsTransitivity",
                                                                          "SameAsTransitivity implements structural entailments based on 'owl:SameAs' taxonomy:" +
                                                                          "((F1 SAMEAS F2) AND (F2 SAMEAS F3)) => (F1 SAMEAS F3)",
                                                                          SameAsTransitivityExec);

            //DifferentFromEntailment
            DifferentFromEntailment         = new RDFOntologyReasonerRule("DifferentFromEntailment",
                                                                          "DifferentFromEntailment implements structural entailments based on 'owl:DifferentFrom' taxonomy:" +
                                                                          "((F1 SAMEAS F2)        AND (F2 DIFFERENTFROM F3)) => (F1 DIFFERENTFROM F3)" +
                                                                          "((F1 DIFFERENTFROM F2) AND (F2 SAMEAS F3))        => (F1 DIFFERENTFROM F3)",
                                                                          DifferentFromEntailmentExec);

            //InverseOfEntailment
            InverseOfEntailment             = new RDFOntologyReasonerRule("InverseOfEntailment",
                                                                          "InverseOfEntailment implements data entailments based on 'owl:inverseOf' taxonomy:" +
                                                                          "((F1 P1 F2) AND (P1 INVERSEOF P2)) => (F2 P2 F1)",
                                                                          InverseOfEntailmentExec);

            //SameAsEntailment
            SameAsEntailment                = new RDFOntologyReasonerRule("SameAsEntailment",
                                                                          "SameAsEntailment implements data entailments based on 'owl:SameAs' taxonomy:" +
                                                                          "((F1 P F2) AND (F1 SAMEAS F3)) => (F3 P F2)" +
                                                                          "((F1 P F2) AND (F2 SAMEAS F3)) => (F1 P F3)",
                                                                          SameAsEntailmentExec);

            //SymmetricPropertyEntailment
            SymmetricPropertyEntailment     = new RDFOntologyReasonerRule("SymmetricPropertyEntailment",
                                                                          "SymmetricPropertyEntailment implements data entailments based on 'owl:SymmetricProperty' axiom:" +
                                                                          "((F1 P F2) AND (P TYPE SYMMETRICPROPERTY)) => (F2 P F1)",
                                                                          SymmetricPropertyEntailmentExec);

            //TransitivePropertyEntailment
            TransitivePropertyEntailment    = new RDFOntologyReasonerRule("TransitivePropertyEntailment",
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

    }

}