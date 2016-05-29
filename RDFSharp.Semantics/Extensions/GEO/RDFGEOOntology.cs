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
using RDFSharp.Semantics.BASE;
using RDFSharp.Semantics.FOAF;

namespace RDFSharp.Semantics.GEO {

    /// <summary>
    /// RDFGEOOntology represents an OWL-DL ontology implementation of W3C GEO vocabulary
    /// </summary>
    public static class RDFGEOOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the GEO ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the GEO ontology
        /// </summary>
        static RDFGEOOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/geo_ontology#"));
            #endregion

            #region Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.GEO.SPATIAL_THING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.GEO.POINT.ToRDFOntologyClass());
            #endregion

            #region Properties
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.GEO.ALT.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.GEO.LAT.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.GEO.LONG.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.GEO.LAT_LONG.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.GEO.LOCATION.ToRDFOntologyObjectProperty());
            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.GEO.POINT.ToString()), SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.GEO.LOCATION.ToString()), (RDFOntologyObjectProperty)RDFFOAFOntology.SelectProperty(RDFVocabulary.FOAF.BASED_NEAR.ToString()));

            //Domain/Range
            SelectProperty(RDFVocabulary.GEO.ALT.ToString()).SetDomain(SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.GEO.ALT.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.FLOAT.ToString()));
            SelectProperty(RDFVocabulary.GEO.LAT.ToString()).SetDomain(SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.GEO.LAT.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.FLOAT.ToString()));
            SelectProperty(RDFVocabulary.GEO.LONG.ToString()).SetDomain(SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.GEO.LONG.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.FLOAT.ToString()));
            SelectProperty(RDFVocabulary.GEO.LAT_LONG.ToString()).SetDomain(SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.GEO.LAT_LONG.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.STRING.ToString()));
            SelectProperty(RDFVocabulary.GEO.LOCATION.ToString()).SetRange(SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the GEO ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the GEO ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the GEO ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            return Instance.Data.SelectFact(ontFact);
        }
        #endregion

    }

}