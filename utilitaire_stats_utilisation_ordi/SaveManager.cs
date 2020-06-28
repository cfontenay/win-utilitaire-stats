using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace utilitaire_stats_utilisation_ordi
{
    public class SaveManager
    {
        private State CurrentState = new State();
        private string directorySavePath;
        private string currentProgramName;
        public SaveManager(string directorySavePath)
        {
            this.directorySavePath = directorySavePath;
            currentProgramName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

        }
        public void Update(State newState)
        {
            if (newState != CurrentState)
            {
                CurrentState = newState.Clone();
                Console.WriteLine(GetStringToSave());
                if (CurrentState.Name != currentProgramName)
                {
                    Save();
                }
            }
        }
        private void Save()
        {
            using var stream = new FileStream($"{directorySavePath}/{DateTime.Today.ToString("yyyy-MM-dd")}.txt",
                FileMode.Append,
                FileAccess.Write,
                FileShare.Write,
                1024,
                useAsync: true);
            var bytes = Encoding.UTF8.GetBytes(GetStringToSave());
            stream.WriteAsync(bytes, 0, bytes.Length);
        }
        private string GetStringToSave()
        {
            return $"{CurrentState.Name};{(CurrentState.SoundPlaying ? 1 : 0)};{DateTimeOffset.Now.ToUnixTimeMilliseconds()}\n";
        }
    }
}
