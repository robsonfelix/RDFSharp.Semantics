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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyTaxonomy represents a register for storing a generic taxonomy relationship.
    /// </summary>
    public sealed class RDFOntologyTaxonomy: IEnumerable<RDFOntologyTaxonomyEntry> {

        #region Properties
        /// <summary>
        /// Category of the ontology taxonomy
        /// </summary>
        public RDFSemanticsEnums.RDFOntologyTaxonomyCategory Category { get; internal set; }

        /// <summary>
        /// Count of the taxonomy entries
        /// </summary>
        public Int64 EntriesCount {
            get { return this.Entries.Count; }
        }

        /// <summary>
        /// Gets the enumerator on the taxonomy entries for iteration
        /// </summary>
        public IEnumerator<RDFOntologyTaxonomyEntry> EntriesEnumerator {
            get { return this.Entries.Values.GetEnumerator(); }
        }

        /// <summary>
        /// Dictionary of ontology entries composing the taxonomy
        /// </summary>
        internal Dictionary<Int64, RDFOntologyTaxonomyEntry> Entries { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology taxonomy of the given category
        /// </summary>
        internal RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory category) {
            this.Category = category;
            this.Entries  = new Dictionary<Int64, RDFOntologyTaxonomyEntry>();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the taxonomy entries
        /// </summary>
        IEnumerator<RDFOntologyTaxonomyEntry> IEnumerable<RDFOntologyTaxonomyEntry>.GetEnumerator() {
            return this.Entries.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the taxonomy entries
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.Entries.Values.GetEnumerator();
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given taxonomy entry to the taxonomy.
        /// Returns true if the insertion has been made.
        /// </summary>
        internal Boolean AddEntry(RDFOntologyTaxonomyEntry taxonomyEntry) {
            if (taxonomyEntry != null) {
                if (!this.ContainsEntry(taxonomyEntry)) {
                     this.Entries.Add(taxonomyEntry.TaxonomyEntryID, taxonomyEntry);
                     return true;
                }
            }
            return false;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the given taxonomy entry from the taxonomy.
        /// Returns true if the deletion has been made.
        /// </summary>
        internal Boolean RemoveEntry(RDFOntologyTaxonomyEntry taxonomyEntry) {
            if (taxonomyEntry != null) {
                if (this.ContainsEntry(taxonomyEntry)) {
                    this.Entries.Remove(taxonomyEntry.TaxonomyEntryID);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Select
        /// <summary>
        /// Checks if the taxonomy contains the given taxonomy entry
        /// </summary>
        internal Boolean ContainsEntry(RDFOntologyTaxonomyEntry taxonomyEntry) {
            return (taxonomyEntry != null && this.Entries.ContainsKey(taxonomyEntry.TaxonomyEntryID));
        }

        /// <summary>
        /// Gets a taxonomy with the entries having the specified ontology resource as subject 
        /// </summary>
        public RDFOntologyTaxonomy SelectEntriesBySubject(RDFOntologyResource subjectResource) {
            var resultTaxonomy     = new RDFOntologyTaxonomy(this.Category);
            if (subjectResource   != null) {                
                foreach (var te   in this.Where(tEntry => tEntry.TaxonomySubject.Equals(subjectResource))) {
                    resultTaxonomy.AddEntry(te);
                }
            }
            return resultTaxonomy;
        }

        /// <summary>
        /// Gets a taxonomy with the entries having the specified ontology resource as predicate 
        /// </summary>
        public RDFOntologyTaxonomy SelectEntriesByPredicate(RDFOntologyResource predicateResource) {
            var resultTaxonomy     = new RDFOntologyTaxonomy(this.Category);
            if (predicateResource != null) {
                foreach (var te   in this.Where(tEntry => tEntry.TaxonomyPredicate.Equals(predicateResource))) {
                    resultTaxonomy.AddEntry(te);
                }
            }
            return resultTaxonomy;
        }

        /// <summary>
        /// Gets a taxonomy with the entries having the specified ontology resource as object 
        /// </summary>
        public RDFOntologyTaxonomy SelectEntriesByObject(RDFOntologyResource objectResource) {
            var resultTaxonomy     = new RDFOntologyTaxonomy(this.Category);
            if (objectResource    != null) {
                foreach (var te   in this.Where(tEntry => tEntry.TaxonomyObject.Equals(objectResource))) {
                    resultTaxonomy.AddEntry(te);
                }
            }
            return resultTaxonomy;
        }
        #endregion

        #region Set
        /// <summary>
        /// Builds a new intersection taxonomy from this taxonomy and a given one
        /// </summary>
        internal RDFOntologyTaxonomy IntersectWith(RDFOntologyTaxonomy taxonomy) {
            var result    = new RDFOntologyTaxonomy(this.Category);
            if (taxonomy != null) {

                //Add intersection triples
                foreach (var te in this) {
                    if  (taxonomy.ContainsEntry(te)) {
                         result.AddEntry(te);
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// Builds a new union taxonomy from this taxonomy and a given one
        /// </summary>
        internal RDFOntologyTaxonomy UnionWith(RDFOntologyTaxonomy taxonomy) {
            var result    = new RDFOntologyTaxonomy(this.Category);

            //Add entries from this taxonomy
            foreach (var te in this) {
                result.AddEntry(te);
            }
            
            //Manage the given taxonomy
            if (taxonomy != null) {

                //Add entries from the given taxonomy
                foreach (var te in taxonomy) {
                    result.AddEntry(te);
                }

            }
            return result;
        }

        /// <summary>
        /// Builds a new difference taxonomy from this taxonomy and a given one
        /// </summary>
        internal RDFOntologyTaxonomy DifferenceWith(RDFOntologyTaxonomy taxonomy) {
            var result    = new RDFOntologyTaxonomy(this.Category);
            if (taxonomy != null) {

                //Add difference entries
                foreach (var te in this) {
                    if  (!taxonomy.ContainsEntry(te)) {
                          result.AddEntry(te);
                    }
                }

            }
            else {

                //Add entries from this taxonomy
                foreach (var te in this) {
                    result.AddEntry(te);
                }

            }
            return result;
        }
        #endregion

        #region Convert
        /// <summary>
        /// Gets a graph representation of this taxonomy, exporting inferences according to the selected behavior
        /// </summary>
        internal RDFGraph ToRDFGraph(RDFSemanticsEnums.RDFOntologyInferenceExportBehavior infexpBehavior) {
            var result    = new RDFGraph();

            //Taxonomy entries
            foreach (var te in this) {
                
                //Do not export semantic inferences
                if (infexpBehavior           == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.None) {
                    if (te.InferenceType     == RDFSemanticsEnums.RDFOntologyInferenceType.None) {
                        result.AddTriple(te.ToRDFTriple());
                    }
                }

                //Export semantic inferences related only to ontology model
                else if(infexpBehavior       == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyModel) {
                    if (this.Category        == RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model      || 
                        this.Category        == RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Annotation) {
                        result.AddTriple(te.ToRDFTriple());
                    }
                    else {
                        if (te.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None) {
                            result.AddTriple(te.ToRDFTriple());
                        }
                    }
                }

                //Export semantic inferences related only to ontology data
                else if(infexpBehavior       == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyData) {
                    if (this.Category        == RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data       ||
                        this.Category        == RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Annotation) {
                        result.AddTriple(te.ToRDFTriple());
                    }
                    else {
                        if (te.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None) {
                            result.AddTriple(te.ToRDFTriple());
                        }
                    }
                }

                //Export semantic inferences related both to ontology model and data
                else {
                    result.AddTriple(te.ToRDFTriple());
                }

            }
            return result;
        }
        #endregion

        #endregion

    }

}