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
using System.Collections.Generic;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFBASEHelper contains utility methods supporting RDFS/OWL-DL modeling and reasoning
    /// </summary>
    public static class RDFBASEHelper {

		#region ClassModel
	
        #region SubClassOf
        /// <summary>
        /// Checks if the given aClass is subClass of the given bClass within the given class model
        /// </summary>
        public static Boolean IsSubClassOf(this RDFOntologyClassModel classModel, RDFOntologyClass aClass, RDFOntologyClass bClass) {
            return (aClass      != null && bClass != null && classModel != null ? classModel.EnlistSuperClassesOf(aClass).Classes.ContainsKey(bClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the subClasses of the given class within the given class model
        /// </summary>
        public static RDFOntologyClassModel EnlistSubClassesOf(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result           = new RDFOntologyClassModel();
            if (ontClass        != null && classModel != null) {

                //Step 1: Reason on the given class
                result           = classModel.EnlistSubClassesOfInternal(ontClass);

                //Step 2: Reason on the equivalent classes
                foreach (var ec in classModel.EnlistEquivalentClassesOf(ontClass)) {
                    result       = result.UnionWith(classModel.EnlistSubClassesOfInternal(ec));
                }

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "rdfs:subClassOf" taxonomy to discover direct and indirect subClasses of the given class
        /// </summary>
        internal static RDFOntologyClassModel EnlistSubClassesOfInternalVisitor(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result           = new RDFOntologyClassModel();

            // Transitivity of "rdfs:subClassOf" taxonomy: ((A SUBCLASSOF B)  &&  (B SUBCLASSOF C))  =>  (A SUBCLASSOF C)
            foreach (var sc     in classModel.Relations.SubClassOf.SelectEntriesByObject(ontClass)) {
                result.AddClass((RDFOntologyClass)sc.TaxonomySubject);
                result           = result.UnionWith(classModel.EnlistSubClassesOfInternalVisitor((RDFOntologyClass)sc.TaxonomySubject));
            }

            return result;
        }
        internal static RDFOntologyClassModel EnlistSubClassesOfInternal(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result1          = new RDFOntologyClassModel();
            var result2          = new RDFOntologyClassModel();

            // Step 1: Direct subsumption of "rdfs:subClassOf" taxonomy
            result1              = classModel.EnlistSubClassesOfInternalVisitor(ontClass);

            // Step 2: Enlist equivalent classes of subclasses
            result2              = result2.UnionWith(result1);
            foreach (var sc     in result1) {
                result2          = result2.UnionWith(classModel.EnlistEquivalentClassesOf(sc)
                                                               .UnionWith(classModel.EnlistSubClassesOf(sc)));
            }

            return result2;
        }
        #endregion

        #region SuperClassOf
        /// <summary>
        /// Checks if the given aClass is superClass of the given bClass within the given class model
        /// </summary>
        public static Boolean IsSuperClassOf(this RDFOntologyClassModel classModel, RDFOntologyClass aClass, RDFOntologyClass bClass) {
            return (aClass      != null && bClass != null && classModel != null ? classModel.EnlistSubClassesOf(aClass).Classes.ContainsKey(bClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the superClasses of the given class within the given class model
        /// </summary>
        public static RDFOntologyClassModel EnlistSuperClassesOf(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result           = new RDFOntologyClassModel();
            if (ontClass        != null && classModel != null) {

                //Step 1: Reason on the given class
                result           = classModel.EnlistSuperClassesOfInternal(ontClass);

                //Step 2: Reason on the equivalent classes
                foreach (var ec in classModel.EnlistEquivalentClassesOf(ontClass)) {
                    result       = result.UnionWith(classModel.EnlistSuperClassesOfInternal(ec));
                }

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "rdfs:subClassOf" taxonomy to discover direct and indirect superClasses of the given class
        /// </summary>
        internal static RDFOntologyClassModel EnlistSuperClassesOfInternalVisitor(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result           = new RDFOntologyClassModel();

            // Transitivity of "rdfs:subClassOf" taxonomy: ((A SUPERCLASSOF B)  &&  (B SUPERCLASSOF C))  =>  (A SUPERCLASSOF C)
            foreach (var sc     in classModel.Relations.SubClassOf.SelectEntriesBySubject(ontClass)) {
                result.AddClass((RDFOntologyClass)sc.TaxonomyObject);
                result           = result.UnionWith(classModel.EnlistSuperClassesOfInternalVisitor((RDFOntologyClass)sc.TaxonomyObject));
            }

            return result;
        }
        internal static RDFOntologyClassModel EnlistSuperClassesOfInternal(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result1          = new RDFOntologyClassModel();
            var result2          = new RDFOntologyClassModel();

            // Step 1: Direct subsumption of "rdfs:subClassOf" taxonomy
            result1              = classModel.EnlistSuperClassesOfInternalVisitor(ontClass);

            // Step 2: Enlist equivalent classes of superclasses
            result2              = result2.UnionWith(result1);
            foreach (var sc     in result1) {
                result2          = result2.UnionWith(classModel.EnlistEquivalentClassesOf(sc)
                                                               .UnionWith(classModel.EnlistSuperClassesOf(sc)));
            }

            return result2;
        }
        #endregion

        #region EquivalentClass
        /// <summary>
        /// Checks if the given aClass is equivalentClass of the given bClass within the given class model
        /// </summary>
        public static Boolean IsEquivalentClassOf(this RDFOntologyClassModel classModel, RDFOntologyClass aClass, RDFOntologyClass bClass) {
            return (aClass != null && bClass != null && classModel != null ? classModel.EnlistEquivalentClassesOf(aClass).Classes.ContainsKey(bClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the equivalentClasses of the given class within the given class model
        /// </summary>
        public static RDFOntologyClassModel EnlistEquivalentClassesOf(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result      = new RDFOntologyClassModel();
            if (ontClass   != null && classModel != null) {
                result      = classModel.EnlistEquivalentClassesOfInternal(ontClass, null)
                                        .RemoveClass(ontClass); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "owl:equivalentClass" taxonomy to discover direct and indirect equivalentClasses of the given class
        /// </summary>
        internal static RDFOntologyClassModel EnlistEquivalentClassesOfInternal(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass, Dictionary<Int64, RDFOntologyClass> visitContext) {
            var result        = new RDFOntologyClassModel();

            #region visitContext
            if (visitContext == null) {
                visitContext  = new Dictionary<Int64, RDFOntologyClass>() { { ontClass.PatternMemberID, ontClass } };
            }
            else {
                if (!visitContext.ContainsKey(ontClass.PatternMemberID)) {
                     visitContext.Add(ontClass.PatternMemberID, ontClass);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "owl:equivalentClass" taxonomy: ((A EQUIVALENTCLASSOF B)  &&  (B EQUIVALENTCLASS C))  =>  (A EQUIVALENTCLASS C)
            foreach (var  ec in classModel.Relations.EquivalentClass.SelectEntriesBySubject(ontClass)) {
                result.AddClass((RDFOntologyClass)ec.TaxonomyObject);
                result        = result.UnionWith(classModel.EnlistEquivalentClassesOfInternal((RDFOntologyClass)ec.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region DisjointWith
        /// <summary>
        /// Checks if the given aClass is disjointClass with the given bClass within the given class model
        /// </summary>
        public static Boolean IsDisjointClassWith(this RDFOntologyClassModel classModel, RDFOntologyClass aClass, RDFOntologyClass bClass) {
            return (aClass != null && bClass != null && classModel != null ? classModel.EnlistDisjointClassesWith(aClass).Classes.ContainsKey(bClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the disjointClasses with the given class within the given class model
        /// </summary>
        public static RDFOntologyClassModel EnlistDisjointClassesWith(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result        = new RDFOntologyClassModel();
            if (ontClass     != null && classModel != null) {
                result        = classModel.EnlistDisjointClassesWithInternal(ontClass, null)
                                          .RemoveClass(ontClass); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "owl:disjointWith" taxonomy to discover direct and indirect disjointClasses of the given class
        /// </summary>
        internal static RDFOntologyClassModel EnlistDisjointClassesWithInternal(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass, Dictionary<Int64, RDFOntologyClass> visitContext) {
            var result1       = new RDFOntologyClassModel();
            var result2       = new RDFOntologyClassModel();

            #region visitContext
            if (visitContext == null) {
                visitContext  = new Dictionary<Int64, RDFOntologyClass>() { { ontClass.PatternMemberID, ontClass } };
            }
            else {
                if (!visitContext.ContainsKey(ontClass.PatternMemberID)) {
                     visitContext.Add(ontClass.PatternMemberID, ontClass);
                }
                else {
                     return result1;
                }
            }
            #endregion

            // Inference: ((A DISJOINTWITH B)   &&  (B EQUIVALENTCLASS C))  =>  (A DISJOINTWITH C)
            foreach (var  dw in classModel.Relations.DisjointWith.SelectEntriesBySubject(ontClass)) {
                result1.AddClass((RDFOntologyClass)dw.TaxonomyObject);
                result1       = result1.UnionWith(classModel.EnlistEquivalentClassesOfInternal((RDFOntologyClass)dw.TaxonomyObject, visitContext));
            }

            // Inference: ((A DISJOINTWITH B)   &&  (B SUPERCLASS C))  =>  (A DISJOINTWITH C)
            result2           = result2.UnionWith(result1);
            foreach (var   c in result1) {
                result2       = result2.UnionWith(classModel.EnlistSubClassesOfInternal(c));
            }
            result1           = result1.UnionWith(result2);

            // Inference: ((A EQUIVALENTCLASS B || A SUBCLASSOF B)  &&  (B DISJOINTWITH C))     =>  (A DISJOINTWITH C)
            var compatibleCls = classModel.EnlistSuperClassesOf(ontClass)
                                          .UnionWith(classModel.EnlistEquivalentClassesOf(ontClass));
            foreach (var  ec in compatibleCls) {
                result1       = result1.UnionWith(classModel.EnlistDisjointClassesWithInternal(ec, visitContext));
            }

            return result1;
        }
        #endregion

        #region Domain
        /// <summary>
        /// Checks if the given ontology class is domain of the given ontology property within the given ontology class model
        /// </summary>
        public static Boolean IsDomainClassOf(this RDFOntologyClassModel classModel, RDFOntologyClass domainClass, RDFOntologyProperty ontProperty) {
            return (domainClass        != null && ontProperty != null && classModel != null ? classModel.EnlistDomainClassesOf(ontProperty).Classes.ContainsKey(domainClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the domain classes of the given property within the given ontology class model
        /// </summary>
        public static RDFOntologyClassModel EnlistDomainClassesOf(this RDFOntologyClassModel classModel, RDFOntologyProperty ontProperty) {
            var result                  = new RDFOntologyClassModel();
            if (ontProperty            != null && classModel != null) {
                if (ontProperty.Domain != null) {
                    result              = classModel.EnlistSubClassesOf(ontProperty.Domain)
                                                    .UnionWith(classModel.EnlistEquivalentClassesOf(ontProperty.Domain))
                                                    .AddClass(ontProperty.Domain);
                }
            }
            return result;
        }
        #endregion

        #region Range
        /// <summary>
        /// Checks if the given ontology class is range of the given ontology property within the given ontology class model
        /// </summary>
        public static Boolean IsRangeClassOf(this RDFOntologyClassModel classModel, RDFOntologyClass rangeClass, RDFOntologyProperty ontProperty) {
            return (rangeClass        != null && ontProperty != null && classModel != null ? classModel.EnlistRangeClassesOf(ontProperty).Classes.ContainsKey(rangeClass.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the range classes of the given property within the given ontology class model
        /// </summary>
        public static RDFOntologyClassModel EnlistRangeClassesOf(this RDFOntologyClassModel classModel, RDFOntologyProperty ontProperty) {
            var result                 = new RDFOntologyClassModel();
            if (ontProperty           != null && classModel != null) {
                if (ontProperty.Range != null) {
                    result             = classModel.EnlistSubClassesOf(ontProperty.Range)
                                                   .UnionWith(classModel.EnlistEquivalentClassesOf(ontProperty.Range))
                                                   .AddClass(ontProperty.Range);
                }
            }
            return result;
        }
        #endregion

        #region Literal
        /// <summary>
        /// Checks if the given ontology class is compatible with 'rdfs:Literal' within the given class model
        /// </summary>
        public static Boolean IsLiteralCompatibleClass(this RDFOntologyClassModel classModel, RDFOntologyClass ontClass) {
            var result    = false;
            if (ontClass != null && classModel != null) {
                result    = (ontClass.IsDataRangeClass()
                                || ontClass.Equals(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass())
                                    || classModel.IsSubClassOf(ontClass, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            }
            return result;
        }
        #endregion

		#endregion
		
		#region PropertyModel
		
		#region SubPropertyOf
        /// <summary>
        /// Checks if the given aProperty is subProperty of the given bProperty within the given property model
        /// </summary>
        public static Boolean IsSubPropertyOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty aProperty, RDFOntologyProperty bProperty) {
            return (aProperty != null && bProperty != null && propertyModel != null ? propertyModel.EnlistSuperPropertiesOf(aProperty).Properties.ContainsKey(bProperty.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the sub properties of the given property within the given property model
        /// </summary>
        public static RDFOntologyPropertyModel EnlistSubPropertiesOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();
            if (ontProperty   != null && propertyModel != null) {

                //Step 1: Reason on the given property
                result         = propertyModel.EnlistSubPropertiesOfInternal(ontProperty);

                //Step 2: Reason on the equivalent properties
                foreach (var  ep in propertyModel.EnlistEquivalentPropertiesOf(ontProperty)) {
                    result     = result.UnionWith(propertyModel.EnlistSubPropertiesOfInternal(ep));
                }

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "rdfs:subPropertyOf" taxonomy to discover direct and indirect subProperties of the given property
        /// </summary>
        internal static RDFOntologyPropertyModel EnlistSubPropertiesOfInternalVisitor(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();

            // Transitivity of "rdfs:subPropertyOf" taxonomy: ((A SUBPROPERTYOF B)  &&  (B SUBPROPERTYOF C))  =>  (A SUBPROPERTYOF C)
            foreach (var   sp in propertyModel.Relations.SubPropertyOf.SelectEntriesByObject(ontProperty)) {
                result.AddProperty((RDFOntologyProperty)sp.TaxonomySubject);
                result         = result.UnionWith(propertyModel.EnlistSubPropertiesOfInternalVisitor((RDFOntologyProperty)sp.TaxonomySubject));
            }

            return result;
        }
        internal static RDFOntologyPropertyModel EnlistSubPropertiesOfInternal(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result1        = new RDFOntologyPropertyModel();
            var result2        = new RDFOntologyPropertyModel();

            // Step 1: Direct subsumption of "rdfs:subPropertyOf" taxonomy
            result1            = propertyModel.EnlistSubPropertiesOfInternalVisitor(ontProperty);

            // Step 2: Enlist equivalent properties of subproperties
            result2            = result2.UnionWith(result1);
            foreach (var   sp in result1) {
                result2        = result2.UnionWith(propertyModel.EnlistEquivalentPropertiesOf(sp)
                                                                .UnionWith(propertyModel.EnlistSubPropertiesOf(sp)));
            }

            return result2;
        }
        #endregion

        #region SuperPropertyOf
        /// <summary>
        /// Checks if the given aProperty is superProperty of the given bProperty within the given property model
        /// </summary>
        public static Boolean IsSuperPropertyOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty aProperty, RDFOntologyProperty bProperty) {
            return (aProperty != null && bProperty != null && propertyModel != null ? propertyModel.EnlistSubPropertiesOf(aProperty).Properties.ContainsKey(bProperty.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the super properties of the given property within the given property model
        /// </summary>
        public static RDFOntologyPropertyModel EnlistSuperPropertiesOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();
            if (ontProperty   != null && propertyModel != null) {

                //Step 1: Reason on the given property
                result         = propertyModel.EnlistSuperPropertiesOfInternal(ontProperty);

                //Step 2: Reason on the equivalent properties
                foreach (var  ep in propertyModel.EnlistEquivalentPropertiesOf(ontProperty)) {
                    result     = result.UnionWith(propertyModel.EnlistSuperPropertiesOfInternal(ep));
                }

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "rdfs:subPropertyOf" taxonomy to discover direct and indirect superProperties of the given property
        /// </summary>
        internal static RDFOntologyPropertyModel EnlistSuperPropertiesOfInternalVisitor(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();

            // Transitivity of "rdfs:subPropertyOf" taxonomy: ((A SUPERPROPERTYOF B)  &&  (B SUPERPROPERTYOF C))  =>  (A SUPERPROPERTYOF C)
            foreach (var   sp in propertyModel.Relations.SubPropertyOf.SelectEntriesBySubject(ontProperty)) {
                result.AddProperty((RDFOntologyProperty)sp.TaxonomyObject);
                result         = result.UnionWith(propertyModel.EnlistSuperPropertiesOfInternalVisitor((RDFOntologyProperty)sp.TaxonomyObject));
            }

            return result;
        }
        internal static RDFOntologyPropertyModel EnlistSuperPropertiesOfInternal(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result1        = new RDFOntologyPropertyModel();
            var result2        = new RDFOntologyPropertyModel();

            // Step 1: Direct subsumption of "rdfs:subPropertyOf" taxonomy
            result1            = propertyModel.EnlistSuperPropertiesOfInternalVisitor(ontProperty);

            // Step 2: Enlist equivalent properties of subproperties
            result2            = result2.UnionWith(result1);
            foreach (var sp in result1) {
                result2        = result2.UnionWith(propertyModel.EnlistEquivalentPropertiesOf(sp)
                                                                .UnionWith(propertyModel.EnlistSuperPropertiesOf(sp)));
            }

            return result2;
        }
        #endregion

        #region EquivalentProperty
        /// <summary>
        /// Checks if the given aProperty is equivalentProperty of the given bProperty within the given property model
        /// </summary>
        public static Boolean IsEquivalentPropertyOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty aProperty, RDFOntologyProperty bProperty) {
            return (aProperty != null && bProperty != null && propertyModel != null ? propertyModel.EnlistEquivalentPropertiesOf(aProperty).Properties.ContainsKey(bProperty.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the equivalentProperties of the given property within the given property model
        /// </summary>
        public static RDFOntologyPropertyModel EnlistEquivalentPropertiesOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();
            if (ontProperty   != null && propertyModel != null) {
                result         = propertyModel.EnlistEquivalentPropertiesOfInternal(ontProperty, null)
                                              .RemoveProperty(ontProperty); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "owl:equivalentProperty" taxonomy to discover direct and indirect equivalentProperties of the given property
        /// </summary>
        internal static RDFOntologyPropertyModel EnlistEquivalentPropertiesOfInternal(this RDFOntologyPropertyModel propertyModel, RDFOntologyProperty ontProperty, Dictionary<Int64, RDFOntologyProperty> visitContext) {
            var result         = new RDFOntologyPropertyModel();

            #region visitContext
            if (visitContext  == null) {
                visitContext   = new Dictionary<Int64, RDFOntologyProperty>() { { ontProperty.PatternMemberID, ontProperty } };
            }
            else {
                if (!visitContext.ContainsKey(ontProperty.PatternMemberID)) {
                     visitContext.Add(ontProperty.PatternMemberID, ontProperty);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "owl:equivalentProperty" taxonomy: ((A EQUIVALENTPROPERTY B)  &&  (B EQUIVALENTPROPERTY C))  =>  (A EQUIVALENTPROPERTY C)
            foreach (var  ep  in propertyModel.Relations.EquivalentProperty.SelectEntriesBySubject(ontProperty)) {
                result.AddProperty((RDFOntologyProperty)ep.TaxonomyObject);
                result         = result.UnionWith(propertyModel.EnlistEquivalentPropertiesOfInternal((RDFOntologyProperty)ep.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region InverseOf
        /// <summary>
        /// Checks if the given aProperty is inverse property of the given bProperty within the given property model
        /// </summary>
        public static Boolean IsInversePropertyOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyObjectProperty aProperty, RDFOntologyObjectProperty bProperty) {
            return (aProperty != null && bProperty != null && propertyModel != null ? propertyModel.EnlistInversePropertiesOf(aProperty).Properties.ContainsKey(bProperty.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the inverse properties of the given property within the given property model
        /// </summary>
        public static RDFOntologyPropertyModel EnlistInversePropertiesOf(this RDFOntologyPropertyModel propertyModel, RDFOntologyObjectProperty ontProperty) {
            var result         = new RDFOntologyPropertyModel();
            if (ontProperty   != null && propertyModel != null) {

                //Step 1: Reason on the given property
                //Subject-side inverseOf relation
                foreach (var invOf in propertyModel.Relations.InverseOf.SelectEntriesBySubject(ontProperty)) {
                    result.AddProperty((RDFOntologyObjectProperty)invOf.TaxonomyObject);
                }
                //Object-side inverseOf relation
                foreach (var invOf in propertyModel.Relations.InverseOf.SelectEntriesByObject(ontProperty))  {
                    result.AddProperty((RDFOntologyObjectProperty)invOf.TaxonomySubject);
                }
                result.RemoveProperty(ontProperty); //Safety deletion

            }
            return result;
        }
        #endregion
		
		#endregion
		
		#region Data
		
		#region SameAs
        /// <summary>
        /// Checks if the given aFact is sameAs the given bFact within the given data
        /// </summary>
        public static Boolean IsSameFactAs(this RDFOntologyData data, RDFOntologyFact aFact, RDFOntologyFact bFact) {
            return (aFact     != null && bFact != null && data != null ? data.EnlistSameFactsAs(aFact).Facts.ContainsKey(bFact.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the sameFacts of the given fact within the given data
        /// </summary>
        public static RDFOntologyData EnlistSameFactsAs(this RDFOntologyData data, RDFOntologyFact ontFact) {
            var result         = new RDFOntologyData();
            if (ontFact       != null && data != null) {
                result         = data.EnlistSameFactsAsInternal(ontFact, null)
                                     .RemoveFact(ontFact); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "owl:sameAs" taxonomy to discover direct and indirect samefacts of the given facts
        /// </summary>
        internal static RDFOntologyData EnlistSameFactsAsInternal(this RDFOntologyData data, RDFOntologyFact ontFact, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result         = new RDFOntologyData();

            #region visitContext
            if (visitContext  == null) {
                visitContext   = new Dictionary<Int64, RDFOntologyFact>() { { ontFact.PatternMemberID, ontFact } };
            }
            else {
                if (!visitContext.ContainsKey(ontFact.PatternMemberID)) {
                     visitContext.Add(ontFact.PatternMemberID, ontFact);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "owl:sameAs" taxonomy: ((A SAMEAS B)  &&  (B SAMEAS C))  =>  (A SAMEAS C)
            foreach (var   sf in data.Relations.SameAs.SelectEntriesBySubject(ontFact)) {
                result.AddFact((RDFOntologyFact)sf.TaxonomyObject);
                result         = result.UnionWith(data.EnlistSameFactsAsInternal((RDFOntologyFact)sf.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region DifferentFrom
        /// <summary>
        /// Checks if the given aFact is differentFrom the given bFact within the given data
        /// </summary>
        public static Boolean IsDifferentFactFrom(this RDFOntologyData data, RDFOntologyFact aFact, RDFOntologyFact bFact) {
            return (aFact      != null && bFact != null && data != null ? data.EnlistDifferentFactsFrom(aFact).Facts.ContainsKey(bFact.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the different facts of the given fact within the given data
        /// </summary>
        public static RDFOntologyData EnlistDifferentFactsFrom(this RDFOntologyData data, RDFOntologyFact ontFact) {
            var result          = new RDFOntologyData();
            if (ontFact        != null && data != null) {
                result          = data.EnlistDifferentFactsFromInternal(ontFact, null)
                                      .RemoveFact(ontFact); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "owl:differentFrom" taxonomy to discover direct and indirect differentFacts of the given facts
        /// </summary>
        internal static RDFOntologyData EnlistDifferentFactsFromInternal(this RDFOntologyData data, RDFOntologyFact ontFact, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result         = new RDFOntologyData();

            #region visitContext
            if (visitContext  == null) {
                visitContext  = new Dictionary<Int64, RDFOntologyFact>() { { ontFact.PatternMemberID, ontFact } };
            }
            else {
                if (!visitContext.ContainsKey(ontFact.PatternMemberID)) {
                     visitContext.Add(ontFact.PatternMemberID, ontFact);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Inference: (A DIFFERENTFROM B  &&  B SAMEAS C         =>  A DIFFERENTFROM C)
            foreach (var   df in data.Relations.DifferentFrom.SelectEntriesBySubject(ontFact)) {
                result.AddFact((RDFOntologyFact)df.TaxonomyObject);
                result         = result.UnionWith(data.EnlistSameFactsAsInternal((RDFOntologyFact)df.TaxonomyObject, visitContext));
            }

            // Inference: (A SAMEAS B         &&  B DIFFERENTFROM C  =>  A DIFFERENTFROM C)
            foreach (var   sa in data.EnlistSameFactsAs(ontFact)) {
                result         = result.UnionWith(data.EnlistDifferentFactsFromInternal(sa, visitContext));
            }

            return result;
        }
        #endregion

        #region TransitiveProperty
        /// <summary>
        /// Checks if the given "aFact -> transProp" assertion links to the given bFact within the given data
        /// </summary>
        public static Boolean IsTransitiveAssertionOf(this RDFOntologyData data, RDFOntologyFact aFact, RDFOntologyObjectProperty transProp, RDFOntologyFact bFact) {
            return (aFact  != null && transProp != null && transProp.IsTransitiveProperty() && bFact != null && data != null ? data.EnlistTransitiveAssertionsOf(aFact, transProp).Facts.ContainsKey(bFact.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the given "aFact -> transOntProp" assertions within the given data
        /// </summary>
        public static RDFOntologyData EnlistTransitiveAssertionsOf(this RDFOntologyData data, RDFOntologyFact ontFact, RDFOntologyObjectProperty transOntProp) {
            var result     = new RDFOntologyData();
            if (ontFact   != null && transOntProp != null && transOntProp.IsTransitiveProperty() && data != null) {
                result       = data.EnlistTransitiveAssertionsOfInternal(ontFact, transOntProp, null);
            }
            return result;
        }

        /// <summary>
        /// Enlists the transitive assertions of the given fact and the given property within the given data
        /// </summary>
        internal static RDFOntologyData EnlistTransitiveAssertionsOfInternal(this RDFOntologyData data, RDFOntologyFact ontFact, RDFOntologyObjectProperty ontProp, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result        = new RDFOntologyData();

            #region visitContext
            if (visitContext == null) {
                visitContext  = new Dictionary<Int64, RDFOntologyFact>() { { ontFact.PatternMemberID, ontFact } };
            }
            else {
                if (!visitContext.ContainsKey(ontFact.PatternMemberID)) {
                     visitContext.Add(ontFact.PatternMemberID, ontFact);
                }
                else {
                     return result;
                }
            }
            #endregion

            // ((F1 P F2)    &&  (F2 P F3))  =>  (F1 P F3)
            foreach (var  ta in data.Relations.Assertions.SelectEntriesBySubject(ontFact)
                                                         .SelectEntriesByPredicate(ontProp)) {
                result.AddFact((RDFOntologyFact)ta.TaxonomyObject);
                result        = result.UnionWith(data.EnlistTransitiveAssertionsOfInternal((RDFOntologyFact)ta.TaxonomyObject, ontProp, visitContext));
            }

            return result;
        }
        #endregion

        #region EnlistMembers
        /// <summary>
        /// Checks if the given fact is member of the given class within the given ontology
        /// </summary>
        public static Boolean IsMemberOf(this RDFOntology ontology, RDFOntologyFact ontFact, RDFOntologyClass ontClass) {
            return (ontFact != null && ontClass != null && ontology != null ? ontology.EnlistMembersOf(ontClass).Facts.ContainsKey(ontFact.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the facts which are members of the given class within the given ontology
        /// </summary>
        public static RDFOntologyData EnlistMembersOf(this RDFOntology ontology, RDFOntologyClass ontClass) {
            var result       = new RDFOntologyData();
            if (ontClass    != null && ontology != null) {

                //Merge BASE ontology
                ontology     = ontology.UnionWith(RDFBASEOntology.Instance);

                //DataRange/Literal-Compatible
                if (ontology.Model.ClassModel.IsLiteralCompatibleClass(ontClass)) {
                    result   = ontology.EnlistMembersOfLiteralCompatibleClass(ontClass);
                }

                //Restriction/Composite/Enumerate/Class
                else {
                    result   = ontology.EnlistMembersOfNonLiteralCompatibleClass(ontClass);
                }

                //Unmerge BASE ontology
                ontology     = ontology.DifferenceWith(RDFBASEOntology.Instance);

            }
            return result;
        }

        /// <summary>
        /// Enlists the facts which are members of the given class within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfClass(this RDFOntology ontology, RDFOntologyClass ontClass) {
            var result           = new RDFOntologyData();

            //Get the compatible classes
            var compCls          = ontology.Model.ClassModel.EnlistSubClassesOf(ontClass)
                                                            .UnionWith(ontology.Model.ClassModel.EnlistEquivalentClassesOf(ontClass))
                                                            .AddClass(ontClass);

            //Filter "classType" relations made with compatible classes
            var fTaxonomy        = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            foreach (var c      in compCls) {
                fTaxonomy        = fTaxonomy.UnionWith(ontology.Data.Relations.ClassType.SelectEntriesByObject(c));
            }
            foreach (var tEntry in fTaxonomy) {

                //Add the fact and its synonyms
                if (tEntry.TaxonomySubject.IsFact()) {
                    result       = result.UnionWith(ontology.Data.EnlistSameFactsAs((RDFOntologyFact)tEntry.TaxonomySubject))
                                         .AddFact((RDFOntologyFact)tEntry.TaxonomySubject);
                }

            }

            return result;
        }

        /// <summary>
        /// Enlists the facts which are members of the given composition within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfComposite(this RDFOntology ontology, RDFOntologyClass ontCompClass) {
            var result               = new RDFOntologyData();

            #region Intersection
            if (ontCompClass        is RDFOntologyIntersectionClass) {

                //Filter "intersectionOf" relations made with the given intersection class
                var firstIter        = true;
                var iTaxonomy        = ontology.Model.ClassModel.Relations.IntersectionOf.SelectEntriesBySubject(ontCompClass);
                foreach (var tEntry in iTaxonomy) {
                    if (firstIter)   {
                        result       = ontology.EnlistMembersOf((RDFOntologyClass)tEntry.TaxonomyObject);
                        firstIter    = false;
                    }
                    else {
                        result       = result.IntersectWith(ontology.EnlistMembersOf((RDFOntologyClass)tEntry.TaxonomyObject));
                    }
                }

            }
            #endregion

            #region Union
            else if (ontCompClass   is RDFOntologyUnionClass) {

                //Filter "unionOf" relations made with the given union class
                var uTaxonomy        = ontology.Model.ClassModel.Relations.UnionOf.SelectEntriesBySubject(ontCompClass);
                foreach (var tEntry in uTaxonomy) {
                    result           = result.UnionWith(ontology.EnlistMembersOf((RDFOntologyClass)tEntry.TaxonomyObject));
                }

            }
            #endregion

            #region Complement
            else if (ontCompClass   is RDFOntologyComplementClass) {
                result               = ontology.Data.DifferenceWith(ontology.EnlistMembersOf(((RDFOntologyComplementClass)ontCompClass).ComplementOf));
            }
            #endregion

            return result;
        }

        /// <summary>
        /// Enlists the facts which are members of the given enumeration within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfEnumerate(this RDFOntology ontology, RDFOntologyEnumerateClass ontEnumClass) {
            var result           = new RDFOntologyData();

            //Filter "oneOf" relations made with the given enumerate class
            var enTaxonomy       = ontology.Model.ClassModel.Relations.OneOf.SelectEntriesBySubject(ontEnumClass);
            foreach (var tEntry in enTaxonomy) {

                //Add the fact and its synonyms
                if (tEntry.TaxonomySubject.IsEnumerateClass() && tEntry.TaxonomyObject.IsFact()) {
                    result       = result.UnionWith(ontology.Data.EnlistSameFactsAs((RDFOntologyFact)tEntry.TaxonomyObject))
                                         .AddFact((RDFOntologyFact)tEntry.TaxonomyObject);
                }

            }

            return result;
        }

        /// <summary>
        /// Enlists the facts which are members of the given restriction within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfRestriction(this RDFOntology ontology, RDFOntologyRestriction ontRestriction) {
            var result          = new RDFOntologyData();

            //Enlist the properties which are compatible with the restriction's "OnProperty"
            var compProps       = ontology.Model.PropertyModel.EnlistSubPropertiesOf(ontRestriction.OnProperty)
                                                              .UnionWith(ontology.Model.PropertyModel.EnlistEquivalentPropertiesOf(ontRestriction.OnProperty))
                                                              .AddProperty(ontRestriction.OnProperty);

            //Filter assertions made with enlisted compatible properties
            var fTaxonomy       = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Data);
            foreach (var p     in compProps) {
                fTaxonomy       = fTaxonomy.UnionWith(ontology.Data.Relations.Assertions.SelectEntriesByPredicate(p));
            }

            #region Cardinality
            if (ontRestriction is RDFOntologyCardinalityRestriction) {

                //Item2 is a counter for occurrences of the restricted property within the subject fact
                var fCount      = new Dictionary<Int64, Tuple<RDFOntologyFact, Int64>>();

                //Iterate the compatible assertions
                foreach (var tEntry in fTaxonomy) {
                    if (!fCount.ContainsKey(tEntry.TaxonomySubject.PatternMemberID)) {
                         fCount.Add(tEntry.TaxonomySubject.PatternMemberID, new Tuple<RDFOntologyFact, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, 1));
                    }
                    else {
                         var occurrencyCounter = fCount[tEntry.TaxonomySubject.PatternMemberID].Item2;
                         fCount[tEntry.TaxonomySubject.PatternMemberID] = new Tuple<RDFOntologyFact, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, occurrencyCounter + 1);
                    }
                }

                //Apply the cardinality restriction on the tracked facts
                var fCountEnum  = fCount.Values.GetEnumerator();
                while (fCountEnum.MoveNext())    {
                    var passesMinCardinality     = true;
                    var passesMaxCardinality     = true;

                    //MinCardinality: signal tracked facts having "#occurrences < MinCardinality"
                    if (((RDFOntologyCardinalityRestriction)ontRestriction).MinCardinality > 0) {
                        if (fCountEnum.Current.Item2 < ((RDFOntologyCardinalityRestriction)ontRestriction).MinCardinality) {
                            passesMinCardinality = false;
                        }
                    }

                    //MaxCardinality: signal tracked facts having "#occurrences > MaxCardinality"
                    if (((RDFOntologyCardinalityRestriction)ontRestriction).MaxCardinality > 0) {
                        if (fCountEnum.Current.Item2 > ((RDFOntologyCardinalityRestriction)ontRestriction).MaxCardinality) {
                            passesMaxCardinality = false;
                        }
                    }

                    //Save the candidate fact if it passes cardinality restrictions
                    if (passesMinCardinality    && passesMaxCardinality) {
                        result.AddFact(fCountEnum.Current.Item1);
                    }
                }

            }
            #endregion

            #region AllValuesFrom
            else if (ontRestriction is RDFOntologyAllValuesFromRestriction) {

                //Item2 is a counter for occurrences of the restricted property with a range member of the restricted "FromClass"
                //Item3 is a counter for occurrences of the restricted property with a range member not of the restricted "FromClass"
                var fCount      = new Dictionary<Int64, Tuple<RDFOntologyFact, Int64, Int64>>();

                //Enlist the classes which are compatible with the restricted "FromClass"
                var compClasses = ontology.Model.ClassModel.EnlistSubClassesOf(((RDFOntologyAllValuesFromRestriction)ontRestriction).FromClass)
                                                           .UnionWith(ontology.Model.ClassModel.EnlistEquivalentClassesOf(((RDFOntologyAllValuesFromRestriction)ontRestriction).FromClass))
                                                           .AddClass(((RDFOntologyAllValuesFromRestriction)ontRestriction).FromClass);

                //Iterate the compatible assertions
                foreach (var tEntry in fTaxonomy) {

                    //Initialize the occurrence counters of the subject fact
                    if (!fCount.ContainsKey(tEntry.TaxonomySubject.PatternMemberID)) {
                        fCount.Add(tEntry.TaxonomySubject.PatternMemberID, new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, 0, 0));
                    }

                    //Iterate the class types of the object fact, checking presence of the restricted "FromClass"
                    var fromClassFound             = false;
                    var objFactClassTypes          = ontology.Data.Relations.ClassType.SelectEntriesBySubject(tEntry.TaxonomyObject);
                    foreach (var objFactClassType in objFactClassTypes) {
                        var compObjFactClassTypes  = ontology.Model.ClassModel.EnlistSubClassesOf((RDFOntologyClass)objFactClassType.TaxonomyObject)
                                                                              .UnionWith(ontology.Model.ClassModel.EnlistEquivalentClassesOf((RDFOntologyClass)objFactClassType.TaxonomyObject))
                                                                              .AddClass((RDFOntologyClass)objFactClassType.TaxonomyObject);
                        if (compObjFactClassTypes.IntersectWith(compClasses).ClassesCount > 0) {
                            fromClassFound         = true;
                            break;
                        }
                    }

                    //Update the occurrence counters of the subject fact
                    var equalityCounter            = fCount[tEntry.TaxonomySubject.PatternMemberID].Item2;
                    var differenceCounter          = fCount[tEntry.TaxonomySubject.PatternMemberID].Item3;
                    if (fromClassFound) {
                        fCount[tEntry.TaxonomySubject.PatternMemberID] = new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, equalityCounter + 1, differenceCounter);
                    }
                    else {
                        fCount[tEntry.TaxonomySubject.PatternMemberID] = new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, equalityCounter, differenceCounter + 1);
                    }

                }

                //Apply the restriction on the subject facts
                var fCountEnum                     = fCount.Values.GetEnumerator();
                while  (fCountEnum.MoveNext())     {
                    if (fCountEnum.Current.Item2  >= 1 && fCountEnum.Current.Item3 == 0) {
                        result.AddFact(fCountEnum.Current.Item1);
                    }
                }

            }
            #endregion

            #region SomeValuesFrom
            else if (ontRestriction is RDFOntologySomeValuesFromRestriction) {

                //Item2 is a counter for occurrences of the restricted property with a range member of the restricted "FromClass"
                //Item3 is a counter for occurrences of the restricted property with a range member not of the restricted "FromClass"
                var fCount           = new Dictionary<Int64, Tuple<RDFOntologyFact, Int64, Int64>>();

                //Enlist the classes which are compatible with the restricted "FromClass"
                var compClasses      = ontology.Model.ClassModel.EnlistSubClassesOf(((RDFOntologySomeValuesFromRestriction)ontRestriction).FromClass)
                                                                .UnionWith(ontology.Model.ClassModel.EnlistEquivalentClassesOf(((RDFOntologySomeValuesFromRestriction)ontRestriction).FromClass))
                                                                .AddClass(((RDFOntologySomeValuesFromRestriction)ontRestriction).FromClass);

                //Iterate the compatible assertions
                foreach (var tEntry in fTaxonomy) {

                    //Initialize the occurrence counters of the subject fact
                    if (!fCount.ContainsKey(tEntry.TaxonomySubject.PatternMemberID)) {
                        fCount.Add(tEntry.TaxonomySubject.PatternMemberID, new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, 0, 0));
                    }

                    //Iterate the class types of the object fact, checking presence of the restricted "FromClass"
                    var fromClassFound             = false;
                    var objFactClassTypes          = ontology.Data.Relations.ClassType.SelectEntriesBySubject(tEntry.TaxonomyObject);
                    foreach (var objFactClassType in objFactClassTypes) {
                        var compObjFactClassTypes  = ontology.Model.ClassModel.EnlistSubClassesOf((RDFOntologyClass)objFactClassType.TaxonomyObject)
                                                                              .UnionWith(ontology.Model.ClassModel.EnlistEquivalentClassesOf((RDFOntologyClass)objFactClassType.TaxonomyObject))
                                                                              .AddClass((RDFOntologyClass)objFactClassType.TaxonomyObject);
                        if (compObjFactClassTypes.IntersectWith(compClasses).ClassesCount > 0) {
                            fromClassFound         = true;
                            break;
                        }
                    }

                    //Update the occurrence counters of the subject fact
                    var equalityCounter            = fCount[tEntry.TaxonomySubject.PatternMemberID].Item2;
                    var differenceCounter          = fCount[tEntry.TaxonomySubject.PatternMemberID].Item3;
                    if (fromClassFound) {
                        fCount[tEntry.TaxonomySubject.PatternMemberID] = new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, equalityCounter + 1, differenceCounter);
                    }
                    else {
                        fCount[tEntry.TaxonomySubject.PatternMemberID] = new Tuple<RDFOntologyFact, Int64, Int64>((RDFOntologyFact)tEntry.TaxonomySubject, equalityCounter, differenceCounter + 1);
                    }

                }

                //Apply the restriction on the subject facts
                var fCountEnum                     = fCount.Values.GetEnumerator();
                while  (fCountEnum.MoveNext())     {
                    if (fCountEnum.Current.Item2  >= 1) {
                        result.AddFact(fCountEnum.Current.Item1);
                    }
                }

            }
            #endregion

            #region HasValue
            else if (ontRestriction     is RDFOntologyHasValueRestriction) {
                if (((RDFOntologyHasValueRestriction)ontRestriction).RequiredValue.IsFact()) {

                    //Enlist the same facts of the restriction's "RequiredValue"
                    var compFacts        = ontology.Data.EnlistSameFactsAs((RDFOntologyFact)((RDFOntologyHasValueRestriction)ontRestriction).RequiredValue)
                                                        .AddFact((RDFOntologyFact)((RDFOntologyHasValueRestriction)ontRestriction).RequiredValue);

                    //Iterate the compatible assertions
                    foreach (var tEntry in fTaxonomy) {
                        if (tEntry.TaxonomyObject.IsFact()) {
                            if (compFacts.SelectFact(tEntry.TaxonomyObject.ToString()) != null) {
                                result.AddFact((RDFOntologyFact)tEntry.TaxonomySubject);
                            }
                        }
                    }

                }
                else if (((RDFOntologyHasValueRestriction)ontRestriction).RequiredValue.IsLiteral()) {

                    //Iterate the compatible assertions and track the occurrence informations
                    foreach (var tEntry in fTaxonomy) {
                        if (tEntry.TaxonomyObject.IsLiteral()) {
                            try {
                                var semanticLiteralsCompare  = RDFQueryUtilities.CompareRDFPatternMembers(((RDFOntologyHasValueRestriction)ontRestriction).RequiredValue.Value, tEntry.TaxonomyObject.Value);
                                if (semanticLiteralsCompare == 0) {
                                    result.AddFact((RDFOntologyFact)tEntry.TaxonomySubject);
                                }
                            }
                            finally { }
                        }
                    }

                }
            }
            #endregion

            return result;
        }

        /// <summary>
        /// Enlists the literals which are members of the given literal-compatible class within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfLiteralCompatibleClass(this RDFOntology ontology, RDFOntologyClass ontClass) {
            var result         = new RDFOntologyData();

            #region DataRange
            if (ontClass.IsDataRangeClass()) {

                //Filter "oneOf" relations made with the given datarange class
                var drTaxonomy = ontology.Model.ClassModel.Relations.OneOf.SelectEntriesBySubject(ontClass);
                foreach (var tEntry in drTaxonomy) {

                    //Add the literal
                    if (tEntry.TaxonomySubject.IsDataRangeClass() && tEntry.TaxonomyObject.IsLiteral()) {
                        result.AddLiteral((RDFOntologyLiteral)tEntry.TaxonomyObject);
                    }

                }

            }
            #endregion

            #region Literal
            //Asking for "rdfs:Literal" is the only way to get enlistment of plain literals, since they have really no semantic
            else if (ontClass.Equals(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass())) {
                foreach (var ontLit in ontology.Data.Literals.Values) {
                    result.AddLiteral(ontLit);
                }
            }
            #endregion

            #region SubLiteral
            else {
                foreach (var ontLit in ontology.Data.Literals.Values.Where(l => l.Value is RDFTypedLiteral)) {
                    var dTypeClass   = ontology.Model.ClassModel.SelectClass(RDFModelUtilities.GetDatatypeFromEnum(((RDFTypedLiteral)ontLit.Value).Datatype));
                    if (dTypeClass  != null) {
                        if (dTypeClass.Equals(ontClass)
                                || ontology.Model.ClassModel.IsSubClassOf(dTypeClass, ontClass)
                                    || ontology.Model.ClassModel.IsEquivalentClassOf(dTypeClass, ontClass)) {
                            result.AddLiteral(ontLit);
                        }
                    }
                }
            }
            #endregion

            return result;
        }

        /// <summary>
        /// Enlists the facts which are members of the given non literal-compatible class within the given ontology
        /// </summary>
        internal static RDFOntologyData EnlistMembersOfNonLiteralCompatibleClass(this RDFOntology ontology, RDFOntologyClass ontClass) {
            var result     = new RDFOntologyData();
            if (ontClass  != null && ontology != null) {

                //Restriction
                if (ontClass.IsRestrictionClass()) {
                    result = ontology.EnlistMembersOfRestriction((RDFOntologyRestriction)ontClass);
                }

                //Composite
                else if (ontClass.IsCompositeClass()) {
                    result = ontology.EnlistMembersOfComposite(ontClass);
                }

                //Enumerate
                else if (ontClass.IsEnumerateClass()) {
                    result = ontology.EnlistMembersOfEnumerate((RDFOntologyEnumerateClass)ontClass);
                }

                //Class
                else {
                    result = ontology.EnlistMembersOfClass(ontClass);
                }

            }
            return result;
        }
        #endregion
		
		#endregion
		
    }

}