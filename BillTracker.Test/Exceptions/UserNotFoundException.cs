﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BillTracker.Test.Exceptions
{
    class UserNotFoundException :Exception
    {
        public string Messages;

        public UserNotFoundException()
        {
            Messages = "User Not Found Exception";
        }
        public UserNotFoundException(string message)
        {
            Messages = message;
        }
    }
}
