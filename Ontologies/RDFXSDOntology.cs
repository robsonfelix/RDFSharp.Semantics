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
    /// RDFXSDOntology represents an OWL-DL ontology implementation of XSD vocabulary
    /// </summary>
    internal static class RDFXSDOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the XSD ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the XSD ontology
        /// </summary>
        static RDFXSDOntology() {
            Instance = new RDFOntology(new RDFResource(RDFVocabulary.XSD.BASE_URI));
            
            //Classes
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

            //Taxonomies
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.STRING.ToString()),               RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BOOLEAN.ToString()),              RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BASE64_BINARY.ToString()),        RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.HEX_BINARY.ToString()),           RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.FLOAT.ToString()),                RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DECIMAL.ToString()),              RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DOUBLE.ToString()),               RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.ANY_URI.ToString()),              RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.QNAME.ToString()),                RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NOTATION.ToString()),             RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DURATION.ToString()),             RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATETIME.ToString()),             RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TIME.ToString()),                 RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString()),                 RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToString()),         RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR.ToString()),               RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH_DAY.ToString()),          RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_DAY.ToString()),                RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH.ToString()),              RDFSOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
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

    }

}