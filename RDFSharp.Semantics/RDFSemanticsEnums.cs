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

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFSemanticsEnums represents a collector for all the enumerations used by the "RDFSharp.Semantics" namespace
    /// </summary>
    public static class RDFSemanticsEnums {

        /// <summary>
        /// RDFOntologyValidationEvidenceCategory represents an enumeration for possible categories of ontology validation evidence
        /// </summary>
        public enum RDFOntologyValidationEvidenceCategory {
            /// <summary>
            /// Specifications have not been violated: ontology may contain semantic inconsistencies
            /// </summary>
            Warning = 1,
            /// <summary>
            /// Specifications have been violated: ontology will contain semantic inconsistencies
            /// </summary>
            Error = 2
        };

        /// <summary>
        /// RDFOntologyReasoningEvidenceCategory represents an enumeration for possible categories of ontology reasoning evidence
        /// </summary>
        public enum RDFOntologyReasoningEvidenceCategory {
            /// <summary>
            /// Semantic inference has been generated within the ontology class model
            /// </summary>
            ClassModel = 1,
            /// <summary>
            /// Semantic inference has been generated within the ontology property model
            /// </summary>
            PropertyModel = 2,
            /// <summary>
            /// Semantic inference has been generated within the ontology data
            /// </summary>
            Data = 3
        };

        /// <summary>
        /// RDFOntologyReasoningRuleType represents an enumeration for possible types of a reasoning rule
        /// </summary>
        public enum RDFOntologyReasoningRuleType {
            /// <summary>
            /// RDFSharp-builtin reasoning rule
            /// </summary>
            Standard = 1,
            /// <summary>
            /// User-defined reasoning rule
            /// </summary>
            UserDefined = 2
        };

        /// <summary>
        /// RDFOntologyInferenceType represents an enumeration for possible types of a semantic inference
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

        /// <summary>
        /// RDFOntologyTaxonomyCategory represents an enumeration for supported types of taxonomy
        /// </summary>
        public enum RDFOntologyTaxonomyCategory {
            /// <summary>
            /// Taxonomy is not related to ontology model or ontology data
            /// </summary>
            Generic = 0,
            /// <summary>
            /// Taxonomy is related to ontology model
            /// </summary>
            Model = 1,
            /// <summary>
            /// Taxonomy is related to ontology data
            /// </summary>
            Data = 2
        };

    }

}