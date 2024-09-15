using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UseAspNetCoreInWpf.Logging;

namespace UseAspNetCoreInWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            mainWindow.Show();

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers();
            builder.Logging.AddProvider(new WpfLoggerProvider(mainWindow.LogTextBox));
            builder.WebHost.UseUrls("http://localhost:5000");

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.MapControllers();

            app.RunAsync();
        }
    }

}
