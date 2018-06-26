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
        public RDFOntologyAnnotations Annotations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology with the given name
        /// </summary>
        public RDFOntology(RDFResource ontologyName) {
            if (ontologyName        != null) {
                this.Value           = ontologyName;
                this.PatternMemberID = ontologyName.PatternMemberID;
                this.Model           = new RDFOntologyModel();
                this.Data            = new RDFOntologyData();
                this.Annotations     = new RDFOntologyAnnotations();
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntology because given \"ontologyName\" parameter is null.");
            }
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given standard annotation to the ontology resource
        /// </summary>
        public RDFOntology AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation standardAnnotation,
                                                 RDFOntologyResource annotationValue) {
            if (annotationValue != null) {
                switch (standardAnnotation) {

                    //owl:versionInfo accepts a literal as range
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo:
                        if (annotationValue.IsLiteral()) {
                            this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                            RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:versionInfo value '{0}' because it is not an ontology literal", annotationValue));
                        }
                        break;

                    //owl:versionIRI accepts a non-literal as range (in literature it must be an ontology)
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI:
                        if (!annotationValue.IsLiteral()) {
                             this.Annotations.VersionIRI.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:versionIRI value '{0}' because it is an ontology literal", annotationValue));
                        }
                        break;

                    //rdfs:comment accepts a literal as range
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment:
                        if (annotationValue.IsLiteral()) {
                            this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                            RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with rdfs:comment value '{0}' because it is not an ontology literal", annotationValue));
                        }
                        break;

                    //rdfs:label accepts a literal as range
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label:
                        if (annotationValue.IsLiteral()) {
                            this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                            RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with rdfs:label value '{0}' because it is not an ontology literal", annotationValue));
                        }
                        break;

                    //rdfs:seeAlso accepts everything as range
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso:
                        this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty(), annotationValue));
                        break;

                    //rdfs:isDefinedBy accepts everything as range
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy:
                        this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty(), annotationValue));
                        break;

                    //owl:priorVersion accepts a non-literal as range (in literature it must be an ontology)
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion:
                        if (!annotationValue.IsLiteral()) {
                             this.Annotations.PriorVersion.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:priorVersion value '{0}' because it is an ontology literal", annotationValue));
                        }
                        break;

                    //owl:imports accepts a non-literal as range (in literature it must be an ontology)
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports:
                        if (!annotationValue.IsLiteral()) {
                             this.Annotations.Imports.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:imports value '{0}' because it is an ontology literal", annotationValue));
                        }
                        break;

                    //owl:backwardCompatibleWith accepts a non-literal as range (in literature it must be an ontology)
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith:
                        if (!annotationValue.IsLiteral()) {
                             this.Annotations.BackwardCompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:backwardCompatibleWith value '{0}' because it is an ontology literal", annotationValue));
                        }
                        break;

                    //owl:incompatibleWith accepts a non-literal as range (in literature it must be an ontology)
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith:
                        if (!annotationValue.IsLiteral()) {
                             this.Annotations.IncompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                        }
                        else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology with owl:incompatibleWith value '{0}' because it is an ontology literal", annotationValue));
                        }
                        break;

                }
            }
            return this;
        }

        /// <summary>
        /// Adds the given custom annotation to the ontology resource
        /// </summary>
        public RDFOntology AddCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                               RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty())) {
                    this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo, ontologyResource);
                }

                //owl:versionIRI
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI, ontologyResource);
                }

                //rdfs:comment
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment, ontologyResource);
                }

                //rdfs:label
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label, ontologyResource);
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy, ontologyResource);
                }

                //owl:imports
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports, ontologyResource);
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith, ontologyResource);
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith, ontologyResource);
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion, ontologyResource);
                }

                //custom annotation
                else {
                    this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(this, ontologyAnnotationProperty, ontologyResource));
                }
                
            }
            return this;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the given standard annotation from the ontology resource
        /// </summary>
        public RDFOntology RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation standardAnnotation,
                                                    RDFOntologyResource annotationValue) {
            if (annotationValue != null) {
                switch(standardAnnotation) {

                    //owl:versionInfo
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo:
                         this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:versionIRI
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI:
                         this.Annotations.VersionIRI.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:comment
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment:
                         this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:label
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label:
                         this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:seeAlso
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso:
                         this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:isDefinedBy
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy:
                         this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:priorVersion
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion:
                         this.Annotations.PriorVersion.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:imports
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports:
                         this.Annotations.Imports.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:backwardCompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith:
                         this.Annotations.BackwardCompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:incompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith:
                         this.Annotations.IncompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                }
            }
            return this;
        }

        /// <summary>
        /// Removes the given custom annotation from the ontology resource
        /// </summary>
        public RDFOntology RemoveCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty,
                                                  RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty())) {
                    this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo, ontologyResource);
                }

                //owl:versionIRI
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI, ontologyResource);
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment, ontologyResource);
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label, ontologyResource);
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy, ontologyResource);
                }

                //owl:imports
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports, ontologyResource);
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith, ontologyResource);
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith, ontologyResource);
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion, ontologyResource);
                }

                //custom annotation
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
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public void ClearInferences() {
            this.Model.ClearInferences();
            this.Data.ClearInferences();
        }
        #endregion

        #endregion

    }

}