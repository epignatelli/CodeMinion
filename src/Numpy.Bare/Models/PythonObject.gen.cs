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

namespace Numpy
{
    public partial class PythonObject
    {
        
        
        //auto-generated
        public PyTuple ToTuple(Array input)
        {
            var array = new PyObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i]=ToPython(input.GetValue(i));
            }
            return new PyTuple(array);
        }
        
        //auto-generated
        public PyObject ToPython(object obj)
        {
            if (obj == null) return Runtime.GetPyNone();
            switch (obj)
            {
                // basic types
                case int o: return new PyInt(o);
                case long o: return new PyLong(o);
                case float o: return new PyFloat(o);
                case double o: return new PyFloat(o);
                case string o: return new PyString(o);
                case bool o: return ConverterExtension.ToPython(o);
                case PyObject o: return o;
                // sequence types
                case Array o: return ToTuple(o);
                // special types from 'ToPythonConversions'
                case Shape o: return ToTuple(o.Dimensions);
                case Slice o: return o.ToPython();
                case PythonObject o: return o.PyObject;
                default: throw new NotImplementedException($"Type is not yet supported: { obj.GetType().Name}. Add it to 'ToPythonConversions'");
            }
        }
        
        //auto-generated
        public T ToCsharp<T>(dynamic pyobj)
        {
            switch (typeof(T).Name)
            {
                // types from 'ToCsharpConversions'
                case "Dtype": return (T)(object)new Dtype(pyobj);
                case "NDarray": return (T)(object)new NDarray(pyobj);
                case "NDarray`1":
                switch (typeof(T).GenericTypeArguments[0].Name)
                {
                   case "Byte": return (T)(object)new NDarray<byte>(pyobj);
                   case "Short": return (T)(object)new NDarray<short>(pyobj);
                   case "Boolean": return (T)(object)new NDarray<bool>(pyobj);
                   case "Int32": return (T)(object)new NDarray<int>(pyobj);
                   case "Int64": return (T)(object)new NDarray<long>(pyobj); 
                   case "Single": return (T)(object)new NDarray<float>(pyobj); 
                   case "Double": return (T)(object)new NDarray<double>(pyobj); 
                   default: throw new NotImplementedException($"Type NDarray<{typeof(T).GenericTypeArguments[0].Name}> missing. Add it to 'ToCsharpConversions'");
                }
                break;
                case "NDarray[]":
                   var po = pyobj as PyObject;
                   var len = po.Length();
                   var rv = new NDarray[len];
                   for (int i = 0; i < len; i++)
                       rv[i] = ToCsharp<NDarray>(po[i]);
                   return (T) (object) rv;
                case "Matrix": return (T)(object)new Matrix(pyobj);
                default:
                try
                {
                    return pyobj.As<T>();
                }
                catch (Exception e)
                {
                    throw new NotImplementedException($"conversion from {typeof(T).Name} to {pyobj.__class__} not implemented", e);
                    return default(T);
                }
            }
        }
        
        //auto-generated
        public T SharpToSharp<T>(object obj)
        {
            if (obj == null) return default(T);
            switch (obj)
            {
                // from 'SharpToSharpConversions':
                case Array a:
                if (typeof(T)==typeof(NDarray)) return (T)(object)ConvertArrayToNDarray(a);
                break;
            }
            throw new NotImplementedException($"Type is not yet supported: { obj.GetType().Name}. Add it to 'SharpToSharpConversions'");
        }
        
        //auto-generated: SpecialConversions
        private static NDarray ConvertArrayToNDarray(Array a)
        {
            switch(a)
            {
                case bool[] arr: return np.array(arr);
                case int[,] arr: return np.array(arr.Cast<int>().ToArray()).reshape(arr.GetLength(0), arr.GetLength(1));
                case float[,] arr: return np.array(arr.Cast<float>().ToArray()).reshape(arr.GetLength(0), arr.GetLength(1));
                case double[,] arr: return np.array(arr.Cast<double>().ToArray()).reshape(arr.GetLength(0), arr.GetLength(1));
                case bool[,] arr: return np.array(arr.Cast<bool>().ToArray()).reshape(arr.GetLength(0), arr.GetLength(1));
                default: throw new NotImplementedException($"Type {a.GetType()} not supported yet in ConvertArrayToNDarray.");
            }
        }
    }
}
