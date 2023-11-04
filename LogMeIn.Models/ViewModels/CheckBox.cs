namespace LogMeIn.Models.ViewModels;

public class CheckBox
{
    public int Id { get; set; }
    public string LabelName { get; set; } = null!;
    public bool IsChecked { get; set; }

    public string? JavascriptId { get; set; }

    public int ExhibitionStoreId { get; set; }

    public int FeeId { get; set; }
}