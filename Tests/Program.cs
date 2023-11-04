// See https://aka.ms/new-console-template for more information


using Tests;

TestCase testCase = new();
testCase.TestMe();


public class EmsTuple
{
    public EmsTuple(string eMs, string representation)
    {
        EMs = eMs;
        Representation = representation;
    }

    public string EMs { get; set; }
    public string Representation { get; set; }
}

public class TestCase
{
    public List<EmsTuple> test()
    {
        var emsTuples = new List<EmsTuple>();

        emsTuples.Add(new EmsTuple("PER a", "Perská modrá"));
        emsTuples.Add(new EmsTuple("PER ns 11", "Perská černá stříbřitě stínovaná"));
        emsTuples.Add(new EmsTuple("PER d 03", "Perská červený bikolor"));
        emsTuples.Add(new EmsTuple("PER g 03", "Perská modře želvovinový bikolor"));
        // emsTuples.Add(new EmsTuple("PER g 01 21 62",
        //     "Perská modrá želvovinový van s nepecifikovanou kresnou oranžovooká"));
        emsTuples.Add(new EmsTuple("PER n 03 22", "Perská černá bikolor mramorovaná"));
        emsTuples.Add(new EmsTuple("PER ns 01 21 62", "Perská černá stříbřitá van s kresbou a oranžovýma očima"));

        emsTuples.Add(new EmsTuple("RAG n", "Ragdoll s červenohnědými odznaky"));
        emsTuples.Add(new EmsTuple("RAG a", "Ragdoll s modrými odznaky"));
        emsTuples.Add(new EmsTuple("RAG a 21", "Ragdoll s modrými žíhanými odznaky"));
        emsTuples.Add(new EmsTuple("RAG n 03", "Ragdoll černý bikolor"));
        emsTuples.Add(new EmsTuple("RAG n 03", "Ragdoll černý bikolor"));
        emsTuples.Add(new EmsTuple("RAG a 03", "Ragdoll modrý bikolor"));
        emsTuples.Add(new EmsTuple("RAG b 03", "Ragdoll čokoládovobílá bikolor"));
        emsTuples.Add(new EmsTuple("RAG n 04", "Ragdoll černohnědý mitted"));
        emsTuples.Add(new EmsTuple("RAG a 04", "Ragdoll modrý mitted"));
        emsTuples.Add(new EmsTuple("RAG f 04", "Ragdoll černý želvovinový mitted"));
        emsTuples.Add(new EmsTuple("RAG g 04", "Ragdoll modře želvovinový mitted"));
        emsTuples.Add(new EmsTuple("RAG e 04 21", "Ragdoll krémový s odznaky s kresbou"));
        emsTuples.Add(new EmsTuple("RAG g 04 21", "Ragdoll modrý želvovinový s odznaky a kresbou"));

        emsTuples.Add(new EmsTuple("SBI n", "Birma červenohnědá"));
        emsTuples.Add(new EmsTuple("SBI c", "Birma lilová"));
        emsTuples.Add(new EmsTuple("SBI e", "Birma krémová"));
        emsTuples.Add(new EmsTuple("SBI f", "Birma černě želvovinový"));
        emsTuples.Add(new EmsTuple("SBI a 21", "Birma s modrými odznaky s kresbou"));
        emsTuples.Add(new EmsTuple("SBI a 21", "Birma čokoládová želvovinová s nespecifckou kresbou"));

        emsTuples.Add(new EmsTuple("BEN n 24", "Bengálská černá tečkovaná"));

        emsTuples.Add(new EmsTuple("BLH b", "Britská dlouhosrstá čokoládová"));
        emsTuples.Add(new EmsTuple("BLH c", "Britská dlouhosrstá lilová"));
        emsTuples.Add(new EmsTuple("BLH j 02 62",
            "Britská dlouhosrstá lilová želvovinová harlekýn s oranžovýma očima"));

        emsTuples.Add(new EmsTuple("BSH a", "Britská krátkosrstá modrá"));
        emsTuples.Add(new EmsTuple("BSH b", "Britská krátkosrstá čokoládová"));
        emsTuples.Add(new EmsTuple("BSH c", "Britská krátkosrstá lilová"));
        emsTuples.Add(new EmsTuple("BSH e", "Britská krátkosrstá krémová"));
        emsTuples.Add(new EmsTuple("BSH g", "Britská krátkosrstá modrá želvovinová"));
        emsTuples.Add(new EmsTuple("BSH j", "Britská krátkosrstá lilově želvovinová"));
        emsTuples.Add(new EmsTuple("BSH o", "Britská krátkosrstá skořicová"));
        emsTuples.Add(new EmsTuple("BSH ns 11", "Britská krátkosrstá černá stříbřitá stínovaná"));
        emsTuples.Add(new EmsTuple("BSH h 24", "Britská krátkosrstá čokoládová želvovinová tečkovaná"));
        emsTuples.Add(new EmsTuple("BSH ns 22 64", "Britská krátkosrstá černá stříbřitá mramorovaná zelenooká"));
        emsTuples.Add(new EmsTuple("BSH d 02 62", "Britská krátkosrstá červená harlekýn oranžovooká"));
        emsTuples.Add(new EmsTuple("BSH e 02 62", "Britská krátkosrstá krémová harlekýn oranžovooká"));
        emsTuples.Add(new EmsTuple("BSH b 03", "Britská krátkosrstá čokoládový bikolor"));
        emsTuples.Add(new EmsTuple("BSH c 03", "Britská krátkosrstá lilová bikolor"));
        emsTuples.Add(new EmsTuple("BSH f 03", "Britská krátkosrstá černá želvovinová bikolor"));
        emsTuples.Add(new EmsTuple("BSH g 03", "Britská krátkosrstá modrá želvovinová bikolor"));
        emsTuples.Add(new EmsTuple("BSH bs 02 62", "Britská krátkosrstá čokoládová stříbřitá harlekýn oranžovooká"));
        emsTuples.Add(new EmsTuple("BSH b 03 22", "Britská krátkosrstá čokoládová bikolor mramorovaná"));
        emsTuples.Add(new EmsTuple("BSH d 03 22", "Britská krátkosrstá červená bikolor mramorovaná"));
        emsTuples.Add(new EmsTuple("BSH b 03 24", "Britská krátkosrstá čokoládová bikolor tečkovaná"));
        emsTuples.Add(new EmsTuple("BSH d 03 24", "Britská krátkosrstá červená bikolor tečkovaná"));
        emsTuples.Add(new EmsTuple("BSH ns 02 21 64",
            "Britská krátkosrstá černá stříbřitá harlekýn s kresbou zelenooká"));
        emsTuples.Add(new EmsTuple("BSH ns 02 22 64",
            "Britská krátkosrstá černá stříbřitá harlekýn mramorovaná zelenooká"));
        // emsTuples.Add(new EmsTuple("BSH b 21 33", "Britská krátkosrstá s čokoládovými žíhanými odznaky"));

        emsTuples.Add(new EmsTuple("BUR n", "Barmská černá"));
        emsTuples.Add(new EmsTuple("BUR b", "Barmská čokoládová"));
        emsTuples.Add(new EmsTuple("BUR f", "Barmská černá želvovinová"));

        emsTuples.Add(new EmsTuple("OCI b 24", "Ocicat čokoládová tečkovaná"));
        emsTuples.Add(new EmsTuple("ABY n", "Habešská divoce zbarevená"));
        emsTuples.Add(new EmsTuple("THA n", "Thajská seal"));
        emsTuples.Add(new EmsTuple("THA a", "Thajská modrá"));
        emsTuples.Add(new EmsTuple("THA b", "Thajská čokoládová"));
        emsTuples.Add(new EmsTuple("THA c", "Thajská lilová"));

        emsTuples.Add(new EmsTuple("MCO ds 09 22", "Mainská mývalí červená stříbřitá mramorovaná s bílou"));
        emsTuples.Add(new EmsTuple("MCO f 22", "Mainská mývalí želvovinová mramorovaná"));

        // emsTuples.Add(new EmsTuple("NFO at 22", "Norská lesní světlý amber mramorovaná"));
        // emsTuples.Add(new EmsTuple("BEN x nt 24", "Bengálská kočka charcoal černě tečkovaná (neuznaná varieta)"));
        // emsTuples.Add(new EmsTuple("XSH n (SPH)", "neuznaný bezsrstý černý (cílové plemeno: Sphynx)"));
        // emsTuples.Add(new EmsTuple("XSH n 82 (SPH)", "XSH n 82 neuznaný krátkosrstý černý (cílové plemeno: Sphynx)"));
        // emsTuples.Add(new EmsTuple("BXSH n (DRX)", "neuznaný krátkosrstý černý (cílové plemeno: Devon Rex)"));
        // emsTuples.Add(new EmsTuple("XSH n 84 (DRX)", "neuznanýs krátkou rovnou srstí černý(cílové plemeno: Devon Rex)"));
        // emsTuples.Add(new EmsTuple("DSP n 21 33 81", "donský sphynx s kresbou a černohnědými odznaky dlouhosrstý"));
        // emsTuples.Add(new EmsTuple("DSP x f 03 24 82", "donský sphynx černě želvovinový bikolor tečkovaný krátkosrstý"));
        // emsTuples.Add(new EmsTuple("DSP x n 33 83", "donský sphynx s černohnědými odznaky brush"));
        // emsTuples.Add(new EmsTuple("DSP x f 03 21 83", "donský sphynx černě želvovinový bikolor s kresbou brush"));
        // emsTuples.Add(new EmsTuple("PEB x n 33 81", "Peterbald s černohnědými odznaky dlouhosrstý"));ý
        // emsTuples.Add(new EmsTuple("PEB x f 03 24 82", "Peterbald černě želvovinový bikolor tečkovaný krátkosrstý"));
        // emsTuples.Add(new EmsTuple("PEB n 33 83", "Peterbald s černohnědými odznaky brush"));
        emsTuples.Add(new EmsTuple("PEB f 03 24 83", "Peterbald černě želvovinový bikolor tečkovaný brush"));


        return emsTuples;
    }

    public void TestMe()
    {
        var fails = 0;
        var testCases = test();
        foreach (var testCase in testCases)
        {
            var controller = new EmsService(testCase.EMs);
            var parsed = controller.Parse();
            if (!parsed.Contains(testCase.Representation))
            {
                parsed.ForEach(x => Console.WriteLine(x + " VS " + testCase.Representation));
                Console.WriteLine("");
                fails++;
            }
        }

        Console.WriteLine("Fails: " + fails + " out of " + testCases.Count);
    }
}


// using var browserFetcher = new BrowserFetcher();
// await browserFetcher.DownloadAsync();
// await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions {Headless = true});
// await using var page = await browser.NewPageAsync();
// await page.GoToAsync("http://www.seznam.cz"); // In case of fonts being loaded from a CDN, use WaitUntilNavigation.Networkidle0 as a second param.
// await page.EvaluateExpressionHandleAsync("document.fonts.ready"); // Wait for fonts to be loaded. Omitting this might result in no text rendered in pdf.
//     Console.WriteLine(Path.GetFullPath("outputFile"));
// await page.PdfAsync("outputFile.pdf");