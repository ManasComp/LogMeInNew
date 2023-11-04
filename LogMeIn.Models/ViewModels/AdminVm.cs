namespace LogMeIn.Models.ViewModels;

public class AdminVm
{
    public CatVm Father { get; set; }
    public CatVm Mother { get; set; }
    public ExhibitionVm Exhibition { get; set; }
    public ExhibitedCatVm ExhibitedCatVm { get; set; }

    public int RegId { get; set; }

    public int PersonegID { get; set; }
}