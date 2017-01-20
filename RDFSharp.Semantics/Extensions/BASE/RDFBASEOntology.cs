/*
   Copyright 2015-2017 Marco De Salvo

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
    /// RDFBASEOntology represents a partial OWL-DL ontology implementation of structural vocabularies (RDF/RDFS/OWL/XSD)
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
            Instance = new RDFOntology(new RDFResource("https://rdfsharp.codeplex.com/semantics/base_ontology#"), true);
            #endregion

            #region Classes

            //RDF+RDFS
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass());

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
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.THING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.NOTHING.ToRDFOntologyClass());

            #endregion

            #region Properties

            //RDF+RDFS
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDF.TYPE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.DOMAIN.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.RANGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.COMMENT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.SEE_ALSO.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToRDFOntologyAnnotationProperty());

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

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDF.XML_LITERAL.ToString()),          Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.STRING.ToString()),               Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BOOLEAN.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BASE64_BINARY.ToString()),        Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.HEX_BINARY.ToString()),           Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.FLOAT.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DECIMAL.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DOUBLE.ToString()),               Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.ANY_URI.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.QNAME.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NOTATION.ToString()),             Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DURATION.ToString()),             Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATETIME.ToString()),             Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TIME.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATETIME.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATETIME.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToString()),         Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR.ToString()),               Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH_DAY.ToString()),          Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_DAY.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToString()),    Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.STRING.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TOKEN.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.LANGUAGE.ToString()),             Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TOKEN.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NAME.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TOKEN.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NMTOKEN.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TOKEN.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NCNAME.ToString()),               Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NAME.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INTEGER.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DECIMAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.LONG.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToString()),     Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INT.ToString()),                  Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.LONG.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.SHORT.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BYTE.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.SHORT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.POSITIVE_INTEGER.ToString()),     Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToString()),        Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_INT.ToString()),         Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToString()),       Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_INT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_BYTE.ToString()),        Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToString()));

            #endregion

            #endregion

        }
        #endregion

    }

}