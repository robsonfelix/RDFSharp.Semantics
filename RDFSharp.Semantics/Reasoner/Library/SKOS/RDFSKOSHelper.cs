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
        public static void AddCollection(RDFOntologyData ontologyData, RDFOntologyFact collectionFact) {
            if (ontologyData       != null && collectionFact != null) {
                var collectionClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString());

                //Add fact
                ontologyData.AddFact(collectionFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(collectionFact, collectionClass);
            }
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:Concept"
        /// </summary>
        public static void AddConcept(RDFOntologyData ontologyData, RDFOntologyFact conceptFact) {
            if (ontologyData    != null && conceptFact != null) {
                var conceptClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());

                //Add fact
                ontologyData.AddFact(conceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
            }
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:ConceptScheme"
        /// </summary>
        public static void AddConceptScheme(RDFOntologyData ontologyData, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData          != null && conceptSchemeFact != null) {
                var conceptSchemeClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());

                //Add fact
                ontologyData.AddFact(conceptSchemeFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);
            }
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skos:OrderedCollection"
        /// </summary>
        public static void AddOrderedCollection(RDFOntologyData ontologyData, RDFOntologyFact orderedCollectionFact) {
            if (ontologyData              != null && orderedCollectionFact != null) {
                var orderedCollectionClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString());

                //Add fact
                ontologyData.AddFact(orderedCollectionFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(orderedCollectionFact, orderedCollectionClass);
            }
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skosxl:Label"
        /// </summary>
        public static void AddLabel(RDFOntologyData ontologyData, RDFOntologyFact labelFact) {
            if (ontologyData  != null && labelFact != null) {
                var labelClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());

                //Add fact
                ontologyData.AddFact(labelFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(labelFact, labelClass);
            }
        }
        #endregion

        #region Assertions
        /// <summary>
        /// Adds the "conceptFact -> skos:inScheme -> conceptSchemeFact" assertion to the ontology data
        /// </summary>
        public static void AddInSchemeAssertion(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData          != null && conceptFact != null && conceptSchemeFact != null) {
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
        }

        /// <summary>
        /// Adds the "conceptSchemeFact -> skos:hasTopConcept -> conceptFact" assertion to the ontology data
        /// </summary>
        public static void AddHasTopConceptAssertion(RDFOntologyData ontologyData, RDFOntologyFact conceptSchemeFact, RDFOntologyFact conceptFact) {
            if (ontologyData             != null && conceptFact != null && conceptSchemeFact != null) {
                var conceptSchemeClass    = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());
                var conceptClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());                
                var hasTopConceptProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString());

                //Add fact
                ontologyData.AddFact(conceptSchemeFact);
                ontologyData.AddFact(conceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:hasTopConcept assertion
                ontologyData.AddAssertionRelation(conceptSchemeFact, (RDFOntologyObjectProperty)hasTopConceptProperty, conceptFact);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:topConceptOf -> conceptSchemeFact" assertion to the ontology data
        /// </summary>
        public static void AddTopConceptOfAssertion(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData            != null && conceptFact != null && conceptSchemeFact != null) {
                var conceptClass         = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var conceptSchemeClass   = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());                
                var topConceptOfProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString());

                //Add fact
                ontologyData.AddFact(conceptFact);
                ontologyData.AddFact(conceptSchemeFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);                

                //Add skos:topConceptOf assertion
                ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyObjectProperty)topConceptOfProperty, conceptSchemeFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:semanticRelation -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddSemanticRelationAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass             = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var semanticRelationProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:semanticRelation assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)semanticRelationProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:related -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddRelatedAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData       != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass    = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var relatedProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.RELATED.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:related assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)relatedProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broader -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddBroaderAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData       != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass    = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var broaderProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:broader assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)broaderProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broaderTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddBroaderTransitiveAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                 != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass              = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var broaderTransitiveProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:broaderTransitive assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)broaderTransitiveProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrower -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData        != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var narrowerProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:narrower assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)narrowerProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrowerTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerTransitiveAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                  != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass               = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var narrowerTransitiveProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:narrowerTransitive assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)narrowerTransitiveProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:closeMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddCloseMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData          != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var closeMatchProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.CLOSE_MATCH.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:closeMatch assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)closeMatchProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:exactMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddExactMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData          != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var exactMatchProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.EXACT_MATCH.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:exactMatch assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)exactMatchProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broadMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddBroadMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData          != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var broadMatchProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:broadMatch assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)broadMatchProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrowMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddNarrowMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData           != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass        = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var narrowMatchProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:narrowMatch assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)narrowMatchProperty, bConceptFact);
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:relatedMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddRelatedMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData            != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass         = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var relatedMatchProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.RELATED_MATCH.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:relatedMatch assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)relatedMatchProperty, bConceptFact);
            }
        }
        
        /// <summary>
        /// Adds the "aConceptFact -> skos:mappingRelation -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddMappingRelationAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData               != null && aConceptFact != null && bConceptFact != null) {
                var conceptClass            = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var mappingRelationProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString());

                //Add fact
                ontologyData.AddFact(aConceptFact);
                ontologyData.AddFact(bConceptFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aConceptFact, conceptClass);
                ontologyData.AddClassTypeRelation(bConceptFact, conceptClass);

                //Add skos:mappingRelation assertion
                ontologyData.AddAssertionRelation(aConceptFact, (RDFOntologyObjectProperty)mappingRelationProperty, bConceptFact);
            }
        }
        #endregion

    }

}
