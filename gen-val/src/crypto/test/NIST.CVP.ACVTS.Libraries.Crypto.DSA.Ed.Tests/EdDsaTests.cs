﻿using NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.DSA.Ed;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.DSA.Ed.Enums;
using NIST.CVP.ACVTS.Libraries.Crypto.SHA.NativeFastSha;
using NIST.CVP.ACVTS.Libraries.Math;
using NIST.CVP.ACVTS.Libraries.Math.Entropy;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Crypto.DSA.Ed.Tests
{
    [TestFixture, LongCryptoTest]
    public class EdDsaTests
    {
        [Test]
        #region KeyPairGen-25519
        [TestCase(Curve.Ed25519,
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60",
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a",
            TestName = "KeyGen 25519 - 1")]
        [TestCase(Curve.Ed25519,
            "4ccd089b28ff96da9db6c346ec114e0f5b8a319f35aba624da8cf6ed4fb8a6fb",
            "3d4017c3e843895a92b70aa74d1b7ebc9c982ccf2ec4968cc0cd55f12af4660c",
            TestName = "KeyGen 25519 - 2")]
        [TestCase(Curve.Ed25519,
            "c5aa8df43f9f837bedb7442f31dcb7b166d38535076f094b85ce3a2e0b4458f7",
            "fc51cd8e6218a1a38da47ed00230f0580816ed13ba3303ac5deb911548908025",
            TestName = "KeyGen 25519 - 3")]
        [TestCase(Curve.Ed25519,
            "f5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5",
            "278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e",
            TestName = "KeyGen 25519 - 4")]
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            TestName = "KeyGen 25519 - 5")]
        #endregion KeyPairGen-25519
        #region KeyPairGen-448
        [TestCase(Curve.Ed448,
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b",
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180",
            TestName = "KeyGen 448 - 1")]
        [TestCase(Curve.Ed448,
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463afbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e",
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480",
            TestName = "KeyGen 448 - 2")]
        [TestCase(Curve.Ed448,
            "cd23d24f714274e744343237b93290f511f6425f98e64459ff203e8985083ffdf60500553abc0e05cd02184bdb89c4ccd67e187951267eb328",
            "dcea9e78f35a1bf3499a831b10b86c90aac01cd84b67a0109b55a36e9328b1e365fce161d71ce7131a543ea4cb5f7e9f1d8b00696447001400",
            TestName = "KeyGen 448 - 3")]
        [TestCase(Curve.Ed448,
            "258cdd4ada32ed9c9ff54e63756ae582fb8fab2ac721f2c8e676a72768513d939f63dddb55609133f29adf86ec9929dccb52c1c5fd2ff7e21b",
            "3ba16da0c6f2cc1f30187740756f5e798d6bc5fc015d7c63cc9510ee3fd44adc24d8e968b6e46e6f94d19b945361726bd75e149ef09817f580",
            TestName = "KeyGen 448 - 4")]
        [TestCase(Curve.Ed448,
            "7ef4e84544236752fbb56b8f31a23a10e42814f5f55ca037cdcc11c64c9a3b2949c1bb60700314611732a6c2fea98eebc0266a11a93970100e",
            "b3da079b0aa493a5772029f0467baebee5a8112d9d3a22532361da294f7bb3815c5dc59e176b4d9f381ca0938e13c6c07b174be65dfa578e80",
            TestName = "KeyGen 448 - 5")]
        [TestCase(Curve.Ed448,
            "d65df341ad13e008567688baedda8e9dcdc17dc024974ea5b4227b6530e339bff21f99e68ca6968f3cca6dfe0fb9f4fab4fa135d5542ea3f01",
            "df9705f58edbab802c7f8363cfe5560ab1c6132c20a9f1dd163483a26f8ac53a39d6808bf4a1dfbd261b099bb03b3fb50906cb28bd8a081f00",
            TestName = "KeyGen 448 - 6")]
        [TestCase(Curve.Ed448,
            "2ec5fe3c17045abdb136a5e6a913e32ab75ae68b53d2fc149b77e504132d37569b7e766ba74a19bd6162343a21c8590aa9cebca9014c636df5",
            "79756f014dcfe2079f5dd9e718be4171e2ef2486a08f25186f6bff43a9936b9bfe12402b08ae65798a3d81e22e9ec80e7690862ef3d4ed3a00",
            TestName = "KeyGen 448 - 7")]
        [TestCase(Curve.Ed448,
            "872d093780f5d3730df7c212664b37b8a0f24f56810daa8382cd4fa3f77634ec44dc54f1c2ed9bea86fafb7632d8be199ea165f5ad55dd9ce8",
            "a81b2e8a70a5ac94ffdbcc9badfc3feb0801f258578bb114ad44ece1ec0e799da08effb81c5d685c0c56f64eecaef8cdf11cc38737838cf400",
            TestName = "KeyGen 448 - 8")]
        #endregion KeyPairGen-448
        public void ShouldGenerateKeyPairsCorrectly(Curve curveEnum, string dHex, string qHex)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var subject = new EdDsa(EntropyProviderTypes.Testable);
            subject.AddEntropy(d.ToPositiveBigInteger());

            var result = subject.GenerateKeyPair(domainParams);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.KeyPair.PrivateD, d, "d");
            Assert.AreEqual(q, result.KeyPair.PublicQ, "q");
        }

        // need more/ better data for this test
        [Test]
        #region KeyPairVer-25519
        [TestCase(Curve.Ed25519,
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60",
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a",
            true,
            TestName = "KeyVer 25519 Good Pair")]
        [TestCase(Curve.Ed25519,
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f61",
            "d75a980182b10ab7df4bfed3cf64073f0ee172f3daa62325af021a68f707511a",
            false,
            TestName = "KeyVer 25519 Bad Pair")]
        #endregion KeyPairVer-25519
        #region KeyPairVer-448
        [TestCase(Curve.Ed448,
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b",
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180",
            true,
            TestName = "KeyVer 448 Good Pair")]
        [TestCase(Curve.Ed448,
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b",
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783de1e50f6cd1fa1abeafe8256180",
            false,
            TestName = "KeyVer 448 Bad Pair")]
        [TestCase(Curve.Ed448,
            "018bdfa928dd25dbf2533e8f088a71d0d42e878c61edd12b81465c8e70638085067dcfc97739f5418c2bb28403f2127da6a9401cd252f1d05458",
            "fc35f437c8ffd3b1aac2da6be89a6fdb5a48def9bffefcaf900a4bbf39f4556fd60f97a33ceb37a37a11f4ba180974b04fa24283a62152f200",
            false,
            TestName = "KeyVer 448 Bad Pair - 2")]
        #endregion KeyPairVer-448
        public void ShouldValidateKeyPairsCorrectly(Curve curveEnum, string dHex, string qHex, bool expectedResult)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());
            var keyPair = new EdKeyPair(q, d);

            var subject = new EdDsa();

            var result = subject.ValidateKeyPair(domainParams, keyPair);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [Test]
        [TestCase(Curve.Ed25519,
            "0E29D4E9E8B66CC8EEA55859CFCD7013A0EEDECC85DE415D1929448F3A2FF14F",
            "411EBEF25A8B2F641071FEDD58506BD5BBC9EB82EAE836FCF728DA3514204FDC",
            false)]
        [TestCase(Curve.Ed25519,
            "93F9ED36E7309740482247317E31B623941A386E8F4846DCFC3F9EDBEBBE969C",
            "FCDF73F5E830FD92FA5F7D70345B60CCC66049EA915627D1B1957E1840E3A463",
            false)]
        [TestCase(Curve.Ed25519,
            "07427F466A55D0FC6B8D81E77BA8370D39DF46C4CFA7007F747D1BBA6FBA33A7",
            "14FED80D7ED1B36AC7B22E6D64C67A6E1CB3725DCB252707C92A399D444286F7",
            false)]
        [TestCase(Curve.Ed25519,
            "B53BD9E461B8ECBFEF10F447D046A9751075C4874EBBC8A5E3BBC6B92A591101",
            "BF51B02DE2DADC57A4AC0553A86A1DAA88226BF2BE9F20051F396DEC4F65456D",
            false)]

        [TestCase(Curve.Ed25519,
            "F9527A0185D468498DA94D9F7773AA21C618088F7E8591F252472F28E0D399FD",
            "30BAA342E9A1A28E9504FFBFDA9BFE3DF515B174E9BB640A6382362E8623C738",
            true)]
        [TestCase(Curve.Ed25519,
            "7E34DBB73116760A450D7ED21CB49A1BBF00C832E0C0923AB13B67F9C2BE0402",
            "9F5A1641EACEB4FB07C6184651AF018E75B7BC15A390A46FE2F3F2ABFD97FA72",
            true)]
        [TestCase(Curve.Ed448,
            "9BFE5F25C54134DBA5572670C1831AD8DCD5DCFF7B36D3D4D2253574C0E26F125D339CBA233B019F4B00B4DC660712293B614DE15171B337B9",
            "AF375DF3B99FBC5CDBB05B9000001B3C1D7E6FFE1C94C1286B2C08120109DA2D147AC08AC2FC9507E52EBD22214648F78F76CF99AF8EE0D180",
            true)]
        [TestCase(Curve.Ed25519,
            "441B1DBE723BA85CFB6059F254454632253E02A454C3E44DA821D94F7E3CDF19",
            "4621524DC7CA6631B639464F35F2856DADC25C9AA54E8BD028C5B72E0B419568",
            true)]
        [TestCase(Curve.Ed25519,
            "C55BD73F6257A653ED50EE0B0BF4E042C8DBBCB0D8BC1F5D42770726FA3D3001",
            "D96D1D3F3219EC354FCDD857EC2AFFA8DDBC9BDFC371C26E53409D8B21558987",
            true)]

        [TestCase(Curve.Ed448,
            "22B8F90C10F5358CB0DD8C5E30C2DADDA7E8127F2C050588D9A4845D9CDD84A67295DF19B8EB0F223130E3F31625F5E79197247FE6429502D3",
            "50EBD0B565E668F2A4D867E1FA2A8B8E58D67D2EBCC432A4C316EAAACF30993B2C313DD8F6CEC4F2F2AC598D90615A13E118B7AF0B7AEF6381",
            false)]
        [TestCase(Curve.Ed448,
            "AEE7C07A6CBC01B28C925645B961F5C244B6B4A6980A4125F417DC70EE52B47151A423D3C3FC052B6B493A017CDE774D69AEED9DD8C2A5D1BC",
            "4773111EDA8AE8C366AD542BB77D43CE12379834B9B778270A26628FA0E52F53093BDC403234AF8494B104D333D62A919032D871725F0BFB80",
            false)]
        [TestCase(Curve.Ed448,
            "5EEAA4FB3443DD413414D5CAF06B9AA88F9EABCE6A710C701EEF968114738D70E334930A605F4D5C9B4A58DB9D43794867A687CA1832B5F2F5",
            "1F9356B53F6B7FD6998E68201044E5074662ECCB42FFE416589B62810FF6339698F53EC62FB798A41F756862E699F87D890A35AD602D4CED80",
            false)]
        [TestCase(Curve.Ed448,
            "AA23F275BB2EDD5408A13CBE3F62096ED4FF55C0538F90ED7B52891134D807B45D98E479141077B7A880927A23DF7829697EEF7DFF24198F9D",
            "800B25E84F43CA460A739FC877AAEB6234B29D17B1BA9C8ACFAA6A6BE8EE367FE17E649812547BE9F15A8B94E146DC5E3BD6A62323863B4780",
            false)]

        [TestCase(Curve.Ed448,
            "179045814927F84CBBC9002D22110C9FCC47D9A880F997FC53B9EEBA8BAF1686668B9B65A68C071E2D57223E91DE970DB034181728A40BB2F7",
            "B3B9D20E22071AA3FF3A77CF374246B6C47BD7E8DDFC6FE3CD61D33623DB7DD8BB72D9F294C276000216DE2C8EFDC1797AF48F4E6DA32A0700",
            true)]
        [TestCase(Curve.Ed448,
            "3BE24D296D8D472C1D023FB70B1F683258A4973EA1223E219C716455EA46175F0EF4A1A4CC68C7111F840A2A86278BBA19853B193436F4DC87",
            "4BB57E451B493323BED1CB6BF6FD6C754A906B651501CC4E5922707F2F3458353E8F67BF7C68383EB13F651175138321C6D81DBC5C3E787C00",
            true)]
        public void ShouldValidateKeyPairsCorrectlyWithNewMangleLogic(Curve curveEnum, string dHex, string qHex, bool expectedResult)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());
            var keyPair = new EdKeyPair(q, d);

            var subject = new EdDsa();

            var result = subject.ValidateKeyPair(domainParams, keyPair);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [Test]
        public void GeneratePublicKeyFromPrivateWithSomeManipulationEnsureNoLongerValidKeyPair()
        {
            var privateKey = new BitString("4C089A9597865D316B5163A01F85458A0B954CD542B9B2D83E39CB3CBA010441");
            var expectedPublic = new BitString("EBB9897DF6C5E4E42999578ECA0F48B0985FF99032E80244C4679032F1132A24");

            // Gen public key from private
            var subject = new EdDsa(EntropyProviderTypes.Testable);
            subject.AddEntropy(privateKey.ToPositiveBigInteger());

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(Curve.Ed25519);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var keyPair = subject.GenerateKeyPair(domainParams).KeyPair;

            Assert.AreEqual(expectedPublic, keyPair.PublicQ, "expected public key");
            // Check x/y, record
            var x = new BitString("172B32732D86C9D9D63B11957AAD1364E9D3C1EC258CD13AB012E10648942C4E")
                .ToPositiveBigInteger();
            var y = new BitString("242A13F1329067C44402E83290F95F98B0480FCA8E579929E4E4C5F67D89B9EB")
                .ToPositiveBigInteger();

            // encode public key (done by default, and represented in Q
            // decode public key
            var decoded = domainParams.CurveE.Decode(keyPair.PublicQ);

            // check that the decoded x/y match the previous prior to encode/decode
            Assert.AreEqual(x, decoded.X, "x decoded matches");
            Assert.AreEqual(y, decoded.Y, "y decoded matches");

            Assert.IsTrue(subject.ValidateKeyPair(domainParams, keyPair).Success, "original key pair should be valid");

            // Modify the public key value until the point is no longer on the curve
            var modifiedPublicQ = curve.Decode(keyPair.PublicQ);

            var addedX = modifiedPublicQ.X;
            var addedY = modifiedPublicQ.Y;
            var adds = 0;

            do
            {
                modifiedPublicQ = new EdPoint(modifiedPublicQ.X, modifiedPublicQ.Y + 8);
                addedX = modifiedPublicQ.X + 41;
                addedY = modifiedPublicQ.Y + 23;
                keyPair = new EdKeyPair(curve.Encode(modifiedPublicQ), keyPair.PrivateD.GetDeepCopy());
                adds++;
            } while (subject.ValidateKeyPair(domainParams, keyPair).Success);

            Assert.IsFalse(curve.PointExistsOnCurve(modifiedPublicQ), "check point not on curve prior to encode");
            Assert.IsFalse(subject.ValidateKeyPair(domainParams, keyPair).Success, "keypair should not be valid.");
        }

        [Test]
        #region SigGen-25519
        [TestCase(Curve.Ed25519,
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60",
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a",
            "",
            "e5564300c360ac729086e2cc806e828a84877f1eb8e5d974d873e065224901555fb8821590a33bacc61e39701cf9b46bd25bf5f0595bbe24655141438e7a100b",
            TestName = "SigGen 25519 - 1")]
        [TestCase(Curve.Ed25519,
            "4ccd089b28ff96da9db6c346ec114e0f5b8a319f35aba624da8cf6ed4fb8a6fb",
            "3d4017c3e843895a92b70aa74d1b7ebc9c982ccf2ec4968cc0cd55f12af4660c",
            "72",
            "92a009a9f0d4cab8720e820b5f642540a2b27b5416503f8fb3762223ebdb69da085ac1e43e15996e458f3613d0f11d8c387b2eaeb4302aeeb00d291612bb0c00",
            TestName = "SigGen 25519 - 2")]
        [TestCase(Curve.Ed25519,
            "c5aa8df43f9f837bedb7442f31dcb7b166d38535076f094b85ce3a2e0b4458f7",
            "fc51cd8e6218a1a38da47ed00230f0580816ed13ba3303ac5deb911548908025",
            "af82",
            "6291d657deec24024827e69c3abe01a30ce548a284743a445e3680d7db5ac3ac18ff9b538d16f290ae67f760984dc6594a7c15e9716ed28dc027beceea1ec40a",
            TestName = "SigGen 25519 - 3")]
        [TestCase(Curve.Ed25519,
            "f5e5767cf153319517630f226876b86c8160cc583bc013744c6bf255f5cc0ee5",
            "278117fc144c72340f67d0f2316e8386ceffbf2b2428c9c51fef7c597f1d426e",
            "08b8b2b733424243760fe426a4b54908632110a66c2f6591eabd3345e3e4eb98fa6e264bf09efe12ee50f8f54e9f77b1e355f6c50544e23fb1433ddf73be84d879de7c0046dc4996d9e773f4bc9efe5738829adb26c81b37c93a1b270b20329d658675fc6ea534e0810a4432826bf58c941efb65d57a338bbd2e26640f89ffbc1a858efcb8550ee3a5e1998bd177e93a7363c344fe6b199ee5d02e82d522c4feba15452f80288a821a579116ec6dad2b3b310da903401aa62100ab5d1a36553e06203b33890cc9b832f79ef80560ccb9a39ce767967ed628c6ad573cb116dbefefd75499da96bd68a8a97b928a8bbc103b6621fcde2beca1231d206be6cd9ec7aff6f6c94fcd7204ed3455c68c83f4a41da4af2b74ef5c53f1d8ac70bdcb7ed185ce81bd84359d44254d95629e9855a94a7c1958d1f8ada5d0532ed8a5aa3fb2d17ba70eb6248e594e1a2297acbbb39d502f1a8c6eb6f1ce22b3de1a1f40cc24554119a831a9aad6079cad88425de6bde1a9187ebb6092cf67bf2b13fd65f27088d78b7e883c8759d2c4f5c65adb7553878ad575f9fad878e80a0c9ba63bcbcc2732e69485bbc9c90bfbd62481d9089beccf80cfe2df16a2cf65bd92dd597b0707e0917af48bbb75fed413d238f5555a7a569d80c3414a8d0859dc65a46128bab27af87a71314f318c782b23ebfe808b82b0ce26401d2e22f04d83d1255dc51addd3b75a2b1ae0784504df543af8969be3ea7082ff7fc9888c144da2af58429ec96031dbcad3dad9af0dcbaaaf268cb8fcffead94f3c7ca495e056a9b47acdb751fb73e666c6c655ade8297297d07ad1ba5e43f1bca32301651339e22904cc8c42f58c30c04aafdb038dda0847dd988dcda6f3bfd15c4b4c4525004aa06eeff8ca61783aacec57fb3d1f92b0fe2fd1a85f6724517b65e614ad6808d6f6ee34dff7310fdc82aebfd904b01e1dc54b2927094b2db68d6f903b68401adebf5a7e08d78ff4ef5d63653a65040cf9bfd4aca7984a74d37145986780fc0b16ac451649de6188a7dbdf191f64b5fc5e2ab47b57f7f7276cd419c17a3ca8e1b939ae49e488acba6b965610b5480109c8b17b80e1b7b750dfc7598d5d5011fd2dcc5600a32ef5b52a1ecc820e308aa342721aac0943bf6686b64b2579376504ccc493d97e6aed3fb0f9cd71a43dd497f01f17c0e2cb3797aa2a2f256656168e6c496afc5fb93246f6b1116398a346f1a641f3b041e989f7914f90cc2c7fff357876e506b50d334ba77c225bc307ba537152f3f1610e4eafe595f6d9d90d11faa933a15ef1369546868a7f3a45a96768d40fd9d03412c091c6315cf4fde7cb68606937380db2eaaa707b4c4185c32eddcdd306705e4dc1ffc872eeee475a64dfac86aba41c0618983f8741c5ef68d3a101e8a3b8cac60c905c15fc910840b94c00a0b9d0",
            "0aab4c900501b3e24d7cdf4663326a3a87df5e4843b2cbdb67cbf6e460fec350aa5371b1508f9f4528ecea23c436d94b5e8fcd4f681e30a6ac00a9704a188a03",
            TestName = "SigGen 25519 - 4")]
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f",
            "dc2a4459e7369633a52b1bf277839a00201009a3efbf3ecb69bea2186c26b58909351fc9ac90b3ecfdfbc7c66431e0303dca179c138ac17ad9bef1177331a704",
            TestName = "SigGen 25519 - 5")]
        #endregion SigGen-25519
        #region SigGen-448
        [TestCase(Curve.Ed448,
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b",
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180",
            "",
            "533a37f6bbe457251f023c0d88f976ae2dfb504a843e34d2074fd823d41a591f2b233f034f628281f2fd7a22ddd47d7828c59bd0a21bfd3980ff0d2028d4b18a9df63e006c5d1c2d345b925d8dc00b4104852db99ac5c7cdda8530a113a0f4dbb61149f05a7363268c71d95808ff2e652600",
            TestName = "SigGen 448 - 1")]
        [TestCase(Curve.Ed448,
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463afbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e",
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480",
            "03",
            "26b8f91727bd62897af15e41eb43c377efb9c610d48f2335cb0bd0087810f4352541b143c4b981b7e18f62de8ccdf633fc1bf037ab7cd779805e0dbcc0aae1cbcee1afb2e027df36bc04dcecbf154336c19f0af7e0a6472905e799f1953d2a0ff3348ab21aa4adafd1d234441cf807c03a00",
            TestName = "SigGen 448 - 2")]
        [TestCase(Curve.Ed448,
            "cd23d24f714274e744343237b93290f511f6425f98e64459ff203e8985083ffdf60500553abc0e05cd02184bdb89c4ccd67e187951267eb328",
            "dcea9e78f35a1bf3499a831b10b86c90aac01cd84b67a0109b55a36e9328b1e365fce161d71ce7131a543ea4cb5f7e9f1d8b00696447001400",
            "0c3e544074ec63b0265e0c",
            "1f0a8888ce25e8d458a21130879b840a9089d999aaba039eaf3e3afa090a09d389dba82c4ff2ae8ac5cdfb7c55e94d5d961a29fe0109941e00b8dbdeea6d3b051068df7254c0cdc129cbe62db2dc957dbb47b51fd3f213fb8698f064774250a5028961c9bf8ffd973fe5d5c206492b140e00",
            TestName = "SigGen 448 - 3")]
        [TestCase(Curve.Ed448,
            "258cdd4ada32ed9c9ff54e63756ae582fb8fab2ac721f2c8e676a72768513d939f63dddb55609133f29adf86ec9929dccb52c1c5fd2ff7e21b",
            "3ba16da0c6f2cc1f30187740756f5e798d6bc5fc015d7c63cc9510ee3fd44adc24d8e968b6e46e6f94d19b945361726bd75e149ef09817f580",
            "64a65f3cdedcdd66811e2915",
            "7eeeab7c4e50fb799b418ee5e3197ff6bf15d43a14c34389b59dd1a7b1b85b4ae90438aca634bea45e3a2695f1270f07fdcdf7c62b8efeaf00b45c2c96ba457eb1a8bf075a3db28e5c24f6b923ed4ad747c3c9e03c7079efb87cb110d3a99861e72003cbae6d6b8b827e4e6c143064ff3c00",
            TestName = "SigGen 448 - 4")]
        [TestCase(Curve.Ed448,
            "7ef4e84544236752fbb56b8f31a23a10e42814f5f55ca037cdcc11c64c9a3b2949c1bb60700314611732a6c2fea98eebc0266a11a93970100e",
            "b3da079b0aa493a5772029f0467baebee5a8112d9d3a22532361da294f7bb3815c5dc59e176b4d9f381ca0938e13c6c07b174be65dfa578e80",
            "64a65f3cdedcdd66811e2915e7",
            "6a12066f55331b6c22acd5d5bfc5d71228fbda80ae8dec26bdd306743c5027cb4890810c162c027468675ecf645a83176c0d7323a2ccde2d80efe5a1268e8aca1d6fbc194d3f77c44986eb4ab4177919ad8bec33eb47bbb5fc6e28196fd1caf56b4e7e0ba5519234d047155ac727a1053100",
            TestName = "SigGen 448 - 5")]
        [TestCase(Curve.Ed448,
            "d65df341ad13e008567688baedda8e9dcdc17dc024974ea5b4227b6530e339bff21f99e68ca6968f3cca6dfe0fb9f4fab4fa135d5542ea3f01",
            "df9705f58edbab802c7f8363cfe5560ab1c6132c20a9f1dd163483a26f8ac53a39d6808bf4a1dfbd261b099bb03b3fb50906cb28bd8a081f00",
            "bd0f6a3747cd561bdddf4640a332461a4a30a12a434cd0bf40d766d9c6d458e5512204a30c17d1f50b5079631f64eb3112182da3005835461113718d1a5ef944",
            "554bc2480860b49eab8532d2a533b7d578ef473eeb58c98bb2d0e1ce488a98b18dfde9b9b90775e67f47d4a1c3482058efc9f40d2ca033a0801b63d45b3b722ef552bad3b4ccb667da350192b61c508cf7b6b5adadc2c8d9a446ef003fb05cba5f30e88e36ec2703b349ca229c2670833900",
            TestName = "SigGen 448 - 6")]
        [TestCase(Curve.Ed448,
            "2ec5fe3c17045abdb136a5e6a913e32ab75ae68b53d2fc149b77e504132d37569b7e766ba74a19bd6162343a21c8590aa9cebca9014c636df5",
            "79756f014dcfe2079f5dd9e718be4171e2ef2486a08f25186f6bff43a9936b9bfe12402b08ae65798a3d81e22e9ec80e7690862ef3d4ed3a00",
            "15777532b0bdd0d1389f636c5f6b9ba734c90af572877e2d272dd078aa1e567cfa80e12928bb542330e8409f3174504107ecd5efac61ae7504dabe2a602ede89e5cca6257a7c77e27a702b3ae39fc769fc54f2395ae6a1178cab4738e543072fc1c177fe71e92e25bf03e4ecb72f47b64d0465aaea4c7fad372536c8ba516a6039c3c2a39f0e4d832be432dfa9a706a6e5c7e19f397964ca4258002f7c0541b590316dbc5622b6b2a6fe7a4abffd96105eca76ea7b98816af0748c10df048ce012d901015a51f189f3888145c03650aa23ce894c3bd889e030d565071c59f409a9981b51878fd6fc110624dcbcde0bf7a69ccce38fabdf86f3bef6044819de11",
            "c650ddbb0601c19ca11439e1640dd931f43c518ea5bea70d3dcde5f4191fe53f00cf966546b72bcc7d58be2b9badef28743954e3a44a23f880e8d4f1cfce2d7a61452d26da05896f0a50da66a239a8a188b6d825b3305ad77b73fbac0836ecc60987fd08527c1a8e80d5823e65cafe2a3d00",
            TestName = "SigGen 448 - 7")]
        [TestCase(Curve.Ed448,
            "872d093780f5d3730df7c212664b37b8a0f24f56810daa8382cd4fa3f77634ec44dc54f1c2ed9bea86fafb7632d8be199ea165f5ad55dd9ce8",
            "a81b2e8a70a5ac94ffdbcc9badfc3feb0801f258578bb114ad44ece1ec0e799da08effb81c5d685c0c56f64eecaef8cdf11cc38737838cf400",
            "6ddf802e1aae4986935f7f981ba3f0351d6273c0a0c22c9c0e8339168e675412a3debfaf435ed651558007db4384b650fcc07e3b586a27a4f7a00ac8a6fec2cd86ae4bf1570c41e6a40c931db27b2faa15a8cedd52cff7362c4e6e23daec0fbc3a79b6806e316efcc7b68119bf46bc76a26067a53f296dafdbdc11c77f7777e972660cf4b6a9b369a6665f02e0cc9b6edfad136b4fabe723d2813db3136cfde9b6d044322fee2947952e031b73ab5c603349b307bdc27bc6cb8b8bbd7bd323219b8033a581b59eadebb09b3c4f3d2277d4f0343624acc817804728b25ab797172b4c5c21a22f9c7839d64300232eb66e53f31c723fa37fe387c7d3e50bdf9813a30e5bb12cf4cd930c40cfb4e1fc622592a49588794494d56d24ea4b40c89fc0596cc9ebb961c8cb10adde976a5d602b1c3f85b9b9a001ed3c6a4d3b1437f52096cd1956d042a597d561a596ecd3d1735a8d570ea0ec27225a2c4aaff26306d1526c1af3ca6d9cf5a2c98f47e1c46db9a33234cfd4d81f2c98538a09ebe76998d0d8fd25997c7d255c6d66ece6fa56f11144950f027795e653008f4bd7ca2dee85d8e90f3dc315130ce2a00375a318c7c3d97be2c8ce5b6db41a6254ff264fa6155baee3b0773c0f497c573f19bb4f4240281f0b1f4f7be857a4e59d416c06b4c50fa09e1810ddc6b1467baeac5a3668d11b6ecaa901440016f389f80acc4db977025e7f5924388c7e340a732e554440e76570f8dd71b7d640b3450d1fd5f0410a18f9a3494f707c717b79b4bf75c98400b096b21653b5d217cf3565c9597456f70703497a078763829bc01bb1cbc8fa04eadc9a6e3f6699587a9e75c94e5bab0036e0b2e711392cff0047d0d6b05bd2a588bc109718954259f1d86678a579a3120f19cfb2963f177aeb70f2d4844826262e51b80271272068ef5b3856fa8535aa2a88b2d41f2a0e2fda7624c2850272ac4a2f561f8f2f7a318bfd5caf9696149e4ac824ad3460538fdc25421beec2cc6818162d06bbed0c40a387192349db67a118bada6cd5ab0140ee273204f628aad1c135f770279a651e24d8c14d75a6059d76b96a6fd857def5e0b354b27ab937a5815d16b5fae407ff18222c6d1ed263be68c95f32d908bd895cd76207ae726487567f9a67dad79abec316f683b17f2d02bf07e0ac8b5bc6162cf94697b3c27cd1fea49b27f23ba2901871962506520c392da8b6ad0d99f7013fbc06c2c17a569500c8a7696481c1cd33e9b14e40b82e79a5f5db82571ba97bae3ad3e0479515bb0e2b0f3bfcd1fd33034efc6245eddd7ee2086ddae2600d8ca73e214e8c2b0bdb2b047c6a464a562ed77b73d2d841c4b34973551257713b753632efba348169abc90a68f42611a40126d7cb21b58695568186f7e569d2ff0f9e745d0487dd2eb997cafc5abf9dd102e62ff66cba87",
            "e301345a41a39a4d72fff8df69c98075a0cc082b802fc9b2b6bc503f926b65bddf7f4c8f1cb49f6396afc8a70abe6d8aef0db478d4c6b2970076c6a0484fe76d76b3a97625d79f1ce240e7c576750d295528286f719b413de9ada3e8eb78ed573603ce30d8bb761785dc30dbc320869e1a00",
            TestName = "SigGen 448 - 8")]
        #endregion SigGen-448
        public void ShouldGenerateSignaturesCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());
            var keyPair = new EdKeyPair(q, d);

            var subject = new EdDsa(EntropyProviderTypes.Testable);

            var result = subject.Sign(domainParams, keyPair, msg);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedSig, result.Signature.Sig, "sig");
        }

        [Test]
        #region SigGenContext-448
        [TestCase(Curve.Ed448,
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463afbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e",
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480",
            "03",
            "d4f8f6131770dd46f40867d6fd5d5055de43541f8c5e35abbcd001b32a89f7d2151f7647f11d8ca2ae279fb842d607217fce6e042f6815ea000c85741de5c8da1144a6a1aba7f96de42505d7a7298524fda538fccbbb754f578c1cad10d54d0d5428407e85dcbc98a49155c13764e66c3c00",
            "666f6f",
            TestName = "SigGenWithContext 448 - 1")]
        #endregion
        public void ShouldGenerateSignaturesWithContextCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex, string contextHex)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var context = new BitString(contextHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());
            var keyPair = new EdKeyPair(q, d);

            var subject = new EdDsa(EntropyProviderTypes.Testable);

            var result = subject.Sign(domainParams, keyPair, msg, context);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedSig, result.Signature.Sig, "sig");
        }

        [Test]
        #region SigGenPreHash-25519
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            "616263",
            "98a70222f0b8121aa9d30f813d683f809e462b469c7ff87639499bb94e6dae4131f85042463c2a355a2003d062adf5aaa10b8c61e636062aaad11c2a26083406",
            "",
            TestName = "SigGen 25519ph - 1")]
        #endregion SigGenPreHash-25519
        #region SigGenPreHash-448
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "822f6901f7480f3d5f562c592994d9693602875614483256505600bbc281ae381f54d6bce2ea911574932f52a4e6cadd78769375ec3ffd1b801a0d9b3f4030cd433964b6457ea39476511214f97469b57dd32dbc560a9a94d00bff07620464a3ad203df7dc7ce360c3cd3696d9d9fab90f00",
            "",
            TestName = "SigGen 448ph - 1")]
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "c32299d46ec8ff02b54540982814dce9a05812f81962b649d528095916a2aa481065b1580423ef927ecf0af5888f90da0f6a9a85ad5dc3f280d91224ba9911a3653d00e484e2ce232521481c8658df304bb7745a73514cdb9bf3e15784ab71284f8d0704a608c54a6b62d97beb511d132100",
            "666f6f",
            TestName = "SigGen 448ph - 2")]
        #endregion SigGenPreHash-448
        public void ShouldGenerateSignaturesPreHashCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex, string contextHex)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var context = new BitString(contextHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());
            var keyPair = new EdKeyPair(q, d);

            var subject = new EdDsa(EntropyProviderTypes.Testable);

            var result = subject.Sign(domainParams, keyPair, msg, context, true);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedSig, result.Signature.Sig, "sig");
        }

        // need more / better test data for this test
        [Test]
        #region SigVer-25519
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f",
            "dc2a4459e7369633a52b1bf277839a00201009a3efbf3ecb69bea2186c26b58909351fc9ac90b3ecfdfbc7c66431e0303dca179c138ac17ad9bef1177331a704",
            true,
            TestName = "SigVer 25519 Good Signature")]
        [TestCase(Curve.Ed25519,
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60",
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a",
            "",
            "e5564300c360ac729086e2cc806e828a84877f1eb8e5d974d873e065224901555fb8821590a33bacc61e39701cf9b46bd25bf5f0595bbe24655141438e7a100c",
            false,
            TestName = "SigVer 25519 Bad Signature")]
        #endregion SigVer-25519
        #region SigVer-448
        [TestCase(Curve.Ed448,
            "2ec5fe3c17045abdb136a5e6a913e32ab75ae68b53d2fc149b77e504132d37569b7e766ba74a19bd6162343a21c8590aa9cebca9014c636df5",
            "79756f014dcfe2079f5dd9e718be4171e2ef2486a08f25186f6bff43a9936b9bfe12402b08ae65798a3d81e22e9ec80e7690862ef3d4ed3a00",
            "15777532b0bdd0d1389f636c5f6b9ba734c90af572877e2d272dd078aa1e567cfa80e12928bb542330e8409f3174504107ecd5efac61ae7504dabe2a602ede89e5cca6257a7c77e27a702b3ae39fc769fc54f2395ae6a1178cab4738e543072fc1c177fe71e92e25bf03e4ecb72f47b64d0465aaea4c7fad372536c8ba516a6039c3c2a39f0e4d832be432dfa9a706a6e5c7e19f397964ca4258002f7c0541b590316dbc5622b6b2a6fe7a4abffd96105eca76ea7b98816af0748c10df048ce012d901015a51f189f3888145c03650aa23ce894c3bd889e030d565071c59f409a9981b51878fd6fc110624dcbcde0bf7a69ccce38fabdf86f3bef6044819de11",
            "c650ddbb0601c19ca11439e1640dd931f43c518ea5bea70d3dcde5f4191fe53f00cf966546b72bcc7d58be2b9badef28743954e3a44a23f880e8d4f1cfce2d7a61452d26da05896f0a50da66a239a8a188b6d825b3305ad77b73fbac0836ecc60987fd08527c1a8e80d5823e65cafe2a3d00",
            true,
            TestName = "SigVer 448 Good Signature")]
        [TestCase(Curve.Ed448,
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b",
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180",
            "",
            "533a37f6bbe457251f023c0d88f976ae23fb504a843e34d2074fd823d41a591f2b233f034f628281f2fd7a22ddd47d7828c59bd0a21bfd3980ff0d2028d4b18a9df63e006c5d1c2d345b925d8dc00b4104852db99ac5c7cdda8530a113a0f4dbb61149f05a7363268c71d95808ff2e652600",
            false,
            TestName = "SigVer 448 Bad Signature")]
        #endregion SigVer-488
        public void ShouldValidateSignaturesCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex, bool expectedResult)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var keyPair = new EdKeyPair(q);
            var signature = new EdSignature(expectedSig);

            var subject = new EdDsa();

            var result = subject.Verify(domainParams, keyPair, msg, signature);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [Test]
        #region SigVer-448
        [TestCase(Curve.Ed448,
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463afbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e",
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480",
            "03",
            "d4f8f6131770dd46f40867d6fd5d5055de43541f8c5e35abbcd001b32a89f7d2151f7647f11d8ca2ae279fb842d607217fce6e042f6815ea000c85741de5c8da1144a6a1aba7f96de42505d7a7298524fda538fccbbb754f578c1cad10d54d0d5428407e85dcbc98a49155c13764e66c3c00",
            "666f6f",
            true,
            TestName = "SigVerWithContext 448 Good Signature")]
        [TestCase(Curve.Ed448,
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463afbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e",
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480",
            "03",
            "d4f8f6131770dd46f40867d6fd5d5055de43541f8c5e35abbcd001b32a89f7d2151f7647f11d8ca2ae279fb842d607217fce6e042f6815ea000c85741de5c8da1144a6a1aba7f96de42505d7a7298524fda538fccbbb754f578c1cad10d54d0d5428407e85dcbc98a49155c13764e66c3c00",
            "656f6f",
            false,
            TestName = "SigVerWithContext 448 Bad Signature")]
        #endregion SigVer-488
        public void ShouldValidateSignaturesWithContextCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex, string contextHex, bool expectedResult)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var context = new BitString(contextHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var keyPair = new EdKeyPair(q);
            var signature = new EdSignature(expectedSig);

            var subject = new EdDsa();

            var result = subject.Verify(domainParams, keyPair, msg, signature, context);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [Test]
        #region SigVerPreHash-25519
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            "616263",
            "98a70222f0b8121aa9d30f813d683f809e462b469c7ff87639499bb94e6dae4131f85042463c2a355a2003d062adf5aaa10b8c61e636062aaad11c2a26083406",
            "",
            true,
            TestName = "SigVer 25519ph Good Signature")]
        [TestCase(Curve.Ed25519,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42",
            "ec172b93ad5e563bf4932c70e1245034c35467ef2efd4d64ebf819683467e2bf",
            "616263",
            "98a70222f0b8121aa9d30f813d683f809e462b469c7ff87639499bb94e6dae4131f85042463c2a355a2003d062adf5baa10b8c61e636062aaad11c2a26083406",
            "",
            false,
            TestName = "SigVer 25519ph Bad Signature")]
        #endregion SigVerPreHash-25519
        #region SigVerPreHash-448
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "822f6901f7480f3d5f562c592994d9693602875614483256505600bbc281ae381f54d6bce2ea911574932f52a4e6cadd78769375ec3ffd1b801a0d9b3f4030cd433964b6457ea39476511214f97469b57dd32dbc560a9a94d00bff07620464a3ad203df7dc7ce360c3cd3696d9d9fab90f00",
            "",
            true,
            TestName = "SigVer 448ph Good Signature - 1")]
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "822f6901f7480f3d5f562c592994d9693602875614483256505600bbc281ae381f54d6bce2ea911574922f52a4e6cadd78769375ec3ffd1b801a0d9b3f4030cd433964b6457ea39476511214f97469b57dd32dbc560a9a94d00bff07620464a3ad203df7dc7ce360c3cd3696d9d9fab90f00",
            "",
            false,
            TestName = "SigVer 448ph Bad Signature - 1")]
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "c32299d46ec8ff02b54540982814dce9a05812f81962b649d528095916a2aa481065b1580423ef927ecf0af5888f90da0f6a9a85ad5dc3f280d91224ba9911a3653d00e484e2ce232521481c8658df304bb7745a73514cdb9bf3e15784ab71284f8d0704a608c54a6b62d97beb511d132100",
            "666f6f",
            true,
            TestName = "SigVer 448ph Good Signature - 2")]
        [TestCase(Curve.Ed448,
            "833fe62409237b9d62ec77587520911e9a759cec1d19755b7da901b96dca3d42ef7822e0d5104127dc05d6dbefde69e3ab2cec7c867c6e2c49",
            "259b71c19f83ef77a7abd26524cbdb3161b590a48f7d17de3ee0ba9c52beb743c09428a131d6b1b57303d90d8132c276d5ed3d5d01c0f53880",
            "616263",
            "c32299d46ec8ff02b54540982814dce9a05812f81962b649d528095916a2aa481065b1580423ef927ecf0af5888f90da0f6a9a85ad5dc3f280d91224ba9911a3653d00e484e2ce232521481c8658df304bb7745a73514cdb9bf3e15784ab71284f8d0704a608c54a6b62d97beb511d132100",
            "666e6f",
            false,
            TestName = "SigVer 448ph Bad Signature - 2")]
        [TestCase(Curve.Ed448,
            "018bdfa928dd25dbf2533e8f088a71d0d42e878c61edd12b81465c8e70638085067dcfc97739f5418c2bb28403f2127da6a9401cd252f1d05458",
            "fc35f437c8ffd3b1aac2da6be89a6fdb5a48def9bffefcaf900a4bbf39f4556fd60f97a33ceb37a37a11f4ba180974b04fa24283a62152f200",
            "686e713d",
            "f9406f9f59498e939bb1ebc45451ea815d32a2976d1c6b7d60beb62867f43a29eebb83a54a10c555ee385920813c14913eb9b1dd47260a80dc3829317c4158b549bfd09f4ddc3f9fa64c1041adea909849fbe21e9b58923ad8898bc5e2c5400e9d8b2dd6e5ba5dd220948b49989a7f2600",
            "",
            false,
            TestName = "SigVer 448ph Bad Signature - 3")]
        #endregion SigVerPreHash-448
        public void ShouldValidateSignaturesPreHashCorrectly(Curve curveEnum, string dHex, string qHex, string msgHex, string sigHex, string contextHex, bool expectedResult)
        {
            var d = LoadValue(dHex);
            var q = LoadValue(qHex);
            var context = new BitString(contextHex);
            var msg = new BitString(msgHex);
            var expectedSig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(curveEnum);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var keyPair = new EdKeyPair(q);
            var signature = new EdSignature(expectedSig);

            var subject = new EdDsa();

            var result = subject.Verify(domainParams, keyPair, msg, signature, context, true);

            Assert.AreEqual(expectedResult, result.Success);
        }

        [Test]
        [TestCase("2a66241a42a9ee12994d8068dcf1bb7dfc6637b45450acd43711f637fa5080fc", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac037a0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase("8c93255d71dcab10e8f379c26200f3c7bd5f09d9bc3068d3ef4edeb4853022b6", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac037a0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase("9bedc267423725d473888631ebf45988bad3db83851ee85c85e241a07d148b41", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43a5bb704786be79fc476f91d3f3f89b03984d8068dcf1bb7dfc6637b45450ac04")]
        [TestCase("9bd9f44f4dcc75bd531b56b2cd280b0bb38fc1cd6d1230e14861d861de092e79", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43a5bb704786be79fc476f91d3f3f89b03984d8068dcf1bb7dfc6637b45450ac04")]
        [TestCase("9bedc267423725d473888631ebf45988bad3db83851ee85c85e241a07d148b41", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa182ef1a5b928da07fec769cc8a12db6bcf70dab3f3227fa315e9d5e3e01a3405")]
        [TestCase("aebf3f2601a0c8c5d39cc7d8911642f740b78168218da8471772b35f9d35b9ab", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43", "c7176a703d4dd84fba3c0b760d10670f2a2053fa2c39ccc64ec7fd7792ac03fa8c4bd45aecaca5b24fb97bc10ac27ac8751a7dfe1baff8b953ec9f5833ca260e")]
        [TestCase("e47d62c63f830dc7a6851a0b1f33ae4bb2f507fb6cffec4011eaccd55b53f56c", "cdb267ce40c5cd45306fa5d2f29731459387dbf9eb933b7bd5aed9a765b88d4d", "160a1cb0dc9c0258cd0a7d23e94d8fa878bcb1925f2c64246b2dee1796bed5125ec6bc982a269b723e0668e540911a9a6a58921d6925e434ab10aa7940551a09")]
        [TestCase("9bd9f44f4dcc75bd531b56b2cd280b0bb38fc1cd6d1230e14861d861de092e79", "cdb267ce40c5cd45306fa5d2f29731459387dbf9eb933b7bd5aed9a765b88d4d", "9046a64750444938de19f227bb80485e92b83fdb4b6506c160484c016cc1852f87909e14428a7a1d62e9f22f3d3ad7802db02eb2e688b6c52fcd6648a98bd009")]
        [TestCase("e47d62c63f830dc7a6851a0b1f33ae4bb2f507fb6cffec4011eaccd55b53f56c", "cdb267ce40c5cd45306fa5d2f29731459387dbf9eb933b7bd5aed9a765b88d4d", "21122a84e0b5fca4052f5b1235c80a537878b38f3142356b2c2384ebad4668b7e40bc836dac0f71076f9abe3a53f9c03c1ceeeddb658d0030494ace586687405")]
        //[TestCase("85e241a07d148b41e47d62c63f830dc7a6851a0b1f33ae4bb2f507fb6cffec40", "442aad9f089ad9e14647b1ef9099a1ff4798d78589e66f28eca69c11f582a623", "e96f66be976d82e60150baecff9906684aebb1ef181f67a7189ac78ea23b6c0e547f7690a0e2ddcd04d87dbc3490dc19b3b3052f7ff0538cb68afb369ba3a514")]
        //[TestCase("85e241a07d148b41e47d62c63f830dc7a6851a0b1f33ae4bb2f507fb6cffec40", "442aad9f089ad9e14647b1ef9099a1ff4798d78589e66f28eca69c11f582a623", "8ce5b96c8f26d0ab6c47958c9e68b937104cd36e13c33566acd2fe8d38aa19427e71f98a473474f2f13f06f97c20d58cc3f54b8bd0d272f42b695dd7e89a8c22")]
        [TestCase("fdaebc429f4a735932a160da1301080c13280eea8bc280d1b392c6b9e6ba3a5a", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43", "edffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7f454d370c8d9fc323a41450f8d513eafeb5b0697390c1e505a0d4ddc71f566607")]
        [TestCase("84b698d39be126ff55fe45079e6c8bf64a0d7db6994560b4e96b7021eb39c1a1", "f7badec5b8abeaf699583992219b7b223f1df3fbbea919844e3f7c554a43dd43", "edffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7f084d5b99c2a9463d9c8bd5026916996984eeec87ddf1d3be329006ace1b37b09")]
        [TestCase("e96b7021eb39c1a163b6da4e3093dcd3f21387da4cc4572be588fafae23c155b", "ecffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7f", "a9d55260f765261eb9b84e106f665e00b867287a761990d7135963ee0a7d59dca5bb704786be79fc476f91d3f3f89b03984d8068dcf1bb7dfc6637b45450ac04")]
        [TestCase("39a591f5321bbe07fd5a23dc2f39d025d74526615746727ceefd6e82ae65c06f", "ecffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff7f", "a9d55260f765261eb9b84e106f665e00b867287a761990d7135963ee0a7d59dca5bb704786be79fc476f91d3f3f89b03984d8068dcf1bb7dfc6637b45450ac04")]
        public void ShouldValidateEdgeCaseSignaturesCorrectly(string msgHex, string qHex, string sigHex)
        {
            var q = LoadValue(qHex);
            var msg = LoadValue(msgHex);
            var sig = LoadValue(sigHex);

            var factory = new EdwardsCurveFactory();
            var curve = factory.GetCurve(Curve.Ed25519);

            var domainParams = new EdDomainParameters(curve, new NativeShaFactory());

            var keyPair = new EdKeyPair(q);
            var signature = new EdSignature(sig);

            var subject = new EdDsa();

            var result = subject.Verify(domainParams, keyPair, msg, signature);
            
            Assert.IsFalse(result.Success, result.ErrorMessage);
        }

        private BitString LoadValue(string value)
        {
            return new BitString(value);
        }
    }
}
