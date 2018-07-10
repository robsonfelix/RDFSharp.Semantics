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
        public static void AddCollection(RDFOntologyData ontologyData, RDFResource collection) {
            if (ontologyData       != null && collection != null) {
                var collectionFact  = new RDFOntologyFact(collection);
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
        public static void AddConcept(RDFOntologyData ontologyData, RDFResource concept) {
            if (ontologyData    != null && concept != null) {
                var conceptFact  = new RDFOntologyFact(concept);
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
        public static void AddConceptScheme(RDFOntologyData ontologyData, RDFResource conceptScheme) {
            if (ontologyData          != null && conceptScheme != null) {
                var conceptSchemeFact  = new RDFOntologyFact(conceptScheme);
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
        public static void AddOrderedCollection(RDFOntologyData ontologyData, RDFResource orderedCollection) {
            if (ontologyData              != null && orderedCollection != null) {
                var orderedCollectionFact  = new RDFOntologyFact(orderedCollection);
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
        public static void AddLabel(RDFOntologyData ontologyData, RDFResource label) {
            if (ontologyData  != null && label != null) {
                var labelFact  = new RDFOntologyFact(label);
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
        /// Adds the "concept -> skos:inScheme -> conceptScheme" assertion to the ontology data
        /// </summary>
        public static void AddInSchemeAssertion(RDFOntologyData ontologyData, RDFResource concept, RDFResource conceptScheme) {
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
        }
        
        /// <summary>
        /// Adds the "conceptScheme -> skos:hasTopConcept -> concept" assertion to the ontology data
        /// </summary>
        public static void AddHasTopConceptAssertion(RDFOntologyData ontologyData, RDFResource conceptScheme, RDFResource concept) {
            if (ontologyData             != null && concept != null && conceptScheme != null) {
                var conceptSchemeFact     = new RDFOntologyFact(conceptScheme);
                var conceptFact           = new RDFOntologyFact(concept);
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
        /// Adds the "concept -> skos:topConceptOf -> conceptScheme" assertion to the ontology data
        /// </summary>
        public static void AddTopConceptOfAssertion(RDFOntologyData ontologyData, RDFResource concept, RDFResource conceptScheme) {
            if (ontologyData            != null && concept != null && conceptScheme != null) {
                var conceptFact          = new RDFOntologyFact(concept);
                var conceptSchemeFact    = new RDFOntologyFact(conceptScheme);
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
        /// Adds the "aConcept -> skos:semanticRelation -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddSemanticRelationAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData != null && aConcept != null && bConcept != null) {
                var aConceptFact             = new RDFOntologyFact(aConcept);
                var bConceptFact             = new RDFOntologyFact(bConcept);
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
        /// Adds the "aConcept -> skos:related -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddRelatedAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData       != null && aConcept != null && bConcept != null) {
                var aConceptFact    = new RDFOntologyFact(aConcept);
                var bConceptFact    = new RDFOntologyFact(bConcept);
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
        /// Adds the "aConcept -> skos:broader -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddBroaderAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData       != null && aConcept != null && bConcept != null) {
                var aConceptFact    = new RDFOntologyFact(aConcept);
                var bConceptFact    = new RDFOntologyFact(bConcept);
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
        /// Adds the "aConcept -> skos:broaderTransitive -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddBroaderTransitiveAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData                 != null && aConcept != null && bConcept != null) {
                var aConceptFact              = new RDFOntologyFact(aConcept);
                var bConceptFact              = new RDFOntologyFact(bConcept);
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
        /// Adds the "aConcept -> skos:narrower -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData        != null && aConcept != null && bConcept != null) {
                var aConceptFact     = new RDFOntologyFact(aConcept);
                var bConceptFact     = new RDFOntologyFact(bConcept);
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
        /// Adds the "aConcept -> skos:narrowerTransitive -> bConcept" assertion to the ontology data
        /// </summary>
        public static void AddNarrowerTransitiveAssertion(RDFOntologyData ontologyData, RDFResource aConcept, RDFResource bConcept) {
            if (ontologyData                  != null && aConcept != null && bConcept != null) {
                var aConceptFact               = new RDFOntologyFact(aConcept);
                var bConceptFact               = new RDFOntologyFact(bConcept);
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
        #endregion

    }

}
