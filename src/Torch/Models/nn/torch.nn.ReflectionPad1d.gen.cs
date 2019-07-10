// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Numpy;
using Numpy.Models;

namespace Torch
{
    public static partial class torch {
        public static partial class nn {
            /// <summary>
            ///	Pads the input tensor using the reflection of the input boundary.<br></br>
            ///	
            ///	For N-dimensional padding, use torch.nn.functional.pad().
            /// </summary>
            public partial class ReflectionPad1d : Module
            {
                // auto-generated class
                
                public ReflectionPad1d(PyObject pyobj) : base(pyobj) { }
                
                public ReflectionPad1d(Module other) : base(other.PyObject as PyObject) { }
                
                public ReflectionPad1d(int padding = 0)
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    var pyargs=ToTuple(new object[]
                    {
                    });
                    var kwargs=new PyDict();
                    if (padding!=0) kwargs["padding"]=ToPython(padding);
                    dynamic py = __self__.InvokeMethod("ReflectionPad1d", pyargs, kwargs);
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
