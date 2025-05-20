namespace Nonograms_1._1.Forms
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonHint = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.blackBlockLabel = new System.Windows.Forms.Label();
            this.whiteBlockLabel = new System.Windows.Forms.Label();
            this.crossBlockLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonHideControl = new System.Windows.Forms.Button();
            this.panelControlHint = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelControlHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(109, 30);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.LightGray;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(450, 450);
            this.panel.TabIndex = 7;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 460);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 51);
            this.progressBar.TabIndex = 9;
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClear.Location = new System.Drawing.Point(330, 0);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 25);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "Сбросить решение";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonHint
            // 
            this.buttonHint.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonHint.Location = new System.Drawing.Point(0, 0);
            this.buttonHint.Margin = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.buttonHint.Name = "buttonHint";
            this.buttonHint.Size = new System.Drawing.Size(120, 25);
            this.buttonHint.TabIndex = 0;
            this.buttonHint.Text = "Подсказать (0/3)";
            this.buttonHint.UseVisualStyleBackColor = true;
            this.buttonHint.Click += new System.EventHandler(this.buttonHint_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.progressBar);
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(315, 30);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(450, 550);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 450);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonHint);
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 25);
            this.panel1.TabIndex = 12;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(200, 2);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(65, 19);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "00:00:00";
            // 
            // blackBlockLabel
            // 
            this.blackBlockLabel.BackColor = System.Drawing.Color.Black;
            this.blackBlockLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blackBlockLabel.Location = new System.Drawing.Point(3, 115);
            this.blackBlockLabel.Name = "blackBlockLabel";
            this.blackBlockLabel.Size = new System.Drawing.Size(75, 75);
            this.blackBlockLabel.TabIndex = 6;
            // 
            // whiteBlockLabel
            // 
            this.whiteBlockLabel.BackColor = System.Drawing.Color.White;
            this.whiteBlockLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.whiteBlockLabel.Location = new System.Drawing.Point(3, 309);
            this.whiteBlockLabel.Name = "whiteBlockLabel";
            this.whiteBlockLabel.Size = new System.Drawing.Size(75, 75);
            this.whiteBlockLabel.TabIndex = 7;
            // 
            // crossBlockLabel
            // 
            this.crossBlockLabel.BackColor = System.Drawing.Color.White;
            this.crossBlockLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crossBlockLabel.Location = new System.Drawing.Point(3, 212);
            this.crossBlockLabel.Name = "crossBlockLabel";
            this.crossBlockLabel.Size = new System.Drawing.Size(75, 75);
            this.crossBlockLabel.TabIndex = 8;
            this.crossBlockLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.crossBlockLabel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Как играть?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "- ЛКМ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(107, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "- ПКМ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(92, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "- Повтор";
            // 
            // buttonHideControl
            // 
            this.buttonHideControl.Location = new System.Drawing.Point(23, 434);
            this.buttonHideControl.Name = "buttonHideControl";
            this.buttonHideControl.Size = new System.Drawing.Size(150, 23);
            this.buttonHideControl.TabIndex = 13;
            this.buttonHideControl.Text = "Спрятать подсказку";
            this.buttonHideControl.UseVisualStyleBackColor = true;
            this.buttonHideControl.Click += new System.EventHandler(this.buttonHideControl_Click);
            // 
            // panelControlHint
            // 
            this.panelControlHint.Controls.Add(this.label1);
            this.panelControlHint.Controls.Add(this.label2);
            this.panelControlHint.Controls.Add(this.label3);
            this.panelControlHint.Controls.Add(this.label4);
            this.panelControlHint.Controls.Add(this.buttonHideControl);
            this.panelControlHint.Controls.Add(this.blackBlockLabel);
            this.panelControlHint.Controls.Add(this.crossBlockLabel);
            this.panelControlHint.Controls.Add(this.whiteBlockLabel);
            this.panelControlHint.Location = new System.Drawing.Point(817, 30);
            this.panelControlHint.Name = "panelControlHint";
            this.panelControlHint.Size = new System.Drawing.Size(200, 460);
            this.panelControlHint.TabIndex = 14;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1064, 608);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelControlHint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение";
            this.Load += new System.EventHandler(this.GameForm_Load_1);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelControlHint.ResumeLayout(false);
            this.panelControlHint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonHint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label blackBlockLabel;
        private System.Windows.Forms.Label whiteBlockLabel;
        private System.Windows.Forms.Label crossBlockLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonHideControl;
        private System.Windows.Forms.Panel panelControlHint;
    }
}