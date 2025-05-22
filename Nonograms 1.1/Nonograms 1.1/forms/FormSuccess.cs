using Nonograms_1._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonograms_1._1.forms
{
    public partial class FormSuccess : Form
    {

        private int[,] readyMatrix; // готовая матрица
        // значения клеток в цифрах
        private int valueOfBlack = 1; // черная клетка 
        public FormSuccess(Crossword crossword)
        {
            InitializeComponent();
            panel.BackColor = SystemColors.Window;
            int N = crossword.Height;
            int M = crossword.Width;

            readyMatrix = new int[N, M];
            string matrixString = crossword.Matrix;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int index = i * M + j;
                    if (index < matrixString.Length)
                    {
                        readyMatrix[i, j] = int.Parse(Convert.ToString(crossword.Matrix[index]));
                    }
                }
            }
            createGameMatrix(N, M);

            labelNameOfCrossword.Text = crossword.Name;
        }
        private void createGameMatrix(int N, int M)
        {
            panel.Controls.Clear();

            int pixelWidth = panel.Width / M;
            int pixelHeight = panel.Height / N;
            int pixelSize = Math.Min(pixelWidth, pixelHeight);
            // начальные точки для центрирования рисунка по середине панели
            int x = (panel.Width - pixelSize * M) / 2;
            int y = (panel.Height - pixelSize * N) / 2;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Label pixel = new Label();
                    pixel.Name = $"pixel{i}{j}";
                    pixel.Size = new Size(pixelSize, pixelSize);
                    pixel.Location = new Point(x+j * pixelSize, y+i * pixelSize);

                    pixel.BackColor = (readyMatrix[i, j] == valueOfBlack) ? Color.Black : Color.White;

                    pixel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Controls.Add(pixel);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelNameOfCrossword_Click(object sender, EventArgs e)
        {

        }
    }
}
