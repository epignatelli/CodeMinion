﻿using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet
{
    public class Shape : Base
    {
        public Shape(PyObject py)
        {
            __self__ = py;
        }

        public int[] Dimensions { get; }

        public Shape(params int[] shape)
        {
            this.Dimensions = shape;
        }

        public int this[int n] => Dimensions[n];

        #region Equality

        public static bool operator ==(Shape a, Shape b)
        {
            if (b is null) return false;
            return Enumerable.SequenceEqual(a.Dimensions, b?.Dimensions);
        }

        public static bool operator !=(Shape a, Shape b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Shape))
                return false;
            return Enumerable.SequenceEqual(Dimensions, ((Shape)obj).Dimensions);
        }

        public override int GetHashCode()
        {
            return (Dimensions ?? new int[0]).GetHashCode();
        }

        public override string ToString()
        {
            return $"({string.Join(", ", Dimensions ?? new int[0])})";
        }

        #endregion
    }
}
