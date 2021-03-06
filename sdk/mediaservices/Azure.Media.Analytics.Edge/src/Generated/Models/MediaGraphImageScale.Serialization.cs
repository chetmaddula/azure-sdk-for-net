// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphImageScale : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode");
                writer.WriteStringValue(Mode.Value.ToString());
            }
            if (Optional.IsDefined(Width))
            {
                writer.WritePropertyName("width");
                writer.WriteStringValue(Width);
            }
            if (Optional.IsDefined(Height))
            {
                writer.WritePropertyName("height");
                writer.WriteStringValue(Height);
            }
            writer.WriteEndObject();
        }

        internal static MediaGraphImageScale DeserializeMediaGraphImageScale(JsonElement element)
        {
            Optional<MediaGraphImageScaleMode> mode = default;
            Optional<string> width = default;
            Optional<string> height = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    mode = new MediaGraphImageScaleMode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("width"))
                {
                    width = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("height"))
                {
                    height = property.Value.GetString();
                    continue;
                }
            }
            return new MediaGraphImageScale(Optional.ToNullable(mode), width.Value, height.Value);
        }
    }
}
