using System;

namespace OrbbDotNet;

// typedef enum {
//     OB_PERMISSION_DENY = 0,
//     OB_PERMISSION_READ = 1,
//     OB_PERMISSION_WRITE = 2,
//     OB_PERMISSION_READ_WRITE = 3,
//      OB_PERMISSION_ANY = 255,
// } OBPermissionType, ob_permission_type;
/// <summary>the permission type of API or property</summary>
[Flags]
public enum PermissionType
{
    /// <summary>no permission</summary>
    Deny = 0,

    /// <summary>can read</summary>
    Read = 1,

    /// <summary>can write</summary>
    Write = 2,

    /// <summary>can read and write</summary>
    ReadWrite = 3,

    /// <summary>any situation about</summary>
    Any = 255,
}
