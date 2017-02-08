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

using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFModelExtensions represents an extension class for RDFSharp.Model functionalities
    /// </summary>
    public static class RDFModelExtensions {

        /// <summary>
        /// Gets an ontology class of the given nature from the given RDF resource
        /// </summary>
        public static RDFOntologyClass ToRDFOntologyClass(this RDFResource ontResource, 
                                                          RDFSemanticsEnums.RDFOntologyClassNature nature=RDFSemanticsEnums.RDFOntologyClassNature.OWL) {
            return new RDFOntologyClass(ontResource, nature);
        }

        /// <summary>
        /// Gets an ontology property from the given RDF resource
        /// </summary>
        internal static RDFOntologyProperty ToRDFOntologyProperty(this RDFResource ontResource) {
            return new RDFOntologyProperty(ontResource);
        }

        /// <summary>
        /// Gets an ontology object property from the given RDF resource
        /// </summary>
        public static RDFOntologyObjectProperty ToRDFOntologyObjectProperty(this RDFResource ontResource) {
            return new RDFOntologyObjectProperty(ontResource);
        }

        /// <summary>
        /// Gets an ontology datatype property from the given RDF resource
        /// </summary>
        public static RDFOntologyDatatypeProperty ToRDFOntologyDatatypeProperty(this RDFResource ontResource) {
            return new RDFOntologyDatatypeProperty(ontResource);
        }

        /// <summary>
        /// Gets an ontology annotation property from the given RDF resource
        /// </summary>
        public static RDFOntologyAnnotationProperty ToRDFOntologyAnnotationProperty(this RDFResource ontResource) {
            return new RDFOntologyAnnotationProperty(ontResource);
        }

        /// <summary>
        /// Gets an ontology fact from the given RDF resource
        /// </summary>
        public static RDFOntologyFact ToRDFOntologyFact(this RDFResource ontResource) {
            return new RDFOntologyFact(ontResource);
        }

        /// <summary>
        /// Gets an ontology literal from the given RDF literal
        /// </summary>
        public static RDFOntologyLiteral ToRDFOntologyLiteral(this RDFLiteral ontLiteral) {
            return new RDFOntologyLiteral(ontLiteral);
        }

    }

}