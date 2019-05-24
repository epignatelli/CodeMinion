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
    public partial class PythonObject
    {
        
        
        //auto-generated
        protected PyTuple ToTuple(Array input)
        {
            var array = new PyObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i]=ToPython(input.GetValue(i));
            }
            return new PyTuple(array);
        }
        
        //auto-generated
        protected PyObject ToPython(object obj)
        {
            if (obj == null) return null;
            switch (obj)
            {
                // basic types
                case int o: return new PyInt(o);
                case float o: return new PyFloat(o);
                case double o: return new PyFloat(o);
                case string o: return new PyString(o);
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
        protected T ToCsharp<T>(dynamic pyobj)
        {
            switch (typeof(T).Name)
            {
                // types from 'ToCsharpConversions'
                case "Dtype": return (T)(object)new Dtype(pyobj);
                case "NDarray": return (T)(object)new NDarray(pyobj);
                case "Matrix": return (T)(object)new Matrix(pyobj);
                default: return (T)pyobj;
            }
        }
        
        //auto-generated
        protected T SharpToSharp<T>(object obj)
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
        protected NDarray ConvertArrayToNDarray(Array a)
        {
            switch(a)
            {
                case bool[] arr: return np.array(arr);
                default: throw new NotImplementedException($"Type {a.GetType()} not supported yet in ConvertArrayToNDarray.");
            }
        }
    }
}
