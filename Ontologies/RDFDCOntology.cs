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

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFDCOntology represents an OWL-DL ontology implementation of DC vocabulary
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
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/dc_ontology#"), true);
            #endregion

            #region Classes

            //DC.DCAM
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME));

            //DC.DCTERMS
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.AGENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_RESOURCE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.BOX));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.FILE_FORMAT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.FREQUENCY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.ISO3166));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.ISO639_2));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.ISO639_3));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.JURISDICTION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.LINGUISTIC_SYSTEM));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.LOCATION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_INSTRUCTION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_ACCRUAL));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.PERIOD));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_RESOURCE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.POINT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.POLICY));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.PROVENANCE_STATEMENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.RFC1766));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.RFC3066));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.RFC4646));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.RFC5646));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.STANDARD));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.URI));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTERMS.W3CDTF));
            
            //DC.DCTYPE
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.COLLECTION));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.DATASET));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.EVENT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.IMAGE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.INTERACTIVE_RESOURCE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.MOVING_IMAGE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.PHYSICAL_OBJECT));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.SERVICE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.SOFTWARE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.SOUND));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.STILL_IMAGE));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(RDFVocabulary.DC.DCTYPE.TEXT));

            #endregion

            #region Properties

            //DC
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.CONTRIBUTOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.COVERAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.CREATOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DATE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DESCRIPTION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.FORMAT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.IDENTIFIER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.LANGUAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.PUBLISHER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.RELATION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.RIGHTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.SOURCE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.SUBJECT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.TITLE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.TYPE));
            
            //DC.DCAM
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCAM.MEMBER_OF));
            
            //DC.DCTERMS
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DCTERMS.ABSTRACT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DCTERMS.ALTERNATIVE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.AVAILABLE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.CREATED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.CREATOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.DATE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.DATE_ACCEPTED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.DATE_COPYRIGHTED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.DATE_SUBMITTED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DCTERMS.DESCRIPTION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.EXTENT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.FORMAT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.HAS_PART));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.IDENTIFIER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.ISSUED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.INSTRUCTIONAL_METHOD));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.LANGUAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.LICENSE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.MODIFIED));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.PROVENANCE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.PUBLISHER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.RELATION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.REPLACES));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.REQUIRES));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS_HOLDER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.SOURCE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.SPATIAL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.SUBJECT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DCTERMS.TABLE_OF_CONTENTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyAnnotationProperty(RDFVocabulary.DC.DCTERMS.TITLE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.TYPE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.VALID));

            #endregion

            #region Facts

            //DC.DCTERMS
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.DCMITYPE));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.DDC));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.IMT));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.LCC));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.LCSH));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.MESH));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.NLM));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.TGN));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.UDC));

            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()),            SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.BOX.ToString()),              RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.FILE_FORMAT.ToString()),      SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO3166.ToString()),          RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_2.ToString()),         RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_3.ToString()),         RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.JURISDICTION.ToString()),     SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToString()), SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToString()),         SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()),       SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD.ToString()),           RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToString()),   SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToString()),  SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.POINT.ToString()),            RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC1766.ToString()),          RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC3066.ToString()),          RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC4646.ToString()),          RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.RFC5646.ToString()),          RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToString()), SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.URI.ToString()),              RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.DC.DCTERMS.W3CDTF.ToString()),           RDFBASEOntology.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
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