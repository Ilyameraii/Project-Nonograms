using Nonograms_1._1.forms;
using Nonograms_1._1.Forms;
using Nonograms_1._1.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Nonograms_1._1
{
    public partial class MenuForm : Form
    {
        private User currentUser;
        private int currentLevel;
        private bool showOnlyReady;
        public MenuForm()
        {
            InitializeComponent();
            addButtonLevels();
            updateUIForUser(currentUser);
        }
        private void addButtonLevels()
        {
            // добавляем сложности
            var difficults = Program.context.Difficults.OrderBy(d => d.DifficultLevel).ToList();
            foreach (var difficult in difficults)
            {
                Button button = new Button()
                {
                    Name = $"buttonDifficult{difficult.DifficultLevel}",
                    Width = buttonCompleted.Width,
                    Text = difficult.DifficultName,
                    BackColor = SystemColors.Window,
                    Margin = new Padding(13, 13, 0, 13),
                    Font = buttonCompleted.Font,
                    Tag = difficult.DifficultLevel,
                };
                button.Click += buttonLevel_Click;
                FLPLevels.Controls.Add(button);
            }
        }
        private void buttonLevel_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            foreach (Button buttons in FLPLevels.Controls)
            {
                if (buttons.Tag != button.Tag)
                {
                    buttons.BackColor = SystemColors.Window;
                }
            }
            if (currentLevel != (int)button.Tag)
            {
                button.BackColor = Color.LightGreen;
                currentLevel = (int)button.Tag;
            }
            else
            {
                button.BackColor = SystemColors.Window;
                currentLevel = 0;
            }
            fillPanelOfCrosswords();
        }
        private void buttonCompleted_Click(object sender, EventArgs e)
        {
            if (!showOnlyReady)
            {
                buttonCompleted.BackColor = Color.LightGreen;
                showOnlyReady = true;
            }
            else
            {
                buttonCompleted.BackColor = SystemColors.Window;
                showOnlyReady = false;
            }
            fillPanelOfCrosswords();
        }
        private void fillPanelOfCrosswords()
        {
            FLPanelOfCrosswords.Controls.Clear();
            var crosswords = Program.context.Crosswords.OrderBy(x => x.CrosswordID).ToList();
            if (currentLevel != 0)
            {
                var difficult = Program.context.Difficults.Where(d=>d.DifficultLevel == currentLevel).FirstOrDefault();
                crosswords = crosswords.Where(x => x.DifficultID  == difficult.DifficultID).ToList();
            }
            // заполнение листа кроссвордов для авторизованного пользователя

            foreach (Crossword crossword in crosswords)
            {
                CrosswordUserControl crosswordUserControl = new CrosswordUserControl(crossword, currentUser);
                if (currentUser != null)
                {
                    SolvingProcess solvingProcess = Program.context.SolvingProcesses
                        .Where(s => s.CrosswordID == crossword.CrosswordID && s.UsersID == currentUser.UsersID).FirstOrDefault();
                    if (solvingProcess != null)
                    {
                        crosswordUserControl = new CrosswordUserControl(solvingProcess);
                        if (!showOnlyReady || solvingProcess.StatusOfCrossword == true)
                        {
                            FLPanelOfCrosswords.Controls.Add(crosswordUserControl);
                        }
                    }
                    else
                    {
                        if (!showOnlyReady)
                        {
                            FLPanelOfCrosswords.Controls.Add(crosswordUserControl);
                        }
                    }
                        crosswordUserControl.GameFormClosed += (s, args) =>
                        {
                            updateUIForUser(currentUser);
                        };

                    
                }
                else
                {
                    if (!showOnlyReady)
                    {
                        FLPanelOfCrosswords.Controls.Add(crosswordUserControl);
                    }
                }
            }
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                currentUser = null;
                updateUIForUser(currentUser);
                MessageBox.Show(
                            "Вы вышли из аккаунта",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

            }
            else
            {
                this.Close();
            }
        }
        private void buttonToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // передаем значение ID авторизованного пользователя из формы авторизации в эту форму
                currentUser = Program.context.Users.FirstOrDefault(x => x.UsersID == loginForm.currentUserID);

                // обновляем интерфейс главной формы
                updateUIForUser(currentUser);

            }
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonToRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
            }

        }
        private void updateUIForUser(User currentUser)
        {

            if (currentUser != null)
            {
                // обновление интерфейса
                var readySolvingProcessesOfUser = Program.context.SolvingProcesses.Where(s => s.UsersID == currentUser.UsersID && s.StatusOfCrossword == true).ToList();
                if (readySolvingProcessesOfUser.Count > 0)
                {
                    labelStat.Text = $"Пройденных кроссвордов:  {readySolvingProcessesOfUser.Count}" + Environment.NewLine;
                    int countOfDifficult = 0;
                    int countOfHintsUsed = 0;
                    foreach (var process in readySolvingProcessesOfUser)
                    {
                        var crossword = process.Crossword;
                        countOfDifficult += crossword.Difficult.DifficultLevel;
                        countOfHintsUsed += (int)process.HintsUsed;
                    }
                    var middleDiff = Program.context.Difficults.Where(d => d.DifficultLevel ==
                    countOfDifficult / readySolvingProcessesOfUser.Count).FirstOrDefault();
                    labelStat.Text += $"Средняя сложность кроссворда:{middleDiff.DifficultName}";


                    labelStat.Text += Environment.NewLine;
                    labelStat.Text += $"В среднем подсказок:  {countOfHintsUsed / readySolvingProcessesOfUser.Count}";
                }
                else
                {
                    labelStat.Text = $"Пройденных кроссвордов:  0" + Environment.NewLine;
                    labelStat.Text += $"Средняя сложность кроссворда: неизвестно" + Environment.NewLine;
                    labelStat.Text += $"В среднем подсказок: 0";

                }
                labelStatTitle.Visible = true;
                labelStat.Visible = true;
                labelUsername.Text = currentUser.UserLogin;
                if (currentUser.RoleID == 1)
                {
                    buttonGoCreate.Enabled = true;
                    buttonGoCreate.Visible = true;
                }
                else
                {
                    buttonGoCreate.Enabled = false;
                    buttonGoCreate.Visible = false;
                }
            }
            else
            {
                labelStat.Text = "";
                labelUsername.Text = "User";
                labelStatTitle.Visible = false;
                labelStat.Visible = false;
                buttonGoCreate.Enabled = false;
                buttonGoCreate.Visible = false;
            }

            fillPanelOfCrosswords();
        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGoCreate_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем главную форму
            CreateForm createForm = new CreateForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
            }

            fillPanelOfCrosswords();
            this.Show();

        }


        private void FLPanelOfCrosswords_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
