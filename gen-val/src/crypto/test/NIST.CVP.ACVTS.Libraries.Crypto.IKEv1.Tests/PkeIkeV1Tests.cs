﻿using NIST.CVP.ACVTS.Libraries.Crypto.Common.Hash.ShaWrapper;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.KDF.Components.IKEv1.Enums;
using NIST.CVP.ACVTS.Libraries.Crypto.HMAC;
using NIST.CVP.ACVTS.Libraries.Crypto.SHA.NativeFastSha;
using NIST.CVP.ACVTS.Libraries.Math;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Crypto.IKEv1.Tests
{
    [TestFixture, FastCryptoTest]
    public class PkeIkeV1Tests
    {
        private readonly IkeV1Factory _factory = new IkeV1Factory(new HmacFactory(new NativeShaFactory()), new NativeShaFactory());

        [Test]
        [TestCase(ModeValues.SHA1, DigestSizes.d160,
            "c40c396c4e6528bd", "02a3831318a52ff9",
            "de5c5af22cce9c22543519c97c714575b80f783e96e1442a3b76371f",
            "a20ec571030dbf5d", "08a1c78caf77b78d",
            "ecfac02e5a5f374ee50b7acbcd652bb602416655", "a06c47153b2509147f9fb3b2e65bc8f34299f82b", "ec7983927bb34f7f503244ab1804de4fa3e6c410", "860a40980478307185097c85bda2cb8db013f1c3",
            TestName = "PKE IKEv1 - SHA-1")]
        [TestCase(ModeValues.SHA2, DigestSizes.d224,
            "9efc183fe50ea4ace52d5e4363466813206c90c4453afc32b0f9b64d165a39cf80231c0e79ad9ab9f7bd98d2ee0a67528450d5d06f58ae2892ccfe9fbc92b34c0cc43cb124bb15a21bc8c0afd827bd7e9b4ed4dac807504bdc44b023f15a9a6b0d4cb666c7cac042a6abcb301d1c087647b07828a95d1353818df3ba8334a3c65f7a542530b0eae1b6f6ae662e492abaceb5e349129f705d2b834438a9356420a59cefd46fda77d1ed826ff857b0a9532685088acd7867b0bcb66772d8e95f1da166f16ef00bb5138bbfba4c436223e5aec54a516def655603437fe0cfb4eb1704dfabc18f6d7ed76c87d7015cbe5ed05d02c174b9caca63d0d89db134b4eed8", "1d87cb7fa2e90961518ee2379c490a63bc4802baabcdf30ca406b67787060bad43afcfb7f727ca1ea0a54ba1e5d71e6d46ab38adae3f0e34bce0e7f810ab06cb7b97caf8790ce4980bba629aad58a2cf9a69b9841b167543c027cd4eeae092068016484ae8ec03bb7527aaf529ee881cb8d52f1fb65f858741e81f2578eba29ef7284a135f8124cf5e83e017679c03eae44eb193e3577a5eaa525e8bfb6ecd5dc35c306088fe927631d02acb5e15f7979bb23a72052ef75a928beb1bd5a7db5b6fa0c37bd53cd50132f7f219a79d502fb2dee05aa79cfad8c0a91ac8e25743b5d58eedd9b1e0a83454e7bbaacfd4d8135d6836f6ec562844cf1ad445ed952c9d",
            "d3c1c302d04d2cd971647fc656ae918e773086481818e88eb64b32a2",
            "9a78774965f93bb1", "fa81e458cde270a2",
            "048cc940af4c7e529806478c30fe8e171bee6c65bf7c496226dd965c", "8c82facc066e9dcbb271785169dec2e98b27a84616121c2f00e0f2e9", "7b23c19b9daf0ae52ce1b17891bfef9f202b1514b59f9c819e7a1c4c", "4b47c9fc27ca00c45ce68553cd413df69462ac2678a6abae9da948d2",
            TestName = "PKE IKEv1 - SHA2-224")]
        [TestCase(ModeValues.SHA2, DigestSizes.d256,
            "9f22c7b27c3b86b7", "feeb525a99abbe2a",
            "9e993c3fbb1b69f99d6cda83af5fa75dbf36114d246b3097cfb45ed3cd973bbacfdc20f355277be43f236260d05a056bd1be3f74ae43b0b8c9e8d9bd1cf927922aaf7b5cbc99866a738df985658c9bb275b78f308a90f2e615f1f7075160238b066674b18701b18359c3360ac966f7cb1772b641cdac7a5c7d55a61204eb1180554eaa61fd1d035d7d081d921a4e76bac381fc3cb1f41dffa2ef87869f98de32420b908b417d7c320eed6ed15c96efa736abc0f4759bb8295c19fdf96f890873a227652bb4d16cd24796277de41f06b20e31e0dbb646faf21a215d6fb67fb8af6483668abf408ad64d12915675b149ac5d9fb557519c9c1108d2a6f90f4c3f02",
            "e6b34952ea91f892", "870060bf4d1f70b8",
            "0b7aaae162a82665b7b4f00c85da14bf035fe3bcc4f4c6e15e0988350586e437", "4c5427e81ddd987bee3d56983f37ac9708143cf582d749c320dbddbf32d4ce0e", "9835da7d23f4162cf6e09412af68abfa187542db91dc8fd97a434bba7028887a", "bd34bc7c1debe1de0577f42870c9956ed0662d396f1cdb426f8c9eb1ed5f8354",
            TestName = "PKE IKEv1 - SHA2-256")]
        [TestCase(ModeValues.SHA2, DigestSizes.d384,
            "6de163cdda0b0a534d50e0e765cf62bd5bd539de41e5fbe8e656db0b2f1d6acba2e2095298610460dd28f8cb793a9ba601511d782c4d5c2c6f4068ea13421be33385d3170ede373f50f0c85d37564600687e023789b478b0d14f2801e07236246a8256a889db656298b15899d326f9e03e19753443580f6625d56fa377ee6416384746f69b8c8faf794f2b402914d2940b13c615464b1dcedf768a529cbb853c7ecc03e0618096b52d9b20b031891b5978c1f5fd127cd6097d16b8adb97a2244f59c8e5bedd595341d8ba11154138d074165a991f6087fd9106f96e483105a37b8783e7ee9e57630f6cf24d0287b7330cfeb1f1d362753b78c5298d4d2a6fa52", "6957be15e9089c5e7e53bc1f55754e0c1db05ace0c87881891c32a184884567be7d64668128b4b03ee4e3b39a7a28fd8d814f77c35c68390cee0d72cb569e84355a5cab865381ebc5a2c62f8e0c1b6e824f69947f995f703832b1a4d0e75df7b56b170638a0ee12b29b58ffbc7888d3107f160a54b6ba57533df3e8d3aacc664ada1487d2a9568783766837178dcea4aede713391dd89bbe48a92f58402e60ccaf14f3a7531a86f1280134fe641d50a131306144fdc0f1a3cbac59975d80a48b23d3c8cd622f34d8b8ffb8e34e2c143c5b2b96454512e00389750af2398840526ce6f7911cb43bb763f33dacf55bf20a4c74a718916cf54b501be59407bc638a",
            "c033354e621da59fd4d7a207de420fc5f5a9fff2d770d7b7ebbb1731209c91c5e2b1bf51a4ded5fb4241f4de8d43567e7ceabff1d9b4d9a9f94cdc15b60c6b595105fbb251364b230c347dfb487a687f71072c774afc748f1efdad59038de60168d4f866308a145dd600221452800a7f5bf05f1288ed5635d97255065e9afe29ecfc7f1317165f5e72f2a8fe5f8a31ff6a9a30e9f23b95c0706b5019183519c43f3696c5dd03899b99c54a1b51c542ee9ef99fb4cc64db3482a7d2876f3af7ce658c0608cc514f845b30d7d06e3822cb64cf13d0b529d957911256f29a70062c65f090230f88e63657a6b779217529369af79670ff27e44670eff4042be5d4f6fda61b7d185677ac05f382053f4e74ce935373b2d3d10c223cc029abaa6d867b7b8a23dbf463545ae5cd988d60ff19eb6d5c44e5a62ca05136aedc429e1456646fec0f3397d9b6e7d656987127248e385ffc02842fa7175a697376452af568c79bda914c5dc9b8999d8ca29caee3ca4a6c338bf0722e75e22bf86ab27ba5dc4910a64aca1b3f16d98591026470615ce62a3bad0459f5cf2ef3fd2f982e51a49261db1255589485ac8caf5280669871c82b571a67b44997b6b19833fc26ad5c136fbee8a82d0ce0e925c6ddb663a06725dbfb0e942181f291aefce50c82e773a7fc5b464d9accd815c31c97a8850b4a1b4403c98bd5df14eb64863b7c8faf987d4125cfe69b1bb37502cd3e70a391a68db61c003bda3c58b83b56b8a4c267cd49e1fb1550693776283c29dde9313c858049c457d4df2357b95e7c36c635524c2b77c63adf29b942956cc190146eb35fe33c3fd3f664e8034ebbd295bd1e08e4191d349f1760b47ec51e9a1849934ee25cea9b7ff6dda50d2ef2a0c20226905ef88d385c797c7a193c2b54dc693c826b8ba89c82715d4c0a05c984517947f95660d9b0a60f393727e7dedd6836bfa2853731d05f5f09c7e33aba24ec0d75bfdcce22d5931e4198335e46e6ec78fab166f00b3e3a504c1cc29aeabc78d8faf86eabf5f7d01dfc068cc7de91ae81bd02edfd31a1bbdd3a39e2d7a5ec23cc4f81c7858ece3db8b2d487bf5dbc1e83c9295e205022860ac6a7fc6bb3c2ad79f176b7e8e1040cc294ae5aa697a690131bd8bca78e937b47f6b9dace615209513535d8696af79db600cb4b47153beb5b27a1c8a000fe1a88dc854f9737e3cd1d570a3e099385076dc9d35068544d7a6db048b5a424d9d420b57f289f947d966ec495f1a453960ae9b46b17b0fef07b15d6fb08d3d8147329272d6123cd19845e41d6f2724db533b48a08d529a07e27d3a6c7568acd00d717b719997e1e466d0d112f2d97c1c434413e2e58d73fc8f5fc4abaa5e34621d90b07e407e86b65bcf3f1a052a86e0f10aa118ee0b0a9a470fabb9b77a162af1e47e607d5b7af060d1828b9afc5",
            "8d8b0f1627092107", "f7e5d8b8a899597e",
            "4fd141e0e31c152176a85c8ad873f1487b229dc61e3f852ab493cfc8cbba9bd98079d6641b01116999999dcb2274fc88", "703b5648268d703917b9b268424090d7cb96de19057344710a8e07302d2951a797e0448256b5cb3f9b9526d8e73aae1e", "178c165f0b8ea51eca56b49a8995ebff22b091bbf9d5febb8c51b252a2af30ed56f5afe0b5d1f674729fb3440b0d9462", "079aba146e7663f741c32d46716a8c76847dbc00690f0c62e542adce4dc3b4d197b28a271ff169c9e8380eb3b169fd87",
            TestName = "PKE IKEv1 - SHA2-384")]
        [TestCase(ModeValues.SHA2, DigestSizes.d512,
            "7338e445a7b65dbd", "b8d8ae586e586e25",
            "9212db9f6b82133150bb5c9a55627dcd500fcc6638268f5e73541a3e",
            "39fb8fc80130d697", "146d7b541affeda0",
            "828ff3f30e2e8ad728c6672278e00ea3a6e015021190d7762f9eab3671b7cc1602a9e26ee351ce62aa3643aeac3599153688fb535afac2b6749ea61f0a0f9ab1", "f5817f8587c93ba1a620cd4ee39507c0dd886080e49cb4e04a2c7c36df5f2580e7805193d1fcf6162dbda708875158c2ea4ff278676d4f3858658569b75222ee", "b30a5133cf8da2fc2a52a4685c7b958464174b8149b568fde8b0f6ab51d3f5decc83589fb39dc520cb919f875ac3a8fd5af4bef934b13da3bfee44cf7dcb2246", "cbabe39b24fc49602908f58dd9b6ec43f60f47c324e76dfe4aff93757202a4dc34c16874978bb5848869e466f92922134a255092d16c3f7cfd8120c455f134fd",
            TestName = "PKE IKEv1 - SHA2-512")]
        [TestCase(ModeValues.SHA2, DigestSizes.d256,
            "6405C3F745167350", 
            "7DAC7E959AC2B762",
            "6583BD55DCBF332059091B819016F01F88B05E99281331612FAA9E33E03923AD3D51DC87382C9A616F3EB820181D4F3E8B89C6584B30C0C20AF50276A0A25E912900",
            "5494D2AB78AC6443", 
            "673DBEABF7539E11",
            "4F7EB58059FA2C5DBCDD63F46FA68B5773136B4530E4443BFE6675D59EE6EA7D", 
            "CE4B035BD7FB505832731B2910FB6CD49FC53E623CFDA20A148A71CCC28AF9DC", 
            "E25A1BCA49C9C1DCCD018B7AF7F944C591199ADE61E5BD58C1E0EB79E3207BE6", 
            "EC6149B51E69DA3CD66A17D0A0E479E0E124E22E930767DA2FD1414AF4F05EF9", 
            521,
            TestName = "PKE IKEv1 - SHA2-256 - non-byte-aligned g^xy, i.e., 521 bit")]
        public void ShouldIkeV1Correctly(ModeValues mode, DigestSizes digestSize, string niHex, string nrHex, string gxyHex, string ckyiHex, string ckyrHex, string sKeyIdHex, string sKeyIdDHex, string sKeyIdAHex, string sKeyIdEHex, int bitLen = -1)
        {
            // inputs
            var ni = new BitString(niHex);
            var nr = new BitString(nrHex);
            BitString gxy;
            
            if (bitLen > 0)
            {
                gxy = new BitString(gxyHex, bitLen);                
            }
            else
            {
                gxy = new BitString(gxyHex);
            }
            var ckyi = new BitString(ckyiHex);
            var ckyr = new BitString(ckyrHex);
            
            var sKeyId = new BitString(sKeyIdHex);
            var sKeyIdD = new BitString(sKeyIdDHex);
            var sKeyIdA = new BitString(sKeyIdAHex);
            var sKeyIdE = new BitString(sKeyIdEHex);

            var hash = new HashFunction(mode, digestSize);
            var subject = _factory.GetIkeV1Instance(AuthenticationMethods.Pke, hash);

            var result = subject.GenerateIke(ni, nr, gxy, ckyi, ckyr);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(sKeyId, result.SKeyId, "sKeyId");
            Assert.AreEqual(sKeyIdD, result.SKeyIdD, "sKeyIdD");
            Assert.AreEqual(sKeyIdA, result.SKeyIdA, "sKeyIdA");
            Assert.AreEqual(sKeyIdE, result.SKeyIdE, "sKeyIdE");
        }
    }
}
