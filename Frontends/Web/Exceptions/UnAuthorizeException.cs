using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Exceptions
{
    public class UnAuthorizeException:Exception
    {
        public UnAuthorizeException() : base()
        {

        }

        public UnAuthorizeException(string message) : base(message)
        {

        }

        public UnAuthorizeException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
