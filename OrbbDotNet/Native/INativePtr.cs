using System;

namespace OrbbDotNet.Native;

/// <summary>
/// Base interface for all structures that wrap pointers to native objects.
/// Such structures are used instead of <see cref="IntPtr"/> for better type safety in native API.
/// </summary>
internal interface INativePtr
{
    /// <summary>Raw value of native pointer. Use with care.</summary>
    IntPtr UnsafeValue { get; }

    /// <summary>Release of native object referenced by pointer.</summary>
    /// <returns><see langword="true"/> in case of success, <see langword="false"/> in case of error.</returns>
    /// <remarks>Important! Can be called only once.</remarks>
    bool Release();
}
