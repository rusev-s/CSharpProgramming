using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class LongOperations : IOperations<long>
    {
        public long Add(long a, long b) { return a + b; }
        public long Subtract(long a, long b) { return a - b; }
        public long Multiply(long a, long b) { return a * b; }
        public long Divide(long a, long b) { return a / b; }
    }
}
