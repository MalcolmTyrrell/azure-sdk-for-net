// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering.Models
{
    public partial class SessionProperties
    {
        internal static SessionProperties DeserializeSessionProperties(JsonElement element)
        {
            Optional<string> id = default;
            Optional<int> arrInspectorPort = default;
            Optional<int> handshakePort = default;
            Optional<int> elapsedTimeMinutes = default;
            Optional<string> hostname = default;
            Optional<int> maxLeaseTimeMinutes = default;
            Optional<SessionSize> size = default;
            Optional<SessionStatus> status = default;
            Optional<float> teraflops = default;
            Optional<Error> error = default;
            Optional<DateTimeOffset> creationTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("arrInspectorPort"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    arrInspectorPort = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("handshakePort"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    handshakePort = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("elapsedTimeMinutes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    elapsedTimeMinutes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("hostname"))
                {
                    hostname = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxLeaseTimeMinutes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    maxLeaseTimeMinutes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    size = new SessionSize(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new SessionStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("teraflops"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    teraflops = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = Error.DeserializeError(property.Value);
                    continue;
                }
                if (property.NameEquals("creationTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    creationTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new SessionProperties(id.Value, Optional.ToNullable(arrInspectorPort), Optional.ToNullable(handshakePort), Optional.ToNullable(elapsedTimeMinutes), hostname.Value, Optional.ToNullable(maxLeaseTimeMinutes), Optional.ToNullable(size), Optional.ToNullable(status), Optional.ToNullable(teraflops), error.Value, Optional.ToNullable(creationTime));
        }
    }
}
