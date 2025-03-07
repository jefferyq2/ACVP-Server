﻿using System;
using System.Collections.Generic;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Symmetric;
using NIST.CVP.ACVTS.Libraries.Generation.AES_OFB.v1_0;
using NIST.CVP.ACVTS.Libraries.Math;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.AES.OFB
{
    public static class TestDataMother
    {
        public static TestVectorSet GetTestGroups(int groups = 1, string direction = "encrypt", string testType = "aft")
        {
            var tvs = new TestVectorSet()
            {
                Algorithm = "AES",
                IsSample = true,
                Mode = "OFB"
            };

            var testGroups = new List<TestGroup>();
            tvs.TestGroups = testGroups;
            for (int groupIdx = 0; groupIdx < groups; groupIdx++)
            {
                var tg = new TestGroup
                {
                    Function = direction,
                    KeyLength = 256 + groupIdx * 2,
                    TestType = testType
                };
                testGroups.Add(tg);

                var tests = new List<TestCase>();
                tg.Tests = tests;
                for (int testId = 15 * groupIdx + 1; testId <= (groupIdx + 1) * 15; testId++)
                {
                    var tc = new TestCase
                    {
                        ParentGroup = tg,
                        PlainText = new BitString("1AAADFFF"),
                        Deferred = true,
                        CipherText = new BitString("7EADDC"),
                        Key = new BitString("9998ADCD"),
                        IV = new BitString("CAFECAFE"),
                        TestCaseId = testId
                    };
                    tests.Add(tc);

                    if (testType.Equals("mct", StringComparison.OrdinalIgnoreCase))
                    {
                        tc.ResultsArray = new List<AlgoArrayResponse>()
                        {
                            new AlgoArrayResponse()
                            {
                                PlainText = new BitString("FF1AAADFFF"),
                                CipherText = new BitString("FF7EADDC"),
                                Key = new BitString("FF9998ADCD"),
                                IV = new BitString("FFCAFECAFE"),
                            }
                        };
                    }
                }
            }

            return tvs;
        }
    }
}
