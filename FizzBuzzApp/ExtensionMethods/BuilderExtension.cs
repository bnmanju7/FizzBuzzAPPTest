using FizzBuzz.Services.Interfaces;
using FuzzBuzz.Services;

namespace FizzBuzzApp.ExtensionMethods
{
    public static class BuilderExtension
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IFizzBuzz, FizzBuzzService>();
        }
    }
}
