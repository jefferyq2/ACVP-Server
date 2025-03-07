﻿using NIST.CVP.ACVTS.Libraries.Generation.Core.DeSerialization;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Enums;
using NIST.CVP.ACVTS.Libraries.Generation.Core.JsonConverters;
using NIST.CVP.ACVTS.Libraries.Generation.ML_DSA.FIPS204.SigVer;
using NIST.CVP.ACVTS.Libraries.Generation.ML_DSA.FIPS204.SigVer.ContractResolvers;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.ML_DSA.FIPS204.SigVer;

[TestFixture, UnitTest, FastIntegrationTest]
public class ResultsProjectionContractResolverTests
{
    private readonly JsonConverterProvider _jsonConverterProvider = new();
    private readonly ContractResolverFactory _contractResolverFactory = new();
    private readonly Projection _projection = Projection.Result;

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

        Assert.AreNotEqual(tg.ParameterSet, newTg.ParameterSet, nameof(newTg.ParameterSet));
        Assert.AreNotEqual(tg.PublicKey, newTg.PublicKey, nameof(newTg.PublicKey));
        Assert.AreNotEqual(tg.PrivateKey, newTg.PrivateKey, nameof(newTg.PrivateKey));
    }
    
    [Test]
    public void ShouldSerializeCaseProperties()
    {
        var tvs = TestDataMother.GetTestGroups(2);
        var tg = tvs.TestGroups[0];
        var tc = tg.Tests[0];

        var json = _serializer.Serialize(tvs, _projection);
        var newTvs = _deserializer.Deserialize(json);

        var newTg = newTvs.TestGroups[0];
        var newTc = newTg.Tests[0];

        Assert.AreEqual(tc.ParentGroup.TestGroupId, newTc.ParentGroup.TestGroupId, nameof(newTc.ParentGroup));
        Assert.AreEqual(tc.TestCaseId, newTc.TestCaseId, nameof(newTc.TestCaseId));
        Assert.AreEqual(tc.TestPassed, newTc.TestPassed, nameof(newTc.TestPassed));

        Assert.AreNotEqual(tc.Signature, newTc.Signature, nameof(newTc.Signature));
        Assert.AreNotEqual(tc.Message, newTc.Message, nameof(newTc.Message));
    }
}
