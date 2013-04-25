using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class ByteOperations : IOperations<byte>
    {
        public byte Add(byte a, byte b) { return ((byte)(a + b)); }
        public byte Subtract(byte a, byte b) { return ((byte)(a - b)); }
        public byte Multiply(byte a, byte b) { return ((byte)(a * b)); }
        public byte Divide(byte a, byte b) { return ((byte)(a / b)); }
    }
}
