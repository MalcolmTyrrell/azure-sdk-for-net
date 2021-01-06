﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The <see cref="RemoteRenderingClientOptions"/>.
    /// Implements the <see cref="Azure.Core.ClientOptions" />.
    /// </summary>
    /// <seealso cref="Azure.Core.ClientOptions" />
    public class RemoteRenderingClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        public RemoteRenderingClientOptions(ServiceVersion version = ServiceVersion.V2021_01_01_preview)
        {
            Version = version switch
            {
                ServiceVersion.V2021_01_01_preview => "V2021_01_01_preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Azure Remote Rendering service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version V2021_01_01_preview of the Azure Remote Rendering service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_01_01_preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
