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
    /// RDFOWLOntology represents an OWL-DL ontology implementation of OWL vocabulary
    /// </summary>
    public static class RDFOWLOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the OWL ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the OWL ontology
        /// </summary>
        static RDFOWLOntology() {

            //Initialize
            Instance = new RDFOntology(new RDFResource(RDFVocabulary.OWL.BASE_URI));

            //Classes
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.OWL.THING));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.OWL.NOTHING));

            //Properties
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.DISJOINT_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.INVERSE_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ON_PROPERTY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ONE_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.UNION_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.INTERSECTION_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.COMPLEMENT_OF));            
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ALL_VALUES_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.SOME_VALUES_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.HAS_VALUE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.SAME_AS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.DIFFERENT_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.MIN_CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.MAX_CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.VERSION_INFO));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.VERSION_IRI));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.IMPORTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.PRIOR_VERSION));

        }
        #endregion

    }

}