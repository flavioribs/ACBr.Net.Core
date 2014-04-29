using System;
using System.Runtime.Serialization;

namespace ACBr.Net.Core
{
    public class ACBrTEFDException : Exception
    {
        public ACBrTEFDException(string message)
            : base(message)
        {
        }

        public ACBrTEFDException()
        {

        }

        public ACBrTEFDException(Exception ex):base(ex.Message)
        {

        }

        public ACBrTEFDException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ACBrTEFDException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
