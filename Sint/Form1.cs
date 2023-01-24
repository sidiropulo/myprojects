using Sint.Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sint
{
    public partial class Form1 : Form
    {
        SoundController soundController = new SoundController();
        Recorder recorder;
        Player player;
        public Form1()
        {
            InitializeComponent();
            recorder = new Recorder(soundController);
            player = new Player(soundController,recorder);
        }

        private void button1_Click(object sender, EventArgs e) => soundController.PlayNote(0);

        private void button2_Click(object sender, EventArgs e) => soundController.PlayNote(1);

        private void button3_Click(object sender, EventArgs e) => soundController.PlayNote(2);

        private void button4_Click(object sender, EventArgs e) => soundController.PlayNote(3);

        private void button5_Click(object sender, EventArgs e) => soundController.PlayNote(4);

        private void button10_Click(object sender, EventArgs e) => soundController.PlayNote(5);

        private void button9_Click(object sender, EventArgs e) => soundController.PlayNote(6);

        private void button8_Click(object sender, EventArgs e) => soundController.PlayNote(7);

        private void button7_Click(object sender, EventArgs e) => soundController.PlayNote(8);

        private void button6_Click(object sender, EventArgs e) => soundController.PlayNote(9);

        private void button12_Click(object sender, EventArgs e) => soundController.PlayNote(10);

        private void button11_Click(object sender, EventArgs e) => soundController.PlayNote(11);

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => soundController.SetOctav(0);

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => soundController.SetOctav(1);

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => soundController.SetOctav(2);

        private void radioButton4_CheckedChanged(object sender, EventArgs e) => soundController.SetOctav(3);

        private void trackBar1_Scroll(object sender, EventArgs e) => soundController.SetDuration(trackBar1.Value);

        private void record_Click(object sender, EventArgs e)
        {
            if(recorder.isRecording)
            {
                recorder.isRecording = false;
                recordButton.BackColor = Color.White;
                recordButton.Text = "R";
            }else
            {
                recorder.isRecording = true;
                recordButton.BackColor = Color.Red;
                recordButton.Text = "S";
            }
        }

        private void playRecord_Click(object sender, EventArgs e)
        {
            player.Play();
        }
    }
}
