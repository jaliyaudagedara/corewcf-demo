using CoreWCF;

namespace CoreWcfDemo.Server.Services;

[ServiceContract]
public interface IAnotherGreetService
{
    [OperationContract]
    string AnotherGreet(string message);
}
