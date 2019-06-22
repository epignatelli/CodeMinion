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
            /// A kind of Tensor that is to be considered a module parameter.
            /// 
            /// Parameters are Tensor subclasses, that have a
            /// very special property when used with Module s - when they’re
            /// assigned as Module attributes they are automatically added to the list of
            /// its parameters, and will appear e.g. in parameters() iterator.
            /// Assigning a Tensor doesn’t have such effect. This is because one might
            /// want to cache some temporary state, like last hidden state of the RNN, in
            /// the model. If there was no such class as Parameter, these
            /// temporaries would get registered too.
            /// </summary>
            public partial class Parameter : PythonObject
            {
                // auto-generated class
                
                public Parameter(PyObject pyobj) : base(pyobj) { }
                
                public Parameter(Tensor data, bool? requires_grad = null)
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    var pyargs=ToTuple(new object[]
                    {
                        data,
                    });
                    var kwargs=new PyDict();
                    if (requires_grad!=null) kwargs["requires_grad"]=ToPython(requires_grad);
                    dynamic py = __self__.InvokeMethod("Parameter", pyargs, kwargs);
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
