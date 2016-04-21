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
using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFFOAFOntology represents an ontology implementation of FOAF vocabulary
    /// </summary>
    public static class RDFFOAFOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the FOAF ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the FOAF ontology
        /// </summary>
        static RDFFOAFOntology() {

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharp.codeplex.com/foaf_ontology#"));
            #endregion

            #region Classes
            
            #endregion

            #region Properties
            
            #endregion

            #region Facts
            
            #endregion

            #region Taxonomies

            #region ClassModel
            
            #endregion

            #region PropertyModel
            
            #endregion

            #region Data
            
            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the FOAF ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            if (ontClass     != null) {
                Int64 classID = RDFModelUtilities.CreateHash(ontClass);
                if (Instance.Model.ClassModel.Classes.ContainsKey(classID)) {
                    return Instance.Model.ClassModel.Classes[classID];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the given property from the FOAF ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            if (ontProperty  != null) {
                Int64 propID  = RDFModelUtilities.CreateHash(ontProperty);
                if (Instance.Model.PropertyModel.Properties.ContainsKey(propID)) {
                    return Instance.Model.PropertyModel.Properties[propID];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the given fact from the FOAF ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            if (ontFact     != null) {
                Int64 factID = RDFModelUtilities.CreateHash(ontFact);
                if (Instance.Data.Facts.ContainsKey(factID)) {
                    return Instance.Data.Facts[factID];
                }
            }
            return null;
        }

        /// <summary>
        /// Exports the FOAF ontology to a RDF graph
        /// </summary>
        public static RDFGraph ToRDFGraph(Boolean includeInferences) {
            return Instance.ToRDFGraph(includeInferences);
        }
        #endregion

    }

}