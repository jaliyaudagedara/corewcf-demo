using CoreWCF;

namespace CoreWcfDemo.Server.Services;

[ServiceContract]
public interface IGreetService
{
    [OperationContract]
    string Greet(string message);
}
