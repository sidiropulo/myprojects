using Sint.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sint
{
    class Recorder
    {
        
        List<RecordAction> recordActions = new List<RecordAction>();
        int startTime = 0;
        bool recordOn;
        public bool isRecording
        {
            get
            {
                return recordOn;
            }
            set
            {
                if(value)
                {
                    RecordOn();
                }else
                {
                    RecordStop();
                }
            }
        }
        public RecordAction[] RecordActions => recordActions.ToArray();
        public Recorder(SoundController controller)
        {
            controller.OnPlayNote += RecordNote;
        }
        public void RecordOn()
        {
            startTime = Millisecond();
            recordOn = true;
            recordActions.Clear();
        }
        public void RecordStop()
        {            
            recordOn = false;            
        }             
        public void RecordNote(Note note)
        {
            if (!recordOn)
                return;            
            recordActions.Add(new RecordAction(note, Millisecond() - startTime));
        }
        public int Millisecond()
        {
            return DateTime.Now.Minute*60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        }
    }
}
