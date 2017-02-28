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
using System.Collections.Generic;
using System.Linq;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyReasoner represents an inference engine applied on a given ontology
    /// </summary>
    public class RDFOntologyReasoner {

        #region Properties
        /// <summary>
        /// List of rules applied by the reasoner
        /// </summary>
        internal List<RDFOntologyReasonerRule> Rules { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology reasoner
        /// </summary>
        public RDFOntologyReasoner() {
            this.Rules = new List<RDFOntologyReasonerRule>();
        }
        #endregion

        #region Methods

        #region Management
        /// <summary>
        /// Adds the given rule to the reasoner
        /// </summary>
        public RDFOntologyReasoner AddRule(RDFOntologyReasonerRule rule) {
            if (rule   != null) {
                if (this.SelectRule(rule.RuleName) == null) {
                    this.Rules.Add(rule);
                }
            }
            return this;
        }

        /// <summary>
        /// Removes the given rule from the reasoner
        /// </summary>
        public RDFOntologyReasoner RemoveRule(RDFOntologyReasonerRule rule) {
            if (rule   != null) {
                if (this.SelectRule(rule.RuleName) != null) {
                    this.Rules.RemoveAll(rs => rs.RuleName.ToUpperInvariant().Equals(rule.RuleName.Trim().ToUpperInvariant(), StringComparison.Ordinal));
                }
            }
            return this;
        }

        /// <summary>
        /// Selects the given rule from the resoner
        /// </summary>
        public RDFOntologyReasonerRule SelectRule(String ruleName = "") {
            return this.Rules.Find(r => r.RuleName.ToUpperInvariant().Equals(ruleName.Trim().ToUpperInvariant(), StringComparison.Ordinal));
        }
        #endregion

        #region Reasoning
        /// <summary>
        /// Triggers the execution of the given rule on the given ontology. 
        /// Returns a boolean indicating if new evidences have been found.
        /// </summary>
        internal Boolean TriggerRule(String ruleName, RDFOntology ontology, RDFOntologyReasonerReport report) {
            var reasonerRule  = this.SelectRule(ruleName);
            if (reasonerRule != null) {

                //Raise launching signal
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Launching execution of reasoning rule '{0}'", ruleName));

                //Launch the reasoning rule
                var oldCnt    = report.EvidencesCount;
                reasonerRule.ExecuteRule(ontology, report);
                var newCnt    = report.EvidencesCount - oldCnt;

                //Raise termination signal
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Completed execution of reasoning rule '{0}': found {1} new evidences", ruleName, newCnt));

                return newCnt > 0;
            }
            return false;
        }

        /// <summary>
        /// Applies the reasoner on the given ontology, producing a reasoning report.
        /// The ontology is progressively enriched with discovered inferences.
        /// </summary>
        public RDFOntologyReasonerReport ApplyToOntology(RDFOntology ontology) {
            if (ontology   != null) {
                var rReport = new RDFOntologyReasonerReport(ontology.Value.PatternMemberID);

                //Step 0: Cleanup ontology from inferences
                ontology.ClearInferences();

                //Step 1: Expand the ontology with the BASE ontology definitions
                ontology    = ontology.UnionWith(RDFBASEOntology.Instance);

                //Step 2: Apply class-based rules
                this.TriggerRule("EquivalentClassTransitivity",    ontology, rReport);
                this.TriggerRule("SubClassTransitivity",           ontology, rReport);
                this.TriggerRule("DisjointWithEntailment",         ontology, rReport);

                //Step 3: Apply property-based rules
                this.TriggerRule("EquivalentPropertyTransitivity", ontology, rReport);
                this.TriggerRule("SubPropertyTransitivity",        ontology, rReport);

                //Step 4: Apply data-based rules
                this.TriggerRule("SameAsTransitivity",             ontology, rReport);
                this.TriggerRule("DifferentFromEntailment",        ontology, rReport);
                this.TriggerRule("ClassTypeEntailment",            ontology, rReport);
                this.TriggerRule("DomainEntailment",               ontology, rReport);
                this.TriggerRule("RangeEntailment",                ontology, rReport);
                this.TriggerRule("InverseOfEntailment",            ontology, rReport);
                this.TriggerRule("SymmetricPropertyEntailment",    ontology, rReport);
                this.TriggerRule("TransitivePropertyEntailment",   ontology, rReport);
                this.TriggerRule("PropertyEntailment",             ontology, rReport);
                this.TriggerRule("SameAsEntailment",               ontology, rReport);

                //Step 5: Apply custom rules
                foreach (var sr in this.Rules.Where(r => r.RuleType == RDFSemanticsEnums.RDFOntologyReasonerRuleType.UserDefined)) {
                    this.TriggerRule(sr.RuleName, ontology, rReport);
                }

                //Step 6: Unexpand the ontology with the BASE ontology definitions
                ontology    = ontology.DifferenceWith(RDFBASEOntology.Instance);

                return rReport;
            }
            throw new RDFSemanticsException("Cannot apply RDFOntologyReasoner because given \"ontology\" parameter is null.");
        }
        #endregion

        #endregion

    }

}
