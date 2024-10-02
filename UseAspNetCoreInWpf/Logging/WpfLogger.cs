using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace UseAspNetCoreInWpf.Logging
{
    public class WpfLogger : ILogger
    {
        private readonly TextBox _textBox;
        private readonly StringBuilder _stringBuilder = new();
        private readonly Queue<string> _logItems = new();

        public int MaxCount { get; set; } = 100;

        public WpfLogger(TextBox textBox)
        {
            _textBox = textBox;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            _logItems.Enqueue(formatter.Invoke(state, exception));

            while (_logItems.Count > MaxCount)
            {
                _logItems.Dequeue();
            }

            foreach (var item in _logItems)
            {
                _stringBuilder.AppendLine(item);
            }

            App.Current.Dispatcher.Invoke(() =>
            {
                _textBox.Text = _stringBuilder.ToString();
                _stringBuilder.Clear();
            });
        }
    }

}
