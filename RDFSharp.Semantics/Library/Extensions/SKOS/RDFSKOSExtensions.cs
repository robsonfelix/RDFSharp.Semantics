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

namespace RDFSharp.Semantics.SKOS {

    /// <summary>
    /// RDFSKOSExtensions represents an extension class for SKOS ontology modeling
    /// </summary>
    public static class RDFSKOSExtensions {

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given fact and its "skos:Concept" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSConcept(this RDFOntologyData ontologyData, RDFOntologyFact skosConcept) {
            if (ontologyData != null && skosConcept != null) {
                ontologyData.AddFact(skosConcept);
                ontologyData.AddClassTypeRelation(skosConcept, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:ConceptScheme" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSConceptScheme(this RDFOntologyData ontologyData, RDFOntologyFact skosConceptScheme) {
            if (ontologyData != null && skosConceptScheme != null) {
                ontologyData.AddFact(skosConceptScheme);
                ontologyData.AddClassTypeRelation(skosConceptScheme, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:Collection" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSCollection(this RDFOntologyData ontologyData, RDFOntologyFact skosCollection) {
            if (ontologyData != null && skosCollection != null) {
                ontologyData.AddFact(skosCollection);
                ontologyData.AddClassTypeRelation(skosCollection, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()));
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:OrderedCollection" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSOrderedCollection(this RDFOntologyData ontologyData, RDFOntologyFact skosOrderedCollection) {
            if (ontologyData != null && skosOrderedCollection != null) {
                ontologyData.AddFact(skosOrderedCollection);
                ontologyData.AddClassTypeRelation(skosOrderedCollection, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString()));
            }
            return ontologyData;
        }
        #endregion

        #endregion

    }

}