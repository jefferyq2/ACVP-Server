﻿using System;
using System.Linq;
using System.Threading.Tasks;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Symmetric.Enums;
using NIST.CVP.ACVTS.Libraries.Generation.Core;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Async;
using NIST.CVP.ACVTS.Libraries.Math;
using NIST.CVP.ACVTS.Libraries.Math.Domain;
using NIST.CVP.ACVTS.Libraries.Oracle.Abstractions;
using NIST.CVP.ACVTS.Libraries.Oracle.Abstractions.ParameterTypes;
using NLog;

namespace NIST.CVP.ACVTS.Libraries.Generation.ConditioningComponents.Sp800_90B.CBC_MAC
{
    public class TestCaseGenerator : ITestCaseGeneratorWithPrep<TestGroup, TestCase>
    {
        public int NumberOfTestCasesToGenerate { get; private set; } = 100;

        private ShuffleQueue<int> _payloadLengths;
        private readonly IOracle _oracle;

        private static readonly ILogger ThisLogger = LogManager.GetCurrentClassLogger();

        public TestCaseGenerator(IOracle oracle)
        {
            _oracle = oracle;
        }

        public GenerateResponse PrepareGenerator(TestGroup @group, bool isSample)
        {
            if (isSample)
            {
                NumberOfTestCasesToGenerate = 5;
            }

            var payloadLength = group.PayloadLength.GetDeepCopy();
            
            var min = payloadLength.GetDomainMinMax().Minimum;
            var max = payloadLength.GetDomainMinMax().Maximum;

            var minMax = payloadLength.GetDomainMinMaxAsEnumerable();
            var lengths = payloadLength.GetRandomValues(x => x != min && x != max, NumberOfTestCasesToGenerate - 2).ToList();
            lengths.AddRange(minMax);

            _payloadLengths = new ShuffleQueue<int>(lengths, NumberOfTestCasesToGenerate);

            return new GenerateResponse();
        }

        public async Task<TestCaseGenerateResponse<TestGroup, TestCase>> GenerateAsync(TestGroup group, bool isSample, int caseNo = -1)
        {
            var param = new AesParameters
            {
                DataLength = _payloadLengths.Pop(),
                Direction = "encrypt",
                KeyLength = group.KeyLength,
                Mode = BlockCipherModesOfOperation.CbcMac,
                Key = group.Key ??= group.Key
            };

            try
            {
                var oracleResult = await _oracle.GetAesCaseAsync(param);

                return new TestCaseGenerateResponse<TestGroup, TestCase>(new TestCase
                {
                    Key = oracleResult.Key,
                    PlainText = oracleResult.PlainText,
                    CipherText = oracleResult.CipherText
                    // Important DO NOT STORE IV, the IV that is generated by Oracle is ignored by CBC-MAC crypto which requires an empty IV
                });
            }
            catch (Exception ex)
            {
                ThisLogger.Error(ex);
                return new TestCaseGenerateResponse<TestGroup, TestCase>($"Failed to generate. {ex.Message}");
            }
        }
    }
}
