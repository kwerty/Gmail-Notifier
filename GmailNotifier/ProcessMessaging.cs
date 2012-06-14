using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace GmailNotifier
{

    public class ProcessMessaging
    {

        public event MessageReceivedEventHandler MessageReceived;

        private NamedPipeServerStream _pipe;
        private object _pipeLock;

        public void Close()
        {

            object pipeLock = _pipeLock;

            Interlocked.CompareExchange(ref _pipeLock, null, _pipeLock);

            if (_pipeLock == pipeLock) return;

            _pipe.Close();

        }

        public void ReceieveMessages()
        {
            ThreadPool.QueueUserWorkItem(ReceiveMessagesInner, null);
        }

        private void ReceiveMessagesInner(object state)
        {

            _pipeLock = new object();

            while (true)
            {

                if (_pipeLock == null) return;

                try
                {
                    _pipe = new NamedPipeServerStream("GmailNotifier", PipeDirection.In);
                }
                catch (IOException)
                {
                    Process.Start("http://kwerty.com/Gmail-Notifier-for-Windows-7/?curr_version=" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    //something needs to be done here to exit the app
                    throw;
                    //return;
                }

                try
                {

                    _pipe.WaitForConnection();

                    using (StreamReader stream = new StreamReader(_pipe))
                    {

                        string cmd;

                        cmd = stream.ReadLine();

                        if (cmd == null)
                        {
                            _pipeLock = null;
                            return;
                        }

                        _pipe.Close();

                        OnMessageReceived(new MessageEventArgs(cmd));

                    }

                }
                catch (ObjectDisposedException)
                {
                    return;
                }

            }




        }

        public static void SendMessage(string message)
        {

            NamedPipeClientStream pipe = new NamedPipeClientStream(".", "GmailNotifier", PipeDirection.Out);

            using (pipe)
            {

                pipe.Connect(5000);

                using (StreamWriter stream = new StreamWriter(pipe))
                    stream.WriteLine(message);

            }


        }

        private void OnMessageReceived(MessageEventArgs e)
        {
            MessageReceivedEventHandler handler = MessageReceived;
            if (handler != null) handler(this, e);
        }


    }

    public delegate void MessageReceivedEventHandler(object sender, MessageEventArgs e);

    public class MessageEventArgs : EventArgs
    {

        internal MessageEventArgs(string message)
            : base()
        {
            Message = message;
        }

        public string Message { get; private set; }

    }

}
