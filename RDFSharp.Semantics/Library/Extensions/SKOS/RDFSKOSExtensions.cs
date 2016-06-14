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

        #region AddFact
        /// <summary>
        /// Adds the given fact and its "skos:Concept" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSConcept(this RDFOntologyData ontologyData, 
                                                     RDFOntologyFact skosConcept) {
            if (ontologyData != null && skosConcept != null) {

                //Enforce taxonomy checks
                if (!ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass()))     && 
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.COLLECTION.ToRDFOntologyClass()))         && 
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.ORDERED_COLLECTION.ToRDFOntologyClass()))) {

                     //Declare the fact
                     ontologyData.AddFact(skosConcept);

                     //Add its classtype
                     ontologyData.AddClassTypeRelation(skosConcept, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));

                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:ConceptScheme" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSConceptScheme(this RDFOntologyData ontologyData, 
                                                           RDFOntologyFact skosConceptScheme) {
            if (ontologyData != null && skosConceptScheme != null) {

                //Enforce taxonomy checks
                if (!ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))            &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.COLLECTION.ToRDFOntologyClass()))         &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.ORDERED_COLLECTION.ToRDFOntologyClass()))) {

                     //Declare the fact
                     ontologyData.AddFact(skosConceptScheme);

                     //Add its classtype
                     ontologyData.AddClassTypeRelation(skosConceptScheme, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));

                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:Collection" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSCollection(this RDFOntologyData ontologyData, 
                                                        RDFOntologyFact skosCollection) {
            if (ontologyData != null && skosCollection != null) {

                //Enforce taxonomy checks
                if (!ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))            &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass()))     &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.ORDERED_COLLECTION.ToRDFOntologyClass()))) {

                     //Declare the fact
                     ontologyData.AddFact(skosCollection);

                     //Add its classtype
                     ontologyData.AddClassTypeRelation(skosCollection, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()));

                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given fact and its "skos:OrderedCollection" classtype relation to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSOrderedCollection(this RDFOntologyData ontologyData, 
                                                               RDFOntologyFact skosOrderedCollection) {
            if (ontologyData != null && skosOrderedCollection != null) {

                //Enforce taxonomy checks
                if (!ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosOrderedCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))        &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosOrderedCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass())) &&
                    !ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosOrderedCollection, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.COLLECTION.ToRDFOntologyClass())))     {

                    //Declare the fact
                    ontologyData.AddFact(skosOrderedCollection);

                    //Add its classtype
                    ontologyData.AddClassTypeRelation(skosOrderedCollection, RDFSKOSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString()));

                }

            }
            return ontologyData;
        }
        #endregion

        #region AddRelation
        /// <summary>
        /// Adds the given "skosConcept skos:inScheme skosConceptScheme" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSInScheme(this RDFOntologyData ontologyData,
                                                      RDFOntologyFact skosConcept,
                                                      RDFOntologyFact skosConceptScheme) {
            if (ontologyData != null && skosConcept != null && skosConceptScheme != null && !skosConcept.Equals(skosConceptScheme)) {

                //Enforce taxonomy checks
                if (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept,       RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))        &&
                    ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass()))) {

                    // skosConcept -> skos:inScheme -> skosConceptScheme
                    ontologyData.AddAssertionRelation(skosConcept, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.IN_SCHEME.ToString()), skosConceptScheme);
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given "skosCollection skos:member [skosConcept | skosConceptScheme]" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSMember(this RDFOntologyData ontologyData,
                                                    RDFOntologyFact skosCollection,
                                                    RDFOntologyFact skosConceptOrScheme) {
            if (ontologyData != null && skosConceptOrScheme != null && !skosCollection.Equals(skosConceptOrScheme)) {

                //Enforce taxonomy checks
                if (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosCollection,       RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.COLLECTION.ToRDFOntologyClass()))      &&
                    (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptOrScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))         ||
                     ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptOrScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass())))) {

                    // skosCollection -> skos:member -> skosConceptOrScheme
                    ontologyData.AddAssertionRelation(skosCollection, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.MEMBER.ToString()), skosConceptOrScheme);
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given "skosConcept skos:TopConceptOf skosConceptScheme" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSTopConceptOf(this RDFOntologyData ontologyData, 
                                                          RDFOntologyFact skosConcept,
                                                          RDFOntologyFact skosConceptScheme) {
            if (ontologyData != null && skosConcept != null && skosConceptScheme != null && !skosConcept.Equals(skosConceptScheme)) {

                //Enforce taxonomy checks
                if (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept,       RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass())) &&
                    ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass()))) {

                    // skosConcept -> skos:TopConceptOf -> skosConceptScheme
                    ontologyData.AddAssertionRelation(skosConcept, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()), skosConceptScheme);
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given "skosConceptScheme skos:HasTopConcept skosConcept" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSHasTopConcept(this RDFOntologyData ontologyData,
                                                           RDFOntologyFact skosConceptScheme,
                                                           RDFOntologyFact skosConcept) {
            if (ontologyData != null && skosConcept != null && skosConceptScheme != null && !skosConceptScheme.Equals(skosConcept)) {

                //Enforce taxonomy checks
                if (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConcept,       RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass())) &&
                    ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptScheme, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass()))) {

                    // skosConceptScheme -> skos:HasTopConcept -> skosConcept
                    ontologyData.AddAssertionRelation(skosConceptScheme, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()), skosConcept);
                }

            }
            return ontologyData;
        }

        /// <summary>
        /// Adds the given "skosConceptA skos:SemanticRelation skosConceptB" assertion to the ontology data
        /// </summary>
        public static RDFOntologyData AddSKOSSemanticRelation(this RDFOntologyData ontologyData,
                                                              RDFOntologyFact skosConceptA,
                                                              RDFOntologyFact skosConceptB) {
            if (ontologyData != null && skosConceptA != null && skosConceptB != null && !skosConceptA.Equals(skosConceptB)) {

                //Enforce taxonomy checks
                if (ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptA, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass())) &&
                    ontologyData.Relations.ClassType.ContainsEntry(new RDFOntologyTaxonomyEntry(skosConceptB, RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty(), RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass()))) {

                    // skosConceptA -> skos:SemanticRelation -> skosConceptB
                    ontologyData.AddAssertionRelation(skosConceptA, (RDFOntologyObjectProperty)RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()), skosConceptB);
                }

            }
            return ontologyData;
        }
        #endregion

        #endregion

    }

}