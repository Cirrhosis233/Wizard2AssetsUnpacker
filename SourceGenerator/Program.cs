using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace SourceGenerator
{
    public class Program
    {
        private static Dictionary<string, string> ClassDefs = [];

        static string DummyDllPath = Path.Combine(Directory.GetCurrentDirectory(), "DummyDll");

        static string GetTypeString(PropertyInfo propertyInfo)
        {
            var name = propertyInfo.PropertyType.Name.ToString();
            if (name == "Single") return "Single";

            return name
                .ToLower()
                .Replace("int16", "short")
                .Replace("int32", "int")
                .Replace("int64", "long")
                .Replace("boolean", "bool");
        }

        static string GetEnumDef(Type enumType)
        {
            var builder = new StringBuilder();
            builder.Append($"public enum {enumType.Name} : uint");
            builder.Append(" {");

            var values = enumType.GetEnumValuesAsUnderlyingType();

            foreach (var value in values)
            {
                builder.Append($"{enumType.GetEnumName(value)} = {value},");
            }

            builder.Append('}');

            return builder.ToString();
        }

        static Dictionary<uint, string> GetEnumValueToKey(Type enumType)
        {
            var result = new Dictionary<uint, string>();

            var values = enumType.GetEnumValuesAsUnderlyingType();
            foreach (var value in values)
            {
                result.Add(value is int ? Convert.ToUInt32(value) : (uint)value, enumType.GetEnumName(value));
            }

            return result;
        }

        static bool IsPrimitive(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return false;
            if (propertyInfo.PropertyType.Name == "String" || propertyInfo.PropertyType.IsPrimitive) return true;

            if (propertyInfo.PropertyType.IsArray)
            {
                var elementType = propertyInfo.PropertyType.GetElementType();
                if (elementType.Name == "String" || elementType.IsPrimitive) return true;
            }
            return false;
        }

        static string GetClassDef(Type klass)
        {
            var attributeList = new List<string>();
            foreach (var attribute in klass.GetCustomAttributesData())
            {
                if (attribute.AttributeType.FullName == "Il2CppDummyDll.TokenAttribute") continue;

                var attrBuilder = new StringBuilder();

                attrBuilder.Append($"[{attribute.AttributeType.Name.Replace("Attribute", "")}");

                var propertyAttrArgList = new List<string>();
                foreach (var attributeArg in attribute.ConstructorArguments)
                {
                    var argValue = attributeArg.Value.ToString();
                    if (attributeArg.ArgumentType.Name == "String") argValue = $"\"{argValue}\"";
                    if (attributeArg.ArgumentType.Name == "Boolean") argValue = argValue.ToLower();
                    propertyAttrArgList.Add(argValue);
                }
                if (propertyAttrArgList.Count > 0)
                {
                    attrBuilder.Append('(');
                    attrBuilder.AppendJoin(",", propertyAttrArgList);
                    attrBuilder.Append(')');
                }
                attrBuilder.Append(']');
                attributeList.Add(attrBuilder.ToString());
            }

            var propertiesList = new List<string>();
            foreach (var property in klass.GetProperties())
            {
                var builder = new StringBuilder();

                foreach (var attribute in property.GetCustomAttributesData())
                {
                    if (attribute.AttributeType.FullName == "Il2CppDummyDll.TokenAttribute") continue;

                    builder.Append($"[{attribute.AttributeType.Name.Replace("Attribute", "")}");

                    var propertyAttrArgList = new List<string>();
                    foreach (var attributeArg in attribute.ConstructorArguments)
                    {
                        var literal = attributeArg.Value.ToString();
                        if (attributeArg.ArgumentType.IsEnum)
                        {
                            var enumType = attributeArg.ArgumentType;
                            var valueToKey = GetEnumValueToKey(enumType);
                            var value = attributeArg.Value;

                            literal = $"{enumType.Name}.{valueToKey[value is int ? Convert.ToUInt32(value) : (uint)attributeArg.Value]}";
                        }

                        propertyAttrArgList.Add(literal);
                    }
                    if (propertyAttrArgList.Count > 0)
                    {
                        builder.Append('(');
                        builder.AppendJoin(",", propertyAttrArgList);
                        builder.Append(')');
                    }
                    builder.AppendLine("]");
                }

                string propertyTypeName;
                var isEnumArray = property.PropertyType.IsArray && property.PropertyType.GetElementType().IsEnum;

                if (IsPrimitive(property)) propertyTypeName = GetTypeString(property);
                else if (property.PropertyType.IsEnum || isEnumArray)
                {
                    var propertyType = isEnumArray ? property.PropertyType.GetElementType() : property.PropertyType;
                    propertyTypeName = property.PropertyType.Name;
                    ClassDefs.TryAdd(property.PropertyType.Name, GetEnumDef(propertyType));
                }
                else
                {
                    propertyTypeName = property.PropertyType.Name;
                    ClassDefs.TryAdd(property.PropertyType.Name, GetClassDef(property.PropertyType));
                }
                var propertyName = property.Name.ToString();

                builder.Append($"public {propertyTypeName} {propertyName} {{ get; set; }}");

                propertiesList.Add(builder.ToString());
            }

            return $"\r\n{string.Join("\n", attributeList)}\r\npublic class {klass.Name.Replace("[]", "")} {{\r\n {string.Join("\n", propertiesList)} \r\n}}";
        }

        static void Main(string[] args)
        {
            var builder = new StringBuilder(@"using MasterMemory;
using MessagePack;

namespace Wizard2AssetsUnpacker.Models.Generated
{
");

            var resolver = new PathAssemblyResolver([
                ..Directory.GetFiles(DummyDllPath, "*.dll"),
                ..Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll")
            ]);

            using var context = new MetadataLoadContext(resolver);
            Assembly Domain = context.LoadFromAssemblyPath(Path.Combine(DummyDllPath, "Domain.dll"));
            Assembly MasterMemory = context.LoadFromAssemblyPath(Path.Combine(DummyDllPath, "MasterMemory.dll"));
            Assembly CuteLocalize = context.LoadFromAssemblyPath(Path.Combine(DummyDllPath, "Cute.Localize.Assembly.dll"));
            Assembly CuteAssetBundle = context.LoadFromAssemblyPath(Path.Combine(DummyDllPath, "Cute.AssetBundle.Assembly.dll"));

            Type[] TableTypes = [
                Domain.GetType("Wizard2.Domain.MasterData"),
                CuteAssetBundle.GetType("Cute.AssetBundle.MemoryDatabase"),
                CuteLocalize.GetType("Cute.Localize.MemoryDatabase")
            ];

            Type TableBase = MasterMemory.GetType("MasterMemory.TableBase`1");

            foreach (Type t in TableTypes)
            {
                foreach (var property in t.GetProperties())
                {
                    var baseType = property.PropertyType.BaseType;
                    if (baseType.Name == "TableBase`1")
                    {
                        var genericArg = baseType.GetGenericArguments()[0];
                        var classDef = GetClassDef(genericArg);

                        ClassDefs.TryAdd(genericArg.Name, classDef);
                    }
                }
            }

            builder.AppendLine(string.Join("\n", ClassDefs.Values));
            builder.Append('}');
            File.WriteAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../Wizard2AssetsUnpacker/Models/Generated/Generated.cs"),
                builder.ToString()
            );
        }
    }
}
