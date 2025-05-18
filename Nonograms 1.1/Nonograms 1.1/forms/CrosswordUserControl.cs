using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nonograms_1._1.Models;
using Nonograms_1._1.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nonograms_1._1.forms
{
    public partial class CrosswordUserControl : UserControl
    {
        private Crossword _crossword;
        private SolvingProcess _solvingProcess;
        private User _currentUser;

        private int valueOfBlack = 1;
        private int valueOfWhite = 0;
        private int valueOfX = 2;

        private int _countOfBlack = 0; //  счетчик черных клеток готового кроссворда для вычисления процента 
        private int _readyPercent = 0; // процент готовности решения

        public event EventHandler GameFormClosed;

        public CrosswordUserControl(Crossword crossword, User currentUser)
        {
            InitializeComponent();
            _crossword = crossword;
            _currentUser = currentUser;
            labelID.Text = "#" + Convert.ToString(_crossword.CrosswordID);
            labelSize.Text = $"Размер:{_crossword.Width}x{_crossword.Height}";
            var currentDiff = _crossword.Difficult;
            labelDifficult.Text = $"Сложность: {currentDiff.DifficultName}";
            labelStatus.Text = "Статус: не начат";
            labelProgress.Text = "Прогресс: 0%";

            // добавляем нужную по смыслу кроссворда картинку
            if (crossword.Width == crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardNxN;
            }

            else if (crossword.Width > crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardNxM;
            }
            else if (crossword.Width < crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardMxN;
            }
        }
        public CrosswordUserControl(SolvingProcess solvingProcess)
        {
            InitializeComponent();
            _solvingProcess = solvingProcess;
            _currentUser = solvingProcess.User;
            _crossword = solvingProcess.Crossword;

            labelID.Text = "#" + Convert.ToString(_crossword.CrosswordID);
            labelSize.Text = $"Размер:{_crossword.Width}x{_crossword.Height}";
            var currentDiff = _crossword.Difficult;
            labelDifficult.Text = $"Сложность: {currentDiff.DifficultName}";

            string matrix = _solvingProcess.Progress;
            string readyMatrix = _crossword.Matrix;
            for (int i = 0; i < readyMatrix.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToString(readyMatrix[i])) == valueOfBlack)
                {
                    _countOfBlack++;
                }
            }
            int countOfScores = 0; // подсчет правильных совпадений черных клеток с готовым кроссвордом
            for (int i = 0; i < readyMatrix.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToString(matrix[i])) == valueOfBlack && Convert.ToInt32(Convert.ToString(readyMatrix[i])) == valueOfBlack)
                {
                    countOfScores++;
                }
                else if (Convert.ToInt32(Convert.ToString(matrix[i])) == valueOfBlack && (Convert.ToInt32(Convert.ToString(readyMatrix[i])) == valueOfWhite || Convert.ToInt32(Convert.ToString(readyMatrix[i])) == valueOfX))
                {
                    countOfScores--;
                }
            }
            if (countOfScores < 0)
            {
                countOfScores = 0;
            }
            if (_countOfBlack == 0)
            {
                // Если в кроссворде нет чёрных клеток, считаем его полностью решённым (100%)
                _readyPercent = 100;
            }
            else
            {
                _readyPercent = Convert.ToInt32(Convert.ToDouble(countOfScores) / _countOfBlack * 100);
            }
            labelStatus.Text = "Статус: ";
            if (_readyPercent == 0)
            {
                labelStatus.Text += "не начат";
            }
            else if (_readyPercent == 100)
            {
                labelStatus.Text += "завершен";
            }
            else
            {
                labelStatus.Text += "начат";
            }
            labelProgress.Text = $"Прогресс: {_readyPercent}%";
            // добавляем нужную по смыслу кроссворда картинку
            if (_crossword.Width == _crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardNxN;
            }

            else if (_crossword.Width > _crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardNxM;
            }
            else if (_crossword.Width < _crossword.Height)
            {
                pictureBox.Image = Nonograms_1._1.Properties.Resources.hardMxN;
            }
        }
        private void CrosswordUserControl_Load(object sender, EventArgs e)
        {

        }

        private void CrosswordUserControl_Click(object sender, EventArgs e)
        {
            if (_crossword == null)
            {
                MessageBox.Show("Кроссворд не найден!");
                return;
            }
            if (_currentUser != null)
            {
                SolvingProcess solvingProcess = Program.context.SolvingProcesses.FirstOrDefault(x => x.CrosswordID == _crossword.CrosswordID && x.UsersID == _currentUser.UsersID);
                if (solvingProcess == null)
                {
                    solvingProcess = new SolvingProcess()
                    {
                        CrosswordID = _crossword.CrosswordID,
                        UsersID = _currentUser.UsersID,
                        StatusOfCrossword = false,
                        StartTime = DateTime.Now,
                        HintsUsed = 0,
                        LeadTime = 0,
                        Progress = new string('0', _crossword.Width * _crossword.Height) // Инициализируем прогресс   
                    };
                    Program.context.SolvingProcesses.Add(solvingProcess);
                    Program.context.SaveChanges();
                }
                GameForm gameForm = new GameForm(solvingProcess);
                gameForm.FormClosed += (s, args) =>
                {
                    GameFormClosed?.Invoke(this, EventArgs.Empty);
                };
                gameForm.ShowDialog(); // Блокирует главную форму
            }
            else
            {
                GameForm gameForm = new GameForm(_crossword);
                gameForm.FormClosed += (s, args) =>
                {
                    GameFormClosed?.Invoke(this, EventArgs.Empty);
                };
                gameForm.ShowDialog(); // Блокирует главную форму
            }
        }
    }
}
