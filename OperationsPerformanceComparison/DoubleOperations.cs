using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class DoubleOperations : IOperations<double>
    {
        public double Add(double a, double b) { return a + b; }
        public double Subtract(double a, double b) { return a - b; }
        public double Multiply(double a, double b) { return a * b; }
        public double Divide(double a, double b) { return a / b; }
    }
}
