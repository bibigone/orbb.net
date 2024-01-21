namespace OrbbDotNet;

// typedef enum {
//     STAT_VERIFY_SUCCESS = 5,
//     STAT_FILE_TRANSFER = 4,
//     STAT_DONE = 3,
//     STAT_IN_PROGRESS = 2,
//     STAT_START = 1,
//     STAT_VERIFY_IMAGE = 0,
//     ERR_VERIFY = -1,
//     ERR_PROGRAM = -2,
//     ERR_ERASE = -3,
//     ERR_FLASH_TYPE = -4,
//     ERR_IMAGE_SIZE = -5,
//     ERR_OTHER = -6,
//     ERR_DDR = -7,
//     ERR_TIMEOUT = -8
// } OBUpgradeState, ob_upgrade_state;
/// <summary>Enumeration value describing the firmware upgrade status</summary>
public enum UpgradeState
{
    /// <summary>Image file verify success</summary>
    VerifySuccess = 5,

    /// <summary>file transfer</summary>
    FileTransfer = 4,

    /// <summary>update completed</summary>
    Done = 3,

    /// <summary>upgrade in process</summary>
    InProgress = 2,

    /// <summary>start the upgrade</summary>
    Start = 1,

    /// <summary>Image file verification</summary>
    VerifyImage = 0,

    #region Errors

    /// <summary>Verification failed</summary>
    ErrorVerify = -1,

    /// <summary>Program execution failed</summary>
    ErrorProgram = -2,

    /// <summary>Flash parameter failed</summary>
    ErrorErase = -3,

    /// <summary>Flash type error</summary>
    ErrorFlashType = -4,

    /// <summary>Image file size error</summary>
    ErrorImageSize = -5,

    /// <summary>other errors</summary>
    ErrorOther = -6,

    /// <summary>DDR access error</summary>
    ErrorDdr = -7,

    /// <summary>timeout error</summary>
    ErrorTimeout = -8,

    #endregion
}
