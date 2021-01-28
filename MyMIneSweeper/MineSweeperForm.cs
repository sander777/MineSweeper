using MyMIneSweeper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyMineSweeper
{

    class MineButton : Button
    {
        public bool IsMine { get; set; }
        public bool IsClosed { get; set; } = true;

        public bool IsFlaged { get; set; } = false;
        public int MinesAround { get; set; }
        public MineButton() : base() { }
    }

    public partial class MineSweeperForm : Form
    {
        delegate void MineSweeperHandler();
        event MineSweeperHandler LoseHandler;
        event MineSweeperHandler WinHandler;

        Timer timer = new Timer()
        {
            Interval = 1000,
        };

        uint flagCounter = 0;

        bool isMinePuted = false;
        int W = 10, H = 10, M = 15;
        List<MineButton> field = new List<MineButton>();

        DateTime start;

        private MineButton GetMineOn(int i, int j)
        {
            if (i >= 0 && i < H && j >= 0 && j < W)
                return field.ElementAt(i * W + j);
            else
                return null;
        }

        private void PutButtons()
        {
            if (field.Count > 0)
            {
                foreach(MineButton b in field)
                {
                    Controls.Remove(b);
                }
                field.Clear();
            }
            Random rng = new Random(); 
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    MineButton button = new MineButton()
                    {
                        Location = new System.Drawing.Point(10 + 50 * j, 30 + 50 * i),
                        Name = $"{i}_{j}",
                        Text = " ",
                        Size = new System.Drawing.Size(50, 50),
                        TabIndex = 0,
                        UseVisualStyleBackColor = true,
                        BackColor = Color.DarkGray,
                    };
                    button.MouseDown += new MouseEventHandler(ButtonEventHandler);
                    Controls.Add(button);
                    field.Add(button);
                }
            }
        }

        private void PutMines(MineButton dontPut)
        {
            isMinePuted = true;
            Random rng = new Random();
            List<MineButton> futureMines = field.OrderBy(x => rng.Next()).Where(x => x != dontPut).Take(M).ToList();
            foreach(MineButton b in futureMines)
            {
                b.IsMine = true;
            }
            PutNumbers();
        }

        private void PutNumbers()
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    MineButton mine = GetMineOn(i, j);
                    if (mine != null && mine.IsMine == false)
                    {
                        int count = 0;
                        for (int m = -1; m < 2; m++)
                        {
                            for (int n = -1; n < 2; n++)
                            {
                                if (GetMineOn(i + m, j + n)?.IsMine == true)
                                {
                                    count++;
                                }
                            }
                        }
                        mine.MinesAround = count;
                    }
                }
            }
        }

        private int OpenMine(MineButton mine)
        {
            if (mine != null && mine.IsClosed && !mine.IsFlaged)
            {
                if (!isMinePuted)
                {
                    PutMines(mine);
                    start = DateTime.Now; 
                    timer.Start();
                }
                if (mine.IsMine)
                {
                    mine.BackColor = Color.Red;
                    LoseHandler();
                }
                else
                {
                    mine.BackColor = Color.LightGray;
                    mine.IsClosed = false;
                    if (mine.MinesAround > 0)
                        mine.Text = mine.MinesAround.ToString();
                    else
                    {
                        int idx = field.FindIndex(x => x.GetHashCode() == mine.GetHashCode());
                        int i = idx / W, j = idx % W;
                        for (int m = -1; m < 2; m++)
                        {
                            for (int n = -1; n < 2; n++)
                            {
                                if (m != 0 || n != 0)
                                    if (OpenMine(GetMineOn(i + m, j + n)) == 1)
                                    {
                                        return 1;
                                    }

                            }
                        }
                    }
                    if (IsWin())
                    {
                        WinHandler();
                        return 1;
                    }
                }
                return 0;
            }
            return -1;
        }

        private void FlagButton(MineButton mine)
        {
            if (mine.IsClosed)
            {
                if (!mine.IsFlaged)
                {
                    mine.BackColor = Color.Yellow;
                    mine.IsFlaged = !mine.IsFlaged;
                    flagCounter++;
                }
                else
                {
                    mine.BackColor = Color.DarkGray;
                    mine.IsFlaged = !mine.IsFlaged;
                    flagCounter--;
                }
                flagToMine.Text = $"{flagCounter}\\{M}";
            }
        }

        private void ButtonEventHandler(object s, MouseEventArgs e)
        {
            MineButton button = s as MineButton;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    OpenMine(button);
                    break;
                case MouseButtons.Right:
                    FlagButton(button);
                    break;
            }
        }

        bool IsWin()
        {
            if (!isMinePuted) return false;
            foreach(MineButton m in field)
            {
                if (!m.IsMine && m.IsClosed) return false;
            }
            return true;
        }

        void ShowLoseMessage()
        {
            foreach (MineButton m in field)
            {
                if (m.IsMine)
                {
                    m.BackColor = Color.Red;
                }
            }
            MessageBox.Show("You Lose");
        }

        void ShowWinMessage()
        {
            MessageBox.Show("You Win");
        }

        void RestartGame()
        {
            foreach(MineButton m in field)
            {
                m.IsClosed = true;
                m.IsFlaged = false;
                m.IsMine = false;
                m.Text = " ";
                m.BackColor = Color.DarkGray;
                m.MinesAround = 0;
            }
            isMinePuted = false;
            start = DateTime.Now;
            timerText.Text = "0:0:0";
            flagToMine.Text = $"0\\{M}";
            flagCounter = 0;
            timer.Stop();
        }

        void ChangeSize(int H, int W, int M)
        {
            this.H = H;
            this.W = W;
            this.M = M;
            RestartGame();
            PutButtons();
            SetApp();
        }

        void ChangeSizeHandler(object s, EventArgs e)
        {
            ChangeSizeForm form = new ChangeSizeForm(H, W, M, ChangeSize);
            form.Show();
        }

        void IncrementTimer(object s, EventArgs e)
        {
            TimeSpan pass = DateTime.Now - start;
            string print = $"{pass.Hours}:{pass.Minutes}:{pass.Seconds}";
            timerText.Text = print;
        }

        void StopTimer()
        {
            timer.Stop();
        }

        void SetApp()
        {
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(50 * W + 150, 40 + 50 * H + 20);
            timerText.Location = new Point(50 * W + 20, 10);
            flagToMine.Location = new Point(50 * W + 20, 100);
            ResumeLayout(true);
            PutButtons();
        }

        public MineSweeperForm()
        {
            InitializeComponent();
            SetApp();
            LoseHandler += StopTimer;
            LoseHandler += ShowLoseMessage;
            LoseHandler += RestartGame;
            WinHandler += StopTimer;
            WinHandler += ShowWinMessage;
            WinHandler += RestartGame;
            timer.Tick += new EventHandler(IncrementTimer);
        }
    }
}
