﻿using System;

namespace OffensiveCS.Flags
{
    [Flags]
    enum MessageBoxResponseType
    {
        Abort = 3,
        Cancel = 2,
        Continue = 11,
        Ignore = 5,
        No = 7,
        Ok = 1,
        Retry = 4,
        TryAgain = 10,
        Yes = 6
    }
}
