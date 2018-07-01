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

namespace RDFSharp.Semantics.Reasoner
{

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
        internal RDFOntologyReasoner() {
            this.Rules = new List<RDFOntologyReasonerRule>();
        }

        /// <summary>
        /// Creates an empty ontology reasoner
        /// </summary>
        public static RDFOntologyReasoner CreateNew() {
            return new RDFOntologyReasoner();
        }
        #endregion

        #region Methods

        #region Management
        /// <summary>
        /// Adds the given rule to the reasoner
        /// </summary>
        public RDFOntologyReasoner WithRule(RDFOntologyReasonerRule rule) {
            if (rule   != null) {
                if (this.SelectRule(rule.RuleName) == null) {
                    this.Rules.Add(rule);
                }
            }
            return this;
        }

        /// <summary>
        /// Selects the given rule from the resoner
        /// </summary>
        internal RDFOntologyReasonerRule SelectRule(String ruleName = "") {
            return this.Rules.FirstOrDefault(r => r.RuleName.Equals(ruleName.Trim().ToUpperInvariant(), StringComparison.Ordinal));
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
                var infCount  = reasonerRule.ExecuteRule(ontology, report);
                
                //Raise termination signal
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Completed execution of reasoning rule '{0}': found {1} new evidences", ruleName, infCount));

                return (infCount > 0);
            }
            return false;
        }

        /// <summary>
        /// Applies the reasoner on the given ontology, producing a reasoning report.
        /// </summary>
        public RDFOntologyReasonerReport ApplyToOntology(ref RDFOntology ontology) {
            if (ontology   != null) {
                var report  = new RDFOntologyReasonerReport();
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner is going to be applied on Ontology '{0}'", ontology.Value));

                //Expand ontology
                ontology    = ontology.UnionWith(RDFBASEOntology.Instance);

                #region Triggers
                //Apply basic rules
                var eqct    = this.TriggerRule("EquivalentClassTransitivity",    ontology, report);
                var sbct    = this.TriggerRule("SubClassTransitivity",           ontology, report);
                var dwen    = this.TriggerRule("DisjointWithEntailment",         ontology, report);
                var eqpt    = this.TriggerRule("EquivalentPropertyTransitivity", ontology, report);
                var sbpt    = this.TriggerRule("SubPropertyTransitivity",        ontology, report);
                var smat    = this.TriggerRule("SameAsTransitivity",             ontology, report);
                var dffe    = this.TriggerRule("DifferentFromEntailment",        ontology, report);

                //Apply extended rules
                var dome    = this.TriggerRule("DomainEntailment",               ontology, report);
                var rane    = this.TriggerRule("RangeEntailment",                ontology, report);
                var clte    = this.TriggerRule("ClassTypeEntailment",            ontology, report);
                var iofe    = this.TriggerRule("InverseOfEntailment",            ontology, report);
                var sype    = this.TriggerRule("SymmetricPropertyEntailment",    ontology, report);
                var trpe    = this.TriggerRule("TransitivePropertyEntailment",   ontology, report);
                var prpe    = this.TriggerRule("PropertyEntailment",             ontology, report);
                var smae    = this.TriggerRule("SameAsEntailment",               ontology, report);
                #endregion

                //Unexpand ontology
                ontology    = ontology.DifferenceWith(RDFBASEOntology.Instance);

                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner has been applied on Ontology '{0}'", ontology.Value));
                return report;
            }
            throw new RDFSemanticsException("Cannot apply RDFOntologyReasoner because given \"ontology\" parameter is null.");
        }
        #endregion

        #endregion

    }

}
