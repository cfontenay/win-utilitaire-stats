using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace utilitaire_stats_utilisation_ordi
{
    public class StateManager
    {
        private MMDevice DefaultDevice;
        public State CurrentState { get; private set; }
        public StateManager()
        {
            DefaultDevice = Utils.GetDefaultRenderDevice();
        }
        public void Update()
        {
            var nameFocusedWindow = Utils.GetForegroundWindowName();
            bool audioIsPlaying = Utils.IsAudioPlaying(DefaultDevice);
            CurrentState = new State()
            {
                Name = nameFocusedWindow,
                SoundPlaying = audioIsPlaying
            };
        }
    }
}
