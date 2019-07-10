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
            ///	A placeholder identity operator that is argument-insensitive.
            /// </summary>
            public partial class Identity : Module
            {
                // auto-generated class
                
                public Identity(PyObject pyobj) : base(pyobj) { }
                
                public Identity(Module other) : base(other.PyObject as PyObject) { }
                
                public Identity()
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    dynamic py = __self__.InvokeMethod("Identity");
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
