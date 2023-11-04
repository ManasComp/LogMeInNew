namespace LogMeIn.Models.ViewModels;

public class PayInfoVm
{
    public List<VelkyVm> cats { get; set; }

    public VelkyVm person { get; set; }
    public double TotalPrice { get; set; }

    public string Messahge { get; set; }

    public int PersonRegID { get; set; }
}