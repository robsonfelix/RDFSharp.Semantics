﻿/*
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
    /// RDFOntologyClassModel represents the class-oriented model component (T-BOX) of an ontology.
    /// </summary>
    public class RDFOntologyClassModel: IEnumerable<RDFOntologyClass> {

        #region Properties
        /// <summary>
        /// Count of the classes composing the class model
        /// </summary>
        public Int64 ClassesCount {
            get { return this.Classes.Count; }
        }

        /// <summary>
        /// Count of the restrictions classes composing the class model
        /// </summary>
        public Int64 RestrictionsCount {
            get { return this.Classes.Count(c => c.Value.IsRestrictionClass()); }
        }

        /// <summary>
        /// Count of the enumerate classes composing the class model
        /// </summary>
        public Int64 EnumeratesCount {
            get { return this.Classes.Count(c => c.Value.IsEnumerateClass()); }
        }

        /// <summary>
        /// Count of the datarange classes composing the class model
        /// </summary>
        public Int64 DataRangesCount {
            get { return this.Classes.Count(c => c.Value.IsDataRangeClass()); }
        }

        /// <summary>
        /// Count of the composite classes composing the class model
        /// </summary>
        public Int64 CompositesCount {
            get { return this.Classes.Count(c => c.Value.IsCompositeClass()); }
        }

        /// <summary>
        /// Gets the enumerator on the class model's classes for iteration
        /// </summary>
        public IEnumerator<RDFOntologyClass> ClassesEnumerator {
            get { return this.Classes.Values.GetEnumerator(); }
        }

        /// <summary>
        /// Gets the enumerator on the class model's restriction classes for iteration
        /// </summary>
        public IEnumerator<RDFOntologyRestriction> RestrictionsEnumerator {
            get {
                return this.Classes.Values.Where(c => c.IsRestrictionClass())
                                          .OfType<RDFOntologyRestriction>()
                                          .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the class model's enumerate classes for iteration
        /// </summary>
        public IEnumerator<RDFOntologyEnumerateClass> EnumeratesEnumerator {
            get {
                return this.Classes.Values.Where(c => c.IsEnumerateClass())
                                          .OfType<RDFOntologyEnumerateClass>()
                                          .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the class model's datarange classes for iteration
        /// </summary>
        public IEnumerator<RDFOntologyDataRangeClass> DataRangesEnumerator {
            get {
                return this.Classes.Values.Where(c => c.IsDataRangeClass())
                                          .OfType<RDFOntologyDataRangeClass>()
                                          .GetEnumerator();
            }
        }

        /// <summary>
        /// Gets the enumerator on the class model's composite classes for iteration
        /// </summary>
        public IEnumerator<RDFOntologyClass> CompositesEnumerator {
            get {
                return this.Classes.Values.Where(c => c.IsCompositeClass())
                                          .GetEnumerator();
            }
        }

        /// <summary>
        /// Annotations describing classes of the ontology class model
        /// </summary>
        public RDFOntologyAnnotationsMetadata Annotations { get; internal set; }

        /// <summary>
        /// Relations describing classes of the ontology class model
        /// </summary>
        public RDFOntologyClassModelMetadata Relations { get; internal set; }

        /// <summary>
        /// Dictionary of classes composing the class model
        /// </summary>
        internal Dictionary<Int64, RDFOntologyClass> Classes { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty class model
        /// </summary>
        public RDFOntologyClassModel() {
            this.Classes     = new Dictionary<Int64, RDFOntologyClass>();
            this.Annotations = new RDFOntologyAnnotationsMetadata();
            this.Relations   = new RDFOntologyClassModelMetadata();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the class model's classes
        /// </summary>
        IEnumerator<RDFOntologyClass> IEnumerable<RDFOntologyClass>.GetEnumerator() {
            return this.Classes.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the ontology class model's classes
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.Classes.Values.GetEnumerator();
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given class to the ontology class model
        /// </summary>
        public RDFOntologyClassModel AddClass(RDFOntologyClass ontologyClass) {
            if (ontologyClass != null) {
                if (!this.Classes.ContainsKey(ontologyClass.PatternMemberID)) {
                     this.Classes.Add(ontologyClass.PatternMemberID, ontologyClass);
                }
            }
            return this;
        }

        /// <summary>
        /// Adds the given standard annotation to the given ontology class
        /// </summary>
        public RDFOntologyClassModel AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation standardAnnotation,
                                                           RDFOntologyClass ontologyClass,
                                                           RDFOntologyResource annotationValue) {
            if (ontologyClass != null && annotationValue != null) {
                switch (standardAnnotation) {

                    //owl:versionInfo
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo:
                         if (annotationValue.IsLiteral()) {
                             this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         }
                         else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology class with owl:versionInfo value '{0}' because it is not an ontology literal", annotationValue));
                         }
                         break;

                    //owl:versionIRI
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI:
                         RDFSemanticsEvents.RaiseSemanticsInfo("Cannot annotate ontology class with owl:versionIRI because it is reserved for ontologies");
                         break;

                    //rdfs:comment
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment:
                         if (annotationValue.IsLiteral()) {
                             this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty(), annotationValue));
                         }
                         else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology class with rdfs:comment value '{0}' because it is not an ontology literal", annotationValue));
                         }
                         break;

                    //rdfs:label
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label:
                         if (annotationValue.IsLiteral()) {
                             this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty(), annotationValue));
                         }
                         else {
                             RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Cannot annotate ontology class with rdfs:label value '{0}' because it is not an ontology literal", annotationValue));
                         }
                         break;

                    //rdfs:seeAlso
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso:
                         this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:isDefinedBy
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy:
                         this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:priorVersion
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion:
                         RDFSemanticsEvents.RaiseSemanticsInfo("Cannot annotate ontology class with owl:priorVersion because it is reserved for ontologies");
                         break;

                    //owl:imports
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports:
                         RDFSemanticsEvents.RaiseSemanticsInfo("Cannot annotate ontology class with owl:imports because it is reserved for ontologies");
                         break;

                    //owl:backwardCompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith:
                         RDFSemanticsEvents.RaiseSemanticsInfo("Cannot annotate ontology class with owl:backwardCompatibleWith because it is reserved for ontologies");
                         break;

                    //owl:incompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith:
                         RDFSemanticsEvents.RaiseSemanticsInfo("Cannot annotate ontology class with owl:incompatibleWith because it is reserved for ontologies");
                         break;

                }
            }
            return this;
        }

        /// <summary>
        /// Adds the given custom annotation to the given ontology class
        /// </summary>
        public RDFOntologyClassModel AddCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty,
                                                         RDFOntologyClass ontologyClass,
                                                         RDFOntologyResource annotationValue) {
            if (ontologyAnnotationProperty != null && ontologyClass != null && annotationValue != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty())) {
                    this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo, ontologyClass, annotationValue);
                }

                //owl:versionIRI
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI, ontologyClass, annotationValue);
                }

                //rdfs:comment
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment, ontologyClass, annotationValue);
                }

                //rdfs:label
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label, ontologyClass, annotationValue);
                }

                //rdfs:seeAlso
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso, ontologyClass, annotationValue);
                }

                //rdfs:isDefinedBy
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy, ontologyClass, annotationValue);
                }

                //owl:imports
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports, ontologyClass, annotationValue);
                }

                //owl:backwardCompatibleWith
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith, ontologyClass, annotationValue);
                }

                //owl:incompatibleWith
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith, ontologyClass, annotationValue);
                }

                //owl:priorVersion
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty())) {
                     this.AddStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion, ontologyClass, annotationValue);
                }

                //custom annotation
                else {
                     this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyAnnotationProperty, annotationValue));
                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "childClass -> rdfs:subClassOf -> motherClass" relation to the class model.
        /// </summary>
        public RDFOntologyClassModel AddSubClassOfRelation(RDFOntologyClass childClass, 
                                                           RDFOntologyClass motherClass) {
            if (childClass != null && motherClass != null && !childClass.Equals(motherClass)) {

                //Enforce preliminary checks on usage of BASE classes
                if (!RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(childClass.PatternMemberID) 
                     && !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(motherClass.PatternMemberID)) {

                     //Enforce taxonomy checks before adding the subClassOf relation
                     if (!RDFOntologyReasonerHelper.IsSubClassOf(motherClass, childClass, this) 
                          && !RDFOntologyReasonerHelper.IsEquivalentClassOf(motherClass, childClass, this) 
                          && !RDFOntologyReasonerHelper.IsDisjointClassWith(motherClass, childClass, this)) {
                          this.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(childClass, RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty(), motherClass));
                     }
                     else {

                          //Raise warning event to inform the user: SubClassOf relation cannot be added to the class model because it violates the taxonomy consistency
                          RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubClassOf relation between child class '{0}' and mother class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", childClass, motherClass));

                     }

                }
                else {

                     //Raise warning event to inform the user: SubClassOf relation cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubClassOf relation between child class '{0}' and mother class '{1}' cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency.", childClass, motherClass));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "aClass -> owl:equivalentClass -> bClass" relation to the class model.
        /// </summary>
        public RDFOntologyClassModel AddEquivalentClassRelation(RDFOntologyClass aClass, 
                                                                RDFOntologyClass bClass) {
            if (aClass != null && bClass != null && !aClass.Equals(bClass)) {

                //Enforce preliminary checks on usage of BASE classes
                if (!RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(aClass.PatternMemberID)
                     && !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(bClass.PatternMemberID)) {

                     //Enforce taxonomy checks before adding the equivalentClass relation
                     if (!RDFOntologyReasonerHelper.IsSubClassOf(aClass, bClass, this)
                          && !RDFOntologyReasonerHelper.IsSuperClassOf(aClass, bClass, this)
                          && !RDFOntologyReasonerHelper.IsDisjointClassWith(aClass, bClass, this)) {
                          this.Relations.EquivalentClass.AddEntry(new RDFOntologyTaxonomyEntry(aClass, RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty(), bClass));
                          this.Relations.EquivalentClass.AddEntry(new RDFOntologyTaxonomyEntry(bClass, RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty(), aClass).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                     }
                     else {
                     
                          //Raise warning event to inform the user: EquivalentClass relation cannot be added to the class model because it violates the taxonomy consistency
                          RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("EquivalentClass relation between class '{0}' and class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", aClass, bClass));
                     
                     }

                }
                else {

                     //Raise warning event to inform the user: EquivalentClass relation cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("EquivalentClass relation between class '{0}' and class '{1}' cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency.", aClass, bClass));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "aClass -> owl:disjointWith -> bClass" relation to the class model.
        /// </summary>
        public RDFOntologyClassModel AddDisjointWithRelation(RDFOntologyClass aClass, 
                                                             RDFOntologyClass bClass) {
            if (aClass != null && bClass != null && !aClass.Equals(bClass)) {

                //Enforce preliminary checks on usage of BASE classes
                if (!RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(aClass.PatternMemberID)
                     && !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(bClass.PatternMemberID)) {

                     //Enforce taxonomy checks before adding the disjointWith relation
                     if (!RDFOntologyReasonerHelper.IsSubClassOf(aClass, bClass, this)
                          && !RDFOntologyReasonerHelper.IsSuperClassOf(aClass, bClass, this)
                          && !RDFOntologyReasonerHelper.IsEquivalentClassOf(aClass, bClass, this)) {
                          this.Relations.DisjointWith.AddEntry(new RDFOntologyTaxonomyEntry(aClass, RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty(), bClass));
                          this.Relations.DisjointWith.AddEntry(new RDFOntologyTaxonomyEntry(bClass, RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty(), aClass).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                     }
                     else {

                          //Raise warning event to inform the user: DisjointWith relation cannot be added to the class model because it violates the taxonomy consistency
                          RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("DisjointWith relation between class '{0}' and class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", aClass, bClass));

                     }

                }
                else {

                     //Raise warning event to inform the user: DisjointWith relation cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("DisjointWith relation between class '{0}' and class '{1}' cannot be added to the class model because usage of BASE reserved classes compromises the taxonomy consistency.", aClass, bClass));

                }

            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyEnumerateClass -> owl:oneOf -> ontologyFact" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddOneOfRelation(RDFOntologyEnumerateClass ontologyEnumerateClass, 
                                                      RDFOntologyFact ontologyFact) {
            if (ontologyEnumerateClass != null && ontologyFact != null) {
                this.Relations.OneOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyEnumerateClass, RDFVocabulary.OWL.ONE_OF.ToRDFOntologyObjectProperty(), ontologyFact));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyDataRangeClass -> owl:oneOf -> ontologyLiteral" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddOneOfRelation(RDFOntologyDataRangeClass ontologyDataRangeClass, 
                                                      RDFOntologyLiteral ontologyLiteral) {
            if (ontologyDataRangeClass != null && ontologyLiteral != null) {
                this.Relations.OneOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyDataRangeClass, RDFVocabulary.OWL.ONE_OF.ToRDFOntologyDatatypeProperty(), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyIntersectionClass -> owl:intersectionOf -> ontologyClass" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddIntersectionOfRelation(RDFOntologyIntersectionClass ontologyIntersectionClass, 
                                                               RDFOntologyClass ontologyClass) {
            if (ontologyIntersectionClass != null && ontologyClass != null && !ontologyIntersectionClass.Equals(ontologyClass)) {
                this.Relations.IntersectionOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyIntersectionClass, RDFVocabulary.OWL.INTERSECTION_OF.ToRDFOntologyObjectProperty(), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyUnionClass -> owl:unionOf -> ontologyClass" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddUnionOfRelation(RDFOntologyUnionClass ontologyUnionClass, 
                                                        RDFOntologyClass ontologyClass) {
            if (ontologyUnionClass != null && ontologyClass != null && !ontologyUnionClass.Equals(ontologyClass)) {
                this.Relations.UnionOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyUnionClass, RDFVocabulary.OWL.UNION_OF.ToRDFOntologyObjectProperty(), ontologyClass));
            }
            return this;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the given class from the ontology class model
        /// </summary>
        public RDFOntologyClassModel RemoveClass(RDFOntologyClass ontologyClass) {
            if (ontologyClass != null) {
                if (this.Classes.ContainsKey(ontologyClass.PatternMemberID)) {
                    this.Classes.Remove(ontologyClass.PatternMemberID);
                }
            }
            return this;
        }

        /// <summary>
        /// Removes the given standard annotation from the given ontology class
        /// </summary>
        public RDFOntologyClassModel RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation standardAnnotation,
                                                              RDFOntologyClass ontologyClass,
                                                              RDFOntologyResource annotationValue) {
            if (ontologyClass != null && annotationValue != null) {
                switch (standardAnnotation) {

                    //owl:versionInfo
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo:
                         this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:versionIRI
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI:
                         this.Annotations.VersionIRI.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:comment
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment:
                         this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:label
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label:
                         this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:seeAlso
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso:
                         this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //rdfs:isDefinedBy
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy:
                         this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:priorVersion
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion:
                         this.Annotations.PriorVersion.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:imports
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports:
                         this.Annotations.Imports.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:backwardCompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith:
                         this.Annotations.BackwardCompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                    //owl:incompatibleWith
                    case RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith:
                         this.Annotations.IncompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty(), annotationValue));
                         break;

                }
            }
            return this;
        }

        /// <summary>
        /// Removes the given custom annotation from the given ontology class
        /// </summary>
        public RDFOntologyClassModel RemoveCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty,
                                                            RDFOntologyClass ontologyClass,
                                                            RDFOntologyResource annotationValue) {
            if (ontologyAnnotationProperty != null && ontologyClass != null && annotationValue != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty())) {
                    this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionInfo, ontologyClass, annotationValue);
                }

                //owl:versionIRI
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.VersionIRI, ontologyClass, annotationValue);
                }

                //rdfs:comment
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Comment, ontologyClass, annotationValue);
                }

                //rdfs:label
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Label, ontologyClass, annotationValue);
                }

                //rdfs:seeAlso
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.SeeAlso, ontologyClass, annotationValue);
                }

                //rdfs:isDefinedBy
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IsDefinedBy, ontologyClass, annotationValue);
                }

                //owl:imports
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.Imports, ontologyClass, annotationValue);
                }

                //owl:backwardCompatibleWith
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.BackwardCompatibleWith, ontologyClass, annotationValue);
                }

                //owl:incompatibleWith
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.IncompatibleWith, ontologyClass, annotationValue);
                }

                //owl:priorVersion
                else if (ontologyAnnotationProperty.Equals(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty())) {
                     this.RemoveStandardAnnotation(RDFSemanticsEnums.RDFOntologyStandardAnnotation.PriorVersion, ontologyClass, annotationValue);
                }

                //custom annotation
                else {
                     this.Annotations.CustomAnnotations.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyAnnotationProperty, annotationValue));
                }

            }
            return this;
        }

        /// <summary>
        /// Removes the "childClass -> rdfs:subClassOf -> motherClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveSubClassOfRelation(RDFOntologyClass childClass, 
                                                              RDFOntologyClass motherClass) {
            if (childClass != null && motherClass != null) {
                this.Relations.SubClassOf.RemoveEntry(new RDFOntologyTaxonomyEntry(childClass, RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty(), motherClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aClass -> owl:equivalentClass -> bClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveEquivalentClassRelation(RDFOntologyClass aClass, 
                                                                   RDFOntologyClass bClass) {
            if (aClass != null && bClass != null) {
                this.Relations.EquivalentClass.RemoveEntry(new RDFOntologyTaxonomyEntry(aClass, RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty(), bClass));
                this.Relations.EquivalentClass.RemoveEntry(new RDFOntologyTaxonomyEntry(bClass, RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty(), aClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aClass -> owl:disjointWith -> bClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveDisjointWithRelation(RDFOntologyClass aClass, 
                                                                RDFOntologyClass bClass) {
            if (aClass != null && bClass != null) {
                this.Relations.DisjointWith.RemoveEntry(new RDFOntologyTaxonomyEntry(aClass, RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty(), bClass));
                this.Relations.DisjointWith.RemoveEntry(new RDFOntologyTaxonomyEntry(bClass, RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty(), aClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyEnumerateClass -> owl:oneOf -> ontologyFact" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveOneOfRelation(RDFOntologyEnumerateClass ontologyEnumerateClass, 
                                                         RDFOntologyFact ontologyFact) {
            if (ontologyEnumerateClass != null && ontologyFact != null) {
                this.Relations.OneOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyEnumerateClass, RDFVocabulary.OWL.ONE_OF.ToRDFOntologyObjectProperty(), ontologyFact));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyDataRangeClass -> owl:oneOf -> ontologyLiteral" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveOneOfRelation(RDFOntologyDataRangeClass ontologyDataRangeClass, 
                                                         RDFOntologyLiteral ontologyLiteral) {
            if (ontologyDataRangeClass != null && ontologyLiteral != null) {
                this.Relations.OneOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyDataRangeClass, RDFVocabulary.OWL.ONE_OF.ToRDFOntologyDatatypeProperty(), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyIntersectionClass -> owl:intersectionOf -> ontologyClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveIntersectionOfRelation(RDFOntologyIntersectionClass ontologyIntersectionClass, 
                                                                  RDFOntologyClass ontologyClass) {
            if (ontologyIntersectionClass != null && ontologyClass != null) {
                this.Relations.IntersectionOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyIntersectionClass, RDFVocabulary.OWL.INTERSECTION_OF.ToRDFOntologyObjectProperty(), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyUnionClass -> owl:unionOf -> ontologyClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveUnionOfRelation(RDFOntologyUnionClass ontologyUnionClass, 
                                                           RDFOntologyClass ontologyClass) {
            if (ontologyUnionClass != null && ontologyClass != null) {
                this.Relations.UnionOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyUnionClass, RDFVocabulary.OWL.UNION_OF.ToRDFOntologyObjectProperty(), ontologyClass));
            }
            return this;
        }
        #endregion

        #region Select
        /// <summary>
        /// Selects the ontology class represented by the given string from the ontology class model
        /// </summary>
        public RDFOntologyClass SelectClass(String ontClass) {
            if (ontClass     != null) {
                Int64 classID = RDFModelUtilities.CreateHash(ontClass);
                if (this.Classes.ContainsKey(classID)) {
                    return this.Classes[classID];
                }
            }
            return null;
        }
        #endregion

        #region Set
        /// <summary>
        /// Builds a new intersection class model from this class model and a given one
        /// </summary>
        public RDFOntologyClassModel IntersectWith(RDFOntologyClassModel classModel) {
            var result       = new RDFOntologyClassModel();
            if (classModel  != null) {

                //Add intersection classes
                foreach (var c in this) {
                    if  (classModel.Classes.ContainsKey(c.PatternMemberID)) {
                         result.AddClass(c);
                    }
                }

                //Add intersection relations
                result.Relations.SubClassOf          = this.Relations.SubClassOf.IntersectWith(classModel.Relations.SubClassOf);
                result.Relations.EquivalentClass     = this.Relations.EquivalentClass.IntersectWith(classModel.Relations.EquivalentClass);
                result.Relations.DisjointWith        = this.Relations.DisjointWith.IntersectWith(classModel.Relations.DisjointWith);
                result.Relations.OneOf               = this.Relations.OneOf.IntersectWith(classModel.Relations.OneOf);
                result.Relations.IntersectionOf      = this.Relations.IntersectionOf.IntersectWith(classModel.Relations.IntersectionOf);
                result.Relations.UnionOf             = this.Relations.UnionOf.IntersectWith(classModel.Relations.UnionOf);

                //Add intersection annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.IntersectWith(classModel.Annotations.VersionInfo);
                result.Annotations.Comment           = this.Annotations.Comment.IntersectWith(classModel.Annotations.Comment);
                result.Annotations.Label             = this.Annotations.Label.IntersectWith(classModel.Annotations.Label);
                result.Annotations.SeeAlso           = this.Annotations.SeeAlso.IntersectWith(classModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = this.Annotations.IsDefinedBy.IntersectWith(classModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = this.Annotations.CustomAnnotations.IntersectWith(classModel.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new union class model from this class model and a given one
        /// </summary>
        public RDFOntologyClassModel UnionWith(RDFOntologyClassModel classModel) {
            var result   = new RDFOntologyClassModel();

            //Add classes from this class model
            foreach (var c in this) {
                result.AddClass(c);
            }

            //Add relations from this class model
            result.Relations.SubClassOf          = result.Relations.SubClassOf.UnionWith(this.Relations.SubClassOf);
            result.Relations.EquivalentClass     = result.Relations.EquivalentClass.UnionWith(this.Relations.EquivalentClass);
            result.Relations.DisjointWith        = result.Relations.DisjointWith.UnionWith(this.Relations.DisjointWith);
            result.Relations.OneOf               = result.Relations.OneOf.UnionWith(this.Relations.OneOf);
            result.Relations.IntersectionOf      = result.Relations.IntersectionOf.UnionWith(this.Relations.IntersectionOf);
            result.Relations.UnionOf             = result.Relations.UnionOf.UnionWith(this.Relations.UnionOf);

            //Add annotations from this class model
            result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.Comment           = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label             = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso           = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy       = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.CustomAnnotations = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given class model
            if (classModel  != null) {

                //Add classes from the given class model
                foreach (var c in classModel) {
                    result.AddClass(c);
                }

                //Add relations from the given class model
                result.Relations.SubClassOf          = result.Relations.SubClassOf.UnionWith(classModel.Relations.SubClassOf);
                result.Relations.EquivalentClass     = result.Relations.EquivalentClass.UnionWith(classModel.Relations.EquivalentClass);
                result.Relations.DisjointWith        = result.Relations.DisjointWith.UnionWith(classModel.Relations.DisjointWith);
                result.Relations.OneOf               = result.Relations.OneOf.UnionWith(classModel.Relations.OneOf);
                result.Relations.IntersectionOf      = result.Relations.IntersectionOf.UnionWith(classModel.Relations.IntersectionOf);
                result.Relations.UnionOf             = result.Relations.UnionOf.UnionWith(classModel.Relations.UnionOf);

                //Add annotations from the given class model
                result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(classModel.Annotations.VersionInfo);
                result.Annotations.Comment           = result.Annotations.Comment.UnionWith(classModel.Annotations.Comment);
                result.Annotations.Label             = result.Annotations.Label.UnionWith(classModel.Annotations.Label);
                result.Annotations.SeeAlso           = result.Annotations.SeeAlso.UnionWith(classModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = result.Annotations.IsDefinedBy.UnionWith(classModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = result.Annotations.CustomAnnotations.UnionWith(classModel.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new difference class model from this class model and a given one
        /// </summary>
        public RDFOntologyClassModel DifferenceWith(RDFOntologyClassModel classModel) {
            var result       = new RDFOntologyClassModel();
            if (classModel  != null) {

                //Add difference classes
                foreach (var c in this) {
                    if  (!classModel.Classes.ContainsKey(c.PatternMemberID)) {
                          result.AddClass(c);
                    }
                }

                //Add difference relations
                result.Relations.SubClassOf          = this.Relations.SubClassOf.DifferenceWith(classModel.Relations.SubClassOf);
                result.Relations.EquivalentClass     = this.Relations.EquivalentClass.DifferenceWith(classModel.Relations.EquivalentClass);
                result.Relations.DisjointWith        = this.Relations.DisjointWith.DifferenceWith(classModel.Relations.DisjointWith);
                result.Relations.OneOf               = this.Relations.OneOf.DifferenceWith(classModel.Relations.OneOf);
                result.Relations.IntersectionOf      = this.Relations.IntersectionOf.DifferenceWith(classModel.Relations.IntersectionOf);
                result.Relations.UnionOf             = this.Relations.UnionOf.DifferenceWith(classModel.Relations.UnionOf);

                //Add difference annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.DifferenceWith(classModel.Annotations.VersionInfo);
                result.Annotations.Comment           = this.Annotations.Comment.DifferenceWith(classModel.Annotations.Comment);
                result.Annotations.Label             = this.Annotations.Label.DifferenceWith(classModel.Annotations.Label);
                result.Annotations.SeeAlso           = this.Annotations.SeeAlso.DifferenceWith(classModel.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy       = this.Annotations.IsDefinedBy.DifferenceWith(classModel.Annotations.IsDefinedBy);
                result.Annotations.CustomAnnotations = this.Annotations.CustomAnnotations.DifferenceWith(classModel.Annotations.CustomAnnotations);

            }
            else {

                //Add classes from this class model
                foreach (var c in this) {
                    result.AddClass(c);
                }

                //Add relations from this class model
                result.Relations.SubClassOf          = result.Relations.SubClassOf.UnionWith(this.Relations.SubClassOf);
                result.Relations.EquivalentClass     = result.Relations.EquivalentClass.UnionWith(this.Relations.EquivalentClass);
                result.Relations.DisjointWith        = result.Relations.DisjointWith.UnionWith(this.Relations.DisjointWith);
                result.Relations.OneOf               = result.Relations.OneOf.UnionWith(this.Relations.OneOf);
                result.Relations.IntersectionOf      = result.Relations.IntersectionOf.UnionWith(this.Relations.IntersectionOf);
                result.Relations.UnionOf             = result.Relations.UnionOf.UnionWith(this.Relations.UnionOf);

                //Add annotations from this class model
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
        /// Gets a graph representation of this ontology class model, exporting inferences according to the selected behavior
        /// </summary>
        public RDFGraph ToRDFGraph(RDFSemanticsEnums.RDFOntologyInferenceExportBehavior infexpBehavior) {
            var result        = new RDFGraph();

            //Definitions
            foreach(var    c in this.Where(c => !RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(c.PatternMemberID))) {

                //Restriction
                if (c.IsRestrictionClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.RESTRICTION));
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ON_PROPERTY, (RDFResource)((RDFOntologyRestriction)c).OnProperty.Value));
                    if (c is RDFOntologyAllValuesFromRestriction) {
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ALL_VALUES_FROM, (RDFResource)((RDFOntologyAllValuesFromRestriction)c).FromClass.Value));
                     }
                     else if (c is RDFOntologySomeValuesFromRestriction) {
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.SOME_VALUES_FROM, (RDFResource)((RDFOntologySomeValuesFromRestriction)c).FromClass.Value));
                     }
                     else if (c is RDFOntologyHasValueRestriction) {
                        if (((RDFOntologyHasValueRestriction)c).RequiredValue.IsLiteral()) {
                            result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.HAS_VALUE, (RDFLiteral)((RDFOntologyHasValueRestriction)c).RequiredValue.Value));
                        }
                        else {
                            result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.HAS_VALUE, (RDFResource)((RDFOntologyHasValueRestriction)c).RequiredValue.Value));
                        }
                     }
                     else if (c is RDFOntologyCardinalityRestriction) {
                        if  (((RDFOntologyCardinalityRestriction)c).MinCardinality == ((RDFOntologyCardinalityRestriction)c).MaxCardinality) {
                             result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MinCardinality.ToString(), RDFModelEnums.RDFDatatypes.XSD_NONNEGATIVEINTEGER)));
                        }
                        else {
                            if (((RDFOntologyCardinalityRestriction)c).MinCardinality > 0) {
                                result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.MIN_CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MinCardinality.ToString(), RDFModelEnums.RDFDatatypes.XSD_NONNEGATIVEINTEGER)));
                            }
                            if (((RDFOntologyCardinalityRestriction)c).MaxCardinality > 0) {
                                result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.MAX_CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MaxCardinality.ToString(), RDFModelEnums.RDFDatatypes.XSD_NONNEGATIVEINTEGER)));
                            }
                        }
                     }
                }

                //Enumerate
                else if (c.IsEnumerateClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.CLASS));
                    RDFCollection enumCollection        = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                    enumCollection.ReificationSubject   = new RDFResource("bnode:" + c.PatternMemberID);
                    if (infexpBehavior                 == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.None     ||
                        infexpBehavior                 == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyData) {
                        foreach (var enumMember        in this.Relations.OneOf.SelectEntriesBySubject(c).Where(tax => tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None)) {
                            enumCollection.AddItem((RDFResource)enumMember.TaxonomyObject.Value);
                        }
                    }
                    else {
                        foreach (var enumMember        in this.Relations.OneOf.SelectEntriesBySubject(c)) {
                            enumCollection.AddItem((RDFResource)enumMember.TaxonomyObject.Value);
                        }
                    }
                    result                              = result.UnionWith(enumCollection.ReifyCollection());
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ONE_OF, enumCollection.ReificationSubject));
                }

                //DataRange
                else if (c.IsDataRangeClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DATA_RANGE));
                    RDFCollection drangeCollection      = new RDFCollection(RDFModelEnums.RDFItemTypes.Literal);
                    drangeCollection.ReificationSubject = new RDFResource("bnode:" + c.PatternMemberID);
                    if (infexpBehavior                 == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.None     ||
                        infexpBehavior                 == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyData) {
                        foreach (var drangeMember      in this.Relations.OneOf.SelectEntriesBySubject(c).Where(tax => tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None)) {
                            drangeCollection.AddItem((RDFLiteral)drangeMember.TaxonomyObject.Value);
                        }
                    }
                    else {
                        foreach (var drangeMember      in this.Relations.OneOf.SelectEntriesBySubject(c)) {
                            drangeCollection.AddItem((RDFLiteral)drangeMember.TaxonomyObject.Value);
                        }
                    }
                    result                              = result.UnionWith(drangeCollection.ReifyCollection());
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ONE_OF, drangeCollection.ReificationSubject));
                }

                //Composite
                else if (c.IsCompositeClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.CLASS));
                    if  (c is RDFOntologyComplementClass) {
                         result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.COMPLEMENT_OF, (RDFResource)((RDFOntologyComplementClass)c).ComplementOf.Value));
                    }
                    else if (c is RDFOntologyIntersectionClass) {
                        var intersectCollection                = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                        intersectCollection.ReificationSubject = new RDFResource("bnode:" + c.PatternMemberID);
                        if (infexpBehavior                    == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.None     ||
                            infexpBehavior                    == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyData) {
                            foreach (var intersectMember      in this.Relations.IntersectionOf.SelectEntriesBySubject(c).Where(tax => tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None)) {
                                intersectCollection.AddItem((RDFResource)intersectMember.TaxonomyObject.Value);
                            }
                        }
                        else {
                            foreach (var intersectMember      in this.Relations.IntersectionOf.SelectEntriesBySubject(c)) {
                                intersectCollection.AddItem((RDFResource)intersectMember.TaxonomyObject.Value);
                            }
                        }
                        result                                 = result.UnionWith(intersectCollection.ReifyCollection());
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.INTERSECTION_OF, intersectCollection.ReificationSubject));
                    }
                    else if (c is RDFOntologyUnionClass) {
                        var unionCollection                    = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                        unionCollection.ReificationSubject     = new RDFResource("bnode:" + c.PatternMemberID);
                        if (infexpBehavior                    == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.None     ||
                            infexpBehavior                    == RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.OnlyData) {
                            foreach (var unionMember          in this.Relations.UnionOf.SelectEntriesBySubject(c).Where(tax => tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None)) {
                                unionCollection.AddItem((RDFResource)unionMember.TaxonomyObject.Value);
                            }
                        }
                        else {
                            foreach (var unionMember          in this.Relations.UnionOf.SelectEntriesBySubject(c)) {
                                unionCollection.AddItem((RDFResource)unionMember.TaxonomyObject.Value);
                            }
                        }
                        result                                 = result.UnionWith(unionCollection.ReifyCollection());
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.UNION_OF, unionCollection.ReificationSubject));
                    }
                }

                //Class
                else {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, (c.Nature == RDFSemanticsEnums.RDFOntologyClassNature.OWL ? RDFVocabulary.OWL.CLASS : RDFVocabulary.RDFS.CLASS)));
                    if (c.IsDeprecatedClass()) {
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DEPRECATED_CLASS));
                    }
                }

            }

            //Relations
            result         = result.UnionWith(this.Relations.SubClassOf.ToRDFGraph(infexpBehavior))
                                   .UnionWith(this.Relations.EquivalentClass.ToRDFGraph(infexpBehavior))
                                   .UnionWith(this.Relations.DisjointWith.ToRDFGraph(infexpBehavior));

            //Annotations
            result         = result.UnionWith(this.Annotations.VersionInfo.ToRDFGraph(infexpBehavior))
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
        /// Clears all the taxonomy entries marked as semantic inferences generated by a reasoner
        /// </summary>
        public void ClearInferences() {
            var cacheRemove = new Dictionary<Int64, Object>();

            //SubClassOf
            foreach (var t in this.Relations.SubClassOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.SubClassOf.Entries.Remove(c); }
            cacheRemove.Clear();

            //EquivalentClass
            foreach (var t in this.Relations.EquivalentClass.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.EquivalentClass.Entries.Remove(c); }
            cacheRemove.Clear();

            //DisjointWith
            foreach (var t in this.Relations.DisjointWith.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.DisjointWith.Entries.Remove(c); }
            cacheRemove.Clear();

            //UnionOf
            foreach (var t in this.Relations.UnionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.UnionOf.Entries.Remove(c); }
            cacheRemove.Clear();

            //IntersectionOf
            foreach (var t in this.Relations.IntersectionOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.IntersectionOf.Entries.Remove(c); }
            cacheRemove.Clear();

            //OneOf
            foreach (var t in this.Relations.OneOf.Where(tEntry => tEntry.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)) {
                cacheRemove.Add(t.TaxonomyEntryID, null);
            }
            foreach (var c in cacheRemove.Keys) { this.Relations.OneOf.Entries.Remove(c); }
            cacheRemove.Clear();

        }
        #endregion

        #endregion

    }

    #region Metadata
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
        }
        #endregion

    }
    #endregion

}