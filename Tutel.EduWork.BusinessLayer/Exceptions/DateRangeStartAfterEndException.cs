using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutel.EduWork.BusinessLayer.Exceptions
{
    public class DateRangeStartAfterEndException : Exception
    {
        public DateRangeStartAfterEndException(string message) : base(message)
        {

        } 
    }
}
