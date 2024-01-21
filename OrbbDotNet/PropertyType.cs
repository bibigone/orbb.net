namespace OrbbDotNet;

// typedef enum OBPropertyType
// {
//     OB_BOOL_PROPERTY = 0,
//     OB_INT_PROPERTY = 1,
//     OB_FLOAT_PROPERTY = 2,
//     OB_STRUCT_PROPERTY = 3,
// } OBPropertyType, ob_property_type;
/// <summary>The data type used to describe all property settings</summary>
public enum PropertyType
{
    /// <summary>Boolean property</summary>
    Bool = 0,

    /// <summary>Integer property</summary>
    Int = 1,

    /// <summary>Floating-point property</summary>
    Float = 2,

    /// <summary>Struct property</summary>
    Struct = 3,
}
