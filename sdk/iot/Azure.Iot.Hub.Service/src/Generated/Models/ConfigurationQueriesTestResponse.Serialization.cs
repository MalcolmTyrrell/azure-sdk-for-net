// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Iot.Hub.Service.Models
{
    public partial class ConfigurationQueriesTestResponse
    {
        internal static ConfigurationQueriesTestResponse DeserializeConfigurationQueriesTestResponse(JsonElement element)
        {
            string targetConditionError = default;
            IReadOnlyDictionary<string, string> customMetricQueryErrors = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("targetConditionError"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    targetConditionError = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customMetricQueryErrors"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(property0.Name, property0.Value.GetString());
                        }
                    }
                    customMetricQueryErrors = dictionary;
                    continue;
                }
            }
            return new ConfigurationQueriesTestResponse(targetConditionError, customMetricQueryErrors);
        }
    }
}