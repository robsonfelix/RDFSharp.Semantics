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
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    /// RDFSKOSChecker is responsible for implicit validation of SKOS ontologies during modeling
    /// </summary>
    internal static class RDFSKOSChecker {

        #region Assertions
        /// <summary>
        /// Checks if the skos:broader/skos:broaderTransitive/skos:broadMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckBroaderAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddBroaderAssert = false;

            //Avoid clash with hierarchical relations
            canAddBroaderAssert     = !RDFSKOSHelper.HasNarrowerConcept(ontologyData, aConceptFact, bConceptFact);

            //Avoid clash with associative relations
            if (canAddBroaderAssert) {
                canAddBroaderAssert = !RDFSKOSHelper.HasRelatedConcept(ontologyData, aConceptFact, bConceptFact);
            }

            //Avoid clash with mapping relations
            if (canAddBroaderAssert) {
                canAddBroaderAssert = (!RDFSKOSHelper.HasNarrowMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                       !RDFSKOSHelper.HasCloseMatchConcept(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.HasExactMatchConcept(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.HasRelatedMatchConcept(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddBroaderAssert;
        }

        /// <summary>
        /// Checks if the skos:narrower/skos:narrowerTransitive/skos:narrowMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckNarrowerAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddNarrowerAssert = false;

            //Avoid clash with hierarchical relations
            canAddNarrowerAssert     = !RDFSKOSHelper.HasBroaderConcept(ontologyData, aConceptFact, bConceptFact);

            //Avoid clash with associative relations
            if (canAddNarrowerAssert) {
                canAddNarrowerAssert = !RDFSKOSHelper.HasRelatedConcept(ontologyData, aConceptFact, bConceptFact);
            }

            //Avoid clash with mapping relations
            if (canAddNarrowerAssert) {
                canAddNarrowerAssert = (!RDFSKOSHelper.HasBroadMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.HasCloseMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.HasExactMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.HasRelatedMatchConcept(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddNarrowerAssert;
        }

        /// <summary>
        /// Checks if the skos:related/skos:relatedMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckRelatedAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddRelatedAssert = false;

            //Avoid clash with hierarchical relations
            canAddRelatedAssert     = (!RDFSKOSHelper.HasBroaderConcept(ontologyData, aConceptFact, bConceptFact)     &&
                                       !RDFSKOSHelper.HasNarrowerConcept(ontologyData, aConceptFact, bConceptFact));

            //Avoid clash with mapping relations
            if (canAddRelatedAssert) {
                canAddRelatedAssert = (!RDFSKOSHelper.HasBroadMatchConcept(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.HasNarrowMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                       !RDFSKOSHelper.HasCloseMatchConcept(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.HasExactMatchConcept(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddRelatedAssert;
        }

        /// <summary>
        /// Checks if the skos:closeMatch/skos:exactMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckCloseOrExactMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddCloseOrExactMatchAssert = false;

            //Avoid clash with hierarchical relations
            canAddCloseOrExactMatchAssert     = (!RDFSKOSHelper.HasBroaderConcept(ontologyData, aConceptFact, bConceptFact)     &&
                                                 !RDFSKOSHelper.HasNarrowerConcept(ontologyData, aConceptFact, bConceptFact));

            //Avoid clash with mapping relations
            if (canAddCloseOrExactMatchAssert) {
                canAddCloseOrExactMatchAssert = (!RDFSKOSHelper.HasBroadMatchConcept(ontologyData, aConceptFact, bConceptFact)  &&
                                                 !RDFSKOSHelper.HasNarrowMatchConcept(ontologyData, aConceptFact, bConceptFact) &&
                                                 !RDFSKOSHelper.HasRelatedConcept(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddCloseOrExactMatchAssert;
        }
        #endregion

        #region Annotations
        /// <summary>
        /// Checks if the skos:prefLabel annotation can be added to the given concept
        /// </summary>
        internal static Boolean CheckPrefLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral prefLabelLiteral) {
            var canAddPrefLabelAnnot = false;
            var prefLabelProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var altLabelProperty     = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());
            var hidLabelProperty     = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());
            var prefLabelLiteralLang = ((RDFPlainLiteral)prefLabelLiteral.Value).Language;

            //Plain literal without language tag: only one occurrence of this annotation is allowed
            if (String.IsNullOrEmpty(prefLabelLiteralLang)) {
                canAddPrefLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                                   .SelectEntriesByPredicate(prefLabelProperty)
                                                                                   .Any(x => x.TaxonomyObject.Value is RDFPlainLiteral
                                                                                               && String.IsNullOrEmpty(((RDFPlainLiteral)x.TaxonomyObject.Value).Language)));
            }

            //Plain literal with language tag: only one occurrence of this annotation per language tag is allowed
            else {
                canAddPrefLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                                   .SelectEntriesByPredicate(prefLabelProperty)
                                                                                   .Any(x => x.TaxonomyObject.Value is RDFPlainLiteral
                                                                                               && !String.IsNullOrEmpty(((RDFPlainLiteral)x.TaxonomyObject.Value).Language)
                                                                                               && (((RDFPlainLiteral)x.TaxonomyObject.Value).Language).Equals(prefLabelLiteralLang, StringComparison.OrdinalIgnoreCase)));
            }

            //Pairwise disjointness between skos:prefLabel and skos:altLabel must be preserved
            if (canAddPrefLabelAnnot) {
                canAddPrefLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                 .SelectEntriesByPredicate(altLabelProperty)
                                                                 .Any(x => x.TaxonomyObject.Equals(prefLabelLiteral)));
            }

            //Pairwise disjointness between skos:prefLabel and skos:hiddenLabel must be preserved
            if (canAddPrefLabelAnnot) {
                canAddPrefLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                 .SelectEntriesByPredicate(hidLabelProperty)
                                                                 .Any(x => x.TaxonomyObject.Equals(prefLabelLiteral)));
            }

            return canAddPrefLabelAnnot;
        }

        /// <summary>
        /// Checks if the skos:altLabel annotation can be added to the given concept
        /// </summary>
        internal static Boolean CheckAltLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral altLabelLiteral) {
            var canAddAltLabelAnnot = false;
            var prefLabelProperty   = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var hidLabelProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());

            //Pairwise disjointness between skos:altLabel and skos:prefLabel must be preserved
            canAddAltLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                .SelectEntriesByPredicate(prefLabelProperty)
                                                                .Any(x => x.TaxonomyObject.Equals(altLabelLiteral)));

            //Pairwise disjointness between skos:altLabel and skos:hiddenLabel must be preserved
            if (canAddAltLabelAnnot) {
                canAddAltLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                .SelectEntriesByPredicate(hidLabelProperty)
                                                                .Any(x => x.TaxonomyObject.Equals(altLabelLiteral)));
            }

            return canAddAltLabelAnnot;
        }

        /// <summary>
        /// Checks if the skos:hiddenLabel annotation can be added to the given concept
        /// </summary>
        internal static Boolean CheckHiddenLabelAnnotation(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral hiddenLabelLiteral) {
            var canAddHiddenLabelAnnot = false;
            var prefLabelProperty      = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var altLabelProperty       = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());

            //Pairwise disjointness between skos:hiddenLabel and skos:prefLabel must be preserved
            canAddHiddenLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                   .SelectEntriesByPredicate(prefLabelProperty)
                                                                   .Any(x => x.TaxonomyObject.Equals(hiddenLabelLiteral)));

            //Pairwise disjointness between skos:hiddenLabel and skos:altLabel must be preserved
            if (canAddHiddenLabelAnnot) {
                canAddHiddenLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                   .SelectEntriesByPredicate(altLabelProperty)
                                                                   .Any(x => x.TaxonomyObject.Equals(hiddenLabelLiteral)));
            }

            return canAddHiddenLabelAnnot;
        }
        #endregion

    }

}