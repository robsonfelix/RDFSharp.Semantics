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
using System.Collections.Generic;
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    ///  RDFSKOSHelper contains utility methods supporting SKOS modeling and reasoning
    /// </summary>
    public static class RDFSKOSHelper {

        #region Modeling

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
                //Add skos:related assertion as inference
                ontologyData.Relations.Assertions.AddEntry(new RDFOntologyTaxonomyEntry(bConceptFact, (RDFOntologyObjectProperty)relatedProperty, aConceptFact)
                                                 .SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            }
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broader -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddBroaderAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData            != null && aConceptFact != null && bConceptFact != null) {
                if (!HasNarrowerConcept(ontologyData, aConceptFact, bConceptFact)) { 
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
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broaderTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddBroaderTransitiveAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                      != null && aConceptFact != null && bConceptFact != null) {
                if (!HasNarrowerConcept(ontologyData, aConceptFact, bConceptFact)) {
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
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrower -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData             != null && aConceptFact != null && bConceptFact != null) {
                if (!HasBroaderConcept(ontologyData, aConceptFact, bConceptFact)) {
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
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrowerTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerTransitiveAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                       != null && aConceptFact != null && bConceptFact != null) {
                if (!HasBroaderConcept(ontologyData, aConceptFact, bConceptFact)) {
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
                //Add skos:closeMatch assertion as inference
                ontologyData.Relations.Assertions.AddEntry(new RDFOntologyTaxonomyEntry(bConceptFact, (RDFOntologyObjectProperty)closeMatchProperty, aConceptFact)
                                                 .SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
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
                //Add skos:exactMatch assertion as inference
                ontologyData.Relations.Assertions.AddEntry(new RDFOntologyTaxonomyEntry(bConceptFact, (RDFOntologyObjectProperty)exactMatchProperty, aConceptFact)
                                                 .SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
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
                //Add skos:relatedMatch assertion as inference
                ontologyData.Relations.Assertions.AddEntry(new RDFOntologyTaxonomyEntry(bConceptFact, (RDFOntologyObjectProperty)relatedMatchProperty, aConceptFact)
                                                 .SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
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

        /// <summary>
        /// Adds the "conceptFact -> skos:notation -> notationLiteral" assertion to the ontology data
        /// </summary>
        public static void AddNotationAssertion(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral notationLiteral) {
            if (ontologyData        != null && conceptFact != null && notationLiteral != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var notationProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NOTATION.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(notationLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:notation assertion
                ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyDatatypeProperty)notationProperty, notationLiteral);
            }
        }

        /// <summary>
        /// Adds the "aLabel -> skosxl:labelRelation -> bLabel" assertion to the ontology data
        /// </summary>
        public static void AddLabelRelationAssertion(RDFOntologyData ontologyData, RDFOntologyFact aLabel, RDFOntologyFact bLabel) {
            if (ontologyData             != null && aLabel != null && bLabel != null) {
                var labelClass            = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var labelRelationProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LABEL_RELATION.ToString());

                //Add fact
                ontologyData.AddFact(aLabel);
                ontologyData.AddFact(bLabel);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(aLabel, labelClass);
                ontologyData.AddClassTypeRelation(bLabel, labelClass);

                //Add skosxl:labelRelation assertion
                ontologyData.AddAssertionRelation(aLabel, (RDFOntologyObjectProperty)labelRelationProperty, bLabel);
                //Add skosxl:labelRelation assertion as inference
                ontologyData.Relations.Assertions.AddEntry(new RDFOntologyTaxonomyEntry(bLabel, (RDFOntologyObjectProperty)labelRelationProperty, aLabel)
                                                 .SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            }
        }

        /// <summary>
        /// Adds the "label -> skosxl:literalForm -> literal" assertion to the ontology data
        /// </summary>
        public static void AddLiteralFormAssertion(RDFOntologyData ontologyData, RDFOntologyFact label, RDFOntologyLiteral literal) {
            if (ontologyData           != null && label != null && literal != null) {
                var labelClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var literalFormProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

                //Add fact and literal
                ontologyData.AddFact(label);
                ontologyData.AddLiteral(literal);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(label, labelClass);

                //Add skosxl:literalForm assertion
                ontologyData.AddAssertionRelation(label, (RDFOntologyDatatypeProperty)literalFormProperty, literal);
            }
        }
        #endregion

        #region Annotations
        /// <summary>
        /// Adds the "conceptFact -> skos:prefLabel -> prefLabelLiteral" annotation to the ontology data
        /// </summary>
        public static void AddPrefLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral prefLabelLiteral) {
            if (ontologyData                != null && conceptFact != null && prefLabelLiteral != null) {
                var conceptClass             = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var prefLabelProperty        = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());

                //Only plain literals are allowed as skos:prefLabel annotations
                if (prefLabelLiteral.Value  is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckPrefLabelAnnotation(ontologyData, conceptFact, prefLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(prefLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:prefLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)prefLabelProperty, conceptFact, prefLabelLiteral);

                    }
                    else {
                        RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:prefLabel '{1}' literal value, because skos taxonomy checks are violated.", conceptFact, prefLabelLiteral));
                    }
                }
                else {
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:prefLabel '{1}' literal value, because skos requires a plain literal.", conceptFact, prefLabelLiteral));
                }

            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:altLabel -> altLabelLiteral" annotation to the ontology data
        /// </summary>
        public static void AddAltLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral altLabelLiteral) {
            if (ontologyData        != null && conceptFact != null && altLabelLiteral != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var altLabelProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());

                //Only plain literals are allowed as skos:altLabel annotations
                if (altLabelLiteral.Value is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckAltLabelAnnotation(ontologyData, conceptFact, altLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(altLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:altLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)altLabelProperty, conceptFact, altLabelLiteral);

                    }
                    else {
                        RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:altLabel '{1}' literal value, because skos taxonomy checks are violated.", conceptFact, altLabelLiteral));
                    }
                }
                else {
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:altLabel '{1}' literal value, because skos requires a plain literal.", conceptFact, altLabelLiteral));
                }

            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:hiddenLabel -> hiddenLabelLiteral" annotation to the ontology data
        /// </summary>
        public static void AddHiddenLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral hiddenLabelLiteral) {
            if (ontologyData        != null && conceptFact != null && hiddenLabelLiteral != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var hidLabelProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());

                //Only plain literals are allowed as skos:hiddenLabel annotations
                if (hiddenLabelLiteral.Value is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckHiddenLabelAnnotation(ontologyData, conceptFact, hiddenLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(hiddenLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:hiddenLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)hidLabelProperty, conceptFact, hiddenLabelLiteral);

                    }
                    else {
                        RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:hiddenLabel '{1}' literal value, because skos taxonomy checks are violated.", conceptFact, hiddenLabelLiteral));
                    }
                }
                else {
                    RDFSemanticsEvents.RaiseSemanticsWarning(String.Format("Cannot annotate skos:concept '{0}' with skos:hiddenLabel '{1}' literal value, because skos requires a plain literal.", conceptFact, hiddenLabelLiteral));
                }

            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:note -> noteLiteral" annotation to the ontology data
        /// </summary>
        public static void AddNoteAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral noteLiteral) {
            if (ontologyData    != null && conceptFact != null && noteLiteral != null) {
                var conceptClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var noteProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NOTE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(noteLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:note annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)noteProperty, conceptFact, noteLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:changeNote -> changeNoteLiteral" annotation to the ontology data
        /// </summary>
        public static void AddChangeNoteAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral changeNoteLiteral) {
            if (ontologyData          != null && conceptFact != null && changeNoteLiteral != null) {
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var changeNoteProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.CHANGE_NOTE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(changeNoteLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:changeNote annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)changeNoteProperty, conceptFact, changeNoteLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:editorialNote -> editorialNoteLiteral" annotation to the ontology data
        /// </summary>
        public static void AddEditorialNoteAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral editorialNoteLiteral) {
            if (ontologyData             != null && conceptFact != null && editorialNoteLiteral != null) {
                var conceptClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var editorialNoteProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.EDITORIAL_NOTE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(editorialNoteLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:editorialNote annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)editorialNoteProperty, conceptFact, editorialNoteLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:historyNote -> historyNoteLiteral" annotation to the ontology data
        /// </summary>
        public static void AddHistoryNoteAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral historyNoteLiteral) {
            if (ontologyData           != null && conceptFact != null && historyNoteLiteral != null) {
                var conceptClass        = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var historyNoteProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HISTORY_NOTE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(historyNoteLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:historyNote annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)historyNoteProperty, conceptFact, historyNoteLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:scopeNote -> scopeNoteLiteral" annotation to the ontology data
        /// </summary>
        public static void AddScopeNoteAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral scopeNoteLiteral) {
            if (ontologyData         != null && conceptFact != null && scopeNoteLiteral != null) {
                var conceptClass      = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var scopeNoteProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SCOPE_NOTE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(scopeNoteLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:scopeNote annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)scopeNoteProperty, conceptFact, scopeNoteLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:definition -> definitionLiteral" annotation to the ontology data
        /// </summary>
        public static void AddDefinitionAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral definitionLiteral) {
            if (ontologyData          != null && conceptFact != null && definitionLiteral != null) {
                var conceptClass       = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var definitionProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.DEFINITION.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(definitionLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:definition annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)definitionProperty, conceptFact, definitionLiteral);
            }
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:example -> exampleLiteral" annotation to the ontology data
        /// </summary>
        public static void AddExampleAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral exampleLiteral) {
            if (ontologyData       != null && conceptFact != null && exampleLiteral != null) {
                var conceptClass    = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var exampleProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.EXAMPLE.ToString());

                //Add fact and literal
                ontologyData.AddFact(conceptFact);
                ontologyData.AddLiteral(exampleLiteral);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                //Add skos:example annotation
                ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)exampleProperty, conceptFact, exampleLiteral);
            }
        }
        #endregion

        #endregion

        #region Reasoning

        #region Broader
        /// <summary>
        /// Checks if the given aConcept has broader concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasBroaderConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistBroaderConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the broader concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistBroaderConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result     = new RDFOntologyData();
            if (concept   != null && data != null) {

                //Add skos:broader concepts to result
                foreach(var broader in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                     .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER.ToString()))) {
                    result.AddFact((RDFOntologyFact)broader.TaxonomyObject);

                    //Exploit skos:exactMatch taxonomy
                    result = result.UnionWith(EnlistExactMatchesOf(data, (RDFOntologyFact)broader.TaxonomyObject));
                }

                //Add skos:broaderTransitive concepts to result
                result     = result.UnionWith(data.EnlistBroaderConceptsOfInternal(concept, null))
                                   .RemoveFact(concept); //Safety deletion

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "skos:broaderTransitive" taxonomy to discover direct and indirect broader concepts of the given concept
        /// </summary>
        internal static RDFOntologyData EnlistBroaderConceptsOfInternal(this RDFOntologyData data, RDFOntologyFact concept, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result        = new RDFOntologyData();

            #region visitContext
            if (visitContext == null) {
                visitContext  = new Dictionary<Int64, RDFOntologyFact>() { { concept.PatternMemberID, concept } };
            }
            else {
                if (!visitContext.ContainsKey(concept.PatternMemberID)) {
                     visitContext.Add(concept.PatternMemberID, concept);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "skos:broaderTransitive" taxonomy: ((A SKOS:BROADERTRANSITIVE B)  &&  (B SKOS:BROADERTRANSITIVE C))  =>  (A SKOS:BROADERTRANSITIVE C)
            var broaderTrProp = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString());
            foreach (var bt  in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                         .SelectEntriesByPredicate(broaderTrProp)) {
                result.AddFact((RDFOntologyFact)bt.TaxonomyObject);

                // Exploit skos:exactMatch taxonomy
                result        = result.UnionWith(EnlistExactMatchesOf(data, (RDFOntologyFact)bt.TaxonomyObject));

                // Exploit skos:broaderTransitive taxonomy
                result        = result.UnionWith(data.EnlistBroaderConceptsOfInternal((RDFOntologyFact)bt.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region Narrower
        /// <summary>
        /// Checks if the given aConcept has narrower concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasNarrowerConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistNarrowerConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the narrower concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistNarrowerConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result     = new RDFOntologyData();
            if (concept   != null && data != null) {

                //Add skos:narrower concepts to result
                foreach (var narrower in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                       .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString()))) {
                    result.AddFact((RDFOntologyFact)narrower.TaxonomyObject);

                    //Exploit skos:exactMatch taxonomy
                    result = result.UnionWith(EnlistExactMatchesOf(data, (RDFOntologyFact)narrower.TaxonomyObject));
                }

                //Add skos:narrowerTransitive concepts to result
                result     = result.UnionWith(data.EnlistNarrowerConceptsOfInternal(concept, null))
                                   .RemoveFact(concept); //Safety deletion

            }
            return result;
        }

        /// <summary>
        /// Subsumes the "skos:narrowerTransitive" taxonomy to discover direct and indirect narrower concepts of the given concept
        /// </summary>
        internal static RDFOntologyData EnlistNarrowerConceptsOfInternal(this RDFOntologyData data, RDFOntologyFact concept, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result         = new RDFOntologyData();

            #region visitContext
            if (visitContext  == null) {
                visitContext   = new Dictionary<Int64, RDFOntologyFact>() { { concept.PatternMemberID, concept } };
            }
            else {
                if (!visitContext.ContainsKey(concept.PatternMemberID)) {
                     visitContext.Add(concept.PatternMemberID, concept);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "skos:narrowerTransitive" taxonomy: ((A SKOS:NARROWERTRANSITIVE B)  &&  (B SKOS:NARROWERTRANSITIVE C))  =>  (A SKOS:NARROWERTRANSITIVE C)
            var narrowerTrProp = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString());
            foreach (var nt   in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(narrowerTrProp)) {
                result.AddFact((RDFOntologyFact)nt.TaxonomyObject);

                // Exploit skos:exactMatch taxonomy
                result         = result.UnionWith(EnlistExactMatchesOf(data, (RDFOntologyFact)nt.TaxonomyObject));

                // Exploit skos:narrowerTransitive taxonomy
                result         = result.UnionWith(data.EnlistBroaderConceptsOfInternal((RDFOntologyFact)nt.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region ExactMatch
        /// <summary>
        /// Checks if the given aConcept skos:exactMatch the given bConcept within the given data
        /// </summary>
        public static Boolean IsExactMatchOf(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistExactMatchesOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the skos:exactMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistExactMatchesOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result   = new RDFOntologyData();
            if (concept != null && data != null) {
                result   = data.EnlistExactMatchesOfInternal(concept, null)
                               .RemoveFact(concept); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "skos:exactMatch" taxonomy to discover direct and indirect exactmatches of the given concept
        /// </summary>
        internal static RDFOntologyData EnlistExactMatchesOfInternal(this RDFOntologyData data, RDFOntologyFact concept, Dictionary<Int64, RDFOntologyFact> visitContext) {
            var result         = new RDFOntologyData();

            #region visitContext
            if (visitContext  == null) {
                visitContext   = new Dictionary<Int64, RDFOntologyFact>() { { concept.PatternMemberID, concept } };
            }
            else {
                if (!visitContext.ContainsKey(concept.PatternMemberID)) {
                     visitContext.Add(concept.PatternMemberID, concept);
                }
                else {
                     return result;
                }
            }
            #endregion

            // Transitivity of "skos:exactMatch" taxonomy: ((A SKOS:EXACTMATCH B)  &&  (B SKOS:EXACTMATCH C))  =>  (A SKOS:EXACTMATCH C)
            var exactMatchProp = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.EXACT_MATCH.ToString());
            foreach (var em   in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(exactMatchProp)) {
                result.AddFact((RDFOntologyFact)em.TaxonomyObject);
                result         = result.UnionWith(data.EnlistExactMatchesOfInternal((RDFOntologyFact)em.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #endregion

    }

}
