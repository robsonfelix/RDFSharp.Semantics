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
using System.Threading.Tasks;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyValidator analyzes a given ontology through a predefined set of RDFS/OWL-DL rules
    /// in order to find error and inconsistency evidences affecting its model and data.
    /// </summary>
    internal class RDFOntologyValidator {

        #region Properties
        /// <summary>
        /// List of rules applied by the ontology validator
        /// </summary>
        internal List<RDFOntologyValidatorRule> Rules { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an ontology validator
        /// </summary>
        internal RDFOntologyValidator() {
            this.Rules = new List<RDFOntologyValidatorRule>() {

                //Vocabulary_Disjointness
                new RDFOntologyValidatorRule(
                    "Vocabulary_Disjointness", 
                    "This rule checks for disjointness of vocabulary of classes, properties and facts",
                    RDFBASEOntologyValidatorRuleSet.Vocabulary_Disjointness),

                //Vocabulary_Declaration
                new RDFOntologyValidatorRule(
                    "Vocabulary_Declaration", 
                    "This rule checks for complete declaration of classes, properties and facts",
                    RDFBASEOntologyValidatorRuleSet.Vocabulary_Declaration),

                //Domain_Range
                new RDFOntologyValidatorRule(
                    "Domain_Range", 
                    "This rule checks for consistency of rdfs:domain and rdfs:range axioms",
                    RDFBASEOntologyValidatorRuleSet.Domain_Range),

                //InverseOf
                new RDFOntologyValidatorRule(
                    "InverseOf", 
                    "This rule checks for consistency of owl:inverseOf axioms",
                    RDFBASEOntologyValidatorRuleSet.InverseOf),

                //SymmetricProperty
                new RDFOntologyValidatorRule(
                    "SymmetricProperty",
                    "This rule checks for consistency of owl:SymmetricProperty axioms",
                    RDFBASEOntologyValidatorRuleSet.SymmetricProperty),

                //ClassType
                new RDFOntologyValidatorRule(
                    "ClassType", 
                    "This rule checks for consistency of rdf:type axioms",
                    RDFBASEOntologyValidatorRuleSet.ClassType),

                //GlobalCardinalityConstraint
                new RDFOntologyValidatorRule(
                    "GlobalCardinalityConstraint", 
                    "This rule checks for consistency of global cardinality constraints",
                    RDFBASEOntologyValidatorRuleSet.GlobalCardinalityConstraint),

                //LocalCardinalityConstraint
                new RDFOntologyValidatorRule(
                    "LocalCardinalityConstraint", 
                    "This rule checks for consistency of local cardinality constraints",
                    RDFBASEOntologyValidatorRuleSet.LocalCardinalityConstraint),

                //Deprecation
                new RDFOntologyValidatorRule(
                    "Deprecation", 
                    "This rule checks for usage of deprecated classes and properties",
                    RDFBASEOntologyValidatorRuleSet.Deprecation)

            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Analyzes the given ontology and produces a detailed report of found evidences
        /// </summary>
        internal RDFOntologyValidatorReport AnalyzeOntology(RDFOntology ontology) {
            var report = new RDFOntologyValidatorReport(ontology.Value.PatternMemberID);

            //Execute the validation rules
            Parallel.ForEach(this.Rules, rule => {
                rule.ExecuteRule(ontology, report);
            });
            
            return report;
        }
        #endregion

    }

}