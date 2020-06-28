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
            return true;
        }
        public static bool operator !=(State s1, State s2)
        {
            return true;
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
