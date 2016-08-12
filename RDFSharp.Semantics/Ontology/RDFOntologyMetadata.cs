/*
   Copyright 2012-2016 Marco De Salvo

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

namespace RDFSharp.Semantics 
{

    /// <summary>
    /// RDFOntologyAnnotationsMetadata represents a collector for annotations describing ontology resources.
    /// </summary>
    public class RDFOntologyAnnotationsMetadata {

        #region Properties
        /// <summary>
        /// "owl:versionInfo" annotations
        /// </summary>
        public RDFOntologyTaxonomy VersionInfo { get; internal set; }

        /// <summary>
        /// "owl:versionIRI" annotations
        /// </summary>
        public RDFOntologyTaxonomy VersionIRI { get; internal set; }

        /// <summary>
        /// "vs:term_status" annotations
        /// </summary>
        public RDFOntologyTaxonomy TermStatus { get; internal set; }

        /// <summary>
        /// "rdfs:comment" annotations
        /// </summary>
        public RDFOntologyTaxonomy Comment { get; internal set; }

        /// <summary>
        /// "rdfs:label" annotations
        /// </summary>
        public RDFOntologyTaxonomy Label { get; internal set; }

        /// <summary>
        /// "rdfs:seeAlso" annotations
        /// </summary>
        public RDFOntologyTaxonomy SeeAlso { get; internal set; }

        /// <summary>
        /// "rdfs:isDefinedBy" annotations
        /// </summary>
        public RDFOntologyTaxonomy IsDefinedBy { get; internal set; }

        /// <summary>
        /// "owl:priorVersion" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy PriorVersion { get; internal set; }

        /// <summary>
        /// "owl:BackwardCompatibleWith" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy BackwardCompatibleWith { get; internal set; }

        /// <summary>
        /// "owl:IncompatibleWith" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy IncompatibleWith { get; internal set; }

        /// <summary>
        /// "owl:imports" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy Imports { get; internal set; }

        /// <summary>
        /// Custom-property annotations
        /// </summary>
        public RDFOntologyTaxonomy CustomAnnotations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology annotations metadata
        /// </summary>
        internal RDFOntologyAnnotationsMetadata() {
            this.VersionInfo            = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.VersionIRI             = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.TermStatus             = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.Comment                = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.Label                  = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.SeeAlso                = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.IsDefinedBy            = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.PriorVersion           = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.BackwardCompatibleWith = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.IncompatibleWith       = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.Imports                = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
            this.CustomAnnotations      = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
        }
        #endregion

    }

    /// <summary>
    /// RDFOntologyMetadata represents a collector for relations describing ontologies.
    /// </summary>
    public class RDFOntologyMetadata {

        #region Properties
        /// <summary>
        /// "Custom" relations (non-structural taxonomies)
        /// </summary>
        public RDFOntologyTaxonomy CustomRelations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology metadata
        /// </summary>
        internal RDFOntologyMetadata() {
            this.CustomRelations = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
        }
        #endregion

    }

    /// <summary>
    /// RDFOntologyClassModelMetadata represents a collector for relations describing ontology classes.
    /// </summary>
    public class RDFOntologyClassModelMetadata {

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
        /// "owl:oneOf" relations (specific for enumerate and datarange classes)
        /// </summary>
        public RDFOntologyTaxonomy OneOf { get; internal set; }

        /// <summary>
        /// "owl:intersectionOf" relations (specific for intersection classes)
        /// </summary>
        public RDFOntologyTaxonomy IntersectionOf { get; internal set; }

        /// <summary>
        /// "owl:unionOf" relations (specific for union classes)
        /// </summary>
        public RDFOntologyTaxonomy UnionOf { get; internal set; }

        /// <summary>
        /// "Custom" relations (non-structural taxonomies)
        /// </summary>
        public RDFOntologyTaxonomy CustomRelations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology class model metadata
        /// </summary>
        internal RDFOntologyClassModelMetadata() {
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
    /// RDFOntologyPropertyModelMetadata represents a collector for relations describing ontology properties.
    /// </summary>
    public class RDFOntologyPropertyModelMetadata {

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

        /// <summary>
        /// "Custom" relations (non-structural taxonomies)
        /// </summary>
        public RDFOntologyTaxonomy CustomRelations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology property model metadata
        /// </summary>
        internal RDFOntologyPropertyModelMetadata() {
            this.SubPropertyOf      = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.EquivalentProperty = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.InverseOf          = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
            this.CustomRelations    = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Model);
        }
        #endregion

    }

    /// <summary>
    /// RDFOntologyDataMetadata represents a collector for relations connecting describing ontology facts.
    /// </summary>
    public class RDFOntologyDataMetadata {

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
        /// Default-ctor to build an empty ontology data metadata
        /// </summary>
        internal RDFOntologyDataMetadata() {
            this.ClassType     = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.SameAs        = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.DifferentFrom = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            this.Assertions    = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
        }
        #endregion

    }

}