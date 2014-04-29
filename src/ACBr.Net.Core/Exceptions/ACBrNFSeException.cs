using System;
using System.Runtime.Serialization;

namespace ACBr.Net.Core
{
    public class ACBrNFSeException : Exception
    {
        public ACBrNFSeException(string message)
            : base(message)
        {
        }

        public ACBrNFSeException()
        {

        }

        public ACBrNFSeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ACBrNFSeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}