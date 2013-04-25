using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class OperationsTest
    {
        delegate T OperationDelegateGeneric<T>(T[] arr);

        delegate byte OperationDelegate(byte[] arr);

        delegate int OperationDelegateInt(int[] arr);

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

        private static float NextFloat(Random randomGenerator)
        {
            double mantissa = (randomGenerator.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, randomGenerator.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        private static long NextLong(Random randomGenerator) {

            long value = (long)((randomGenerator.NextDouble() * 2.0 - 1.0) * long.MaxValue);
            return value;
        }

        public static decimal NextDecimal(Random randomGenerator)
        {
            //a fairly random decimal number :D
            if (randomGenerator.Next(2) %2 == 0)
            {
                return 1.000000008m;    
            }
            else
            {
                return -1.0000000008m;
            }
        }

        public static void Main()
        {
            byte[] randomBytes = new byte[10000000];
            int[] randomInts = new int[10000000];
            long[] randomLongs = new long[10000000];
            float[] randomFloats = new float[10000000];
            double[] randomDoubles = new double[10000000];
            decimal[] randomDecimals = new decimal[10000000];

            Random randomGenerator = new Random();
            for (int i = 0; i < randomBytes.Length; i++)
            {
                randomBytes[i] = (byte)randomGenerator.Next(1, 255);
                randomInts[i] = randomGenerator.Next(1, int.MaxValue);
                randomLongs[i] = NextLong(randomGenerator);
                randomFloats[i] = NextFloat(randomGenerator);
                randomDecimals[i] = NextDecimal(randomGenerator);

            }

            //List<Type> typesToCheck = new List<Type> { typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) };

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
                DateTime startTime = DateTime.Now;
                var resultInt = operation(randomInts);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine(operation.Method.Name + " for int takes: " 
                    + elapsed.TotalSeconds.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in longOperations)
            {
                DateTime startTime = DateTime.Now;
                var resultLong = operation(randomLongs);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine(operation.Method.Name + " for long takes: " 
                    + elapsed.TotalSeconds.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in floatOperations)
            {
                DateTime startTime = DateTime.Now;
                var resultLong = operation(randomFloats);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine(operation.Method.Name + " for float takes: " 
                    + elapsed.TotalSeconds.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in doubleOperations)
            {
                DateTime startTime = DateTime.Now;
                var resultLong = operation(randomDoubles);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine(operation.Method.Name + " for double takes: " 
                    + elapsed.TotalSeconds.ToString("00.0000") + " secs");
            }

            Console.WriteLine(new string('*', 50));

            foreach (var operation in decimalOperations)
            {
                DateTime startTime = DateTime.Now;
                var resultLong = operation(randomDecimals);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine(operation.Method.Name + " for decimal takes: "
                    + elapsed.TotalSeconds.ToString("00.0000") + " secs");
            }
        }

    }
}

