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
    /// RDFSKOSChecker is responsible for implicit SKOS validation of ontologies during modeling
    /// </summary>
    internal static class RDFSKOSChecker {

        #region Methods
        /// <summary>
        /// Checks if the skos:broader/skos:broaderTransitive/skos:broadMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckBroaderAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddBroaderAssert = false;

            //Avoid clash with hierarchical relations
            canAddBroaderAssert     = !RDFSKOSHelper.CheckNarrower(ontologyData, aConceptFact, bConceptFact);

            //Avoid clash with associative relations
            if (canAddBroaderAssert) {
                canAddBroaderAssert = !RDFSKOSHelper.CheckRelated(ontologyData, aConceptFact, bConceptFact);
            }

            //Avoid clash with mapping relations
            if (canAddBroaderAssert) {
                canAddBroaderAssert = (!RDFSKOSHelper.CheckNarrowMatch(ontologyData, aConceptFact, bConceptFact) &&
                                       !RDFSKOSHelper.CheckCloseMatch(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.CheckExactMatch(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.CheckRelatedMatch(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddBroaderAssert;
        }

        /// <summary>
        /// Checks if the skos:narrower/skos:narrowerTransitive/skos:narrowMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckNarrowerAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddNarrowerAssert = false;

            //Avoid clash with hierarchical relations
            canAddNarrowerAssert     = !RDFSKOSHelper.CheckBroader(ontologyData, aConceptFact, bConceptFact);

            //Avoid clash with associative relations
            if (canAddNarrowerAssert) {
                canAddNarrowerAssert = !RDFSKOSHelper.CheckRelated(ontologyData, aConceptFact, bConceptFact);
            }

            //Avoid clash with mapping relations
            if (canAddNarrowerAssert) {
                canAddNarrowerAssert = (!RDFSKOSHelper.CheckBroadMatch(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.CheckCloseMatch(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.CheckExactMatch(ontologyData, aConceptFact, bConceptFact) &&
                                        !RDFSKOSHelper.CheckRelatedMatch(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddNarrowerAssert;
        }

        /// <summary>
        /// Checks if the skos:related/skos:relatedMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckRelatedAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddRelatedAssert = false;

            //Avoid clash with hierarchical relations
            canAddRelatedAssert     = (!RDFSKOSHelper.CheckBroader(ontologyData, aConceptFact, bConceptFact)     &&
                                       !RDFSKOSHelper.CheckNarrower(ontologyData, aConceptFact, bConceptFact));

            //Avoid clash with mapping relations
            if (canAddRelatedAssert) {
                canAddRelatedAssert = (!RDFSKOSHelper.CheckBroadMatch(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.CheckNarrowMatch(ontologyData, aConceptFact, bConceptFact) &&
                                       !RDFSKOSHelper.CheckCloseMatch(ontologyData, aConceptFact, bConceptFact)  &&
                                       !RDFSKOSHelper.CheckExactMatch(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddRelatedAssert;
        }

        /// <summary>
        /// Checks if the skos:closeMatch/skos:exactMatch assertion can be added to the given aConcept with the given bConcept
        /// </summary>
        internal static Boolean CheckCloseOrExactMatchAssertion(RDFOntologyData ontologyData, RDFOntologyFact aConceptFact, RDFOntologyFact bConceptFact) {
            var canAddCloseOrExactMatchAssert = false;

            //Avoid clash with hierarchical relations
            canAddCloseOrExactMatchAssert     = (!RDFSKOSHelper.CheckBroader(ontologyData, aConceptFact, bConceptFact)     &&
                                                 !RDFSKOSHelper.CheckNarrower(ontologyData, aConceptFact, bConceptFact));

            //Avoid clash with mapping relations
            if (canAddCloseOrExactMatchAssert) {
                canAddCloseOrExactMatchAssert = (!RDFSKOSHelper.CheckBroadMatch(ontologyData, aConceptFact, bConceptFact)  &&
                                                 !RDFSKOSHelper.CheckNarrowMatch(ontologyData, aConceptFact, bConceptFact) &&
                                                 !RDFSKOSHelper.CheckRelated(ontologyData, aConceptFact, bConceptFact));
            }

            return canAddCloseOrExactMatchAssert;
        }

        /// <summary>
        /// Checks if the skos:prefLabel/skosxl:prefLabel informations can be added to the given concept
        /// </summary>
        internal static Boolean CheckPrefLabel(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral prefLabelLiteral) {
            var canAddPrefLabelAnnot     = false;
            var prefLabelProperty        = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var prefLabelXLProperty      = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.PREF_LABEL.ToString());
            var altLabelProperty         = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());
            var altLabelXLProperty       = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.ALT_LABEL.ToString());
            var hidLabelProperty         = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());
            var hidLabelXLProperty       = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.HIDDEN_LABEL.ToString());
            var literalFormXLProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());
            var prefLabelLiteralLang     = ((RDFPlainLiteral)prefLabelLiteral.Value).Language;

            //Plain literal without language tag: only one occurrence of this annotation is allowed
            if (String.IsNullOrEmpty(prefLabelLiteralLang)) {

                //Check skos:prefLabel annotation
                canAddPrefLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                                       .SelectEntriesByPredicate(prefLabelProperty)
                                                                                       .Any(x => x.TaxonomyObject.Value is RDFPlainLiteral
                                                                                                   && String.IsNullOrEmpty(((RDFPlainLiteral)x.TaxonomyObject.Value).Language)));
                //Check skosxl:prefLabel assertion
                if (canAddPrefLabelAnnot) {
                    canAddPrefLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                              .SelectEntriesByPredicate(prefLabelXLProperty)
                                                                              .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                         .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                         .Any(y => y.TaxonomyObject.Value is RDFPlainLiteral
                                                                                                                                     && String.IsNullOrEmpty(((RDFPlainLiteral)y.TaxonomyObject.Value).Language))));
                }

            }

            //Plain literal with language tag: only one occurrence of this annotation per language tag is allowed
            else {

                //Check skos:prefLabel annotation
                canAddPrefLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                                       .SelectEntriesByPredicate(prefLabelProperty)
                                                                                       .Any(x => x.TaxonomyObject.Value is RDFPlainLiteral
                                                                                                   && !String.IsNullOrEmpty(((RDFPlainLiteral)x.TaxonomyObject.Value).Language)
                                                                                                   && (((RDFPlainLiteral)x.TaxonomyObject.Value).Language).Equals(prefLabelLiteralLang, StringComparison.OrdinalIgnoreCase)));
            
                //Check skosxl:prefLabel assertion
                if (canAddPrefLabelAnnot) {
                    canAddPrefLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                              .SelectEntriesByPredicate(prefLabelXLProperty)
                                                                              .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                         .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                         .Any(y => y.TaxonomyObject.Value is RDFPlainLiteral
                                                                                                                                     && !String.IsNullOrEmpty(((RDFPlainLiteral)x.TaxonomyObject.Value).Language)
                                                                                                                                     && (((RDFPlainLiteral)x.TaxonomyObject.Value).Language).Equals(prefLabelLiteralLang, StringComparison.OrdinalIgnoreCase))));
                }
            
            }

            //Pairwise disjointness with skos:altLabel/skosxl:altLabel must be preserved
            if (canAddPrefLabelAnnot) {

                //Check skos:altLabel annotation
                canAddPrefLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                     .SelectEntriesByPredicate(altLabelProperty)
                                                                     .Any(x => x.TaxonomyObject.Equals(prefLabelLiteral)));
                                                                 
                //Check skosxl:altLabel assertion
                if (canAddPrefLabelAnnot) {
                    canAddPrefLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                              .SelectEntriesByPredicate(altLabelXLProperty)
                                                                              .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                         .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                         .Any(y => y.TaxonomyObject.Equals(prefLabelLiteral))));
                }
                                                
            }

            //Pairwise disjointness with skos:hiddenLabel/skosxl:hiddenLabel must be preserved
            if (canAddPrefLabelAnnot) {

                //Check skos:hiddenLabel annotation
                canAddPrefLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                     .SelectEntriesByPredicate(hidLabelProperty)
                                                                     .Any(x => x.TaxonomyObject.Equals(prefLabelLiteral)));
                                                                 
                //Check skosxl:hiddenLabel assertion
                if (canAddPrefLabelAnnot) {
                    canAddPrefLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                              .SelectEntriesByPredicate(hidLabelXLProperty)
                                                                              .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                         .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                         .Any(y => y.TaxonomyObject.Equals(prefLabelLiteral))));
                }
  
            }

            return canAddPrefLabelAnnot;
        }

        /// <summary>
        /// Checks if the skos:altLabel/skosxl:altLabel informations can be added to the given concept
        /// </summary>
        internal static Boolean CheckAltLabel(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral altLabelLiteral) {
            var canAddAltLabelAnnot   = false;
            var prefLabelProperty     = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var prefLabelXLProperty   = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.PREF_LABEL.ToString());
            var hidLabelProperty      = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.HIDDEN_LABEL.ToString());
            var hidLabelXLProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.HIDDEN_LABEL.ToString());
            var literalFormXLProperty = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

            //Pairwise disjointness with skos:prefLabel/skosxl:prefLabel must be preserved
            canAddAltLabelAnnot       = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                  .SelectEntriesByPredicate(prefLabelProperty)
                                                                  .Any(x => x.TaxonomyObject.Equals(altLabelLiteral)));

            if (canAddAltLabelAnnot) {
                canAddAltLabelAnnot   = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                           .SelectEntriesByPredicate(prefLabelXLProperty)
                                                                           .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                      .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                      .Any(y => y.TaxonomyObject.Equals(altLabelLiteral))));
            }

            //Pairwise disjointness with skos:hiddenLabel/skosxl:hiddenLabel must be preserved
            if (canAddAltLabelAnnot) {
                canAddAltLabelAnnot   = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                  .SelectEntriesByPredicate(hidLabelProperty)
                                                                  .Any(x => x.TaxonomyObject.Equals(altLabelLiteral)));
            }
 
            if (canAddAltLabelAnnot) {
                canAddAltLabelAnnot   = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                           .SelectEntriesByPredicate(hidLabelXLProperty)
                                                                           .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                      .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                      .Any(y => y.TaxonomyObject.Equals(altLabelLiteral))));
            }

            return canAddAltLabelAnnot;
        }

        /// <summary>
        /// Checks if the skos:hiddenLabel/skosxl:hiddenLabel informations can be added to the given concept
        /// </summary>
        internal static Boolean CheckHiddenLabel(RDFOntologyData ontologyData, RDFOntologyFact conceptFact, RDFOntologyLiteral hiddenLabelLiteral) {
            var canAddHiddenLabelAnnot = false;
            var prefLabelProperty      = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.PREF_LABEL.ToString());
            var prefLabelXLProperty    = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.PREF_LABEL.ToString());
            var altLabelProperty       = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.ALT_LABEL.ToString());
            var altLabelXLProperty     = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.ALT_LABEL.ToString());
            var literalFormXLProperty  = RDFSKOSOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.SKOS.SKOSXL.LITERAL_FORM.ToString());

            //Pairwise disjointness with skos:prefLabel/skosxl:prefLabel must be preserved
            canAddHiddenLabelAnnot     = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                   .SelectEntriesByPredicate(prefLabelProperty)
                                                                   .Any(x => x.TaxonomyObject.Equals(hiddenLabelLiteral)));

            if (canAddHiddenLabelAnnot) {
                canAddHiddenLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                            .SelectEntriesByPredicate(prefLabelXLProperty)
                                                                            .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                       .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                       .Any(y => y.TaxonomyObject.Equals(hiddenLabelLiteral))));
            }

            //Pairwise disjointness with skos:altLabel/skosxl:altLabel must be preserved
            if (canAddHiddenLabelAnnot) {
                canAddHiddenLabelAnnot = !(ontologyData.Annotations.CustomAnnotations.SelectEntriesBySubject(conceptFact)
                                                                   .SelectEntriesByPredicate(altLabelProperty)
                                                                   .Any(x => x.TaxonomyObject.Equals(hiddenLabelLiteral)));
            }

            if (canAddHiddenLabelAnnot) {
                canAddHiddenLabelAnnot = !(ontologyData.Relations.Assertions.SelectEntriesBySubject(conceptFact)
                                                                            .SelectEntriesByPredicate(altLabelXLProperty)
                                                                            .Any(x => ontologyData.Relations.Assertions.SelectEntriesBySubject(x.TaxonomyObject)
                                                                                                                       .SelectEntriesByPredicate(literalFormXLProperty)
                                                                                                                       .Any(y => y.TaxonomyObject.Equals(hiddenLabelLiteral))));
            }

            return canAddHiddenLabelAnnot;
        }

        /// <summary>
        /// Checks if the skos:memberList assertion can be added to the given orderedCollectionFact
        /// </summary>
        internal static Boolean CheckMemberListAssertion(RDFOntologyData ontologyData, RDFOntologyFact orderedCollectionFact) {
            var canAddMemberListAssert = false;

            //Only one instance of this skos:OrderedCollection is allowed (FunctionalProperty)
            canAddMemberListAssert     = (ontologyData.Relations.Assertions.SelectEntriesBySubject(orderedCollectionFact)
                                                                           .SelectEntriesByPredicate(RDFVocabulary.SKOS.MEMBER_LIST.ToRDFOntologyObjectProperty())
                                                                           .EntriesCount == 0);

            return canAddMemberListAssert;
        }
        #endregion

    }

}
