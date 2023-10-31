using Microsoft.AspNetCore.Builder;

namespace Product.API.Extensions;

public static class ApplicationExtensions
{
    public static void UseInferastructure(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        // for production
        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
