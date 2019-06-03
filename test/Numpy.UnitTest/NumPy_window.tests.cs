// Copyright (c) 2019 by the SciSharp Team
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Numpy.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Numpy.UnitTest
{
    [TestClass]
    public class NumPy_windowTest : BaseTestCase
    {
        
        [TestMethod]
        public void bartlettTest()
        {
            // >>> np.bartlett(12)
            // array([ 0.        ,  0.18181818,  0.36363636,  0.54545455,  0.72727273,
            //         0.90909091,  0.90909091,  0.72727273,  0.54545455,  0.36363636,
            //         0.18181818,  0.        ])
            // 
            
            #if TODO
            var given=  np.bartlett(12);
            var expected=
                "array([ 0.        ,  0.18181818,  0.36363636,  0.54545455,  0.72727273,\n" +
                "        0.90909091,  0.90909091,  0.72727273,  0.54545455,  0.36363636,\n" +
                "        0.18181818,  0.        ])";
            Assert.AreEqual(expected, given.repr);
            #endif
            // Plot the window and its frequency response (requires SciPy and matplotlib):
            
            // >>> from numpy.fft import fft, fftshift
            // >>> window = np.bartlett(51)
            // >>> plt.plot(window)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Bartlett window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Amplitude")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Sample")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.show()
            // 
            
            #if TODO
             given=  from numpy.fft import fft, fftshift;
             given=  window = np.bartlett(51);
             given=  plt.plot(window);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Bartlett window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Amplitude");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Sample");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
            // >>> plt.figure()
            // <matplotlib.figure.Figure object at 0x...>
            // >>> A = fft(window, 2048) / 25.5
            // >>> mag = np.abs(fftshift(A))
            // >>> freq = np.linspace(-0.5, 0.5, len(A))
            // >>> response = 20 * np.log10(mag)
            // >>> response = np.clip(response, -100, 100)
            // >>> plt.plot(freq, response)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Frequency response of Bartlett window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Magnitude [dB]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Normalized frequency [cycles per sample]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.axis('tight')
            // (-0.5, 0.5, -100.0, ...)
            // >>> plt.show()
            // 
            
            #if TODO
             given=  plt.figure();
             expected=
                "<matplotlib.figure.Figure object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  A = fft(window, 2048) / 25.5;
             given=  mag = np.abs(fftshift(A));
             given=  freq = np.linspace(-0.5, 0.5, len(A));
             given=  response = 20 * np.log10(mag);
             given=  response = np.clip(response, -100, 100);
             given=  plt.plot(freq, response);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Frequency response of Bartlett window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Magnitude [dB]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Normalized frequency [cycles per sample]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.axis('tight');
             expected=
                "(-0.5, 0.5, -100.0, ...)";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
        }
        
        
        [TestMethod]
        public void blackmanTest()
        {
            // >>> import matplotlib.pyplot as plt
            // >>> np.blackman(12)
            // array([ -1.38777878e-17,   3.26064346e-02,   1.59903635e-01,
            //          4.14397981e-01,   7.36045180e-01,   9.67046769e-01,
            //          9.67046769e-01,   7.36045180e-01,   4.14397981e-01,
            //          1.59903635e-01,   3.26064346e-02,  -1.38777878e-17])
            // 
            
            #if TODO
            var given=  import matplotlib.pyplot as plt;
             given=  np.blackman(12);
            var expected=
                "array([ -1.38777878e-17,   3.26064346e-02,   1.59903635e-01,\n" +
                "         4.14397981e-01,   7.36045180e-01,   9.67046769e-01,\n" +
                "         9.67046769e-01,   7.36045180e-01,   4.14397981e-01,\n" +
                "         1.59903635e-01,   3.26064346e-02,  -1.38777878e-17])";
            Assert.AreEqual(expected, given.repr);
            #endif
            // Plot the window and the frequency response:
            
            // >>> from numpy.fft import fft, fftshift
            // >>> window = np.blackman(51)
            // >>> plt.plot(window)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Blackman window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Amplitude")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Sample")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.show()
            // 
            
            #if TODO
             given=  from numpy.fft import fft, fftshift;
             given=  window = np.blackman(51);
             given=  plt.plot(window);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Blackman window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Amplitude");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Sample");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
            // >>> plt.figure()
            // <matplotlib.figure.Figure object at 0x...>
            // >>> A = fft(window, 2048) / 25.5
            // >>> mag = np.abs(fftshift(A))
            // >>> freq = np.linspace(-0.5, 0.5, len(A))
            // >>> response = 20 * np.log10(mag)
            // >>> response = np.clip(response, -100, 100)
            // >>> plt.plot(freq, response)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Frequency response of Blackman window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Magnitude [dB]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Normalized frequency [cycles per sample]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.axis('tight')
            // (-0.5, 0.5, -100.0, ...)
            // >>> plt.show()
            // 
            
            #if TODO
             given=  plt.figure();
             expected=
                "<matplotlib.figure.Figure object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  A = fft(window, 2048) / 25.5;
             given=  mag = np.abs(fftshift(A));
             given=  freq = np.linspace(-0.5, 0.5, len(A));
             given=  response = 20 * np.log10(mag);
             given=  response = np.clip(response, -100, 100);
             given=  plt.plot(freq, response);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Frequency response of Blackman window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Magnitude [dB]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Normalized frequency [cycles per sample]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.axis('tight');
             expected=
                "(-0.5, 0.5, -100.0, ...)";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
        }
        
        
        [TestMethod]
        public void hammingTest()
        {
            // >>> np.hamming(12)
            // array([ 0.08      ,  0.15302337,  0.34890909,  0.60546483,  0.84123594,
            //         0.98136677,  0.98136677,  0.84123594,  0.60546483,  0.34890909,
            //         0.15302337,  0.08      ])
            // 
            
            #if TODO
            var given=  np.hamming(12);
            var expected=
                "array([ 0.08      ,  0.15302337,  0.34890909,  0.60546483,  0.84123594,\n" +
                "        0.98136677,  0.98136677,  0.84123594,  0.60546483,  0.34890909,\n" +
                "        0.15302337,  0.08      ])";
            Assert.AreEqual(expected, given.repr);
            #endif
            // Plot the window and the frequency response:
            
            // >>> import matplotlib.pyplot as plt
            // >>> from numpy.fft import fft, fftshift
            // >>> window = np.hamming(51)
            // >>> plt.plot(window)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Hamming window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Amplitude")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Sample")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.show()
            // 
            
            #if TODO
             given=  import matplotlib.pyplot as plt;
             given=  from numpy.fft import fft, fftshift;
             given=  window = np.hamming(51);
             given=  plt.plot(window);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Hamming window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Amplitude");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Sample");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
            // >>> plt.figure()
            // <matplotlib.figure.Figure object at 0x...>
            // >>> A = fft(window, 2048) / 25.5
            // >>> mag = np.abs(fftshift(A))
            // >>> freq = np.linspace(-0.5, 0.5, len(A))
            // >>> response = 20 * np.log10(mag)
            // >>> response = np.clip(response, -100, 100)
            // >>> plt.plot(freq, response)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Frequency response of Hamming window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Magnitude [dB]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Normalized frequency [cycles per sample]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.axis('tight')
            // (-0.5, 0.5, -100.0, ...)
            // >>> plt.show()
            // 
            
            #if TODO
             given=  plt.figure();
             expected=
                "<matplotlib.figure.Figure object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  A = fft(window, 2048) / 25.5;
             given=  mag = np.abs(fftshift(A));
             given=  freq = np.linspace(-0.5, 0.5, len(A));
             given=  response = 20 * np.log10(mag);
             given=  response = np.clip(response, -100, 100);
             given=  plt.plot(freq, response);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Frequency response of Hamming window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Magnitude [dB]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Normalized frequency [cycles per sample]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.axis('tight');
             expected=
                "(-0.5, 0.5, -100.0, ...)";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
        }
        
        
        [TestMethod]
        public void hanningTest()
        {
            // >>> np.hanning(12)
            // array([ 0.        ,  0.07937323,  0.29229249,  0.57115742,  0.82743037,
            //         0.97974649,  0.97974649,  0.82743037,  0.57115742,  0.29229249,
            //         0.07937323,  0.        ])
            // 
            
            #if TODO
            var given=  np.hanning(12);
            var expected=
                "array([ 0.        ,  0.07937323,  0.29229249,  0.57115742,  0.82743037,\n" +
                "        0.97974649,  0.97974649,  0.82743037,  0.57115742,  0.29229249,\n" +
                "        0.07937323,  0.        ])";
            Assert.AreEqual(expected, given.repr);
            #endif
            // Plot the window and its frequency response:
            
            // >>> import matplotlib.pyplot as plt
            // >>> from numpy.fft import fft, fftshift
            // >>> window = np.hanning(51)
            // >>> plt.plot(window)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Hann window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Amplitude")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Sample")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.show()
            // 
            
            #if TODO
             given=  import matplotlib.pyplot as plt;
             given=  from numpy.fft import fft, fftshift;
             given=  window = np.hanning(51);
             given=  plt.plot(window);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Hann window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Amplitude");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Sample");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
            // >>> plt.figure()
            // <matplotlib.figure.Figure object at 0x...>
            // >>> A = fft(window, 2048) / 25.5
            // >>> mag = np.abs(fftshift(A))
            // >>> freq = np.linspace(-0.5, 0.5, len(A))
            // >>> response = 20 * np.log10(mag)
            // >>> response = np.clip(response, -100, 100)
            // >>> plt.plot(freq, response)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Frequency response of the Hann window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Magnitude [dB]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Normalized frequency [cycles per sample]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.axis('tight')
            // (-0.5, 0.5, -100.0, ...)
            // >>> plt.show()
            // 
            
            #if TODO
             given=  plt.figure();
             expected=
                "<matplotlib.figure.Figure object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  A = fft(window, 2048) / 25.5;
             given=  mag = np.abs(fftshift(A));
             given=  freq = np.linspace(-0.5, 0.5, len(A));
             given=  response = 20 * np.log10(mag);
             given=  response = np.clip(response, -100, 100);
             given=  plt.plot(freq, response);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Frequency response of the Hann window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Magnitude [dB]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Normalized frequency [cycles per sample]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.axis('tight');
             expected=
                "(-0.5, 0.5, -100.0, ...)";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
        }
        
        
        [TestMethod]
        public void kaiserTest()
        {
            // >>> import matplotlib.pyplot as plt
            // >>> np.kaiser(12, 14)
            // array([  7.72686684e-06,   3.46009194e-03,   4.65200189e-02,
            //          2.29737120e-01,   5.99885316e-01,   9.45674898e-01,
            //          9.45674898e-01,   5.99885316e-01,   2.29737120e-01,
            //          4.65200189e-02,   3.46009194e-03,   7.72686684e-06])
            // 
            
            #if TODO
            var given=  import matplotlib.pyplot as plt;
             given=  np.kaiser(12, 14);
            var expected=
                "array([  7.72686684e-06,   3.46009194e-03,   4.65200189e-02,\n" +
                "         2.29737120e-01,   5.99885316e-01,   9.45674898e-01,\n" +
                "         9.45674898e-01,   5.99885316e-01,   2.29737120e-01,\n" +
                "         4.65200189e-02,   3.46009194e-03,   7.72686684e-06])";
            Assert.AreEqual(expected, given.repr);
            #endif
            // Plot the window and the frequency response:
            
            // >>> from numpy.fft import fft, fftshift
            // >>> window = np.kaiser(51, 14)
            // >>> plt.plot(window)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Kaiser window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Amplitude")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Sample")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.show()
            // 
            
            #if TODO
             given=  from numpy.fft import fft, fftshift;
             given=  window = np.kaiser(51, 14);
             given=  plt.plot(window);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Kaiser window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Amplitude");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Sample");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
            // >>> plt.figure()
            // <matplotlib.figure.Figure object at 0x...>
            // >>> A = fft(window, 2048) / 25.5
            // >>> mag = np.abs(fftshift(A))
            // >>> freq = np.linspace(-0.5, 0.5, len(A))
            // >>> response = 20 * np.log10(mag)
            // >>> response = np.clip(response, -100, 100)
            // >>> plt.plot(freq, response)
            // [<matplotlib.lines.Line2D object at 0x...>]
            // >>> plt.title("Frequency response of Kaiser window")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.ylabel("Magnitude [dB]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.xlabel("Normalized frequency [cycles per sample]")
            // <matplotlib.text.Text object at 0x...>
            // >>> plt.axis('tight')
            // (-0.5, 0.5, -100.0, ...)
            // >>> plt.show()
            // 
            
            #if TODO
             given=  plt.figure();
             expected=
                "<matplotlib.figure.Figure object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  A = fft(window, 2048) / 25.5;
             given=  mag = np.abs(fftshift(A));
             given=  freq = np.linspace(-0.5, 0.5, len(A));
             given=  response = 20 * np.log10(mag);
             given=  response = np.clip(response, -100, 100);
             given=  plt.plot(freq, response);
             expected=
                "[<matplotlib.lines.Line2D object at 0x...>]";
            Assert.AreEqual(expected, given.repr);
             given=  plt.title("Frequency response of Kaiser window");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.ylabel("Magnitude [dB]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.xlabel("Normalized frequency [cycles per sample]");
             expected=
                "<matplotlib.text.Text object at 0x...>";
            Assert.AreEqual(expected, given.repr);
             given=  plt.axis('tight');
             expected=
                "(-0.5, 0.5, -100.0, ...)";
            Assert.AreEqual(expected, given.repr);
             given=  plt.show();
            #endif
        }
        
    }
}
