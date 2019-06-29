// Copyright (c) 2019 by the SciSharp Team
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Numpy.Models;
using Python.Included;

namespace Numpy
{
    public static partial class np
    {
        
        /// <summary>
        ///	Returns True if cast between data types can occur according to the
        ///	casting rule.<br></br>
        ///	  If from is a scalar or array scalar, also returns
        ///	True if the scalar value can be cast without overflow or truncation
        ///	to an integer.<br></br>
        ///	
        ///	
        ///	Notes
        ///	
        ///	Starting in NumPy 1.9, can_cast function now returns False in ‘safe’
        ///	casting mode for integer/float dtype and string dtype if the string dtype
        ///	length is not long enough to store the max integer/float value converted
        ///	to a string.<br></br>
        ///	 Previously can_cast in ‘safe’ mode returned True for
        ///	integer/float dtype and a string dtype of any length.
        /// </summary>
        /// <param name="from_">
        ///	Data type, scalar, or array to cast from.
        /// </param>
        /// <param name="to">
        ///	Data type to cast to.
        /// </param>
        /// <param name="casting">
        ///	Controls what kind of data casting may occur.
        /// </param>
        /// <returns>
        ///	True if cast can occur according to the casting rule.
        /// </returns>
        public static bool can_cast(Dtype from_, Dtype to, string casting = "safe")
            => NumPy.Instance.can_cast(from_, to, casting:casting);
        
        /// <summary>
        ///	Returns the data type with the smallest size and smallest scalar
        ///	kind to which both type1 and type2 may be safely cast.<br></br>
        ///	The returned data type is always in native byte order.<br></br>
        ///	
        ///	
        ///	This function is symmetric, but rarely associative.<br></br>
        ///	
        ///	
        ///	Notes
        ///	
        ///	Starting in NumPy 1.9, promote_types function now returns a valid string
        ///	length when given an integer or float dtype as one argument and a string
        ///	dtype as another argument.<br></br>
        ///	 Previously it always returned the input string
        ///	dtype, even if it wasn’t long enough to store the max integer/float value
        ///	converted to a string.
        /// </summary>
        /// <param name="type1">
        ///	First data type.
        /// </param>
        /// <param name="type2">
        ///	Second data type.
        /// </param>
        /// <returns>
        ///	The promoted data type.
        /// </returns>
        public static Dtype promote_types(Dtype type1, Dtype type2)
            => NumPy.Instance.promote_types(type1, type2);
        
        /// <summary>
        ///	For scalar a, returns the data type with the smallest size
        ///	and smallest scalar kind which can hold its value.<br></br>
        ///	  For non-scalar
        ///	array a, returns the vector’s dtype unmodified.<br></br>
        ///	
        ///	
        ///	Floating point values are not demoted to integers,
        ///	and complex values are not demoted to floats.<br></br>
        ///	
        ///	
        ///	Notes
        /// </summary>
        /// <param name="a">
        ///	The value whose minimal data type is to be found.
        /// </param>
        /// <returns>
        ///	The minimal data type.
        /// </returns>
        public static Dtype min_scalar_type(NDarray a)
            => NumPy.Instance.min_scalar_type(a);
        
        /*
        /// <summary>
        ///	Returns the type that results from applying the NumPy
        ///	type promotion rules to the arguments.<br></br>
        ///	
        ///	
        ///	Type promotion in NumPy works similarly to the rules in languages
        ///	like C++, with some slight differences.<br></br>
        ///	  When both scalars and
        ///	arrays are used, the array’s type takes precedence and the actual value
        ///	of the scalar is taken into account.<br></br>
        ///	
        ///	
        ///	For example, calculating 3*a, where a is an array of 32-bit floats,
        ///	intuitively should result in a 32-bit float output.<br></br>
        ///	  If the 3 is a
        ///	32-bit integer, the NumPy rules indicate it can’t convert losslessly
        ///	into a 32-bit float, so a 64-bit float should be the result type.<br></br>
        ///	By examining the value of the constant, ‘3’, we see that it fits in
        ///	an 8-bit integer, which can be cast losslessly into the 32-bit float.<br></br>
        ///	
        ///	
        ///	Notes
        ///	
        ///	The specific algorithm used is as follows.<br></br>
        ///	
        ///	
        ///	Categories are determined by first checking which of boolean,
        ///	integer (int/uint), or floating point (float/complex) the maximum
        ///	kind of all the arrays and the scalars are.<br></br>
        ///	
        ///	
        ///	If there are only scalars or the maximum category of the scalars
        ///	is higher than the maximum category of the arrays,
        ///	the data types are combined with promote_types
        ///	to produce the return value.<br></br>
        ///	
        ///	
        ///	Otherwise, min_scalar_type is called on each array, and
        ///	the resulting data types are all combined with promote_types
        ///	to produce the return value.<br></br>
        ///	
        ///	
        ///	The set of int values is not a subset of the uint values for types
        ///	with the same number of bits, something not reflected in
        ///	min_scalar_type, but handled as a special case in result_type.
        /// </summary>
        /// <param name="arrays_and_dtypes">
        ///	The operands of some operation whose result type is needed.
        /// </param>
        /// <returns>
        ///	The result type.
        /// </returns>
        public static Dtype result_type(list of arrays and dtypes arrays_and_dtypes)
            => NumPy.Instance.result_type(arrays_and_dtypes);
        */
        
        /// <summary>
        ///	Return a scalar type which is common to the input arrays.<br></br>
        ///	
        ///	
        ///	The return type will always be an inexact (i.e.<br></br>
        ///	 floating point) scalar
        ///	type, even if all the arrays are integer arrays.<br></br>
        ///	 If one of the inputs is
        ///	an integer array, the minimum precision type that is returned is a
        ///	64-bit floating point dtype.<br></br>
        ///	
        ///	
        ///	All input arrays except int64 and uint64 can be safely cast to the
        ///	returned dtype without loss of information.
        /// </summary>
        /// <param name="array2">
        ///	Input arrays.
        /// </param>
        /// <param name="array1">
        ///	Input arrays.
        /// </param>
        /// <returns>
        ///	Data type code.
        /// </returns>
        public static Dtype common_type(NDarray array2, NDarray array1)
            => NumPy.Instance.common_type(array2, array1);
        
        /// <summary>
        ///	Return the scalar dtype or NumPy equivalent of Python type of an object.
        /// </summary>
        /// <param name="rep">
        ///	The object of which the type is returned.
        /// </param>
        /// <param name="default">
        ///	If given, this is returned for objects whose types can not be
        ///	determined.<br></br>
        ///	If not given, None is returned for those objects.
        /// </param>
        /// <returns>
        ///	The data type of rep.
        /// </returns>
        public static Dtype obj2sctype(object rep, object @default = null)
            => NumPy.Instance.obj2sctype(rep, @default:@default);
        
        /// <summary>
        ///	Create a data type object.<br></br>
        ///	
        ///	
        ///	A numpy array is homogeneous, and contains elements described by a
        ///	dtype object.<br></br>
        ///	 A dtype object can be constructed from different
        ///	combinations of fundamental numeric types.
        /// </summary>
        /// <param name="align">
        ///	Add padding to the fields to match what a C compiler would output
        ///	for a similar C-struct.<br></br>
        ///	Can be True only if obj is a dictionary
        ///	or a comma-separated string.<br></br>
        ///	If a struct dtype is being created,
        ///	this also sets a sticky alignment flag isalignedstruct.
        /// </param>
        /// <param name="copy">
        ///	Make a new copy of the data-type object.<br></br>
        ///	If False, the result
        ///	may just be a reference to a built-in data-type object.
        /// </param>
        public static void dtype(bool? align = null, bool? copy = null)
            => NumPy.Instance.dtype(align:align, copy:copy);
        
        /// <summary>
        ///	Class to convert formats, names, titles description to a dtype.<br></br>
        ///	
        ///	
        ///	After constructing the format_parser object, the dtype attribute is
        ///	the converted data-type:
        ///	dtype = format_parser(formats, names, titles).dtype
        /// </summary>
        /// <param name="formats">
        ///	The format description, either specified as a string with
        ///	comma-separated format descriptions in the form 'f8, i4, a5', or
        ///	a list of format description strings  in the form
        ///	['f8', 'i4', 'a5'].
        /// </param>
        /// <param name="names">
        ///	The field names, either specified as a comma-separated string in the
        ///	form 'col1, col2, col3', or as a list or tuple of strings in the
        ///	form ['col1', 'col2', 'col3'].<br></br>
        ///	An empty list can be used, in that case default field names
        ///	(‘f0’, ‘f1’, …) are used.
        /// </param>
        /// <param name="titles">
        ///	Sequence of title strings.<br></br>
        ///	An empty list can be used to leave titles
        ///	out.
        /// </param>
        /// <param name="aligned">
        ///	If True, align the fields by padding as the C-compiler would.<br></br>
        ///	Default is False.
        /// </param>
        /// <param name="byteorder">
        ///	If specified, all the fields will be changed to the
        ///	provided byte-order.<br></br>
        ///	Otherwise, the default byte-order is
        ///	used.<br></br>
        ///	For all available string specifiers, see dtype.newbyteorder.
        /// </param>
        public static void format_parser(string[] formats, string[] names, string[] titles, bool? aligned = null, string byteorder = null)
            => NumPy.Instance.format_parser(formats, names, titles, aligned:aligned, byteorder:byteorder);
        
        /// <summary>
        ///	Machine limits for floating point types.<br></br>
        ///	
        ///	
        ///	Notes
        ///	
        ///	For developers of NumPy: do not instantiate this at the module level.<br></br>
        ///	The initial calculation of these parameters is expensive and negatively
        ///	impacts import times.<br></br>
        ///	  These objects are cached, so calling finfo()
        ///	repeatedly inside your functions is not a problem.
        /// </summary>
        /// <param name="dtype">
        ///	Kind of floating point data-type about which to get information.
        /// </param>
        public static void finfo(Dtype dtype)
            => NumPy.Instance.finfo(dtype);
        
        /// <summary>
        ///	Machine limits for integer types.
        /// </summary>
        /// <param name="int_type">
        ///	The kind of integer data type to get information about.
        /// </param>
        public static void iinfo(Dtype int_type)
            => NumPy.Instance.iinfo(int_type);
        
        /// <summary>
        ///	Diagnosing machine parameters.<br></br>
        ///	
        ///	
        ///	References
        /// </summary>
        /// <param name="float_conv">
        ///	Function that converts an integer or integer array to a float
        ///	or float array.<br></br>
        ///	Default is float.
        /// </param>
        /// <param name="int_conv">
        ///	Function that converts a float or float array to an integer or
        ///	integer array.<br></br>
        ///	Default is int.
        /// </param>
        /// <param name="float_to_float">
        ///	Function that converts a float array to float.<br></br>
        ///	Default is float.<br></br>
        ///	Note that this does not seem to do anything useful in the current
        ///	implementation.
        /// </param>
        /// <param name="float_to_str">
        ///	Function that converts a single float to a string.<br></br>
        ///	Default is
        ///	lambda v:'%24.16e' %v.
        /// </param>
        /// <param name="title">
        ///	Title that is printed in the string representation of MachAr.
        /// </param>
        public static void MachAr(Delegate float_conv = null, Delegate int_conv = null, Delegate float_to_float = null, Delegate float_to_str = null, string title = null)
            => NumPy.Instance.MachAr(float_conv:float_conv, int_conv:int_conv, float_to_float:float_to_float, float_to_str:float_to_str, title:title);
        
        /// <summary>
        ///	Determines whether the given object represents a scalar data-type.
        /// </summary>
        /// <param name="rep">
        ///	If rep is an instance of a scalar dtype, True is returned.<br></br>
        ///	If not,
        ///	False is returned.
        /// </param>
        /// <returns>
        ///	Boolean result of check whether rep is a scalar dtype.
        /// </returns>
        public static bool issctype(object rep)
            => NumPy.Instance.issctype(rep);
        
        /// <summary>
        ///	Returns True if first argument is a typecode lower/equal in type hierarchy.
        /// </summary>
        /// <param name="arg2">
        ///	dtype or string representing a typecode.
        /// </param>
        /// <param name="arg1">
        ///	dtype or string representing a typecode.
        /// </param>
        public static bool issubdtype(Dtype arg2, Dtype arg1)
            => NumPy.Instance.issubdtype(arg2, arg1);
        
        /// <summary>
        ///	Determine if the first argument is a subclass of the second argument.
        /// </summary>
        /// <param name="arg2">
        ///	Data-types.
        /// </param>
        /// <param name="arg1">
        ///	Data-types.
        /// </param>
        /// <returns>
        ///	The result.
        /// </returns>
        public static bool issubsctype(Dtype arg2, Dtype arg1)
            => NumPy.Instance.issubsctype(arg2, arg1);
        
        /*
        /// <summary>
        ///	Determine if a class is a subclass of a second class.<br></br>
        ///	
        ///	
        ///	issubclass_ is equivalent to the Python built-in issubclass,
        ///	except that it returns False instead of raising a TypeError if one
        ///	of the arguments is not a class.
        /// </summary>
        /// <param name="arg1">
        ///	Input class.<br></br>
        ///	True is returned if arg1 is a subclass of arg2.
        /// </param>
        /// <param name="arg2">
        ///	Input class.<br></br>
        ///	If a tuple of classes, True is returned if arg1 is a
        ///	subclass of any of the tuple elements.
        /// </param>
        /// <returns>
        ///	Whether arg1 is a subclass of arg2 or not.
        /// </returns>
        public static bool issubclass_(class arg1, class or tuple of classes. arg2)
            => NumPy.Instance.issubclass_(arg1, arg2);
        */
        
        /*
        /// <summary>
        ///	Determine common type following standard coercion rules.
        /// </summary>
        /// <param name="array_types">
        ///	A list of dtypes or dtype convertible objects representing arrays.
        /// </param>
        /// <param name="scalar_types">
        ///	A list of dtypes or dtype convertible objects representing scalars.
        /// </param>
        /// <returns>
        ///	The common data type, which is the maximum of array_types ignoring
        ///	scalar_types, unless the maximum of scalar_types is of a
        ///	different kind (dtype.kind).<br></br>
        ///	 If the kind is not understood, then
        ///	None is returned.
        /// </returns>
        public static Dtype find_common_type(sequence array_types, sequence scalar_types)
            => NumPy.Instance.find_common_type(array_types, scalar_types);
        */
        
        /// <summary>
        ///	Return a description for the given data type code.
        /// </summary>
        /// <param name="char">
        ///	Data type code.
        /// </param>
        /// <returns>
        ///	Description of the input data type code.
        /// </returns>
        public static string typename(string @char)
            => NumPy.Instance.typename(@char);
        
        /// <summary>
        ///	Return the string representation of a scalar dtype.
        /// </summary>
        /// <param name="sctype">
        ///	If a scalar dtype, the corresponding string character is
        ///	returned.<br></br>
        ///	If an object, sctype2char tries to infer its scalar type
        ///	and then return the corresponding string character.
        /// </param>
        /// <returns>
        ///	The string character corresponding to the scalar type.
        /// </returns>
        public static string sctype2char(object sctype)
            => NumPy.Instance.sctype2char(sctype);
        
        /// <summary>
        ///	Return the character for the minimum-size type to which given types can
        ///	be safely cast.<br></br>
        ///	
        ///	
        ///	The returned type character must represent the smallest size dtype such
        ///	that an array of the returned type can handle the data from an array of
        ///	all types in typechars (or if typechars is an array, then its
        ///	dtype.char).
        /// </summary>
        /// <param name="typechars">
        ///	If a list of strings, each string should represent a dtype.<br></br>
        ///	If array_like, the character representation of the array dtype is used.
        /// </param>
        /// <param name="typeset">
        ///	The set of characters that the returned character is chosen from.<br></br>
        ///	The default set is ‘GDFgdf’.
        /// </param>
        /// <param name="default">
        ///	The default character, this is returned if none of the characters in
        ///	typechars matches a character in typeset.
        /// </param>
        /// <returns>
        ///	The character representing the minimum-size type that was found.
        /// </returns>
        public static string mintypecode(string[] typechars, string[] typeset = null, string @default = "d")
            => NumPy.Instance.mintypecode(typechars, typeset:typeset, @default:@default);
        
        
    }
}
