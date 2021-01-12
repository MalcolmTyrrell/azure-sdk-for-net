// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.MixedReality.RemoteRendering;

namespace Azure.MixedReality.RemoteRendering.Models
{
    /// <summary> The ErrorResponse. </summary>
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        internal ErrorResponse()
        {
        }

        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"> The error object containing details of why the request failed. </param>
        internal ErrorResponse(ErrorDetails error)
        {
            Error = error;
        }

        /// <summary> The error object containing details of why the request failed. </summary>
        public ErrorDetails Error { get; }
    }
}
