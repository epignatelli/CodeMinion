using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.gluon.nn
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class Flatten : Base
	{
		private static dynamic caller = Instance.mxnet.gluon.nn.Flatten;
		public Flatten()
		{
			
			__self__ = caller;
		}

		
	}
}