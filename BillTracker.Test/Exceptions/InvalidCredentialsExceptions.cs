﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BillTracker.Test.Exceptions
{
    class InvalidCredentialsExceptions :Exception
    {
        public string Messages ;

        public InvalidCredentialsExceptions()
        {
            Messages = "Please enter valid usename & password";
        }
        public InvalidCredentialsExceptions(string message)
        {
            Messages = message;
        }
    }
}
