using System.Windows.Controls;
using Microsoft.Extensions.Logging;

namespace UseAspNetCoreInWpf.Logging
{
    public class WpfLoggerProvider : ILoggerProvider
    {
        private readonly TextBox _textBox;

        public WpfLoggerProvider(TextBox textBox)
        {
            _textBox = textBox;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new WpfLogger(_textBox);
        }

        public void Dispose() { }
    }

}
