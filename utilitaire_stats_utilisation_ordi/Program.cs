using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace utilitaire_stats_utilisation_ordi
{
    class Program
    {
        

        

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
        

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        /*
        public static List<string> GetOpenWindows()
        {
            var shellWindow = GetShellWindow();
            List<string> windowNames = new List<string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windowNames.Add(builder.ToString());
                return true;
            }, 0);

            return windowNames;
        }
        */


        static void Main(string[] args)
        {
            var stateManager = new StateManager();
            var saveManager = new SaveManager(args[0]);


            while (true)
            {
                stateManager.Update();
                saveManager.Update(stateManager.CurrentState);
                Thread.Sleep(200);
            }
       
        }
    }
}
