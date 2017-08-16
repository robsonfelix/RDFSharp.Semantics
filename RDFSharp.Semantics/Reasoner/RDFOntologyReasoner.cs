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
        /// Returns the count of new evidences found.
        /// </summary>
        internal Int32 TriggerRule(String ruleName, RDFOntology ontology, RDFOntologyReasonerReport report, RDFReasonerOptions options) {
            var inferenceCounter = 0;

            var reasonerRule     = this.SelectRule(ruleName);
            if (reasonerRule    != null) {

                //Raise launching signal
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Launching execution of reasoning rule '{0}'", ruleName));

                //Launch the reasoning rule
                inferenceCounter = reasonerRule.ExecuteRule(ontology, report, options);
                
                //Raise termination signal
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Completed execution of reasoning rule '{0}': found {1} new evidences", ruleName, inferenceCounter));

            }

            return inferenceCounter;
        }

        /// <summary>
        /// Applies the reasoner on the given ontology, producing a detailed reasoning report.
        /// </summary>
        public RDFOntologyReasonerReport ApplyToOntology(RDFOntology ontology) {
            return this.ApplyToOntology(ontology, new RDFReasonerOptions());
        }

        /// <summary>
        /// Applies the reasoner on the given ontology, producing a detailed reasoning report.
        /// </summary>
        public RDFOntologyReasonerReport ApplyToOntology(RDFOntology ontology, RDFReasonerOptions options) {
            if (ontology    != null) {
                var report   = new RDFOntologyReasonerReport(ontology.Value.PatternMemberID);

                //Cleanup ontology
                if (options == null)
                    options  = new RDFReasonerOptions();
                if (options.ClearExistingInferences)
                    ontology.ClearInferences();

                //Expand ontology
                ontology     = ontology.UnionWith(RDFBASEOntology.Instance);

                #region Triggers
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner is going to be applied on Ontology '{0}': existing inferences " + (options.ClearExistingInferences ? "have been" : "have not been") + " cleared.", ontology.Value));

                //Apply model rules
                var infCount = 0;
                infCount    += this.TriggerRule("EquivalentClassTransitivity", ontology, report, options);
                infCount    += this.TriggerRule("SubClassTransitivity", ontology, report, options);
                infCount    += this.TriggerRule("DisjointWithEntailment", ontology, report, options);
                infCount    += this.TriggerRule("EquivalentPropertyTransitivity", ontology, report, options);
                infCount    += this.TriggerRule("SubPropertyTransitivity", ontology, report, options);

                //Apply data rules
                infCount    += this.TriggerRule("SameAsTransitivity", ontology, report, options);
                infCount    += this.TriggerRule("DifferentFromEntailment", ontology, report, options);
                infCount    += this.TriggerRule("ClassTypeEntailment", ontology, report, options);
                infCount    += this.TriggerRule("DomainEntailment", ontology, report, options);
                infCount    += this.TriggerRule("RangeEntailment", ontology, report, options);
                infCount    += this.TriggerRule("InverseOfEntailment", ontology, report, options);
                infCount    += this.TriggerRule("SymmetricPropertyEntailment", ontology, report, options);
                infCount    += this.TriggerRule("TransitivePropertyEntailment", ontology, report, options);
                infCount    += this.TriggerRule("PropertyEntailment", ontology, report, options);
                infCount    += this.TriggerRule("SameAsEntailment", ontology, report, options);

                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner has been applied on Ontology '{0}': found {1} new inferences.", ontology.Value, infCount));
                #endregion

                //Unexpand ontology
                ontology     = ontology.DifferenceWith(RDFBASEOntology.Instance);

                return report;
            }
            throw new RDFSemanticsException("Cannot apply RDFOntologyReasoner because given \"ontology\" parameter is null.");
        }
        #endregion

        #endregion

    }

    #region RDFReasonerOptions
    /// <summary>
    /// RDFReasonerOptions represents a configuration given to a reasoner for customizing its behavior
    /// </summary>
    public class RDFReasonerOptions {

        #region Properties
        /// <summary>
        /// If true (default) the reasoner will clear existing inferences from the ontology before starting a new analysis.
        /// </summary>
        public Boolean ClearExistingInferences { get; set; }

        /// <summary>
        /// If true (default) the reasoner will automatically merge inferences into the ontology during the analysis.
        /// </summary>
        public Boolean AutoMergeInferences { get; set; }
        #endregion

        #region Ctors
        public RDFReasonerOptions() {
            this.ClearExistingInferences = true;
            this.AutoMergeInferences = true;
        }
        #endregion

    }
    #endregion

}
