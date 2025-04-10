using Nonograms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonograms.Forms
{
    public partial class LoginForm : Form
    {
        public int currentUserID { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBoxUnvisible_Click(object sender, EventArgs e)
        {
            pictureBoxUnvisible.Visible = false;
            pictureBoxVisible.Visible = true;

            textBoxPassword.UseSystemPasswordChar = false;
        }

        private void pictureBoxVisible_Click(object sender, EventArgs e)
        {
            pictureBoxVisible.Visible = false;
            pictureBoxUnvisible.Visible = true;
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Пример проверки авторизации
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            try
            {
                List<User> users = Program.context.Users.ToList();
                User u = users.FirstOrDefault(p => p.UserLogin == login && p.UserPassword == password);
                if (u != null)
                {
                    currentUserID = u.UsersID;
                    // Если авторизация успешна, закрываем форму с результатом OK
                    MessageBox.Show(
                        "Успешный вход!", 
                        "Заголовок", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Неверный логин или пароль!", 
                        "Ошибка", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        private void textBoxPassword_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
