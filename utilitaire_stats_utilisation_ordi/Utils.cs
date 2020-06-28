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
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
    }
}
