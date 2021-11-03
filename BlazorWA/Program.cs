using BlazorWA;
using BlazorWA.Services;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44388/api/") });
builder.Services.AddScoped<IShopViewModel, ShopViewModel>();
builder.Services.AddScoped<IRealEstateService, RealEstateService>();

await builder.Build().RunAsync();
