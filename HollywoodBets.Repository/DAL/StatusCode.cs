using System;
using System.Collections.Generic;
using System.Text;

namespace HollywoodBets.Repository.DAL
{
    public static class StatusCodes
    {
        public static object ReturnStatusObject(string message)
        {
            string parm1 = "\"status\" : ";
            string parm2 = $"\"${message}\"";
            return "{" + parm1 + parm2 + "}";
        }
    }
}
