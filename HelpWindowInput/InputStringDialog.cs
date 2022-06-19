using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpWindowInput
{
    public partial class InputStringDialog : Form
    {
        IStringValidator validator;
        string value = null;

        public string Value
        {
            get => value;
        }
        public InputStringDialog(IStringValidator validator, string message = "Введите строку")
        {
            InitializeComponent();

            this.validator = validator;

            Text = message;
            messageLabel.Text = message;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!validator.IsValid(inputStringTextBox.Text))
            {
                MessageBox.Show("Неправильный ввод\n" + validator.ErrorMessage);
            }
            else
            {
                value = inputStringTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
