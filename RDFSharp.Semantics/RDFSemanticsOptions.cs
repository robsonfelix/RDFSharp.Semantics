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
using System.Collections.Generic;

namespace RDFSharp.Semantics 
{

    /// <summary>
    /// RDFSemanticsOptions represents a collector for configuration options
    /// </summary>
    public static class RDFSemanticsOptions {

        #region Properties
        /// <summary>
        /// Dictionary for storing preferences about automatic extensions loading on ontology init
        /// </summary>
        internal static Dictionary<RDFSemanticsEnums.RDFOntologyExtensions, Boolean> ExtensionsLoading { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to initialize semantics options
        /// </summary>
        static RDFSemanticsOptions() {
            ExtensionsLoading = new Dictionary<RDFSemanticsEnums.RDFOntologyExtensions, Boolean>() {
                { RDFSemanticsEnums.RDFOntologyExtensions.DC,   false },
                { RDFSemanticsEnums.RDFOntologyExtensions.FOAF, false },
                { RDFSemanticsEnums.RDFOntologyExtensions.GEO,  false },
                { RDFSemanticsEnums.RDFOntologyExtensions.SIOC, false },
                { RDFSemanticsEnums.RDFOntologyExtensions.SKOS, false }
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Enables automatic loading of given extension
        /// </summary>
        public static void EnableExtensionLoading(RDFSemanticsEnums.RDFOntologyExtensions extension) {
            if (ExtensionsLoading.ContainsKey(extension)) {
                ExtensionsLoading[extension] = true;
            }            
        }

        /// <summary>
        /// Gets the status of automatic loading of given extension
        /// </summary>
        public static Boolean IsExtensionLoadingEnabled(RDFSemanticsEnums.RDFOntologyExtensions extension) {
            return (ExtensionsLoading.ContainsKey(extension) && ExtensionsLoading[extension]);
        }
        #endregion

    }

}