using System;
using System.Linq;
using RDFSharp.Model;

namespace RDFSharp.Semantics {

    /// <summary>
    /// RDFOntologyInitializer prepares an ontology for the first use,
    /// injecting all the needed classes, properties and taxonomies 
    /// </summary>
    internal class RDFOntologyInitializer {

        #region Methods
        internal static void PrepareOntology(RDFOntology ontology) {

            //Classes
            ontology.Model.ClassModel.Classes.Add(RDFOntologyVocabulary.Classes.THING.PatternMemberID,   RDFOntologyVocabulary.Classes.THING);
            ontology.Model.ClassModel.Classes.Add(RDFOntologyVocabulary.Classes.NOTHING.PatternMemberID, RDFOntologyVocabulary.Classes.NOTHING);

            //Datatypes
            foreach(var dType   in RDFDatatypeRegister.Instance) {
                var  dTypeCls    = new RDFOntologyClass(new RDFResource(dType.ToString()));
                ontology.Model.ClassModel.Classes.Add(dTypeCls.PatternMemberID, dTypeCls);
            }

            //Annotations
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.VERSION_INFO.PatternMemberID,             RDFOntologyVocabulary.AnnotationProperties.VERSION_INFO);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.COMMENT.PatternMemberID,                  RDFOntologyVocabulary.AnnotationProperties.COMMENT);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.LABEL.PatternMemberID,                    RDFOntologyVocabulary.AnnotationProperties.LABEL);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.SEE_ALSO.PatternMemberID,                 RDFOntologyVocabulary.AnnotationProperties.SEE_ALSO);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.IS_DEFINED_BY.PatternMemberID,            RDFOntologyVocabulary.AnnotationProperties.IS_DEFINED_BY);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.VERSION_IRI.PatternMemberID,              RDFOntologyVocabulary.AnnotationProperties.VERSION_IRI);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.PRIOR_VERSION.PatternMemberID,            RDFOntologyVocabulary.AnnotationProperties.PRIOR_VERSION);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.INCOMPATIBLE_WITH.PatternMemberID,        RDFOntologyVocabulary.AnnotationProperties.INCOMPATIBLE_WITH);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.BACKWARD_COMPATIBLE_WITH.PatternMemberID, RDFOntologyVocabulary.AnnotationProperties.BACKWARD_COMPATIBLE_WITH);
            ontology.Model.PropertyModel.Properties.Add(RDFOntologyVocabulary.AnnotationProperties.IMPORTS.PatternMemberID,                  RDFOntologyVocabulary.AnnotationProperties.IMPORTS);

            //Taxonomies - Primitive Datatypes
            var rdfsLiteralCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.RDFS.LITERAL.ToString());
            var rdfXmlLitCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.RDF.XML_LITERAL.ToString());
            var rdfHtmlCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.RDF.HTML.ToString());
            var xsdStringCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.STRING.ToString());
            var xsdBooleanCls    = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BOOLEAN.ToString());
            var xsdBase64Cls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BASE64_BINARY.ToString());
            var xsdHexBinCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.HEX_BINARY.ToString());
            var xsdFloatCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.FLOAT.ToString());
            var xsdDecimalCls    = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DECIMAL.ToString());
            var xsdDoubleCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DOUBLE.ToString());
            var xsdAnyUriCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.ANY_URI.ToString());
            var xsdQNameCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.QNAME.ToString());
            var xsdNotationCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NOTATION.ToString());
            var xsdDurationCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DURATION.ToString());
            var xsdDateTimeCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATETIME.ToString());
            var xsdTimeCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TIME.ToString());
            var xsdDateCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.DATE.ToString());
            var xsdGYearMonthCls = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToString());
            var xsdGYearCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_YEAR.ToString());
            var xsdGMonthDayCls  = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH_DAY.ToString());
            var xsdGDayCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_DAY.ToString());
            var xsdGMonthCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.G_MONTH.ToString());
            ontology.Model.ClassModel.AddSubClassOfRelation(rdfXmlLitCls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(rdfHtmlCls,       rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdStringCls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdBooleanCls,    rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdBase64Cls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdHexBinCls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdFloatCls,      rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdDecimalCls,    rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdDoubleCls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdAnyUriCls,     rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdQNameCls,      rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNotationCls,   rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdDurationCls,   rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdDateTimeCls,   rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdTimeCls,       rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdDateCls,       rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdGYearMonthCls, rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdGYearCls,      rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdGMonthDayCls,  rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdGDayCls,       rdfsLiteralCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdGMonthCls,     rdfsLiteralCls);

            //Taxonomies - Derived Datatypes
            var xsdNormStringCls = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToString());
            var xsdTokenCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.TOKEN.ToString());
            var xsdLanguageCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.LANGUAGE.ToString());
            var xsdNameCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NAME.ToString());
            var xsdNMTokenCls    = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NMTOKEN.ToString());
            var xsdNCNameCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NCNAME.ToString());
            var xsdIntegerCls    = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INTEGER.ToString());
            var xsdNPIntegerCls  = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToString());
            var xsdNIntegerCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToString());
            var xsdNNIntegerCls  = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToString());
            var xsdPIntegerCls   = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.POSITIVE_INTEGER.ToString());
            var xsdLongCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.LONG.ToString());
            var xsdIntCls        = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.INT.ToString());
            var xsdShortCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.SHORT.ToString());
            var xsdByteCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.BYTE.ToString());
            var xsdULongCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToString());
            var xsdUIntCls       = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_INT.ToString());
            var xsdUShortCls     = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToString());
            var xsdUByteCls      = ontology.Model.ClassModel.SelectClass(RDFVocabulary.XSD.UNSIGNED_BYTE.ToString());
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNormStringCls, xsdStringCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdTokenCls,      xsdNormStringCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdLanguageCls,   xsdTokenCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNameCls,       xsdTokenCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNMTokenCls,    xsdTokenCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNCNameCls,     xsdNameCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdIntegerCls,    xsdDecimalCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNPIntegerCls,  xsdIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNNIntegerCls,  xsdIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdLongCls,       xsdIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdNIntegerCls,   xsdNPIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdIntCls,        xsdLongCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdShortCls,      xsdIntCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdByteCls,       xsdShortCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdPIntegerCls,   xsdNNIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdULongCls,      xsdNNIntegerCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdUIntCls,       xsdULongCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdUShortCls,     xsdUIntCls);
            ontology.Model.ClassModel.AddSubClassOfRelation(xsdUByteCls,      xsdUShortCls);

            //Taxonomy - Custom Datatypes
            foreach(var customDType  in RDFDatatypeRegister.Instance.Where(dt =>
                                           !dt.Prefix.Equals(RDFVocabulary.XSD.PREFIX,  StringComparison.Ordinal)  &&
                                           !dt.Prefix.Equals(RDFVocabulary.RDF.PREFIX,  StringComparison.Ordinal)  &&
                                           !dt.Prefix.Equals(RDFVocabulary.RDFS.PREFIX, StringComparison.Ordinal))) {

                var customDTypeCls    = ontology.Model.ClassModel.SelectClass(customDType.ToString());
                if (customDTypeCls   != null) {
                    switch(customDType.Category) {
                        case RDFModelEnums.RDFDatatypeCategory.Boolean:
                             ontology.Model.ClassModel.AddSubClassOfRelation(customDTypeCls, xsdBooleanCls);
                             break;
                        case RDFModelEnums.RDFDatatypeCategory.DateTime:
                             ontology.Model.ClassModel.AddSubClassOfRelation(customDTypeCls, xsdDateTimeCls);
                             break;
                        case RDFModelEnums.RDFDatatypeCategory.Numeric:
                             ontology.Model.ClassModel.AddSubClassOfRelation(customDTypeCls, xsdDecimalCls);
                             break;
                        case RDFModelEnums.RDFDatatypeCategory.String:
                             ontology.Model.ClassModel.AddSubClassOfRelation(customDTypeCls, xsdStringCls);
                             break;
                        case RDFModelEnums.RDFDatatypeCategory.TimeSpan:
                             ontology.Model.ClassModel.AddSubClassOfRelation(customDTypeCls, xsdDurationCls);
                             break;
                    }
                }
            }

        }
        #endregion

    }

}