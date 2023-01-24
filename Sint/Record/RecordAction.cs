using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sint.Record
{
    class RecordAction
    {
        Note note;
        int time;
        public RecordAction(Note note, int deltaTime)
        {
            time = deltaTime;
            this.note = note;
        }
        public Note GetNote() => note;
        public int GetTime() => time;
        public override string ToString() => $"{time},{note}";        
    }
}
