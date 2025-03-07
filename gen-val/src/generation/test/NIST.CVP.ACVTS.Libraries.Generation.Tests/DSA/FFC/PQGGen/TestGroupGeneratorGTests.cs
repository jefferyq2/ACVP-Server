﻿using System.Linq;
using System.Threading.Tasks;
using NIST.CVP.ACVTS.Libraries.Generation.DSA.v1_0.PqgGen;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.DSA.FFC.PQGGen
{
    [TestFixture, UnitTest]
    public class TestGroupGeneratorGTests
    {
        private static object[] parameters =
        {
            new object[]
            {
                1,
                new ParameterBuilder()
                    .WithCapabilities(new []
                        {
                            ParameterBuilder.GetCapabilityWith(2048, 224, new[] {"probable" }, new[] {"unverifiable" }, new[] {"sha2-256"})
                        })
                    .Build()
            },
            new object[]
            {
                4,
                new ParameterBuilder()
                    .WithCapabilities(new []
                        {
                            ParameterBuilder.GetCapabilityWith(2048, 224, new[] {"probable"}, new[] {"unverifiable"}, new[] {"sha2-256", "sha2-512"}),
                            ParameterBuilder.GetCapabilityWith(2048, 256, new[] {"provable"}, new[] {"unverifiable"}, new[] {"sha2-256", "sha2-384"})
                        })
                    .Build()
            },
            new object[]
            {
                10,
                new ParameterBuilder()
                    .WithCapabilities(new []
                        {
                            ParameterBuilder.GetCapabilityWith(2048, 224, new[] {"probable"}, new[] {"unverifiable"}, new[] {"sha2-256", "sha2-512"}),
                            ParameterBuilder.GetCapabilityWith(3072, 256, new[] {"provable"}, new[] {"unverifiable", "canonical"}, new[] {"sha2-256", "sha2-384", "sha2-512", "sha2-512/256"})
                        })
                    .Build()
            },
            new object[]
            {
                2 * 6 + 2 * 4 + 2 * 4,
                new ParameterBuilder()
                    .WithCapabilities(new []
                        {
                            ParameterBuilder.GetCapabilityWith(2048, 224, new[] {"probable"}, new[] {"unverifiable", "canonical"}, new[] {"sha2-224", "sha2-256", "sha2-384", "sha2-512", "sha2-512/224", "sha2-512/256"}),
                            ParameterBuilder.GetCapabilityWith(2048, 256, new[] {"probable", "provable"}, new[] {"unverifiable", "canonical"}, new[] {"sha2-256", "sha2-384", "sha2-512", "sha2-512/256"}),
                            ParameterBuilder.GetCapabilityWith(3072, 256, new[] {"probable", "provable"}, new[] {"unverifiable", "canonical"}, new[] {"sha2-256", "sha2-384", "sha2-512", "sha2-512/256"})
                        })
                    .Build()
            }
        };

        [Test]
        [TestCaseSource(nameof(parameters))]
        public async Task ShouldCreate1TestGroupForEachCombinationOfModeLNAndHashAlg(int expectedGroups, Parameters parameters)
        {
            var subject = new TestGroupGeneratorG();
            var result = await subject.BuildTestGroupsAsync(parameters);
            Assert.AreEqual(expectedGroups, result.Count());
        }
    }
}
