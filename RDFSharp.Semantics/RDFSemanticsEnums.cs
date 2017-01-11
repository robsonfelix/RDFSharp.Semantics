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

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFSemanticsEnums represents a collector for all the enumerations used by the "RDFSharp.Semantics" namespace
    /// </summary>
    public static class RDFSemanticsEnums {

        /// <summary>
        /// RDFOntologyTaxonomyCategory represents an enumeration for supported types of taxonomy
        /// </summary>
        public enum RDFOntologyTaxonomyCategory {
            /// <summary>
            /// Taxonomy is not specific of ontology model or ontology data
            /// </summary>
            Generic = 0,
            /// <summary>
            /// Taxonomy is specific of ontology model
            /// </summary>
            Model = 1,
            /// <summary>
            /// Taxonomy is specific of ontology data
            /// </summary>
            Data = 2
        };

        /// <summary>
        /// RDFOntologyInferenceType represents an enumeration for possible types of semantic inference
        /// </summary>
        public enum RDFOntologyInferenceType {
            /// <summary>
            /// Not a semantic inference
            /// </summary>
            None = 0,
            /// <summary>
            /// Semantic inference generated during ontology modeling
            /// </summary>
            API = 1,
            /// <summary>
            /// Semantic inference generated during ontology reasoning
            /// </summary>
            Reasoner = 2
        };

        /// <summary>
        /// RDFOntologyInferenceExportBehavior represents an enumeration for supported inference export behaviors
        /// </summary>
        public enum RDFOntologyInferenceExportBehavior {
            /// <summary>
            /// Does not export any semantic inference
            /// </summary>
            None = 0,
            /// <summary>
            /// Exports only semantic inferences of ontology model
            /// </summary>
            OnlyModel = 1,
            /// <summary>
            /// Exports only semantic inferences of ontology data
            /// </summary>
            OnlyData = 2,
            /// <summary>
            /// Exports both semantic inferences of ontology model and ontology data 
            /// </summary>
            ModelAndData = 3
        };

    }

}