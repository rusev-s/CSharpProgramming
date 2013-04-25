using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class IntegerOperations : IOperations<int>
    {
        public int Add(int a, int b) { return a + b; }
        public int Subtract(int a, int b) { return a - b; }
        public int Multiply(int a, int b) { return a * b; }
        public int Divide(int a, int b) { return a / b; }
    }
}
