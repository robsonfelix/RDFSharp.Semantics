/*
   Copyright 2015-2018 Marco De Salvo

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
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    /// RDFSKOSOptions is a singleton container for options driving the SKOS engine behavior
    /// </summary>
    public static class RDFSKOSOptions {

        #region Properties
        /// <summary>
        /// If enabled, skos:exactMatch will be used to enhance entailments whenever semantically possible (default:TRUE)
        /// </summary>
        public static Boolean EnableExactMatchEntailments { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to initialize the singleton instance of RDFSKOSOptions
        /// </summary>
        static RDFSKOSOptions() {
            EnableExactMatchEntailments = true;
        }
        #endregion

    }

}