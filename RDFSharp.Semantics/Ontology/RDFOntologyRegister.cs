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
using System.Collections;
using System.Collections.Generic;
using RDFSharp.Model;

namespace RDFSharp.Semantics 
{

    /// <summary>
    /// RDFOntologyRegister is a singleton container for registered ontologies.
    /// </summary>
    public sealed class RDFOntologyRegister: IEnumerable<RDFOntology> {

        #region Properties
        /// <summary>
        /// Singleton instance of the RDFOntologyRegister class
        /// </summary>
        internal static RDFOntologyRegister Instance { get; set; }

        /// <summary>
        /// Dictionary of registered ontologies
        /// </summary>
        internal Dictionary<String, RDFOntology> Register { get; set; }

        /// <summary>
        /// Count of the register's ontologies
        /// </summary>
        public static Int32 OntologiesCount {
            get { return Instance.Register.Count; }
        }

        /// <summary>
        /// Gets the enumerator on the register's ontologies for iteration
        /// </summary>
        public static IEnumerator<RDFOntology> OntologiesEnumerator {
            get { return Instance.Register.Values.GetEnumerator(); }
        }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the singleton instance of the register
        /// </summary>
        static RDFOntologyRegister() {
            Instance          = new RDFOntologyRegister();
            Instance.Register = new Dictionary<String, RDFOntology>();

            //Initialize the register with support for BASE ontology
            AddOntology("base", RDFBASEOntology.Instance);
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes an untyped enumerator on the register's ontologies
        /// </summary>
        IEnumerator<RDFOntology> IEnumerable<RDFOntology>.GetEnumerator() {
            return Instance.Register.Values.GetEnumerator();
        }

        /// <summary>
        /// Exposes a typed enumerator on the register's ontologies
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return Instance.Register.Values.GetEnumerator();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the given ontology to the register, using the given prefix as key
        /// </summary>
        public static void AddOntology(String prefix, RDFOntology ontology) {
            if (prefix != null && prefix.Trim() != String.Empty && ontology != null) {
                if (!Instance.Register.ContainsKey(prefix.Trim().ToUpperInvariant())) {
                     Instance.Register.Add(prefix.Trim().ToUpperInvariant(), ontology);
                }
            }
        }

        /// <summary>
        /// Removes the given ontology from the register, using the given prefix as key
        /// </summary>
        public static void RemoveOntology(String prefix) {
            if (prefix != null && prefix.Trim() != String.Empty) {
                if (!prefix.Trim().ToUpperInvariant().Equals("BASE")) {
                     Instance.Register.Remove(prefix.Trim().ToUpperInvariant());
                }
                else {

                    //Raise semantic warning to inform the user: BASE ontology cannot be removed from the ontology register
                    RDFSemanticsEvents.RaiseSemanticsWarning("BASE ontology cannot be removed from the ontology register.");

                }
            }
        }
        #endregion

    }

}