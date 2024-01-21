using System;
using System.Runtime.Serialization;

namespace OrbbDotNet;

partial class ObException
{
    /// <summary>SDK access and use memory errors, which means that the frame fails to allocate memory.</summary>
    [Serializable]
    public class Memory : ObException
    {
        /// <summary>Creates exception instance with parameters specified.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="functionName">The name of the API function that caused the error.</param>
        /// <param name="functionParameters">The error parameters.</param>
        public Memory(string? message, string? sdkFunctionName, string? sdkFunctionParameters)
            : base(message, sdkFunctionName, sdkFunctionParameters)
        { }

        /// <summary>Constructor for deserialization needs.</summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected Memory(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
