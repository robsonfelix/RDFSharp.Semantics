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

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyTaxonomyChecker is responsible for implicit validation of ontologies during modeling
    /// </summary>
    internal static class RDFOntologyTaxonomyChecker {

        #region ClassModel
        /// <summary>
        /// Checks if the given class is a reserved BASE ontology class
        /// </summary>
        internal static Boolean CheckReservedClass(RDFOntologyClass ontClass) {
            return (RDFBASEOntology.Instance.Model.ClassModel.Classes.ContainsKey(ontClass.PatternMemberID));
        } 

        /// <summary>
        /// Checks if the given childclass can be set subclassof the given motherclass
        /// </summary>
        internal static Boolean CheckSubClassOfCompatibility(RDFOntologyClassModel classModel, 
                                                             RDFOntologyClass childClass,
                                                             RDFOntologyClass motherClass) {
            return (!classModel.IsSubClassOf(motherClass, childClass)
                        && !classModel.IsEquivalentClassOf(motherClass, childClass) 
                            && !classModel.IsDisjointClassWith(motherClass, childClass));
        }

        /// <summary>
        /// Checks if the given aclass can be set equivalentclassof the given bclass
        /// </summary>
        internal static Boolean CheckEquivalentClassCompatibility(RDFOntologyClassModel classModel,
                                                                  RDFOntologyClass aClass,
                                                                  RDFOntologyClass bClass) {
            return (!classModel.IsSubClassOf(aClass, bClass)
                        && !classModel.IsSuperClassOf(aClass, bClass)
                            && !classModel.IsDisjointClassWith(aClass, bClass));
        }

        /// <summary>
        /// Checks if the given aclass can be set disjointwith the given bclass
        /// </summary>
        internal static Boolean CheckDisjointWithCompatibility(RDFOntologyClassModel classModel,
                                                               RDFOntologyClass aClass,
                                                               RDFOntologyClass bClass) {
            return (!classModel.IsSubClassOf(aClass, bClass)
                        && !classModel.IsSuperClassOf(aClass, bClass)
                            && !classModel.IsEquivalentClassOf(aClass, bClass));
        }
        #endregion

        #region PropertyModel
        /// <summary>
        /// Checks if the given property is a reserved BASE ontology property
        /// </summary>
        internal static Boolean CheckReservedProperty(RDFOntologyProperty ontProperty) {
            return (RDFBASEOntology.Instance.Model.PropertyModel.Properties.ContainsKey(ontProperty.PatternMemberID));
        }

        /// <summary>
        /// Checks if the given childproperty can be set subpropertyof the given motherproperty
        /// </summary>
        internal static Boolean CheckSubPropertyOfCompatibility(RDFOntologyPropertyModel propertyModel,
                                                                RDFOntologyObjectProperty childProperty,
                                                                RDFOntologyObjectProperty motherProperty) {
            return (!propertyModel.IsSubPropertyOf(motherProperty, childProperty)
                        && !propertyModel.IsEquivalentPropertyOf(motherProperty, childProperty));
        }

        /// <summary>
        /// Checks if the given childproperty can be set subpropertyof the given motherproperty
        /// </summary>
        internal static Boolean CheckSubPropertyOfCompatibility(RDFOntologyPropertyModel propertyModel,
                                                                RDFOntologyDatatypeProperty childProperty,
                                                                RDFOntologyDatatypeProperty motherProperty) {
            return (!propertyModel.IsSubPropertyOf(motherProperty, childProperty)
                        && !propertyModel.IsEquivalentPropertyOf(motherProperty, childProperty));
        }

        /// <summary>
        /// Checks if the given aproperty can be set equivalentpropertyof the given bproperty
        /// </summary>
        internal static Boolean CheckEquivalentPropertyCompatibility(RDFOntologyPropertyModel propertyModel,
                                                                     RDFOntologyObjectProperty aProperty,
                                                                     RDFOntologyObjectProperty bProperty) {
            return (!propertyModel.IsSubPropertyOf(aProperty, bProperty)
                        && !propertyModel.IsSuperPropertyOf(aProperty, bProperty));
        }

        /// <summary>
        /// Checks if the given aproperty can be set equivalentpropertyof the given bproperty
        /// </summary>
        internal static Boolean CheckEquivalentPropertyCompatibility(RDFOntologyPropertyModel propertyModel,
                                                                     RDFOntologyDatatypeProperty aProperty,
                                                                     RDFOntologyDatatypeProperty bProperty) {
            return (!propertyModel.IsSubPropertyOf(aProperty, bProperty)
                        && !propertyModel.IsSuperPropertyOf(aProperty, bProperty));
        }

        /// <summary>
        /// Checks if the given aproperty can be set inverseof the given bproperty
        /// </summary>
        internal static Boolean CheckInverseOfPropertyCompatibility(RDFOntologyPropertyModel propertyModel,
                                                                    RDFOntologyObjectProperty aProperty,
                                                                    RDFOntologyObjectProperty bProperty) {
            return (!propertyModel.IsSubPropertyOf(aProperty, bProperty)
                        && !propertyModel.IsSuperPropertyOf(aProperty, bProperty)
                            && !propertyModel.IsEquivalentPropertyOf(aProperty, bProperty));
        }
        #endregion

        #region Data
        /// <summary>
        /// Checks if the given class can be assigned as classtype of facts
        /// </summary>
        public static Boolean CheckClassTypeCompatibility(RDFOntologyClass ontologyClass) {
            return (!ontologyClass.IsRestrictionClass()
                        && !ontologyClass.IsCompositeClass()
                             && !ontologyClass.IsEnumerateClass()
                                 && !ontologyClass.IsDataRangeClass());
        }
        #endregion

    }

}