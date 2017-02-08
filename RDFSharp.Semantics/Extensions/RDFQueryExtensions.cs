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
using RDFSharp.Query;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFQueryExtensions represents an extension class for RDFSharp.Query functionalities
    /// </summary>
    public static class RDFQueryExtensions {

        /// <summary>
        /// Applies the given SPARQL SELECT query to the given ontology (which is converted into
        /// a RDF graph including semantic inferences in respect of the given export behavior)
        /// </summary>
        public static RDFSelectQueryResult ApplyToOntology(this RDFSelectQuery selectQuery,
                                                           RDFOntology ontology,
                                                           RDFSemanticsEnums.RDFOntologyInferenceExportBehavior ontologyInferenceExportBehavior = RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.ModelAndData) {
            var result           = new RDFSelectQueryResult();
            if (selectQuery     != null) {
                if (ontology    != null) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Ontology '{0}' is going to be converted into a graph on which the SPARQL SELECT query will be applied. Please, remember that if the ontology validation has raised warnings or errors, you may get unexpected query results due to inconsistent semantic inferences!", ontology.Value));

                    var ontGraph = ontology.ToRDFGraph(ontologyInferenceExportBehavior);
                    return selectQuery.ApplyToGraph(ontGraph);
                }
            }
            return result;
        }

        /// <summary>
        /// Applies the given SPARQL ASK query to the given ontology (which is converted into
        /// a RDF graph including semantic inferences in respect of the given export behavior)
        /// </summary>
        public static RDFAskQueryResult ApplyToOntology(this RDFAskQuery askQuery,
                                                        RDFOntology ontology,
                                                        RDFSemanticsEnums.RDFOntologyInferenceExportBehavior ontologyInferenceExportBehavior = RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.ModelAndData) {
            var result           = new RDFAskQueryResult();
            if (askQuery        != null) {
                if (ontology    != null) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Ontology '{0}' is going to be converted into a graph on which the SPARQL ASK query will be applied. Please, remember that if the ontology validation has raised warnings or errors, you may get unexpected query results due to inconsistent semantic inferences!", ontology.Value));

                    var ontGraph = ontology.ToRDFGraph(ontologyInferenceExportBehavior);
                    return askQuery.ApplyToGraph(ontGraph);
                }
            }
            return result;
        }

        /// <summary>
        /// Applies the given SPARQL CONSTRUCT query to the given ontology (which is converted into
        /// a RDF graph including semantic inferences in respect of the given export behavior)
        /// </summary>
        public static RDFConstructQueryResult ApplyToOntology(this RDFConstructQuery constructQuery,
                                                              RDFOntology ontology,
                                                              RDFSemanticsEnums.RDFOntologyInferenceExportBehavior ontologyInferenceExportBehavior = RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.ModelAndData) {
            var result           = new RDFConstructQueryResult(ontology.Value.ToString());
            if (constructQuery  != null) {
                if (ontology    != null) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Ontology '{0}' is going to be converted into a graph on which the SPARQL CONSTRUCT query will be applied. Please, remember that if the ontology validation has raised warnings or errors, you may get unexpected query results due to inconsistent semantic inferences!", ontology.Value));

                    var ontGraph = ontology.ToRDFGraph(ontologyInferenceExportBehavior);
                    return constructQuery.ApplyToGraph(ontGraph);
                }
            }
            return result;
        }

        /// <summary>
        /// Applies the given SPARQL DESCRIBE query to the given ontology (which is converted into
        /// a RDF graph including semantic inferences in respect of the given export behavior)
        /// </summary>
        public static RDFDescribeQueryResult ApplyToOntology(this RDFDescribeQuery describeQuery,
                                                             RDFOntology ontology,
                                                             RDFSemanticsEnums.RDFOntologyInferenceExportBehavior ontologyInferenceExportBehavior = RDFSemanticsEnums.RDFOntologyInferenceExportBehavior.ModelAndData) {
            var result           = new RDFDescribeQueryResult(ontology.Value.ToString());
            if (describeQuery   != null) {
                if (ontology    != null) {
                    RDFSemanticsEvents.RaiseSemanticsInfo(String.Format("Ontology '{0}' is going to be converted into a graph on which the SPARQL DESCRIBE query will be applied. Please, remember that if the ontology validation has raised warnings or errors, you may get unexpected query results due to inconsistent semantic inferences!", ontology.Value));

                    var ontGraph = ontology.ToRDFGraph(ontologyInferenceExportBehavior);
                    return describeQuery.ApplyToGraph(ontGraph);
                }
            }
            return result;
        }

    }

}