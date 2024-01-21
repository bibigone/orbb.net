using System;
using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     uint8_t* data;
//     uint32_t size;
//     uint32_t offset;
//     uint32_t fullDataSize;
// } OBDataChunk, ob_data_chunk;
/// <summary>Structure for transmitting data blocks</summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct DataChunk
{
    /// <summary>Pointer to current block data</summary>
    public readonly IntPtr DataPtr;

    /// <summary>Length of current block data</summary>
    public readonly int DataSizeBytes;

    /// <summary>Offset of current data block relative to complete data</summary>
    public readonly int Offset;

    /// <summary>Size of full data</summary>
    public readonly int FullDataSizeBytes;
}
