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
    /// RDFBASEOntology represents a partial ontology implementation of RDF/RDFS/OWL/XSD vocabularies
    /// </summary>
    public static class RDFBASEOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the BASE ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the BASE ontology
        /// </summary>
        static RDFBASEOntology() {

            //Initialize
            Instance = new RDFOntology(new RDFResource("http://rdfsharp.codeplex.com/default_ontology#"));

            //Classes
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.RDFS.LITERAL));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.RDF.XML_LITERAL));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.ANY_URI));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.BASE64_BINARY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.BOOLEAN));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.BYTE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.DATE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.DATETIME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.DECIMAL));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.DOUBLE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.DURATION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.FLOAT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.G_DAY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.G_MONTH));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.G_MONTH_DAY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.G_YEAR));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.G_YEAR_MONTH));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.HEX_BINARY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.INT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.INTEGER));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.LANGUAGE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.LONG));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NAME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NCNAME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NEGATIVE_INTEGER));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NMTOKEN));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NORMALIZED_STRING));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.NOTATION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.POSITIVE_INTEGER));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.QNAME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.SHORT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.STRING));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.TIME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.TOKEN));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.UNSIGNED_BYTE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.UNSIGNED_INT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.UNSIGNED_LONG));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.XSD.UNSIGNED_SHORT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.OWL.THING));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.OWL.NOTHING));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.OWL.INDIVIDUAL));

            //Properties
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDF.TYPE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.SUB_CLASS_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.DOMAIN));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.RANGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.EQUIVALENT_CLASS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.DISJOINT_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.EQUIVALENT_PROPERTY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.INVERSE_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ON_PROPERTY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ONE_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.UNION_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.INTERSECTION_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.COMPLEMENT_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.ALL_VALUES_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.SOME_VALUES_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.HAS_VALUE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.SAME_AS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.DIFFERENT_FROM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.MIN_CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.OWL.MAX_CARDINALITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.COMMENT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.LABEL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.SEE_ALSO));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.IS_DEFINED_BY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.VERSION_INFO));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.VERSION_IRI));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.IMPORTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.OWL.PRIOR_VERSION));

            //Taxonomies
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
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TIME.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()),                 Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToString()),         Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR.ToString()),               Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH_DAY.ToString()),          Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_DAY.ToString()),                Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH.ToString()),              Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
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

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the BASE ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the BASE ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the BASE ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String fact) {
            return Instance.Data.SelectFact(fact);
        }
        #endregion

    }

}
