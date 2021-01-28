using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMIneSweeper
{
    public partial class ChangeSizeForm : Form
    {
        public delegate void ChangeSizeDelegate(int H, int W, int M);
        public int W { get; set; }
        public int H { get; set; }

        public int M { get; set; }

        ChangeSizeDelegate doOnClosing;
        public ChangeSizeForm(int H, int W, int M, ChangeSizeDelegate doOnClosing)
        {
            this.H = H;
            this.W = W;
            this.M = M;
            this.doOnClosing = doOnClosing;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            W = Int32.Parse(WBox.SelectedItem.ToString());
            H = Int32.Parse(HBox.SelectedItem.ToString());
            M = Int32.Parse(MBox.SelectedItem.ToString());
            Console.WriteLine($"{H} {W} {M}");
            Close();
            doOnClosing(H, W, M);
        }
    }
}
