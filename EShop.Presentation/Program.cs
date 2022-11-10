
using EShop.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using EShop.DataAccessor;
using EShop.Business;
using EShop.Business.Services;
using EShop.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLayer();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDataAccessorLayer(builder.Configuration);

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = string.Empty;
        });
} else {
    app.UseMiddleware<ErrorHandlers>();
}

//app.UseMiddleware<ErrorHandlers>();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
