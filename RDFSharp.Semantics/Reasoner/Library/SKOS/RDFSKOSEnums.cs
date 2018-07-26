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

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    /// RDFSKOSEnums represents a collector for all the enumerations used by the "RDFSharp.Semantics.SKOS" namespace
    /// </summary>
    public static class RDFSKOSEnums {

        /// <summary>
        /// SKOSMemberType is an enumeration for supported types of skos:member objects
        /// </summary>
        public enum RDFSKOSMemberType {
            /// <summary>
            /// Member of the skos:Collection is a skos:Concept
            /// </summary>
            Concept = 0,
            /// <summary>
            /// Member of the skos:Collection is a skos:Collection
            /// </summary>
            Collection = 1
        }

    }

}