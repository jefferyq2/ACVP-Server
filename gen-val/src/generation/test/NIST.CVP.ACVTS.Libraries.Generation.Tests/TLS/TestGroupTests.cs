﻿using System;
using NIST.CVP.ACVTS.Libraries.Generation.KDF_Components.v1_0.TLS.v1_0;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Generation.Tests.TLS
{
    [TestFixture, UnitTest]
    public class TestGroupTests
    {
        [Test]
        [TestCase("Fredo")]
        [TestCase("")]
        [TestCase("NULL")]
        [TestCase(null)]
        public void ShouldReturnFalseIfUnknownSetStringName(string name)
        {
            var subject = new TestGroup();
            var result = subject.SetString(name, "1");
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseIfPassObjectCannotCast()
        {
            var subject = new TestGroup();
            var result = subject.Equals(null);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("hashAlg")]
        [TestCase("HASHALG")]
        public void ShouldSetHashAlg(string name)
        {
            const string shaValue = "sha2-256";

            var subject = new TestGroup();

            var result = subject.SetString(name, shaValue);
            Assert.IsTrue(result, nameof(result));
            Assert.IsTrue(shaValue.Equals(subject.HashAlg.Name, StringComparison.OrdinalIgnoreCase), nameof(subject.HashAlg.Name));
        }
    }
}
