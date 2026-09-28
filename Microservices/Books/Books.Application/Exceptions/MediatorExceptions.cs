using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.Exceptions
{
    public class MediatorExceptions : Exception
    {
        public MediatorExceptions(string message): base(message)
        {
            
        }
    }
}
