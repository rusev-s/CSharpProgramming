﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ComparePerformanceOperationsForDifferentTypes
{
    public class GenericOperations<T> : IOperations<T>
    {
        private Func<T, T, T> add, subtract, multiply, divide;

        public GenericOperations()
        {
            add = CreateLambda(Expression.Add);
            subtract = CreateLambda(Expression.Subtract);
            multiply = CreateLambda(Expression.Multiply);
            divide = CreateLambda(Expression.Divide);
        }
        
        public T Add(T a, T b) { return add(a, b); }
        public T Subtract(T a, T b) { return subtract(a, b); }
        public T Multiply(T a, T b) { return multiply(a, b); }
        public T Divide(T a, T b) { return divide(a, b); }

        private static Func<T, T, T> CreateLambda(Func<Expression, Expression, Expression> op)
        {
            var a = Expression.Parameter(typeof(T), "a");
            var b = Expression.Parameter(typeof(T), "b");
            var body = op(a, b);
            var expr = Expression.Lambda<Func<T, T, T>>(body, a, b);
            return expr.Compile();
        }

    }
}
