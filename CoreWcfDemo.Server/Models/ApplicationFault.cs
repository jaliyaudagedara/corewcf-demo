using System.Runtime.Serialization;

namespace CoreWcfDemo.Server.Models;

[DataContract]
public class ApplicationFault
{
    [DataMember]
    public string Message { get; set; }
}
