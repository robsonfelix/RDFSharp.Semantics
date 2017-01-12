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

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyClassModelRelations represents a collector for relations specifically describing ontology classes.
    /// </summary>
    public class RDFOntologyClassModelRelations: RDFOntologyCommonRelations {

        #region Properties
        /// <summary>
        /// "rdfs:subClassOf" relations
        /// </summary>
        public RDFOntologyTaxonomy SubClassOf { get; internal set; }

        /// <summary>
        /// "owl:equivalentClass" relations
        /// </summary>
        public RDFOntologyTaxonomy EquivalentClass { get; internal set; }

        /// <summary>
        /// "owl:disjointWith" relations
        /// </summary>
        public RDFOntologyTaxonomy DisjointWith { get; internal set; }

        /// <summary>
        /// "owl:oneOf" relations
        /// </summary>
        public RDFOntologyTaxonomy OneOf { get; internal set; }

        /// <summary>
        /// "owl:intersectionOf" relations
        /// </summary>
        public RDFOntologyTaxonomy IntersectionOf { get; internal set; }

        /// <summary>
        /// "owl:unionOf" relations
        /// </summary>
        public RDFOntologyTaxonomy UnionOf { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology class model relations structure
        /// </summary>
        internal RDFOntologyClassModelRelations() {
            this.SubClassOf      = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.EquivalentClass = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.DisjointWith    = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.OneOf           = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.IntersectionOf  = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.UnionOf         = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.CustomRelations = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
        }
        #endregion

    }

    /// <summary>
    /// RDFOntologyPropertyModelRelations represents a collector for relations specifically describing ontology properties.
    /// </summary>
    public class RDFOntologyPropertyModelRelations: RDFOntologyCommonRelations {

        #region Properties
        /// <summary>
        /// "rdfs:subPropertyOf" relations
        /// </summary>
        public RDFOntologyTaxonomy SubPropertyOf { get; internal set; }

        /// <summary>
        /// "owl:equivalentProperty" relations
        /// </summary>
        public RDFOntologyTaxonomy EquivalentProperty { get; internal set; }

        /// <summary>
        /// "owl:inverseOf" relations
        /// </summary>
        public RDFOntologyTaxonomy InverseOf { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology property model relations structure
        /// </summary>
        internal RDFOntologyPropertyModelRelations() {
            this.SubPropertyOf      = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.EquivalentProperty = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.InverseOf          = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.CustomRelations    = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
        }
        #endregion

    }

    /// <summary>
    /// RDFOntologyDataRelations represents a collector for relations specifically describing ontology facts.
    /// </summary>
    public class RDFOntologyDataRelations: RDFOntologyCommonRelations {

        #region Properties
        /// <summary>
        /// "rdf:type" relations
        /// </summary>
        public RDFOntologyTaxonomy ClassType { get; internal set; }

        /// <summary>
        /// "owl:sameAs" relations
        /// </summary>
        public RDFOntologyTaxonomy SameAs { get; internal set; }

        /// <summary>
        /// "owl:differentFrom" relations
        /// </summary>
        public RDFOntologyTaxonomy DifferentFrom { get; internal set; }

        /// <summary>
        /// "ontology property -> ontology resource" custom relations
        /// </summary>
        public RDFOntologyTaxonomy Assertions { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology data relations structure
        /// </summary>
        internal RDFOntologyDataRelations() {
            this.ClassType       = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.SameAs          = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.DifferentFrom   = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.Assertions      = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.CustomRelations = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
        }
        #endregion

    }

}