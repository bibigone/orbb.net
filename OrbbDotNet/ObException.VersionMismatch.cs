using System;
using System.Runtime.Serialization;

namespace OrbbDotNet;

partial class ObException
{
    /// <summary>Exception caused by API version mismatch</summary>
    [Serializable]
    public class VersionMismatch : ObException
    {
        /// <summary>Creates exception instance with parameters specified.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="functionName">The name of the API function that caused the error.</param>
        /// <param name="functionParameters">The error parameters.</param>
        public VersionMismatch(string? message, string? sdkFunctionName, string? sdkFunctionParameters)
            : base(message, sdkFunctionName, sdkFunctionParameters)
        { }

        /// <summary>Constructor for deserialization needs.</summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected VersionMismatch(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
