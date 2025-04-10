using Nonograms.Forms;
using Nonograms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;

namespace Nonograms
{
    public partial class MenuForm : Form
    {
        private int currentUserID = 0;
        public MenuForm()
        {
            InitializeComponent();
            fillPanelOfCrosswords();
        }
        private void fillPanelOfCrosswords()
        {
            panelOfCrosswords.Controls.Clear();
            int crosswordPanelWidth = panelOfCrosswords.Size.Width / 2;
            int crosswordPanelHeight = (panelOfCrosswords.Size.Height - 20) / 3;
            var crosswords = Program.context.Crosswords;
            for (int i = 0; i < crosswords.Count(); i++)
            {
                Crossword crossword = Program.context.Crosswords.FirstOrDefault(x => x.CrosswordID == i + 1);
                // создание панели кроссворда
                Panel panel = new Panel()
                {
                    Name = $"crossword{i}",
                    Size = new Size(crosswordPanelWidth, crosswordPanelHeight),
                    Location = new Point(20, 20 + (crosswordPanelHeight + 20) * i),
                    BackColor = SystemColors.Window,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = i + 1,  // прибавляем один,т.к. в sql счет начинается с 1
                };
                panelOfCrosswords.Controls.Add(panel);

                // создание элементов на этой панели

                // добавляем картинку
                PictureBox pictureBox = new PictureBox()
                {
                    Name = $"pictureCrossword{i}",
                    Size = new Size(crosswordPanelHeight - 10, crosswordPanelHeight - 10),
                    SizeMode = PictureBoxSizeMode.Zoom,  // Масштабируем, сохраняя пропорции
                    Anchor = AnchorStyles.None,          // Не привязываем к краям
                };
                // добавляем нужную по смыслу кроссворда картинку
                if (crossword.Width == crossword.Height)
                {
                    pictureBox.Image = Properties.Resources.hardNxN;
                }

                else if (crossword.Width > crossword.Height)
                {
                    pictureBox.Image = Properties.Resources.hardNxM;
                }
                else if (crossword.Width < crossword.Height)
                {
                    pictureBox.Image = Properties.Resources.hardMxN;
                }

                pictureBox.Location = new Point(5,(panel.Height - pictureBox.Height) / 2 // Центрируем по высоте
                );

                panel.Controls.Add(pictureBox);

                // добавляем подпись
                Label label = new Label()
                {
                    Name = $"labelCrossword{i}",
                    Text =$"#{i+1}"+Environment.NewLine+ $"Размер: {crossword.Width}x{crossword.Height}",
                    AutoSize = true,
                    Font = new Font("Calibri", 16, FontStyle.Regular), // Настраиваем шрифт
                };

                // Размещаем Label правее картинки
                label.Location = new Point(
                    (crosswordPanelWidth - label.Width*2),
                    (panel.Height - label.Height*2) / 2 // Центрируем по высоте
                );

                panel.Controls.Add(label);
                // Добавляем обработчик кликов к самой панели
                panel.Click += panelPlay_Click;
                panel.MouseEnter += cursorHand_MouseEnter;
                panel.MouseLeave += cursorHand_MouseLeave;
                // Добавляем обработчик кликов ко всем элементам внутри панели
                foreach (Control control in panel.Controls)
                {
                    control.Click += panelPlay_Click;
                    control.MouseEnter += cursorHand_MouseEnter;
                    control.MouseLeave += cursorHand_MouseLeave;
                }
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (currentUserID != 0)
            {
                currentUserID = 0;
                updateUIForUser(currentUserID);
                MessageBox.Show(
                            "Вы вышли из аккаунта",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

            }
            this.Close();
        }

        private void buttonToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // передаем значение ID авторизованного пользователя из формы авторизации в эту форму
                currentUserID = loginForm.currentUserID;

                // обновляем интерфейс главной формы
                updateUIForUser(currentUserID);

            }
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
        }
        private void panelPlay_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            while (control != null && !(control is Panel))
            {
                control = control.Parent; // Поднимаемся вверх по иерархии
            }
            Panel panel = control as Panel;
            if (panel == null || panel.Tag == null) return;

            int crosswordID = Convert.ToInt32(panel.Tag);
            Crossword crossword = Program.context.Crosswords.FirstOrDefault(x => x.CrosswordID == crosswordID);
            User user = Program.context.Users.FirstOrDefault(x => x.UsersID == currentUserID);
            if (crossword == null)
            {
                MessageBox.Show("Кроссворд не найден!");
                return;
            }
            if(currentUserID != 0)
            {
                SolvingProcess solvingProcess =  Program.context.SolvingProcesses.FirstOrDefault(x => x.CrosswordID == crossword.CrosswordID && x.UsersID == user.UsersID);
                if (solvingProcess != null)
                {   
                    solvingProcess = new SolvingProcess()
                    {
                        CrosswordID = crossword.CrosswordID,
                        UsersID= user.UsersID,
                        StatusOfCrossword = false,
                        StartTime = DateTime.Now,
                        HintsUsed= 0,
                        Mistakes = 
                    };
                    Program.context.Users.Add(user);
                    Program.context.SaveChanges();
                }
            }
            this.Hide(); // Скрываем главную форму
            using (GameForm gameForm = new GameForm(crossword))
            {
                gameForm.ShowDialog(); // Блокирует главную форму
            }
            if (!this.IsDisposed)
                this.Show();
        }

        private void buttonToRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
            }

        }
        private void updateUIForUser(int currentUserID)
        {
            // поиск конкретного пользователя
            User user = Program.context.Users.Find(currentUserID);
            if (user != null)
            {
                // обновление интерфейса
                labelUsername.Text = user.UserLogin;
            }
            else
            {
                labelUsername.Text = "User";
                labelStat.Visible = true;
            }
            if (currentUserID == 1)
            {
                buttonGoCreate.Enabled = true;
                buttonGoCreate.Visible = true;
            }
            else
            {
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
        private void cursorHand_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.Cursor = Cursors.Hand; // Устанавливаем курсор "рука"
        }

        private void cursorHand_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.Cursor = Cursors.Default; // Возвращаем стандартный курсор
        }
    }
}
