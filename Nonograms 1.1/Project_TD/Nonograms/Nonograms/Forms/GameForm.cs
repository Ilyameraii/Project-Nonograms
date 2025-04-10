using Nonograms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nonograms.Forms
{
    public partial class GameForm : Form
    {

        private int N;
        private int M;
        private int[,] matrix; // заполняемая матрица
        private int[,] readyMatrix; // готовая матрица
        private int valueOfX = 2;
        private int valueOfBlack = 1;
        private int valueOfWhite = 0;
        private string name;
        public GameForm(Crossword crossword)
        {
            InitializeComponent();
            // инициализируем компоненты матрицы
            N = crossword.Width;
            M = crossword.Height;
            // размер заполняемой матрицы
            matrix = new int[N, M];
            name = crossword.Name;
            // размер готовой числовой матрицы
            readyMatrix = new int[N, M];
            // Заполняем готовую матрицу
            string matrixString = crossword.Matrix;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int index = i * M + j;
                    if (index < matrixString.Length)
                    {
                        readyMatrix[i, j] = int.Parse(Convert.ToString(matrixString[index]));
                    }
                }
            }
            // создаем матрицу(игровое поле) из Label
            createGameMatrix(N, M);

            // Выводим результат
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sb.Append(readyMatrix[i, j] + " ");
                }
                sb.AppendLine();
            }
            label2.Text = sb.ToString();
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

                }
            }

            label1.Text = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    label1.Text += $"{matrix[i, j],3}";
                }
                label1.Text += Environment.NewLine;
            }
            // проверка на выигрыш
            bool winOrNot = true;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (matrix[i, j] == valueOfBlack && readyMatrix[i, j] == valueOfWhite || matrix[i, j] != valueOfBlack && readyMatrix[i, j] == valueOfBlack)
                    {
                        winOrNot = false;
                    }
                }
            }
            if (winOrNot)
            {
                MessageBox.Show("Вы победили!\nИмя кроссворда: " + name, "Успех!", MessageBoxButtons.OK);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        string pixelName = $"pixel{i}{j}";
                        Label pixel = panel.Controls.Find(pixelName, true).FirstOrDefault() as Label;
                        // делаем некликабельными пиксели
                        pixel.MouseDown -= Pixel_MouseDown;
                    }
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

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }
        /// <summary>
        /// Создаём игровое поле и панели с цифрами
        /// </summary>
        private void createGameMatrix(int N, int M)
        {
            panel.Controls.Clear(); // Очищаем панель перед созданием новой матрицы

            // Определяем максимальное количество чисел в подсказках
            int maxRowDigits = 0;
            int maxColDigits = 0;

            for (int i = 0; i < N; i++)
                maxRowDigits = Math.Max(maxRowDigits, GetHintsForRow(i).Count);

            for (int j = 0; j < M; j++)
                maxColDigits = Math.Max(maxColDigits, GetHintsForColumn(j).Count);

            // Максимальный размер отступа под цифры
            int digitXSize = Math.Max(maxRowDigits, maxColDigits);

            // Вычисляем размер клетки так, чтобы все влезало
            int pixelSize = Math.Min(panel.Width / (M + digitXSize), panel.Height / (N + digitXSize));
            panel.Size = new Size((maxRowDigits + M) * pixelSize, (maxColDigits + N) * pixelSize);
            CenterPanel();
            // Вычисляем корректные отступы для центрирования
            int offsetX = 0;
            int offsetY = 0;

            // Генерация чисел для столбцов (прижимаем к нижнему краю)
            for (int j = 0; j < M; j++)
            {
                List<int> columnHints = GetHintsForColumn(j);
                int startY = offsetY + (maxColDigits - columnHints.Count) * pixelSize; // Смещение вниз

                for (int k = 0; k < columnHints.Count; k++)
                {
                    Label colHintLabel = new Label
                    {
                        Name = $"col{j}_{k}",
                        Text = columnHints[k].ToString(),
                        Size = new Size(pixelSize, pixelSize),
                        Location = new Point((j + maxRowDigits) * pixelSize + offsetX, startY + (k * pixelSize)),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.DarkGray,
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Calibri", 72, FontStyle.Bold)
                    };
                    colHintLabel.Click += digit_Click;
                    colHintLabel.Paint += digit_Paint;
                    AdjustFontSize(colHintLabel, pixelSize, pixelSize);
                    panel.Controls.Add(colHintLabel);
                }
            }
            // Генерация чисел для строк (прижимаем к правому краю)
            for (int i = 0; i < N; i++)
            {
                List<int> rowHints = GetHintsForRow(i);
                int startX = offsetX + (maxRowDigits - rowHints.Count) * pixelSize; // Смещение вправо

                for (int k = 0; k < rowHints.Count; k++)
                {
                    Label rowHintLabel = new Label
                    {
                        Name = $"row{i}_{k}",
                        Text = rowHints[k].ToString(),
                        Size = new Size(pixelSize, pixelSize),
                        Location = new Point(startX + (k * pixelSize), (i + maxColDigits) * pixelSize + offsetY),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.DarkGray,
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Calibri", 20, FontStyle.Bold)
                    };
                    rowHintLabel.Click += digit_Click;
                    rowHintLabel.Paint += digit_Paint;
                    AdjustFontSize(rowHintLabel, pixelSize - 2, pixelSize - 2);
                    panel.Controls.Add(rowHintLabel);
                }
            }
            // поиск минимального размера шрифта
            float minSize = 72f;
            for (int i = 0; i < N; i++)
            {
                List<int> rowHints = GetHintsForRow(i);
                for (int k = 0; k < rowHints.Count; k++)
                {
                    string rowName = $"row{i}_{k}";
                    Label row = panel.Controls.Find(rowName, true).FirstOrDefault() as Label;
                    minSize = Math.Min(minSize, row.Font.Size);
                }
            }
            for (int i = 0; i < M; i++)
            {

                List<int> columnHints = GetHintsForColumn(i);
                for (int k = 0; k < columnHints.Count; k++)
                {
                    string colName = $"col{i}_{k}";
                    Label col = panel.Controls.Find(colName, true).FirstOrDefault() as Label;
                    minSize = Math.Min(minSize, col.Font.Size);
                }
            }

            // выравнивание шрифтов
            for (int i = 0; i < N; i++)
            {
                List<int> rowHints = GetHintsForRow(i);
                for (int k = 0; k < rowHints.Count; k++)
                {
                    string rowName = $"row{i}_{k}";
                    Label row = panel.Controls.Find(rowName, true).FirstOrDefault() as Label;
                    row.Font = new Font(row.Font.FontFamily, minSize, row.Font.Style);
                }
            }
            for (int i = 0; i < M; i++)
            {

                List<int> columnHints = GetHintsForColumn(i);
                for (int k = 0; k < columnHints.Count; k++)
                {
                    string colName = $"col{i}_{k}";
                    Label col = panel.Controls.Find(colName, true).FirstOrDefault() as Label;
                    col.Font = new Font(col.Font.FontFamily, minSize, col.Font.Style);
                }
            }
            // Генерация игрового поля
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Label pixel = new Label
                    {
                        Name = $"pixel{i}{j}",
                        Size = new Size(pixelSize, pixelSize),
                        Location = new Point((j + maxRowDigits) * pixelSize + offsetX, (i + maxColDigits) * pixelSize + offsetY),
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        BorderStyle = BorderStyle.FixedSingle,
                        ForeColor = Color.Black
                    };

                    // Обработчики событий
                    pixel.MouseDown += Pixel_MouseDown;
                    pixel.MouseEnter += Pixel_MouseEnter;
                    pixel.MouseLeave += Pixel_MouseLeave;
                    pixel.Paint += digit_Paint;

                    panel.Controls.Add(pixel);
                    matrix[i, j] = valueOfWhite;
                }
            }
            // Заполняем ВСЁ пространство панели клетками (включая подсказки)
            for (int y = 0; y < maxColDigits + N; y++)
            {
                for (int x = 0; x < maxRowDigits + M; x++)
                {
                    // Пропускаем левый верхний угол (где x < maxRowDigits И y < maxColDigits)
                    if (x < maxRowDigits && y < maxColDigits)
                        continue;
                    // Проверяем, не является ли эта клетка уже созданной подсказкой или игровым полем
                    bool isHintOrPixel = false;
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl.Location.X == x * pixelSize && ctrl.Location.Y == y * pixelSize)
                        {
                            isHintOrPixel = true;
                            break;
                        }
                    }

                    // Если это пустое место - заполняем серой клеткой
                    if (!isHintOrPixel)
                    {
                        Label backgroundCell = new Label
                        {
                            Size = new Size(pixelSize, pixelSize),
                            Location = new Point(x * pixelSize, y * pixelSize),
                            BackColor = Color.LightGray,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        panel.Controls.Add(backgroundCell);
                    }
                }
            }
        }


        /// <summary>
        /// Получает группы подряд идущих единиц для столбца
        /// </summary>
        private List<int> GetHintsForColumn(int col)
        {
            List<int> hints = new List<int>();
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                if (readyMatrix[i, col] == valueOfBlack)
                {
                    count++;
                }
                else if (count > 0)
                {
                    hints.Add(count);
                    count = 0;
                }
            }
            if (count > 0) hints.Add(count);
            return hints;
        }

        /// <summary>
        /// Получает группы подряд идущих единиц для строки
        /// </summary>
        private List<int> GetHintsForRow(int row)
        {
            List<int> hints = new List<int>();
            int count = 0;
            for (int j = 0; j < M; j++)
            {
                if (readyMatrix[row, j] == valueOfBlack)
                {
                    count++;
                }
                else if (count > 0)
                {
                    hints.Add(count);
                    count = 0;
                }
            }
            if (count > 0) hints.Add(count);
            return hints;
        }

        /// <summary>
        /// Подгоняет размер шрифта, чтобы текст поместился в Label
        /// </summary>
        void AdjustFontSize(Label label, int maxWidth, int maxHeight)
        {
            using (Graphics g = label.CreateGraphics())
            {
                float fontSize = label.Font.Size;
                Font testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);

                while (fontSize > 1)
                {
                    SizeF textSize = g.MeasureString(label.Text, testFont);

                    if (textSize.Width <= maxWidth - 4 && textSize.Height <= maxHeight - 4)
                        break; // Если текст влезает, выходим

                    fontSize--; // Уменьшаем шрифт
                    testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
                }

                label.Font = testFont; // Применяем найденный размер шрифта
            }
        }

        private void digit_Click(object sender, EventArgs e)
        {
            Label digit = (Label)sender;

            if (digit.Tag == null)
            {
                digit.Tag = "ready"; // или true/false, или новый объект
            }
            else if (digit.Tag == "ready")
            {
                digit.Tag = null;
            }

            digit.Invalidate(); // Перерисовать
        }

        private void panel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void GameForm_Load_1(object sender, EventArgs e)
        {

        }
        private void CenterPanel()
        {
            // Получаем размеры формы и панели
            int formWidth = this.ClientSize.Width;  // Ширина клиентской области формы
            int formHeight = this.ClientSize.Height; // Высота клиентской области формы

            int panelWidth = panel.Width;  // Ширина панели
            int panelHeight = panel.Height; // Высота панели

            // Вычисляем координаты для центрирования панели
            int x = (formWidth - panelWidth) / 2;
            int y = (formHeight - panelHeight) / 2 - formHeight / 20; // Сдвиг панели по вертикали

            // Устанавливаем положение панели
            panel.Location = new Point(x, y);

            // Центрируем все элементы внутри панели (например, игровое поле и подсказки)
            foreach (Control ctrl in panel.Controls)
            {
                // Если нужно центрировать элементы внутри панели:
                int elementX = (panel.Width - ctrl.Width) / 2;
                int elementY = (panel.Height - ctrl.Height) / 2;

                // Устанавливаем координаты для каждого элемента
                ctrl.Location = new Point(elementX, elementY);
            }
        }
        private void digit_Paint(object sender, PaintEventArgs e)
        {
            var label = (Label)sender;
            if (label.Tag?.ToString() == "ready" || label.Tag?.ToString() == "cross")
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    // Получаем размеры клиентской области метки (без учета границ и отступов)
                    int clientWidth = label.ClientSize.Width;
                    int clientHeight = label.ClientSize.Height;

                    // Центр метки
                    int centerX = clientWidth / 2;
                    int centerY = clientHeight / 2;

                    // Размер крестика, который зависит от меньшего размера стороны
                    int crossSize = Math.Min(clientWidth, clientHeight) / 2;

                    // Рисуем крестик
                    e.Graphics.DrawLine(pen, centerX - crossSize, centerY - crossSize, centerX + crossSize, centerY + crossSize);
                    e.Graphics.DrawLine(pen, centerX + crossSize, centerY - crossSize, centerX - crossSize, centerY + crossSize);
                }
            }
        }


    }
}
