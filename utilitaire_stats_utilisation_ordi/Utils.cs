using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace utilitaire_stats_utilisation_ordi
{
    public static class Utils
    {
        public static bool IsAudioPlaying(MMDevice device)
        {

            using var meter = AudioMeterInformation.FromDevice(device);
            return meter.PeakValue > 0.00005;
        }
        public static MMDevice GetDefaultRenderDevice()
        {
            using var enumerator = new MMDeviceEnumerator();
            return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }
        public static string GetForegroundWindowName()
        {
            var idWindow = GetForegroundWindow();
            var textLength = GetWindowTextLength(idWindow);
            StringBuilder nameWindow = new StringBuilder(textLength);
            if (textLength > 0)
            {
                    GetWindowText(idWindow, nameWindow, textLength + 1);
            }
            return nameWindow.ToString();
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

    }
}
