namespace VelorusNet8.Application.Interface;

public interface IMessageBusService
{
    //Task<string> CallAndReceiveResponseAsync(string message);  // Task<string> olarak değiştirildi
    Task<string> PublishMessageAsync(string message);
    void StartConsuming();
}
