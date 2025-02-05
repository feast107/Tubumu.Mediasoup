﻿using System;
using System.Text;
using System.Threading.Tasks;

namespace Tubumu.Libuv.Threading.Tasks
{
    internal static class IPCPipeExtensions
    {
        public static Task WriteAsync(this IPCPipe pipe, Handle handle, ArraySegment<byte> data)
        {
            return HelperFunctions.Wrap(handle, data, pipe.Write);
        }

        public static Task WriteAsync(this IPCPipe pipe, Handle handle, byte[] data, int offset, int count)
        {
            return HelperFunctions.Wrap(handle, data, offset, count, pipe.Write);
        }

        public static Task WriteAsync(this IPCPipe pipe, Handle handle, byte[] data, int offset)
        {
            return HelperFunctions.Wrap(handle, data, offset, pipe.Write);
        }

        //public static Task WriteAsync(this IPCPipe pipe, Handle handle, byte[] data)
        //{
        //    return HelperFunctions.Wrap(handle, data, pipe.Write);
        //}

        #region Write string

        public static Task<int> WriteAsync(this IPCPipe pipe, Handle handle, Encoding encoding, string text)
        {
            return HelperFunctions.Wrap(handle, encoding, text, pipe.Write);
        }

        public static Task<int> WriteAsync(this IPCPipe pipe, Handle handle, string text)
        {
            return HelperFunctions.Wrap(handle, text, pipe.Write);
        }

        #endregion Write string
    }
}
