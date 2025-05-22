using Nonograms_1._1.forms;
using Nonograms_1._1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nonograms_1._1.Forms
{
    public partial class GameForm : Form
    {
        // свойства матриц
        private int N; // длина в клетках
        private int M; // ширина  в  клетках
        private int[,] matrix; // заполняемая матрица
        private int[,] readyMatrix; // готовая матрица
        // значения клеток в цифрах
        private int valueOfX = 2; // зачеркнутый крестик
        private int valueOfBlack = 1; // черная клетка 
        private int valueOfWhite = 0; // белая клетка
        // переменные для полчения данных из бд
        private string name;
        private Crossword _crossword;
        private SolvingProcess _solvingProcess;
        // проценты
        private int _countOfBlack = 0; //  счетчик черных клеток готового кроссворда для вычисления процента 
        private int _readyPercent = 0; // процент готовности решения
        //подсказки
        private bool hintOrNot = false;
        private int hintsUsed = 0;
        private int maxOfHints = 10;
        // таймер
        public int A = 0; // десятки часов таймера
        public int B = 0; // часы таймера
        public int C = 0; // десятки минут таймера
        public int D = 0;  // минуты таймер
        public int E = 0; // десятки секунд таймера
        public int F = 0; // секунды таймера
        /// <summary>
        /// Конструктор игровой формы для неавторизованного пользователя
        /// </summary>
        /// <param name="crossword"></param>
        public GameForm(Crossword crossword)
        {
            InitializeComponent();

            this._crossword = crossword;
            // инициализируем компоненты матрицы
            N = _crossword.Height;
            M = _crossword.Width;
            // размер заполняемой матрицы
            matrix = new int[N, M];
            name = _crossword.Name;
            // размер готовой числовой матрицы
            readyMatrix = new int[N, M];
            // Заполняем готовую матрицу
            string matrixString = _crossword.Matrix;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int index = i * M + j;
                    if (index < matrixString.Length)
                    {
                        readyMatrix[i, j] = int.Parse(Convert.ToString(_crossword.Matrix[index]));
                    }
                }
            }
            // создаем матрицу(игровое поле) из Label
            createGameMatrix(N, M);

            // вычисление количества черных клеток у готового кроссворда
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (readyMatrix[i, j] == valueOfBlack)
                    {
                        _countOfBlack++;
                    }
                }
            }

            // устанавливаем таймер
            timer.Enabled = true;

            // подсказки
            buttonHint.Text = $"Подсказать {hintsUsed}/{maxOfHints}";

        }
        /// <summary>
        /// Конструктор  игровой формы  для авторизованного пользователя
        /// </summary>
        /// <param name="solvingProcess"></param>
        public GameForm(SolvingProcess solvingProcess)
        {
            this._solvingProcess = solvingProcess;

            this._crossword = Program.context.Crosswords.FirstOrDefault(x => x.CrosswordID == _solvingProcess.CrosswordID);
            if (_solvingProcess.LeadTime == null)
            {
                _solvingProcess.LeadTime = 0;
            }
            InitializeComponent();
            // инициализируем компоненты матрицы
            N = _crossword.Height;
            M = _crossword.Width;
            // размер заполняемой матрицы
            matrix = new int[N, M];
            // заполняем заполняемую матрицу
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int index = i * M + j;
                    if (index < _solvingProcess.Progress.Length)
                    {
                        matrix[i, j] = int.Parse(Convert.ToString(_solvingProcess.Progress[index]));
                    }
                }
            }
            name = _crossword.Name;
            // размер готовой числовой матрицы
            readyMatrix = new int[N, M];
            // Заполняем готовую матрицу
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int index = i * M + j;
                    if (index < _crossword.Matrix.Length)
                    {
                        readyMatrix[i, j] = int.Parse(Convert.ToString(_crossword.Matrix[index]));
                    }
                }
            }
            // создаем матрицу(игровое поле) из Label
            createGameMatrix(N, M);

            if (_solvingProcess.StatusOfCrossword == true)
            {
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
            // вычисление количества черных клеток у готового кроссворда
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (readyMatrix[i, j] == valueOfBlack)
                    {
                        _countOfBlack++;
                    }
                }
            }

            checkProgressPercent();
            // ставим таймер

            var leadTime = (int)_solvingProcess.LeadTime;

            // Часы
            int hours = leadTime / 3600;
            // Десятки часов
            A = hours / 10;
            // Единицы часов
            B = hours % 10;

            // Минуты
            int minutes = (leadTime % 3600) / 60;
            // Десятки минут
            C = minutes / 10;
            // Единицы минут
            D = minutes % 10;

            // Секунды
            int seconds = leadTime % 60;
            // Десятки секунд
            E = seconds / 10;
            // Единицы секунд
            F = seconds % 10;

            labelTime.Text = $"{A}{B}:{C}{D}:{E}{F}";

            if (_solvingProcess.StatusOfCrossword == false)
            {
                timer.Enabled = true;
            }

            // подсказки
            hintsUsed = (int)_solvingProcess.HintsUsed;
            buttonHint.Text = $"Подсказать {hintsUsed}/{maxOfHints}";

        }
        private void Pixel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!hintOrNot)
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
            }
            else
            {
                Label pixel = (Label)sender;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        string pixelName = $"pixel{i}{j}";
                        if (pixel.Name == pixelName)
                        {
                            if (readyMatrix[i, j] == valueOfBlack && pixel.BackColor != Color.Black)
                            {
                                pixel.BackColor = Color.Black;
                                pixel.Tag = null;

                                pixel.Invalidate();
                                hintsUsed++;
                            }
                            // значение закрашенной клетки
                            else if ((readyMatrix[i, j] == valueOfWhite || readyMatrix[i, j] == valueOfX) && pixel.BackColor == Color.Black || pixel.BackColor == Color.LightBlue && pixel.Tag == null)
                            {
                                pixel.BackColor = Color.LightBlue;
                                pixel.Tag = "cross";

                                pixel.Invalidate();
                                hintsUsed++;
                            }
                            if (hintsUsed == maxOfHints)
                            {
                                buttonHint.BackColor = SystemColors.Window;
                                hintOrNot = false;
                            }
                        }
                    }
                }

            }
            if (_solvingProcess == null)
            {

                UpdateMatrixForCrossword();
            }
            else
            {
                UpdateMatrixForSP();
            }
        }
        /// <summary>
        /// обновление числовой матрицы после взаимодействия с пользователем
        /// </summary>
        /// 
        private void checkProgressPercent()
        {
            int countOfScores = 0; // подсчет правильных совпадений черных клеток с готовым кроссвордом
            for (int i = 0; i < readyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < readyMatrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == valueOfBlack && readyMatrix[i, j] == valueOfBlack)
                    {
                        countOfScores++;
                    }
                    else if (matrix[i, j] == valueOfBlack && (readyMatrix[i, j] == valueOfWhite || readyMatrix[i, j] == valueOfX))
                    {
                        countOfScores--;
                    }
                }
            }

            _readyPercent = Convert.ToInt32(Convert.ToDouble(countOfScores) / _countOfBlack * 100);
            if (_readyPercent > 0)
            {
                progressBar.Value = _readyPercent;
            }
            else
            {
                progressBar.Value = 0;
            }
        }
        /// <summary>
        /// функция обновления матрицы после действия НЕавторизованного пользователя (работаем с таблицей Crossword)
        /// </summary>
        private void UpdateMatrixForCrossword()
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

            // обновление подсказок
            buttonHint.Text = $"Подсказать {hintsUsed}/{maxOfHints}";

            checkProgressPercent();
            // проверка на выигрыш
            bool winOrNot = true;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (matrix[i, j] == valueOfBlack && readyMatrix[i, j] != valueOfBlack || matrix[i, j] != valueOfBlack && readyMatrix[i, j] == valueOfBlack)
                    {
                        winOrNot = false;
                    }
                }
            }
            if (winOrNot)
            {
                timer.Enabled = false;
                FormSuccess formSuccess = new FormSuccess(_crossword);
                formSuccess.ShowDialog();
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
        /// <summary>
        /// функция обновления матрицы после действия авторизованного пользователя (работаем с таблицей SolvingProcess)
        /// </summary>
        private void UpdateMatrixForSP()
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

            // обновление подсказок
            buttonHint.Text = $"Подсказать {hintsUsed}/{maxOfHints}";

            checkProgressPercent();
            // проверка на выигрыш
            bool winOrNot = true;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (matrix[i, j] == valueOfBlack && readyMatrix[i, j] != valueOfBlack || matrix[i, j] != valueOfBlack && readyMatrix[i, j] == valueOfBlack)
                    {
                        winOrNot = false;
                    }
                }
            }
            if (winOrNot)
            {
                timer.Enabled = false;
                _solvingProcess.StatusOfCrossword = true;
                _solvingProcess.EndTime = DateTime.Now;
                Program.context.SaveChanges();
                FormSuccess formSuccess = new FormSuccess(_crossword);
                formSuccess.ShowDialog();
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
            // 1. Преобразуем текущую матрицу в строку прогресса
            StringBuilder progressBuilder = new StringBuilder(N * M);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    progressBuilder.Append(matrix[i, j]);
                }
            }

            // 2. Обновляем прогресс в объекте SolvingProcess
            _solvingProcess.Progress = progressBuilder.ToString();

            // 3. Обновляем количество использованных подсказок
            _solvingProcess.HintsUsed = hintsUsed;
            Program.context.SaveChanges();
        }
        /// <summary>
        /// Обработчик наведения курсора, для хорошей видимости выбираемой клетки
        /// </summary>
        private void Pixel_MouseEnter(object sender, EventArgs e)
        {

            Label pixel = (Label)sender;
            if (pixel.BackColor == Color.White)
            {
                pixel.BackColor = Color.LightBlue;
            }
        }

        /// <summary>
        /// Обработчик выхода курсора, и замены цвета на стандартный
        /// </summary>
        private void Pixel_MouseLeave(object sender, EventArgs e)
        {
            Label pixel = (Label)sender;
            if (pixel.BackColor == Color.LightBlue)
            {
                pixel.BackColor = Color.White;
            }
        }
        // Флаг для отслеживания, была ли форма закрыта через кнопку "Выход"

        private void buttonExit_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; // обязательно выключаем таймер, иначе счет будет идти, и счетчики складываться (как это работает хз).
            this.Close();
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
            int pixelSize;
            if (Math.Max(M, N) + digitXSize < 13)
            {
                pixelSize = Math.Min(panel.Width / (M + digitXSize), panel.Height / (N + digitXSize));
                panel.Size = new Size((maxRowDigits + M) * pixelSize, (maxColDigits + N) * pixelSize);
                CenterPanel();
            }
            else
            {
                pixelSize = Math.Min(panel.Width / (13), panel.Height / (13));
                panel.AutoScroll = true; // Включаем автопрокрутку
                panel.AutoScrollMinSize = new Size(0, 0); // Сброс минимального размера
                // Вычисляем общий размер кроссворда                                            
                int totalWidth = (maxRowDigits + M) * pixelSize;
                int totalHeight = (maxColDigits + N) * pixelSize;
                // Устанавливаем минимальный размер для прокрутки
                panel.AutoScrollMinSize = new Size(totalWidth, totalHeight);

            }
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
                        Font = new Font("Calibri", 72, FontStyle.Bold)
                    };
                    rowHintLabel.Click += digit_Click;
                    rowHintLabel.Paint += digit_Paint;
                    AdjustFontSize(rowHintLabel, pixelSize, pixelSize);
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
            // Генерация игрового поля с учетом прогресса
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Label pixel = new Label
                    {
                        Name = $"pixel{i}{j}",
                        Size = new Size(pixelSize, pixelSize),
                        Location = new Point((j + maxRowDigits) * pixelSize + offsetX,
                                           (i + maxColDigits) * pixelSize + offsetY),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Инициализация пикселей в зависимости от прогресса
                    if (matrix[i, j] == valueOfBlack)
                    {
                        pixel.BackColor = Color.Black;
                    }
                    else if (matrix[i, j] == valueOfX)
                    {
                        pixel.Tag = "cross";
                    }

                    pixel.MouseDown += Pixel_MouseDown;
                    pixel.MouseEnter += Pixel_MouseEnter;
                    pixel.MouseLeave += Pixel_MouseLeave;
                    pixel.Paint += digit_Paint;

                    panel.Controls.Add(pixel);
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
            if (count > 0) hints.Add(count); // если последняя клетка закрашена в черный и не сработала функция добавления count
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
            if (count > 0) hints.Add(count); // если последняя клетка закрашена в черный и не сработала функция добавления count
            return hints;
        }

        /// <summary>
        /// Подгоняет размер шрифта, чтобы все цифры поместились в клетках
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

                    if (textSize.Width <= maxWidth - 5 && textSize.Height <= maxHeight - 5)
                        break; // Если текст влезает, выходим

                    fontSize--; // Уменьшаем шрифт
                    testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
                }

                label.Font = testFont; // Применяем найденный размер шрифта
            }
        }
        /// <summary>
        /// клик по цифре подсказки, который меняет флаг для закраски крестиком
        /// </summary>
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


        private void GameForm_Load_1(object sender, EventArgs e)
        {
        }
        // выравнивание панели кроссворда
        private void CenterPanel()
        {
            // Получаем размеры формы и панели
            int formWidth = panel2.Width;  // Ширина клиентской области формы
            int formHeight = panel2.Height; // Высота клиентской области формы

            int panelWidth = panel.Width;  // Ширина панели
            int panelHeight = panel.Height; // Высота панели

            // Вычисляем координаты для центрирования панели
            int x = (formWidth - panelWidth) / 2;
            int y  = (formHeight - panelHeight) / 2;
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
        /// <summary>
        /// закраска клеток крестиком
        /// </summary>
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

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_solvingProcess != null)
            {
                // таймер для авторизованного пользвоателя
                _solvingProcess.LeadTime++;
                var leadTime = (int)_solvingProcess.LeadTime;

                // Часы
                int hours = leadTime / 3600;
                // Десятки часов
                A = hours / 10;
                // Единицы часов
                B = hours % 10;

                // Минуты
                int minutes = (leadTime % 3600) / 60;
                // Десятки минут
                C = minutes / 10;
                // Единицы минут
                D = minutes % 10;

                // Секунды
                int seconds = leadTime % 60;
                // Десятки секунд
                E = seconds / 10;
                // Единицы секунд
                F = seconds % 10;

                labelTime.Text = $"{A}{B}:{C}{D}:{E}{F}";
                Program.context.SaveChanges();
            }
            else
            {
                // таймер для неавторизованного пользвоателя
                // распределяем таймер по цифрам
                F++;
                if (F > 9)
                {
                    F = 0;
                    E++;
                    if (E > 5)
                    {
                        E = 0;
                        D++;
                        if (D > 9)
                        {
                            D = 0;
                            C++;
                            if (C > 5)
                            {
                                C = 0;
                                B++;
                                if (B > 9)
                                {
                                    B = 0;
                                    A++;
                                }
                            }
                        }
                    }
                }

                labelTime.Text = $"{A}{B}:{C}{D}:{E}{F}";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Подтверждение действия у пользователя
            var result = MessageBox.Show("Вы действительно хотите сбросить текущее решение?",
                                       "Подтверждение сброса",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            if (_solvingProcess != null)
            {
                // Сбрасываем статус решения
                _solvingProcess.StatusOfCrossword = false;

                // Создаем строку прогресса из нулей
                _solvingProcess.Progress = new string('0', N * M);

                // Обновляем таймер 
                _solvingProcess.StartTime = DateTime.Now;
                _solvingProcess.LeadTime = 0;
                _solvingProcess.HintsUsed = 0;
                _solvingProcess.EndTime = null;
                // Обновляем матрицу
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    // Сбрасываем значение в матрице
                    matrix[i, j] = 0;

                    // Находим соответствующий пиксель
                    string pixelName = $"pixel{i}{j}";
                    Label pixel = panel.Controls.Find(pixelName, true).FirstOrDefault() as Label;

                    if (pixel != null)
                    {
                        // Сбрасываем визуальное состояние
                        pixel.BackColor = Color.White;
                        pixel.Tag = null;
                        pixel.Invalidate();

                        // Обновляем подписки на события (более надежный способ)
                        pixel.MouseDown -= Pixel_MouseDown;
                        pixel.MouseDown += Pixel_MouseDown;
                    }
                }
            }
            // сброс таймера для неавторизованного пользователя
            if (_solvingProcess == null)
            {
                A = 0; // десятки часов таймера
                B = 0; // часы таймера
                C = 0; // десятки минут таймера
                D = 0;  // минуты таймер
                E = 0; // десятки секунд таймера
                F = 0; // секунды таймера
            }
            hintsUsed = 0;

            if (_solvingProcess != null)
            {
                // Обновляем данные в базе
                UpdateMatrixForSP();
                Program.context.SaveChanges();
            }
            else
            {
                UpdateMatrixForCrossword();
            }

            timer.Enabled = true;
            labelTime.Text = "00:00:00";
        }


        private void buttonHint_Click(object sender, EventArgs e)
        {
            if (hintsUsed < maxOfHints)
            {
                if (!hintOrNot)
                {
                    buttonHint.BackColor = Color.LightGreen;
                    hintOrNot = true;
                }
                else
                {

                    buttonHint.BackColor = SystemColors.Window;
                    hintOrNot = false;
                }
            }
        }
    }
}
