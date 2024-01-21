using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OrbbDotNet.Native;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct NativeBool : IEquatable<NativeBool>, IEquatable<bool>
{
    private const byte RAW_TRUE = 1;
    private const byte RAW_FALSE = 0;

    public static readonly NativeBool False = new(false);
    public static readonly NativeBool True = new(true);

    private readonly byte rawValue;

    public NativeBool(bool value)
        => rawValue = value ? RAW_TRUE : RAW_FALSE;

    public bool Value => rawValue != RAW_FALSE;

    public bool Equals(NativeBool other)
        => Value == other.Value;

    public bool Equals(bool other)
        => Value == other;

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is not null && (obj is NativeBool nb && nb.Value == Value || obj is bool b && b == Value);

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public static bool operator ==(NativeBool left, NativeBool right)
        => left.Equals(right);

    public static bool operator !=(NativeBool left, NativeBool right)
        => !left.Equals(right);

    public static bool operator ==(NativeBool left, bool right)
        => left.Equals(right);

    public static bool operator !=(NativeBool left, bool right)
        => !left.Equals(right);

    public static NativeBool operator !(NativeBool nb)
        => new(!nb.Value);

    public static implicit operator bool (NativeBool nb)
        => nb.Value;

    public static implicit operator NativeBool (bool b)
        => new(b);
}
