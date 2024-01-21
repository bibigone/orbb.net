using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace OrbbDotNet;

internal static class IntPtrToObjectMap<T> where T : class
{
    private static readonly ConcurrentDictionary<IntPtr, WeakReference<T>> map = new();

    public static IntPtr Register(T obj)
    {
        var hash = obj.GetHashCode();
        var id = hash;
        do
        {
            var intPtrId = new IntPtr(id);
            if (map.TryAdd(intPtrId, new(obj)))
                return intPtrId;
            unchecked { id++; }
        }
        while (id != hash);
        throw new InvalidOperationException("Map is full");
    }

    public static bool Unregister(IntPtr id)
        => map.TryRemove(id, out _);

    public static bool TryGet(IntPtr id, [NotNullWhen(returnValue: true)] out T? result)
    {
        if (map.TryGetValue(id, out var weakRef))
            return weakRef.TryGetTarget(out result);
        result = default;
        return false;
    }
}
