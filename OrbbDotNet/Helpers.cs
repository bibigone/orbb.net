using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

internal static class Helpers
{
    public delegate TValue ValueGetter<TNativePtr, TValue>(TNativePtr ptr, out ObErrorPtr error)
        where TNativePtr : struct, Native.INativePtr;

    public static TValue GetValue<TNativePtr, TValue>(ValueGetter<TNativePtr, TValue> getter, Native.PtrWrapper<TNativePtr> ptr)
        where TNativePtr : struct, Native.INativePtr
    {
        var res = getter(ptr.ValueNotDisposed, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    public static string? GetStringValue<TNativePtr>(ValueGetter<TNativePtr, IntPtr> getter, Native.PtrWrapper<TNativePtr> ptr)
        where TNativePtr : struct, Native.INativePtr
    {
        var res = GetValue(getter, ptr);
        return Marshal.PtrToStringAnsi(res);
    }
}
