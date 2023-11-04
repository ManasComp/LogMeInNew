namespace LogMeIn.Models.ViewModels;

public class Step
{
    public int CatRegistrationId { get; set; }
    public int StepId { get; set; }

    public bool isHomeCat { get; set; }

    public bool Disabled { get; set; } = false;

    public bool editting { get; set; } = false;
}