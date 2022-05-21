using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.SQLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddPiranha(options =>
{
    options.AddRazorRuntimeCompilation = true;

    options.UseManager();
    options.UseMemoryCache();

    options.UseEF<SQLiteDb>(db =>
        db.UseSqlite("Filename=./piranha.razorweb.db"));
    options.UseIdentityWithSeed<IdentitySQLiteDb>(db =>
        db.UseSqlite("Filename=./piranha.razorweb.db"));

    options.UseSecurity(o =>
    {
        o.UsePermission("Subscriber");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var api = app.Services.CreateScope().ServiceProvider.GetService<IApi>();
if (api == null)
{
    throw new ArgumentNullException(nameof(api));
}
App.Init(api);

// Configure cache level
App.CacheLevel = Piranha.Cache.CacheLevel.Full;

// Register custom components
//App.Blocks.Register<RazorWeb.Models.Blocks.MyGenericBlock>();
//App.Blocks.Register<RazorWeb.Models.Blocks.RawHtmlBlock>();
App.Modules.Manager().Scripts.Add("~/assets/custom-blocks.js");
App.Modules.Manager().Styles.Add("~/assets/custom-blocks.css");

// Build content types
new ContentTypeBuilder(api)
    .AddAssembly(typeof(Program).Assembly)
    .Build()
    .DeleteOrphans();

/**
 *
 * Test another culture in the UI
 *
var cultureInfo = new System.Globalization.CultureInfo("en-US");
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
 */

app.UsePiranha(options =>
{
    options.UseManager();
    options.UseIdentity();
});

app.Run();
