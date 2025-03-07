﻿using NIST.CVP.ACVTS.Libraries.Generation.Core;

namespace NIST.CVP.ACVTS.Libraries.Generation.AES_CBC.v1_0
{
    public class Parameters : IParameters
    {
        public int VectorSetId { get; set; }
        public string Algorithm { get; set; }
        public string Mode { get; set; }
        public string Revision { get; set; } = "1.0";
        public bool IsSample { get; set; }
        public string[] Conformances { get; set; } = { };
        public string[] Direction { get; set; }
        public int[] KeyLen { get; set; }
    }
}
