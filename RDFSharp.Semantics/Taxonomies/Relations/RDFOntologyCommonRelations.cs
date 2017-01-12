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

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyCommonRelations represents a collector for foundational relations describing ontology resources.
    /// </summary>
    public class RDFOntologyCommonRelations {

        #region Properties
        /// <summary>
        /// Custom relations
        /// </summary>
        public RDFOntologyTaxonomy CustomRelations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology relations structure
        /// </summary>
        internal RDFOntologyCommonRelations() {
            this.CustomRelations = new RDFOntologyTaxonomy(RDFSemanticsEnums.RDFOntologyTaxonomyCategory.Generic);
        }
        #endregion

    }

}