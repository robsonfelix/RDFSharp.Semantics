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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyRegister is a singleton container for registered ontologies.
    /// </summary>
    public sealed class RDFOntologyRegister : IEnumerable<RDFOntology> {

        #region Properties
        /// <summary>
        /// Singleton instance of the RDFOntologyRegister class
        /// </summary>
        public static RDFOntologyRegister Instance { get; internal set; }

        /// <summary>
        /// Dictionary of ontologies composing the register
        /// </summary>
        internal Dictionary<String, RDFOntology> Register {
            get {
                return StaticRegister.Union(DynamicRegister).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        /// <summary>
        /// Dictionary of static ontologies composing the register
        /// </summary>
        internal Dictionary<String, RDFOntology> StaticRegister { get; set; }

        /// <summary>
        /// Dictionary of dynamic ontologies composing the register
        /// </summary>
        internal Dictionary<String, RDFOntology> DynamicRegister { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the singleton instance of the register
        /// </summary>
        static RDFOntologyRegister() {
            Instance                 = new RDFOntologyRegister();
            Instance.StaticRegister  = new Dictionary<String, RDFOntology>() { { "BASE", RDFBASEOntology.Instance } };
            Instance.DynamicRegister = new Dictionary<String, RDFOntology>();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the register's ontologies
        /// </summary>
        IEnumerator<RDFOntology> IEnumerable<RDFOntology>.GetEnumerator() {
            return Instance.Register.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the register's ontologies
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return Instance.Register.Values.GetEnumerator();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the given ontology to the register (if it has unique prefix.
        /// </summary>
        public static void AddOntology(String prefix, RDFOntology ontology) {
            if (prefix != null && prefix.Trim() != String.Empty && ontology != null) {
                if (GetOntologybyPrefix(prefix) == null) {
                    Instance.DynamicRegister.Add(prefix, ontology);
                }
            }
        }

        /// <summary>
        /// Retrieves an ontology by seeking presence of its prefix.
        /// </summary>
        public static RDFOntology GetOntologybyPrefix(String prefix) {
            if (prefix != null && prefix.Trim() != String.Empty) {
                 if (Instance.Register.Keys.Contains(prefix.Trim().ToUpperInvariant())) {
                     return Instance.Register[prefix.Trim().ToUpperInvariant()];
                 }
            }
            return null;
        }
        
        /// <summary>
        /// Gets the list of registered ontology prefixes
        /// </summary>
        public static List<String> GetRegisteredPrefixes() {
            return Instance.Register.Keys.ToList();
        }
        #endregion

    }

}