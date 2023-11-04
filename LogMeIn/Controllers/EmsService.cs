namespace Tests;

public class EmsService
{
    private readonly string[] emsCode;
    private int _couner;
    private TypKocky _kocka;
    private List<string> _kodDepigmentaceSrsti = new();

    private List<string> _kodSnizenePigmentac = new();
    private List<string> _kodSrsti = new();
    private List<string> _kodTypuKresbVSrsti = new();
    private List<string> _kodyBileSkrrvrnitosti = new();
    private List<string> _kodyStupnedepigmentace = new();
    private List<string> _kodZbarveniOci = new();
    private List<string> _kodZkraceniOcasu = new();

    private List<string> _plemeno = new();
    private List<string> _zbaerveniSrsti = new();
    private bool run;

    public EmsService(string emsCode)
    {
        if (string.IsNullOrEmpty(emsCode)) throw new ArgumentNullException(nameof(emsCode));
        if (emsCode.Trim() != emsCode)
            throw new ArgumentException("EMS code cannot contain leading or trailing whitespace.", nameof(emsCode));
        this.emsCode = emsCode.Split(" ");
    }

    public List<string> Parse()
    {
        if (!canBeParsed()) throw new InvalidOperationException("Invalid EMS code.");
        return GetResult();
    }

    public bool canBeParsed()
    {
        if (run) return _couner == emsCode.Length;
        try
        {
            var x1 = ParsePlemeno();
            if (x1 == status.error) return false;

            var x2 = ParseZbarveniSrsti();
            if (x2 == status.error) return false;

            var x3 = bilaSkvrnitost();
            if (x3 == status.error) return false;

            var x4 = stupenDepigmentace();
            if (x4 == status.error) return false;

            var x5 = typKresby();
            if (x5 == status.error) return false;

            var x6 = snizenaPigmentace();
            if (x6 == status.error) return false;

            var x7 = zkraceniOcastu();
            if (x7 == status.error) return false;

            var x8 = zbarveniOci();
            if (x8 == status.error) return false;

            var x9 = kodSrsti();
            if (x9 == status.error) return false;
        }
        catch (Exception e)
        {
            return false;
        }

        run = true;
        return _couner == emsCode.Length;
    }


    private string hadnlePanda()
    {
        if (_couner >= emsCode.Length) return "";
        var zbarv = emsCode[_couner];
        if (zbarv != zbarv.Trim() || string.IsNullOrEmpty(zbarv.Trim()))
            throw new ArgumentException("EMS code cannot contain leading or trailing whitespace.", nameof(zbarv));
        return zbarv;
    }

    /*
     * a
     */
    public status ParsePlemeno()
    {
        var plemen = hadnlePanda();
        var x = EmsInitializer.Initialize();
        _kocka = x.FirstOrDefault(x => x._plemeno.attribute.EMS_CODE == plemen);
        if (_kocka == null) throw new InvalidOperationException("Invalid EMS code.");
        _couner++;
        _plemeno = _kocka._plemeno.attribute.CodeInCzech;
        return _kocka._plemeno.Stat;
    }

    /**
     * b, c
     */
    private status ParseZbarveniSrsti()
    {
        var zbarv = hadnlePanda();
        if (zbarv.Length == 0) return status.valid;
        var x = _kocka._zbaerveniSrsti.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv[0].ToString());
        if (x == null) return status.valid;
        _couner++;
        _zbaerveniSrsti = x.attribute.CodeInCzech;
        if (x.Stat == status.error) return status.error;
        if (zbarv.Length == 2)
        {
            var x1 = _kocka._kodDepigmentaceSrsti.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv[1].ToString());
            if (x1 == null) return status.error;
            _kodDepigmentaceSrsti = x1.attribute.CodeInCzech;
            return x1.Stat;
        }

        return zbarv.Length == 1 ? status.valid : status.error;
    }


    /*
     * e
     */
    private status bilaSkvrnitost()
    {
        var zbarv = hadnlePanda();
        var x = _kocka._kodyBileSkrrvrnitosti.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null) return status.valid;
        _couner++;
        _kodyBileSkrrvrnitosti = x.attribute.CodeInCzech;
        return x.Stat;
    }

    /*
     * f
     */
    public status stupenDepigmentace()
    {
        if (_kodDepigmentaceSrsti == null) return status.valid;

        var zbarv = hadnlePanda();
        var x = _kocka._kodyStupnedepigmentace.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null)
            // _kodyStupnedepigmentace = new List<string> { "kouřová" };
            return status.valid;

        _couner++;
        _kodyStupnedepigmentace = x.attribute.CodeInCzech;
        return x.Stat;
    }

    /**
     * g
     */
    private status typKresby()
    {
        var zbarv = hadnlePanda();
        var x = _kocka._kodTypuKresbVSrsti.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null)
            // _kodTypuKresbVSrsti = new List<string> { "srst zcela bez kresby" };
            return status.valid;

        _couner++;
        _kodTypuKresbVSrsti = x.attribute.CodeInCzech;
        return x.Stat;
    }


    /**
* h
*/
    private status snizenaPigmentace()
    {
        var zbarv = hadnlePanda();
        var x = _kocka._kodSnizenePigmentace.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null) return status.valid;

        _couner++;
        _kodSnizenePigmentac = x.attribute.CodeInCzech;
        return x.Stat;
    }

    /**
 * j
 */
    private status zkraceniOcastu()
    {
        var zbarv = hadnlePanda();
        var x = _kocka._kodZkraceniOcasu.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null) return status.valid;

        _couner++;
        _kodZkraceniOcasu = x.attribute.CodeInCzech;
        return x.Stat;
    }

    /**
* k
*/
    private status zbarveniOci()
    {
        var zbarv = hadnlePanda();
        var x = _kocka._kodZbarveniOci.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null) return status.valid;
        _couner++;
        _kodZbarveniOci = x.attribute.CodeInCzech;
        return x.Stat;
    }

    private List<string> GetResult()
    {
        var result = new List<List<string>>();
        result.Add(_plemeno);
        result.Add(_zbaerveniSrsti);
        result.Add(_kodDepigmentaceSrsti);
        result.Add(_kodyBileSkrrvrnitosti);
        result.Add(_kodyStupnedepigmentace);
        result.Add(_kodTypuKresbVSrsti);
        result.Add(_kodSnizenePigmentac);
        result.Add(_kodZkraceniOcasu);
        result.Add(_kodZbarveniOci);
        result.Add(_kodSrsti);
        var separator = " ";

        var output = new List<string> { "" };
        foreach (var list in result)
        {
            var old = output;
            output = new List<string>();

            foreach (var s in old)
            foreach (var s1 in list)
                if (s.Length == 0 || s1.Length == 0)
                    output.Add(s + s1);
                else
                    output.Add(s + separator + s1);

            if (output.Count == 0)
                output = old;
        }

        return output;
    }


    private status kodSrsti()
    {
        var zbarv = hadnlePanda();
        var x = _kocka.KodSrsti.FirstOrDefault(x => x.attribute.EMS_CODE == zbarv);
        if (x == null) return status.valid;

        _couner++;
        _kodSrsti = x.attribute.CodeInCzech;
        return x.Stat;
    }
}