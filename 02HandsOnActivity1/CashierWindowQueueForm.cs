using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02HandsOnActivity1
{
    public partial class CashierWindowQueue : Form
    {
        public CashierWindowQueue()
        {
            InitializeComponent();
        }

        private int _tick;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach(object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void CashierWindowQueue_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _tick++;
                lblTime.Text = _tick.ToString();
                if (_tick == 15)
                {
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                    timer1.Stop();
                    _tick = 0;
                }
            }
            catch
            {
                timer1.Stop();
                MessageBox.Show("Theres nothing in the Queue right now.", "Message");
                _tick = 0;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
