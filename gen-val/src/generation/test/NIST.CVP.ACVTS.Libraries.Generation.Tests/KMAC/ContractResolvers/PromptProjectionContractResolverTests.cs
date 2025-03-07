﻿using System.Text.RegularExpressions;
using NIST.CVP.ACVTS.Libraries.Generation.Core.DeSerialization;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Enums;
using NIST.CVP.ACVTS.Libraries.Generation.Core.JsonConverters;
using NIST.CVP.ACVTS.Libraries.Generation.KMAC.v1_0;
using NIST.CVP.ACVTS.Libraries.Generation.KMAC.v1_0.ContractResolvers;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.KMAC.ContractResolvers
{
    [TestFixture, UnitTest, FastIntegrationTest]
    public class PromptProjectionContractResolverTests
    {
        private readonly JsonConverterProvider _jsonConverterProvider = new JsonConverterProvider();
        private readonly ContractResolverFactory _contractResolverFactory = new ContractResolverFactory();
        private readonly Projection _projection = Projection.Prompt;

        private VectorSetSerializer<TestVectorSet, TestGroup, TestCase> _serializer;
        private VectorSetDeserializer<TestVectorSet, TestGroup, TestCase> _deserializer;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _serializer =
                new VectorSetSerializer<TestVectorSet, TestGroup, TestCase>(
                    _jsonConverterProvider,
                    _contractResolverFactory
                );
            _deserializer =
                new VectorSetDeserializer<TestVectorSet, TestGroup, TestCase>(
                    _jsonConverterProvider
                );
        }

        [Test]
        public void ShouldSerializeGroupProperties()
        {
            var tvs = TestDataMother.GetTestGroups();
            var tg = tvs.TestGroups[0];

            var json = _serializer.Serialize(tvs, _projection);
            var newTvs = _deserializer.Deserialize(json);

            var newTg = newTvs.TestGroups[0];

            Assert.AreEqual(tg.TestGroupId, newTg.TestGroupId, nameof(newTg.TestGroupId));
            Assert.AreEqual(tg.Tests.Count, newTg.Tests.Count, nameof(newTg.Tests));
            Assert.AreEqual(tg.TestType, newTg.TestType, nameof(newTg.TestType));
            Assert.AreEqual(tg.XOF, newTg.XOF, nameof(newTg.XOF));
            Assert.AreEqual(tg.HexCustomization, newTg.HexCustomization, nameof(newTg.HexCustomization));
        }

        [Test]
        [TestCase("aft", true)]
        [TestCase("aft", false)]
        [TestCase("mvt", true)]
        [TestCase("mvt", false)]
        public void ShouldSerializeCaseProperties(string testType, bool hexCustomization)
        {
            var tvs = TestDataMother.GetTestGroups();
            var tg = tvs.TestGroups[0];
            tg.TestType = testType;
            tg.HexCustomization = hexCustomization;
            var tc = tg.Tests[0];

            var json = _serializer.Serialize(tvs, _projection);
            var newTvs = _deserializer.Deserialize(json);

            var newTg = newTvs.TestGroups[0];
            var newTc = newTg.Tests[0];

            Assert.AreEqual(tc.ParentGroup.TestGroupId, newTc.ParentGroup.TestGroupId, nameof(newTc.ParentGroup));
            Assert.AreEqual(tc.TestCaseId, newTc.TestCaseId, nameof(newTc.TestCaseId));
            Assert.AreEqual(tc.Key, newTc.Key, nameof(newTc.Key));
            Assert.AreEqual(tc.KeyLength, newTc.KeyLength, nameof(newTc.KeyLength));
            Assert.AreEqual(tc.Message, newTc.Message, nameof(newTc.Message));
            Assert.AreEqual(tc.MessageLength, newTc.MessageLength, nameof(newTc.MessageLength));
            Assert.AreEqual(tc.MacLength, newTc.MacLength, nameof(newTc.MacLength));

            if (testType == "mvt")
            {
                Assert.AreEqual(tc.Mac, newTc.Mac, nameof(newTc.Mac));
            }
            else
            {
                Assert.AreNotEqual(tc.Mac, newTc.Mac, nameof(newTc.Mac));
            }

            if (hexCustomization)
            {
                Assert.AreNotEqual(tc.Customization, newTc.Customization, nameof(newTc.Customization));
                Assert.AreEqual(tc.CustomizationHex, newTc.CustomizationHex, nameof(newTc.CustomizationHex));
            }
            else
            {
                Assert.AreEqual(tc.Customization, newTc.Customization, nameof(newTc.Customization));
                Assert.AreNotEqual(tc.CustomizationHex, newTc.CustomizationHex, nameof(newTc.CustomizationHex));
            }

            Regex regexDeferred = new Regex(nameof(TestCase.Deferred), RegexOptions.IgnoreCase);
            Assert.IsTrue(regexDeferred.Matches(json).Count == 0);

            // TestPassed will have the default value when re-hydrated, check to make sure it isn't in the JSON
            Regex regexTestPassed = new Regex(nameof(TestCase.TestPassed), RegexOptions.IgnoreCase);
            Assert.IsTrue(regexTestPassed.Matches(json).Count == 0);
        }
    }
}
