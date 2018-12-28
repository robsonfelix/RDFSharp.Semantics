/*
   Copyright 2015-2019 Marco De Salvo

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
using RDFSharp.Model;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyTaxonomy represents an entry of a RDFOntologyTaxonomy object.
    /// </summary>
    public class RDFOntologyTaxonomyEntry : IEquatable<RDFOntologyTaxonomyEntry> {

        #region Properties
        /// <summary>
        /// Unique representation of the taxonomy entry
        /// </summary>
        public Int64 TaxonomyEntryID { get; internal set; }

        /// <summary>
        /// Ontology resource acting as subject of the taxonomy relationship
        /// </summary>
        public RDFOntologyResource TaxonomySubject { get; internal set; }

        /// <summary>
        /// Ontology resource acting as predicate of the taxonomy relationship
        /// </summary>
        public RDFOntologyResource TaxonomyPredicate { get; internal set; }

        /// <summary>
        /// Ontology resource acting as object of the taxonomy relationship
        /// </summary>
        public RDFOntologyResource TaxonomyObject { get; internal set; }

        /// <summary>
        /// Nature of the taxonomy entry as a semantic inference
        /// </summary>
        public RDFSemanticsEnums.RDFOntologyInferenceType InferenceType { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build a taxonomy entry with the given subject, predicate and object resources
        /// </summary>
        internal RDFOntologyTaxonomyEntry(RDFOntologyResource taxonomySubject,
                                          RDFOntologyResource taxonomyPredicate,
                                          RDFOntologyResource taxonomyObject) {
            if (taxonomySubject        != null) {
                if (taxonomyPredicate  != null) {
                    if (taxonomyObject != null) {
                        this.TaxonomySubject    = taxonomySubject;
                        this.TaxonomyPredicate  = taxonomyPredicate;
                        this.TaxonomyObject     = taxonomyObject;
                        this.InferenceType      = RDFSemanticsEnums.RDFOntologyInferenceType.None;
                        this.TaxonomyEntryID    = RDFModelUtilities.CreateHash(this.ToString());
                    }
                    else {
                        throw new RDFSemanticsException("Cannot create RDFOntologyTaxonomyEntry because given \"taxonomyObject\" parameter is null.");
                    }
                }
                else {
                    throw new RDFSemanticsException("Cannot create RDFOntologyTaxonomyEntry because given \"taxonomyPredicate\" parameter is null.");
                }
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntologyTaxonomyEntry because given \"taxonomySubject\" parameter is null.");
            }
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Gets the string representation of the taxonomy entry
        /// </summary>
        public override String ToString() {
            return this.TaxonomySubject + " " + this.TaxonomyPredicate + " " + this.TaxonomyObject;
        }

        /// <summary>
        /// Performs the equality comparison between two taxonomy entries
        /// </summary>
        public Boolean Equals(RDFOntologyTaxonomyEntry other) {
            return (other != null && this.TaxonomyEntryID.Equals(other.TaxonomyEntryID));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Marks this taxonomy entry as a semantic inference, depending on the given parameter
        /// </summary>
        internal RDFOntologyTaxonomyEntry SetInference(RDFSemanticsEnums.RDFOntologyInferenceType inferenceType) {
            this.InferenceType = inferenceType;
            return this;
        }

        /// <summary>
        /// Get a triple representation of this taxonomy entry
        /// </summary>
        internal RDFTriple ToRDFTriple() {
            if (this.TaxonomyObject.IsLiteral()) {
                return new RDFTriple((RDFResource)this.TaxonomySubject.Value, (RDFResource)this.TaxonomyPredicate.Value, (RDFLiteral)this.TaxonomyObject.Value);
            }
            else {
                return new RDFTriple((RDFResource)this.TaxonomySubject.Value, (RDFResource)this.TaxonomyPredicate.Value, (RDFResource)this.TaxonomyObject.Value);
            }
        }
        #endregion

    }

}