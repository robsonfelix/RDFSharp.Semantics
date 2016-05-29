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
    /// RDFSKOSExtensions represents an extension class for SKOS modeling
    /// </summary>
    public static class RDFSKOSExtensions {

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given fact as instance of "skos:Concept" to the given ontology data 
        /// </summary>
        public static RDFOntologyData AddSKOSConcept(this RDFOntologyData ontData, RDFOntologyFact concept) {
            if (concept != null) {
                ontData.AddFact(concept);

                ontData.AddClassTypeRelation(concept, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            }
            return ontData;
        }

        /// <summary>
        /// Adds the given fact as instance of "skos:ConceptScheme" to the given ontology data 
        /// </summary>
        public static RDFOntologyData AddSKOSConceptScheme(this RDFOntologyData ontData, RDFOntologyFact conceptScheme) {
            if (conceptScheme != null) {
                ontData.AddFact(conceptScheme);

                ontData.AddClassTypeRelation(conceptScheme, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));
            }
            return ontData;
        }

        /// <summary>
        /// Adds the given "concept skos:InScheme conceptScheme" assertion to the given ontology data 
        /// </summary>
        public static RDFOntologyData AddSKOSInSchemeAssertion(this RDFOntologyData ontData, RDFOntologyFact concept, RDFOntologyFact conceptScheme) {
            if (concept != null && conceptScheme != null) {
                AddSKOSConcept(ontData, concept);
                AddSKOSConceptScheme(ontData, conceptScheme);

                ontData.AddAssertionRelation(concept, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.IN_SCHEME.ToString()), conceptScheme);
            }
            return ontData;
        }

        /// <summary>
        /// Adds the given "concept skos:topConceptOf conceptScheme" assertion to the given ontology data 
        /// </summary>
        public static RDFOntologyData AddSKOSTopConceptOfAssertion(this RDFOntologyData ontData, RDFOntologyFact concept, RDFOntologyFact conceptScheme) {
            if (concept != null && conceptScheme != null) {
                AddSKOSConcept(ontData, concept);
                AddSKOSConceptScheme(ontData, conceptScheme);

                ontData.AddAssertionRelation(concept, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()), conceptScheme);
                ontData.AddAssertionRelation(conceptScheme, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()), concept);
            }
            return ontData;
        }

        /// <summary>
        /// Adds the given "conceptScheme skos:hasTopConcept concept" assertion to the given ontology data 
        /// </summary>
        public static RDFOntologyData AddSKOSHasTopConceptAssertion(this RDFOntologyData ontData, RDFOntologyFact conceptScheme, RDFOntologyFact concept) {
            if (concept != null && conceptScheme != null) {
                AddSKOSConcept(ontData, concept);
                AddSKOSConceptScheme(ontData, conceptScheme);

                ontData.AddAssertionRelation(conceptScheme, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()), concept);
                ontData.AddAssertionRelation(concept, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()), conceptScheme);
            }
            return ontData;
        }
        #endregion

        #endregion

    }

}