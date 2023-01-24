using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sint.Record
{
    class Player
    {
        private static Timer timer;
        RecordAction[] actions;
        int curAction = 0;
        SoundController controller;
        Recorder recorder;
        bool playerOn;
        public bool isPlaying
        {
            get
            {
                return playerOn;
            }
            set
            {
                playerOn = value;
                if (!playerOn)
                {
                    Stop();
                }else
                {
                    Play();
                }
            }
        }
        public Player(SoundController controller, Recorder recorder)
        {
            timer = new Timer(NotePlay, null, System.Threading.Timeout.Infinite, 0);
            this.controller = controller;
            this.recorder = recorder;
        }
        public void Play()
        {
            this.actions = recorder.RecordActions;
            if (actions.Length == 0)
                return;
            curAction = 0;
            playerOn = true;
            NotePlay(null);            
        }
        public void Stop()
        {
            timer.Change(System.Threading.Timeout.Infinite, 0);
            playerOn = false;
        }
        private void NotePlay(Object o)
        {            
            controller.PlayNote(actions[curAction].GetNote());
            curAction++;
            if (curAction == actions.Length)
            {
                Stop();
                return;
            }
            timer.Change(0, actions[curAction].GetTime());            
        }
    }
}
