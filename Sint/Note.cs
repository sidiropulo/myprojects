using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sint
{
    class Note
    {
        int index;
        int duration;
        int octave;
        public Note(int index, int duration, int octave)
        {
            this.index = index;
            this.duration = duration;
            this.octave = octave;
        }
        public Note(string text)
        {
            string[] lines = text.Split(';');
            this.index = Convert.ToInt32(lines[0]);
            this.duration = Convert.ToInt32(lines[1]);
            this.octave = Convert.ToInt32(lines[2]);
        }
        public int Index => index;
        public int Duration => duration;
        public int Octave => octave;
        public override string ToString() => $"{index};{duration};{octave}";        
    }
}
