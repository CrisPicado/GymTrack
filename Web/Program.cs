using Application;
using Application.Clients;
using Persistence;
using Domain.Configuration;
using Application.Routines;
using Application.Coaches;
using Application.Equipments;
using Application.Exercises;
using Infrastructure;
using Infrastructure.Policy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var endpoints = builder.Configuration.GetSection
            (nameof(EndpointConfiguration)).Get<List<EndpointConfiguration>>();

builder.Services.Configure<List<EndpointConfiguration>>
    (options =>
    {
        options.AddRange(endpoints);
    });

builder.Services.AddHttpClient<IClientContract, ClientImp>((provider, client) =>
{
    var endpoint = endpoints.Where
        (s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);

});

builder.Services.AddHttpClient<ICoachClient, CoachClient>((provider, client) =>
{
    var endpoint = endpoints.Where
        (s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);

});

builder.Services.AddHttpClient<IEquipmentsClient, EquipmentsClient>((provider, client) =>
{
    var endpoint = endpoints.Where
        (s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);

});

builder.Services.AddHttpClient<IExerciseClient, ExerciseClient>((provider, client) =>
{
    var endpoint = endpoints.Where
        (s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);

});

builder.Services.AddHttpClient<IRoutineClient, RoutineClient>((provider, client) =>
{
    var endpoint = endpoints.Where
        (s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Account/SignIn";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Clients.Read", policy => {
        policy.AddRequirements(new PolicyRequirement(new List<PolicyPermission>()
        {
            new PolicyPermission("Clients", "Index"),
        }));
    });
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Coaches.Read", policy => {
        policy.AddRequirements(new PolicyRequirement(new List<PolicyPermission>()
        {
            new PolicyPermission("Coaches", "Index"),
        }));
    });
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Equipments.Read", policy => {
        policy.AddRequirements(new PolicyRequirement(new List<PolicyPermission>()
        {
            new PolicyPermission("Equipments", "Index"),
        }));
    });
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Exercises.Read", policy => {
        policy.AddRequirements(new PolicyRequirement(new List<PolicyPermission>()
        {
            new PolicyPermission("Exercises", "Index"),
        }));
    });
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Routines.Read", policy => {
        policy.AddRequirements(new PolicyRequirement(new List<PolicyPermission>()
        {
            new PolicyPermission("Routines", "Index"),
        }));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Usar primero Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
