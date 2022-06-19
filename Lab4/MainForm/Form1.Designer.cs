namespace MainForm
{
    partial class Form1
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
            this.selectTypecomboBox = new System.Windows.Forms.ComboBox();
            this.propertiesListBox = new System.Windows.Forms.ListBox();
            this.parametersLlistBox = new System.Windows.Forms.ListBox();
            this.selectMethodComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.createObjectButton = new System.Windows.Forms.Button();
            this.inputParametersButton = new System.Windows.Forms.Button();
            this.executeMethodButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectTypecomboBox
            // 
            this.selectTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTypecomboBox.FormattingEnabled = true;
            this.selectTypecomboBox.Location = new System.Drawing.Point(467, 34);
            this.selectTypecomboBox.Name = "selectTypecomboBox";
            this.selectTypecomboBox.Size = new System.Drawing.Size(209, 24);
            this.selectTypecomboBox.TabIndex = 0;
            this.selectTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.selectTypecomboBox_SelectedIndexChanged);
            // 
            // propertiesListBox
            // 
            this.propertiesListBox.FormattingEnabled = true;
            this.propertiesListBox.ItemHeight = 16;
            this.propertiesListBox.Location = new System.Drawing.Point(13, 34);
            this.propertiesListBox.Name = "propertiesListBox";
            this.propertiesListBox.Size = new System.Drawing.Size(429, 212);
            this.propertiesListBox.TabIndex = 1;
            // 
            // parametersLlistBox
            // 
            this.parametersLlistBox.FormattingEnabled = true;
            this.parametersLlistBox.ItemHeight = 16;
            this.parametersLlistBox.Location = new System.Drawing.Point(13, 292);
            this.parametersLlistBox.Name = "parametersLlistBox";
            this.parametersLlistBox.Size = new System.Drawing.Size(429, 100);
            this.parametersLlistBox.TabIndex = 3;
            // 
            // selectMethodComboBox
            // 
            this.selectMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectMethodComboBox.Enabled = false;
            this.selectMethodComboBox.FormattingEnabled = true;
            this.selectMethodComboBox.Location = new System.Drawing.Point(467, 89);
            this.selectMethodComboBox.Name = "selectMethodComboBox";
            this.selectMethodComboBox.Size = new System.Drawing.Size(209, 24);
            this.selectMethodComboBox.TabIndex = 2;
            this.selectMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.selectMethodComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Class:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Method:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Object properties:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Method parameters";
            // 
            // createObjectButton
            // 
            this.createObjectButton.Enabled = false;
            this.createObjectButton.Location = new System.Drawing.Point(467, 161);
            this.createObjectButton.Name = "createObjectButton";
            this.createObjectButton.Size = new System.Drawing.Size(209, 49);
            this.createObjectButton.TabIndex = 8;
            this.createObjectButton.Text = "Create object of class";
            this.createObjectButton.UseVisualStyleBackColor = true;
            this.createObjectButton.Click += new System.EventHandler(this.createObjectButton_Click);
            // 
            // inputParametersButton
            // 
            this.inputParametersButton.Enabled = false;
            this.inputParametersButton.Location = new System.Drawing.Point(467, 225);
            this.inputParametersButton.Name = "inputParametersButton";
            this.inputParametersButton.Size = new System.Drawing.Size(209, 49);
            this.inputParametersButton.TabIndex = 9;
            this.inputParametersButton.Text = "Input parameters";
            this.inputParametersButton.UseVisualStyleBackColor = true;
            this.inputParametersButton.Click += new System.EventHandler(this.inputParametersButton_Click);
            // 
            // executeMethodButton
            // 
            this.executeMethodButton.Enabled = false;
            this.executeMethodButton.Location = new System.Drawing.Point(467, 285);
            this.executeMethodButton.Name = "executeMethodButton";
            this.executeMethodButton.Size = new System.Drawing.Size(209, 48);
            this.executeMethodButton.TabIndex = 10;
            this.executeMethodButton.Text = "Execute method";
            this.executeMethodButton.UseVisualStyleBackColor = true;
            this.executeMethodButton.Click += new System.EventHandler(this.executeMethodButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 412);
            this.Controls.Add(this.executeMethodButton);
            this.Controls.Add(this.inputParametersButton);
            this.Controls.Add(this.createObjectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parametersLlistBox);
            this.Controls.Add(this.selectMethodComboBox);
            this.Controls.Add(this.propertiesListBox);
            this.Controls.Add(this.selectTypecomboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectTypecomboBox;
        private System.Windows.Forms.ListBox propertiesListBox;
        private System.Windows.Forms.ListBox parametersLlistBox;
        private System.Windows.Forms.ComboBox selectMethodComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createObjectButton;
        private System.Windows.Forms.Button inputParametersButton;
        private System.Windows.Forms.Button executeMethodButton;
    }
}

