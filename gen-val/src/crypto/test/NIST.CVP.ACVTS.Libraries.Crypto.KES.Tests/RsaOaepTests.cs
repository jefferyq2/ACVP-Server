﻿using System.Collections.Generic;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.RSA.Keys;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Hash.ShaWrapper;
using NIST.CVP.ACVTS.Libraries.Crypto.KTS;
using NIST.CVP.ACVTS.Libraries.Crypto.RSA;
using NIST.CVP.ACVTS.Libraries.Crypto.SHA.NativeFastSha;
using NIST.CVP.ACVTS.Libraries.Math;
using NIST.CVP.ACVTS.Libraries.Math.Entropy;
using NIST.CVP.ACVTS.Tests.Core.TestCategoryAttributes;
using NUnit.Framework;

namespace NIST.CVP.ACVTS.Libraries.Crypto.KES.Tests
{
    [TestFixture, FastCryptoTest]
    public class RsaOaepTests
    {
        private readonly IShaFactory _shaFactory = new NativeShaFactory();
        private readonly EntropyProviderFactory _entropyProviderFactory = new EntropyProviderFactory();

        private RsaOaep _subject;

        private static IEnumerable<object> _testData = new List<object>()
        {
            new object[]
            {
                "test 1 CRT private key sha 2",
                new KeyPair()
                {
                    PubKey = new PublicKey()
                    {
                        E = new BitString("3BCF32AB").ToPositiveBigInteger(),
                        N = new BitString("CAAAB260AC87B780BD80F76CAB0B54F9B938803C1036A5F9D66F6AEF1869B43945E991155EC7178AA54A0BB1331FDAFD3B6A0984780842C96A88500B19D054111B53EAB5977D4B7F15230C610EE67177C361CB3A108581B47D5362EEC7C0AB7F3CEA25D6688EE69539682C9FFB1BE7F507EA875E3E234D0AA253467109ED9A5D9C1510AFA9A1DFCA0C827C96032AE5699E6D6C4271327DCA55093DE0C44025090014E4AD694D1C04582435FB5CCEDC9D28CD10608D44A6118AA60E91823330A0FD5E68C78028DAB1318642B7151FBED2937D46AB3C38F27E72D008C71DDD75071B4559F3B74990EA313B3542C402803BE4CCF499251B0C3349C92B394AD0EAF7").ToPositiveBigInteger()
                    },
                    PrivKey = new CrtPrivateKey()
                    {
                        P = new BitString("E704507BAFBDC985DC51E4067BB4FF7DAC2A6A9F46F09BC6AF66AD6703810BDF81290E31D1E453CBA72C899E56E7FCA1551F43BB3E6B442CC240D039A230AB68708FE3A82EDF33A021A2FC99E73391667D3B0B5DE89B8834E0A6D60EA11DFB382D2ABCFC2FB3766EA71F3BB5F4BECE7D23C0D59B632BC951C707DC6DF11FF6A5").ToPositiveBigInteger(),
                        Q = new BitString("E0958340B64B3A09B9D02080185A35FC990F6D9D2A6031B17645FB94C57D455690DA3075BE8F3E5D9A77210552ABDDCBFE9DA0B19F7D04A1D40521A12824E3969ABC1F01633D0E639F42308293733B5E649446CF13B0EAED3EAA0D54C1FA6D680FF672CF6365A1A662D31E53B34C9339E6B8896421AB69DD5E6DC8E9CF5D446B").ToPositiveBigInteger(),
                        DMP1 = new BitString("865258DAA534A9669F305818D7C8A5F1F0BE9ABE560F3D4511778DE97910015F4F2A48F34BDEA5B730BAC6B9139748ACAC52D2EB04B63B46420D26A5CD942007482B65EEB869D6511C5ABD8F7CD0EEA2E17347D862F967AF1FE39814700EA9D8EA76637736ED7DA7BF783B9877AF9333FFC796F5CA42E49472DFCDB33982C5CF").ToPositiveBigInteger(),
                        DMQ1 = new BitString("08772938B561D3848DF51B63A8AA3F3D81B13FDDFE116E39B8E95E0DD8CDBB7124C0962DA54517DB898C62FE3E5842B7DA1FC5165A1A3D5538EDA323B303C92C9FC337BB565E6D1E5E68B42B51DF1A14A01F83D8FDBD021B8D259EBAC6A67BF43123D5472AE93BEFEC6A506F75E46F7C77CE93E0FE17371FB173024584D6111B").ToPositiveBigInteger(),
                        IQMP = new BitString("1BB02423EB847B9AB183EB56B3049EACE3BA909453BEF2122A4400FB04EAD357CE67F5E8B126D0657B1AB123ED80DC22AEC68E008EC2A506F969F896C6349696BAC5D355EDFF68CD6587BA9C64F11E8C32C35EC144AF87417C9B6C22B9C772A206CDDD783255180A5CCBEE297C11DBC753D8238E1CD8753C13004885C352B87B").ToPositiveBigInteger()
                    }
                },
                new HashFunction(ModeValues.SHA2, DigestSizes.d224)
            },
            new object[]
            {
                "test 2 CRT private key sha 2",
                new KeyPair()
                {
                    PubKey = new PublicKey()
                    {
                        E = new BitString("CCD124DDE3").ToPositiveBigInteger(),
                        N = new BitString("AE1622DF89B835BB16746CDB39409E9451724D6ECF3A830E778118F2B07691BAF5808CE9ADE0E699F575A04B101CA0C5C79C64B47129A686760C62160ADFF35F8A1F5A2D2076760DB90832CF313157D94C38301CBA61AD83214D00AADF56918C321AEC3FB1FCFF6F3D4F74174E6BCBC9590EF7316F4240348DD6FC4BE1AE119A73370E5FE9308345BC409733073BBC5B36D2C60CEC9442D80CA857257467AB979232F22EEC66A9D3C9C413AB60BF93D428A6CDA612AA7323B1974D6EAD593F3AAF11F84FE143313A8DCEE8C91476715C2ACD0B4CC0798DA9B9F4C375ED2474C83392756BE8815D0A2FF44F26E5107B4DFB2002368B938D87030DB3290ADBC37B").ToPositiveBigInteger()
                    },
                    PrivKey = new CrtPrivateKey()
                    {
                        P = new BitString("D3B2D056DEE431A9B3AF3AD6FB1E3466CAE0B150C960CE311DC94042D3D9B4A668BA35668D3380F64689DB64923F90A952EFB848346F4E0B96B098D3CDDB053B0E55A8228CF9A168217610D6EAFB3BEFF665247765D6FD6204B5E9CF5C40C779454E9B00DDBA84EE85D94984938F44E8C85595CAD5B4AE0E65AE44E199DB3C3F").ToPositiveBigInteger(),
                        Q = new BitString("D2845B9FF912011F4ABB69AB32002E3FB45B3630917EE22B0103D708109EC39FF3CC40625C6E7883CA6C03CB0C020061E5C7D9119210107970A9CC160B432BF3A063BB9663A775F34D4EEC6038A831A24C3F86F80F30FB455D937BB7873904BF7A696BFF2D6D4B370C97EB3A8C0CC2CF1E141EE264A5588E559B4EDE2FABD9C5").ToPositiveBigInteger(),
                        DMP1 = new BitString("4703CDF52DA3A729552208B7BBC98EE1D32D4243086FB238B6BA046EFBB6B44F71FA24725DF51E318551208A9BA1A0C75B2D9C8389FBC4CC1F06E74692CDA7B6E54F4E1566B59C094BCB159B66F91E960966D0AD7DBA32E254B829E22C6B40419542FA26F7A0DE6C15F5D341CA69BBE9552264114B97F7AB4B3B45554933AA25").ToPositiveBigInteger(),
                        DMQ1 = new BitString("0CD06209519369A5FF9FD26494FE62A3039D3C5A896117A82EE2BD337293393C707F217B4E69568636FF6CC0663F860612850500EDD28D8212009AF724411C270B6EB999B74156049DCB049ACF044162EC70B49F86D8E30EFBC2F9BB29AF492634D2DB59703CDA897214A8DB5786874A8ED6E2573EA116C9311FF907B8BABA17").ToPositiveBigInteger(),
                        IQMP = new BitString("A05EC740A458C064D2A93ADB79FB21EF3337440C1DD02E91203899135667BC974CC4A596EBE070E56183D96C28B4F2F0B30980D3B5DA86CC158E40AA6E5AE4F3978D10150C5C9F38D056D19AAA21B4F78EEDFB346727DFB87FB74DB7C11738F00D97CDDF3A497E8C32C88B50FEED2732F0A9F3E376AC120BCC444FD2065A55D9").ToPositiveBigInteger()
                    }
                },
                new HashFunction(ModeValues.SHA2, DigestSizes.d224)
            },
            new object[]
            {
                "test 3 private key sha 2",
                new KeyPair()
                {
                    PubKey = new PublicKey()
                    {
                        E = new BitString("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000001").ToPositiveBigInteger(),
                        N = new BitString("982379d819ac1c57824c10f4c3df9e04f7744d2e98e5136e7f4497c7743fcd5ed25b22f8ca9eb4ddef60110edd00c6c4541391e3590c2d96b5bb08386d06de821366da1fd684695ec2158238e5fd83c3dc781321442244611de51c2d26f142ea4d5c41aac3d5a94ebd1b704fcc3cbf3e3f4a5acf3c61b5688c7bb7887170c075c31800dba8273c0f54bf096d89f68ad098a6fd45f648b5112d0f9321a9ec1136d8a8a0f9888a8fcf91129cd3d4d11121e78d9d9c55fb4825a6f06e4bb56d8c796611614f71b84707c80ac9bd575478c8a0608e6fb1d7e6e1a9e4f8ded481ad861fae59a998bd9939b94f90dba167f707b4d30248146876c9c5776a413ae1d0fb").ToPositiveBigInteger()
                    },
                    PrivKey = new PrivateKey()
                    {
                        P = new BitString("b87c1a91830ce1f139ef57442649f0b658a38760a8641529477e8852da5e5149d2903eee429f9ec575cae7bb41afa059785a977e48cf3809daedd87c878fe67db149497cb37c1ab8334c608e668c445ae8590d780260210d3d37b3f279fe99ef729199d45b401a222f4ed6f5b4a087d5111cf0e0a5213213e57c173fe46a687b").ToPositiveBigInteger(),
                        Q = new BitString("d31d66879610923be079764be5f23f04da500b88b0dee74e592c03c5ca5c941300e697cfeca6b453cf2436d03e037bd5320aa46f07ad1c6e3391783928d7be8738ef8d0f3da0e2554acd96ecac6645868cc78f574661be1c6fdf5778b4686e5a0345e264cbe9355d8f2f5b9bf872b62d9ed5cd15942be7641f6a3eefec091181").ToPositiveBigInteger(),
                        D = new BitString("013635df454fa56d30cd0b92a5e4b6b65c761d5bb4d262d64fe4ccc9e378cb313e013d50e660a6f7881826a7a2137c07bcf846aab23dc326a8218c3593c16cffd0914241fe10a43daaff5fbb6115668f433043c6ae23e38e9d40ea3ca36e3e639987d4bea6b16901a78251ded0407ba5e3b6b2045a5246c22a1675015ec015ba4fb04a6b808538c6a7c889de73be0e58c986443167476ac7b0f699f6f7d4630d8e15bfeb6031380fabc882d8121abb553788fdc5d4d09aece3d43c2e7a5225a6fcc2ead084a30c0c9ac4fd848c25eaaa6c74f780130de1c11bf2855f087bf31cf614bb839b804d7b0d6870bfa61597aa257ca5cea37bfbb12c55948eacd32f01").ToPositiveBigInteger()
                    }
                },
                new HashFunction(ModeValues.SHA2, DigestSizes.d224)
            },
            new object[]
            {
                "test 4 private key sha 2",
                new KeyPair()
                {
                    PubKey = new PublicKey()
                    {
                        E = new BitString("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000001").ToPositiveBigInteger(),
                        N = new BitString("d9bae14d665c0d1f3664857f56c4c2a22b006020ac4aa14d14e4a8531fbd98f2982c0796362bbd89fff6f1aac9e352a78575db07cb0f7b6ea6ad8edbd01c3503204c751543ff4c1d2ca80c161ec9d6dcc60d39221faad707646e64233caf3127f226e201058527ae5f2ab2f0bbe849f41f38618c5604f53b20dd104f652a9caff1f442469b4cd586bce20c3714160193145b32b29f84ecba0ad0e9c6f239e5ffc34fcc7e35ec473338ae6cd17935459bdd79baa5a97052df4a123a69af0c0333b7ecc543816eaf75df02774a65c335fb0270a1c40008187d88408abf9157c0c39054aebf2d875fc439b42d8e54ae79eb3c0397bd69e981b536fe1a5ad2529907").ToPositiveBigInteger()
                    },
                    PrivKey = new PrivateKey()
                    {
                        P = new BitString("fa0d42ae82df9aac490d2af12af8d5dbc520233facfd59b752bc5cf6c89336ccf2bed7f82ad4779cb90a0674c7f4cf2377806d3aeb6d96a28aaf062c8193ccf4528f7f612ea989892c8dbe0d4631d1e298185f8d73d71fc94542bfb31401963370f61e7ae48c7fba671430f237c0e6a312f65a072314e9d736ccf2dff00088f7").ToPositiveBigInteger(),
                        Q = new BitString("dee8ca281aa5ee06e114bffdc17bd510aa4f615ab2b1c0fbcdfefd122efd26a8688ee94060470c39764bb06dbd6093e842352a484e55af7ed2d34cd195678c3080fd9f5c8d1882ea3ea52900c8539096eb874e089327d8d40fc268e2ef3ed0c992a79384265f64cd0a8ab575f33e0d4a0593b680ba33ffcfea0db75a1915fc71").ToPositiveBigInteger(),
                        D = new BitString("4f3eca92ac2cfbafb1b67d8f8d7e63ab0c39c4d8461c5a995a1edda5a91b86585d86fb7b0d1de5d5ba0a0bf1c12e1066b91bd5abe69e4c44f2cced81210f0e028070505266b95fc78237a72c1bd34b595e774e943b1b520b754bccf45761bda7a57a279546e80dfba6c319237233f4f6f8fdc3de5e0f00627dc28842a35a8b4b5070831273c7da575f402e60904a0765d037362941e5479599e17e17d30e805473cf4e3f31e0d7934d04d98f22d83cbe3558a45f418d4732b83c7b590d2863a4b8a08f13fbca65e7eb5ec2b1a4422c4529b36beadbabb57f1cd4c338436cdad3a1f7849e86647b5c9a5b152fb8b16e11e0abb499b7aa0db5d76c4ec4bbed1101").ToPositiveBigInteger()
                    }
                },
                new HashFunction(ModeValues.SHA2, DigestSizes.d224)
            }
        };

        [Test]
        [TestCaseSource(nameof(_testData))]
        public void ShouldEncryptDecryptToSameValue(string label, KeyPair rsaKeyPair, HashFunction hashFunction)
        {
            var numberOfTimes = 512; // Arbitrary

            var hash = _shaFactory.GetShaInstance(hashFunction);
            _subject = new RsaOaep(hash, new Mgf(hash), new Rsa(new RsaVisitor()), _entropyProviderFactory);

            var key = new BitString("CAFECAFEFACEFACE");

            for (var i = 0; i < numberOfTimes; i++)
            {
                var secretEncrypted = _subject.Encrypt(rsaKeyPair.PubKey, key, null);
                var secretDecrypted = _subject.Decrypt(rsaKeyPair, secretEncrypted.SharedSecretZ, null);

                Assert.AreEqual(key, secretDecrypted.SharedSecretZ);
            }
        }

        /// <summary>
        /// https://github.com/usnistgov/ACVP-Server/issues/156
        /// </summary>
        [Test]
        public void DebuggingVectorsFromGh_AcvpServer156()
        {
            var iutN = new BitString(
                "9DC9ECDB0ED4F8C3BDDF2C096315FE5150B2892F14C1B13AD143D03D5BE7085C15A34696342F14CBFAD08334E44D22F6BCBDC426E975D70E6EA249EDE00245C9C1822B9C73233CA63B0909CB962AD372C65BF945A7DC9F9687AEA17CB04850369EF37D1D31E4C59A6112CE973CB8C68D3A1215936975F0929F47C9F2D6183C2652C521378B3486ED6A5A3F58584F23874DC93B64047F3400B4B6D763C97CA46B938FB4477441F36FF84A33C2E98494661FE931E442F78E5386C336DBF0E72F5478FA461E756244685FFC8271DCAD8C84DB776E4A13E8039753000A098542F42ADF474A42671CF14DE937AECCE8D47AC7AF18F56D033103D6EAF8FAEF44841062F7348C1A790F5BBBD5D20E29F949C44870781F3C620B70BA039648A7AE7A779DB9EDE69B4E1B87854EF1F0138ABE7B9BAFF1E93563D548A0210AEB8F5D28DDCF8CDBA6F9BE99735B78E0A0B4A42B939F7CEA0D5E654D72176C8B6BCCE47306F610BE691F6120492D376CCA8DB4BD46C5AF631CBDD2E31E754192DB57A92CFDC7");
            var iutE = new BitString("010001");
            var iutP = new BitString(
                "CE2FB63924C792BA45165562FF0241F13FF8D3FEF3B5C0B0C4B2E2A73C21B714F69F92E360F7E2E28F7ED03A873817153572FA26498B3C6112173006A922391551DD9A161777643A1E1C892F16D3C8F4B88BC9753709F290B6AA5AC43100FE19AEE70E502CCFA1FFE8322F3B1CF20C6CDC6107A83BE7FD5F2DC7E5B9764C6C4E57A5212240A455BF34055D35691F579C63D0119D4F56BFCF0A4EF4828FD5044568985A738E6F3DEEFF56FFFBB707AE2249758F7B92D4E7B219AF927E93551633");
            var iutQ = new BitString(
                "C3E8E6B4AEC650E5BC102F72D4570B7EBAF218D9DEED8E0EA1CBFCF8B8D785C59C57ADC48245CA209E804A4F40FDBC3E379189784AC91070AC69F978E6EE66065F706F91954210436B63A3EE5D3B779A43E2E61FDEE5350BE8420793883583416FA88AB89700211DB1685D80D5F8B3B3FC81AE6930D6AFEA290792B760C1ABC8E378E711EF741CF14C16F68ED05F127AF9675433FE66B957B97A2CB3F26D34A7F62DDFE873AC1B51B5ACD0EA2D686556BA84249569A1F6C2605ABE0BC5D29E1D");
            var iutD = new BitString(
                "131270AC2BB74758558F6FA1B4D5D83718F3738C7ACC4CB148D1130F0F9835D4F792943A1C95A244638D2786D19F973DCEA37B5D9EB36D2AA3E9BED8DF4E3704437D09EB6FA94F2FE28BDDA0BB8672A7795D6D9C6345520EDE5897D15BF769A6A880D2DB200840704012876115685A2B80DCE5B9BB3213C18D3A1EA9590275E6C5F368E7EF4E0A8F10DF56AFC580CF510FF0665AD9064D1156C690F3514BDD0DD9B8B1783F8FA72E9E0ACE05DDB6F63EFFD56E7FE22E4D08408E4107C5AF13F3C7CF77E5567236BE9163F9330E979DC656BBF4FB6D01B28034E889E95794E970EDC070E0B9D6D748D7276818530D8A3D0DADADF1DF49935FAF37CE5B5BAAE682D06AA3D2DF6AF4B7FD7E9A1EAACDDF551FB6F2457CF820484ABE14860EA5C7D2D637C855919CC5E12934A65FD48CB5A90BEC9CE85879E58DD084EE0DBEF4E678387D1C7F5191BB346F3C3EF682566AE236BE9FECF86FA10DE9C00E46EE186B16F6F80223004DB6F855ECFD5C30DBDBFB04EF094576E77FB6F867432BBCE3DEB5");

            var serverC = new BitString(
                "703F99421B8691360B8B6438304F3D833EF5C5D25848A623B7A7F470F5610D75F89251BF773FE0E9A1A475A3D66D7ED0C9C6B6FDB96EC78134CFCAE4541BEFF6CD5AA58FA05A21E2F6C38489C8D741901834EE2C537157F7C1CDFB873F8DDAAF763BB1FC3A8741020335C93CCFB1A13129ED700D7D288901DDD2BFD4B98EC533DAB274BEC616B8E6869F5D4236BFFB58FE670E6A6521C05F5218F594E23FCA622B49FE6950BA5ADCD3138D6E537362EFFB288AC6E5E677BEA2C3766D10C080322EBBEED8BE08712F76AEC80AD2B53FD7A51FC712143C897285C04FC572D51FB28CF6275AB2C36C43B7948D34387B60C868243D0708A3282E09964E153480EFF59C014FAB4858C98C84C5E0113F0FA879C75E309339FE1EA7EEA0C381C6236E752535E68D311BB09EA519419370C8359B68988AF6E543A369BBF578D59BC2D3B285B3880C5F23E9111A6C6A514E9B25D9BD2C9F1B53FE29D770B0B61A77F802F294AC97D27925C8111278D51757316EF5E3F7377C97F83F95C6D33EE9ACBD233E");
            var serverK =
                new BitString(
                    "FCC6DDAA3D052160991FDC2EF6C1E9D8D4E15AC47B85B399AFAC6BACA96CB34FBAB6B9231EF9791B3645DE86302ED59A327DBDCE3550BFB5E9FCA3B72058A578A50C5DCB5B1B5592B090153A3B9D9653638C044EE4585C1781143F748B2AAB4B");

            var hash = _shaFactory.GetShaInstance(new HashFunction(ModeValues.SHA3, DigestSizes.d224));
            _subject = new RsaOaep(hash, new Mgf(hash), new Rsa(new RsaVisitor()), _entropyProviderFactory);

            var iutKeyPair = new KeyPair()
            {
                PubKey = new PublicKey() { E = iutE.ToPositiveBigInteger(), N = iutN.ToPositiveBigInteger() },
                PrivKey = new PrivateKey()
                {
                    D = iutD.ToPositiveBigInteger(),
                    P = iutP.ToPositiveBigInteger(),
                    Q = iutQ.ToPositiveBigInteger()
                }
            };

            var result = _subject.Decrypt(iutKeyPair, serverC, null);

            Assert.AreEqual(serverK.ToHex(), result.SharedSecretZ.ToHex());
        }
    }
}
