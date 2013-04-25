using System;
using System.Collections.Generic;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public static class Operations<T>
    {
        public static IOperations<T> Default { get { return Create(); } }

        //int, long, float, double, decimal
        static IOperations<T> Create()
        {
            var type = typeof(T);
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                    return (IOperations<T>)new ByteOperations();
                case TypeCode.Single:
                    return (IOperations<T>)new SingleOperations();
                case TypeCode.Double:
                    return (IOperations<T>)new DoubleOperations();
                case TypeCode.Int32:
                    return (IOperations<T>)new IntegerOperations();
                case TypeCode.Int64:
                    return (IOperations<T>)new LongOperations();
                case TypeCode.Decimal:
                    return (IOperations<T>)new DecimalOperations();
                default:
                    var message = String.Format("Operations for type {0} is not supported.", type.Name);
                    throw new NotSupportedException(message);
            }
        }
    }
}
