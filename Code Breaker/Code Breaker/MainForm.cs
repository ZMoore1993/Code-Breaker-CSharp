using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Breaker
{
    public partial class MainForm : Form
    {
        CodeBreakerEngine cb = new CodeBreakerEngine();
        string roundtxt;
        Timer stopwatch;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            stopwatch = new Timer();
            roundtxt = lblRound.Text;
            lbGuesses.DataSource = cb.UserGuesses;
            stopwatch.Tick += new EventHandler(stopwatch_tick);
            ResetForm();
        }

        private void stopwatch_tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum && cb.Round <= 10)
            {
                progressBar1.Value++;
            }
            else
            {
                stopwatch.Stop();
                cb.RoundOver();
            }
            
        }


        private void ResetForm()
        {
            //lbGuesses.Items.Clear();
            List<Button> buttonList = Controls.OfType<Button>().ToList();
            char num = '1';
            foreach (Button b in buttonList)
            {
                if (!b.Name.Equals("btnInstructions") && !b.Name.Equals("btnStart"))
                {
                    b.Text = b.Text[b.Text.Length-1].ToString();
                    b.Click += new EventHandler(button_click);
                    b.Enabled = false;
                    num++;
                }
            }
            lblRound.Text = roundtxt + cb.Round.ToString();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            cb.AddDigitToUserNumber(btn.Text);
            lblNumber.Text += btn.Text;
        }

        private void BtnInstructions_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            if (MessageBox.Show(cb.PrintInstructions(), "Game Instructions", MessageBoxButtons.OK) == DialogResult.OK)
                stopwatch.Start();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            foreach (Button b in Controls.OfType<Button>().ToList())
            {
                if (!b.Name.Equals("btnInstructions") && !b.Name.Equals("btnStart"))
                {
                    b.Enabled = false;
                }
            }
            stopwatch.Start();
            stopwatch.Interval = 1000;
        }
    }
}
