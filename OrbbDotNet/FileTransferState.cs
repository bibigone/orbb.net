namespace OrbbDotNet;

// typedef enum {
//     FILE_TRAN_STAT_TRANSFER = 2,
//     FILE_TRAN_STAT_DONE = 1,
//     FILE_TRAN_STAT_PREPAR = 0,
//     FILE_TRAN_ERR_DDR = -1,
//     FILE_TRAN_ERR_NOT_ENOUGH_SPACE = -2,
//     FILE_TRAN_ERR_PATH_NOT_WRITABLE = -3,
//     FILE_TRAN_ERR_MD5_ERROR = -4,
//     FILE_TRAN_ERR_WRITE_FLASH_ERROR = -5,
//     FILE_TRAN_ERR_TIMEOUT = -6
// } OBFileTranState, ob_file_tran_state;
/// <summary>Enumeration value describing the file transfer status</summary>
public enum FileTransferState : int
{
    /// <summary>File transfer</summary>
    Transferring = 2,

    /// <summary>File transfer succeeded</summary>
    Done = 1,

    /// <summary>Preparing</summary>
    Preparing = 0,

    #region Errors

    /// <summary>DDR access failed</summary>
    DdrAccessFailed = -1,

    /// <summary>Insufficient target space error</summary>
    NotEnoughSpace = -2,

    /// <summary>Destination path is not writable</summary>
    PathNotWritable = -3,

    /// <summary>MD5 checksum error</summary>
    MD5ChecksumError = -4,

    /// <summary>Write flash error</summary>
    WriteFlashError = -5,

    /// <summary>Timeout error</summary>
    Timeout = -6,

    #endregion
}
