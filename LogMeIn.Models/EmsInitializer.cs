namespace Tests;

public class EmsInitializer
{
    public static List<TypKocky> Initialize()
    {
        /**
         * b
         * Jedno malé písmeno kódu zbarvení srsti
         * Kód zbarvení srsti se neuvádí u plemen uznaných pouze v jediném zbarvení srsti, např. Ruská modrá [RUS] a Kartouzská kočka [CHA], povinný je naopak všude tam, kde slouží k rozlišení barevných variet, např. Britská modrá [BRI a]. Obecně rozeznáváme zbarvení:
            1.	10 odstínů základního zbarvení: [kódy n, a, b, c, d, e, o, p]
            2.	 6 odstínů želvovinového zbarvení [kódy f, g, h, j, q,r]
            3.	 1 zbarvení bílé [kód w]
            Konkrétní odstín zbarvení kočky se u daného plemene může lišit zejména vlivem stupně depigmentace: kupř. u siamské kočky se zbarvení černé mění na zbarvení s tmavohnědými odznaky (seal-point), u barmské kočky se zbarvení černé mění na zbarvení hnědé atd. Kódy zbarvení srsti jsou uvedeny v tabulce 3.
            Bílé zbarvení je u kočky zbarvením dominantním, které navíc působí epistaticky, takže maskuje projev jakéhokoliv pigmentu v srsti. Naopak kočka s bílou skvrnitostí má vždy v srstním pokryvu alespoň malou část plně pigmentovanou.
             Písmenem „x“ se nahrazuje písmeno označující konkrétní zbarvení, nelze-li zbarvení zjistit. V případě, že pro dané plemeno není konkrétní zbarvení srsti povoleno, před kód zbarvení srsti se někdy předsazuje malé písmeno „x“.
         */
        var n = new Record
        {
            EMS_CODE = "n",
            CodeInCzech = new List<string>
            {
                "černá", "černý", "základní neředěná", "seal", "ruddy", "s červenohnědými odznaky", "černohnědý",
                "červenohnědá", "divoce zbarevená"
            }
        };
        var a = new Record
        {
            EMS_CODE = "a",
            CodeInCzech = new List<string>
            {
                "modrá", "modře ředěná", "modrý", "modře ředěný", "s modrými odznaky", "s modrými",
                "čokoládová želvovinová"
            }
        };
        var b = new Record
        {
            EMS_CODE = "b",
            CodeInCzech = new List<string>
            {
                "čokoládová", "čokoládové ředěná", "čokoládový", "čokoládově ředěný", "čokoládovobílá", "s čokoládovými"
            }
        };
        var c = new Record
        {
            EMS_CODE = "c",
            CodeInCzech = new List<string> { "lilová", "souběh modrého a čokoládového ředění" }
        };
        var d = new Record
            { EMS_CODE = "d", CodeInCzech = new List<string> { "červená", "červený" } };
        var e = new Record
            { EMS_CODE = "e", CodeInCzech = new List<string> { "krémová", "krémový", "krémový" } };
        var f = new Record
        {
            EMS_CODE = "f",
            CodeInCzech = new List<string>
            {
                "želvovinová", "černě želvovinová", "želvovinový", "černě želvovinový", "černý želvovinový",
                "černá želvovinová"
            }
        };
        var g = new Record
        {
            EMS_CODE = "g",
            CodeInCzech = new List<string>
            {
                "modře želvovinová", "modrokrémová", "modře želvovinový", "modrý želvovinový", "modrá", "krémový",
                "modrá želvovinová"
            }
        };
        var h = new Record
        {
            EMS_CODE = "h",
            CodeInCzech = new List<string>
                { "čokoládově želvovinová", "čokoládově želvovinový", "čokoládová želvovinová" }
        };
        var j = new Record
        {
            EMS_CODE = "j",
            CodeInCzech = new List<string> { "lilově želvovinová", "lilově želvovinový", "lilová želvovinová" }
        };
        var o = new Record
        {
            EMS_CODE = "o",
            CodeInCzech = new List<string>
                { "skořicová", " červenohnědá", "sorrel", "cinnamon", "skořicový, červenohnědý" }
        };
        var p = new Record { EMS_CODE = "p", CodeInCzech = new List<string> { "plavá", " fawn" } };
        Record q = new()
            { EMS_CODE = "q", CodeInCzech = new List<string> { "skořicově želvovinová", "skořicově želvovinový" } };
        var r = new Record
            { EMS_CODE = "r", CodeInCzech = new List<string> { "plavě želvovinová", "plavě želvovinový" } };
        var w = new Record { EMS_CODE = "w", CodeInCzech = new List<string> { "bílá", "dominantně bílá", "bílý" } };
        var x = new Record
            { EMS_CODE = "x", CodeInCzech = new List<string> { "neuznané", "neidentifikovatelné zbarvení" } };
        var vaar = new Record
        {
            EMS_CODE = "var",
            CodeInCzech = new List<string> { "označení krátkosrsté kočky nesoucí genetickou vlohu pro dlouhosrstost" }
        };
        var zbaerveniSrsti = new List<Record> { n, a, b, c, e, d, e, f, g, h, j, o, p, q, r, w, x, vaar };

        /*
         c
         * Jedno malé doplňkové písmeno kódu depigmentace srsti (tipingu)
         * Kód depigmentace srsti (tipingu) se uvádí pouze tam, kde má smysl. Obecně rozeznáváme depigmentaci srsti v odstínu:
           1.	stříbřitém [doplňkový kód s]
           2.	zlatém [doplňkový kód y]
           Kódy depigmentace srsti jsou uvedeny v tabulce 4A. Není-li doplňkový kód konkretizován dvojčíslím kódu depigmentace srsti, jde o tiping kouřový. Například: „BRI ns“= britská černá stříbřitě kouřová, „BRI ns 12“= Britská černá stříbřitě stínovaná.
         */
        var s = new Record
            { EMS_CODE = "s", CodeInCzech = new List<string> { "stříbřitém", "stříbřitě", "stříbřitá" } };
        var y = new Record
        {
            EMS_CODE = "y", CodeInCzech = new List<string> { "zlatém" }
        };

        var kodDepigmentaceSrsti = new List<Record> { s, y };


        /**
         * Dvojčíslí skupinových kódů exteriérových znaků:
         * Dvojčíslí skupinových kódů se uvádějí tam, kde jsou pro úplnou identifikaci kočky zapotřebí. Řadí se vzestupně a oddělují mezerou. Podrobněji definují další exteriérové vlastnosti, např. bílou skvrnitost (tabulka 4B.), stupeň depigmentace (tabulka 4C.), typ kresby v srsti (tabulka 4D.), snížení intenzity pigmentace srsti (tabulka 4E.), stupeň zkrácení ocasu (tabulka 4F.) a zbarvení očí (tabulka 4G.).
         */

        /**
         *e
         *
         * Kódy bílé skvrnitosti: 01, 02, 03, 04, 09
         * Kódy bílé skvrnitosti vyjadřují počet, velikost a umístění bílých skvrn v srsti. Rozeznáváme:
        1.	bílou skvrnitost typu „van“ [kód 01]
        2.	bílou skvrnitost typu „harlekýn“ [kód 02]
        3.	bílou skvrnitost typu „bikolor“ [kód 03]
        4.	bílou skvrnitost typu „mitted“ [kód 04]
        5.	bílou skvrnitost nespecifikovanou [kód 09]
        Typy bílé skvrnitosti 1., 2. a 3. se v zásadě liší počtem, t.j. velikostí a rozsahem bílých skvrn a zařazení kočky do příslušného typu se řídí standardem plemene konkrétní kočky.
        Typ bílé skvrnitosti 4. označuje bílé skvrny, jejichž výskyt je typický pro specielní plemena, např. Ragdol [RAG] nebo Birma [SBI[. Bílá skvrnitost typu 4. je obvykle vázána na umístění bílých skvrn v přesně určených, t.zv. predilekčních místech povrchu těla, např. ve formě bílých „ponožek“ na tlapkách.
        Pro bílé skvrny, umístěné na krku, t.zv. „medailónek“ není kód stanoven, protože takto umístěné bílé skvrny jsou zpravidla pokládány za vadu, naopak bílé skvrny na bradě u koček t.zv. „divokého zbarvení“ jsou obvykle tolerovány, protože jde o typický plemenný znak.
        Typ bílé skvrnitosti 5. označuje nespecifikovanou bílou skvrnitost u plemen, u nichž je povolena bez omezení, např. kočka mainská mývalí [MCO], norská lesní [NFO] a sibiřská {SIB].
Vždy platí, že dvojčíslí kódu bílé skvrnitosti se uvádí pouze tehdy, neplyne-li přímo ze standardu plemene, proto se např. neuvádí u birmy [SBI].

         */
        var s_01 = new Record { EMS_CODE = "01", CodeInCzech = new List<string> { "van" } };
        var s_02 = new Record { EMS_CODE = "02", CodeInCzech = new List<string> { "harlekýn" } };
        var s_03 = new Record { EMS_CODE = "03", CodeInCzech = new List<string> { "bikolor" } };
        var s_04 = new Record { EMS_CODE = "04", CodeInCzech = new List<string> { "mitted", "s odznaky" } };
        var s_09 = new Record
            { EMS_CODE = "09", CodeInCzech = new List<string> { "bílou skvrnitost nespecifikovanou", "" } };
        var kodyBileSkrrvrnitosti = new List<Record> { s_01, s_02, s_03, s_04, s_09 };

        /*
         * Kódy stupně depigmentace srsti (tipingu): 11, 12
         * Kódy označující stupeň depigmentace (tipingu) jsou vázány na plemena, u nich je uplatněn doplňkový kód označující stříbřitý nebo zlatý tiping (viz poznámka c.).
           Depigmentaci rozeznáváme :
           1.	stínovaná (shaded) [11], nižší stupeň depigmentace, při němž je jednotlivý chlup zbaven pigmentu zhruba v 1/3 své délky od kořínku
           2.	závojová (shell) [12], vyšší stupeň depigmentace, při němž je jednotlivých chlup zbaven pigmentu zhruba v 7/8 své délky od kořínku, takže zbarven je pouze koneček chlupu. Depigmentace se mění podle tělesných partií a podle kresby v srsti. U závojové kočky depigmentací vzniká tak velký kontrast, že se černě pigmentovaná kočka může jevit jako bílá.
           Depigmentace se kromě toho menší měrou projevuje u zvířat s kresbou a zvířat jednobarevných bez kresby.

         */
        var x_11 = new Record { EMS_CODE = "11", CodeInCzech = new List<string> { "stínovaná" } };
        var x_12 = new Record { EMS_CODE = "12", CodeInCzech = new List<string> { "závojová" } };
        var kodyStupnedepigmentace = new List<Record> { x_11, x_12 };


        /*
         g

         Kódy typu kresby v srsti: 21, 22, 23, 24, 25
         * Kódy kresby v srsti vyjadřují konkrétní typ kresby v srsti kočky. Rozlišuje se:
           1.	srst zcela bez kresby (non- aguti), bez kódu
           2.	srst s kresbou nespecifikovanou [kód 21], obecný kód pro jakoukoli kresbu, kterou nelze přesně identifikovat pro nejasnost či neúplnost a pro typické žíhání siamské kočky
           3.	srst s kresbou mramorovanou (blotched) [kód 22]
           4.	srst s kresbou tygrovanou (mackerel) [kód 23]
           5.	srst s kresbou tečkovanou (spotted) [kód 24]
           6.	srst s tikingem (ticked tabby) [kód 25]. Srst s tikingem je současně  projevem kresby typickým pro habešské kočky a současně projevem zonálního zbarvení chlupu. Chlupy jsou po své délce proužkovány střídáním silněji a slaběji pigmentovaných zón.
           U červených a krémových odstínů zbarvení srsti bývá často problematické jednoznačně určit, zda kočka má či nemá v srsti kresbu správně a plně vyjádřenu, proto ani kód EMS zde nemusí vždy být plně směrodatný.

         */
        var x_21 = new Record
        {
            EMS_CODE = "21",
            CodeInCzech = new List<string>
            {
                "srst s nespecifikovanou kresbou nebo se žíháním", "žíhovanými odznaky", "žíhanými odznaky",
                "s nepecifikovanou kresnou", "s nespecifckou kresbou", "s kresbou", "a kresbou"
            }
        };
        var x_22 = new Record
            { EMS_CODE = "22", CodeInCzech = new List<string> { "mramorovaná", "mramorovaná s bílou" } };
        var x_23 = new Record
            { EMS_CODE = "23", CodeInCzech = new List<string> { "tygrovaná kresby v srsti (mackerel)" } };
        var x_24 = new Record
        {
            EMS_CODE = "24",
            CodeInCzech = new List<string> { "tečkovaná kresba v srsti (spotted)", "tečkovaný", "tečkovaná" }
        };
        var x_25 = new Record
            { EMS_CODE = "25", CodeInCzech = new List<string> { "kresba (a zbarvení) s tikingem (ticked tabby)" } };
        var kodTypuKresbVSrsti = new List<Record> { x_21, x_22, x_23, x_24, x_25 };

        /**
         * h
         * * Kódy snížené intenzity pigmentace srsti: 31, 32, 33¨
         * Kód snížené intenzity pigmentace je charakteristický pro plemennou skupinu barmských [kód 31] a siamských [kód 33[ koček, pro birmy [kód 33] a pro neuznané tonkinské kočky [kód 32]. Rozlišují se tři stupně zesvětlení:
1.	barmské zesvětlení- depigmentace (burmese) [kód 31] způsobuje mírné zesvětlení barevných odstínů, z nichž nejmarkantnější je zesvětlení z černé na (barmsky) hnědou
2.	tonkinská depigmentace (tonkinese, tonkanese) [kód 32] způsobuje střední zesvětlení barevných odstínů, kompromisně mezi typem 1 a 3
3.	siamská depigmentace (siamese)- zbarvení s odznaky- [kód 33] způsobuje silné zesvětlení barevných odstínů, při čemž výrazně zbarveny zůstávají pouze koncové části těla, t.zv. „odznaky (points)“, kdežto ostatní plochy srsti jsou ledově bílé. Siamské zesvětlení je typickým projevem akromelanismu.
Kód se uvádí pouze u těch plemen, kde jej jej třeba k úplné identifikaci, zásadně se vypouští u kódového označení koček barmských, siamských, balinéských a u birem, kde je pokládán za samozřejmý

         */
        var x_31 = new Record { EMS_CODE = "31", CodeInCzech = new List<string> { "barmské zesvětlení" } };
        var x_32 = new Record { EMS_CODE = "32", CodeInCzech = new List<string> { "tonkinská depigmentac" } };
        var x_33 = new Record { EMS_CODE = "33", CodeInCzech = new List<string> { "siamská depigmentace" } };
        var kodSnizenePigmentace = new List<Record> { x_31, x_32, x_33 };


        /**
         * Kódy stupně zkrácení ocasu (u Manxe): 51, 52, 53, 54
         * Kód stupně zkrácení ocasu je vyhrazen do plemeno Manx [MAN]. Pro ostatní plemena včetně Japonského bobtaila [JBT] je bez významu. U plemene Manx se často vypouští kód skutečného zbarvení, protože zbarvení srsti je pokládáno na bezvýznamné.
         */
        /*
         Tři velká písmena kódu plemene
         Označení plemene, pokud je známo, je povinné. K označení neurčeného plemene se obecně užívá znaku „X“, k označení neuznaného (neurčeného) dlouhosrstého nebo polodlouhosrstého plemene se užije kód „XLH“, k označení neuznaného (neurčeného) krátkosrstého plemene se užije kód „XSH“. Alternativní označení „non-LH“ a „non-SH“ se nepoužívá. Rozlišují se:
           1.	plemena koček ve FIFe uznávaná
           2.	plemena koček ve FIFe (dosud anebo natrvalo) neuznávaná
           Kódy uznaných i neuznaných plemen koček jsou uvedeny v Registračním řádu FIFe (vydáno v češtině). Kódy plemen koček jsou uvedeny v tabulce 2.
         */
        var x_51 = new Record { EMS_CODE = "31", CodeInCzech = new List<string> { "Manx rumpy- bezocasý" } };
        var x_52 = new Record
            { EMS_CODE = "32", CodeInCzech = new List<string> { "Manx rumpy riser- nepatrně prodloužená páteř" } };
        var x_53 = new Record { EMS_CODE = "33", CodeInCzech = new List<string> { "Manx stumpy- ocasní pahýl" } };
        var x_54 = new Record { EMS_CODE = "33", CodeInCzech = new List<string> { "Manx longie- normální ocas" } };
        var kodZkraceniOcasu = new List<Record> { x_51, x_52, x_53, x_54 };


        /**
         * Kódy zbarvení očí: 61, 62, 63, 64, 65, 66, 67
         *
         * Kódy zbarvení očí se uvádějí pouze u těch plemen koček, u nichž jsou ve vazbě na zbarvení srsti povoleny různé barvy očí. U plemen, kde je povolena jediná barva očí, se kód neuvádí.46
         */
        var x_61 = new Record { EMS_CODE = "61", CodeInCzech = new List<string> { "modré oči" } };
        var x_62 = new Record
        {
            EMS_CODE = "62",
            CodeInCzech = new List<string>
            {
                "oranžové oči", "oranžovooká", "a oranžovými očima", "s oranžovýma očima", "a s oranžovýma očima",
                "a oranžovýma očima"
            }
        };
        var x_63 = new Record
        {
            EMS_CODE = "63", CodeInCzech = new List<string>
            {
                "nestejně zbarvené oči (odd eyes): jedno oko modré, druhé oranžové)"
            }
        };
        var x_64 = new Record { EMS_CODE = "64", CodeInCzech = new List<string> { "zelené oči", "zelenooká" } };
        var x_65 = new Record { EMS_CODE = "65", CodeInCzech = new List<string> { "barmsky žluté oči" } };
        var x_66 = new Record { EMS_CODE = "66", CodeInCzech = new List<string> { "tonkinsky tyrkysové oči" } };
        var x_67 = new Record { EMS_CODE = "67", CodeInCzech = new List<string> { "siamsky modré oči" } };
        var kodZbarveniOci = new List<Record> { x_61, x_62, x_63, x_64, x_65, x_66, x_67 };


        var x_81 = new Record { EMS_CODE = "81", CodeInCzech = new List<string> { "dlouhá srst", "dlouhosrstý" } };
        var x_82 = new Record { EMS_CODE = "82", CodeInCzech = new List<string> { "krátká srst", "krátkosrstý" } };
        var x_83 = new Record { EMS_CODE = "83", CodeInCzech = new List<string> { "brush" } };
        var kodsrsti = new List<Record> { x_81, x_82, x_83 };

        var kocky = new List<TypKocky>();

        Record aby = new() { EMS_CODE = "ABY", CodeInCzech = new List<string> { "Habešská kočka", "Habešská" } };
        var aby_n = new Storage(aby, status.valid);
        var kocka_aby = new TypKocky(
            aby_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_aby);


        Record ACL = new() { EMS_CODE = "ACL", CodeInCzech = new List<string> { "Americký curl dlouhosrstý́" } };
        var ACL_n = new Storage(ACL, status.valid);
        var kocka_ACL = new TypKocky(
            ACL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_ACL);

        Record ACS = new() { EMS_CODE = "ACS", CodeInCzech = new List<string> { "Americký curl krátkosrstý" } };
        var ACS_n = new Storage(ACS, status.valid);
        var kocka_ACS = new TypKocky(
            ACS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_ACS);

        Record BAL = new() { EMS_CODE = "BAL", CodeInCzech = new List<string> { "Balinéská kočka", "Balinéská" } };
        var BAL_n = new Storage(BAL, status.valid);
        var kocka_BAL = new TypKocky(
            BAL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BAL);

        Record BEN = new() { EMS_CODE = "BEN", CodeInCzech = new List<string> { "Bengálská kočka", "Bengálská" } };
        var BENL_n = new Storage(BEN, status.valid);
        var kocka_BEN = new TypKocky(
            BENL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BEN);

        Record BLH = new()
            { EMS_CODE = "BLH", CodeInCzech = new List<string> { "Britská dlouhosrstá kočka", "Britská dlouhosrstá" } };
        var BLH_n = new Storage(BLH, status.valid);
        var kocka_BLH = new TypKocky(
            BLH_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BLH);

        Record BML = new() { EMS_CODE = "BML", CodeInCzech = new List<string> { "Burmilla" } };
        var BML_n = new Storage(BML, status.valid);
        var kocka_BML = new TypKocky(
            BML_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BML);

        Record BSH = new()
            { EMS_CODE = "BSH", CodeInCzech = new List<string> { "Britská krátkosrstá kočka", "Britská krátkosrstá" } };
        var BSH_n = new Storage(BSH, status.valid);
        var kocka_BSH = new TypKocky(
            BSH_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BSH);

        Record BUR = new() { EMS_CODE = "BUR", CodeInCzech = new List<string> { "Barmská kočka", "Barmská" } };
        var BUR_n = new Storage(BUR, status.valid);
        var kocka_BUR = new TypKocky(
            BUR_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_BUR);

        Record CHA = new() { EMS_CODE = "CHA", CodeInCzech = new List<string> { "Kartouzská kočka", "Kartouzská" } };
        var CHA_n = new Storage(CHA, status.valid);
        var kocka_CHA = new TypKocky(
            CHA_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_CHA);

        Record CRX = new() { EMS_CODE = "CRX", CodeInCzech = new List<string> { "Cornish rex" } };
        var CRX_n = new Storage(CRX, status.valid);
        var kocka_CRX = new TypKocky(
            CRX_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_CRX);

        Record CYM = new() { EMS_CODE = "CYM", CodeInCzech = new List<string> { "Kymerská kočka", "Kymerská" } };
        var CYM_n = new Storage(CYM, status.valid);
        var kocka_CYM = new TypKocky(
            CYM_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_CYM);

        Record DRX = new() { EMS_CODE = "DRX", CodeInCzech = new List<string> { "Devon rex" } };
        var DRX_n = new Storage(DRX, status.valid);
        var kocka_DRX = new TypKocky(
            DRX_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_DRX);

        Record DSP = new() { EMS_CODE = "DSP", CodeInCzech = new List<string> { "Donský Sphynx", "donský sphynx" } };
        var DSP_n = new Storage(DSP, status.valid);
        var kocka_DSP = new TypKocky(
            DSP_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_DSP);

        Record EUR = new() { EMS_CODE = "EUR", CodeInCzech = new List<string> { "Evropská kočka", "Evropská" } };
        var EUR_n = new Storage(EUR, status.valid);
        var kocka_EUR = new TypKocky(
            EUR_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_EUR);

        Record exo = new() { EMS_CODE = "EXO", CodeInCzech = new List<string> { "Exotická kočka", "Exotická" } };
        var exo_n = new Storage(exo, status.valid);
        var kocka_exo = new TypKocky(
            exo_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_exo);

        Record GRX = new() { EMS_CODE = "GRX", CodeInCzech = new List<string> { "German rex" } };
        var GRX_n = new Storage(GRX, status.valid);
        var kocka_GRXL = new TypKocky(
            GRX_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_GRXL);

        Record JBS = new()
            { EMS_CODE = "JBS", CodeInCzech = new List<string> { "Japonský bobtail krátkosrstý" } };
        var JBS_n = new Storage(JBS, status.valid);
        var kocka_JBS = new TypKocky(
            JBS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_JBS);


        Record KBL = new()
            { EMS_CODE = "KBL", CodeInCzech = new List<string> { "Kurilský bobtail dlouhosrstý" } };
        var KBL_n = new Storage(KBL, status.valid);
        var kocka_KBL = new TypKocky(
            KBL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_KBL);

        Record KBS = new()
            { EMS_CODE = "KBS", CodeInCzech = new List<string> { "Kurilský bobtail krátkosrstý" } };
        var KBS_n = new Storage(KBS, status.valid);
        var kocka_KBS = new TypKocky(
            KBS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_KBS);


        Record KOR = new() { EMS_CODE = "KOR", CodeInCzech = new List<string> { "Korat" } };
        var KOR_n = new Storage(KOR, status.valid);
        var kocka_KOR = new TypKocky(
            KOR_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_KOR);

        Record LPL = new() { EMS_CODE = "LPL", CodeInCzech = new List<string> { "LaPerm dlouhosrstá" } };
        var LPL_n = new Storage(LPL, status.valid);
        var kocka_LPL = new TypKocky(
            LPL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_LPL);

        Record LPS = new() { EMS_CODE = "LPS", CodeInCzech = new List<string> { "LaPerm krátkosrstá" } };
        var LPS_n = new Storage(LPS, status.valid);
        var kocka_LPS = new TypKocky(
            LPS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_LPS);


        Record MAN = new() { EMS_CODE = "MAN", CodeInCzech = new List<string> { "Manská kočka", "Manská" } };
        var MAN_n = new Storage(MAN, status.valid);
        var kocka_MAN = new TypKocky(
            MAN_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_MAN);


        Record MAU = new() { EMS_CODE = "MAU", CodeInCzech = new List<string> { "Egyptská mau", "Egyptská" } };
        var MAU_n = new Storage(MAU, status.valid);
        var kocka_MAU = new TypKocky(
            MAU_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_MAU);


        Record MCO = new()
            { EMS_CODE = "MCO", CodeInCzech = new List<string> { "Mainská kočka mývalí", "Mainská mývalí" } };
        var MCO_n = new Storage(MCO, status.valid);
        var kocka_MCO = new TypKocky(
            MCO_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_MCO);

        Record NEM = new() { EMS_CODE = "MCO", CodeInCzech = new List<string> { "Něvská maškaráda" } };
        var NEM_n = new Storage(MCO, status.valid);
        var kocka_NEM = new TypKocky(
            NEM_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_NEM);


        Record NFO = new()
            { EMS_CODE = "NEM", CodeInCzech = new List<string> { "Norská kočka lesní", "Norská lesní" } };
        var NFO_n = new Storage(NFO, status.valid);
        var kocka_NFO = new TypKocky(
            NFO_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_NFO);


        Record OCI = new() { EMS_CODE = "OCI", CodeInCzech = new List<string> { "Ocikat", "Ocicat" } };
        var OCI_n = new Storage(OCI, status.valid);
        var kocka_NOCI = new TypKocky(
            OCI_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_NOCI);


        Record OLH = new()
        {
            EMS_CODE = "OLH",
            CodeInCzech = new List<string> { "Orientální kočka dlouhosrstá", "Orientální dlouhosrstá" }
        };
        var OLH_n = new Storage(OLH, status.valid);
        var kocka_OLH = new TypKocky(
            OLH_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_OLH);

        Record OSH = new()
        {
            EMS_CODE = "OSH",
            CodeInCzech = new List<string> { "Orientální kočka krátkosrstá", "Orientální krátkosrstá" }
        };
        var OSH_n = new Storage(OSH, status.valid);
        var kocka_OSH = new TypKocky(
            OSH_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_OSH);

        Record PEB = new() { EMS_CODE = "PEB", CodeInCzech = new List<string> { "Peterbald" } };
        var PEB_n = new Storage(PEB, status.valid);
        var kocka_PEB = new TypKocky(
            PEB_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_PEB);


        Record PER = new() { EMS_CODE = "PER", CodeInCzech = new List<string> { "Perská kočka", "Perská" } };
        var PER_n = new Storage(PER, status.valid);
        var kocka_PER = new TypKocky(
            PER_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_PER);


        Record RAG = new() { EMS_CODE = "RAG", CodeInCzech = new List<string> { "Ragdoll" } };
        var RAG_n = new Storage(RAG, status.valid);
        var kocka_RAG = new TypKocky(
            RAG_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_RAG);


        Record RUS = new() { EMS_CODE = "RUS", CodeInCzech = new List<string> { "Ruská modrá kočka", "Ruská modrá" } };
        var RUS_n = new Storage(RUS, status.valid);
        var kocka_RUS = new TypKocky(
            RUS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_RUS);

        Record SBI = new() { EMS_CODE = "SBI", CodeInCzech = new List<string> { "Birma" } };
        var SBI_n = new Storage(SBI, status.valid);
        var kocka_SBI = new TypKocky(
            SBI_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SBI);

        Record SIA = new() { EMS_CODE = "SIA", CodeInCzech = new List<string> { "Siamská kočka", "Siamská" } };
        var SIA_n = new Storage(SIA, status.valid);
        var kocko_SIA = new TypKocky(
            SIA_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocko_SIA);


        Record SIB = new() { EMS_CODE = "SIB", CodeInCzech = new List<string> { "Sibiřská kočka", "Sibiřská" } };
        var SIB_n = new Storage(SIB, status.valid);
        var kocka_SIA = new TypKocky(
            SIB_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SIA);


        Record SIN = new() { EMS_CODE = "SIN", CodeInCzech = new List<string> { "Singapura" } };
        var SIN_n = new Storage(SIN, status.valid);
        var kocka_SIB = new TypKocky(
            SIN_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SIB);


        Record SNO = new() { EMS_CODE = "SNO", CodeInCzech = new List<string> { "Snowshoe" } };
        var SNO_n = new Storage(SNO, status.valid);
        var kocka_SNO = new TypKocky(
            SNO_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SNO);


        Record SOK = new() { EMS_CODE = "SOK", CodeInCzech = new List<string> { "Sokoke" } };
        var SOK_n = new Storage(SOK, status.valid);
        var kocka_SOK = new TypKocky(
            SOK_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SOK);


        Record SOM = new() { EMS_CODE = "SOM", CodeInCzech = new List<string> { "Somálská kočka", "Somálská" } };
        var SOM_n = new Storage(SOM, status.valid);
        var kocka_SOM = new TypKocky(
            SOM_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SOM);


        Record SPH = new() { EMS_CODE = "SPH", CodeInCzech = new List<string> { "Sphynx" } };
        var SPH_n = new Storage(SPH, status.valid);
        var kocka_SPH = new TypKocky(
            SPH_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SPH);


        Record SRL = new() { EMS_CODE = "SRL", CodeInCzech = new List<string> { "Selkirk rex dlouhosrstý" } };
        var SRL_n = new Storage(SRL, status.valid);
        var kocka_SRL = new TypKocky(
            SRL_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SRL);


        Record SRS = new() { EMS_CODE = "SRS", CodeInCzech = new List<string> { "Selkirk rex krátkosrstý" } };
        var SRS_n = new Storage(SRS, status.valid);
        var kocka_SRS = new TypKocky(
            SRS_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_SRS);


        Record THA = new() { EMS_CODE = "THA", CodeInCzech = new List<string> { "Thajská kočka", "Thajská" } };
        var THA_n = new Storage(THA, status.valid);
        var kocka_THA = new TypKocky(
            THA_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_THA);


        Record abTUAy = new() { EMS_CODE = "TUA", CodeInCzech = new List<string> { "Turecká angora" } };
        var TUA_n = new Storage(abTUAy, status.valid);
        var kocka_TUA = new TypKocky(
            TUA_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_TUA);


        Record TUV = new() { EMS_CODE = "TUV", CodeInCzech = new List<string> { "Turecká van" } };
        var TUV_n = new Storage(TUV, status.valid);
        var kocka_TUV = new TypKocky(
            TUV_n,
            zbaerveniSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodDepigmentaceSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyBileSkrrvrnitosti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodyStupnedepigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodTypuKresbVSrsti
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodSnizenePigmentace
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZkraceniOcasu
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodZbarveniOci
                .Select(x => new Storage(x, status.valid))
                .ToList(),
            kodsrsti
                .Select(x => new Storage(x, status.valid))
                .ToList()
        );
        kocky.Add(kocka_TUV);


        // Record aby = new() { EMS_CODE = "X", CodeInCzech = "Neuznan0" };
        // Record aby = new() { EMS_CODE = "XLH", CodeInCzech = "Neuznan0" };
        // Record aby = new() { EMS_CODE = "XSH", CodeInCzech = "Neuznan0" };

        return kocky;
    }
}