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
using System.Threading.Tasks;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyValidator analyzes a given ontology through a set of RDFS/OWL-DL rules
    /// in order to find error and inconsistency evidences affecting its model and data.
    /// </summary>
    public static class RDFOntologyValidator {

        #region Properties
        /// <summary>
        /// List of rules applied by the ontology validator
        /// </summary>
        internal static List<RDFOntologyValidatorRule> Rules { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Static-ctor to build an ontology validator
        /// </summary>
        static RDFOntologyValidator() {
            Rules = new List<RDFOntologyValidatorRule>() {

                //Vocabulary_Disjointness
                new RDFOntologyValidatorRule(
                    "Vocabulary_Disjointness", 
                    "This rule checks for disjointness of vocabulary of classes, properties and facts",
                    RDFBASEValidatorRuleset.Vocabulary_Disjointness),

                //Vocabulary_Declaration
                new RDFOntologyValidatorRule(
                    "Vocabulary_Declaration", 
                    "This rule checks for complete declaration of classes, properties and facts",
                    RDFBASEValidatorRuleset.Vocabulary_Declaration),

                //Domain_Range
                new RDFOntologyValidatorRule(
                    "Domain_Range", 
                    "This rule checks for consistency of rdfs:domain and rdfs:range axioms",
                    RDFBASEValidatorRuleset.Domain_Range),

                //InverseOf
                new RDFOntologyValidatorRule(
                    "InverseOf", 
                    "This rule checks for consistency of owl:inverseOf axioms",
                    RDFBASEValidatorRuleset.InverseOf),

                //SymmetricProperty
                new RDFOntologyValidatorRule(
                    "SymmetricProperty",
                    "This rule checks for consistency of owl:SymmetricProperty axioms",
                    RDFBASEValidatorRuleset.SymmetricProperty),

                //ClassType
                new RDFOntologyValidatorRule(
                    "ClassType", 
                    "This rule checks for consistency of rdf:type axioms",
                    RDFBASEValidatorRuleset.ClassType),

                //GlobalCardinalityConstraint
                new RDFOntologyValidatorRule(
                    "GlobalCardinalityConstraint", 
                    "This rule checks for consistency of global cardinality constraints",
                    RDFBASEValidatorRuleset.GlobalCardinalityConstraint),

                //LocalCardinalityConstraint
                new RDFOntologyValidatorRule(
                    "LocalCardinalityConstraint", 
                    "This rule checks for consistency of local cardinality constraints",
                    RDFBASEValidatorRuleset.LocalCardinalityConstraint),

                //Deprecation
                new RDFOntologyValidatorRule(
                    "Deprecation", 
                    "This rule checks for usage of deprecated classes and properties",
                    RDFBASEValidatorRuleset.Deprecation)

            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate the given ontology against a set of RDFS/OWL-DL rules, detecting errors and inconsistencies affecting its model and data.
        /// </summary>
        public static RDFOntologyValidatorReport Validate(this RDFOntology ontology) {
            var report          = new RDFOntologyValidatorReport();
            if (ontology       != null) {
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Validator is going to be applied on Ontology '{0}'...", ontology.Value));

                //STEP 1: Expand ontology
                var expOntology = ontology.UnionWith(RDFBASEOntology.Instance);

                //STEP 2: Execute rules                
                Parallel.ForEach(Rules, rule => {
                    report.MergeEvidences(rule.ExecuteRule(expOntology));
                });

                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Validator has been applied on Ontology '{0}': found " + report.EvidencesCount + " evidences.", ontology.Value));
            }
            return report;
        }
        #endregion

    }

}