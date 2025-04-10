namespace Nonograms_1._1.Forms
{
    partial class CreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxDifficult = new System.Windows.Forms.ComboBox();
            this.labelDifficult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Location = new System.Drawing.Point(302, 33);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(480, 480);
            this.panel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(812, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 201);
            this.label1.TabIndex = 11;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(109, 30);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(80, 80);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLength.TabIndex = 12;
            this.numericUpDownLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLength.ValueChanged += new System.EventHandler(this.numericUpDownLength_ValueChanged);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(80, 115);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHeight.TabIndex = 13;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(509, 542);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 14;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(148, 186);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 15;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(47, 189);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(95, 13);
            this.labelName.TabIndex = 16;
            this.labelName.Text = "Имя кроссворда:";
            // 
            // comboBoxDifficult
            // 
            this.comboBoxDifficult.FormattingEnabled = true;
            this.comboBoxDifficult.Items.AddRange(new object[] {
            "Легкий",
            "Средний",
            "Сложный"});
            this.comboBoxDifficult.Location = new System.Drawing.Point(148, 220);
            this.comboBoxDifficult.Name = "comboBoxDifficult";
            this.comboBoxDifficult.Size = new System.Drawing.Size(100, 21);
            this.comboBoxDifficult.TabIndex = 17;
            this.comboBoxDifficult.SelectedIndexChanged += new System.EventHandler(this.comboBoxDifficult_SelectedIndexChanged);
            // 
            // labelDifficult
            // 
            this.labelDifficult.AutoSize = true;
            this.labelDifficult.Location = new System.Drawing.Point(24, 223);
            this.labelDifficult.Name = "labelDifficult";
            this.labelDifficult.Size = new System.Drawing.Size(118, 13);
            this.labelDifficult.TabIndex = 18;
            this.labelDifficult.Text = "Выберите сложность:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 583);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 19;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1064, 608);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDifficult);
            this.Controls.Add(this.comboBoxDifficult);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateForm";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxDifficult;
        private System.Windows.Forms.Label labelDifficult;
        private System.Windows.Forms.Label label2;
    }
}