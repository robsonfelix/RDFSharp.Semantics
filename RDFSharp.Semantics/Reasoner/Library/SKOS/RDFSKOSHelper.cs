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

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    ///  RDFSKOSHelper contains utility methods supporting SKOS modeling and reasoning
    /// </summary>
    public static class RDFSKOSHelper {

        #region Facts
        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:Collection"
        /// </summary>
        public static RDFOntologyData AddSKOSCollection(this RDFOntologyData ontologyData, RDFResource collection) {
            if (ontologyData       != null && collection != null) {
                var collectionFact  = new RDFOntologyFact(collection);
                var collectionClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString());

                //Add fact
                ontologyData.AddFact(collectionFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(collectionFact, collectionClass);
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:Concept"
        /// </summary>
        public static RDFOntologyData AddSKOSConcept(this RDFOntologyData ontologyData, RDFResource concept) {
            if (ontologyData    != null && concept != null) {
                var conceptFact  = new RDFOntologyFact(concept);
                var conceptClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());

                //Add fact
                ontologyData.AddFact(conceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:ConceptScheme"
        /// </summary>
        public static RDFOntologyData AddSKOSConceptScheme(this RDFOntologyData ontologyData, RDFResource conceptScheme) {
            if (ontologyData          != null && conceptScheme != null) {
                var conceptSchemeFact  = new RDFOntologyFact(conceptScheme);
                var conceptSchemeClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());

                //Add fact
                ontologyData.AddFact(conceptSchemeFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:OrderedCollection"
        /// </summary>
        public static RDFOntologyData AddSKOSOrderedCollection(this RDFOntologyData ontologyData, RDFResource orderedCollection) {
            if (ontologyData              != null && orderedCollection != null) {
                var orderedCollectionFact  = new RDFOntologyFact(orderedCollection);
                var orderedCollectionClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString());

                //Add fact
                ontologyData.AddFact(orderedCollectionFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(orderedCollectionFact, orderedCollectionClass);
            }
            return ontologyData;
        }
        
        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skosxl:Label"
        /// </summary>
        public static RDFOntologyData AddSKOSLabel(this RDFOntologyData ontologyData, RDFResource label) {
            if (ontologyData  != null && label != null) {
                var labelFact  = new RDFOntologyFact(label);
                var labelClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());

                //Add fact
                ontologyData.AddFact(labelFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(labelFact, labelClass);
            }
            return ontologyData;
        }
        #endregion

        #region Assertions
        /// <summary>
        /// Adds the "concept -> skos:inScheme -> conceptScheme" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSInSchemeAssertion(this RDFOntologyData ontologyData, RDFResource concept, RDFResource conceptScheme) {
            if (ontologyData          != null && concept != null && conceptScheme != null) {
                var conceptFact        = new RDFOntologyFact(concept);
                var conceptSchemeFact  = new RDFOntologyFact(conceptScheme);
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var conceptSchemeClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());
                var inSchemeProperty   = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.IN_SCHEME.ToString());

                //Add fact
                ontologyData.AddFact(conceptFact);
                ontologyData.AddFact(conceptSchemeFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);

                //Add skos:inScheme assertion
                ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyObjectProperty)inSchemeProperty, conceptSchemeFact);
            }
            return ontologyData;
        }
        #endregion

    }

}
