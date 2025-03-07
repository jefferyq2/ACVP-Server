﻿using System.Collections.Generic;
using NIST.CVP.ACVTS.Libraries.Generation.AES_GCM_SIV.v1_0;
using NIST.CVP.ACVTS.Libraries.Math;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.AES.GCM_SIV
{
    public static class TestDataMother
    {
        public static TestVectorSet GetTestGroups(int groups, string direction, bool testPassed)
        {
            var testVectorSet = new TestVectorSet()
            {
                Algorithm = "AES",
                Mode = "GCM-SIV",
                IsSample = false
            };

            var testGroups = new List<TestGroup>();
            testVectorSet.TestGroups = testGroups;
            for (int groupIdx = 0; groupIdx < groups; groupIdx++)
            {
                var tg = new TestGroup
                {
                    AadLength = 16 + groupIdx * 2,
                    Function = direction,
                    KeyLength = 256 + groupIdx * 2,
                    PayloadLength = 256 + groupIdx * 2,
                    TestType = "AFT"
                };
                testGroups.Add(tg);

                var tests = new List<TestCase>();
                tg.Tests = tests;
                for (int testId = 15 * groupIdx + 1; testId <= (groupIdx + 1) * 15; testId++)
                {
                    var tc = new TestCase
                    {
                        IV = new BitString("00FF00FF"),
                        AAD = new BitString("0AAD"),
                        Plaintext = new BitString("1AAADFFF"),
                        TestPassed = testPassed,
                        Ciphertext = new BitString("7EADDC"),
                        Key = new BitString("9998ADCD"),
                        TestCaseId = testId,
                        ParentGroup = tg
                    };
                    tests.Add(tc);
                }
            }
            return testVectorSet;
        }
    }
}
