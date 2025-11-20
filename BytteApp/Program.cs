using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BytteApp;
using BytteApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Standard API klient til annoncer
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5097")   // ← jeres API-port
});

// Annonce service (allerede sat op)
builder.Services.AddScoped<AnnonceService, AnnonceServiceHttp>();

//  NY — billedservice bruger også HttpClient (samme port)
builder.Services.AddScoped<IAnnonceBilledeService, AnnonceBilledeService>();

await builder.Build().RunAsync();