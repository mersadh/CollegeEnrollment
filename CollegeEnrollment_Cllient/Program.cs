
using Blazored.LocalStorage;
using CollegeEnrollment_Client.Serivce;
using CollegeEnrollment_Cllient;
using CollegeEnrollment_Cllient.Service;
using CollegeEnrollment_Cllient.Service.IService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddScoped<IEnrollmentCartService, EnrollmentCartService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
await builder.Build().RunAsync();
