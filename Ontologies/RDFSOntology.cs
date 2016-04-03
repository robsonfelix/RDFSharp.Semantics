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
    /// RDFSOntology represents an OWL-DL ontology implementation of RDFS vocabulary
    /// </summary>
    public static class RDFSOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the RDFS ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the RDFS ontology
        /// </summary>
        static RDFSOntology() {

            //Initialize
            Instance = new RDFOntology(new RDFResource(RDFVocabulary.RDFS.BASE_URI));

            //Classes
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.RDF.HTML));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.RDF.XML_LITERAL));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.RDFS.LITERAL));

            //Properties
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDF.TYPE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.SUB_CLASS_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.SUB_PROPERTY_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.DOMAIN));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyProperty(RDFVocabulary.RDFS.RANGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.COMMENT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.LABEL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.SEE_ALSO));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.RDFS.IS_DEFINED_BY));            

            //Taxonomies
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDF.HTML.ToString()),        Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDF.XML_LITERAL.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));

        }
        #endregion

    }

}