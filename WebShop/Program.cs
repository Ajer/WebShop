using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using WebShop.Data;
using WebShop.Infrastructure;
using WebShop.Views.Shared.Services;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();   // Detailed DB-errors, development only

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//var redisString = builder.Configuration["ConnectionStrings:RedisConn"]??"";   // secrets.json

//if (redisString != "")
//{
//    var redisOptions = new ConfigurationOptions     // Experiment med Redis-server för sessioner. C har en server som kör på
//    {                                               // Endpointen nedan. Gäller bara i hans nätverk.
//        EndPoints = { redisString },
//        DefaultDatabase = 2,
//        Ssl = true,                     // set true only if your Redis uses TLS
//        AbortOnConnectFail = false
//    };
//}

//builder.Services.AddStackExchangeRedisCache(options =>      // Endast för test av cachning med Redis på WeatherService
//{
//    options.ConfigurationOptions = redisOptions;
//    options.InstanceName = "WeatherService:";
//});


builder.Services.AddSession(opts =>                  // Session for in-memory but also for redis-sessions, These settings will create an extra cookie 
{                                                         // on some pages because of .Net core data protection
    opts.IdleTimeout = TimeSpan.FromMinutes(20);       // change time in real app
    //opts.Cookie.Name = "sid";
    opts.Cookie.HttpOnly = true;
    opts.Cookie.IsEssential = true;
    opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;   // Only https session requests
    opts.Cookie.SameSite = SameSiteMode.Strict;             // Or Lax
});


/*builder.Services.AddSingleton<WeatherService>();*/    // till redis


//var redis = ConnectionMultiplexer.Connect(redisOptions);
//var db = redis.GetDatabase(2); // DB 2 over TLS

//db.StringSet("session:123", "active");   just an example



//builder.Logging.AddFileLogger("logs/app.log");     // Lägg till logger som skriver till path


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseMiddleware<RequestTimingMiddleware>();          // Logging med stopwatch



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // added extra

app.UseAuthorization();


app.UseSession();                               // Session

// app.useOutputCaching();                          // Suggestion: Output caching, requires .AddOutputCaching() in services


//app.MapGet("/set", async (HttpContext ctx) =>   // Experimentell minimal endpoint för att testa Redis-sessioner
//{
//    var sessionId = Guid.NewGuid().ToString("N");

//    var guid = "6767dferlpbj8989dhfhh";
//    ctx.Response.Cookies.Append("sid", sessionId, new CookieOptions
//    {
//        HttpOnly = true,
//        Secure = true,
//        SameSite = SameSiteMode.Strict,
//        Expires = DateTimeOffset.UtcNow.AddMinutes(2)
//    });
//    var jsonData = $"{{ \"Guid\" : \"{guid}\", \"Name\": \"Anders\", \"Age\": 42 }}";
//    await db.StringSetAsync($"session:{sessionId}", jsonData, TimeSpan.FromMinutes(2));    //new { Guid = guid, Name = "Anders", Age = 42 }    "{\"userId\":45,\"guid\":guid}"
//    return Results.Ok("Stored");
//});


//app.MapGet("/setwrong", (HttpContext ctx) =>
//{
//    ctx.Session.SetString("username", "anders");
//    //var val = ctx.Session.GetString("username");

//    ctx.Session.SetInt32("visits", 1);
//    //var val2 = ctx.Session.GetInt32("visits");

//    return "Stored in Redis session";
//});



// This warms up the DB connection on application start making the first sql query faster.
app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.ExecuteSqlRawAsync("SELECT 1");   // Never use ExecuteSqlRawAsync otherwise.
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStatusCodePagesWithRedirects("/Error/{0}"); //point to error page

app.MapRazorPages();

app.Run();
