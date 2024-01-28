using System.Reflection;
using System.Runtime.Serialization;

namespace System.Text.Json.Serialization
{
    /// <summary>
    /// <see cref="JsonConverterFactory"/> to convert enums to and from strings, respecting <see cref="EnumMemberAttribute"/> decorations. Supports nullable enums.
    /// </summary>
    public class JsonStringEnumMemberConverter : JsonConverterFactory
    {
        private readonly JsonNamingPolicy? _namingPolicy;

        private readonly bool _allowIntegerValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonStringEnumMemberConverter"/> class.
        /// </summary>
        public JsonStringEnumMemberConverter()
            : this(namingPolicy: null, allowIntegerValues: true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonStringEnumMemberConverter"/> class.
        /// </summary>
        /// <param name="namingPolicy">
        /// Optional naming policy for writing enum values.
        /// </param>
        /// <param name="allowIntegerValues">
        /// True to allow undefined enum values. When true, if an enum value isn't
        /// defined it will output as a number rather than a string.
        /// </param>
        public JsonStringEnumMemberConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
        {
            _namingPolicy = namingPolicy;
            _allowIntegerValues = allowIntegerValues;
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            // Don't perform a typeToConvert == null check for performance. Trust our callers will be nice.
            return typeToConvert.IsEnum || (typeToConvert.IsGenericType && TestNullableEnum(typeToConvert).IsNullableEnum);
        }

        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            (bool IsNullableEnum, Type? UnderlyingType) = TestNullableEnum(typeToConvert);

            return IsNullableEnum
                ? (JsonConverter)Activator.CreateInstance(
                    typeof(NullableEnumMemberConverter<>).MakeGenericType(UnderlyingType!)!,
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object?[] { _namingPolicy, _allowIntegerValues },
                    culture: null)!
                : (JsonConverter)Activator.CreateInstance(
                    typeof(EnumMemberConverter<>).MakeGenericType(typeToConvert)!,
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object?[] { _namingPolicy, _allowIntegerValues },
                    culture: null)!;
        }

        private static (bool IsNullableEnum, Type? UnderlyingType) TestNullableEnum(Type typeToConvert)
        {
            Type? UnderlyingType = Nullable.GetUnderlyingType(typeToConvert);

            return (UnderlyingType?.IsEnum ?? false, UnderlyingType);
        }

#pragma warning disable CA1812 // Remove class never instantiated
        private class EnumMemberConverter<TEnum> : JsonConverter<TEnum>
            where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
        {
            private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

            public EnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
            {
                _JsonStringEnumMemberConverterHelper = new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
            }

            public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return _JsonStringEnumMemberConverterHelper.Read(ref reader);
            }

            public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            {
                _JsonStringEnumMemberConverterHelper.Write(writer, value);
            }
        }

#pragma warning disable CA1812 // Remove class never instantiated
        private class NullableEnumMemberConverter<TEnum> : JsonConverter<TEnum?>
            where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
        {
            private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

            public NullableEnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
            {
                _JsonStringEnumMemberConverterHelper = new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
            }

            public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return _JsonStringEnumMemberConverterHelper.Read(ref reader);
            }

            public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
            {
                _JsonStringEnumMemberConverterHelper.Write(writer, value!.Value);
            }
        }
    }
}
