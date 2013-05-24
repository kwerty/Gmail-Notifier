using System;
using System.Windows.Forms;
using System.Threading;

namespace GmailNotifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (args.Length > 0) {
                ProcessMessaging.SendMessage(args[0]);
                Environment.Exit(0);
                return;
            }

            bool hasMutex;

            using (Mutex mutex = new Mutex(false, "KwertyGmailNotifier", out hasMutex))
            {

                if (!hasMutex)
                {
                    ProcessMessaging.SendMessage("inbox");
                    Environment.Exit(0);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            
        }




    }
}
