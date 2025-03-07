﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Math.Tests
{
    [TestFixture, UnitTest]
    public class Random800_90Tests
    {
        /// <summary>
        /// Test implementation of <see cref="Random800_90"/>.  
        /// Used to ensure while block within GetDifferentBitStringOfSameSize is hit.
        /// </summary>
        private class TestRandom800_90 : Random800_90
        {
            private readonly BitString _currentBitString;

            public TestRandom800_90(BitString currentBitString)
            {
                _currentBitString = currentBitString;
            }

            public bool HasReturnedCurrentBitString { get; private set; }

            /// <summary>
            /// Returns the <see cref="_currentBitString"/> the first time invoked, and a different <see cref="BitString"/> the second time.
            /// </summary>
            /// <param name="length">The length of the bitstring</param>
            /// <returns>BitString</returns>
            public override BitString GetRandomBitString(int length)
            {
                if (!HasReturnedCurrentBitString)
                {
                    HasReturnedCurrentBitString = true;
                    return _currentBitString;
                }

                // XORable bit array of length
                BitString bs = new BitString(length);
                bs.Bits.SetAll(true);

                // Get the XOR of the current bit string after it is returned as is a single time.
                return bs.XOR(_currentBitString);
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void ShouldReturnZeroLengthBitStringForZeroOrLessLengths(int length)
        {
            var subject = new Random800_90();
            var result = subject.GetRandomBitString(length);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.BitLength);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(16)]
        public void ShouldReturnSelectedLength(int length)
        {
            var subject = new Random800_90();
            var result = subject.GetRandomBitString(length);
            Assert.That(result != null);
            Assert.AreEqual(length, result.BitLength);
        }

        [Test]
        public void ShouldReturnNullWhenCurrentIsNull()
        {
            var subject = new Random800_90();
            var result = subject.GetDifferentBitStringOfSameSize(null);

            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnNullWhenCurrentIsZeroLength()
        {
            var subject = new Random800_90();
            var zeroLengthBitString = new BitString(0);
            var result = subject.GetDifferentBitStringOfSameSize(zeroLengthBitString);

            Assert.IsNull(result);
        }

        [Test]
        [TestCase("test1", new[] { true })]
        [TestCase("test2", new[] { true, false, true })]
        [TestCase("test3", new[] { true, true, true })]
        [TestCase("test4", new[] { false, false, true, true })]
        public void ShouldReturnDifferentBitStringWhenInvoked(string label, bool[] bits)
        {
            var bs = new BitString(new BitArray(bits));
            TestRandom800_90 subject = new TestRandom800_90(bs);
            var result = subject.GetDifferentBitStringOfSameSize(bs);

            Assert.AreNotEqual(bs, result);
        }

        [Test]
        [TestCase(0, 1, 100)]
        public void ShouldReturnNothingOutsideOfRange(int min, int max, int iterations)
        {
            var subject = new Random800_90();

            for (int i = 0; i < iterations; i++)
            {
                var result = subject.GetRandomInt(min, max);
                Assert.IsTrue(result >= 0 && result <= 1);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ShouldReturnCorrectNumberOfAlphaCharacters(int length)
        {
            var subject = new Random800_90();

            var result = subject.GetRandomAlphaCharacters(length);

            Assert.IsTrue(Regex.IsMatch(result, @"^[a-zA-Z]+$"));
            Assert.AreEqual(length, result.Length);
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ShouldReturnCorrectNumberOfCharacters(int length)
        {
            var subject = new Random800_90();

            var result = subject.GetRandomString(length);

            Assert.AreEqual(length, result.Length);
        }

        [Test]
        public void TestRandomSeed()
        {
            var randoms = new List<Random>();
            for (var i = 0; i < 16; i++)
            {
                randoms.Add(new Random());
            }

            var dict = new Dictionary<Random, List<int>>();

            foreach (var random in randoms)
            {
                var numbers = new List<int>();
                for (var i = 0; i < 128; i++)
                {
                    numbers.Add(random.Next());
                }

                dict.Add(random, numbers);
            }

            var groupedRandoms = dict.Values.SelectMany(values => values)
                .ToList()
                .GroupBy(gb => gb)
                .Select(s => new
                {
                    s.Key,
                    Count = s.Count()
                })
                .OrderByDescending(ob => ob.Count)
                .ToList();

            Assert.True(true);
        }
    }
}
