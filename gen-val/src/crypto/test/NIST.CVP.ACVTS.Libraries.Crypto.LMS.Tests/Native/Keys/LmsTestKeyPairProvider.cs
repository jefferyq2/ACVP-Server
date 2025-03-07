﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.LMS.Native.Enums;
using NIST.CVP.ACVTS.Libraries.Crypto.Common.Asymmetric.LMS.Native.Helpers;
using NIST.CVP.ACVTS.Libraries.Crypto.LMS.Native.Keys;
using NIST.CVP.ACVTS.Libraries.Math;

namespace NIST.CVP.ACVTS.Libraries.Crypto.LMS.Tests.Native.Keys;

public static class LmsTestKeyPairProvider
{
    #region Precomputed LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W1
    private static string[] LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W1 = 
    {
        "",
        "06CCA7E073DC8AC11026D556B093959C4B6BB93ACF20DA14", 
        "AEC706CB7519F0993327E8064256456DD785C1B40AE936A0", 
        "7665E4BA88C803A2134C799D4CDE45D8CEF3D7194D8EC34C", 
        "2C70904AEEA6DCB850D80E1FFE3FFC6DCD580491E79F77EC", 
        "A1FF10AFC8D84112FD5CE26F19A9FBAE9C113650974F87D2", 
        "73F3AA55CAD7D6995BD1610E99225B4A131D079E4AA1DDDF", 
        "D5B4ECB973F7A8E785B26C963AA0C203E19CBCFB2EB8A440", 
        "15EDEEF5F6ED306B27B1D01A01D467270911CF3D13EF3F45", 
        "66583362B23FEB64B9F3CBF51EDED7560E1C845DA0BBD07E", 
        "32031860063266CA4B64DE152D0126315A6A59D66B42EAC3", 
        "870D30B5D4044840F73451F4DFC8AA72910544CE91D5BDDB", 
        "D9AFE89FEA976DF67CF5C40B7281FB30366EFDB287FB0B45", 
        "01C2033FDD8D4341E0D6EBB242C3EE123A6D586CDA426B8E", 
        "F7B146E49D04555409D34BFFCCAB6403BC0B820DE6527C95", 
        "295D0B48492F245E16BFF54DFCBA98A4CE35443493217598", 
        "9841BE211070CB1C52D4EB2D9A69DB26F75D0C11CFDF424B", 
        "C41E206EC517732FA223959F66CA21DDCC57C3178542895B", 
        "9069848691E67F99CE3B8AB451EB4500D075765F18416CAB", 
        "1D94864C9BB73CAC641C2E7FCACC6D40C41C812F878F9978", 
        "4E3A42D7F8AC859D7842EAF059973E7176B926838C017B1B", 
        "14B71B0877D4FB04C9DA06A2F5B2F0499C7EEA37AA60AC92", 
        "982CDC5E6616AFFABFC8A55986A766DFA3BA3646AF23D52F", 
        "567E5333EF268CB5DAA7A79BBC44CF934C826F8FD9F33AE5", 
        "7FA112803B2DB29B187DCB3D9A558962173C258237F8C06D", 
        "CA49055922C569DFBA6D1E07CEEE5F5755897806DBFF900A", 
        "48613566BAD7D8BA703934DDB4AE31CA33288A29C2A1F406", 
        "C9FF4C5CF145612AFEEA03F1CA54A12B4125040A82205751", 
        "A15AFBCD9B7FA2B8112E4736F66BFB897E088C252EF922AC", 
        "8918F603E4649CF76005A3C8E4635660E4207C98F79CF135", 
        "C632BB7E340876193B3F97227757CE3EE6B25C23F78AF3A4", 
        "EB1054A5F8D82CB71182D72962A001339BDA929E584983FF", 
        "E3D0832AD4835BA323CABE46B9740BD331BA8D94606F6959", 
        "85348473FA484488CC0E032E1B30253F6023F01DBD67DC66", 
        "D4BB99E6BE6F23DF1D5627D39A7B398FC728ED919A978987", 
        "51C3490CF680F8C7942BD2625CFE71FFB73CD97919526312", 
        "FBCA55295282946FDA3EFD9FAE4E1BF8ACD5E5BD5E011F7A", 
        "42FF1C557CE4AB3BC2DA40FEDCB8E4945BD180C48A4C65C5", 
        "25C6656327D6FC1A792937F6A29035FB9DCAAD996E0D55A5", 
        "3252C99798960298E7F5440B14C129EE480669A0B788843C", 
        "DE0F53057E468C8379D2409E5547E1754572B9D3A53190F9", 
        "7B7A1168819A2ACCE20E0EDFE9502A0861E473D1F5E14C95", 
        "EBAE0F67BEA2A92514A0E80BDF67E40A1FB944B7A0341AA3", 
        "800C5DEC4D327E7D54ADDEE664CEAFBDB1430B0869621ACB", 
        "96953F26930DB2BCC393010E28F00A59CDB563BD1EF2664F", 
        "7DA546BF677FEE689B1350433B93C3C2B2F19C26A248B833", 
        "4E0136D8EBBC48B96DD845C1C07DE94B149EA91DD9916819", 
        "EE88DA74C1938803C32E138370D5464005284C5D6DCC460A", 
        "10538A1438A972825CFC4E53D0E9D806797E892D5138DE5F", 
        "82F9121CA889EE81523D67BF1C6EA18AFF430BD5AC8CADE4", 
        "45597286ED2573E2361F657692DB11A3E6699668E652C74A", 
        "89D500C9EF8FD3852B6D42F2AE1273AADB84F40492430770", 
        "FCBB35672805800ABC3AAF1AD1F9721F12D70C91CA8AC523", 
        "3907D14B6F05627F6FE991A66D356B1A1EF733B861DA332D", 
        "CF7F02510279EE87309C12653EDC0737EE64CC217A8FB3A5", 
        "31C946C5B1761961816FE675F051258D32EBB6BF1DA63332", 
        "8AD847863DF14510BBB39412F1123CA1372AA53F11D4B416", 
        "C9B3A52DAA04760820F1B91CDD92E5EF6B258C5A16863D1D", 
        "22D565F9AF4412A923C65B0A2BBE321EEEFA1A4C00F27EC6", 
        "65B541E6773FD3CADD2318DDCBA27B4F668EA557216F93D6", 
        "3738C39BE82C5DF56F30C83F8DFC4323BA36C46F259C9071", 
        "767820A422E8773979BD8772A3D219E32E60D85D968D246C", 
        "268D985552497A0A67AC441CC7B2200401B7FD76325019B3", 
        "1D57A96741773A300CE894F5624D251CA6439F93ABBF6970", 
    };
    #endregion
        
    #region Precomputed LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W2
    private static string[] LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W2 =
    {
        "",
        "E18398500F622E709F9EFF1DC764620907883244C9C8AD8A", 
        "26CDB91F5702E056679BB4A341691ED282F765F41D74A9EA", 
        "79009E3BF71C40C94939BFF68062284253BD2886FAB2FE82", 
        "8EAF954496035FDB6690BCF84DE0537A722D6666708E3201", 
        "DD49E175FCE3E4C5A75FF2337BCE5C79F7E530887056219C", 
        "F8F649C443F42374C453DB2D94DCCCFFAC87F9594DA202B2", 
        "45E33E61480DC8960C5E6603DA0109F951666D61AFD4474A", 
        "64F25902BFCC3511E652F28E8381AE456B13EE190F13DAE3", 
        "3167F5B61444F83EA0321837ED250B49A126D6664638037B", 
        "3B33EB22FD39B9C44578B369F3CA096A9B80DB861374EEAA", 
        "FAD2F2ECA10EF015CE06E1A6B53BD23E81B6B98CAB3416D4", 
        "FD756B925922DCB7AE10EE74410FA4D62C8B109DAA84816F", 
        "48D3FE4244A78728B6BD4320A90047E9A1EDD484D795D8FB", 
        "61E367B867394717ABB20A3A73D8E25808DC1FCF148433AD", 
        "686961A13ABCBB628741BAF1ED717DCF037A805E8DAE25D1", 
        "FC5E03860942A0507AE12860C705FCAB46A9BE450D4C91D9", 
        "D080D23E834E390538E02C59A307F9308F6F05CEE19C7E26", 
        "351CD31D842218D6B932CFD08B1FFCB91E8552741B399472", 
        "BCADEEC3AFE5E0E4AEE8C5E6B734EAB3FFE2E0E18A4EA243", 
        "200F0B28DD65D6FB4B465E5ED9C7E658DC095EB990660D22", 
        "DFBD98FC10127A11771A6FDFF584042D4FEEEF9ACD627D9A", 
        "7A74C7BA37E5612344817CA41466F97D302B85AD18D40DF4", 
        "E1EBCBF385822200501DD866307F961C81E5D69E9D0BECE6", 
        "A0B9D1D687F72AB049AB113CC44022EEB86C697347944A04", 
        "A8192254862592936656A33E5CF8B358BEDD2916655E2554", 
        "5CC4E305CFED6D29F7FEFCF0EAE0D6842A935A6DF1C1EA21", 
        "419B5EFEC5667A3CBAD70EB102AAC3636087B21C94BBABAB", 
        "332ECF45BCBA422313687788B18C6436B8879CDE54CB3A77", 
        "D166C890417A0C5FD8E0D60016C7C11D4D5EC391A019A049", 
        "4338C50499823BA0EB13C0A602BA83469B7371FCF0D8734E", 
        "C33BCEE2DF327862CB08A2E2ECBCEB7135583C7678878A93", 
        "1CACB79BBFC8325F7950B99534DB20B6D2E0A66C684FE98E", 
        "6798769381D4D2246931025A33ED54211165D56F61B95CF4", 
        "5794B76C98B251752D75E93D525E109AC993C14515532830", 
        "B052E3F6C290780DC789852BD58C83B85B8B457451AF321B", 
        "F0B09FAB0EA035F2272721BE21A8B3B50CD51B1DBAB2AAFD", 
        "31279BABB6248328CC1B19BD2A0375B18DA681D02ED90C6B", 
        "CA4CD6B75A8BBE66277E8A7DB04E854455D43A1AAEDFFFC9", 
        "D3374D25FE8171CAB5EA097DFE2EFA9E1F78C90D182FA6D5", 
        "430531C4A82947F323F83BD2A895D72DF92D5BE0ED54B7C3", 
        "3DBDC9D94636B2F4FC206F54B8B4402AF343E73888D37CE6", 
        "FB001C185FB126F9958EE04577512134B8FEF077C949C955", 
        "62CB627D461C5682E99FCB4398A1D4E440739B26F4476709", 
        "9730860AE56B823F6C614E174D37249D0208F7D29F150B3F", 
        "B0B4ACAD9FBF6F980ECB3E540DA5F0F6BAE323D0B78DB76C", 
        "55D26266ABEC7BB96724C46F6BCFE3D63DABF64A46E81BEF", 
        "AA5C38705D6B942AD66B4ACDC07F22D39D70DDACD45EEFC4", 
        "E0823C368DD07B89DB9784E9C4C6A05C418CD206EE2AFD78", 
        "2355EFA54CC97681874C04206DA29D3D06BB798B01206A0A", 
        "F0F8DC0563143886C88CA673E578922E6ACFF9703529A2F5", 
        "2214E6291D3690F1053E1F5ACE8DF475E5116264432A2E9A", 
        "A02A81948AE797117BAC4393167795E229918A7F1FB88245", 
        "08F00773F7912A677C7E7D391F55EF00EF2EC66F365CF4CD", 
        "636371C2CCC4F36A90A94CD719081E0D10DB673E78FC9511", 
        "D8168947B7DF7511774D1A1E438E49E81028F04E30343C44", 
        "970EB3F7627F180F78EFC2055E3616BA0931E3049FB6A7A9", 
        "E1CB4452A04E0D134A390F2915F419930BFEAF9BF856E5CF", 
        "AB5E4C43BB544BC77ECEA7FDC6FD7BE750FF056851ED1993", 
        "4CD0100F6FC9E65C97CC004006C72EAE7AF56FD9C1D65AF5", 
        "9FE2616F1B337F3D8DB1751227205DD2DD8D33AD965C6F25", 
        "42DCDD95EC2C3807D7C6A2267906230E8BB9F7343B04FA7C", 
        "D40769E5DD04F7F6693EF69AE2A3D05B03CBC2D0684E6BDF", 
        "9CEEBC430044B602A159C03F85A53CF4E61360FC16DC021F", 
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W4
    private static string[] LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W4 =
    {
        "",
        "459C06A56BBC5101B67214C1928B9F7A4AC000506F7EAF22", 
        "9FC3EBEEA4E62F14AD21C406EE432B853049A5568AB1F47A", 
        "82E29550465C48C260B84802620198C690DBB5D2A73FA84E", 
        "982398275311FED1B6A12CE5BEAE5ADE6431B3D07CF1D6D5", 
        "520BA516B811B48CB44DF8C4D397792F0AB7D470EDB28D9A", 
        "54AE33F07F787EB8AA25660F37A3D393C4555643C17E8055", 
        "68CA6CB5B66D195C1549E9B1CD35F146AE02B53354A2D3D8", 
        "1CFA93242982F731F6CFE678BC53D22C98E99FA3E66C2874", 
        "42A4F02F62542C8B1A16E2B1C38A595857265517CD06BD41", 
        "B2738DFB2B8A08BCAC61CBA25E26C4661D2FDED6166FE040", 
        "5A4ACAACF1718EC60DECE16116421F7B5FDA2DC486859643", 
        "FA5B60EDBF2925D3077B38F5E41A99E7AAEBC9A484966ADD", 
        "C20809EB4E542707F01F93BB9300FFB123336F1940CA723C", 
        "BE3DA9B3E277CF25373DB96D8847C3B89094E7D9332EE821", 
        "859BE7321C8B7F2BA025C3B60ED599858C7304CD251053A7", 
        "7EA929B72DF83B61BDD8EEFCB259ADC31FC7FA1AF48A8F94", 
        "949D0EFBED6CB7DEA7B157481C83285064760E97FC0FADFA", 
        "59057FD0E4119E1375690E34E280A4895D31716DCBA6F875", 
        "3F2358179AD3FAF431764FA9E37F5CA0488E15F335C091DB", 
        "D5272D33496A559A4C45910B04ACA61C2385484AC156D4B8", 
        "CEDABEEC0C44BE9157E0D4CA3F4EF1C8A1E4C6D3AEBC83FA", 
        "FD8AF919E5F599D33E2F1F877E5D7F5D145927C7DDD1DEE7", 
        "6DD033813F09F2675EC097DDA55BCEC8B8A4A2FC4FBB7BF2", 
        "526B4C6D27928D53850F3515F5558AD5C7A78F52EEC8028A", 
        "88355126EBCCAEC1D2BE3D40459123D992F0BC9786AB17A2", 
        "D7EF91E84C39DF64E984C08C3CE8CF73F81319A76D3BCD29", 
        "D3E326B2C716E59C437B6BFA3A13F6BE911F74C078E1B980", 
        "C75723EDCEE9079F34962BE2793258C5DC4F95E98E806C90", 
        "DB1242A3DF22E53644750563E0D01AE731D90E13CA537628", 
        "FDEC0DC25224FB23AF782D888FD0285ECF9C244E0393A6AA", 
        "3F572BEEBA53870EC01FAAD14D7BDB309048C08C768E5595", 
        "3E60FD9C4E01647A16DA829BD50CED1CCA22E65233E42B9D", 
        "62B0091C31A6E28B6D27E867F02BBBD6BEE4D035442C7157", 
        "F87BDD753106844D42C185CD96AE094C4787FFA53D59CD88", 
        "850F0DC576991410F777CD5F38F28F1FCE96E8054C0BD932", 
        "8D829231004B0560AE41B358E7C6B20569C9CFAFB36B265D", 
        "E677026AB9AF560705321A35BE328B4F935CF4123BD27B39", 
        "6A0F9709227DC573DEC1F78124C7A6CC3DAE03A26636BE36", 
        "CBBC90C490F3E5910184947D45EE2F4D63E62271D8D7440E", 
        "936E6AB8046AD9373345B38CBCDE1E301139B4A35203076D", 
        "C01FCF33A87DB01E9A0D171C72925A23EA955DA868872112", 
        "A8273BF6A50CD98B3B3809439EE31672919BCB123BB5FC71", 
        "2EBC142ED5C7F8C01D49B9D48DBAD4A221E3502A9706B922", 
        "A6AF303354DEF3B534D8AB82A2A422A918BFE0B13A55A213", 
        "7B3734CFCFC624E39E36A818DE2B48A1905827E6CFD6D9FC", 
        "DC7093591A1247AA7995A3DE4FB1DBF40DB94A3498C4A6C5", 
        "024EB971FB3B574D062FE901E1D2F85FA7E541B14C6C2E1D", 
        "B1A418025CD00C89A8BE17AE4354FF4FF6DB2FBF060250A6", 
        "5C304D7AE9B766E6299FFD1C04D921C59BD72F37209C8C66", 
        "60E72862090C4495293AC994C67D7330BDA8383870E8EBCB", 
        "5869CBA72C8C30A71B2CB941AC9E4F1C42BFE445ED1E880E", 
        "D2222FF1157099FB6A82162442EB5B6243FA2204F4A8AB86", 
        "D76C9FF1E7ECB76F7EA631FBB742D83BF7AE04C05FC52BEE", 
        "C8D392AABECF65A414F30F7483D99DD28B595779BB540D79", 
        "2E8B195DE957768B8E12BB477BCEBF68826A2027A6C5286B", 
        "29151F98A433BF44DBAD3FA23CC552C048487D241F22A076", 
        "4D4F4432E8D381D704FB3EBA94078B96770FE7E2C2B0E7BC", 
        "E90D9762381DCA343F1AE595A6BDD3B67FB66B88934B093A", 
        "B279ED4C6D834D7A3FFB7A948EF8C03E7C89877839F5E726", 
        "1A92E8D75CC8B01EFD5CAAD995381768DA1B5D875DC4967F", 
        "B7105B65D5CA3719104E8BE28851F253F2D0D9B43026B587", 
        "D40718D659A483437E7A8B687748C3D3769399365A36BEAE", 
        "D5D1BA567D408067F67E85677027CB2DEA253BAFDFA5B5A1"
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W8
    private static string[] LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W8 =
    {
        "",
        "F4541C138D18DB2BB752D93163B8DEEBB4E4C3311035EB8C",
        "F5D785DBBAE6F9F87F19CE5E664F12C49B5AF4EE9C9FCD79",
        "C15D2EDFB0C57FC0E1CD75E05797A35F7F7AAE87FF3D0F10",
        "DFC6573AE678EE4415343FEF6087C912675E36A8F27C2087",
        "1B18AEB0A1BC48D01F89B276F996F3F7EA9EF26B402F7B93",
        "A6E27A4CBAA62D08C1B61C00D9F53423AF039B1B096412A1",
        "C74C905A45F739820F0A7E5A6464A3C09ABA81F63FA9C4DA",
        "9589E04DB4A2D8C41ACDA664B6BBA3ACDFDD1796199CD619",
        "1CFCCA17555647807F1FDFD18E2331B4233EC3877B8F7DFC",
        "FB5DD1A43852C1DD3DBFBC6E91BF384A3DC7B97DE72DD620",
        "4C839DA8E8EFB1E3BC0DBCED2862BBF7A471D8D01BA43D42",
        "3FA64B19E2A2CA29C2B0B8FCAD7DA0C8686622C225047521",
        "89961181C2D961B7FCF6D577E6E22FF4D2284EBDD437DE72",
        "FFD7E0432AEB6D1ADC8F064E133A4FCD21FD376F7F3D59C5",
        "0A1CB9A6C79DE82B55224F20B7422B600E444E83FAEB1ECE",
        "686E07718FC3C1308E1EFEAA5D55DF995B2A14DCB0E662F8",
        "52E12C7910D77C21711A30ECB8DBBB183449B876386A7E16",
        "FCB04190B3331C438DAB1C08D264FB30FA4EB5410BFDF76A",
        "DC8FC0E6E027ABA366016F8318E340C61D993C3237435754",
        "7F23B7EA79CE923CCB74412B8C5EC3EE2F89086DDD58AD5C",
        "D9FE16474BBCCF58784B1D707D43A4E6572DC49732C01950",
        "25325E6A119486E71B0423109FF75869223DCE9835B71BA7",
        "B14D0668D06BCBC0CC9D5F97130DD206B228E6BA4735A7A2",
        "8880EF2FE52F4D6106704E7CA725F3B42D1E6DD6F99650A7",
        "2F58E2658F4DAA0436C67A585B5C2FEC2FA897E4D1B9F3A7",
        "667F21B5A2B2FFDCB629569F9ECFFB3A841FC6E47AD55320",
        "7967F7108837DFC3254CFD955F01A9E00E85700863090D68",
        "62B3EEC7FE105FEDBB12D2361ABCFE1D044C49C207BEC465",
        "D1A0DDF3DC88F84EDF3554A785F9B3BDF46C4D39F35EE3D2",
        "A08F5055C83631A7504F95ED103D488F6B337992BDAAC15A",
        "8CC94C301D58CE9D9A873903B54E76F28D8F10D3780FE979",
        "2B3B314B62CAA58ACD6781461ADB4C8BD0C7D9B21C392E72",
        "51E40165B30AE753737C387D10E89E3A0DCC51732228E8BA",
        "E9F60A7F5EFA56728EECF848B87E5DF82EF8194007451591",
        "9CD2D4E3D81B548FD1D3B0A2BDE04B730137C9E684B3DFCA",
        "9D1BB97BF3B0367891502A336212E852730B70DE5F87C45C",
        "2121F64F599AC38BF6A6DCBD921A432649B3597CFBBB8679",
        "3EFC76BA38D1782D8C91BA643D69D0E47B65DD76ED4EBE4C",
        "E74CC8228857FA193FA48F21EB287BFFFD2C93F5511127C8",
        "BBF7B762841471F6D9D335D6B2C5508D45065356C92D2710",
        "7655117D1F968B4896DE1D6FFC399B993EA17B2EF96DD18B",
        "CA41B8ADCD26842933F6BF7671BF0C43CE33AF7EC0C9488A",
        "79DC97E9D95B7D1176153CE93E1ED2A4596EBF1AEF8DC26F",
        "710E20B57639743ADC4C6ECC99785DCDD2B30DAFFE2C016C",
        "A0733F6D7B449586EB57245FCE98205BED2617A0E1189683",
        "4518A8BEF8EEE81EC2C45C0C50F9CD8603BAAB9F472996DA",
        "228B0FB26287D63FEB2133B64AFB8B0C570FFB18AAAB9CA6",
        "8AEADFA9AE4A2F7E8869228D24AC510E189E7139B1F9F9C3",
        "AD774E1294A342C2678DEB515EE101356FDB7B2F06C80EA4",
        "B6954135882B148FAFFD913DD58AC237E33A8346E17389B0",
        "BC1565370C803F7E832AAC1AAB9F80CF020EEAF36F909AEE",
        "C3973B246399D96727EE9134C471F75F5DF8DAFDB63DD847",
        "1115CEAF64DF6088FECA4049054B1E6D70A93287D82F311D",
        "D306A720D34FB8A6CE0A5051115F18A348C97907DC8FCB77",
        "D16A554B167743861D0568DE99991A33901A12AA49150E1B",
        "B8B769967A7C6DC1CB89F73763E498FEB1560CE893C9C2FA",
        "42D1182AB4F87539C44AB4485659EA6565D02CA514086973",
        "B365AB3DCC91FC212E035BF7B5DA957873093C4A2E2BE2D7",
        "2C174EFBA9D01044ACC110667471A4E40C24980BE7BED515",
        "B491EC55FE3AB57BB3051B9B92C71253885C519D2ADCD222",
        "3FE05AAED1CEF11FE989BCCFEC41EAADA3C843EA34CCBBEF",
        "EBE6130C3126168FA7587E92EE3E73E36D2980A3A7AFDEC8",
        "5F807E7D44A1F9329CA95E3B59AD683B4792422303F5E797"
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W1
    private static string[] LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W1 =
    {
        "",
        "B33BC283128FED0FD88C0DB2628B46120602A2252D602C90", 
        "53F464D25CAE5D00D55BA43A8C052191CB3E77221A99073B", 
        "E7F5D87282FB96146CD5D7C0F3CA6970AD680C381EE26516", 
        "70BC96E3DEBC40F12B22A7C0B4DC5013557961A168A40DBF", 
        "34EA22F210E25880DE2E784F41A8901F636DECFF4B066BDA", 
        "8D9D5ABC2569C6144E6E9297FED677322A4FC84AFFB70171", 
        "6344A442CA6C2358A2CBC7F4DD9AB6AAFE68F7DD5F8EB2A4", 
        "D103E79BBD5BBEDDDCF90B6A2A8EF6E34F2281E31DFCA0CE", 
        "2E1B745FC647512178047DDE31688DFC373671DD0BB82846", 
        "215640F3F9EB02E9986CF1E78F8C0030890C2C9764A4674C", 
        "B05D4369063824A282171B8FB3A655FA98EC5C96C9376021", 
        "57545051A50D1B06DAEB506BCCDA5CE19A752DE4F7866742", 
        "914B3AF7A0C119B6359760CE353C8B0900A263EF042845C0", 
        "A6A2E1103C2F40FF895655DE321A1BAFB4C18103E78E7027", 
        "E308ED5626B90B31D5784E556CECF553524190295447297B", 
        "BD2FFFF9D8BEE16D16E12773E4DF1FDE4508585EC504D69D", 
        "396017AFAB25F01F484F20910C368FBCE387E5A87FD17AF7", 
        "0E0D83593BF36FF1EB89458DC716B5F4118BCAA6149A9A9A", 
        "5D81DC862D77945395CE9800A1A44EFA3D85EB98DB91A40E", 
        "C2C2384CF7099EA243CCC0D50C4633F790A5FA7F412097B3", 
        "35F37AD2171CA4184BC55D68AA39DA413C542AFA83327493", 
        "5735B82055412843A641A81008A3CC647498E96288C52A58", 
        "787A326837CD7D6CE52A17DB751A88AAAA455F1FDA7FAC1E", 
        "D705C8BCAFA7F865BA75CC3D01FEE77C0913508BA406C77A", 
        "43B97E6E8DF05A20BEB03AC881B534E7B7A9D1348AAF941C", 
        "61301886454716D835011A4B7E52E7CAFEE8BA5A0EEE0F46", 
        "E18E1921A1DC9DA42971F083F6DC84FAD912EA3C68A8D65D", 
        "A6D2905D176B9DD209314361673F4D7D113BCDEFA5B03C57", 
        "D1AE9F6EF187730404ECA55C0623EAC2DBC3310CD1B44471", 
        "6F0C93B8C0503C430214E89E086C22EA863917BB9ECDA49D", 
        "88234300C34D670B49630FB4D0ED5DCFCA19D1DFF13283F9", 
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W2
    private static string[] LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W2 =
    {
        "",
        "96F5372205FCC4C40E87A1A26A7706BA01E3AC0A7A6EF538", 
        "C2348D3EBD5F95C614D175793C85450B8C5A75C9C74364A8", 
        "ADC14496D98603723E7FECA37B01B699335B587448413FBD", 
        "9098108464EFBCD4D3024CB15F74EDEE359D897BB8C64F81", 
        "7CFBC2E208D5B0DC8DF77E022ACAE4BADAF4F3D45C7FA15C", 
        "0FE1C03F2DC3B3EFA352CBCD6E552C5EE217A7E4F06256BE", 
        "2ACB49473620F28A8991664FEE807EB4B46FB4F21B93510A", 
        "03D2FCA37DC01F9878F12647F4BCA6CB36DE1A879DD0C1AC", 
        "40F77B0A6E8AC84A09EACB16261D2F3C6DE5C82F983114B4", 
        "A5EBA476B92E1ECDB132D2B5EEA2D1DC3CA81EC3F2FAFB3E", 
        "71DAFC4B160738915DBF4D3E6154F30140AF6CCC2A80C5F0", 
        "6883CBB7AAC5DA79D70E3BEC4E86CC64A72E6C66776A4EB7", 
        "BA6DC0B5B8A4E4F15C14EDC07E5A54711F62655FBF1B076A", 
        "BB82AE3112875B7BB1302740E599E999C7441B717608343E", 
        "7B4F009E91E8DF595FCAD2B45DAC34A59F73222CEC138314", 
        "99FE9163ED2E62F909F66292093C86FAEE981F8D2BE740A3", 
        "DFEBBBD32A280997BF716FDCDFA94B43E87C1DC3C3C9E7B8", 
        "5123D34CE7F38DEF536242E5604F2DC8DF2FC98B56F38B6A", 
        "030F27F7B6B2002B60D3DFF38F52BDC5F1ADA16FFED7C10B", 
        "7B323B17C0FACCB4CF42AC28854F2104ACA45C929C59C0E2", 
        "A69C21A4D475A6E77149AE8070F54ECFFEDFF646F66E4BB7", 
        "CF98717F0CA0529CD5665B960C262808FCFF9CEE43CA2AE0", 
        "DA45D7410ABFCB202AF7D5562D5E72140643DF266B50BD20", 
        "807EDB27BC5FA4C7382038A790DA2354E1479096352B7892", 
        "8B53C649A69683D3CCC3DAA49D788F1A7D2E7E4324339B94", 
        "8A1EA8DD26A66FF9B803E2ED2F3FD8BA1004093FD7079247", 
        "7DC777D93492FA4380A8E01C6ABC0D57871B3ACB35CC7881", 
        "61BB038174B4E287D915A6776301F7FBE979BCA10DB5B4A1", 
        "732120AE15AD47D680208ADCC285604B7C83F235B753D5DD", 
        "4CC16015B64775BAA4F233CB80D2F232CEBA958E00039E02", 
        "6A1D7CE1DE722FAC35CE41D04C6CC3860ACB6C28A2C6F6CD", 
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W4
    private static string[] LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W4 =
    {
        "",
        "4AC3BAA9186043FA39F68DBB1DFDC09F0569282ADD771AD0", 
        "20510A42674FBB0232E9C63596E9ED2BDDCC07BAF9BA1F38", 
        "5D69ACE4FD7086CDEA8A60AED1D8C663F0E086F2E7615C2F", 
        "A8A0D92CCD802986B06099DEBE178B93276D2610F532C5F6", 
        "295C2D4DBF060C686E0FCC088719B4BF7E4BF098CD9C5B63", 
        "36B17C6559A2461747C9038847D9625EFCB5FAEA1C1DBF20", 
        "5C7513685F36D94F272B6EAD56629F6AFFDE6661104849F1", 
        "70CC6C9F020AE4F4616213C3C48C09F4B2D80DB69CB3035D", 
        "21D77E0138FA39EC5F719E23C6D0CABD298657C60DC2A58D", 
        "001F014EE9BAEB41DFEB491A71A677415F730513D71AD398", 
        "677332BC45A999A372135E2C631D46022B8A94480C132B13", 
        "31DE684A517B96B5E061B0770E06B1BB1DB5EE1ACF2DC6A1", 
        "2086BB2738F3FCBC66D41A77985B73D11401CFE3BEEA05DF", 
        "963A2980DFD3B782F18972E4903BF15C345DC1B7F536D5A4", 
        "F113BA0412747E29C6E6171E82E3DA234D121DD448AB1064", 
        "8D9EA4F00B3A2480D2F81EC2A9457C7490E2DE69E7F7B835", 
        "9B0546AE784BB63DDC2AE63A990CAD3D033DFAF4C224C6B0", 
        "BDC262B0800C70B68EC6117692A0BC1C8461A82A1E38C2A2", 
        "70ADAB8B5423D35185BD2A2350584D3DB521FE5D580169FA", 
        "4209C86FD70A922590688A904929E161B01B2F26EFD72B3E", 
        "E66EDCDCF3CFCFFA404EB5D0E85CD5146EF6AEDE28A7CF88", 
        "3ABE7B3C2329F3A603F46E771D18C7E05F48CD5B9CD040EC", 
        "A6F909C28C402A95ADE40195669565B27D907E8825CA998E", 
        "BF6643E49DD3E214877C9E24B562BDCDBFA6B75B843CAB30", 
        "5399336F3C6C23A34FB8BF17699A0AE8C2A8A57DE552A1B8", 
        "C21FE695A8C6C5E9C0F0EDFB136A0F6754784A2B3C9264A7", 
        "CF8EB012187B66B6C7E3F0B61F0FC9FA514985BBFBFB9CAA", 
        "5D9986D0B16988C20F60A03D44EAD500B62BD3471BA41AD8", 
        "26B9960EB9E5A3D22365C1745078EA57BF597FFB23461781", 
        "761EA0FCFCF1E5F3163F670F86CB47AE83DA8725D5CEBBCC", 
        "AE00275DC928AA9AE451E30A01CB8286FE2927B4655103DC", 
    };
    #endregion
    
    #region Precomputed LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W8
    private static string[] LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W8 =
    {
        "",
        "6ECAE46757563E94E817B3BD4260FB3D00FD98A18BFA726C", 
        "F278A5FA297C53D946B0B235EA6C3DE7CDDCC8BE6E8A64F2", 
        "F8B24AF1AA07DEECD06C0A22294BD923C636DE45B682CA43", 
        "3C0D02C029DB586E983E6ED30A447C59B4CBDF22A460C224", 
        "37C5BBAC5C39AD85489125AE53AC6D526803EB33DB4C7AA0", 
        "FB0DC270C33DE99DB5E3D0E08CF4E7A494F68AA068BBA6F6", 
        "29529B8A25CD182A08F7D42D5D088F1C1804378C63AA3E7E", 
        "BF8FC577FB52894A7A0D224BCB3448E57A7BDD2AE7CD2282", 
        "75CACC448900F3569D15F35466FBDD181BA28ACABF416D62", 
        "A8072EE50E474241C7932FCD2744530761CD73E3FB8D0DF9", 
        "64E6E4151FDB567E6C4C2DD80692C259877B9A9FBE2A3CF3", 
        "F7F3579B580A16B50740755D0D5951E9E2C3AE1B937BBA5C", 
        "355D579F831D97390BDE35CA04A93E42CFC7189D75EAE7BE", 
        "F8D3D62D5CF24251B13705B726F3A6B690618839BB9F2A5A", 
        "D6608857E380C14D5396E58F8EE7238B6E60782C5222A397", 
        "F729B9F46BED586A479E124C195D79BA918A7712EC303892", 
        "DDD5A5AB4C3B20CA7BEB31AECD03FC33F371CF77536E5C76", 
        "13ED7F33B427E7E51DB56793183BCD6D6F4140CD41B81237", 
        "D9864400A925B1BC5D5BDE2D5963349279FE7863275E486D", 
        "B15872ADB4122BE7FBAA76A5C9318EEEEFB4B1CEC1ACCF89", 
        "0733D8EDAF1373F99E0412F3F50AF2CB049A5DDD4DDA5EF6", 
        "AB324F6B8871733EE7064B05ACC5120655D87A0ABF314888", 
        "8AF5E1C7974C1DBAC539B8E8E8A2430100A6E140312DA95F", 
        "D07F7D73496E2A3179F2BAD8EF2E7E4508E50D6E743985DD", 
        "147C06F6F1D5DBB8234A6F71541656957BE52BFAFB210155", 
        "79D1BE8270F006D6CD02AC78925EBE68D51E7372B600D0A2", 
        "A9848A77ED0B1FFA045637375A6BF0B66F1592B151793CD9", 
        "EBACDBA924F182671F2ACD46301D5221FCC9502635EB0BE4", 
        "C91DBB6540FEA4BC0A29B5F551A0C0C2F839BAAAAA1066CC", 
        "957C98776208D614BC128722E9F11B0CEFCE4FD94ACD8FC0", 
        "D5045D56815813F05C85F812AFC750729071DEA974C7B16E", 
    };
    #endregion

    public static LmsKeyPair GetPrecomputedTreeFromFile(LmsMode lmsMode, LmOtsMode lmOtsMode, byte seedLastOctet, string filePath)
    {
        var lmsAttribute = AttributesHelper.GetLmsAttribute(lmsMode);
        var lmOtsAttribute = AttributesHelper.GetLmOtsAttribute(lmOtsMode);

        var seed = new byte[24];
        seed[23] = seedLastOctet;
        
        using StreamReader s = new StreamReader(filePath);
        var publicKeyHex = s.ReadLine()?.Split(":").Last();
        var publicKey = new LmsPublicKey(lmsAttribute, new BitString(publicKeyHex).ToBytes());

        List<string> treeStrings = new List<string>();
        var nodeCount = 0;
        while (s.ReadLine() is { } line)
        {
            var lineSplit = line.Split(":");
            nodeCount = Int32.Parse(lineSplit.First());
            treeStrings.Add(lineSplit.Last().Trim());
        }

        var height = (int)System.Math.Log2(nodeCount + 1) - 1;
        
        var tree = GetTreeFromStrings(treeStrings.ToArray());
        var privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], seed, 0, height, tree);

        return new LmsKeyPair
        {
            LmsAttribute = lmsAttribute,
            LmOtsAttribute = lmOtsAttribute,
            PublicKey = publicKey,
            PrivateKey = privateKey
        };
    }
    
    public static LmsKeyPair GetPrecomputedTree(LmsMode lmsMode, LmOtsMode lmOtsMode)
    {
        var lmsAttribute = AttributesHelper.GetLmsAttribute(lmsMode);
        var lmOtsAttribute = AttributesHelper.GetLmOtsAttribute(lmOtsMode);
        byte[][] tree;
        LmsPrivateKey privateKey = null;
        
        switch (lmsMode, lmOtsMode)
        {
            case (LmsMode.LMS_SHA256_M24_H5, LmOtsMode.LMOTS_SHA256_N24_W1):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W1);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 5, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000A000000050000000000000000000000000000000006CCA7E073DC8AC11026D556B093959C4B6BB93ACF20DA14").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H5, LmOtsMode.LMOTS_SHA256_N24_W2):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W2);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 5, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000A0000000600000000000000000000000000000000E18398500F622E709F9EFF1DC764620907883244C9C8AD8A").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H5, LmOtsMode.LMOTS_SHA256_N24_W4):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W4);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 5, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000A0000000700000000000000000000000000000000459C06A56BBC5101B67214C1928B9F7A4AC000506F7EAF22").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H5, LmOtsMode.LMOTS_SHA256_N24_W8):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H5_LMOTS_SHA256_N24_W8);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 5, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000A0000000800000000000000000000000000000000F4541C138D18DB2BB752D93163B8DEEBB4E4C3311035EB8C").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H10, LmOtsMode.LMOTS_SHA256_N24_W1):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W1);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 4, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000B0000000500000000000000000000000000000000B33BC283128FED0FD88C0DB2628B46120602A2252D602C90").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H10, LmOtsMode.LMOTS_SHA256_N24_W2):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W2);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 4, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000B000000060000000000000000000000000000000096F5372205FCC4C40E87A1A26A7706BA01E3AC0A7A6EF538").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H10, LmOtsMode.LMOTS_SHA256_N24_W4):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W4);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 4, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000B00000007000000000000000000000000000000004AC3BAA9186043FA39F68DBB1DFDC09F0569282ADD771AD0").ToBytes())
                };
            
            case (LmsMode.LMS_SHA256_M24_H10, LmOtsMode.LMOTS_SHA256_N24_W8):
                tree = GetTreeFromStrings(LMS_SHA256_M24_H10_LMOTS_SHA256_N24_W8);
                privateKey = new LmsPrivateKey(lmsAttribute, lmOtsAttribute, new byte[16], new byte[24], 0, 4, tree);
                return new LmsKeyPair
                {
                    LmsAttribute = lmsAttribute,
                    LmOtsAttribute = lmOtsAttribute,
                    PrivateKey = privateKey,
                    PublicKey = new LmsPublicKey(lmsAttribute, new BitString("0000000B00000008000000000000000000000000000000006ECAE46757563E94E817B3BD4260FB3D00FD98A18BFA726C").ToBytes())
                };

            default:
                throw new NotImplementedException();
        }
    }
    
    private static byte[][] GetTreeFromStrings(string[] treeStrings)
    {
        var tree = new byte[treeStrings.Length][];
        for (var i = 1; i < treeStrings.Length; i++)
        {
            tree[i] = new BitString(treeStrings[i]).ToBytes();
        }

        return tree;
    }
}
