﻿using System.Numerics;

namespace NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.RSA.Signatures
{
    public class SignatureResult
    {
        public BigInteger Signature { get; }
        public string ErrorMessage { get; }

        public bool Success => string.IsNullOrEmpty(ErrorMessage);

        public SignatureResult(BigInteger signature)
        {
            Signature = signature;
        }

        public SignatureResult(string error)
        {
            ErrorMessage = error;
        }
    }
}
