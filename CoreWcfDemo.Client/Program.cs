using ServiceReference1;

// BasicHttpsBinding
var greetServiceClient = new GreetServiceClient(
    GreetServiceClient.EndpointConfiguration.BasicHttpBinding_IGreetService,
    "http://localhost:5051/GreetService/BasicHttp"
);
var result = await greetServiceClient.GreetAsync("Hello");
Console.WriteLine(result);

// WSHttpBinding
var anotherGreetServiceClient = new AnotherGreetServiceClient(
    AnotherGreetServiceClient.EndpointConfiguration.WSHttpBinding_IAnotherGreetService,
    "https://localhost:7051/AnotherGreetService/WSHttps"
);
result = await anotherGreetServiceClient.AnotherGreetAsync("Hello");
Console.WriteLine(result);

Console.ReadLine();