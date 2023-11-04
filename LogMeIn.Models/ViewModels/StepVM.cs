namespace LogMeIn.Models.ViewModels;

public class StepVm<T>
{
    public int RegistrationId { get; set; }
    public int StepId { get; set; }
    public T Data { get; set; } = default!;
}