namespace OrbbDotNet;

// typedef enum {
//     DATA_TRAN_STAT_VERIFY_DONE = 4,
//     DATA_TRAN_STAT_STOPPED = 3,
//     DATA_TRAN_STAT_DONE = 2,
//     DATA_TRAN_STAT_VERIFYING = 1,
//     DATA_TRAN_STAT_TRANSFERRING = 0,
//     DATA_TRAN_ERR_BUSY = -1,
//     DATA_TRAN_ERR_UNSUPPORTED = -2,
//     DATA_TRAN_ERR_TRAN_FAILED = -3,
//     DATA_TRAN_ERR_VERIFY_FAILED = -4,
//     DATA_TRAN_ERR_OTHER = -5
// } OBDataTranState, ob_data_tran_state;
/// <summary>Enumeration value describing the data transfer status</summary>
public enum DataTransferState : int
{
    /// <summary>data verify done</summary>
    VerifyDone = 4,

    /// <summary>data transfer stopped</summary>
    Stopped = 3,

    /// <summary>data transfer completed</summary>
    Done = 2,

    /// <summary>data verifying</summary>
    Verifying = 1,

    /// <summary>data transferring</summary>
    Transferring = 0,

    #region Errors

    /// <summary>transmission is busy</summary>
    Busy = -1,

    /// <summary>not supported (error)</summary>
    Unsupported = -2,

    /// <summary>transfer failed (error)</summary>
    TransferFailed = -3,

    /// <summary>test failed (error)</summary>
    VerifyFailed = -4,

    /// <summary>other errors</summary>
    ErrorOther = -5,

    #endregion
}
