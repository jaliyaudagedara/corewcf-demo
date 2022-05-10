using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWcfDemo.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

WebApplication? app = builder.Build();
app.UseServiceModel(builder =>
{
    // This service only supports BasicHttpBinding
    builder
        .AddService<GreetService>()
        .AddServiceEndpoint<GreetService, IGreetService>(new BasicHttpBinding(),
            "/GreetService/BasicHttp");

    // This service supports BasicHttpBinding and WSHttpBinding
    builder
        .AddService<AnotherGreetService>()
        .AddServiceEndpoint<AnotherGreetService, IAnotherGreetService>(new BasicHttpBinding(),
            "/AnotherGreetService/BasicHttp")
        .AddServiceEndpoint<AnotherGreetService, IAnotherGreetService>(new WSHttpBinding(SecurityMode.Transport),
            "/AnotherGreetService/WSHttps");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();

serviceMetadataBehavior.HttpGetEnabled = true;
serviceMetadataBehavior.HttpsGetEnabled = true;

serviceMetadataBehavior.HttpGetUrl = new Uri("http://localhost:5051/metadata");
serviceMetadataBehavior.HttpsGetUrl = new Uri("https://localhost:7051/metadata");

app.Run();