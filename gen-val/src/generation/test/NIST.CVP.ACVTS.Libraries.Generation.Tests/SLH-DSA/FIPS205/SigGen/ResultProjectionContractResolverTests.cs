using System.Text.RegularExpressions;
using NIST.CVP.ACVTS.Libraries.Generation.Core.DeSerialization;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Enums;
using NIST.CVP.ACVTS.Libraries.Generation.Core.JsonConverters;
using NIST.CVP.ACVTS.Libraries.Generation.SLH_DSA.FIPS205.SigGen;
using NIST.CVP.ACVTS.Libraries.Generation.SLH_DSA.FIPS205.SigGen.ContractResolvers;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.SLH_DSA.FIPS205.SigGen;

[TestFixture, UnitTest]
public class ResultProjectionContractResolverTests
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

        // Response properties
        Assert.AreEqual(tg.TestGroupId, newTg.TestGroupId, nameof(newTg.TestGroupId));
        Assert.AreEqual(tg.Tests.Count, newTg.Tests.Count, nameof(newTg.Tests));

        // Prompt properties
        Assert.AreNotEqual(tg.TestType, newTg.TestType, nameof(newTg.TestType));
        Assert.AreNotEqual(tg.ParameterSet, newTg.ParameterSet, nameof(newTg.ParameterSet));
        Assert.AreNotEqual(tg.Deterministic, newTg.Deterministic, nameof(newTg.Deterministic));
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
        
        // Response properties
        Assert.AreEqual(tc.TestCaseId, newTc.TestCaseId, nameof(newTc.TestCaseId));
        Assert.AreEqual(tc.Signature, newTc.Signature, nameof(newTc.Signature));
        
        // Prompt properties
        Assert.AreNotEqual(tc.PrivateKey, newTc.PrivateKey, nameof(newTc.PrivateKey));
        Assert.AreNotEqual(tc.AdditionalRandomness, newTc.AdditionalRandomness, nameof(newTc.AdditionalRandomness));
        Assert.AreNotEqual(tc.MessageLength, newTc.MessageLength, nameof(newTc.MessageLength));
        Assert.AreNotEqual(tc.Message, newTc.Message, nameof(newTc.Message));
        
        // TestPassed will have the default value when re-hydrated, check to make sure it isn't in the JSON
        var regex = new Regex("testPassed", RegexOptions.IgnoreCase);
        Assert.IsTrue(regex.Matches(json).Count == 0);
    }
}
