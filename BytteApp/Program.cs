using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BytteApp;
using BytteApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient til jeres API på Serverapp1 (port 5097)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5097")
});

// Annonce service
builder.Services.AddScoped<AnnonceService, AnnonceServiceHttp>();

//  Billedservice – *HTTP-implementationen*
builder.Services.AddScoped<IAnnonceBilledeService, AnnonceBilledeService>();

await builder.Build().RunAsync();