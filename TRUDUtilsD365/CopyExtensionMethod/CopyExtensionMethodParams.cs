using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using System;
using System.Linq;
using System.Text;

namespace TRUDUtilsD365.CopyExtensionMethod
{
    public class CopyExtensionMethodParams
    {
        #region Member variables

        private const string StaticString = " static";

        #endregion

        public string CreateMethod(IMethodBase sourceMethod)
        {
            if (sourceMethod == null)
            {
                throw new Exception("sourceMethod is null");
            }
            var attributes = sourceMethod.DataContractAttributes.OfType<IAttributeItem>();

            Boolean isWrappableAttrib = (attributes != null && attributes.Any(attribute =>
                    attribute.Name == "Wrappable" &&
                    string.Equals(attribute.Parameters[0].TypeValue, Boolean.TrueString)));


            if (sourceMethod.IsFinal && !isWrappableAttrib)
            {
                throw new Exception("Final method could not be extended");
            }

            if (!(sourceMethod.Visibility == CompilerVisibility.Protected ||
                  sourceMethod.Visibility == CompilerVisibility.Public))
            {
                throw new Exception("Only protected and public methods can be extended");
            }

            
            if (attributes != null && attributes.Any(attribute =>
                    attribute.Name == "Wrappable" &&
                    string.Equals(attribute.Parameters[0].TypeValue, Boolean.FalseString)))
            {
                throw new Exception("Only Wrappable methods could be extended");
            }

            if (attributes != null && attributes.Any(attribute => attribute.Name.Contains("InternalUseOnlyAttribute")))
            {
                throw new Exception("Method is marked with InternalUseOnlyAttribute and can not be extended");
            }

            string parametersString = string.Empty;
            string nextParameters = string.Empty;
            var parameters = sourceMethod.Parameters.OfType<IMethodParameter>();
            if (parameters != null && parameters.Any())
            {
                parametersString = string.Join(", ",
                    parameters.Select(parameter =>
                        GetTypeNameFromCompilerType(parameter.TypeCompiler, parameter.TypeName) + " " + parameter.Name +
                        (parameter.IsArray ? "[]" : string.Empty)));
                nextParameters = string.Join(", ",
                    parameters.Select(parameter => parameter.Name + (parameter.IsArray ? "[]" : string.Empty)));
            }

            string nextString = $"next {sourceMethod.Name}({nextParameters});";
            StringBuilder methodText = new StringBuilder();
            string returnType =
                GetTypeNameFromCompilerType(sourceMethod.ReturnType.TypeCompiler, sourceMethod.ReturnType.TypeName);
            methodText.AppendLine(
                $"{sourceMethod.Visibility.ToString().ToLower()}{(sourceMethod.IsStatic ? StaticString : string.Empty)} {returnType} {sourceMethod.Name}({parametersString})");
            methodText.AppendLine("{");
            if (sourceMethod.ReturnType.TypeCompiler != CompilerBaseType.Void)
            {
                methodText.AppendLine($"\t{returnType} ret = {nextString}");
                methodText.AppendLine();
                methodText.AppendLine($"\treturn ret;");
            }
            else
            {
                methodText.AppendLine($"\t{nextString}");
            }

            methodText.AppendLine("}");
            return methodText.ToString();
        }

        private static string GetTypeNameFromCompilerType(CompilerBaseType compilerType, string compilerTypeName)
        {
            switch (compilerType)
            {
                case CompilerBaseType.String:
                    return "str";
                case CompilerBaseType.Int32:
                case CompilerBaseType.Time:
                    return "int";
                case CompilerBaseType.Int64:
                    return "int64";
                case CompilerBaseType.Enum:
                case CompilerBaseType.ExtendedDataType:
                case CompilerBaseType.ClrType:
                case CompilerBaseType.Class:
                case CompilerBaseType.Record:
                case CompilerBaseType.FormElementType:
                    return compilerTypeName;
                case CompilerBaseType.DateTime:
                    return "utcdatetime";
                case CompilerBaseType.AnyType:
                    return "anytype";
                case CompilerBaseType.Guid:
                    return "guid";
                case CompilerBaseType.Real:
                    return "real";
                case CompilerBaseType.Date:
                    return "date";
                case CompilerBaseType.Container:
                    return "container";
                case CompilerBaseType.Void:
                    return "void";
                default:
                    throw new ArgumentException("Unknown modifier");
            }
        }
    }
}
