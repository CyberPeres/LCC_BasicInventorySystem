using LCC_BasicInventorySystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//(Important) Must register "Inject" dependancies into pages.
builder.Services.AddRazorPages();
// Register InventoryService
builder.Services.AddSingleton<InventoryService>();
//For being able to tell what page we are on to hide/show elements
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
