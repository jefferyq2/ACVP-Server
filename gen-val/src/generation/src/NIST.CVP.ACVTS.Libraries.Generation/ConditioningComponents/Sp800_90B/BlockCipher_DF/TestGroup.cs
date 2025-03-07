﻿using System.Collections.Generic;
using Newtonsoft.Json;
using NIST.CVP.ACVTS.Libraries.Generation.Core;
using NIST.CVP.ACVTS.Libraries.Math.Domain;

namespace NIST.CVP.ACVTS.Libraries.Generation.ConditioningComponents.Sp800_90B.BlockCipher_DF
{
    public class TestGroup : ITestGroup<TestGroup, TestCase>
    {
        public int TestGroupId { get; set; }
        public string TestType { get; set; }
        
        [JsonProperty(PropertyName = "keyLen")]
        public int KeyLength { get; set; }

        [JsonIgnore]
        public MathDomain PayloadLen { get; set; }
        
        public int OutputLen { get; set; }
        
        public List<TestCase> Tests { get; set; } = new List<TestCase>();
    }
}
