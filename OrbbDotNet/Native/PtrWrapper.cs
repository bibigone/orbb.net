using System;
using System.Threading;

namespace OrbbDotNet.Native;

/// <summary>
/// Helper wrapper around native pointer structures that implement <see cref="INativePtr"/> interface.
/// Implements <see cref="IDisposablePlus"/> interface, which is really helpful in implementation of public classes.
/// Plus this class has a finalyzer that calls <see cref="INativePtr.Release"/> for objects that were not disposed in an explicit manner.
/// </summary>
/// <typeparam name="T">Type of native handle.</typeparam>
internal sealed class PtrWrapper<T> : IDisposablePlus, IEquatable<PtrWrapper<T>>
    where T : struct, INativePtr
{
    private readonly T ptr;                     // underlying native pointer
    private volatile int releaseCounter;        // to release handle only once

    /// <summary>Creates <see cref="IDisposablePlus"/>-wrapper around specified native pointer.</summary>
    /// <param name="ptr">Handle to be wrapped. Must be valid.</param>
    /// <exception cref="ArgumentException">If <paramref name="ptr"/> is invalid.</exception>
    public PtrWrapper(T ptr)
    {
        if (ptr.UnsafeValue == IntPtr.Zero)
            throw new ArgumentException("Pointer must be valid", nameof(ptr));
        this.ptr = ptr;
    }

    /// <summary>Direct access to the underlying pointer object.</summary>
    public T Value => ptr;

    /// <summary>Like <see cref="Value"/> but checks that object is not disposed in addition.</summary>
    /// <exception cref="ObjectDisposedException">If object is disposed.</exception>
    /// <seealso cref="IsDisposed"/>
    public T ValueNotDisposed
    {
        get
        {
            CheckNotDisposed();
            return ptr;
        }
    }

    /// <summary>Calls <see cref="INativePtr.Release"/> for objects that were not disposed in an explicit manner.</summary>
    ~PtrWrapper()
        => ReleasePtr(disposing: false);

    /// <summary>
    /// Disposes underlying handle
    /// plus raises <see cref="Disposed"/> event if it is the first call of this method for the object.
    /// </summary>
    /// <seealso cref="IsDisposed"/>
    public void Dispose()
    {
        if (ReleasePtr(disposing: true))
        {
            GC.SuppressFinalize(this);
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>Releases pointer only once.</summary>
    /// <param name="disposing"><see langword="true"/> means call from <see cref="IDisposable.Dispose"/> method, <see langword="false"/> - from finalizer.</param>
    /// <returns><see langword="true"/> - pointer was really released.</returns>
    private bool ReleasePtr(bool disposing)
    {
        // Release only once
        var incrementedValue = Interlocked.Increment(ref releaseCounter);
        if (incrementedValue == 1)
        {
            var ok = ptr.Release();
            if (!ok && disposing)
                throw new InvalidOperationException($"Cannot release {this} native pointer.");
            return true;
        }
        return false;
    }

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => releaseCounter > 0;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    /// <summary>Checks that object is not disposed.</summary>
    /// <exception cref="ObjectDisposedException">If object is disposed.</exception>
    public void CheckNotDisposed()
    {
        if (releaseCounter > 0)
            throw new ObjectDisposedException(ToString());
    }

    /// <summary>Implicit conversion from pointer to wrapper for usability.</summary>
    /// <param name="ptr">Native pointer to be wrapped.</param>
    public static implicit operator PtrWrapper<T>(T ptr)
        => new(ptr);

    /// <summary>String representation of underlying native pointer.</summary>
    /// <returns><c>{PointerTypeName}#{Address}</c></returns>
    public override string ToString()
        => ptr.GetType().Name + "#" + ptr.UnsafeValue.ToString("X");

    #region Equatable

    /// <summary>Delegates hash code calculation to handle implementation.</summary>
    /// <returns>Hash code consistent with <see cref="Equals(PtrWrapper{T})"/>.</returns>
    public override int GetHashCode()
        => unchecked((int)ptr.UnsafeValue.ToInt64());

    /// <summary>Delegates comparison to pointer.</summary>
    /// <param name="other">Another pointer to be compared with this one. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if both pointers reference to one and the same object.</returns>
    public bool Equals(PtrWrapper<T>? other)
        => other is not null && other.ptr.UnsafeValue == ptr.UnsafeValue;

    /// <summary>Two objects are equal when they reference to one and the same unmanaged object.</summary>
    /// <param name="obj">Another pointer to be compared with this one. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is <see cref="PtrWrapper{T}"/> and they both reference to one and the same object.</returns>
    public override bool Equals(object? obj)
        => obj is PtrWrapper<T> wrapper && Equals(wrapper);

    /// <summary>To be consistent with <see cref="Equals(PtrWrapper{T})"/>.</summary>
    /// <param name="left">Left part of operator. Can be <see langword="null"/>.</param>
    /// <param name="right">Right part of operator. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> equals to <paramref name="right"/>.</returns>
    /// <seealso cref="Equals(PtrWrapper{T})"/>
    public static bool operator ==(PtrWrapper<T>? left, PtrWrapper<T>? right)
        => (left is null && right is null) || (left is not null && left.Equals(right));

    /// <summary>To be consistent with <see cref="Equals(PtrWrapper{T})"/>.</summary>
    /// <param name="left">Left part of operator. Can be <see langword="null"/>.</param>
    /// <param name="right">Right part of operator. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> is not equal to <paramref name="right"/>.</returns>
    /// <seealso cref="Equals(PtrWrapper{T})"/>
    public static bool operator !=(PtrWrapper<T>? left, PtrWrapper<T>? right)
        => !(left == right);

    #endregion
}