using System;
using System.Runtime.InteropServices;

namespace OrbbDotNet;

/// <summary>Placeholder for 3D vector of floats.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Float3 : IEquatable<Float3>, IFormattable
{
    #region Fields

    /// <summary>X-direction component</summary>
    public float X;

    /// <summary>Y-direction component</summary>
    public float Y;

    /// <summary>Z-direction component</summary>
    public float Z;

    #endregion

    /// <summary>Creates 3D vector initialized by specified values.</summary>
    /// <param name="x">Value for <see cref="X"/> component.</param>
    /// <param name="y">Value for <see cref="Y"/> component.</param>
    /// <param name="z">Value for <see cref="Z"/> component.</param>
    public Float3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>Creates vector from an array representation.</summary>
    /// <param name="values">Array representation of vector. Not <see langword="null"/>. 3 elements.</param>
    public Float3(float[] values)
    {
        if (values is null)
            throw new ArgumentNullException(nameof(values));
        if (values.Length != 3)
            throw new ArgumentOutOfRangeException(nameof(values) + "." + nameof(values.Length));
        X = values[0];
        Y = values[1];
        Z = values[2];
    }

    /// <summary>Converts vector structure to array representation.</summary>
    /// <returns>Array representation of vector. Not <see langword="null"/>.</returns>
    public float[] ToArray()
        => new[] { X, Y, Z };

    /// <summary>Indexed access to vector components.</summary>
    /// <param name="index">Zero-based index of vector component.</param>
    /// <returns>Vector component.</returns>
    /// <exception cref="IndexOutOfRangeException"><paramref name="index"/> has invalid value.</exception>
    public float this[int index]
    {
        get => index switch
        {
            0 => X,
            1 => Y,
            2 => Z,
            _ => throw new IndexOutOfRangeException(),
        };

        set
        {
            switch (index)
            {
                case 0: X = value; break;
                case 1: Y = value; break;
                case 2: Z = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }

    /// <summary>Per-component comparison.</summary>
    /// <param name="other">Another vector to be compared with this one.</param>
    /// <returns><see langword="true"/> if all component of <paramref name="other"/> are equal to appropriate elements of this vector.</returns>
    public bool Equals(Float3 other)
        => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

    /// <summary>Overloads <see cref="Object.Equals(object)"/> to be consistent with <see cref="Equals(Float3)"/>.</summary>
    /// <param name="obj">Object to be compared with this vector.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="Float3x3"/> and is equal to this one.</returns>
    /// <seealso cref="Equals(Float3x3)"/>
    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Float3 float3)
            return false;
        return Equals(float3);
    }

    /// <summary>To be consistent with <see cref="Equals(Float3)"/>.</summary>
    /// <param name="left">Left part of operator.</param>
    /// <param name="right">Right part of operator.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> equals to <paramref name="right"/>.</returns>
    /// <seealso cref="Equals(Float3)"/>
    public static bool operator ==(Float3 left, Float3 right)
        => left.Equals(right);

    /// <summary>To be consistent with <see cref="Equals(Float3)"/>.</summary>
    /// <param name="left">Left part of operator.</param>
    /// <param name="right">Right part of operator.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> is not equal to <paramref name="right"/>.</returns>
    /// <seealso cref="Equals(Float3)"/>
    public static bool operator !=(Float3 left, Float3 right)
        => !left.Equals(right);

    /// <summary>Calculates hash code.</summary>
    /// <returns>Hash code. Consistent with overridden equality.</returns>
    public override int GetHashCode()
        => HashCode.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());

    /// <summary>Formats vector in convenient manner.</summary>
    /// <param name="format">Format string for each individual component in string representation.</param>
    /// <param name="formatProvider">Culture for formatting numbers to strings.</param>
    /// <returns>String representation of vector in a given Culture.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider)
        => $"[X:{X.ToString(format, formatProvider)} Y:{Y.ToString(format, formatProvider)} Z:{Z.ToString(format, formatProvider)}]";

    /// <summary>Formats vector in convenient manner.</summary>
    /// <returns>String representation of vector .</returns>
    public override string ToString()
        => $"[X:{X} Y:{Y} Z:{Z}]";

    /// <summary>Zero vector (all elements are 0).</summary>
    public static readonly Float3 Zero = new();

    /// <summary>Unit vector in +X direction.</summary>
    public static readonly Float3 UnitX = new(1f, 0f, 0f);

    /// <summary>Unit vector in +Y direction.</summary>
    public static readonly Float3 UnitY = new(0f, 1f, 0f);

    /// <summary>Unit vector in +Z direction.</summary>
    public static readonly Float3 UnitZ = new(0f, 0f, 1f);
}
