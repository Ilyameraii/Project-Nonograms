namespace Nonograms_1._1
{
    partial class MenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelUser = new System.Windows.Forms.Panel();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonGoCreate = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonToLogin = new System.Windows.Forms.Button();
            this.buttonToRegistration = new System.Windows.Forms.Button();
            this.panelStat = new System.Windows.Forms.Panel();
            this.labelStatTitle = new System.Windows.Forms.Label();
            this.labelStat = new System.Windows.Forms.Label();
            this.panelOfLevels = new System.Windows.Forms.Panel();
            this.buttonCompleted = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.FLPanelOfCrosswords = new System.Windows.Forms.FlowLayoutPanel();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.FLPLevels = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelStat.SuspendLayout();
            this.panelOfLevels.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.panelUser);
            this.panelTop.Controls.Add(this.buttonGoCreate);
            this.panelTop.Controls.Add(this.panelHeader);
            this.panelTop.Controls.Add(this.buttonLogout);
            this.panelTop.Controls.Add(this.buttonToLogin);
            this.panelTop.Controls.Add(this.buttonToRegistration);
            this.panelTop.Controls.Add(this.panelStat);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1064, 100);
            this.panelTop.TabIndex = 0;
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.pictureBoxAvatar);
            this.panelUser.Controls.Add(this.labelUsername);
            this.panelUser.Location = new System.Drawing.Point(29, 3);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(139, 94);
            this.panelUser.TabIndex = 7;
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Nonograms_1._1.Properties.Resources.avatar;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(40, 3);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 4;
            this.pictureBoxAvatar.TabStop = false;
            this.pictureBoxAvatar.Click += new System.EventHandler(this.pictureBoxAvatar_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(4, 66);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(133, 22);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "User";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonGoCreate
            // 
            this.buttonGoCreate.Enabled = false;
            this.buttonGoCreate.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.buttonGoCreate.Location = new System.Drawing.Point(880, 65);
            this.buttonGoCreate.Name = "buttonGoCreate";
            this.buttonGoCreate.Size = new System.Drawing.Size(75, 26);
            this.buttonGoCreate.TabIndex = 2;
            this.buttonGoCreate.Text = "Создать";
            this.buttonGoCreate.UseVisualStyleBackColor = true;
            this.buttonGoCreate.Visible = false;
            this.buttonGoCreate.Click += new System.EventHandler(this.buttonGoCreate_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.label);
            this.panelHeader.Location = new System.Drawing.Point(474, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(300, 94);
            this.panelHeader.TabIndex = 8;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Nonograms_1._1.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 24);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(76, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(221, 94);
            this.label.TabIndex = 8;
            this.label.Text = "Японский кроссворд";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.buttonLogout.Location = new System.Drawing.Point(961, 68);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(91, 23);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Выйти";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonToLogin
            // 
            this.buttonToLogin.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.buttonToLogin.Location = new System.Drawing.Point(961, 39);
            this.buttonToLogin.Name = "buttonToLogin";
            this.buttonToLogin.Size = new System.Drawing.Size(91, 23);
            this.buttonToLogin.TabIndex = 2;
            this.buttonToLogin.Text = "Авторизация";
            this.buttonToLogin.UseVisualStyleBackColor = true;
            this.buttonToLogin.Click += new System.EventHandler(this.buttonToLogin_Click);
            // 
            // buttonToRegistration
            // 
            this.buttonToRegistration.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToRegistration.Location = new System.Drawing.Point(961, 10);
            this.buttonToRegistration.Name = "buttonToRegistration";
            this.buttonToRegistration.Size = new System.Drawing.Size(91, 23);
            this.buttonToRegistration.TabIndex = 1;
            this.buttonToRegistration.Text = "Регистрация";
            this.buttonToRegistration.UseVisualStyleBackColor = true;
            this.buttonToRegistration.Click += new System.EventHandler(this.buttonToRegistration_Click);
            // 
            // panelStat
            // 
            this.panelStat.Controls.Add(this.labelStatTitle);
            this.panelStat.Controls.Add(this.labelStat);
            this.panelStat.Location = new System.Drawing.Point(174, 4);
            this.panelStat.Name = "panelStat";
            this.panelStat.Padding = new System.Windows.Forms.Padding(10);
            this.panelStat.Size = new System.Drawing.Size(294, 91);
            this.panelStat.TabIndex = 7;
            // 
            // labelStatTitle
            // 
            this.labelStatTitle.AutoSize = true;
            this.labelStatTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelStatTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatTitle.ForeColor = System.Drawing.Color.White;
            this.labelStatTitle.Location = new System.Drawing.Point(13, 13);
            this.labelStatTitle.Name = "labelStatTitle";
            this.labelStatTitle.Size = new System.Drawing.Size(84, 19);
            this.labelStatTitle.TabIndex = 6;
            this.labelStatTitle.Text = "Статистика";
            this.labelStatTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelStatTitle.Visible = false;
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStat.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStat.ForeColor = System.Drawing.Color.White;
            this.labelStat.Location = new System.Drawing.Point(10, 66);
            this.labelStat.Margin = new System.Windows.Forms.Padding(0);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(0, 15);
            this.labelStat.TabIndex = 8;
            // 
            // panelOfLevels
            // 
            this.panelOfLevels.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelOfLevels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOfLevels.Controls.Add(this.FLPLevels);
            this.panelOfLevels.Controls.Add(this.buttonCompleted);
            this.panelOfLevels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOfLevels.Location = new System.Drawing.Point(0, 0);
            this.panelOfLevels.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelOfLevels.Name = "panelOfLevels";
            this.panelOfLevels.Size = new System.Drawing.Size(1064, 50);
            this.panelOfLevels.TabIndex = 0;
            // 
            // buttonCompleted
            // 
            this.buttonCompleted.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCompleted.Location = new System.Drawing.Point(943, 13);
            this.buttonCompleted.Margin = new System.Windows.Forms.Padding(13);
            this.buttonCompleted.Name = "buttonCompleted";
            this.buttonCompleted.Size = new System.Drawing.Size(109, 24);
            this.buttonCompleted.TabIndex = 3;
            this.buttonCompleted.Tag = "0";
            this.buttonCompleted.Text = "Решенные";
            this.buttonCompleted.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCompleted.UseVisualStyleBackColor = false;
            this.buttonCompleted.Click += new System.EventHandler(this.buttonCompleted_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.FLPanelOfCrosswords);
            this.panelMain.Controls.Add(this.panelOfLevels);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1064, 508);
            this.panelMain.TabIndex = 1;
            // 
            // FLPanelOfCrosswords
            // 
            this.FLPanelOfCrosswords.AutoScroll = true;
            this.FLPanelOfCrosswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelOfCrosswords.Location = new System.Drawing.Point(0, 50);
            this.FLPanelOfCrosswords.Name = "FLPanelOfCrosswords";
            this.FLPanelOfCrosswords.Size = new System.Drawing.Size(1064, 458);
            this.FLPanelOfCrosswords.TabIndex = 1;
            this.FLPanelOfCrosswords.Paint += new System.Windows.Forms.PaintEventHandler(this.FLPanelOfCrosswords_Paint);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // FLPLevels
            // 
            this.FLPLevels.Dock = System.Windows.Forms.DockStyle.Left;
            this.FLPLevels.Location = new System.Drawing.Point(0, 0);
            this.FLPLevels.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.FLPLevels.Name = "FLPLevels";
            this.FLPLevels.Size = new System.Drawing.Size(927, 48);
            this.FLPLevels.TabIndex = 4;
            this.FLPLevels.WrapContents = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1064, 608);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelStat.ResumeLayout(false);
            this.panelStat.PerformLayout();
            this.panelOfLevels.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonToLogin;
        private System.Windows.Forms.Button buttonToRegistration;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label labelStatTitle;
        private System.Windows.Forms.Panel panelStat;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonGoCreate;
        private System.Windows.Forms.Panel panelOfLevels;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel FLPanelOfCrosswords;
        private System.Windows.Forms.Button buttonCompleted;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label labelStat;
        private System.Windows.Forms.FlowLayoutPanel FLPLevels;
    }
}

