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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyReasonerReport represents a detailed report of an ontology reasoner's activity.
    /// </summary>
    public class RDFOntologyReasonerReport: IEnumerable<RDFOntologyReasonerEvidence> {

        #region Properties
        /// <summary>
        /// Counter of the evidences
        /// </summary>
        public Int32 EvidencesCount {
            get { return this.Evidences.Count; }
        }

        /// <summary>
        /// Gets an enumerator on the evidences for iteration
        /// </summary>
        public IEnumerator<RDFOntologyReasonerEvidence> EvidencesEnumerator {
            get { return this.Evidences.Values.GetEnumerator(); }
        }

        /// <summary>
        /// Dictionary of evidences
        /// </summary>
        internal Dictionary<Int64, RDFOntologyReasonerEvidence> Evidences { get; set; }

        /// <summary>
        /// Synchronization lock
        /// </summary>
        internal Object SyncLock { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty reasoner report
        /// </summary>
        internal RDFOntologyReasonerReport() {
            this.SyncLock  = new Object();
            this.Evidences = new Dictionary<Int64, RDFOntologyReasonerEvidence>();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the reasoner report's evidences
        /// </summary>
        IEnumerator<RDFOntologyReasonerEvidence> IEnumerable<RDFOntologyReasonerEvidence>.GetEnumerator() {
            return this.Evidences.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the reasoner report's evidences
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.Evidences.Values.GetEnumerator();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the evidences having the given category
        /// </summary>
        public List<RDFOntologyReasonerEvidence> SelectEvidencesByCategory(RDFSemanticsEnums.RDFOntologyReasonerEvidenceCategory evidenceCategory) {
            return this.Evidences.Values.Where(e => e.EvidenceCategory.Equals(evidenceCategory)).ToList();
        }

        /// <summary>
        /// Gets the evidences having the given provenance rule
        /// </summary>
        public List<RDFOntologyReasonerEvidence> SelectEvidencesByProvenance(String evidenceProvenance = "") {
            return this.Evidences.Values.Where(e => e.EvidenceProvenance.ToUpper().Equals(evidenceProvenance.Trim().ToUpperInvariant(), StringComparison.Ordinal)).ToList();
        }

        /// <summary>
        /// Gets the evidences having the given content subject
        /// </summary>
        public List<RDFOntologyReasonerEvidence> SelectEvidencesByContentSubject(RDFOntologyResource evidenceContentSubject) {
            return this.Evidences.Values.Where(e => e.EvidenceContent.TaxonomySubject.Equals(evidenceContentSubject)).ToList();
        }

        /// <summary>
        /// Gets the evidences having the given content predicate
        /// </summary>
        public List<RDFOntologyReasonerEvidence> SelectEvidencesByContentPredicate(RDFOntologyResource evidenceContentPredicate) {
            return this.Evidences.Values.Where(e => e.EvidenceContent.TaxonomyPredicate.Equals(evidenceContentPredicate)).ToList();
        }

        /// <summary>
        /// Gets the evidences having the given content object
        /// </summary>
        public List<RDFOntologyReasonerEvidence> SelectEvidencesByContentObject(RDFOntologyResource evidenceContentObject) {
            return this.Evidences.Values.Where(e => e.EvidenceContent.TaxonomyObject.Equals(evidenceContentObject)).ToList();
        }

        /// <summary>
        /// Merges the evidences of the reasoner report into the given ontology.
        /// Returns the total number of merged evidences.
        /// </summary>
        public Int32 Merge(RDFOntology ontology) {
            var counter   = 0;

            if (ontology != null) {
                foreach (var evidence in this) {
                    switch (evidence.EvidenceProvenance) {

                        //RDFS
                        case "SubClassTransitivity":
                            if (ontology.Model.ClassModel.Relations.SubClassOf.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "SubPropertyTransitivity":
                            if (ontology.Model.PropertyModel.Relations.SubPropertyOf.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "ClassTypeEntailment":
                            if (ontology.Data.Relations.ClassType.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "PropertyEntailment":
                            if (ontology.Data.Relations.Assertions.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "DomainEntailment":
                            if (ontology.Data.Relations.ClassType.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "RangeEntailment":
                            if (ontology.Data.Relations.ClassType.AddEntry(evidence.EvidenceContent)) counter++;
                            break;

                        //OWL-DL
                        case "EquivalentClassTransitivity":
                            if (ontology.Model.ClassModel.Relations.EquivalentClass.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "DisjointWithEntailment":
                            if (ontology.Model.ClassModel.Relations.DisjointWith.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "EquivalentPropertyTransitivity":
                            if (ontology.Model.PropertyModel.Relations.EquivalentProperty.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "SameAsTransitivity":
                            if (ontology.Data.Relations.SameAs.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "DifferentFromEntailment":
                            if (ontology.Data.Relations.DifferentFrom.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "InverseOfEntailment":
                            if (ontology.Data.Relations.Assertions.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "SameAsEntailment":
                            if (ontology.Data.Relations.Assertions.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "SymmetricPropertyEntailment":
                            if (ontology.Data.Relations.Assertions.AddEntry(evidence.EvidenceContent)) counter++;
                            break;
                        case "TransitivePropertyEntailment":
                            if (ontology.Data.Relations.Assertions.AddEntry(evidence.EvidenceContent)) counter++;
                            break;

                        //OTHERS
                        default: break;

                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Adds the given evidence to the reasoner report
        /// </summary>
        internal void AddEvidence(RDFOntologyReasonerEvidence evidence) {
            lock(this.SyncLock) {
                 if(!this.Evidences.ContainsKey(evidence.EvidenceContent.TaxonomyEntryID)) { 
                     this.Evidences.Add(evidence.EvidenceContent.TaxonomyEntryID, evidence);
                 }
            }
        }
        #endregion

    }

}