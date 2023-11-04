using LogMeIn.Models.Models;

namespace Tests;

public class TypKocky : BaseModel
{
    public TypKocky(Storage plemeno,
        List<Storage> zbaerveniSrsti,
        List<Storage> kodDepigmentaceSrsti,
        List<Storage> kodyBileSkrrvrnitosti,
        List<Storage> kodyStupnedepigmentace,
        List<Storage> kodTypuKresbVSrsti,
        List<Storage> kodSnizenePigmentace,
        List<Storage> kodZkraceniOcasu,
        List<Storage> kodZbarveniOci,
        List<Storage> kodSrsti)
    {
        _kodSnizenePigmentace = kodSnizenePigmentace;
        _kodZkraceniOcasu = kodZkraceniOcasu;
        _kodZbarveniOci = kodZbarveniOci;
        KodSrsti = kodSrsti;
        _plemeno = plemeno;
        _zbaerveniSrsti = zbaerveniSrsti;
        _kodDepigmentaceSrsti = kodDepigmentaceSrsti;
        _kodyBileSkrrvrnitosti = kodyBileSkrrvrnitosti;
        _kodyStupnedepigmentace = kodyStupnedepigmentace;
        _kodTypuKresbVSrsti = kodTypuKresbVSrsti;
    }

    public List<Storage> _kodSnizenePigmentace { get; }
    public List<Storage> _kodZbarveniOci { get; }
    public List<Storage> KodSrsti { get; }
    public List<Storage> _kodZkraceniOcasu { get; }

    public List<Storage> _kodDepigmentaceSrsti { get; }
    public List<Storage> _kodTypuKresbVSrsti { get; }
    public List<Storage> _kodyBileSkrrvrnitosti { get; }
    public List<Storage> _kodyStupnedepigmentace { get; }
    public Storage _plemeno { get; }
    public List<Storage> _zbaerveniSrsti { get; }
}