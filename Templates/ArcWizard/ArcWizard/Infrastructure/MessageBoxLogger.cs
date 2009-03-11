using System;
using System.Windows.Forms;

namespace ArcWizard.Infrastructure
{
    public class MessageBoxLogger : ILogger
    {
        public void WriteLine(string message)
        {
            MessageBox.Show(DateTime.Now.ToLongTimeString() + "\t" + message);
        }
    }
}