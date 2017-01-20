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

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFSemanticsOptions centralizes configuration and customization of behavior of many aspects of the library
    /// </summary>
    public static class RDFSemanticsOptions {

        /// <summary>
        /// Flag to enable automatic integration with Dublin-Core ontology
        /// </summary>
        public static Boolean EnableDCOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable automatic integration with Firend-of-a-Friend ontology
        /// </summary>
        public static Boolean EnableFOAFOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable automatic integration with W3C Geo ontology
        /// </summary>
        public static Boolean EnableGEOOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable automatic integration with Simple-Knowledge-Organization-System ontology
        /// </summary>
        public static Boolean EnableSKOSOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable automatic integration with Semantically-Interlinked-Online-Communities ontology
        /// </summary>
        public static Boolean EnableSIOCOntologyIntegration { get; set; }

    }

}