using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace GmailNotifier
{

    enum SoundOptions
    {
        None,
        Default,
        Custom
    }

    [Flags]
    enum SoundFlags
    {
        SND_ALIAS = 0x10000,
        SND_ASYNC = 1,
        SND_FILENAME = 0x20000,
    }

    public static class SoundUtil
    {

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hMod, SoundFlags sf);

        public static void PlaySound(string path)
        {
            if (File.Exists(path))
                PlaySound(path, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC);
        }

        public static void PlayWindowsSound(string name)
        {
            PlaySound(name, IntPtr.Zero, SoundFlags.SND_ALIAS | SoundFlags.SND_ASYNC);
        }


    }
}