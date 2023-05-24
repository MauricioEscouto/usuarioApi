using System.Text.Json;
using System.Text.Json.Serialization;

namespace usuarioApi.Shared.Converts.Json
{
    public class ValueTupleFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            Type iTuple = typeToConvert.GetInterface("System.Runtime.CompilerServices.ITuple");
            return iTuple != null;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type[] genericArguments = typeToConvert.GetGenericArguments();

            Type converterType = genericArguments.Length switch
            {
                1 => typeof(ValueTupleConverter<>).MakeGenericType(genericArguments),
                2 => typeof(ValueTupleConverter<,>).MakeGenericType(genericArguments),
                3 => typeof(ValueTupleConverter<,,>).MakeGenericType(genericArguments),
                // And add other cases as needed
                _ => throw new NotSupportedException(),
            };
            return (JsonConverter)Activator.CreateInstance(converterType);
        }
    }
}