﻿
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Nonograms_1._1.Forms
{
    public partial class CreateForm : Form
    {
        private int N;
        private int M;
        private int[,] matrix; // заполняемая матрица
        private int levelDifficult = 0;
        private string matrixToString;
        private int valueOfX = 2;
        private int valueOfBlack = 1;
        private int valueOfWhite = 0;
        public CreateForm()
        {
            InitializeComponent();

            var difficults = Program.context.Difficults.OrderBy(d=>d.DifficultID).ToList();
            foreach( var difficult in difficults )
            {
               comboBoxDifficult.Items.Add(difficult.DifficultName.ToString());
            }
            // инициализируем компоненты матрицы

            N = Convert.ToInt32(numericUpDownWidth.Value); 

            M = Convert.ToInt32(numericUpDownHeight.Value); 

            // размер заполняемой матрицы
            matrix = new int[N, M];
            // создаем матрицу(игровое поле) из Label
            createGameMatrix(N, M);
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }
        private void Pixel_MouseDown(object sender, MouseEventArgs e)
        {
            // проверка нажатия левой кнопки по пикселю
            if (e.Button == MouseButtons.Left)
            {
                Label pixel = (Label)sender;
                pixel.Tag = null;
                if (pixel.BackColor == Color.LightBlue)
                {
                    pixel.BackColor = Color.Black; // Меняем цвет пикселя

                }
                // проверка повторного нажатия по пикселю
                else if (pixel.BackColor == Color.Black)
                {
                    pixel.BackColor = Color.LightBlue;
                }
            }

            // проверка нажатия правой кнопки по пикселю
            if (e.Button == MouseButtons.Right)
            {
                Label pixel = (Label)sender;

                if (pixel.Tag == null)
                {
                    pixel.BackColor = Color.LightBlue;
                    // Для показа крестика:
                    pixel.Tag = "cross";
                    pixel.Invalidate(); // Перерисовываем
                }
                // проверка повторного нажатия по пикселю
                else if (pixel.Tag == "cross")
                {
                    pixel.BackColor = Color.LightBlue;
                    //сброс крестика
                    pixel.Tag = null;
                    pixel.Invalidate();
                }
            }
            UpdateMatrix();
        }
        /// <summary>
        /// обновление числовой матрицы после взаимодействия с пользователем
        /// </summary>
        private void UpdateMatrix()
        {
            matrixToString = null;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    string pixelName = $"pixel{i}{j}";
                    Label pixel = panel.Controls.Find(pixelName, true).FirstOrDefault() as Label;
                    // значение закрашенной клетки
                    if ((matrix[i, j] == valueOfWhite || matrix[i, j] == valueOfX) && pixel.BackColor == Color.Black)
                    {
                        matrix[i, j] = valueOfBlack;
                    }
                    // значения пустой клетки
                    if ((matrix[i, j] == valueOfX && pixel.Tag == null) ||
                        matrix[i, j] == valueOfBlack && pixel.BackColor == Color.LightBlue)
                    {
                        matrix[i, j] = valueOfWhite;
                    }
                    // значение крестика
                    if (matrix[i, j] == valueOfWhite && pixel.Tag == "cross")
                    {
                        matrix[i, j] = valueOfX;
                    }
                    matrixToString += matrix[i, j];
                }
            }

        }
        // Обработчик наведения курсора
        private void Pixel_MouseEnter(object sender, EventArgs e)
        {

            Label pixel = (Label)sender;
            if (pixel.BackColor == Color.White)
            {
                pixel.BackColor = Color.LightBlue;
            }
        }

        // Обработчик ухода курсора
        private void Pixel_MouseLeave(object sender, EventArgs e)
        {
            Label pixel = (Label)sender;
            if (pixel.BackColor == Color.LightBlue)
            {
                pixel.BackColor = Color.White;
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// создаем матрицу(игровое поле) из Label
        /// </summary>
        private void createGameMatrix(int N, int M)
        {
            // само игровое поле, с которым взаимодействует пользователь
            int pixelSize; // Размер одного "пикселя"
            if (N > M)
            {
                pixelSize = panel.Width / N;
            }
            else
            {
                pixelSize = panel.Width / M;
            }
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
                    pixel.Location = new Point(x+j * pixelSize,y+ i * pixelSize);
                    pixel.BackColor = Color.White;
                    pixel.FlatStyle = FlatStyle.Flat;
                    pixel.BorderStyle = BorderStyle.FixedSingle;
                    pixel.ForeColor = Color.Black;
                    // обработчики
                    pixel.MouseDown += Pixel_MouseDown; // Обработка клика
                    pixel.MouseEnter += Pixel_MouseEnter; // Обработка наведения курсора
                    pixel.MouseLeave += Pixel_MouseLeave; // Обработка выведения кусора
                    pixel.Paint += (sender, e) =>
                    {
                        var label = (Label)sender;
                        if (label.Tag?.ToString() == "cross") // Используем Tag как флаг
                        {
                            using (Pen pen = new Pen(Color.Black, 2))
                            {
                                e.Graphics.DrawLine(pen, 0, 0, label.Width, label.Height);
                                e.Graphics.DrawLine(pen, label.Width, 0, 0, label.Height);
                            }
                        }
                    };
                    panel.Controls.Add(pixel);
                }
            }
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string matrix = matrixToString;
            int width = M;
            int height = N;
            int difficult = levelDifficult;
            bool isMatrixFilled = false;
            foreach (var item in matrix)
            {
                if (item == '1')
                {
                    isMatrixFilled = true;
                }
            }
            if (isMatrixFilled && name != null && width > 2 && height > 2 && difficult > 0)
            {
                var names = Program.context.Crosswords.Where(x => x.Name == name).FirstOrDefault();
                if (name != null && names == null)
                {
                    if (difficult > 0)
                    {
                        Crossword crossword = new Crossword()
                        {
                            Name = name,
                            Matrix = matrix,
                            Width = width,
                            Height = height,
                            DifficultID = difficult,
                        };
                        Program.context.Crosswords.Add(crossword);
                        Program.context.SaveChanges();
                        MessageBox.Show("Успешное добавление кроссворда!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        

        private void numericUpDownLength_ValueChanged(object sender, EventArgs e)
        {
            panel.Controls.Clear(); // Очищаем панель перед созданием новых кнопок
            N = Convert.ToInt32(numericUpDownHeight.Value); // Размер матрицы N x N
            createGameMatrix(N, M);

            matrix = new int[N, M];

        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            ;
            panel.Controls.Clear(); // Очищаем панель перед созданием новых кнопок
            M = Convert.ToInt32(numericUpDownWidth.Value); // Размер матрицы N x N
            createGameMatrix(N, M);

            matrix = new int[N, M];
        }

        private void comboBoxDifficult_SelectedIndexChanged(object sender, EventArgs e)
        {
            levelDifficult = comboBoxDifficult.SelectedIndex + 1;
        }

        private void CreateForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
