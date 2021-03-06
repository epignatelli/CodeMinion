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
            ///	The Kullback-Leibler divergence Loss
            ///	
            ///	KL divergence is a useful distance measure for continuous distributions
            ///	and is often useful when performing direct regression over the space of
            ///	(discretely sampled) continuous output distributions.<br></br>
            ///	
            ///	As with NLLLoss, the input given is expected to contain
            ///	log-probabilities and is not restricted to a 2D Tensor.<br></br>
            ///	
            ///	The targets are given as probabilities (i.e.<br></br>
            ///	 without taking the logarithm).<br></br>
            ///	
            ///	This criterion expects a target Tensor of the same size as the
            ///	input Tensor.<br></br>
            ///	
            ///	The unreduced (i.e.<br></br>
            ///	 with reduction set to 'none') loss can be described as:
            ///	
            ///	\[l(x,y) = L = \{ l_1,\dots,l_N \}, \quad
            ///	l_n = y_n \cdot \left( \log y_n - x_n \right)
            ///	
            ///	\]
            ///	
            ///	where the index \(N\) spans all dimensions of input and \(L\) has the same
            ///	shape as input.<br></br>
            ///	 If reduction is not 'none' (default 'mean'), then:
            ///	
            ///	\[\ell(x, y) = \begin{cases}
            ///	    \operatorname{mean}(L), & \text{if reduction} = \text{'mean';} \\
            ///	    \operatorname{sum}(L),  & \text{if reduction} = \text{'sum'.}
            ///	\end{cases}
            ///	
            ///	\]
            ///	
            ///	In default reduction mode 'mean', the losses are averaged for each minibatch over observations
            ///	as well as over dimensions.<br></br>
            ///	 'batchmean' mode gives the correct KL divergence where losses
            ///	are averaged over batch dimension only.<br></br>
            ///	 'mean' mode’s behavior will be changed to the same as
            ///	'batchmean' in the next major release.
            /// </summary>
            public partial class KLDivLoss : Module
            {
                // auto-generated class
                
                public KLDivLoss(PyObject pyobj) : base(pyobj) { }
                
                public KLDivLoss(Module other) : base(other.PyObject as PyObject) { }
                
                public KLDivLoss(bool? size_average = null, bool? reduce = null, string reduction = "mean")
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    var pyargs=ToTuple(new object[]
                    {
                    });
                    var kwargs=new PyDict();
                    if (size_average!=null) kwargs["size_average"]=ToPython(size_average);
                    if (reduce!=null) kwargs["reduce"]=ToPython(reduce);
                    if (reduction!="mean") kwargs["reduction"]=ToPython(reduction);
                    dynamic py = __self__.InvokeMethod("KLDivLoss", pyargs, kwargs);
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
