// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering.Models
{
    public partial class UpdateSessionBody : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("maxLeaseTimeMinutes");
            writer.WriteNumberValue(MaxLeaseTimeMinutes);
            writer.WriteEndObject();
        }
    }
}
