﻿using System;
using System.Collections.Generic;
using System.Text;
using Python.Runtime;

namespace Torch
{
    public partial class PythonObject : IDisposable
    {
        protected readonly PyObject self;
        public dynamic PyObject => self;

        public IntPtr Handle => self.Handle;

        public PythonObject(PyObject pyobject)
        {
            this.self = pyobject;
        }

        public PythonObject(Tensor t)
        {
            this.self = t.PyObject;
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case PythonObject other:
                    return self.Equals(other.self);
                case PyObject other:
                    return self.Equals(other);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return self.GetHashCode();
        }

        public string repr => ToString();

        public override string ToString()
        {
            return self.ToString();
        }

        public void Dispose()
        {
            self?.Dispose();
        }
    }
}
