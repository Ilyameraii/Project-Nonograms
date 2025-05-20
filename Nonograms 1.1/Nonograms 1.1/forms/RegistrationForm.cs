using Nonograms_1._1.Models;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nonograms_1._1.Forms
{
    public partial class RegistrationForm: Form
    {
        private bool _canRegLogin = false;
        private bool _canRegPassword = false;
        private bool _canRegEmail = false;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxUnvisible_Click(object sender, EventArgs e)
        {
            pictureBoxUnvisible.Visible = false;
            pictureBoxVisible.Visible = true;

            textBoxPassword.UseSystemPasswordChar = false;
            textBoxRetryPassword.UseSystemPasswordChar = false;
        }

        private void pictureBoxVisible_Click(object sender, EventArgs e)
        {
            pictureBoxVisible.Visible = false;
            pictureBoxUnvisible.Visible = true;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxRetryPassword.UseSystemPasswordChar = true;
        }

        private void labelRegistration_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLogin.BackColor == Color.Red) {

                textBoxLogin.BackColor = SystemColors.Window;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.BackColor == Color.Red)
            {

                textBoxPassword.BackColor = SystemColors.Window;
            }
        }

        private void textBoxRetryPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.BackColor == Color.Red)
            {

                textBoxPassword.BackColor = SystemColors.Window;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if(textBoxEmail.BackColor == Color.Red)
            {
                textBoxEmail.BackColor = SystemColors.Window;
            }
        }
        private void canRegistration()
        {
            _canRegLogin = true;
            _canRegEmail = true;
            _canRegPassword = true;

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text.Trim();
            string retryPassword = textBoxRetryPassword.Text;
            string email = textBoxEmail.Text;
            string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (Program.context.Users.Any(u => u.UserLogin == login) ||
               login.Length < 3)
            {
                _canRegLogin = false;
            }

            if (password.Length < 8 ||
                password != retryPassword ||
                password.Contains(" "))
            {
                _canRegPassword = false;
            }

            if(!Regex.IsMatch(email, patternEmail)){
                _canRegEmail = false;
            }
        }
        private void textBoxColors()
        {
            if (!_canRegLogin)
            {
                textBoxLogin.BackColor = Color.Red;
            }

            if (!_canRegPassword)
            {
                textBoxPassword.BackColor = Color.Red;
            }
            if (!_canRegEmail)
            {
                textBoxEmail.BackColor = Color.Red;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            textBoxRetryPassword.Text = "";
            textBoxEmail.Text = "";
        }
        private void createNewUser()
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            User user = new User()
            {
                UserLogin = login,
                UserPassword = password,
                UserEmail = email,
                RegistrationDate = DateTime.Now,
            };
            Program.context.Users.Add(user);
            Program.context.SaveChanges();

            // фикс странного бага с добавлением пробелов к концу пароля (trim не работает)
            string connectionString = "data source=localhost;initial catalog=Nonograms;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = @"UPDATE Users 
                          SET UserPassword = TRIM(UserPassword)
                          WHERE UserPassword LIKE '% ' OR UserPassword LIKE ' %'";

                    using (SqlCommand command = new SqlCommand(sql, connection)) {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar)) // Проверяем все пробельные символы
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            canRegistration(); // проверка на корректность ввода данных

            textBoxColors(); // маркировка неправильно введенных данных

            if (_canRegLogin && _canRegPassword && _canRegEmail)
            {
                // создание нового пользователя
                createNewUser();

                // оповещение
                MessageBox.Show(
                        "Успешная регистрация!",
                        "Регистрация",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
