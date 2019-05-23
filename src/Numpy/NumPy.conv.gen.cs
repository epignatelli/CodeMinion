using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Python.Included;
using NumSharp;

namespace Numpy
{
    public partial class NumPy : IDisposable
    {
        
        private PyObject _pyobj = null;
        public static NumPy Instance => _instance.Value;
        
        private static Lazy<NumPy> _instance = new Lazy<NumPy>(() => 
        {
            var instance=new NumPy();
            try
            {
                instance._pyobj = InstallAndImport();
            }
            catch (Exception)
            {
                // retry to fix the installation by forcing a repair.
                instance._pyobj = InstallAndImport(force: true);
            }
            return instance;
        }
        );
        
        private static PyObject InstallAndImport(bool force = false)
        {
            var installer = new Installer();
            installer.SetupPython(force).Wait();
            installer.InstallWheel(typeof(NumPy).Assembly, "numpy-1.16.3-cp37-cp37m-win_amd64.whl").Wait();
            PythonEngine.Initialize();
            var mod = Py.Import("numpy");
            return mod;
        }
        
        public dynamic self => _pyobj;
        private bool IsInitialized => _pyobj != null;
        
        private NumPy() { }
        
        public void Dispose()
        {
            self?.Dispose();
        }
        
        
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
                case NumSharp.Shape o: return ToTuple(o.Dimensions);
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
