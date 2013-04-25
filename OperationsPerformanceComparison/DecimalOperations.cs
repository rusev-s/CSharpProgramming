using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class DecimalOperations : IOperations<decimal>
    {
        public decimal Add(decimal a, decimal b) { return a + b; }
        public decimal Subtract(decimal a, decimal b) { return a - b; }
        public decimal Multiply(decimal a, decimal b) { return a * b; }
        public decimal Divide(decimal a, decimal b) { return a / b; }
    }
}
