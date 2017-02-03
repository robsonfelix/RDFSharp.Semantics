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
using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntology represents an ontology definition.
    /// </summary>
    public class RDFOntology: RDFOntologyResource {

        #region Properties
        /// <summary>
        /// Model (T-BOX) of the ontology
        /// </summary>
        public RDFOntologyModel Model { get; internal set; }

        /// <summary>
        /// Data (A-BOX) of the ontology
        /// </summary>
        public RDFOntologyData Data { get; internal set; }

        /// <summary>
        /// Annotations describing the ontology
        /// </summary>
        public RDFOntologyAnnotationsMetadata Annotations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an ontology with the given name.
        /// </summary>
        public RDFOntology(RDFResource ontologyName): this(ontologyName, false) {
            this.Model = this.Model.UnionWith(RDFBASEOntology.Instance.Model);
            this.Data  = this.Data.UnionWith(RDFBASEOntology.Instance.Data);
        }

        /// <summary>
        /// Default-ctor to build an empty reference ontology with the given name
        /// </summary>
        internal RDFOntology(RDFResource ontologyName, Boolean isReferenceOntology) {
            if (ontologyName        != null) {
                this.Value           = ontologyName;
                this.PatternMemberID = ontologyName.PatternMemberID;
                this.Model           = new RDFOntologyModel();
                this.Data            = new RDFOntologyData();
                this.Annotations     = new RDFOntologyAnnotationsMetadata();
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntology because given \"ontologyName\" parameter is null.");
            }
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the "ontology -> owl:VersionInfo -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddVersionInfoAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:VersionIRI -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddVersionIRIAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.VersionIRI.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:comment -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddCommentAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:label -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddLabelAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:seeAlso -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddSeeAlsoAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:isDefinedBy -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddIsDefinedByAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:priorVersion -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddPriorVersionAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.PriorVersion.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:backwardCompatibleWith -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddBackwardCompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.BackwardCompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:incompatibleWith -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddIncompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.IncompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:imports -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddImportsAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.Imports.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> ontologyAnnotationProperty -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                               RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.AddVersionInfoAnnotation((RDFOntologyLiteral)ontologyResource);
                    }
                }

                //owl:versionIRI
                else if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))) {
                     if (ontologyResource.IsOntology()) {
                         this.AddVersionIRIAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddCommentAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddLabelAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.AddSeeAlsoAnnotation(ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.AddIsDefinedByAnnotation(ontologyResource);
                }

                //owl:imports
                else if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))) {
                     if (ontologyResource.IsOntology()) {
                         this.AddImportsAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddBackwardCompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddIncompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddPriorVersionAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(this, ontologyAnnotationProperty, ontologyResource));
                }
                
            }
            return this;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the "ontology -> owl:VersionInfo -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveVersionInfoAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:VersionIRI -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveVersionIRIAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.VersionIRI.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:comment -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveCommentAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:label -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveLabelAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:seeAlso -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveSeeAlsoAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:isDefinedBy -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveIsDefinedByAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:priorVersion -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemovePriorVersionAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.PriorVersion.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:backwardCompatibleWith -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveBackwardCompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.BackwardCompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:incompatibleWith -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveIncompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.IncompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:imports -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveImportsAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.Imports.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> ontologyAnnotationProperty -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty, RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.RemoveVersionInfoAnnotation((RDFOntologyLiteral)ontologyResource);
                    }
                }

                //owl:versionIRI
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveVersionIRIAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveCommentAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveLabelAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.RemoveSeeAlsoAnnotation(ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.RemoveIsDefinedByAnnotation(ontologyResource);
                }

                //owl:imports
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveImportsAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveBackwardCompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveIncompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemovePriorVersionAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //custom
                else {
                     this.Annotations.CustomAnnotations.RemoveEntry(new RDFOntologyTaxonomyEntry(this, ontologyAnnotationProperty, ontologyResource));
                }

            }
            return this;
        }
        #endregion

        #region Set
        /// <summary>
        /// Builds a new intersection ontology from this ontology and a given one
        /// </summary>
        public RDFOntology IntersectWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.ToString()));
            if (ontology     != null) {

                //Intersect the models
                result.Model  = this.Model.IntersectWith(ontology.Model);

                //Intersect the data
                result.Data   = this.Data.IntersectWith(ontology.Data);

                //Intersect the annotations            
                result.Annotations.VersionInfo            = this.Annotations.VersionInfo.IntersectWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = this.Annotations.VersionIRI.IntersectWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = this.Annotations.Comment.IntersectWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = this.Annotations.Label.IntersectWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = this.Annotations.SeeAlso.IntersectWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = this.Annotations.IsDefinedBy.IntersectWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = this.Annotations.PriorVersion.IntersectWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = this.Annotations.BackwardCompatibleWith.IntersectWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = this.Annotations.IncompatibleWith.IntersectWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = this.Annotations.Imports.IntersectWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = this.Annotations.CustomAnnotations.IntersectWith(ontology.Annotations.CustomAnnotations);

            }

            return result;
        }

        /// <summary>
        /// Builds a new union ontology from this ontology and a given one
        /// </summary>
        public RDFOntology UnionWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.ToString()));

            //Use this model
            result.Model      = result.Model.UnionWith(this.Model);

            //Use this data
            result.Data       = result.Data.UnionWith(this.Data);

            //Use this annotations
            result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(this.Annotations.VersionIRI);
            result.Annotations.Comment                = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label                  = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(this.Annotations.PriorVersion);
            result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(this.Annotations.BackwardCompatibleWith);
            result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(this.Annotations.IncompatibleWith);
            result.Annotations.Imports                = result.Annotations.Imports.UnionWith(this.Annotations.Imports);
            result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given ontology
            if (ontology     != null) {

                //Union the model
                result.Model  = result.Model.UnionWith(ontology.Model);

                //Union the data
                result.Data   = result.Data.UnionWith(ontology.Data);

                //Union the annotations
                result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = result.Annotations.Comment.UnionWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = result.Annotations.Label.UnionWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = result.Annotations.Imports.UnionWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(ontology.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new difference ontology from this ontology and a given one
        /// </summary>
        public RDFOntology DifferenceWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.ToString()));

            //Use this model
            result.Model      = result.Model.UnionWith(this.Model);

            //Use this data
            result.Data       = result.Data.UnionWith(this.Data);

            //Use this annotations
            result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(this.Annotations.VersionIRI);
            result.Annotations.Comment                = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label                  = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(this.Annotations.PriorVersion);
            result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(this.Annotations.BackwardCompatibleWith);
            result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(this.Annotations.IncompatibleWith);
            result.Annotations.Imports                = result.Annotations.Imports.UnionWith(this.Annotations.Imports);
            result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given ontology
            if (ontology     != null) {

                //Difference the model
                result.Model  = result.Model.DifferenceWith(ontology.Model);

                //Difference the data
                result.Data   = result.Data.DifferenceWith(ontology.Data);

                //Difference the annotations
                result.Annotations.VersionInfo            = result.Annotations.VersionInfo.DifferenceWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = result.Annotations.VersionIRI.DifferenceWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = result.Annotations.Comment.DifferenceWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = result.Annotations.Label.DifferenceWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = result.Annotations.SeeAlso.DifferenceWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.DifferenceWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = result.Annotations.PriorVersion.DifferenceWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.DifferenceWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.DifferenceWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = result.Annotations.Imports.DifferenceWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.DifferenceWith(ontology.Annotations.CustomAnnotations);

            }
            return result;
        }
        #endregion

        #region Convert
        /// <summary>
        /// Gets an ontology representation of the given graph.
        /// </summary>
        public static RDFOntology FromRDFGraph(RDFGraph ontGraph) {
            return RDFSemanticsUtilities.FromRDFGraph(ontGraph);
        }

        /// <summary>
        /// Gets a graph representation of this ontology, exporting inferences according to the selected behavior
        /// </summary>
        public RDFGraph ToRDFGraph(RDFSemanticsEnums.RDFOntologyInferenceExportBehavior infexpBehavior) {
            return RDFSemanticsUtilities.ToRDFGraph(this, infexpBehavior);
        }
        #endregion

        #region Validate
        /// <summary>
        /// Validate this ontology against a set of RDFS/OWL-DL rules, detecting errors and inconsistencies affecting its model and data.
        /// </summary>
        public RDFOntologyValidatorReport Validate() { 
            return (new RDFOntologyValidator()).AnalyzeOntology(this);
        }
        #endregion

        #region Reasoner
        /// <summary>
        /// Clears all the taxonomy entries marked as true semantic inferences (=RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)
        /// </summary>
        public RDFOntology ClearInferences() {
            this.Model.ClearInferences();
            this.Data.ClearInferences();

            return this;
        }
        #endregion

        #endregion

    }

    #region Metadata
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
    #endregion

    #region RDFBASEOntology
    /// <summary>
    /// RDFBASEOntology represents a partial OWL-DL ontology implementation of structural vocabularies (RDF/RDFS/OWL/XSD).
    /// This ontology is always included in every ontology, because it contains foundational taxonomies and informations.
    /// </summary>
    public static class RDFBASEOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the BASE ontology
        /// </summary>
        public static RDFOntology Instance { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the BASE ontology
        /// </summary>
        static RDFBASEOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("https://rdfsharp.codeplex.com/semantics/base#"), true);
            #endregion

            #region Classes

            //RDF+RDFS
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CONTAINER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CONTAINER_MEMBERSHIP_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.DATATYPE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.STATEMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.ALT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.BAG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.SEQ.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.LIST.ToRDFOntologyClass());

            //XSD
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass());

            //OWL
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DEPRECATED_CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.RESTRICTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DATA_RANGE.ToRDFOntologyClass());            
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.INDIVIDUAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ONTOLOGY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ANNOTATION_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DATATYPE_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DEPRECATED_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.OBJECT_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ONTOLOGY_PROPERTY.ToRDFOntologyClass());            
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.FUNCTIONAL_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.INVERSE_FUNCTIONAL_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.SYMMETRIC_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.TRANSITIVE_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.THING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.NOTHING.ToRDFOntologyClass());

            #endregion

            #region Properties

            //RDF+RDFS
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.FIRST.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.REST.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.LI.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.SUBJECT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.PREDICATE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.OBJECT.ToRDFOntologyObjectProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.VALUE.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.DOMAIN.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.RANGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.MEMBER.ToRDFOntologyProperty()); //plain property

            //OWL
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INVERSE_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ON_PROPERTY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ONE_OF.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.UNION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.COMPLEMENT_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ALL_VALUES_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.SOME_VALUES_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.HAS_VALUE.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.SAME_AS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.DIFFERENT_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.MIN_CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.MAX_CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty());

            #endregion

            #region Facts

            //OWL
            Instance.Data.AddFact(RDFVocabulary.RDF.NIL.ToRDFOntologyFact());

            #endregion

            #endregion

            #region Taxonomies

            //SubClassOf
            var subClassOf = RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty();
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass(),          subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.STRING.ToRDFOntologyClass(),               subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass(),        subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass(),           subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass(),                subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass(),               subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass(),                subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass(),             subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass(),             subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass(),             subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TIME.ToRDFOntologyClass(),                 subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATE.ToRDFOntologyClass(),                 subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass(),         subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass(),               subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass(),          subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass(),                subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass(),    subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass(),                subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(),             subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(),                 subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(),               subClassOf, RDFVocabulary.XSD.NAME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass(),              subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LONG.ToRDFOntologyClass(),                 subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(),     subClassOf, RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(),                  subClassOf, RDFVocabulary.XSD.LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(),                subClassOf, RDFVocabulary.XSD.INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(),                 subClassOf, RDFVocabulary.XSD.SHORT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(),     subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(),        subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(),         subClassOf, RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(),       subClassOf, RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(),        subClassOf, RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass()));

            #endregion

        }
        #endregion

    }
    #endregion

}