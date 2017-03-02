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
    /// RDFOntologyReasonerRule represents an inference rule executed by a reasoner
    /// </summary>
    public class RDFOntologyReasonerRule {

        #region Properties
        /// <summary>
        /// Name of the rule
        /// </summary>
        public String RuleName { get; internal set; }

        /// <summary>
        /// Description of the rule
        /// </summary>
        public String RuleDescription { get; internal set; }

        /// <summary>
        /// Delegate for the function which will be executed as body of the rule
        /// </summary>
        public delegate void ReasonerRuleDelegate(RDFOntology ontology, RDFOntologyReasonerReport report);

        /// <summary>
        /// Function which will be executed as body of the rule
        /// </summary>
        internal ReasonerRuleDelegate ExecuteRule { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build a reasoner rule with given name, description and delegate
        /// </summary>
        internal RDFOntologyReasonerRule(String ruleName, 
                                         String ruleDescription,
                                         ReasonerRuleDelegate ruleDelegate) {
            if (ruleName                    != null) {
                if (ruleDescription         != null) {
                    if (ruleDelegate        != null) {
                        this.RuleName        = ruleName.Trim().ToUpperInvariant();
                        this.RuleDescription = ruleDescription.Trim().ToUpperInvariant();
                        this.ExecuteRule     = ruleDelegate;
                    }
                    else {
                        throw new RDFSemanticsException("Cannot create RDFOntologyReasonerRule because given \"ruleDelegate\" parameter is null.");
                    }
                }
                else {
                    throw new RDFSemanticsException("Cannot create RDFOntologyReasonerRule because given \"ruleDescription\" parameter is null.");
                }
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntologyReasonerRule because given \"ruleName\" parameter is null.");
            }
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Gives the string representation of the reasoner rule
        /// </summary>
        public override String ToString() {
            return "RULE " + this.RuleName + ": " + this.RuleDescription;
        }
        #endregion

    }

}
