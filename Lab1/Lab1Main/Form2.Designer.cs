namespace Lab1Main
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.InTxtBoxWin = new System.Windows.Forms.TextBox();
            this.InTxtBoxDoor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InpButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenButton = new System.Windows.Forms.RadioButton();
            this.CloseButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Door status:";
            // 
            // InTxtBoxWin
            // 
            this.InTxtBoxWin.Enabled = false;
            this.InTxtBoxWin.Location = new System.Drawing.Point(150, 62);
            this.InTxtBoxWin.Name = "InTxtBoxWin";
            this.InTxtBoxWin.Size = new System.Drawing.Size(100, 22);
            this.InTxtBoxWin.TabIndex = 10;
            // 
            // InTxtBoxDoor
            // 
            this.InTxtBoxDoor.Enabled = false;
            this.InTxtBoxDoor.Location = new System.Drawing.Point(150, 108);
            this.InTxtBoxDoor.Name = "InTxtBoxDoor";
            this.InTxtBoxDoor.Size = new System.Drawing.Size(100, 22);
            this.InTxtBoxDoor.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Number windows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Number doors";
            // 
            // InpButton
            // 
            this.InpButton.Location = new System.Drawing.Point(67, 156);
            this.InpButton.Name = "InpButton";
            this.InpButton.Size = new System.Drawing.Size(119, 23);
            this.InpButton.TabIndex = 14;
            this.InpButton.Text = "Ok";
            this.InpButton.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // OpenButton
            // 
            this.OpenButton.AutoSize = true;
            this.OpenButton.Location = new System.Drawing.Point(150, 7);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(61, 20);
            this.OpenButton.TabIndex = 15;
            this.OpenButton.TabStop = true;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.Location = new System.Drawing.Point(150, 31);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(63, 20);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.TabStop = true;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 195);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InpButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InTxtBoxDoor);
            this.Controls.Add(this.InTxtBoxWin);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InTxtBoxWin;
        private System.Windows.Forms.TextBox InTxtBoxDoor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button InpButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton OpenButton;
        private System.Windows.Forms.RadioButton CloseButton;
    }
}