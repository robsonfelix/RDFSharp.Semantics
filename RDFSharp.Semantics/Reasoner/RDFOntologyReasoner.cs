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
    /// RDFOntologyReasoner represents an inference engine applied on a given ontology
    /// </summary>
    public sealed class RDFOntologyReasoner : IEnumerable<RDFOntologyReasonerRule> {

        #region Properties
        /// <summary>
        /// Description of the reasoner
        /// </summary>
        public String ReasonerDescription { get; internal set; }

        /// <summary>
        /// Count of the rules composing the reasoner
        /// </summary>
        public Int32 RulesCount {
            get { return this.Rules.Count; }
        }

        /// <summary>
        /// List of rules applied by the reasoner
        /// </summary>
        internal List<RDFOntologyReasonerRule> Rules { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology reasoner
        /// </summary>
        public RDFOntologyReasoner(String reasonerDescription) {
            this.ReasonerDescription = reasonerDescription;
            this.Rules               = new List<RDFOntologyReasonerRule>();
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the reasoner's rules
        /// </summary>
        IEnumerator<RDFOntologyReasonerRule> IEnumerable<RDFOntologyReasonerRule>.GetEnumerator() {
            return this.Rules.GetEnumerator();
        }

        /// <summary>
        /// Exposes an untyped enumerator on the reasoner's rules
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.Rules.GetEnumerator();
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the given rule to the reasoner
        /// </summary>
        public RDFOntologyReasoner AddRule(RDFOntologyReasonerRule rule) {
            if (rule   != null) {
                if (this.SelectRuleByName(rule.RuleName) == null) {
                    this.Rules.Add(rule);
                }
            }
            return this;
        }
        #endregion

        #region Select
        /// <summary>
        /// Selects the given rule from the resoner
        /// </summary>
        public RDFOntologyReasonerRule SelectRuleByName(String ruleName) {
            if (ruleName  != null &&  ruleName.Trim() != String.Empty)
                return this.Rules.FirstOrDefault(r => r.RuleName.Equals(ruleName.Trim().ToUpperInvariant(), StringComparison.Ordinal));
            else
                return null;
        }
        #endregion

        #region Apply
        /// <summary>
        /// Applies the reasoner on the given ontology, producing a reasoning report.
        /// </summary>
        public RDFOntologyReasonerReport ApplyToOntology(ref RDFOntology ontology) {
            if (ontology           != null) {
                var report          = new RDFOntologyReasonerReport();
                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner is going to be applied on Ontology '{0}'", ontology.Value));

                //STEP 1: Expand ontology with BASE definitions
                ontology            = ontology.UnionWith(RDFBASEOntology.Instance);

                //STEP 2: Execute BASE rules
                var baseRules       = this.Rules.Where(x => x.RulePriority <= RDFBASERuleset.RulesCount)
                                                .OrderBy(x => x.RulePriority);
                foreach (var bRule in baseRules) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Launching execution of reasoning rule '{0}'", bRule));
                    var infCounter  = bRule.ExecuteRule(ontology, report);
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Completed execution of reasoning rule '{0}': found {1} new evidences", bRule, infCounter));
                }

                //STEP 3: Execute custom rules
                var customRules     = this.Rules.Where(x => x.RulePriority > RDFBASERuleset.RulesCount)
                                                .OrderBy(x => x.RulePriority);
                foreach (var cRule in customRules) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Launching execution of reasoning rule '{0}'", cRule));
                    var infCounter  = cRule.ExecuteRule(ontology, report);
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Completed execution of reasoning rule '{0}': found {1} new evidences", cRule, infCounter));
                }

                //STEP 4: Unexpand ontology from  BASE definitions
                ontology            = ontology.DifferenceWith(RDFBASEOntology.Instance);

                RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Reasoner has been applied on Ontology '{0}'", ontology.Value));
                return report;
            }
            throw new RDFSemanticsException("Cannot apply RDFOntologyReasoner because given \"ontology\" parameter is null.");
        }
        #endregion

        #endregion

    }

}
