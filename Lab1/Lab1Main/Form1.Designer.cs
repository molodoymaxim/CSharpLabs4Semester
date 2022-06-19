namespace Lab1Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.OutTxtBoxStatus = new System.Windows.Forms.TextBox();
            this.OutTxtBoxWin = new System.Windows.Forms.TextBox();
            this.OutTxtBoxDoor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InpDataButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Door status:";
            // 
            // OutTxtBoxStatus
            // 
            this.OutTxtBoxStatus.Enabled = false;
            this.OutTxtBoxStatus.Location = new System.Drawing.Point(150, 7);
            this.OutTxtBoxStatus.Name = "OutTxtBoxStatus";
            this.OutTxtBoxStatus.Size = new System.Drawing.Size(100, 22);
            this.OutTxtBoxStatus.TabIndex = 2;
            // 
            // OutTxtBoxWin
            // 
            this.OutTxtBoxWin.Enabled = false;
            this.OutTxtBoxWin.Location = new System.Drawing.Point(150, 51);
            this.OutTxtBoxWin.Name = "OutTxtBoxWin";
            this.OutTxtBoxWin.Size = new System.Drawing.Size(100, 22);
            this.OutTxtBoxWin.TabIndex = 3;
            // 
            // OutTxtBoxDoor
            // 
            this.OutTxtBoxDoor.Enabled = false;
            this.OutTxtBoxDoor.Location = new System.Drawing.Point(150, 97);
            this.OutTxtBoxDoor.Name = "OutTxtBoxDoor";
            this.OutTxtBoxDoor.Size = new System.Drawing.Size(100, 22);
            this.OutTxtBoxDoor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number windows";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number doors";
            // 
            // InpDataButton
            // 
            this.InpDataButton.Location = new System.Drawing.Point(15, 143);
            this.InpDataButton.Name = "InpDataButton";
            this.InpDataButton.Size = new System.Drawing.Size(119, 23);
            this.InpDataButton.TabIndex = 7;
            this.InpDataButton.Text = "Enter";
            this.InpDataButton.UseVisualStyleBackColor = true;
            this.InpDataButton.Click += new System.EventHandler(this.InpDataButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Change Window";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Change Door";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(269, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "Change door status";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 175);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InpDataButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutTxtBoxDoor);
            this.Controls.Add(this.OutTxtBoxWin);
            this.Controls.Add(this.OutTxtBoxStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutTxtBoxStatus;
        private System.Windows.Forms.TextBox OutTxtBoxWin;
        private System.Windows.Forms.TextBox OutTxtBoxDoor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button InpDataButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

