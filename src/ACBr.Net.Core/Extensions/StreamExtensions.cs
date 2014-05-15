// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 05-13-2014
//
// Last Modified By : RFTD
// Last Modified On : 05-13-2014
// ***********************************************************************
// <copyright file="StreamExtensions.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// The Core namespace.
/// </summary>
namespace ACBr.Net.Core
{
    /// <summary>
    /// Class StreamExtensions.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        public static void CopyTo(this Stream input, Stream destination, int bufferSize = 1048576)
        {
            var buffer = new byte[bufferSize];
            int read = 0;
            do
            {
                read = input.Read(buffer, 0, bufferSize);
                destination.Write(buffer, 0, read);
            } while (read > 0);
        }

        /// <summary>
        /// Ares the equal.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if stream are equals, <c>false</c> otherwise.</returns>
        public static bool AreEqual(this Stream input, Stream other)
        {
            int buffer = sizeof(Int64);

            if (input.Length != other.Length)
                return false;

            int iterations = (int)Math.Ceiling((double)input.Length / buffer);

            byte[] one = new byte[buffer];
            byte[] two = new byte[buffer];

            input.Position = 0;
            other.Position = 0;

            for (int i = 0; i < iterations; i++)
            {
                input.Read(one, 0, buffer);
                other.Read(two, 0, buffer);

                if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                {
                    input.Position = 0;
                    other.Position = 0;
                    return false;
                }
            }

            input.Position = 0;
            other.Position = 0;
            return true;
        }
    }
}
