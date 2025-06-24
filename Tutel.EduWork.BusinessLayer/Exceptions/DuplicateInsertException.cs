using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutel.EduWork.BusinessLayer.Exceptions
{
    public class DuplicateInsertException : Exception
    {
        public DuplicateInsertException(string message) : base(message)
        {

        } 
    }
}
