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
        public static RDFOntologyData AddCollection(this RDFOntologyData ontologyData, RDFOntologyFact collectionFact) {
            if (ontologyData       != null && collectionFact != null) {
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
        public static RDFOntologyData AddConcept(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact) {
            if (ontologyData    != null && conceptFact != null) {
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
        public static RDFOntologyData AddConceptScheme(this RDFOntologyData ontologyData, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData          != null && conceptSchemeFact != null) {
                var conceptSchemeClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString());

                //Add fact
                ontologyData.AddFact(conceptSchemeFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(conceptSchemeFact, conceptSchemeClass);
            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact to the ontology data as instance of "skosxl:Label"
        /// </summary>
        public static RDFOntologyData AddLabel(this RDFOntologyData ontologyData, RDFOntologyFact labelFact) {
            if (ontologyData  != null && labelFact != null) {
                var labelClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());

                //Add fact
                ontologyData.AddFact(labelFact);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(labelFact, labelClass);
            }
            return ontologyData;
        }
        #endregion

        #region Relations

        #region ConceptScheme Relations
        /// <summary>
        /// Adds the "conceptFact -> skos:inScheme -> conceptSchemeFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddInSchemeAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData          != null && conceptFact != null && conceptSchemeFact != null && !conceptFact.Equals(conceptSchemeFact)) {
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

        /// <summary>
        /// Adds the "conceptSchemeFact -> skos:hasTopConcept -> conceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddHasTopConceptAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptSchemeFact, RDFOntologyFact conceptFact) {
            if (ontologyData             != null && conceptFact != null && conceptSchemeFact != null && !conceptSchemeFact.Equals(conceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:topConceptOf -> conceptSchemeFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddTopConceptOfAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact conceptSchemeFact) {
            if (ontologyData            != null && conceptFact != null && conceptSchemeFact != null && !conceptFact.Equals(conceptSchemeFact)) {
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
            return ontologyData;
        }
        #endregion

        #region Semantic Relations
        /// <summary>
        /// Adds the "aConceptFact -> skos:semanticRelation -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSemanticRelationAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:related -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddRelatedAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData           != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckRelatedAssertion(ontologyData, aConceptFact, bConceptFact)) {

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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broader -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddBroaderAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData           != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckBroaderAssertion(ontologyData, aConceptFact, bConceptFact)) { 
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broaderTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddBroaderTransitiveAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                      != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckBroaderAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrower -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddNarrowerAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData            != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckNarrowerAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrowerTransitive -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddNarrowerTransitiveAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                       != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckNarrowerAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }
        #endregion

        #region Mapping Relations
        /// <summary>
        /// Adds the "aConceptFact -> skos:closeMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddCloseMatchAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData              != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckCloseOrExactMatchAssertion(ontologyData, aConceptFact, bConceptFact)) {

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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:exactMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddExactMatchAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData              != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckCloseOrExactMatchAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:broadMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddBroadMatchAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData              != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckBroaderAssertion(ontologyData, aConceptFact, bConceptFact)) {

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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:narrowMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddNarrowMatchAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData               != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckNarrowerAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:relatedMatch -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddRelatedMatchAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData                != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
                if (RDFSKOSChecker.CheckRelatedAssertion(ontologyData, aConceptFact, bConceptFact)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aConceptFact -> skos:mappingRelation -> bConceptFact" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddMappingRelationAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            if (ontologyData               != null && aConceptFact != null && bConceptFact != null && !aConceptFact.Equals(bConceptFact)) {
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
            return ontologyData;
        }
        #endregion

        #region Notation Relations
        /// <summary>
        /// Adds the "conceptFact -> skos:notation -> notationLiteral" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddNotationAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral notationLiteral) {
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
            return ontologyData;
        }
        #endregion

        #region Collection Relations
        /// <summary>
        /// Adds the "collectionFact -> skos:member -> collectionMember" assertion to the ontology data 
        /// </summary>
        public static RDFOntologyData AddMemberAssertion(this RDFOntologyData ontologyData, RDFOntologyFact collectionFact, RDFOntologyFact collectionMember, RDFSKOSEnums.RDFSKOSMemberType skosMemberType) {
            if (ontologyData       != null && collectionFact != null && collectionMember != null) {
                var collectionClass = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString());
                var conceptClass    = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var memberProperty  = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.MEMBER.ToString());

                //Add facts
                ontologyData.AddFact(collectionFact);
                ontologyData.AddFact(collectionMember);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(collectionFact, collectionClass);
                if (skosMemberType == RDFSKOSEnums.RDFSKOSMemberType.Concept)
                    ontologyData.AddClassTypeRelation(collectionMember, conceptClass);
                else
                    ontologyData.AddClassTypeRelation(collectionMember, collectionClass);

                //Add skos:member assertion
                ontologyData.AddAssertionRelation(collectionFact, (RDFOntologyObjectProperty)memberProperty, collectionMember);
            }
            return ontologyData;
        }
        #endregion

        #region Label Relations (SKOS-XL)
        /// <summary>
        /// Adds the "conceptFact -> skosxl:prefLabel -> labelFact" and "labelFact -> skosxl:literalForm -> prefLabelLiteral" assertions to the ontology data
        /// </summary>
        public static RDFOntologyData AddPrefLabelAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact labelFact, RDFOntologyLiteral prefLabelLiteral) {
            if (ontologyData           != null && conceptFact != null && labelFact != null && prefLabelLiteral != null) {
                var conceptClass        = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var labelClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var prefLabelProperty   = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.PREF_LABEL.ToString());
		        var literalFormProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

                //Only plain literals are allowed as skosxl:prefLabel assertions
                if (prefLabelLiteral.Value  is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckPrefLabel(ontologyData, conceptFact, prefLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
			            ontologyData.AddFact(labelFact);
                        ontologyData.AddLiteral(prefLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
			            ontologyData.AddClassTypeRelation(labelFact, labelClass);

                        //Add skosxl:prefLabel assertion
                        ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyObjectProperty)prefLabelProperty, labelFact);
			
			            //Add skosxl:literalForm assertion
                        ontologyData.AddAssertionRelation(labelFact, (RDFOntologyDatatypeProperty)literalFormProperty, prefLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skosxl:altLabel -> labelFact" and "labelFact -> skosxl:literalForm -> altLabelLiteral" assertions to the ontology data
        /// </summary>
        public static RDFOntologyData AddAltLabelAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact labelFact, RDFOntologyLiteral altLabelLiteral) {
            if (ontologyData           != null && conceptFact != null && labelFact != null && altLabelLiteral != null) {
                var conceptClass        = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var labelClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var altLabelProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.ALT_LABEL.ToString());
		        var literalFormProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

                //Only plain literals are allowed as skosxl:altLabel assertions
                if (altLabelLiteral.Value  is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckAltLabel(ontologyData, conceptFact, altLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
			            ontologyData.AddFact(labelFact);
                        ontologyData.AddLiteral(altLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
			            ontologyData.AddClassTypeRelation(labelFact, labelClass);

                        //Add skosxl:altLabel assertion
                        ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyObjectProperty)altLabelProperty, labelFact);
			
			            //Add skosxl:literalForm assertion
                        ontologyData.AddAssertionRelation(labelFact, (RDFOntologyDatatypeProperty)literalFormProperty, altLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skosxl:hiddenLabel -> labelFact" and "labelFact -> skosxl:literalForm -> hidLabelLiteral" assertions to the ontology data
        /// </summary>
        public static RDFOntologyData AddHiddenLabelAssertion(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyFact labelFact, RDFOntologyLiteral hidLabelLiteral) {
            if (ontologyData           != null && conceptFact != null && labelFact != null && hidLabelLiteral != null) {
                var conceptClass        = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var labelClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var hidLabelProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.HIDDEN_LABEL.ToString());
		        var literalFormProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

                //Only plain literals are allowed as skosxl:hiddenLabel assertions
                if (hidLabelLiteral.Value  is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckHiddenLabel(ontologyData, conceptFact, hidLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
			            ontologyData.AddFact(labelFact);
                        ontologyData.AddLiteral(hidLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);
			            ontologyData.AddClassTypeRelation(labelFact, labelClass);

                        //Add skosxl:hiddenLabel assertion
                        ontologyData.AddAssertionRelation(conceptFact, (RDFOntologyObjectProperty)hidLabelProperty, labelFact);
			
			            //Add skosxl:literalForm assertion
                        ontologyData.AddAssertionRelation(labelFact, (RDFOntologyDatatypeProperty)literalFormProperty, hidLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the "aLabel -> skosxl:labelRelation -> bLabel" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddLabelRelationAssertion(this RDFOntologyData ontologyData, RDFOntologyFact aLabel, RDFOntologyFact bLabel) {
            if (ontologyData             != null && aLabel != null && bLabel != null && !aLabel.Equals(bLabel)) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "labelFact -> skosxl:literalForm -> literal" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddLiteralFormAssertion(this RDFOntologyData ontologyData, RDFOntologyFact labelFact, RDFOntologyLiteral literal) {
            if (ontologyData           != null && labelFact != null && literal != null) {
                var labelClass          = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.SKOSXL.LABEL.ToString());
                var literalFormProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

                //Add fact and literal
                ontologyData.AddFact(labelFact);
                ontologyData.AddLiteral(literal);

                //Add classtype relation
                ontologyData.AddClassTypeRelation(labelFact, labelClass);

                //Add skosxl:literalForm assertion
                ontologyData.AddAssertionRelation(labelFact, (RDFOntologyDatatypeProperty)literalFormProperty, literal);
            }
            return ontologyData;
        }
        #endregion

        #endregion

        #region Annotations

        #region Lexical Labeling Annotations
        /// <summary>
        /// Adds the "conceptFact -> skos:prefLabel -> prefLabelLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddPrefLabelAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral prefLabelLiteral) {
            if (ontologyData                != null && conceptFact != null && prefLabelLiteral != null) {
                var conceptClass             = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var prefLabelProperty        = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());

                //Only plain literals are allowed as skos:prefLabel annotations
                if (prefLabelLiteral.Value  is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckPrefLabel(ontologyData, conceptFact, prefLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(prefLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:prefLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)prefLabelProperty, conceptFact, prefLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:altLabel -> altLabelLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddAltLabelAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral altLabelLiteral) {
            if (ontologyData        != null && conceptFact != null && altLabelLiteral != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var altLabelProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());

                //Only plain literals are allowed as skos:altLabel annotations
                if (altLabelLiteral.Value is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckAltLabel(ontologyData, conceptFact, altLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(altLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:altLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)altLabelProperty, conceptFact, altLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:hiddenLabel -> hiddenLabelLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddHiddenLabelAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral hiddenLabelLiteral) {
            if (ontologyData        != null && conceptFact != null && hiddenLabelLiteral != null) {
                var conceptClass     = RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString());
                var hidLabelProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());

                //Only plain literals are allowed as skos:hiddenLabel annotations
                if (hiddenLabelLiteral.Value is RDFPlainLiteral) {
                    if (RDFSKOSChecker.CheckHiddenLabel(ontologyData, conceptFact, hiddenLabelLiteral)) {

                        //Add fact and literal
                        ontologyData.AddFact(conceptFact);
                        ontologyData.AddLiteral(hiddenLabelLiteral);

                        //Add classtype relation
                        ontologyData.AddClassTypeRelation(conceptFact, conceptClass);

                        //Add skos:hiddenLabel annotation
                        ontologyData.AddCustomAnnotation((RDFOntologyAnnotationProperty)hidLabelProperty, conceptFact, hiddenLabelLiteral);

                    }
                }

            }
            return ontologyData;
        }
        #endregion

        #region Documentation Annotations
        /// <summary>
        /// Adds the "conceptFact -> skos:note -> noteLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddNoteAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral noteLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:changeNote -> changeNoteLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddChangeNoteAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral changeNoteLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:editorialNote -> editorialNoteLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddEditorialNoteAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral editorialNoteLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:historyNote -> historyNoteLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddHistoryNoteAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral historyNoteLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:scopeNote -> scopeNoteLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddScopeNoteAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral scopeNoteLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:definition -> definitionLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddDefinitionAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral definitionLiteral) {
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
            return ontologyData;
        }

        /// <summary>
        /// Adds the "conceptFact -> skos:example -> exampleLiteral" annotation to the ontology data
        /// </summary>
        public static RDFOntologyData AddExampleAnnotation(this RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral exampleLiteral) {
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
            return ontologyData;
        }
        #endregion

        #endregion

        #endregion

        #region Reasoning

        #region Semantic Relations

        #region Broader/BroaderTransitive
        /// <summary>
        /// Checks if the given aConcept has broader/broaderTransitive concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasBroaderConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistBroaderConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the broader/broaderTransitive concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistBroaderConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result         = new RDFOntologyData();
            if (concept       != null && data != null) {

                //Get skos:broader concepts
                var broader    = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER.ToString()));
                foreach (var broaderConcept in broader) {
                    result.AddFact((RDFOntologyFact)broaderConcept.TaxonomyObject);
                }

                //Get skos:broaderTransitive concepts
                result         = result.UnionWith(data.EnlistBroaderConceptsOfInternal(concept, null))
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

            //Transitivity of "skos:broaderTransitive" taxonomy: ((A SKOS:BROADERTRANSITIVE B)  &&  (B SKOS:BROADERTRANSITIVE C))  =>  (A SKOS:BROADERTRANSITIVE C)
            var broaderTrProp = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString());
            foreach (var bt  in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                         .SelectEntriesByPredicate(broaderTrProp)) {
                result.AddFact((RDFOntologyFact)bt.TaxonomyObject);

                //Exploit skos:broaderTransitive taxonomy
                result        = result.UnionWith(data.EnlistBroaderConceptsOfInternal((RDFOntologyFact)bt.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region Narrower/NarrowerTransitive
        /// <summary>
        /// Checks if the given aConcept has narrower/narrowerTransitive concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasNarrowerConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistNarrowerConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the narrower/narrowerTransitive concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistNarrowerConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result          = new RDFOntologyData();
            if (concept        != null && data != null) {

                //Get skos:narrower concepts
                var narrower    = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                           .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString()));
                foreach (var narrowerConcept in narrower) {
                    result.AddFact((RDFOntologyFact)narrowerConcept.TaxonomyObject);
                }

                //Get skos:narrowerTransitive concepts
                result          = result.UnionWith(data.EnlistNarrowerConceptsOfInternal(concept, null))
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

            //Transitivity of "skos:narrowerTransitive" taxonomy: ((A SKOS:NARROWERTRANSITIVE B)  &&  (B SKOS:NARROWERTRANSITIVE C))  =>  (A SKOS:NARROWERTRANSITIVE C)
            var narrowerTrProp = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString());
            foreach (var nt   in data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(narrowerTrProp)) {
                result.AddFact((RDFOntologyFact)nt.TaxonomyObject);

                //Exploit skos:narrowerTransitive taxonomy
                result         = result.UnionWith(data.EnlistNarrowerConceptsOfInternal((RDFOntologyFact)nt.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #region Related
        /// <summary>
        /// Checks if the given aConcept has related concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasRelatedConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistRelatedConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the related concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistRelatedConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result           = new RDFOntologyData();
            if (concept         != null && data != null) {
                var related      = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                            .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.RELATED.ToString()));
                foreach (var relatedConcept in related) {
                    result.AddFact((RDFOntologyFact)relatedConcept.TaxonomyObject);
                }

            }
            return result;
        }
        #endregion

        #endregion

        #region Mapping Relations

        #region BroadMatch
        /// <summary>
        /// Checks if the given aConcept has broadMatch concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasBroadMatchConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistBroadMatchConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the broadMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistBroadMatchConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result         = new RDFOntologyData();
            if (concept       != null && data != null) {
                var broadMatch = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToString()));
                foreach (var broadMatchConcept in broadMatch) {
                    result.AddFact((RDFOntologyFact)broadMatchConcept.TaxonomyObject);
                }
            }
            return result;
        }
        #endregion

        #region NarrowMatch
        /// <summary>
        /// Checks if the given aConcept has narrowMatch concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasNarrowMatchConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistNarrowMatchConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the narrowMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistNarrowMatchConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result          = new RDFOntologyData();
            if (concept        != null && data != null) {
                var narrowMatch = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                           .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToString()));
                foreach (var narrowMatchConcept in narrowMatch) {
                    result.AddFact((RDFOntologyFact)narrowMatchConcept.TaxonomyObject);
                }
            }
            return result;
        }
        #endregion

        #region RelatedMatch
        /// <summary>
        /// Checks if the given aConcept has relatedMatch concept the given bConcept within the given data
        /// </summary>
        public static Boolean HasRelatedMatchConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistRelatedMatchConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the relatedMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistRelatedMatchConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result           = new RDFOntologyData();
            if (concept         != null && data != null) {
                var relatedMatch = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                            .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.RELATED_MATCH.ToString()));
                foreach (var relatedMatchConcept in relatedMatch) {
                    result.AddFact((RDFOntologyFact)relatedMatchConcept.TaxonomyObject);
                }
            }
            return result;
        }
        #endregion

        #region CloseMatch
        /// <summary>
        /// Checks if the given aConcept skos:closeMatch the given bConcept within the given data
        /// </summary>
        public static Boolean HasCloseMatchConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistCloseMatchConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the skos:closeMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistCloseMatchConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result         = new RDFOntologyData();
            if (concept       != null && data != null) {
                var closeMatch = data.Relations.Assertions.SelectEntriesBySubject(concept)
                                                          .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.CLOSE_MATCH.ToString()));
                foreach (var closeMatchConcept in closeMatch) {
                    result.AddFact((RDFOntologyFact)closeMatchConcept.TaxonomyObject);
                }
            }
            return result;
        }
        #endregion

        #region ExactMatch
        /// <summary>
        /// Checks if the given aConcept skos:exactMatch the given bConcept within the given data
        /// </summary>
        public static Boolean HasExactMatchConcept(this RDFOntologyData data, RDFOntologyFact aConcept, RDFOntologyFact bConcept) {
            return (aConcept != null && bConcept != null && data != null ? data.EnlistExactMatchConceptsOf(aConcept).Facts.ContainsKey(bConcept.PatternMemberID) : false);
        }

        /// <summary>
        /// Enlists the skos:exactMatch concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistExactMatchConceptsOf(this RDFOntologyData data, RDFOntologyFact concept) {
            var result   = new RDFOntologyData();
            if (concept != null && data != null) {
                result   = data.EnlistExactMatchConceptsOfInternal(concept, null)
                               .RemoveFact(concept); //Safety deletion
            }
            return result;
        }

        /// <summary>
        /// Subsumes the "skos:exactMatch" taxonomy to discover direct and indirect exactmatches of the given concept
        /// </summary>
        internal static RDFOntologyData EnlistExactMatchConceptsOfInternal(this RDFOntologyData data, RDFOntologyFact concept, Dictionary<Int64, RDFOntologyFact> visitContext) {
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
                result         = result.UnionWith(data.EnlistExactMatchConceptsOfInternal((RDFOntologyFact)em.TaxonomyObject, visitContext));
            }

            return result;
        }
        #endregion

        #endregion

        #region Collection Relations
        /// <summary>
        /// Enlists the related concepts of the given concept within the given data
        /// </summary>
        public static RDFOntologyData EnlistMemberConceptsOf(this RDFOntologyData data, RDFOntologyFact collection) {
            var result         = new RDFOntologyData();
            if (collection    != null && data != null) {
                var members    = data.Relations.Assertions.SelectEntriesBySubject(collection)
                                                       .SelectEntriesByPredicate(RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.MEMBER.ToString()));
                foreach (var collMember in members) {

                    //Member is instance of skos:Concept
                    if (data.Relations.ClassType.SelectEntriesBySubject(collMember.TaxonomyObject)
                                                .SelectEntriesByObject(RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()))
                                                .EntriesCount > 0) {
                        result.AddFact((RDFOntologyFact)collMember.TaxonomyObject);
                    }

                    //Member is instance of skos:Collection
                    else if (data.Relations.ClassType.SelectEntriesBySubject(collMember.TaxonomyObject)
                                                     .SelectEntriesByObject(RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()))
                                                     .EntriesCount > 0) {
                        result = result.UnionWith(data.EnlistMemberConceptsOf((RDFOntologyFact)collMember.TaxonomyObject));
                    }

                }
            }
            return result;
        }
        #endregion

        #endregion

    }

}