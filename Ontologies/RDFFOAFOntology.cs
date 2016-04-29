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
    /// RDFFOAFOntology represents an OWL-DL ontology implementation of FOAF vocabulary
    /// </summary>
    public static class RDFFOAFOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the FOAF ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the FOAF ontology
        /// </summary>
        static RDFFOAFOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/foaf_ontology#"), true);
            #endregion

            #region Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.AGENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.DOCUMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.GROUP.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.IMAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.ONLINE_CHAT_ACCOUNT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.ONLINE_ECOMMERCE_ACCOUNT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.ONLINE_GAMING_ACCOUNT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.ORGANIZATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.PERSON.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.PERSONAL_PROFILE_DOCUMENT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.FOAF.PROJECT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(new RDFOntologyDataRangeClass(new RDFResource("bnode:Genders")));

            //OWL-DL Completeness
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(new RDFResource("http://schema.org/CreativeWork")));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(new RDFResource("http://schema.org/ImageObject")));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(new RDFResource("http://schema.org/Person")));
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(new RDFResource("http://www.w3.org/2000/10/swap/pim/contact#Person")));
            #endregion

            #region Properties
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.ACCOUNT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.ACCOUNT_NAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.ACCOUNT_SERVICE_HOMEPAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.AGE.ToRDFOntologyDatatypeProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.AIM_CHAT_ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.BASED_NEAR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.BIRTHDAY.ToRDFOntologyDatatypeProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.CURRENT_PROJECT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.DEPICTION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.DEPICTS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.DNA_CHECKSUM.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.FAMILY_NAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.FIRSTNAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.FOCUS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.FUNDED_BY.ToRDFOntologyObjectProperty());            
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.GEEK_CODE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.GENDER.ToRDFOntologyDatatypeProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.GIVEN_NAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.HOLDS_ACCOUNT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.HOMEPAGE.ToRDFOntologyObjectProperty().SetInverseFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.ICQ_CHAT_ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.IMG.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.INTEREST.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToRDFOntologyObjectProperty().SetInverseFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.JABBER_ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.KNOWS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.LOGO.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MADE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MAKER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MBOX.ToRDFOntologyObjectProperty().SetInverseFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MBOX_SHA1SUM.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MEMBER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MEMBERSHIP_CLASS.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MSN_CHAT_ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.MYERS_BRIGGS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.NAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.NICK.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.OPEN_ID.ToRDFOntologyObjectProperty().SetInverseFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PAST_PROJECT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PHONE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PLAN.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PRIMARY_TOPIC.ToRDFOntologyObjectProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.PUBLICATIONS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.SCHOOL_HOMEPAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.SHA1.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.SKYPE_ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.STATUS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.SURNAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.THEME.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.THUMBNAIL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.TIPJAR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.TITLE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.TOPIC.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.TOPIC_INTEREST.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.WEBLOG.ToRDFOntologyObjectProperty().SetInverseFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.WORKINFO_HOMEPAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.WORKPLACE_HOMEPAGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.FOAF.YAHOO_CHAT_ID.ToRDFOntologyDatatypeProperty());
            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()),                     SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.GROUP.ToString()),                     SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.ONLINE_CHAT_ACCOUNT.ToString()),       SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.ONLINE_ECOMMERCE_ACCOUNT.ToString()),  SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.ONLINE_GAMING_ACCOUNT.ToString()),     SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.ORGANIZATION.ToString()),              SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()),                    SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()),                    RDFGEOOntology.SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.FOAF.PERSONAL_PROFILE_DOCUMENT.ToString()), SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));

            //EquivalentClass
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()),                RDFDCOntology.SelectClass(RDFVocabulary.DC.DCTERMS.AGENT.ToString()));
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()),             SelectClass("http://schema.org/CreativeWork"));
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()),                SelectClass("http://schema.org/ImageObject"));
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()),               SelectClass("http://schema.org/Person"));
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()),               SelectClass("http://www.w3.org/2000/10/swap/pim/contact#Person"));

            //DisjointWith
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.FOAF.ORGANIZATION.ToString()),            SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.FOAF.ORGANIZATION.ToString()),            SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.FOAF.PROJECT.ToString()),                 SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.FOAF.PROJECT.ToString()),                 SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));

            //OneOf
            Instance.Model.ClassModel.AddOneOfRelation((RDFOntologyDataRangeClass)SelectClass("bnode:Genders"), new RDFOntologyLiteral(new RDFTypedLiteral("female", RDFDatatypeRegister.GetByPrefixAndDatatype("xsd", "string"))));
            Instance.Model.ClassModel.AddOneOfRelation((RDFOntologyDataRangeClass)SelectClass("bnode:Genders"), new RDFOntologyLiteral(new RDFTypedLiteral("male",   RDFDatatypeRegister.GetByPrefixAndDatatype("xsd", "string"))));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.AIM_CHAT_ID.ToString()),       (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.NICK.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.HOMEPAGE.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.HOMEPAGE.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.ICQ_CHAT_ID.ToString()),       (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.NICK.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.IMG.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.DEPICTION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToString()), (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.MSN_CHAT_ID.ToString()),       (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.NICK.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.OPEN_ID.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.TIPJAR.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.WEBLOG.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.YAHOO_CHAT_ID.ToString()),     (RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.FOAF.NICK.ToString()));

            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.DEPICTION.ToString()),               (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.DEPICTS.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PRIMARY_TOPIC.ToString()),           (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.MADE.ToString()),                    (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.MAKER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()),                    (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.FOAF.TOPIC.ToString()));

            //Domain/Range
            SelectProperty(RDFVocabulary.FOAF.ACCOUNT.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.ACCOUNT.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.ACCOUNT_NAME.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.AGE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.AGE.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.FOAF.ACCOUNT_SERVICE_HOMEPAGE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.ACCOUNT_SERVICE_HOMEPAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.AIM_CHAT_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.BASED_NEAR.ToString()).SetDomain(RDFGEOOntology.SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.FOAF.BASED_NEAR.ToString()).SetRange(RDFGEOOntology.SelectClass(RDFVocabulary.GEO.SPATIAL_THING.ToString()));
            SelectProperty(RDFVocabulary.FOAF.BIRTHDAY.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.BIRTHDAY.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.DATE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.CURRENT_PROJECT.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.DEPICTION.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.DEPICTS.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.FAMILY_NAME.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.FIRSTNAME.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.FOCUS.ToString()).SetDomain(RDFSKOSOntology.SelectClass(RDFVocabulary.SKOS.CONCEPT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.GEEK_CODE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.GENDER.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.GENDER.ToString()).SetRange(SelectClass("bnode:Genders"));
            SelectProperty(RDFVocabulary.FOAF.HOLDS_ACCOUNT.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.HOLDS_ACCOUNT.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.HOMEPAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.ICQ_CHAT_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.IMG.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.IMG.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.INTEREST.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.INTEREST.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.IS_PRIMARY_TOPIC_OF.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.JABBER_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.KNOWS.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.KNOWS.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MBOX.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MBOX_SHA1SUM.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MADE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MAKER.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MEMBER.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.GROUP.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MEMBER.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MSN_CHAT_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.MYERS_BRIGGS.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.OPEN_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.OPEN_ID.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PAST_PROJECT.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PLAN.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PRIMARY_TOPIC.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PUBLICATIONS.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.PUBLICATIONS.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.SCHOOL_HOMEPAGE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.SCHOOL_HOMEPAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.SKYPE_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.SHA1.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.STATUS.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.SURNAME.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.THUMBNAIL.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.THUMBNAIL.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.IMAGE.ToString()));
            SelectProperty(RDFVocabulary.FOAF.TIPJAR.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.TIPJAR.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.TOPIC.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.TOPIC_INTEREST.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WEBLOG.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WEBLOG.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WORKINFO_HOMEPAGE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WORKINFO_HOMEPAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WORKPLACE_HOMEPAGE.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.PERSON.ToString()));
            SelectProperty(RDFVocabulary.FOAF.WORKPLACE_HOMEPAGE.ToString()).SetRange(SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            SelectProperty(RDFVocabulary.FOAF.YAHOO_CHAT_ID.ToString()).SetDomain(SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the FOAF ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the FOAF ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the FOAF ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            return Instance.Data.SelectFact(ontFact);
        }
        #endregion

    }

}