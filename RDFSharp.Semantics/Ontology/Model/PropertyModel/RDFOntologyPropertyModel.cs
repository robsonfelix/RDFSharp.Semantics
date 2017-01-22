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
using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyPropertyModel represents the property-oriented model component (T-BOX) of an ontology.
    /// </summary>
    public class RDFOntologyPropertyModel: IEnumerable<RDFOntologyProperty> {

        #region Properties
        /// <summary>
        /// Count of the properties composing the property model
        /// </summary>
        public Int64 PropertiesCount {
            get { return this.Properties.Count; }
        }

        /// <summary>
        /// Count of the annotation properties composing the property model
        /// </summary>
        public Int64 AnnotationPropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsAnnotationProperty()); }
        }

        /// <summary>
        /// Count of the datatype properties composing the property model
        /// </summary>
        public Int64 DatatypePropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsDatatypeProperty()); }
        }

        /// <summary>
        /// Count of the object properties composing the property model
        /// </summary>
        public Int64 ObjectPropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsObjectProperty()); }
        }

        /// <summary>
        /// Count of the functional properties composing the property model
        /// </summary>
        public Int64 FunctionalPropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsFunctionalProperty()); }
        }

        /// <summary>
        /// Count of the symmetric properties composing the property model
        /// </summary>
        public Int64 SymmetricPropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsSymmetricProperty()); }
        }

        /// <summary>
        /// Count of the transitive properties composing the property model
        /// </summary>
        public Int64 TransitivePropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsTransitiveProperty()); }
        }

        /// <summary>
        /// Count of the inverse functional properties composing the property model
        /// </summary>
        public Int64 InverseFunctionalPropertiesCount {
            get { return this.Properties.Count(p => p.Value.IsInverseFunctionalProperty()); }
        }

        /// <summary>
        /// Gets the enumerator on the property model's properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyProperty> PropertiesEnumerator {
            get { return this.Properties.Values.GetEnumerator(); }
        }

        /// <summary>
        /// Gets the enumerator on the property model's annotation properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyAnnotationProperty> AnnotationPropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsAnnotationProperty())
                                             .OfType<RDFOntologyAnnotationProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's datatype properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyDatatypeProperty> DatatypePropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsDatatypeProperty())
                                             .OfType<RDFOntologyDatatypeProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's object properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyObjectProperty> ObjectPropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsObjectProperty())
                                             .OfType<RDFOntologyObjectProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's functional properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyProperty> FunctionalPropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsFunctionalProperty())
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's symmetric properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyObjectProperty> SymmetricPropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsSymmetricProperty())
                                             .OfType<RDFOntologyObjectProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's transitive properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyObjectProperty> TransitivePropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsTransitiveProperty())
                                             .OfType<RDFOntologyObjectProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the property model's inverse functional properties for iteration
        /// </summary>
        public IEnumerator<RDFOntologyObjectProperty> InverseFunctionalPropertiesEnumerator {
            get {
                return this.Properties.Values.Where(p => p.IsInverseFunctionalProperty())
                                             .OfType<RDFOntologyObjectProperty>()
                                             .GetEnumerator();
            }
        }

        /// <summary>
        /// Annotations describing properties of the ontology property model
        /// </summary>
        public RDFOntologyAnnotationsMetadata Annotations { get; internal set; }

        /// <summary>
        /// Relations describing properties of the ontology property model
        /// </summary>
        public RDFOntologyPropertyModelMetadata Relations { get; internal set; }

        /// <summary>
        /// Dictionary of properties composing the property model
        /// </summary>
        internal Dictionary<Int64, RDFOntologyProperty> Properties { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty property model
        /// </summary>
        public RDFOntologyPropertyModel() {
            this.Properties  = new Dictionary<Int64, RDFOntologyProperty>();
            this.Annotations = new RDFOntologyAnnotationsMetadata();
            this.Relations   = new RDFOntologyPropertyModelMetadata();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the property model's properties
        /// </summary>
        IEnumerator<RDFOntologyProperty> IEnumerable<RDFOntologyProperty>.GetEnumerator() {
            return this.Properties.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the property model's properties
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.Properties.Values.GetEnumerator();
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given property to the ontology property model
        /// </summary>
        public RDFOntologyPropertyModel AddProperty(RDFOntologyProperty ontologyProperty) {
            if (ontologyProperty != null) {
                if (!this.Properties.ContainsKey(ontologyProperty.PatternMemberID)) {
                     this.Properties.Add(ontologyProperty.PatternMemberID, ontologyProperty);
                }
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> owl:VersionInfo -> ontologyLiteral" annotation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddVersionInfoAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                 RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> rdfs:comment -> ontologyLiteral" annotation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddCommentAnnotation(RDFOntologyProperty ontologyProperty, 
                                                             RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> rdfs:label -> ontologyLiteral" annotation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddLabelAnnotation(RDFOntologyProperty ontologyProperty, 
                                                           RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> rdfs:seeAlso -> ontologyResource" annotation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddSeeAlsoAnnotation(RDFOntologyProperty ontologyProperty, 
                                                             RDFOntologyResource ontologyResource) {
            if (ontologyProperty != null && ontologyResource != null) {
                this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> rdfs:isDefinedBy -> ontologyResource" annotation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddIsDefinedByAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                 RDFOntologyResource ontologyResource) {
            if (ontologyProperty != null && ontologyResource != null) {
                this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> ontologyAnnotationProperty -> ontologyResource" annotation to the class model 
        /// </summary>
        public RDFOntologyPropertyModel AddCustomAnnotation(RDFOntologyProperty ontologyProperty, 
                                                            RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                                            RDFOntologyResource ontologyResource) {
            if (ontologyProperty   != null && ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.AddVersionInfoAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                    }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddCommentAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddLabelAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                    this.AddSeeAlsoAnnotation(ontologyProperty, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                    this.AddIsDefinedByAnnotation(ontologyProperty, ontologyResource);
                }

                //ontology-specific
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))              ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))                  ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString())) ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))        ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {

                        //Raise warning event to inform the user: Ontology-specific annotation properties cannot be used for properties
                        RDFSemanticsEvents.RaiseSemanticsWarning("Ontology-specific annotation properties cannot be used for properties.");

                }

                //custom
                else {
                    this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, ontologyAnnotationProperty, ontologyResource));
                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "childProperty -> rdfs:subPropertyOf -> motherProperty" relation to the property model.
        /// </summary>
        public RDFOntologyPropertyModel AddSubPropertyOfRelation(RDFOntologyObjectProperty childProperty, 
                                                                 RDFOntologyObjectProperty motherProperty) {
            if (childProperty != null && motherProperty != null && !childProperty.Equals(motherProperty)) {

                //Enforce taxonomy checks before adding the subPropertyOf relation
                if (!RDFBASEOntologyReasonerHelper.IsSubPropertyOf(motherProperty,        childProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsEquivalentPropertyOf(motherProperty, childProperty, this)) {
                     this.Relations.SubPropertyOf.AddEntry(new RDFOntologyTaxonomyEntry(childProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()), motherProperty));
                }
                else {

                     //Raise warning event to inform the user: SubPropertyOf relation cannot be added to the property model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubPropertyOf relation between child property '{0}' and mother property '{1}' cannot be added to the property model because it violates the taxonomy consistency.", childProperty, motherProperty));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "childProperty -> rdfs:subPropertyOf -> motherProperty" relation to the property model.
        /// </summary>
        public RDFOntologyPropertyModel AddSubPropertyOfRelation(RDFOntologyDatatypeProperty childProperty, 
                                                                 RDFOntologyDatatypeProperty motherProperty) {
            if (childProperty != null && motherProperty != null && !childProperty.Equals(motherProperty)) {

                //Enforce taxonomy checks before adding the subPropertyOf relation
                if (!RDFBASEOntologyReasonerHelper.IsSubPropertyOf(motherProperty,        childProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsEquivalentPropertyOf(motherProperty, childProperty, this)) {
                     this.Relations.SubPropertyOf.AddEntry(new RDFOntologyTaxonomyEntry(childProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()), motherProperty));
                }
                else {

                     //Raise warning event to inform the user: SubPropertyOf relation cannot be added to the property model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubPropertyOf relation between child property '{0}' and mother property '{1}' cannot be added to the property model because it violates the taxonomy consistency.", childProperty, motherProperty));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "aProperty -> owl:equivalentProperty -> bProperty" relation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddEquivalentPropertyRelation(RDFOntologyObjectProperty aProperty, 
                                                                      RDFOntologyObjectProperty bProperty) {
            if (aProperty  != null && bProperty != null && !aProperty.Equals(bProperty)) {

                //Enforce taxonomy checks before adding the equivalentProperty relation
                if (!RDFBASEOntologyReasonerHelper.IsSubPropertyOf(aProperty,   bProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsSuperPropertyOf(aProperty, bProperty, this)) {
                     this.Relations.EquivalentProperty.AddEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), bProperty));
                     this.Relations.EquivalentProperty.AddEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), aProperty).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                }
                else {

                     //Raise warning event to inform the user: EquivalentProperty relation cannot be added to the property model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("EquivalentProperty relation between property '{0}' and property '{1}' cannot be added to the property model because it violates the taxonomy consistency.", aProperty, bProperty));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "aProperty -> owl:equivalentProperty -> bProperty" relation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddEquivalentPropertyRelation(RDFOntologyDatatypeProperty aProperty, 
                                                                      RDFOntologyDatatypeProperty bProperty) {
            if (aProperty  != null && bProperty != null && !aProperty.Equals(bProperty)) {

                //Enforce taxonomy checks before adding the equivalentProperty relation
                if (!RDFBASEOntologyReasonerHelper.IsSubPropertyOf(aProperty,   bProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsSuperPropertyOf(aProperty, bProperty, this)) {
                     this.Relations.EquivalentProperty.AddEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), bProperty));
                     this.Relations.EquivalentProperty.AddEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), aProperty).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                }
                else {

                     //Raise warning event to inform the user: EquivalentProperty relation cannot be added to the property model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("EquivalentProperty relation between property '{0}' and property '{1}' cannot be added to the property model because it violates the taxonomy consistency.", aProperty, bProperty));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "aProperty -> owl:inverseOf -> bProperty" relation to the property model 
        /// </summary>
        public RDFOntologyPropertyModel AddInverseOfRelation(RDFOntologyObjectProperty aProperty, 
                                                             RDFOntologyObjectProperty bProperty) {
            if (aProperty != null && bProperty != null && !aProperty.Equals(bProperty)) {

                //Enforce taxonomy checks before adding the inverseOf relation
                if (!RDFBASEOntologyReasonerHelper.IsSubPropertyOf(aProperty,        bProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsSuperPropertyOf(aProperty,      bProperty, this) &&
                    !RDFBASEOntologyReasonerHelper.IsEquivalentPropertyOf(aProperty, bProperty, this)) {
                     this.Relations.InverseOf.AddEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()), bProperty));
                     this.Relations.InverseOf.AddEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()), aProperty).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                }
                else {

                    //Raise warning event to inform the user: InverseOf relation cannot be added to the property model because it violates the taxonomy consistency
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("InverseOf relation between property '{0}' and property '{1}' cannot be added to the property model because it violates the taxonomy consistency.", aProperty, bProperty));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyProperty -> predicateProperty -> ontologyResource" relation to the property model
        /// If the predicateProperty is an annotation property, it redirects to the "AddCustomAnnotation" method
        /// </summary>
        public RDFOntologyPropertyModel AddCustomRelation(RDFOntologyProperty ontologyProperty,
                                                          RDFOntologyProperty predicateProperty,
                                                          RDFOntologyResource ontologyResource) {
            if(ontologyProperty != null && predicateProperty != null && ontologyResource != null) {

                //Custom annotations
                if (predicateProperty.IsAnnotationProperty()) {
                    return this.AddCustomAnnotation(ontologyProperty, (RDFOntologyAnnotationProperty)predicateProperty, ontologyResource);
                }

                //rdfs:subPropertyOf
                if (predicateProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()))) {
                    if (ontologyProperty.IsObjectProperty()       && ontologyResource.IsObjectProperty()) {
                        this.AddSubPropertyOfRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                    }
                    else if(ontologyProperty.IsDatatypeProperty() && ontologyResource.IsDatatypeProperty()) {
                        this.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)ontologyProperty, (RDFOntologyDatatypeProperty)ontologyResource);
                    }
                }

                //owl:equivalentProperty
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()))) {
                    if(ontologyProperty.IsObjectProperty()        && ontologyResource.IsObjectProperty()) {
                        this.AddEquivalentPropertyRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                    }
                    else if(ontologyProperty.IsDatatypeProperty() && ontologyResource.IsDatatypeProperty()) {
                        this.AddEquivalentPropertyRelation((RDFOntologyDatatypeProperty)ontologyProperty, (RDFOntologyDatatypeProperty)ontologyResource);
                    }
                }

                //owl:inverseOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()))) {
                     if(ontologyProperty.IsObjectProperty() && ontologyResource.IsObjectProperty()) {
                        this.AddInverseOfRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Relations.CustomRelations.AddEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, predicateProperty, ontologyResource));
                }

            }
            return this;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the given property from the ontology property model
        /// </summary>
        public RDFOntologyPropertyModel RemoveProperty(RDFOntologyProperty ontologyProperty) {
            if (ontologyProperty != null) {
                if (this.Properties.ContainsKey(ontologyProperty.PatternMemberID)) {
                    this.Properties.Remove(ontologyProperty.PatternMemberID);
                }
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> owl:VersionInfo -> ontologyLiteral" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveVersionInfoAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                    RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> rdfs:comment -> ontologyLiteral" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveCommentAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> rdfs:label -> ontologyLiteral" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveLabelAnnotation(RDFOntologyProperty ontologyProperty, 
                                                              RDFOntologyLiteral ontologyLiteral) {
            if (ontologyProperty != null && ontologyLiteral != null) {
                this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> rdfs:seeAlso -> ontologyResource" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveSeeAlsoAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                RDFOntologyResource ontologyResource) {
            if (ontologyProperty != null && ontologyResource != null) {
                this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> rdfs:isDefinedBy -> ontologyResource" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveIsDefinedByAnnotation(RDFOntologyProperty ontologyProperty, 
                                                                    RDFOntologyResource ontologyResource) {
            if (ontologyProperty != null && ontologyResource != null) {
                this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> ontologyAnnotationProperty -> ontologyResource" annotation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveCustomAnnotation(RDFOntologyProperty ontologyProperty, 
                                                               RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                                               RDFOntologyResource ontologyResource) {
            if (ontologyProperty != null && ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.RemoveVersionInfoAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                    }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveCommentAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveLabelAnnotation(ontologyProperty, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.RemoveSeeAlsoAnnotation(ontologyProperty, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.RemoveIsDefinedByAnnotation(ontologyProperty, ontologyResource);
                }

                //custom
                else {
                     this.Annotations.CustomAnnotations.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, ontologyAnnotationProperty, ontologyResource));
                }

            }
            return this;
        }

        /// <summary>
        /// Removes the "childProperty -> rdfs:subPropertyOf -> motherProperty" relation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveSubPropertyOfRelation(RDFOntologyObjectProperty childProperty, 
                                                                    RDFOntologyObjectProperty motherProperty) {
            if (childProperty != null && motherProperty != null) {
                this.Relations.SubPropertyOf.RemoveEntry(new RDFOntologyTaxonomyEntry(childProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()), motherProperty));
            }
            return this;
        }

        /// <summary>
        /// Removes the "childProperty -> rdfs:subPropertyOf -> motherProperty" relation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveSubPropertyOfRelation(RDFOntologyDatatypeProperty childProperty, 
                                                                    RDFOntologyDatatypeProperty motherProperty) {
            if (childProperty != null && motherProperty != null) {
                this.Relations.SubPropertyOf.RemoveEntry(new RDFOntologyTaxonomyEntry(childProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()), motherProperty));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aProperty -> owl:equivalentProperty -> bProperty" relation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveEquivalentPropertyRelation(RDFOntologyObjectProperty aProperty, 
                                                                         RDFOntologyObjectProperty bProperty) {
            if (aProperty != null && bProperty != null) {
                this.Relations.EquivalentProperty.RemoveEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), bProperty));
                this.Relations.EquivalentProperty.RemoveEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), aProperty));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aProperty -> owl:equivalentProperty -> bProperty" relation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveEquivalentPropertyRelation(RDFOntologyDatatypeProperty aProperty, 
                                                                         RDFOntologyDatatypeProperty bProperty) {
            if (aProperty != null && bProperty != null) {
                this.Relations.EquivalentProperty.RemoveEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), bProperty));
                this.Relations.EquivalentProperty.RemoveEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()), aProperty));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aProperty -> owl:inverseOf -> bProperty" relation from the property model 
        /// </summary>
        public RDFOntologyPropertyModel RemoveInverseOfRelation(RDFOntologyObjectProperty aProperty, 
                                                                RDFOntologyObjectProperty bProperty) {
            if (aProperty != null && bProperty != null) {
                this.Relations.InverseOf.RemoveEntry(new RDFOntologyTaxonomyEntry(aProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()), bProperty));
                this.Relations.InverseOf.RemoveEntry(new RDFOntologyTaxonomyEntry(bProperty, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()), aProperty));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyProperty -> predicateProperty -> ontologyResource" relation from the property model
        /// If the predicateProperty is an annotation property, it redirects to the "RemoveCustomAnnotation" method
        /// </summary>
        public RDFOntologyPropertyModel RemoveCustomRelation(RDFOntologyProperty ontologyProperty,
                                                             RDFOntologyProperty predicateProperty,
                                                             RDFOntologyResource ontologyResource) {
            if(ontologyProperty != null && predicateProperty != null && ontologyResource != null) {

                //Custom annotations
                if (predicateProperty.IsAnnotationProperty()) {
                    return this.RemoveCustomAnnotation(ontologyProperty, (RDFOntologyAnnotationProperty)predicateProperty, ontologyResource);
                }

                //rdfs:subPropertyOf
                if (predicateProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToString()))) {
                    if (ontologyProperty.IsObjectProperty() && ontologyResource.IsObjectProperty()) {
                        this.RemoveSubPropertyOfRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                    }
                    else if(ontologyProperty.IsDatatypeProperty() && ontologyResource.IsDatatypeProperty()) {
                        this.RemoveSubPropertyOfRelation((RDFOntologyDatatypeProperty)ontologyProperty, (RDFOntologyDatatypeProperty)ontologyResource);
                    }
                }

                //owl:equivalentProperty
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToString()))) {
                     if(ontologyProperty.IsObjectProperty() && ontologyResource.IsObjectProperty()) {
                        this.RemoveEquivalentPropertyRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                     }
                     else if(ontologyProperty.IsDatatypeProperty() && ontologyResource.IsDatatypeProperty()) {
                        this.RemoveEquivalentPropertyRelation((RDFOntologyDatatypeProperty)ontologyProperty, (RDFOntologyDatatypeProperty)ontologyResource);
                     }
                }

                //owl:inverseOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INVERSE_OF.ToString()))) {
                     if(ontologyProperty.IsObjectProperty() && ontologyResource.IsObjectProperty()) {
                        this.RemoveInverseOfRelation((RDFOntologyObjectProperty)ontologyProperty, (RDFOntologyObjectProperty)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Relations.CustomRelations.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyProperty, predicateProperty, ontologyResource));
                }

            }
            return this;
        }
        #endregion

        #region Select
        /// <summary>
        /// Selects the ontology property represented by the given string from the ontology property model
        /// </summary>
        public RDFOntologyProperty SelectProperty(String ontProperty) {
            if (ontProperty       != null) {
                Int64 propertyID   = RDFModelUtilities.CreateHash(ontProperty);
                if (this.Properties.ContainsKey(propertyID)) {
                    return this.Properties[propertyID];
                }
            }
            return null;
        }
        #endregion

        #region Set
        /// <summary>
        /// Builds a new intersection property model from this property model and a given one
        /// </summary>
        public RDFOntologyPropertyModel IntersectWith(RDFOntologyPropertyModel propertyModel) {
            var result          = new RDFOntologyPropertyModel();
            if (propertyModel  != null) {

                //Add intersection properties
                foreach (var p in this) {
                    if  (propertyModel.Properties.ContainsKey(p.PatternMemberID)) {
                         result.AddProperty(p);
                    }
                }

                //Add intersection relations
                result.Relations.SubPropertyOf       = this.Relations.SubPropertyOf.IntersectWith(propertyModel.Relations.SubPropertyOf);
                result.Relations.EquivalentProperty  = this.Relations.EquivalentProperty.IntersectWith(propertyModel.Relations.EquivalentProperty);
                result.Relations.InverseOf           = this.Relations.InverseOf.IntersectWith(propertyModel.Relations.InverseOf);
                result.Relations.CustomRelations     = this.Relations.CustomRelations.IntersectWith(propertyModel.Relations.CustomRelations);

                //Add intersection annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.IntersectWith(propertyModel.Annotations.VersionInfo);
                result.Annotations.Comment           = this.Annotations.Comment.IntersectWith(propertyModel.Annotations.Comment);
                result.Annotations.Label             = this.Annotations.Label.IntersectWith(propertyModel.Annotations.Label);
                result.Annotations.SeeAlso           = this.Annotations.SeeAlso.IntersectWith(propertyModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = this.Annotations.IsDefinedBy.IntersectWith(propertyModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = this.Annotations.CustomAnnotations.IntersectWith(propertyModel.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new union property model from this property model and a given one
        /// </summary>
        public RDFOntologyPropertyModel UnionWith(RDFOntologyPropertyModel propertyModel) {
            var result   = new RDFOntologyPropertyModel();

            //Add properties from this property model
            foreach (var p in this) {
                result.AddProperty(p);
            }

            //Add relations from this property model
            result.Relations.SubPropertyOf       = result.Relations.SubPropertyOf.UnionWith(this.Relations.SubPropertyOf);
            result.Relations.EquivalentProperty  = result.Relations.EquivalentProperty.UnionWith(this.Relations.EquivalentProperty);
            result.Relations.InverseOf           = result.Relations.InverseOf.UnionWith(this.Relations.InverseOf);
            result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(this.Relations.CustomRelations);

            //Add annotations from this property model
            result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.Comment           = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label             = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso           = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy       = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.CustomAnnotations = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given property model
            if (propertyModel  != null) {

                //Add properties from the given property model
                foreach (var p in propertyModel) {
                    result.AddProperty(p);
                }

                //Add relations from the given property model
                result.Relations.SubPropertyOf       = result.Relations.SubPropertyOf.UnionWith(propertyModel.Relations.SubPropertyOf);
                result.Relations.EquivalentProperty  = result.Relations.EquivalentProperty.UnionWith(propertyModel.Relations.EquivalentProperty);
                result.Relations.InverseOf           = result.Relations.InverseOf.UnionWith(propertyModel.Relations.InverseOf);
                result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(propertyModel.Relations.CustomRelations);

                //Add annotations from the given property model
                result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(propertyModel.Annotations.VersionInfo);
                result.Annotations.Comment           = result.Annotations.Comment.UnionWith(propertyModel.Annotations.Comment);
                result.Annotations.Label             = result.Annotations.Label.UnionWith(propertyModel.Annotations.Label);
                result.Annotations.SeeAlso           = result.Annotations.SeeAlso.UnionWith(propertyModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = result.Annotations.IsDefinedBy.UnionWith(propertyModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = result.Annotations.CustomAnnotations.UnionWith(propertyModel.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new difference property model from this property model and a given one
        /// </summary>
        public RDFOntologyPropertyModel DifferenceWith(RDFOntologyPropertyModel propertyModel) {
            var result          = new RDFOntologyPropertyModel();
            if (propertyModel  != null) {

                //Add difference properties
                foreach (var p in this) {
                    if  (!propertyModel.Properties.ContainsKey(p.PatternMemberID)) {
                          result.AddProperty(p);
                    }
                }

                //Add difference relations
                result.Relations.SubPropertyOf       = this.Relations.SubPropertyOf.DifferenceWith(propertyModel.Relations.SubPropertyOf);
                result.Relations.EquivalentProperty  = this.Relations.EquivalentProperty.DifferenceWith(propertyModel.Relations.EquivalentProperty);
                result.Relations.InverseOf           = this.Relations.InverseOf.DifferenceWith(propertyModel.Relations.InverseOf);
                result.Relations.CustomRelations     = this.Relations.CustomRelations.DifferenceWith(propertyModel.Relations.CustomRelations);

                //Add difference annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.DifferenceWith(propertyModel.Annotations.VersionInfo);
                result.Annotations.Comment           = this.Annotations.Comment.DifferenceWith(propertyModel.Annotations.Comment);
                result.Annotations.Label             = this.Annotations.Label.DifferenceWith(propertyModel.Annotations.Label);
                result.Annotations.SeeAlso           = this.Annotations.SeeAlso.DifferenceWith(propertyModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = this.Annotations.IsDefinedBy.DifferenceWith(propertyModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = this.Annotations.CustomAnnotations.DifferenceWith(propertyModel.Annotations.CustomAnnotations);

            }
            else {

                //Add properties from this property model
                foreach (var p in this) {
                    result.AddProperty(p);
                }

                //Add relations from this property model
                result.Relations.SubPropertyOf       = result.Relations.SubPropertyOf.UnionWith(this.Relations.SubPropertyOf);
                result.Relations.EquivalentProperty  = result.Relations.EquivalentProperty.UnionWith(this.Relations.EquivalentProperty);
                result.Relations.InverseOf           = result.Relations.InverseOf.UnionWith(this.Relations.InverseOf);
                result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(this.Relations.CustomRelations);

                //Add annotations from this property model
                result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
                result.Annotations.Comment           = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
                result.Annotations.Label             = result.Annotations.Label.UnionWith(this.Annotations.Label);
                result.Annotations.SeeAlso           = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            }
            return result;
        }
        #endregion

        #region Convert
        /// <summary>
        /// Gets a graph representation of this ontology property model, exporting inferences according to the selected behavior
        /// </summary>
        public RDFGraph ToRDFGraph(RDFSemanticsEnums.RDFOntologyInferenceExportBehavior infexpBehavior) {
            var result     = new RDFGraph();

            //Definitions (do not export BASE ontology properties)
            foreach(var p in this.Where(prop => RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(prop.ToString()) == null)) {
                if  (p.IsAnnotationProperty()) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.ANNOTATION_PROPERTY));
                }
                else if (p.IsDatatypeProperty()) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DATATYPE_PROPERTY));
                }
                else if (p.IsObjectProperty()) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.OBJECT_PROPERTY));
                     if (p.IsSymmetricProperty()) {
                         result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.SYMMETRIC_PROPERTY));
                     }
                     if (p.IsTransitiveProperty()) {
                         result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.TRANSITIVE_PROPERTY));
                     }
                     if (p.IsInverseFunctionalProperty()) {
                         result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.INVERSE_FUNCTIONAL_PROPERTY));
                     }
                }
                else {
                    result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.RDF.PROPERTY));
                }

                if  (p.IsFunctionalProperty()) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.FUNCTIONAL_PROPERTY));
                }
                if  (p.IsDeprecatedProperty()) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DEPRECATED_PROPERTY));
                }
                if  (p.Domain != null) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDFS.DOMAIN, (RDFResource)p.Domain.Value));
                }
                if  (p.Range  != null) {
                     result.AddTriple(new RDFTriple((RDFResource)p.Value, RDFVocabulary.RDFS.RANGE,  (RDFResource)p.Range.Value));
                }
            }

            //Relations
            result       = result.UnionWith(this.Relations.SubPropertyOf.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Relations.EquivalentProperty.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Relations.InverseOf.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Relations.CustomRelations.ToRDFGraph(infexpBehavior));

            //Annotations
            result       = result.UnionWith(this.Annotations.VersionInfo.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Annotations.Comment.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Annotations.Label.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Annotations.SeeAlso.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Annotations.IsDefinedBy.ToRDFGraph(infexpBehavior))
                                 .UnionWith(this.Annotations.CustomAnnotations.ToRDFGraph(infexpBehavior));
            
            return result;
        }
        #endregion

        #region Reasoner
        /// <summary>
        /// Clears all the taxonomy entries marked as true semantic inferences (=RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)
        /// </summary>
        public RDFOntologyPropertyModel ClearInferences() {
            var cacheRemove = new Dictionary<Int64, Object>();

            //SubPropertyOf
            foreach (var t in this.Relations.SubPropertyOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.SubPropertyOf.Entries.Remove(c); }
            cacheRemove.Clear();

            //EquivalentProperty
            foreach (var t in this.Relations.EquivalentProperty.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.EquivalentProperty.Entries.Remove(c); }
            cacheRemove.Clear();

            //InverseOf
            foreach (var t in this.Relations.InverseOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.InverseOf.Entries.Remove(c); }
            cacheRemove.Clear();

            //CustomRelations
            foreach (var t in this.Relations.CustomRelations.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.CustomRelations.Entries.Remove(c); }
            cacheRemove.Clear();

            return this;
        }
        #endregion

        #endregion

    }

    #region Metadata
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
    #endregion

}