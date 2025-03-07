﻿using System.Collections.Generic;
using Newtonsoft.Json;
using NIST.CVP.ACVTS.Libraries.Generation.Core;
using NIST.CVP.ACVTS.Libraries.Math.Domain;

namespace NIST.CVP.ACVTS.Libraries.Generation.SHA3.v1_0
{
    public class Parameters : IParameters
    {
        public int VectorSetId { get; set; }
        public string Algorithm { get; set; }
        public string Mode { get; set; }
        public string Revision { get; set; }
        public bool IsSample { get; set; }
        public string[] Conformances { get; set; } = { };

        // Was "digestSizes" but client only will send one at a time
        [JsonProperty(PropertyName = "digestSize")]
        public List<int> DigestSizes { get; set; }

        [JsonProperty(PropertyName = "inBit")]
        public bool BitOrientedInput { get; set; } = false;

        [JsonProperty(PropertyName = "outBit")]
        public bool BitOrientedOutput { get; set; } = false;

        [JsonProperty(PropertyName = "inEmpty")]
        public bool IncludeNull { get; set; } = false;

        // Hard assumption that this is just a single RangeSegment inside of a Domain
        [JsonProperty(PropertyName = "outputLen")]
        public MathDomain OutputLength { get; set; }

        [JsonProperty(PropertyName = "performLargeDataTest")]
        public int[] PerformLargeDataTest { get; set; } = { };
    }
}
