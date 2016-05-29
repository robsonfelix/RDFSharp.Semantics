/*
   Copyright 2012-2016 Marco De Salvo

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
using RDFSharp.Model;
using RDFSharp.Semantics.BASE;

namespace RDFSharp.Semantics.DC {

    /// <summary>
    /// RDFDCOntology represents an OWL-DL ontology implementation of Dublin Core vocabulary
    /// </summary>
    public static class RDFDCOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the DC ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the DC ontology
        /// </summary>
        static RDFDCOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/dc_ontology#"));
            #endregion

            #region Classes

            //DC.DCAM
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToRDFOntologyClass());

            //DC.DCTERMS
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.AGENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.BOX.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.FILE_FORMAT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.FREQUENCY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.ISO3166.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.ISO639_2.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.ISO639_3.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.JURISDICTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.LINGUISTIC_SYSTEM.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_INSTRUCTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_ACCRUAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.PERIOD.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.POINT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.POLICY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.PROVENANCE_STATEMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.RFC1766.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.RFC3066.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.RFC4646.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.RFC5646.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.STANDARD.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.URI.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTERMS.W3CDTF.ToRDFOntologyClass());

            //DC.DCTYPE
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.DATASET.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.EVENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.IMAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.INTERACTIVE_RESOURCE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.MOVING_IMAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.PHYSICAL_OBJECT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.SERVICE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.SOFTWARE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.SOUND.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.STILL_IMAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.DC.DCTYPE.TEXT.ToRDFOntologyClass());

            #endregion

            #region Properties

            //DC
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.CONTRIBUTOR.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.COVERAGE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.CREATOR.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DATE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DESCRIPTION.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.FORMAT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.IDENTIFIER.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.LANGUAGE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.PUBLISHER.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.RELATION.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.RIGHTS.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.SOURCE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.SUBJECT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.TITLE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.TYPE.ToRDFOntologyAnnotationProperty());

            //DC.DCAM
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCAM.MEMBER_OF.ToRDFOntologyObjectProperty());

            //DC.DCTERMS
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ABSTRACT.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ALTERNATIVE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.AVAILABLE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.CREATED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.DATE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.DATE_ACCEPTED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.DATE_COPYRIGHTED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.DATE_SUBMITTED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.DESCRIPTION.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.EXTENT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.HAS_PART.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IDENTIFIER.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.ISSUED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.INSTRUCTIONAL_METHOD.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.LANGUAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.LICENSE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.MODIFIED.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.PROVENANCE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.PUBLISHER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.REPLACES.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.REQUIRES.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.RIGHTS_HOLDER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.SOURCE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.SPATIAL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.SUBJECT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.TABLE_OF_CONTENTS.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.TITLE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.TYPE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.DC.DCTERMS.VALID.ToRDFOntologyDatatypeProperty());

            #endregion

            #region Facts

            //DC.DCTERMS
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.DCMITYPE.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.DDC.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.IMT.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.LCC.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.LCSH.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.MESH.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.NLM.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.TGN.ToRDFOntologyFact());
            Instance.Data.AddFact(RDFVocabulary.DC.DCTERMS.UDC.ToRDFOntologyFact());

            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            var rdfsLiteral = RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString());
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()),            SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.BOX.ToString()),              rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.FILE_FORMAT.ToString()),      SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO3166.ToString()),          rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_2.ToString()),         rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_3.ToString()),         rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.JURISDICTION.ToString()),     SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToString()), SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToString()),         SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()),       SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD.ToString()),           rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToString()),   SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToString()),  SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.POINT.ToString()),            rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC1766.ToString()),          rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC3066.ToString()),          rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC4646.ToString()),          rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC5646.ToString()),          rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToString()), SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.URI.ToString()),              rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.W3CDTF.ToString()),           rdfsLiteral);
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTYPE.MOVING_IMAGE.ToString()),      SelectClass(RDFVocabulary.DC.DCTYPE.IMAGE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTYPE.STILL_IMAGE.ToString()),       SelectClass(RDFVocabulary.DC.DCTYPE.IMAGE.ToString()));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.AVAILABLE.ToString()),              (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION.ToString()), (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IDENTIFIER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.CREATED.ToString()),                (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_ACCEPTED.ToString()),          (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_COPYRIGHTED.ToString()),       (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_SUBMITTED.ToString()),         (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL.ToString()),          (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.EXTENT.ToString()),                   (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT.ToString()),               (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_PART.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.ISSUED.ToString()),                 (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF.ToString()),               (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY.ToString()),           (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY.ToString()),           (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.LICENSE.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()),                   (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.MODIFIED.ToString()),               (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToString()),               (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REPLACES.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REQUIRES.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.SOURCE.ToString()),                   (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.SPATIAL.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.VALID.ToString()),                  (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));

            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT.ToString()),                   (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_PART.ToString()),                     (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToString()),                   (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REPLACES.ToString()),                     (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.REQUIRES.ToString()),                     (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY.ToString()));

            //Domain/Range
            SelectProperty(RDFVocabulary.DC.DCAM.MEMBER_OF.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD.ToString()).SetDomain(SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_ACCRUAL.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY.ToString()).SetDomain(SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.FREQUENCY.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY.ToString()).SetDomain(SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.POLICY.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION.ToString()).SetDomain(SelectClass(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_RESOURCE.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.STANDARD.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.EXTENT.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.INSTRUCTIONAL_METHOD.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_INSTRUCTION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.LANGUAGE.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.LINGUISTIC_SYSTEM.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.LICENSE.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()).SetDomain(SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_RESOURCE.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.PUBLISHER.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.PROVENANCE.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.PROVENANCE_STATEMENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS_HOLDER.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.SPATIAL.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToString()));
            SelectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL.ToString()).SetRange(SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToString()));

            #endregion

            #region Data

            //ClassType
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.DCMITYPE.ToString()), SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.DDC.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.IMT.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.LCC.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.LCSH.ToString()),     SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.MESH.ToString()),     SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.NLM.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.TGN.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(SelectFact(RDFVocabulary.DC.DCTERMS.UDC.ToString()),      SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the DC ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the DC ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the DC ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            return Instance.Data.SelectFact(ontFact);
        }
        #endregion

    }

}