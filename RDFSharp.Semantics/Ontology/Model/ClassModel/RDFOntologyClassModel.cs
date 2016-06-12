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
        /// Adds the "ontologyClass -> owl:VersionInfo -> ontologyLiteral" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddVersionInfoAnnotation(RDFOntologyClass ontologyClass, 
                                                              RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> vs:term_status -> termStatus" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddTermStatusAnnotation(RDFOntologyClass ontologyClass,
                                                             RDFModelEnums.RDFTermStatus termStatus) {
            if (ontologyClass != null) {
                if (this.Annotations.TermStatus.SelectEntriesBySubject(ontologyClass).EntriesCount == 0) {
                    this.Annotations.TermStatus.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.VS.TERM_STATUS.ToString()), new RDFOntologyLiteral(new RDFPlainLiteral(RDFModelUtilities.GetTermStatus(termStatus)))));
                }
                else {

                    //Raise warning event to inform user: only one vs:term_status annotation is allowed per ontology class.
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Only one 'vs:term_status' annotation is allowed per ontology class: please, check ontology class '{0}'.", ontologyClass));

                }
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> rdfs:comment -> ontologyLiteral" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddCommentAnnotation(RDFOntologyClass ontologyClass, 
                                                          RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> rdfs:label -> ontologyLiteral" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddLabelAnnotation(RDFOntologyClass ontologyClass, 
                                                        RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> rdfs:seeAlso -> ontologyResource" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddSeeAlsoAnnotation(RDFOntologyClass ontologyClass, 
                                                          RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyResource != null) {
                this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> rdfs:isDefinedBy -> ontologyResource" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddIsDefinedByAnnotation(RDFOntologyClass ontologyClass, 
                                                              RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyResource != null) {
                this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> ontologyAnnotationProperty -> ontologyResource" annotation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddCustomAnnotation(RDFOntologyClass ontologyClass, 
                                                         RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                                         RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.AddVersionInfoAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                    }
                }

                //vs:term_status
                else if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.VS.TERM_STATUS.ToString()))) {
                     if (ontologyResource.IsLiteral()) {
                         String termStatus   = ontologyResource.ToString().Trim().ToUpperInvariant();
                         if (termStatus     == "STABLE") {
                             this.AddTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Stable);
                         }
                         else if(termStatus == "UNSTABLE") {
                             this.AddTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Unstable);
                         }
                         else if(termStatus == "TESTING") {
                             this.AddTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Testing);
                         }
                         else if(termStatus == "ARCHAIC") {
                             this.AddTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Archaic);
                         }
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddCommentAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddLabelAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.AddSeeAlsoAnnotation(ontologyClass, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.AddIsDefinedByAnnotation(ontologyClass, ontologyResource);
                }

                //ontology-specific
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))              ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))                  ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString())) ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))        ||
                        ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {

                     //Raise warning event to inform the user: Ontology-specific annotation properties cannot be used for classes
                     RDFSemanticsEvents.RaiseSemanticsWarning("Ontology-specific annotation properties cannot be used for classes.");

                }

                //custom
                else {
                    this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyAnnotationProperty, ontologyResource));
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

                //Enforce boundary checks on top/bottom OWL classes
                if (motherClass.Equals(RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.OWL.NOTHING.ToString())) ||
                    childClass.Equals(RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.OWL.THING.ToString())))    {

                    //Raise warning event to inform the user: SubClassOf relation cannot be added to the class model because it violates the taxonomy consistency
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubClassOf relation between child class '{0}' and mother class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", childClass, motherClass));

                }
                else {

                    //Enforce taxonomy checks before adding the subClassOf relation
                    if (!RDFBASEOntologyReasoningHelper.IsSubClassOf(motherClass,        childClass, this)   &&
                        !RDFBASEOntologyReasoningHelper.IsEquivalentClassOf(motherClass, childClass, this)   &&
                        !RDFBASEOntologyReasoningHelper.IsDisjointClassWith(motherClass, childClass, this))   {
                         this.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(childClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToString()), motherClass));
                    }
                    else {

                         //Raise warning event to inform the user: SubClassOf relation cannot be added to the class model because it violates the taxonomy consistency
                         RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("SubClassOf relation between child class '{0}' and mother class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", childClass, motherClass));

                    }

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

                //Enforce taxonomy checks before adding the equivalentClass relation
                if (!RDFBASEOntologyReasoningHelper.IsSubClassOf(aClass,        bClass, this) &&
                    !RDFBASEOntologyReasoningHelper.IsSuperClassOf(aClass,      bClass, this) &&
                    !RDFBASEOntologyReasoningHelper.IsDisjointClassWith(aClass, bClass, this)) {
                     this.Relations.EquivalentClass.AddEntry(new RDFOntologyTaxonomyEntry(aClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()), bClass));
                     this.Relations.EquivalentClass.AddEntry(new RDFOntologyTaxonomyEntry(bClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()), aClass).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                }
                else {

                     //Raise warning event to inform the user: EquivalentClass relation cannot be added to the class model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("EquivalentClass relation between class '{0}' and class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", aClass, bClass));

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

                //Enforce taxonomy checks before adding the disjointWith relation
                if (!RDFBASEOntologyReasoningHelper.IsSubClassOf(aClass,        bClass, this) &&
                    !RDFBASEOntologyReasoningHelper.IsSuperClassOf(aClass,      bClass, this) &&
                    !RDFBASEOntologyReasoningHelper.IsEquivalentClassOf(aClass, bClass, this)) {
                     this.Relations.DisjointWith.AddEntry(new RDFOntologyTaxonomyEntry(aClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()), bClass));
                     this.Relations.DisjointWith.AddEntry(new RDFOntologyTaxonomyEntry(bClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()), aClass).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
                }
                else {

                     //Raise warning event to inform the user: DisjointWith relation cannot be added to the class model because it violates the taxonomy consistency
                     RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("DisjointWith relation between class '{0}' and class '{1}' cannot be added to the class model because it violates the taxonomy consistency.", aClass, bClass));

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
                this.Relations.OneOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyEnumerateClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()), ontologyFact));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyDataRangeClass -> owl:oneOf -> ontologyLiteral" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddOneOfRelation(RDFOntologyDataRangeClass ontologyDataRangeClass, 
                                                      RDFOntologyLiteral ontologyLiteral) {
            if (ontologyDataRangeClass != null && ontologyLiteral != null) {
                this.Relations.OneOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyDataRangeClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyIntersectionClass -> owl:intersectionOf -> ontologyClass" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddIntersectionOfRelation(RDFOntologyIntersectionClass ontologyIntersectionClass, 
                                                               RDFOntologyClass ontologyClass) {
            if (ontologyIntersectionClass != null && ontologyClass != null && !ontologyIntersectionClass.Equals(ontologyClass)) {
                this.Relations.IntersectionOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyIntersectionClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToString()), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyUnionClass -> owl:unionOf -> ontologyClass" relation to the class model 
        /// </summary>
        public RDFOntologyClassModel AddUnionOfRelation(RDFOntologyUnionClass ontologyUnionClass, 
                                                        RDFOntologyClass ontologyClass) {
            if (ontologyUnionClass != null && ontologyClass != null && !ontologyUnionClass.Equals(ontologyClass)) {
                this.Relations.UnionOf.AddEntry(new RDFOntologyTaxonomyEntry(ontologyUnionClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.UNION_OF.ToString()), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontologyClass -> ontologyProperty -> ontologyResource" relation to the class model
        /// If the property is an annotation property, it redirects to the "AddCustomAnnotation" method
        /// </summary>
        public RDFOntologyClassModel AddCustomRelation(RDFOntologyClass ontologyClass, 
                                                       RDFOntologyProperty ontologyProperty, 
                                                       RDFOntologyResource ontologyResource) {
            if(ontologyClass != null && ontologyProperty != null && ontologyResource != null) {

                //Custom annotations
                if (ontologyProperty.IsAnnotationProperty()) {
                    return this.AddCustomAnnotation(ontologyClass, (RDFOntologyAnnotationProperty)ontologyProperty, ontologyResource);
                }

                //rdfs:subClassOf
                if (ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToString()))) {
                    if (ontologyResource.IsClass()) {
                        this.AddSubClassOfRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                    }
                }

                //owl:equivalentClass
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()))) {
                     if(ontologyResource.IsClass()) {
                        this.AddEquivalentClassRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:disjointWith
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()))) {
                     if(ontologyResource.IsClass()) {
                        this.AddDisjointWithRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:oneOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()))) {
                     if(ontologyClass.IsEnumerateClass() && ontologyResource.IsFact()) {
                        this.AddOneOfRelation((RDFOntologyEnumerateClass)ontologyClass, (RDFOntologyFact)ontologyResource);
                     }
                     else if(ontologyClass.IsDataRangeClass() && ontologyResource.IsLiteral()) {
                        this.AddOneOfRelation((RDFOntologyDataRangeClass)ontologyClass, (RDFOntologyLiteral)ontologyResource);
                    }
                }

                //owl:IntersectionOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToString()))) {
                     if(ontologyClass is RDFOntologyIntersectionClass && ontologyResource.IsClass()) {
                        this.AddIntersectionOfRelation((RDFOntologyIntersectionClass)ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:UnionOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.UNION_OF.ToString()))) {
                     if(ontologyClass is RDFOntologyUnionClass && ontologyResource.IsClass()) {
                        this.AddUnionOfRelation((RDFOntologyUnionClass)ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Relations.CustomRelations.AddEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyProperty, ontologyResource));
                }

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
        /// Removes the "ontologyClass -> owl:VersionInfo -> ontologyLiteral" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveVersionInfoAnnotation(RDFOntologyClass ontologyClass, 
                                                                 RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> vs:term_status -> termStatus" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveTermStatusAnnotation(RDFOntologyClass ontologyClass,
                                                                RDFModelEnums.RDFTermStatus termStatus) {
            if (ontologyClass != null) {
                this.Annotations.TermStatus.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.VS.TERM_STATUS.ToString()), new RDFOntologyLiteral(new RDFPlainLiteral(RDFModelUtilities.GetTermStatus(termStatus)))));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> rdfs:comment -> ontologyLiteral" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveCommentAnnotation(RDFOntologyClass ontologyClass, 
                                                             RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> rdfs:label -> ontologyLiteral" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveLabelAnnotation(RDFOntologyClass ontologyClass, 
                                                           RDFOntologyLiteral ontologyLiteral) {
            if (ontologyClass != null && ontologyLiteral != null) {
                this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> rdfs:seeAlso -> ontologyResource" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveSeeAlsoAnnotation(RDFOntologyClass ontologyClass, 
                                                             RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyResource != null) {
                this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> rdfs:isDefinedBy -> ontologyResource" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveIsDefinedByAnnotation(RDFOntologyClass ontologyClass, 
                                                                 RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyResource != null) {
                this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> ontologyAnnotationProperty -> ontologyResource" annotation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveCustomAnnotation(RDFOntologyClass ontologyClass, 
                                                            RDFOntologyAnnotationProperty ontologyAnnotationProperty, 
                                                            RDFOntologyResource ontologyResource) {
            if (ontologyClass != null && ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.RemoveVersionInfoAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                    }
                }

                //vs:term_status
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.VS.TERM_STATUS.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        String termStatus   = ontologyResource.ToString().Trim().ToUpperInvariant();
                        if(termStatus      == "STABLE") {
                            this.RemoveTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Stable);
                        }
                        else if(termStatus == "UNSTABLE") {
                            this.RemoveTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Unstable);
                        }
                        else if(termStatus == "TESTING") {
                            this.RemoveTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Testing);
                        }
                        else if(termStatus == "ARCHAIC") {
                            this.RemoveTermStatusAnnotation(ontologyClass, RDFModelEnums.RDFTermStatus.Archaic);
                        }
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveCommentAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveLabelAnnotation(ontologyClass, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.RemoveSeeAlsoAnnotation(ontologyClass, ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.RemoveIsDefinedByAnnotation(ontologyClass, ontologyResource);
                }

                //custom
                else {
                     this.Annotations.CustomAnnotations.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyAnnotationProperty, ontologyResource));
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
                this.Relations.SubClassOf.RemoveEntry(new RDFOntologyTaxonomyEntry(childClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToString()), motherClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aClass -> owl:equivalentClass -> bClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveEquivalentClassRelation(RDFOntologyClass aClass, 
                                                                   RDFOntologyClass bClass) {
            if (aClass != null && bClass != null) {
                this.Relations.EquivalentClass.RemoveEntry(new RDFOntologyTaxonomyEntry(aClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()), bClass));
                this.Relations.EquivalentClass.RemoveEntry(new RDFOntologyTaxonomyEntry(bClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()), aClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "aClass -> owl:disjointWith -> bClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveDisjointWithRelation(RDFOntologyClass aClass, 
                                                                RDFOntologyClass bClass) {
            if (aClass != null && bClass != null) {
                this.Relations.DisjointWith.RemoveEntry(new RDFOntologyTaxonomyEntry(aClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()), bClass));
                this.Relations.DisjointWith.RemoveEntry(new RDFOntologyTaxonomyEntry(bClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()), aClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyEnumerateClass -> owl:oneOf -> ontologyFact" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveOneOfRelation(RDFOntologyEnumerateClass ontologyEnumerateClass, 
                                                         RDFOntologyFact ontologyFact) {
            if (ontologyEnumerateClass != null && ontologyFact != null) {
                this.Relations.OneOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyEnumerateClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()), ontologyFact));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyDataRangeClass -> owl:oneOf -> ontologyLiteral" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveOneOfRelation(RDFOntologyDataRangeClass ontologyDataRangeClass, 
                                                         RDFOntologyLiteral ontologyLiteral) {
            if (ontologyDataRangeClass != null && ontologyLiteral != null) {
                this.Relations.OneOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyDataRangeClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyIntersectionClass -> owl:intersectionOf -> ontologyClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveIntersectionOfRelation(RDFOntologyIntersectionClass ontologyIntersectionClass, 
                                                                  RDFOntologyClass ontologyClass) {
            if (ontologyIntersectionClass != null && ontologyClass != null) {
                this.Relations.IntersectionOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyIntersectionClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToString()), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyUnionClass -> owl:unionOf -> ontologyClass" relation from the class model 
        /// </summary>
        public RDFOntologyClassModel RemoveUnionOfRelation(RDFOntologyUnionClass ontologyUnionClass, 
                                                           RDFOntologyClass ontologyClass) {
            if (ontologyUnionClass != null && ontologyClass != null) {
                this.Relations.UnionOf.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyUnionClass, RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.UNION_OF.ToString()), ontologyClass));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontologyClass -> ontologyProperty -> ontologyResource" relation from the class model
        /// If the property is an annotation property, it redirects to the "RemoveCustomAnnotation" method
        /// </summary>
        public RDFOntologyClassModel RemoveCustomRelation(RDFOntologyClass ontologyClass,
                                                          RDFOntologyProperty ontologyProperty,
                                                          RDFOntologyResource ontologyResource) {
            if(ontologyClass != null && ontologyProperty != null && ontologyResource != null) {

                //Custom annotations
                if (ontologyProperty.IsAnnotationProperty()) {
                    return this.RemoveCustomAnnotation(ontologyClass, (RDFOntologyAnnotationProperty)ontologyProperty, ontologyResource);
                }

                //rdfs:subClassOf
                if (ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToString()))) {
                    if (ontologyResource.IsClass()) {
                        this.RemoveSubClassOfRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                    }
                }

                //owl:equivalentClass
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToString()))) {
                     if(ontologyResource.IsClass()) {
                        this.RemoveEquivalentClassRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:disjointWith
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToString()))) {
                     if(ontologyResource.IsClass()) {
                        this.RemoveDisjointWithRelation(ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:oneOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.ONE_OF.ToString()))) {
                     if(ontologyClass.IsEnumerateClass() && ontologyResource.IsFact()) {
                        this.RemoveOneOfRelation((RDFOntologyEnumerateClass)ontologyClass, (RDFOntologyFact)ontologyResource);
                     }
                     else if(ontologyClass.IsDataRangeClass() && ontologyResource.IsLiteral()) {
                        this.RemoveOneOfRelation((RDFOntologyDataRangeClass)ontologyClass, (RDFOntologyLiteral)ontologyResource);
                     }
                }

                //owl:IntersectionOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToString()))) {
                     if(ontologyClass is RDFOntologyIntersectionClass && ontologyResource.IsClass()) {
                        this.RemoveIntersectionOfRelation((RDFOntologyIntersectionClass)ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //owl:UnionOf
                else if(ontologyProperty.Equals(RDFBASEOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.OWL.UNION_OF.ToString()))) {
                     if(ontologyClass is RDFOntologyUnionClass && ontologyResource.IsClass()) {
                        this.RemoveUnionOfRelation((RDFOntologyUnionClass)ontologyClass, (RDFOntologyClass)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Relations.CustomRelations.RemoveEntry(new RDFOntologyTaxonomyEntry(ontologyClass, ontologyProperty, ontologyResource));
                }

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
                result.Relations.CustomRelations     = this.Relations.CustomRelations.IntersectWith(classModel.Relations.CustomRelations);

                //Add intersection annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.IntersectWith(classModel.Annotations.VersionInfo);
                result.Annotations.TermStatus        = this.Annotations.TermStatus.IntersectWith(classModel.Annotations.TermStatus);
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
            result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(this.Relations.CustomRelations);

            //Add annotations from this class model
            result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.TermStatus        = result.Annotations.TermStatus.UnionWith(this.Annotations.TermStatus);
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
                result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(classModel.Relations.CustomRelations);

                //Add annotations from the given class model
                result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(classModel.Annotations.VersionInfo);
                result.Annotations.TermStatus        = result.Annotations.TermStatus.UnionWith(classModel.Annotations.TermStatus);
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
                result.Relations.CustomRelations     = this.Relations.CustomRelations.DifferenceWith(classModel.Relations.CustomRelations);

                //Add difference annotations
                result.Annotations.VersionInfo       = this.Annotations.VersionInfo.DifferenceWith(classModel.Annotations.VersionInfo);
                result.Annotations.TermStatus        = this.Annotations.TermStatus.DifferenceWith(classModel.Annotations.TermStatus);
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
                result.Relations.CustomRelations     = result.Relations.CustomRelations.UnionWith(this.Relations.CustomRelations);

                //Add annotations from this class model
                result.Annotations.VersionInfo       = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
                result.Annotations.TermStatus        = result.Annotations.TermStatus.UnionWith(this.Annotations.TermStatus);
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
        /// Gets a graph representation of this ontology class model, eventually including inferences
        /// </summary>
        public RDFGraph ToRDFGraph(Boolean includeInferences) {
            var result        = new RDFGraph();

            //Definitions
            foreach(var    c in this) {
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
                             result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MinCardinality.ToString(), RDFDatatypeRegister.GetByPrefixAndDatatype(RDFVocabulary.XSD.PREFIX, "nonNegativeInteger"))));
                        }
                        else {
                            if (((RDFOntologyCardinalityRestriction)c).MinCardinality > 0) {
                                result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.MIN_CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MinCardinality.ToString(), RDFDatatypeRegister.GetByPrefixAndDatatype(RDFVocabulary.XSD.PREFIX, "nonNegativeInteger"))));
                            }
                            if (((RDFOntologyCardinalityRestriction)c).MaxCardinality > 0) {
                                result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.MAX_CARDINALITY, new RDFTypedLiteral(((RDFOntologyCardinalityRestriction)c).MaxCardinality.ToString(), RDFDatatypeRegister.GetByPrefixAndDatatype(RDFVocabulary.XSD.PREFIX, "nonNegativeInteger"))));
                            }
                        }
                     }
                }
                else if (c.IsEnumerateClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.CLASS));
                    var enumCollection                  = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                    enumCollection.ReificationSubject   = new RDFResource("bnode:" + c.PatternMemberID);
                    foreach (var enumMember in this.Relations.OneOf.SelectEntriesBySubject(c).Where(tax   => (includeInferences || tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None))) {
                        enumCollection.AddItem((RDFResource)enumMember.TaxonomyObject.Value);
                    }
                    result                              = result.UnionWith(enumCollection.ReifyCollection());
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ONE_OF, enumCollection.ReificationSubject));
                }
                else if (c.IsDataRangeClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DATA_RANGE));
                    var drangeCollection                = new RDFCollection(RDFModelEnums.RDFItemTypes.Literal);
                    drangeCollection.ReificationSubject = new RDFResource("bnode:" + c.PatternMemberID);
                    foreach (var drangeMember in this.Relations.OneOf.SelectEntriesBySubject(c).Where(tax => (includeInferences || tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None))) {
                        drangeCollection.AddItem((RDFLiteral)drangeMember.TaxonomyObject.Value);
                    }
                    result                              = result.UnionWith(drangeCollection.ReifyCollection());
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.ONE_OF, drangeCollection.ReificationSubject));
                }
                else if (c.IsCompositeClass()) {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.CLASS));
                    if  (c is RDFOntologyComplementClass) {
                         result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.COMPLEMENT_OF, (RDFResource)((RDFOntologyComplementClass)c).ComplementOf.Value));
                    }
                    else if (c is RDFOntologyIntersectionClass) {
                        var intersectCollection                = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                        intersectCollection.ReificationSubject = new RDFResource("bnode:" + c.PatternMemberID);
                        foreach (var intersectMember in this.Relations.IntersectionOf.SelectEntriesBySubject(c).Where(tax => (includeInferences || tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None))) {
                            intersectCollection.AddItem((RDFResource)intersectMember.TaxonomyObject.Value);
                        }
                        result                                 = result.UnionWith(intersectCollection.ReifyCollection());
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.INTERSECTION_OF, intersectCollection.ReificationSubject));
                    }
                    else if (c is RDFOntologyUnionClass) {
                        var unionCollection                    = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
                        unionCollection.ReificationSubject     = new RDFResource("bnode:" + c.PatternMemberID);
                        foreach (var unionMember in this.Relations.UnionOf.SelectEntriesBySubject(c).Where(tax => (includeInferences || tax.InferenceType == RDFSemanticsEnums.RDFOntologyInferenceType.None))) {
                            unionCollection.AddItem((RDFResource)unionMember.TaxonomyObject.Value);
                        }
                        result                                 = result.UnionWith(unionCollection.ReifyCollection());
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.OWL.UNION_OF, unionCollection.ReificationSubject));
                    }
                }
                else {
                    result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.CLASS));
                    if (c.IsDeprecatedClass()) {
                        result.AddTriple(new RDFTriple((RDFResource)c.Value, RDFVocabulary.RDF.TYPE, RDFVocabulary.OWL.DEPRECATED_CLASS));
                    }
                }
            }

            //Relations
            result         = result.UnionWith(this.Relations.SubClassOf.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Relations.EquivalentClass.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Relations.DisjointWith.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Relations.CustomRelations.ToRDFGraph(includeInferences));

            //Annotations
            result         = result.UnionWith(this.Annotations.VersionInfo.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.TermStatus.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.Comment.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.Label.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.SeeAlso.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.IsDefinedBy.ToRDFGraph(includeInferences))
                                   .UnionWith(this.Annotations.CustomAnnotations.ToRDFGraph(includeInferences));

            return result;
        }
        #endregion

        #region Reasoner
        /// <summary>
        /// Clears all the taxonomy entries marked as true semantic inferences (=RDFSemanticsEnums.RDFOntologyInferenceType.Reasoner)
        /// </summary>
        public RDFOntologyClassModel ClearInferences() {
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

}