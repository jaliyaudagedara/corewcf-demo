using CoreWCF;
using CoreWcfDemo.Server.Models;

namespace CoreWcfDemo.Server.Services;

public class AnotherGreetService : IAnotherGreetService
{
    public string AnotherGreet(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new FaultException<ApplicationFault>(new ApplicationFault { Message = "Message is null or empty" }, new FaultReason("InvalidInput"));
        }

        return $"You said another: {message}";
    }
}