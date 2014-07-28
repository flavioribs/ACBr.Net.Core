using System;
using System.Runtime.Serialization;

namespace ACBr.Net.Core
{
	public class ACBrNFeException : Exception
    {
        public ACBrNFeException(string message)
            : base(message)
        {
        }

        public ACBrNFeException()
        {

        }

        public ACBrNFeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public ACBrNFeException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        protected ACBrNFeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}

