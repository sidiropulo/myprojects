using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sint
{
    class SoundController
    {       
        const float upperIndex = 1.0594710288946644243999388472711f;
        int curOctav = 1;
        int duration = 50;
        List<float> octaves = new List<float>();


        public delegate void ChangeSound(Note note);
        public event ChangeSound OnPlayNote;
        public SoundController()
        {
            octaves.Add(65.41f);
            octaves.Add(130.82f);
            octaves.Add(261.63f);
            octaves.Add(523.26f);
        }
        public void SetDuration(int value) => duration = value;
        public void SetOctav(int value) => curOctav = value;
        public void PlayNote(int index) => PlayNote(index, duration, curOctav);
        public void PlayNote(Note note) => PlayNote(note.Index, note.Duration, note.Octave);
        public void PlayNote(int index, int duration, int octave)
        {
            float note = octaves[octave];
            for (int i = 0; i < index; i++)
                note *= upperIndex;
            Console.Beep(Convert.ToInt32(note), duration);
            OnPlayNote?.Invoke(new Note(index, duration, curOctav));
        }
    }
}
