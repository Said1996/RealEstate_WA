using Blazored.LocalStorage;
using BlazorWA;
using BlazorWA.Services;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44388/api/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IBuyViewModel, BuyViewModel>();
builder.Services.AddScoped<ISellViewModel, SellViewModel>();
builder.Services.AddScoped<IUserViewModel, UserViewModel>();
builder.Services.AddScoped<IRealEstateService, RealEstateService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
