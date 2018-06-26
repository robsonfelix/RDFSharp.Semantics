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
    /// RDFOntologyClassModelExtensions contains utility methods for enhancing capabilities of ontology class models
    /// </summary>
    public static class RDFOntologyClassModelExtensions {

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

    }

}