using System;
using System.Runtime.Serialization;

namespace OrbbDotNet;

partial class ObException
{
    /// <summary>SDK device disconnection exception</summary>
    [Serializable]
    public class CameraDisconnected : ObException
    {
        /// <summary>Creates exception instance with parameters specified.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="functionName">The name of the API function that caused the error.</param>
        /// <param name="functionParameters">The error parameters.</param>
        public CameraDisconnected(string? message, string? functionName, string? functionParameters)
            : base(message, functionName, functionParameters)
        { }

        /// <summary>Constructor for deserialization needs.</summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected CameraDisconnected(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
