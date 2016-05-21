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
    /// RDFSKOSOntology represents an OWL-DL ontology implementation of SKOS vocabulary
    /// </summary>
    public static class RDFSKOSOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the SKOS ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the SKOS ontology
        /// </summary>
        static RDFSKOSOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/skos_ontology#"));
            #endregion

            #region Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SKOS.COLLECTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SKOS.CONCEPT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(new RDFOntologyUnionClass(new RDFResource("bnode:ConceptCollection")));
            #endregion

            #region Properties
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.ALT_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.BROADER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.CHANGE_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.CLOSE_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.DEFINITION.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.EDITORIAL_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.EXACT_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true).SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.EXAMPLE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.HISTORY_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.NARROWER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.IN_SCHEME.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.MEMBER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.MEMBER_LIST.ToRDFOntologyObjectProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.NOTATION.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.PREF_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.RELATED_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.RELATED.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.SCOPE_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToRDFOntologyObjectProperty());
            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString()), SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()));

            //DisjointWith
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()),       SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()),       SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()),          SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));

            //UnionOf
            Instance.Model.ClassModel.AddUnionOfRelation((RDFOntologyUnionClass)SelectClass("bnode:ConceptCollection"),    SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            Instance.Model.ClassModel.AddUnionOfRelation((RDFOntologyUnionClass)SelectClass("bnode:ConceptCollection"),    SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString()),  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.CLOSE_MATCH.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.EXACT_MATCH.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.CLOSE_MATCH.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString()),    (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToString()),        (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToString()),        (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString()), (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()),      (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.IN_SCHEME.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.RELATED_MATCH.ToString()),       (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.RELATED.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.RELATED_MATCH.ToString()),       (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.RELATED.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()));

            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROAD_MATCH.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROW_MATCH.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.BROADER_TRANSITIVE.ToString()),      (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.NARROWER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()));

            //Domain/Range
            SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()).SetDomain(SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));
            SelectProperty(RDFVocabulary.SKOS.HAS_TOP_CONCEPT.ToString()).SetRange(SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            SelectProperty(RDFVocabulary.SKOS.IN_SCHEME.ToString()).SetRange(SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));
            SelectProperty(RDFVocabulary.SKOS.MEMBER.ToString()).SetDomain(SelectClass(RDFVocabulary.SKOS.COLLECTION.ToString()));
            SelectProperty(RDFVocabulary.SKOS.MEMBER.ToString()).SetRange(SelectClass("bnode:ConceptCollection"));
            SelectProperty(RDFVocabulary.SKOS.MEMBER_LIST.ToString()).SetDomain(SelectClass(RDFVocabulary.SKOS.ORDERED_COLLECTION.ToString()));
            SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()).SetDomain(SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            SelectProperty(RDFVocabulary.SKOS.SEMANTIC_RELATION.ToString()).SetRange(SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            SelectProperty(RDFVocabulary.SKOS.TOP_CONCEPT_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SKOS.CONCEPT_SCHEME.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the SKOS ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the SKOS ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the SKOS ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            return Instance.Data.SelectFact(ontFact);
        }
        #endregion

    }

}
