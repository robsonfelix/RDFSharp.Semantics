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

namespace RDFSharp.Semantics 
{

    /// <summary>
    /// RDFSemanticsOptions represents a collection of configuration options for customizing the behavior of the library
    /// </summary>
    public sealed class RDFSemanticsOptions {

        #region Properties
        /// <summary>
        /// Flag to enable support for built-in implementation of "Dublin Core Metadata" ontology (default: TRUE)
        /// </summary>
        public static Boolean EnableDCOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable support for built-in implementation of "Friend-of-a-Friend" ontology (default: TRUE)
        /// </summary>
        public static Boolean EnableFOAFOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable support for built-in implementation of "W3C GEO" ontology (default: TRUE)
        /// </summary>
        public static Boolean EnableGEOOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable support for built-in implementation of "W3C SKOS" ontology (default: TRUE)
        /// </summary>
        public static Boolean EnableSKOSOntologyIntegration { get; set; }

        /// <summary>
        /// Flag to enable support for built-in implementation of "Semantically-Interlinked Online Communities" ontology (default: TRUE)
        /// </summary>
        public static Boolean EnableSIOCOntologyIntegration { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to initialize the semantics options
        /// </summary>
        static RDFSemanticsOptions() {
            EnableDCOntologyIntegration   = true;
            EnableFOAFOntologyIntegration = true;
            EnableGEOOntologyIntegration  = true;
            EnableSKOSOntologyIntegration = true;
            EnableSIOCOntologyIntegration = true;
        }
        #endregion

    }

}