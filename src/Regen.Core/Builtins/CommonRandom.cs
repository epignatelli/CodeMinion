﻿using System;
using Regen.Compiler;
using Regen.DataTypes;

namespace Regen.Builtins {
    public class CommonRandom : IRegenModule {
        private Random _random = new Random();
        private int? _seed = null;

        public object Seed(int seed) {
            _seed = seed;
            _random = new Random(seed);
            return null;
        }

        public int GetSeed(int seed) {
            return _seed ?? -1;
        }

        /// <summary>Returns a non-negative random integer.</summary>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="F:System.Int32.MaxValue" />.</returns>
        public int NextInt() {
            return _random.Next();
        }

        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned. </param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue" /> must be greater than or equal to <paramref name="minValue" />. </param>
        /// <returns>A 32-bit signed integer greater than or equal to <paramref name="minValue" /> and less than <paramref name="maxValue" />; that is, the range of return values includes <paramref name="minValue" /> but not <paramref name="maxValue" />. If <paramref name="minValue" /> equals <paramref name="maxValue" />, <paramref name="minValue" /> is returned.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="minValue" /> is greater than <paramref name="maxValue" />. </exception>
        public int NextInt(int minValue, int maxValue) {
            return _random.Next(minValue, maxValue);
        }

        /// <summary>Returns a non-negative random integer that is less than the specified maximum.</summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue" /> must be greater than or equal to 0. </param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue" />; that is, the range of return values ordinarily includes 0 but not <paramref name="maxValue" />. However, if <paramref name="maxValue" /> equals 0, <paramref name="maxValue" /> is returned.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="maxValue" /> is less than 0. </exception>
        public int NextInt(int maxValue) {
            return _random.Next(maxValue);
        }

        /// <summary>Fills the elements of a specified array of bytes with random numbers.</summary>
        /// <param name="buffer">An array of bytes to contain random numbers. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="buffer" /> is <see langword="null" />. </exception>
        public void NextBytes(byte[] buffer) {
            _random.NextBytes(buffer);
        }

        /// <summary>Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.</summary>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
        public double NextDouble() {
            return _random.NextDouble();
        }

        /// <summary>Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.</summary>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
        public double NextDouble(double from, double to) {
            return _random.NextDouble() * to - from;
        }

        /// <summary>
        ///     Simply implement as return this
        /// </summary>
        /// <remarks>Because <see cref="Flee"/> implements external modules as a namespace and not an actual type, returns self </remarks>
        public Data Self() {
            return null; //TODO add ObjectScalar.
        }
    }
}