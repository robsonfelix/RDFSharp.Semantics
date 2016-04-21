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
    /// RDFDCOntology represents an ontology implementation of DC vocabulary
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

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharp.codeplex.com/dc_ontology#"));
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
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.CONTRIBUTOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.COVERAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.CREATOR));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DATE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DESCRIPTION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.FORMAT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.IDENTIFIER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.LANGUAGE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.PUBLISHER));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.RELATION));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.RIGHTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.SOURCE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.SUBJECT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.TITLE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.TYPE));
            
            //DC.DCAM
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCAM.MEMBER_OF));
            
            //DC.DCTERMS
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.ABSTRACT));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.ALTERNATIVE));
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
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.DESCRIPTION));
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
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.TABLE_OF_CONTENTS));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.TITLE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyObjectProperty(RDFVocabulary.DC.DCTERMS.TYPE));
            Instance.Model.PropertyModel.AddProperty(new RDFOntologyDatatypeProperty(RDFVocabulary.DC.DCTERMS.VALID));

            #endregion

            #region Facts

            //DC.DCTERMS
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.DCMI_TYPE));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.DDC));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.IMT));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.LCC));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.LCSH));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.MESH));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.NLM));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.TGN));
            Instance.Data.AddFact(new RDFOntologyFact(RDFVocabulary.DC.DCTERMS.UDC));

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()),            Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.BOX.ToString()),              RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.FILE_FORMAT.ToString()),      Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.ISO3166.ToString()),          RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_2.ToString()),         RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.ISO639_3.ToString()),         RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.JURISDICTION.ToString()),     Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToString()),         Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()),       Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD.ToString()),           RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToString()),   Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToString()),  Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.POINT.ToString()),            RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RFC1766.ToString()),          RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RFC3066.ToString()),          RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RFC4646.ToString()),          RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RFC5646.ToString()),          RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.URI.ToString()),              RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.W3CDTF.ToString()),           RDFBASEOntology.Instance.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.MOVING_IMAGE.ToString()),      Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.IMAGE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.STILL_IMAGE.ToString()),       Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.IMAGE.ToString()));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ABSTRACT.ToString()),               (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DESCRIPTION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS.ToString()),            (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ALTERNATIVE.ToString()),            (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TITLE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.AVAILABLE.ToString()),              (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION.ToString()), (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IDENTIFIER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO.ToString()),              (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToString()),              (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.CONTRIBUTOR.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.COVERAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CREATED.ToString()),                (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.CREATOR.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()),                   (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_ACCEPTED.ToString()),          (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_COPYRIGHTED.ToString()),       (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE_SUBMITTED.ToString()),         (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL.ToString()),          (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.EXTENT.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.FORMAT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT.ToString()),               (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_PART.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION.ToString()),              (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IDENTIFIER.ToString()),             (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.IDENTIFIER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ISSUED.ToString()),                 (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF.ToString()),             (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF.ToString()),               (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY.ToString()),         (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY.ToString()),           (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY.ToString()),           (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF.ToString()),            (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.LANGUAGE.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.LANGUAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.LICENSE.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MODIFIED.ToString()),               (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.PUBLISHER.ToString()),                (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.PUBLISHER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToString()),               (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REPLACES.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REQUIRES.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.RIGHTS.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.SOURCE.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.SOURCE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.SOURCE.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.SUBJECT.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.SUBJECT.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.SPATIAL.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TABLE_OF_CONTENTS.ToString()),      (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DESCRIPTION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL.ToString()),                 (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TITLE.ToString()),                  (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.TITLE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TYPE.ToString()),                     (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.TYPE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.VALID.ToString()),                  (RDFOntologyDatatypeProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            
            //EquivalentProperty
            Instance.Model.PropertyModel.AddEquivalentPropertyRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()),             (RDFOntologyObjectProperty)RDFFOAFOntology.Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.FOAF.MAKER.ToString()));
            
            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_FORMAT.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_FORMAT_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_PART.ToString()),                     (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_PART_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.HAS_VERSION.ToString()),                  (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_VERSION_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToString()),                   (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REFERENCED_BY.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REPLACES.ToString()),                     (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REPLACED_BY.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.REQUIRES.ToString()),                     (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.IS_REQUIRED_BY.ToString()));
            
            //Domain/Range
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCAM.MEMBER_OF.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCESS_RIGHTS.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_METHOD.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_ACCRUAL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_PERIODICITY.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.FREQUENCY.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTYPE.COLLECTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.ACCRUAL_POLICY.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.POLICY.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.AUDIENCE.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_CITATION.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.BIBLIOGRAPHIC_RESOURCE.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CONFORMS_TO.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.STANDARD.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CONTRIBUTOR.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.COVERAGE.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION_PERIOD_OR_JURISDICTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.CREATOR.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.EDUCATION_LEVEL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.EXTENT.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.SIZE_OR_DURATION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.FORMAT.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.MEDIA_TYPE_OR_EXTENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.INSTRUCTIONAL_METHOD.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.METHOD_OF_INSTRUCTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.LANGUAGE.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LINGUISTIC_SYSTEM.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.LICENSE.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LICENSE_DOCUMENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIATOR.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT_CLASS.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_RESOURCE.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.MEDIUM.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PHYSICAL_MEDIUM.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.PUBLISHER.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.PROVENANCE.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PROVENANCE_STATEMENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.RIGHTS_STATEMENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.RIGHTS_HOLDER.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.SPATIAL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.LOCATION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.DC.DCTERMS.TEMPORAL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCTERMS.PERIOD_OF_TIME.ToString()));

            #endregion

            #region Data

            //ClassType
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.DCMI_TYPE.ToString()),                                  Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.DDC.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.IMT.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.LCC.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.LCSH.ToString()),                                       Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.MESH.ToString()),                                       Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.NLM.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.TGN.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));
            Instance.Data.AddClassTypeRelation(Instance.Data.SelectFact(RDFVocabulary.DC.DCTERMS.UDC.ToString()),                                        Instance.Model.ClassModel.SelectClass(RDFVocabulary.DC.DCAM.VOCABULARY_ENCODING_SCHEME.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the DC ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            if (ontClass     != null) {
                Int64 classID = RDFModelUtilities.CreateHash(ontClass);
                if (Instance.Model.ClassModel.Classes.ContainsKey(classID)) {
                    return Instance.Model.ClassModel.Classes[classID];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the given property from the DC ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            if (ontProperty  != null) {
                Int64 propID  = RDFModelUtilities.CreateHash(ontProperty);
                if (Instance.Model.PropertyModel.Properties.ContainsKey(propID)) {
                    return Instance.Model.PropertyModel.Properties[propID];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the given fact from the DC ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            if (ontFact     != null) {
                Int64 factID = RDFModelUtilities.CreateHash(ontFact);
                if (Instance.Data.Facts.ContainsKey(factID)) {
                    return Instance.Data.Facts[factID];
                }
            }
            return null;
        }

        /// <summary>
        /// Exports the DC ontology to a RDF graph
        /// </summary>
        public static RDFGraph ToRDFGraph(Boolean includeInferences) {
            return Instance.ToRDFGraph(includeInferences);
        }
        #endregion

    }

}