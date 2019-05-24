using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Python.Included;
using Numpy.Models;

namespace Numpy
{
    public partial class NumPy
    {
        
        /// <summary>
        /// Packs the elements of a binary-valued array into bits in a uint8 array.
        /// 
        /// The result is padded to full bytes by inserting zero bits at the end.
        /// </summary>
        /// <param name="myarray">
        /// An array of integers or booleans whose elements should be packed to
        /// bits.
        /// </param>
        /// <param name="axis">
        /// The dimension over which bit-packing is done.
        /// None implies packing the flattened array.
        /// </param>
        /// <returns>
        /// Array of type uint8 whose elements represent bits corresponding to the
        /// logical (0 or nonzero) value of the input elements. The shape of
        /// packed has the same number of dimensions as the input (unless axis
        /// is None, in which case the output is 1-D).
        /// </returns>
        public NDarray packbits(NDarray myarray, int? axis = null)
        {
            //auto-generated code, do not change
            var pyargs=ToTuple(new object[]
            {
                myarray,
            });
            var kwargs=new PyDict();
            if (axis!=null) kwargs["axis"]=ToPython(axis);
            dynamic py = self.InvokeMethod("packbits", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }
        
        /// <summary>
        /// Packs the elements of a binary-valued array into bits in a uint8 array.
        /// 
        /// The result is padded to full bytes by inserting zero bits at the end.
        /// </summary>
        /// <param name="myarray">
        /// An array of integers or booleans whose elements should be packed to
        /// bits.
        /// </param>
        /// <param name="axis">
        /// The dimension over which bit-packing is done.
        /// None implies packing the flattened array.
        /// </param>
        /// <returns>
        /// Array of type uint8 whose elements represent bits corresponding to the
        /// logical (0 or nonzero) value of the input elements. The shape of
        /// packed has the same number of dimensions as the input (unless axis
        /// is None, in which case the output is 1-D).
        /// </returns>
        public NDarray<T> packbits<T>(T[] myarray, int? axis = null)
        {
            //auto-generated code, do not change
            var pyargs=ToTuple(new object[]
            {
                SharpToSharp<NDarray>(myarray),
            });
            var kwargs=new PyDict();
            if (axis!=null) kwargs["axis"]=ToPython(axis);
            dynamic py = self.InvokeMethod("packbits", pyargs, kwargs);
            return ToCsharp<NDarray<T>>(py);
        }
        
        /// <summary>
        /// Packs the elements of a binary-valued array into bits in a uint8 array.
        /// 
        /// The result is padded to full bytes by inserting zero bits at the end.
        /// </summary>
        /// <param name="myarray">
        /// An array of integers or booleans whose elements should be packed to
        /// bits.
        /// </param>
        /// <param name="axis">
        /// The dimension over which bit-packing is done.
        /// None implies packing the flattened array.
        /// </param>
        /// <returns>
        /// Array of type uint8 whose elements represent bits corresponding to the
        /// logical (0 or nonzero) value of the input elements. The shape of
        /// packed has the same number of dimensions as the input (unless axis
        /// is None, in which case the output is 1-D).
        /// </returns>
        public NDarray<T> packbits<T>(T[,] myarray, int? axis = null)
        {
            //auto-generated code, do not change
            var pyargs=ToTuple(new object[]
            {
                SharpToSharp<NDarray>(myarray),
            });
            var kwargs=new PyDict();
            if (axis!=null) kwargs["axis"]=ToPython(axis);
            dynamic py = self.InvokeMethod("packbits", pyargs, kwargs);
            return ToCsharp<NDarray<T>>(py);
        }
        
        /// <summary>
        /// Unpacks elements of a uint8 array into a binary-valued output array.
        /// 
        /// Each element of myarray represents a bit-field that should be unpacked
        /// into a binary-valued output array. The shape of the output array is either
        /// 1-D (if axis is None) or the same shape as the input array with unpacking
        /// done along the axis specified.
        /// </summary>
        /// <param name="myarray">
        /// Input array.
        /// </param>
        /// <param name="axis">
        /// The dimension over which bit-unpacking is done.
        /// None implies unpacking the flattened array.
        /// </param>
        /// <returns>
        /// The elements are binary-valued (0 or 1).
        /// </returns>
        public NDarray unpackbits(NDarray myarray, int? axis = null)
        {
            //auto-generated code, do not change
            var pyargs=ToTuple(new object[]
            {
                myarray,
            });
            var kwargs=new PyDict();
            if (axis!=null) kwargs["axis"]=ToPython(axis);
            dynamic py = self.InvokeMethod("unpackbits", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }
        
        /// <summary>
        /// Return the binary representation of the input number as a string.
        /// 
        /// For negative numbers, if width is not given, a minus sign is added to the
        /// front. If width is given, the two’s complement of the number is
        /// returned, with respect to that width.
        /// 
        /// In a two’s-complement system negative numbers are represented by the two’s
        /// complement of the absolute value. This is the most common method of
        /// representing signed integers on computers [1]. A N-bit two’s-complement
        /// system can represent every integer in the range
        ///  to .
        /// 
        /// Notes
        /// 
        /// binary_repr is equivalent to using base_repr with base 2, but about 25x
        /// faster.
        /// 
        /// References
        /// </summary>
        /// <param name="num">
        /// Only an integer decimal number can be used.
        /// </param>
        /// <param name="width">
        /// The length of the returned string if num is positive, or the length
        /// of the two’s complement if num is negative, provided that width is
        /// at least a sufficient number of bits for num to be represented in the
        /// designated form.
        /// 
        /// If the width value is insufficient, it will be ignored, and num will
        /// be returned in binary (num &gt; 0) or two’s complement (num &lt; 0) form
        /// with its width equal to the minimum number of bits needed to represent
        /// the number in the designated form. This behavior is deprecated and will
        /// later raise an error.
        /// </param>
        /// <returns>
        /// Binary representation of num or two’s complement of num.
        /// </returns>
        public string binary_repr(int num, int? width = null)
        {
            //auto-generated code, do not change
            var pyargs=ToTuple(new object[]
            {
                num,
            });
            var kwargs=new PyDict();
            if (width!=null) kwargs["width"]=ToPython(width);
            dynamic py = self.InvokeMethod("binary_repr", pyargs, kwargs);
            return ToCsharp<string>(py);
        }
        
    }
}
