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
    /// RDFOntologyPropertyModelExtensions contains utility methods for enhancing capabilities of ontology property models
    /// </summary>
    public static class RDFOntologyPropertyModelExtensions {

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

    }

}