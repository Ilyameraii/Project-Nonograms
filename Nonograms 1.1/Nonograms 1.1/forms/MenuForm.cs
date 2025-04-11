using Nonograms_1._1.forms;
using Nonograms_1._1.Forms;
using Nonograms_1._1.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nonograms_1._1
{
    public partial class MenuForm : Form
    {
        private User currentUser;
        private int currentDifficult = 0;
        public MenuForm()
        {
            InitializeComponent();
            fillPanelOfCrosswords();
        }
        private void OnGameFormClosed(object sender, EventArgs e)
        {
            fillPanelOfCrosswords();
        }
        private void fillPanelOfCrosswords()
        {
            FLPanelOfCrosswords.Controls.Clear();
            var crosswords = Program.context.Crosswords;
            for (int i = 0; i < crosswords.Count(); i++)
            {
                CrosswordUserControl crosswordUserControl;
                Crossword crossword = Program.context.Crosswords.FirstOrDefault(x => x.CrosswordID == i + 1);
                if (currentUser != null)
                {
                    SolvingProcess solvingProcess = Program.context.SolvingProcesses.FirstOrDefault(x => x.UsersID == currentUser.UsersID && x.CrosswordID == crossword.CrosswordID);
                    if (solvingProcess != null)
                    {
                        crosswordUserControl = new CrosswordUserControl(solvingProcess);
                    }
                    else
                    {
                        crosswordUserControl = new CrosswordUserControl(crossword,  currentUser);
                    }
                }
                else
                {
                    crosswordUserControl = new CrosswordUserControl(crossword, currentUser);
                }
                // Передаем метод обновления панели в UserControl
                crosswordUserControl.GameFormClosed += (s, args) =>
                {
                    fillPanelOfCrosswords();  // Обновляем панель
                };

                if (currentDifficult != crossword.Difficult && currentDifficult > 0 && currentDifficult < 4)
                {
                    continue;
                }
                else if (currentUser != null)
                {
                    SolvingProcess solvingProcess = Program.context.SolvingProcesses.FirstOrDefault(x => x.UsersID == currentUser.UsersID && x.CrosswordID == crossword.CrosswordID);
                    if (solvingProcess != null)
                    {
                        if (currentDifficult == 4 && solvingProcess.StatusOfCrossword == false)
                        {
                            continue;
                        }
                    }
                    else if(currentDifficult == 4)
                    {
                        continue;
                    }
                }
                else if (currentDifficult == 4)
                {
                    continue;
                }
                FLPanelOfCrosswords.Controls.Add(crosswordUserControl);

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

            fillPanelOfCrosswords();
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
            fillPanelOfCrosswords();
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
                labelUsername.Text = currentUser.UserLogin;
                if (currentUser.UsersID == 1)
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
                labelUsername.Text = "User";
                labelStat.Visible = true;
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

        private void panelOfCrosswords_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            if (currentDifficult != 1)
            {
                currentDifficult = 1;
                buttonEasy.BackColor = Color.LightGreen;
                buttonMedium.BackColor = SystemColors.Window;
                buttonHard.BackColor = SystemColors.Window;
                buttonCompleted.BackColor = SystemColors.Window;
            }
            else
            {
                currentDifficult = 0;
                buttonEasy.BackColor = SystemColors.Window;
            }
            fillPanelOfCrosswords();
        }

        private void buttonMedium_Click(object sender, EventArgs e)
        {
            if (currentDifficult != 2)
            {
                currentDifficult = 2;
                buttonEasy.BackColor = SystemColors.Window;
                buttonMedium.BackColor = Color.LightGreen;
                buttonHard.BackColor = SystemColors.Window;
                buttonCompleted.BackColor = SystemColors.Window;
            }
            else
            {
                currentDifficult = 0;
                buttonMedium.BackColor = SystemColors.Window;
            }
            fillPanelOfCrosswords();
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            if (currentDifficult != 3)
            {
                currentDifficult = 3;
                buttonEasy.BackColor = SystemColors.Window;
                buttonMedium.BackColor = SystemColors.Window;
                buttonHard.BackColor = Color.LightGreen;
                buttonCompleted.BackColor = SystemColors.Window;
            }
            else
            {
                currentDifficult = 0;
                buttonHard.BackColor = SystemColors.Window;
            }
            fillPanelOfCrosswords();
        }

        private void buttonCompleted_Click(object sender, EventArgs e)
        {
            if (currentDifficult != 4)
            {
                currentDifficult = 4;
                buttonEasy.BackColor = SystemColors.Window;
                buttonMedium.BackColor = SystemColors.Window;
                buttonHard.BackColor = SystemColors.Window;
                buttonCompleted.BackColor = Color.LightGreen;
            }
            else
            {
                currentDifficult = 0;
                buttonCompleted.BackColor = SystemColors.Window;
            }
            fillPanelOfCrosswords();
        }

        private void FLPanelOfCrosswords_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
