using System;
using System.Runtime.Serialization;

namespace OrbbDotNet;

partial class ObException
{
    /// <summary>SDK access IO exception error</summary>
    [Serializable]
    public class IO : ObException
    {
        /// <summary>Creates exception instance with parameters specified.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="functionName">The name of the API function that caused the error.</param>
        /// <param name="functionParameters">The error parameters.</param>
        public IO(string? message, string? sdkFunctionName, string? sdkFunctionParameters)
            : base(message, sdkFunctionName, sdkFunctionParameters)
        { }

        /// <summary>Constructor for deserialization needs.</summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected IO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
