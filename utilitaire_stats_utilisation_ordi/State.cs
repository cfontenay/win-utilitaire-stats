using System;
using System.Collections.Generic;
using System.Text;

namespace utilitaire_stats_utilisation_ordi
{
    public class State
    {
        public string Name { get; set; }
        public bool SoundPlaying { get; set; }

        public static bool operator ==(State s1, State s2)
        {
            return s1.Name == s2.Name && s1.SoundPlaying == s2.SoundPlaying;
        }
        public static bool operator !=(State s1, State s2)
        {
            return !(s1 == s2);
        }
        public State Clone()
        {
            return new State()
            {
                Name = this.Name,
                SoundPlaying = this.SoundPlaying
            };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
