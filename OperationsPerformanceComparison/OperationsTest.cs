﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class OperationsTest
    {
        delegate T OperationDelegateGeneric<T>(T[] arr);

        public static T Add<T>(IList<T> numbers)
        {
            var operations = Operations<T>.Default;
            var result = numbers.Aggregate(operations.Add);

            return result;
        }

        public static T Subtract<T>(IList<T> numbers)
        {
            var operations = Operations<T>.Default;
            var result = numbers.Aggregate(operations.Subtract);

            return result;
        }

        public static T Multiply<T>(IList<T> numbers)
        {
            var operations = Operations<T>.Default;
            var result = numbers.Aggregate(operations.Multiply);

            return result;
        }

        public static T Divide<T>(IList<T> numbers)
        {
            var operations = Operations<T>.Default;
            var result = numbers.Aggregate(operations.Divide);

            return result;
        }

        public static void Main()
        {
            OperationDelegateGeneric<int>[] intOperations = new OperationDelegateGeneric<int>[4];
            intOperations[0] = new OperationDelegateGeneric<int>(Add<int>);
            intOperations[1] = new OperationDelegateGeneric<int>(Subtract<int>);
            intOperations[2] = new OperationDelegateGeneric<int>(Multiply<int>);
            intOperations[3] = new OperationDelegateGeneric<int>(Divide<int>);

            OperationDelegateGeneric<long>[] longOperations = new OperationDelegateGeneric<long>[4];
            longOperations[0] = new OperationDelegateGeneric<long>(Add<long>);
            longOperations[1] = new OperationDelegateGeneric<long>(Subtract<long>);
            longOperations[2] = new OperationDelegateGeneric<long>(Multiply<long>);
            longOperations[3] = new OperationDelegateGeneric<long>(Divide<long>);

            OperationDelegateGeneric<float>[] floatOperations = new OperationDelegateGeneric<float>[4];
            floatOperations[0] = new OperationDelegateGeneric<float>(Add<float>);
            floatOperations[1] = new OperationDelegateGeneric<float>(Subtract<float>);
            floatOperations[2] = new OperationDelegateGeneric<float>(Multiply<float>);
            floatOperations[3] = new OperationDelegateGeneric<float>(Divide<float>);

            OperationDelegateGeneric<double>[] doubleOperations = new OperationDelegateGeneric<double>[4];
            doubleOperations[0] = new OperationDelegateGeneric<double>(Add<double>);
            doubleOperations[1] = new OperationDelegateGeneric<double>(Subtract<double>);
            doubleOperations[2] = new OperationDelegateGeneric<double>(Multiply<double>);
            doubleOperations[3] = new OperationDelegateGeneric<double>(Divide<double>);

            OperationDelegateGeneric<decimal>[] decimalOperations = new OperationDelegateGeneric<decimal>[4];
            decimalOperations[0] = new OperationDelegateGeneric<decimal>(Add<decimal>);
            decimalOperations[1] = new OperationDelegateGeneric<decimal>(Subtract<decimal>);
            decimalOperations[2] = new OperationDelegateGeneric<decimal>(Multiply<decimal>);
            decimalOperations[3] = new OperationDelegateGeneric<decimal>(Divide<decimal>);

            foreach (var operation in intOperations)
            {
                Stopwatch stopWatch = new Stopwatch();

                int[] arr = { int.MaxValue, int.MinValue };
                double elapsed = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    stopWatch.Start();
                    var resultInt = operation(arr);
                    stopWatch.Stop();
                    elapsed += stopWatch.Elapsed.TotalSeconds;
                }
                double averageElapsed = elapsed / 1000000;
                Console.WriteLine(operation.Method.Name + " for int takes: "
                    + averageElapsed.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in longOperations)
            {
                Stopwatch stopWatch = new Stopwatch();

                long[] arr = { long.MinValue, long.MaxValue };
                double elapsed = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    stopWatch.Start();
                    var resultLong = operation(arr);
                    stopWatch.Stop();
                    elapsed += stopWatch.Elapsed.TotalSeconds;
                }
                double averageElapsed = elapsed / 1000000;
                Console.WriteLine(operation.Method.Name + " for long takes: "
                    + averageElapsed.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in floatOperations)
            {
                Stopwatch stopWatch = new Stopwatch();

                float[] arr = { float.MinValue, float.MaxValue };
                double elapsed = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    stopWatch.Start();
                    var resultLong = operation(arr);
                    stopWatch.Stop();
                    elapsed += stopWatch.Elapsed.TotalSeconds;
                }
                double averageElapsed = elapsed / 1000000;
                Console.WriteLine(operation.Method.Name + " for float takes: "
                    + averageElapsed.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in doubleOperations)
            {
                Stopwatch stopWatch = new Stopwatch();

                double[] arr = { double.MinValue, double.MaxValue };
                double elapsed = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    stopWatch.Start();
                    var resultLong = operation(arr);
                    stopWatch.Stop();
                    elapsed += stopWatch.Elapsed.TotalSeconds;
                }
                double averageElapsed = elapsed / 1000000;
                Console.WriteLine(operation.Method.Name + " for double takes: "
                    + averageElapsed.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in decimalOperations)
            {
                Stopwatch stopWatch = new Stopwatch();

                decimal[] arr = { 1 , decimal.MaxValue / 200};
                double elapsed = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    stopWatch.Start();
                    var resultLong = operation(arr);
                    stopWatch.Stop();
                    elapsed += stopWatch.Elapsed.TotalSeconds;
                }
                double averageElapsed = elapsed / 1000000;
                Console.WriteLine(operation.Method.Name + " for decimal takes: "
                    + averageElapsed.ToString("00.0000") + " secs");
            }
        }

    }
}

