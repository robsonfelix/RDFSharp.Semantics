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
    /// RDFOntologyReasonerExtensions contains utility methods for miscellaneous reasoning tasks
    /// </summary>
    public static class RDFOntologyReasonerExtensions {

        #region GetInferences
        /// <summary>
        /// Gets an ontology made by semantic inferences found in the given one
        /// </summary>
        public static RDFOntology GetInferences(this RDFOntology ontology) {
            var result       = new RDFOntology((RDFResource)ontology.Value);
            if (ontology    != null) {
                result.Model = ontology.Model.GetInferences();
                result.Data  = ontology.Data.GetInferences();
            }
            return result;
        }

        /// <summary>
        /// Gets an ontology model made by semantic inferences found in the given one
        /// </summary>
        public static RDFOntologyModel GetInferences(this RDFOntologyModel ontologyModel) {
            var result               = new RDFOntologyModel();
            if (ontologyModel       != null) {
                result.ClassModel    = ontologyModel.ClassModel.GetInferences();
                result.PropertyModel = ontologyModel.PropertyModel.GetInferences();
            }
            return result;
        }

        /// <summary>
        /// Gets an ontology class model made by semantic inferences found in the given one
        /// </summary>
        public static RDFOntologyClassModel GetInferences(this RDFOntologyClassModel ontologyClassModel) {
            var result              = new RDFOntologyClassModel();
            if (ontologyClassModel != null) {

                //SubClassOf
                foreach (var entry in ontologyClassModel.Relations.SubClassOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

                //EquivalentClass
                foreach (var entry in ontologyClassModel.Relations.EquivalentClass.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

                //DisjointWith
                foreach (var entry in ontologyClassModel.Relations.DisjointWith.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

                //UnionOf
                foreach (var entry in ontologyClassModel.Relations.UnionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

                //IntersectionOf
                foreach (var entry in ontologyClassModel.Relations.IntersectionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

                //OneOf
                foreach (var entry in ontologyClassModel.Relations.OneOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubClassOf.AddEntry(entry);

            }
            return result;
        }

        /// <summary>
        /// Gets an ontology property model made by semantic inferences found in the given one
        /// </summary>
        public static RDFOntologyPropertyModel GetInferences(this RDFOntologyPropertyModel ontologyPropertyModel) {
            var result                 = new RDFOntologyPropertyModel();
            if (ontologyPropertyModel != null) {

                //SubPropertyOf
                foreach (var entry in ontologyPropertyModel.Relations.SubPropertyOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SubPropertyOf.AddEntry(entry);

                //EquivalentProperty
                foreach (var entry in ontologyPropertyModel.Relations.EquivalentProperty.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.EquivalentProperty.AddEntry(entry);

                //InverseOf
                foreach (var entry in ontologyPropertyModel.Relations.InverseOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.InverseOf.AddEntry(entry);

            }
            return result;
        }

        /// <summary>
        /// Gets an ontology data made by semantic inferences found in the given one
        /// </summary>
        public static RDFOntologyData GetInferences(this RDFOntologyData ontologyData) {
            var result              = new RDFOntologyData();
            if (ontologyData       != null) {

                //ClassType
                foreach (var entry in ontologyData.Relations.ClassType.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.ClassType.AddEntry(entry);

                //SameAs
                foreach (var entry in ontologyData.Relations.SameAs.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.SameAs.AddEntry(entry);

                //DifferentFrom
                foreach (var entry in ontologyData.Relations.DifferentFrom.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.DifferentFrom.AddEntry(entry);

                //Assertions
                foreach (var entry in ontologyData.Relations.Assertions.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.API || tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner))
                    result.Relations.Assertions.AddEntry(entry);

            }
            return result;
        }
        #endregion

        #region ClearInferences
        /// <summary>
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public static void ClearInferences(this RDFOntology ontology) {
            if (ontology != null) {
                ontology.Model.ClearInferences();
                ontology.Data.ClearInferences();
            }           
        }

        /// <summary>
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public static void ClearInferences(this RDFOntologyModel ontologyModel) {
            if (ontologyModel != null) {
                ontologyModel.ClassModel.ClearInferences();
                ontologyModel.PropertyModel.ClearInferences();
            }           
        }

        /// <summary>
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public static void ClearInferences(this RDFOntologyClassModel ontologyClassModel) {
            if (ontologyClassModel != null) {
                var cacheRemove     = new Dictionary<Int64, Object>();

                //SubClassOf
                foreach (var t     in ontologyClassModel.Relations.SubClassOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.SubClassOf.Entries.Remove(c); }
                cacheRemove.Clear();

                //EquivalentClass
                foreach (var t     in ontologyClassModel.Relations.EquivalentClass.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.EquivalentClass.Entries.Remove(c); }
                cacheRemove.Clear();

                //DisjointWith
                foreach (var t     in ontologyClassModel.Relations.DisjointWith.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.DisjointWith.Entries.Remove(c); }
                cacheRemove.Clear();

                //UnionOf
                foreach (var t     in ontologyClassModel.Relations.UnionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.UnionOf.Entries.Remove(c); }
                cacheRemove.Clear();

                //IntersectionOf
                foreach (var t     in ontologyClassModel.Relations.IntersectionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.IntersectionOf.Entries.Remove(c); }
                cacheRemove.Clear();

                //OneOf
                foreach (var t     in ontologyClassModel.Relations.OneOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c     in cacheRemove.Keys) { ontologyClassModel.Relations.OneOf.Entries.Remove(c); }
                cacheRemove.Clear();
            }
        }

        /// <summary>
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public static void ClearInferences(this RDFOntologyPropertyModel ontologyPropertyModel) {
            if (ontologyPropertyModel != null) {
                var cacheRemove        = new Dictionary<Int64, Object>();

                //SubPropertyOf
                foreach (var t        in ontologyPropertyModel.Relations.SubPropertyOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c        in cacheRemove.Keys) { ontologyPropertyModel.Relations.SubPropertyOf.Entries.Remove(c); }
                cacheRemove.Clear();

                //EquivalentProperty
                foreach (var t        in ontologyPropertyModel.Relations.EquivalentProperty.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c        in cacheRemove.Keys) { ontologyPropertyModel.Relations.EquivalentProperty.Entries.Remove(c); }
                cacheRemove.Clear();

                //InverseOf
                foreach (var t        in ontologyPropertyModel.Relations.InverseOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c        in cacheRemove.Keys) { ontologyPropertyModel.Relations.InverseOf.Entries.Remove(c); }
                cacheRemove.Clear();
            }
        }

        /// <summary>
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public static void ClearInferences(this RDFOntologyData ontologyData) {
            if (ontologyData   != null) {
                var cacheRemove = new Dictionary<Int64, Object>();

                //ClassType
                foreach (var t in ontologyData.Relations.ClassType.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c in cacheRemove.Keys) { ontologyData.Relations.ClassType.Entries.Remove(c); }
                cacheRemove.Clear();

                //SameAs
                foreach (var t in ontologyData.Relations.SameAs.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c in cacheRemove.Keys) { ontologyData.Relations.SameAs.Entries.Remove(c); }
                cacheRemove.Clear();

                //DifferentFrom
                foreach (var t in ontologyData.Relations.DifferentFrom.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c in cacheRemove.Keys) { ontologyData.Relations.DifferentFrom.Entries.Remove(c); }
                cacheRemove.Clear();

                //Assertions
                foreach (var t in ontologyData.Relations.Assertions.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                    cacheRemove.Add(t.TaxonomyEntryID, null);
                }
                foreach (var c in cacheRemove.Keys) { ontologyData.Relations.Assertions.Entries.Remove(c); }
                cacheRemove.Clear();
            }
        }
        #endregion

    }

}