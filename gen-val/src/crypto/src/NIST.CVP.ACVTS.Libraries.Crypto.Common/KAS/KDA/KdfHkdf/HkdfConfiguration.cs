﻿using NIST.CVP.ACVTS.Libraries.Crypto.Common.Hash.ShaWrapper.Enums;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.KAS.Enums;

namespace NIST.CVP.ACVTS.Libraries.Crypto.Common.KAS.KDA.KdfHkdf
{
    public class HkdfConfiguration : IKdfConfiguration
    {
        public Kda KdfType => Kda.Hkdf;
        public bool RequiresAdditionalNoncePair => false;
        public int L { get; set; }
        public int SaltLen { get; set; }
        public MacSaltMethod SaltMethod { get; set; }
        public string FixedInfoPattern { get; set; }
        public FixedInfoEncoding FixedInfoEncoding { get; set; }
        public HashFunctions HmacAlg { get; set; }
        public IKdfParameter GetKdfParameter(IKdfParameterVisitor visitor)
        {
            return visitor.CreateParameter(this);
        }
    }
}
