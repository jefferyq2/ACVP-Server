﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NIST.CVP.ACVTS.Libraries.Generation.AES_CCM.v1_0;
using NIST.CVP.ACVTS.Libraries.Math;
using NIST.CVP.ACVTS.Libraries.Math.Domain;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.AES.CCM
{
    [TestFixture, UnitTest]
    public class TestGroupGeneratorTests
    {
        private TestGroupGenerator _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new TestGroupGenerator();
        }

        #region Parameter test scenarios
        private static object[] GetTestParameterData()
        {

            List<object[]> list = new List<object[]>()
            {
                new object[]
                {
                    "minimum inputs",
                    new[] {128},
                    new MathDomain().AddSegment(new ValueDomainSegment(0)),
                    new MathDomain().AddSegment(new ValueDomainSegment(0)),
                    new MathDomain().AddSegment(new ValueDomainSegment(ParameterValidator.VALID_NONCE_LENGTHS.First())),
                    new[] {ParameterValidator.VALID_TAG_LENGTHS.First()},
                },
                new object[]
                {
                    "multiple inputs, single array",
                    new[] {128, 192, 256},
                    new MathDomain().AddSegment(new ValueDomainSegment(0)),
                    new MathDomain().AddSegment(new ValueDomainSegment(0)),
                    new MathDomain().AddSegment(new ValueDomainSegment(ParameterValidator.VALID_NONCE_LENGTHS.First())),
                    new[] {ParameterValidator.VALID_TAG_LENGTHS.First()},
                },
                new object[]
                {
                    "multiple differing inputs, in min/max array",
                    new[] {128},
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(), 0, 32 * 8, 8)),
                    new MathDomain().AddSegment(new ValueDomainSegment(0)),
                    new MathDomain().AddSegment(new ValueDomainSegment(ParameterValidator.VALID_NONCE_LENGTHS.First())),
                    new[] {ParameterValidator.VALID_TAG_LENGTHS.First()}
                },
                new object[]
                {
                    "max number of groups, no 2^16",
                    new[] {128, 192, 256},
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(), 0, 32 * 8, 8)),
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(), 0, 32 * 8, 8)),
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(),
                        ParameterValidator.VALID_NONCE_LENGTHS.First(), ParameterValidator.VALID_NONCE_LENGTHS.Last(), 8)),
                    ParameterValidator.VALID_TAG_LENGTHS
                },
                new object[]
                {
                    "max number of groups, max aad",
                    new[] {128, 192, 256},
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(), 0, (1 << 19), 8)),
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(), 0, 32 * 8, 8)),
                    new MathDomain().AddSegment(new RangeDomainSegment(new Random800_90(),
                        ParameterValidator.VALID_NONCE_LENGTHS.First(), ParameterValidator.VALID_NONCE_LENGTHS.Last(), 8)),
                    ParameterValidator.VALID_TAG_LENGTHS
                }
            };

            return list.ToArray();
        }
        #endregion Parameter test scenarios

        [Test]
        public async Task ShouldContainGroupsForEachTestType()
        {
            Parameters p = new ParameterBuilder().Build();

            var result = await _subject.BuildTestGroupsAsync(p);

            foreach (InternalTestTypes testType in Enum.GetValues(typeof(InternalTestTypes)))
            {
                Assert.IsTrue(result.Any(a => a.InternalTestType == testType.ToString()));
            }
        }

        /// <summary>
        /// DecryptionVerification creates test cases based on:
        /// 
        ///     - Each key size
        ///     - The minimum and maximum AAD length (not including 2^16 )       
        ///     - The minimum and maximum Payload length
        ///     - Each nonce length
        ///     - Each Tag length
        /// </summary>
        [Test]
        [TestCaseSource(nameof(GetTestParameterData))]
        public async Task ShouldHaveValidNumberOfGroupsForDecryptionVerification(
            string testLabel,
            int[] keyLen,
            MathDomain aadLen,
            MathDomain ptLen,
            MathDomain ivLen,
            int[] tagLen
        )
        {
            InternalTestTypes testType = InternalTestTypes.DecryptionVerification;

            Parameters p = new Parameters()
            {
                Algorithm = "AES CCM",
                KeyLen = keyLen,
                AadLen = aadLen,
                PayloadLen = ptLen,
                IvLen = ivLen,
                TagLen = tagLen
            };

            var result = await _subject.BuildTestGroupsAsync(p);

            // Only the min/max aadLen and ptLens go into the creation of the group
            int aadLenMultiplier = (_subject.AadLens.Min() == _subject.AadLens.Max()) ? 1 : 2;
            int ptLenMultiplier = (_subject.PtLens.Min() == _subject.PtLens.Max()) ? 1 : 2;

            int expectedResultCount = _subject.KeyLens.Length * aadLenMultiplier * ptLenMultiplier * _subject.NonceLens.Count() * _subject.TagLens.Count();

            Assert.AreEqual(expectedResultCount, result.Count(c => c.InternalTestType == testType.ToString()));
        }

        /// <summary>
        /// VariableAssocatedData creates test cases based on:
        /// 
        ///     - Each key size
        ///     - Each AAD length (including 2^16)
        ///     - The maximum Payload length
        ///     - The maximum nonce length
        ///     - The maximum tag length
        /// </summary>
        [Test]
        [TestCaseSource(nameof(GetTestParameterData))]
        public async Task ShouldHaveValidNumberOfGroupsForVariableAssociatedData(
            string testLabel,
            int[] keyLen,
            MathDomain aadLen,
            MathDomain ptLen,
            MathDomain ivLen,
            int[] tagLen
        )
        {
            InternalTestTypes testType = InternalTestTypes.VariableAssociatedData;

            Parameters p = new Parameters()
            {
                Algorithm = "AES CCM",
                KeyLen = keyLen,
                AadLen = aadLen,
                PayloadLen = ptLen,
                IvLen = ivLen,
                TagLen = tagLen
            };

            var result = await _subject.BuildTestGroupsAsync(p);

            // AAD is a range of values, add an additional group if SupportsAad2Pow16
            int aadLenRange = (_subject.AadLens.Max() - _subject.AadLens.Min()) / 8 + 1 +
                              (_subject.Supports2pow16bytes ? 1 : 0);

            // pt, tag, and nonce use the max value, will always be a multiplier of 1
            int expectedResultCount = keyLen.Length * aadLenRange * 1 * 1 * 1;

            Assert.AreEqual(expectedResultCount, result.Count(c => c.InternalTestType == testType.ToString()));
        }

        /// <summary>
        /// VariableNonce creates test cases based on:
        /// 
        ///     - Each key size
        ///     - The maximum AAD length (excluding 2^16)
        ///     - The maximum Payload length
        ///     - Each nonce length
        ///     - The maximum tag length
        /// 
        /// </summary>
        [Test]
        [TestCaseSource(nameof(GetTestParameterData))]
        public async Task ShouldHaveValidNumberOfGroupsForVariableNonce(
            string testLabel,
            int[] keyLen,
            MathDomain aadLen,
            MathDomain ptLen,
            MathDomain ivLen,
            int[] tagLen
        )
        {
            InternalTestTypes testType = InternalTestTypes.VariableNonce;

            Parameters p = new Parameters()
            {
                Algorithm = "AES CCM",
                KeyLen = keyLen,
                AadLen = aadLen,
                PayloadLen = ptLen,
                IvLen = ivLen,
                TagLen = tagLen
            };

            var result = await _subject.BuildTestGroupsAsync(p);

            // aad, pt, and tag use the max value, will always be a multiplier of 1
            int expectedResultCount = keyLen.Length * 1 * _subject.NonceLens.Count() * 1 * 1;

            Assert.AreEqual(expectedResultCount, result.Count(c => c.InternalTestType == testType.ToString()));
        }

        /// <summary>
        /// VariablePayload creates test cases based on:
        /// 
        ///     - Each key size
        ///     - The maximum AAD length (excluding 2^16)
        ///     - Each Payload length
        ///     - The maximum nonce length
        ///     - The maximum tag length
        /// 
        /// </summary>
        [Test]
        [TestCaseSource(nameof(GetTestParameterData))]
        public async Task ShouldHaveValidNumberOfGroupsForVariablePayload(
            string testLabel,
            int[] keyLen,
            MathDomain aadLen,
            MathDomain ptLen,
            MathDomain ivLen,
            int[] tagLen
        )
        {
            InternalTestTypes testType = InternalTestTypes.VariablePayload;

            Parameters p = new Parameters()
            {
                Algorithm = "AES CCM",
                KeyLen = keyLen,
                AadLen = aadLen,
                PayloadLen = ptLen,
                IvLen = ivLen,
                TagLen = tagLen
            };

            var result = await _subject.BuildTestGroupsAsync(p);

            // Payload is a range of values, add an additional group if SupportsAad2Pow16
            var payloadCount = (_subject.PtLens.Max() - _subject.PtLens.Min()) / 8 + 1;

            // aad, nonce, and tag use the max value, will always be a multiplier of 1
            int expectedResultCount = keyLen.Length * 1 * payloadCount * 1 * 1;

            Assert.AreEqual(expectedResultCount, result.Count(c => c.InternalTestType == testType.ToString()));
        }

        /// <summary>
        /// VariableTag creates test cases based on:
        /// 
        ///     - Each key size
        ///     - The maximum AAD length (excluding 2^16)
        ///     - The maximum Payload length
        ///     - The maximum nonce length
        ///     - Each tag length
        /// 
        /// </summary>
        [Test]
        [TestCaseSource(nameof(GetTestParameterData))]
        public async Task ShouldHaveValidNumberOfGroupsForVariableTag(
            string testLabel,
            int[] keyLen,
            MathDomain aadLen,
            MathDomain ptLen,
            MathDomain ivLen,
            int[] tagLen
        )
        {
            InternalTestTypes testType = InternalTestTypes.VariableTag;

            Parameters p = new Parameters()
            {
                Algorithm = "AES CCM",
                KeyLen = keyLen,
                AadLen = aadLen,
                PayloadLen = ptLen,
                IvLen = ivLen,
                TagLen = tagLen
            };

            var result = await _subject.BuildTestGroupsAsync(p);

            // aad, pt, and nonce use the max value, will always be a multiplier of 1
            int expectedResultCount = keyLen.Length * 1 * 1 * 1 * _subject.TagLens.Length;

            Assert.AreEqual(expectedResultCount, result.Count(c => c.InternalTestType == testType.ToString()));
        }

        [Test]
        [TestCase(InternalTestTypes.DecryptionVerification, true, false)]
        [TestCase(InternalTestTypes.VariableAssociatedData, true, true)]
        [TestCase(InternalTestTypes.VariableNonce, true, false)]
        [TestCase(InternalTestTypes.VariablePayload, true, true)]
        [TestCase(InternalTestTypes.VariableTag, true, true)]
        public async Task ShouldUseSharedParameterInGroup(InternalTestTypes testType, bool useSharedKey, bool useSharedNonce)
        {
            Parameters p = new ParameterBuilder().Build();

            var result = await _subject.BuildTestGroupsAsync(p);

            var typeTests = result.Where(w => w.InternalTestType == testType.ToString()).Select(s => s);
            var correctShares =
                typeTests.All(
                    a =>
                        a.GroupReusesKeyForTestCases == useSharedKey &&
                        a.GroupReusesNonceForTestCases == useSharedNonce);

            Assert.IsTrue(correctShares);
        }
    }
}
