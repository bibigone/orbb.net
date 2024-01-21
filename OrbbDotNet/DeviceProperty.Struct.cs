using System.Runtime.InteropServices;
using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class DeviceProperty
{
    public class Struct : DeviceProperty
    {
        internal Struct(Device device, ObPropertyItem propertyItem)
            : base(device, propertyItem)
        { }

        public void GetValue(IntPtr bufferPtr, ref int dataSizeBytes)
        {
            uint size = (uint)dataSizeBytes;
            Native.DeviceApi.Device.GetStructuredData(device.NativePtr, PropertyId, bufferPtr, ref size, out var error);
            ObException.CheckError(ref error);
            dataSizeBytes = (int)size;
        }

        public unsafe int GetValue<T>(T[] buffer)
            where T : unmanaged
        {
            fixed (void* ptr = buffer)
            {
                var size = buffer.Length * Marshal.SizeOf<T>();
                GetValue(new IntPtr(ptr), ref size);
                return size / Marshal.SizeOf<T>();
            }
        }

#if !(NETSTANDARD2_0 || NET461)

        public unsafe int GetValue<T>(Span<T> buffer)
            where T : unmanaged
        {
            fixed (void* ptr = buffer)
            {
                var size = buffer.Length * Marshal.SizeOf<T>();
                GetValue(new IntPtr(ptr), ref size);
                return size / Marshal.SizeOf<T>();
            }
        }

#endif

        public void SetValue(IntPtr dataPtr, int dataSizeBytes)
        {
            Native.DeviceApi.Device.SetStructuredData(device.NativePtr, PropertyId, dataPtr, (uint)dataSizeBytes, out var error);
            ObException.CheckError(ref error);
        }

        public unsafe void SetValue<T>(T[] data)
            where T : unmanaged
        {
            fixed (void* ptr = data)
            {
                SetValue(new IntPtr(ptr), data.Length * Marshal.SizeOf<T>());
            }
        }

#if !(NETSTANDARD2_0 || NET461)

        public unsafe void SetValue<T>(ReadOnlySpan<T> data)
            where T : unmanaged
        {
            fixed (void* ptr = data)
            {
                SetValue(new IntPtr(ptr), data.Length * Marshal.SizeOf<T>());
            }
        }

#endif

        public override void SetValue<T>(T value)
        {
            var size = Marshal.SizeOf<T>();
            var ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(value, ptr, fDeleteOld: false);
                SetValue(ptr, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public override T GetValue<T>()
        {
            var size = Marshal.SizeOf<T>();
            var ptr = Marshal.AllocHGlobal(size);
            try
            {
                var s = size;
                GetValue(ptr, ref s);
                if (s != size)
                    throw new InvalidOperationException($"Invalid data size: expected {size} bytes, but received {s} bytes");
                return Marshal.PtrToStructure<T>(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public override PropertyRange<T> GetPropertyRange<T>()
            => throw new NotSupportedException("Property range is not available for struct properties.");
    }
}
