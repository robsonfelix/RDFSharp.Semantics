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
    /// RDFFOAFOntology represents an OWL-DL ontology implementation of SIOC vocabulary
    /// </summary>
    public static class RDFSIOCOntology {

        #region Properties
        /// <summary>
        /// Singleton instance of the SIOC ontology
        /// </summary>
        internal static RDFOntology Instance { get; set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the SIOC ontology
        /// </summary>
        static RDFSIOCOntology() {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource("http://rdfsharpsemantics.codeplex.com/sioc_ontology#"));
            #endregion

            #region Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.COMMUNITY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.CONTAINER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.FORUM.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.ITEM.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.POST.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.ROLE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.SPACE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.SITE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.THREAD.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.USER_GROUP.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.SIOC.USER.ToRDFOntologyClass().SetDeprecated(true));

            //OWL-DL Completeness
            Instance.Model.ClassModel.AddClass(new RDFOntologyClass(new RDFResource("http://www.w3.org/2004/03/trix/rdfg-1/Graph")));
            #endregion

            #region Properties
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ABOUT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ACCOUNT_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ADDRESSED_TO.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ADMINISTRATOR_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ATTACHMENT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.AVATAR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.CONTAINER_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.CONTENT.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.CONTENT_ENCODED.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.CREATED_AT.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.CREATOR_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.DESCRIPTION.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.EARLIER_VERSION.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.EMAIL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.EMAIL_SHA1.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.EMBEDS_KNOWLEDGE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.FEED.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.FIRST_NAME.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.FOLLOWS.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.FUNCTION_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.GROUP_OF.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_ADMINISTRATOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_CONTAINER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_CREATOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_DISCUSSION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_FUNCTION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_GROUP.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_HOST.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_MEMBER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_MODERATOR.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_MODIFIER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_OWNER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_PARENT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_PART.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_REPLY.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_SCOPE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_SPACE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_SUBSCRIBER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HAS_USERGROUP.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.HOST_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.ID.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.IP_ADDRESS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LAST_ACTIVITY_DATE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LAST_ITEM_DATE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LAST_NAME.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LAST_REPLY_DATE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LATER_VERSION.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LATEST_VERSION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LINK.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.LINKS_TO.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.MEMBER_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.MODERATOR_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.MODIFIED_AT.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.MODIFIER_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NAME.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NEXT_BY_DATE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NEXT_VERSION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NOTE.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NUM_AUTHORS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NUM_ITEMS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NUM_REPLIES.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NUM_THREADS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.NUM_VIEWS.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.OWNER_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.PARENT_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.PART_OF.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.PREVIOUS_BY_DATE.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.PREVIOUS_VERSION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.REFERENCE.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.RELATED_TO.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.REPLY_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.SCOPE_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.SIBLING.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.SPACE_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.SUBJECT.ToRDFOntologyObjectProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.SUBSCRIBER_OF.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.TITLE.ToRDFOntologyDatatypeProperty().SetDeprecated(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.TOPIC.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.SIOC.USERGROUP_OF.ToRDFOntologyObjectProperty());
            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()),          SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.POST.ToString()),           SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.POST.ToString()),           RDFFOAFOntology.SelectClass(RDFVocabulary.FOAF.DOCUMENT.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.SITE.ToString()),           SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.THREAD.ToString()),         SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()),   RDFFOAFOntology.SelectClass(RDFVocabulary.FOAF.ONLINE_ACCOUNT.ToString()));

            //EquivalentClass
            Instance.Model.ClassModel.AddEquivalentClassRelation(SelectClass(RDFVocabulary.SIOC.USER.ToString()),      SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));

            //DisjointWith
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.COMMUNITY.ToString()),    SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.COMMUNITY.ToString()),    SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.COMMUNITY.ToString()),    SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()),    SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()),    SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()),    SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()),    SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()),         SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()),         SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()),         SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()),         SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()),         SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()),         SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()),         SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()),        SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()),        SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()), SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.AVATAR.ToString()),               (RDFOntologyObjectProperty)RDFFOAFOntology.SelectProperty(RDFVocabulary.FOAF.DEPICTION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_REPLY.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.RELATED_TO.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.SIOC.LAST_ACTIVITY_DATE.ToString()), (RDFOntologyDatatypeProperty)RDFDCOntology.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.SIOC.LAST_ITEM_DATE.ToString()),     (RDFOntologyDatatypeProperty)RDFDCOntology.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyDatatypeProperty)SelectProperty(RDFVocabulary.SIOC.LAST_REPLY_DATE.ToString()),    (RDFOntologyDatatypeProperty)RDFDCOntology.SelectProperty(RDFVocabulary.DC.DCTERMS.DATE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.LINKS_TO.ToString()),             (RDFOntologyObjectProperty)RDFDCOntology.SelectProperty(RDFVocabulary.DC.DCTERMS.REFERENCES.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.NEXT_VERSION.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.LATER_VERSION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.PREVIOUS_VERSION.ToString()),     (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.EARLIER_VERSION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.REPLY_OF.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.RELATED_TO.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.TOPIC.ToString()),                (RDFOntologyObjectProperty)RDFDCOntology.SelectProperty(RDFVocabulary.DC.DCTERMS.SUBJECT.ToString()));

            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.ACCOUNT_OF.ToString()),               (RDFOntologyObjectProperty)RDFFOAFOntology.SelectProperty(RDFVocabulary.FOAF.ACCOUNT.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.ADMINISTRATOR_OF.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_ADMINISTRATOR.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.CONTAINER_OF.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_CONTAINER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.CREATOR_OF.ToString()),               (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_CREATOR.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.FUNCTION_OF.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_FUNCTION.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.GROUP_OF.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_GROUP.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HOST_OF.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_HOST.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.MEMBER_OF.ToString()),                (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_MEMBER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.MODERATOR_OF.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_MODERATOR.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.MODIFIER_OF.ToString()),              (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_MODIFIER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.OWNER_OF.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_OWNER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.PARENT_OF.ToString()),                (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_PARENT.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.PART_OF.ToString()),                  (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_PART.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.REPLY_OF.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_REPLY.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.SCOPE_OF.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_SCOPE.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.SPACE_OF.ToString()),                 (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_SPACE.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.SUBSCRIBER_OF.ToString()),            (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_SUBSCRIBER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.USERGROUP_OF.ToString()),             (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.HAS_USERGROUP.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.EARLIER_VERSION.ToString()),          (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.LATER_VERSION.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.PREVIOUS_VERSION.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.NEXT_VERSION.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.PREVIOUS_BY_DATE.ToString()),         (RDFOntologyObjectProperty)SelectProperty(RDFVocabulary.SIOC.NEXT_BY_DATE.ToString()));

            //Domain/Range
            SelectProperty(RDFVocabulary.SIOC.ABOUT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ACCOUNT_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ACCOUNT_OF.ToString()).SetRange(RDFFOAFOntology.SelectClass(RDFVocabulary.FOAF.AGENT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ADDRESSED_TO.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ADMINISTRATOR_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ADMINISTRATOR_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.SITE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.ATTACHMENT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.AVATAR.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CONTAINER_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CONTAINER_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CONTENT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CONTENT_ENCODED.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CREATED_AT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.CREATOR_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.DESCRIPTION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EARLIER_VERSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EARLIER_VERSION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EMAIL.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EMAIL_SHA1.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EMBEDS_KNOWLEDGE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.EMBEDS_KNOWLEDGE.ToString()).SetRange(SelectClass("http://www.w3.org/2004/03/trix/rdfg-1/Graph"));
            SelectProperty(RDFVocabulary.SIOC.FIRST_NAME.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.FOLLOWS.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.FOLLOWS.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.FUNCTION_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_ADMINISTRATOR.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.SITE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_ADMINISTRATOR.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_CONTAINER.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_CONTAINER.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_CREATOR.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_DISCUSSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_FUNCTION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_HOST.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_HOST.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.SITE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MEMBER.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MEMBER.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MODERATOR.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MODERATOR.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MODIFIER.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_MODIFIER.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_OWNER.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_PARENT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_PARENT.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_REPLY.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_REPLY.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_SCOPE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_SPACE.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_SUBSCRIBER.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_SUBSCRIBER.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_USERGROUP.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HAS_USERGROUP.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HOST_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.SITE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.HOST_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.IP_ADDRESS.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LAST_ITEM_DATE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LAST_NAME.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LATER_VERSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LATER_VERSION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LATEST_VERSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.LATEST_VERSION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MEMBER_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MEMBER_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MODIFIED_AT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MODERATOR_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MODERATOR_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MODIFIER_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.MODIFIER_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NEXT_BY_DATE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NEXT_BY_DATE.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NEXT_VERSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NEXT_VERSION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_AUTHORS.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_ITEMS.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_ITEMS.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_REPLIES.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_THREADS.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.FORUM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_THREADS.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.NUM_VIEWS.ToString()).SetRange(RDFBASEOntology.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.OWNER_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PARENT_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PARENT_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PREVIOUS_BY_DATE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PREVIOUS_BY_DATE.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PREVIOUS_VERSION.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.PREVIOUS_VERSION.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.REFERENCE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.REPLY_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.REPLY_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SCOPE_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ROLE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SIBLING.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SIBLING.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.ITEM.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SPACE_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SUBJECT.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SUBSCRIBER_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_ACCOUNT.ToString()));
            SelectProperty(RDFVocabulary.SIOC.SUBSCRIBER_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.CONTAINER.ToString()));
            SelectProperty(RDFVocabulary.SIOC.TITLE.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.POST.ToString()));
            SelectProperty(RDFVocabulary.SIOC.USERGROUP_OF.ToString()).SetDomain(SelectClass(RDFVocabulary.SIOC.USER_GROUP.ToString()));
            SelectProperty(RDFVocabulary.SIOC.USERGROUP_OF.ToString()).SetRange(SelectClass(RDFVocabulary.SIOC.SPACE.ToString()));

            #endregion

            #endregion

        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the given class from the SIOC ontology
        /// </summary>
        public static RDFOntologyClass SelectClass(String ontClass) {
            return Instance.Model.ClassModel.SelectClass(ontClass);
        }

        /// <summary>
        /// Gets the given property from the SIOC ontology
        /// </summary>
        public static RDFOntologyProperty SelectProperty(String ontProperty) {
            return Instance.Model.PropertyModel.SelectProperty(ontProperty);
        }

        /// <summary>
        /// Gets the given fact from the SIOC ontology
        /// </summary>
        public static RDFOntologyFact SelectFact(String ontFact) {
            return Instance.Data.SelectFact(ontFact);
        }
        #endregion

    }

}