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

using RDFSharp.Model;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFBASEOntology represents a partial OWL-DL ontology implementation of structural vocabularies (RDF/RDFS/OWL/XSD).
    /// </summary>
    public static class RDFBASEOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the BASE ontology
        /// </summary>
        public static RDFOntology Instance { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the BASE ontology
        /// </summary>
        static RDFBASEOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("https://rdfsharp.codeplex.com/semantics/base#"));
            #endregion

            #region Classes

            //RDF+RDFS
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CONTAINER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CONTAINER_MEMBERSHIP_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.DATATYPE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.STATEMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.ALT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.BAG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.SEQ.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.LIST.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.NIL.ToRDFOntologyClass());

            //XSD
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass());

            //OWL
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DEPRECATED_CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.RESTRICTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DATA_RANGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ALL_DIFFERENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.INDIVIDUAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ONTOLOGY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ANNOTATION_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DATATYPE_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.DEPRECATED_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.OBJECT_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.ONTOLOGY_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.FUNCTIONAL_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.INVERSE_FUNCTIONAL_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.SYMMETRIC_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.TRANSITIVE_PROPERTY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.THING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.NOTHING.ToRDFOntologyClass());

            #endregion

            #region Properties

            //RDF+RDFS
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.FIRST.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.REST.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.LI.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.SUBJECT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.PREDICATE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.OBJECT.ToRDFOntologyObjectProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.VALUE.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.DOMAIN.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.RANGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.MEMBER.ToRDFOntologyProperty()); //plain property

            //OWL
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.DISJOINT_WITH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INVERSE_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ON_PROPERTY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ONE_OF.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.UNION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INTERSECTION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.COMPLEMENT_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.ALL_VALUES_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.SOME_VALUES_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.HAS_VALUE.ToRDFOntologyProperty()); //plain property
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.SAME_AS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.DIFFERENT_FROM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.DISTINCT_MEMBERS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.MIN_CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.MAX_CARDINALITY.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.VERSION_INFO.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.VERSION_IRI.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.IMPORTS.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToRDFOntologyAnnotationProperty());

            #endregion

            #endregion

            #region Taxonomies

            //SubClassOf
            var subClassOf = RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty();
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.STRING.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TIME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NAME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.SHORT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass()));

            #endregion

        }
        #endregion

    }

}