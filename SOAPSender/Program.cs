using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

// Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in ASP.NET
var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder =>
{
    builder.AddService<Service>((serviceOptions) => { })
    // Add a BasicHttpBinding at a specific endpoint
    .AddServiceEndpoint<Service, IService>(new BasicHttpBinding(), "/Service/basichttp")
    // Add a WSHttpBinding with Transport Security for TLS
    .AddServiceEndpoint<Service, IService>(myWSHttpBinding, "/Service/WSHttps");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();