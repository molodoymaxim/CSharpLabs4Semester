using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeansTranporation;

namespace MainForm
{
    public partial class Form2 : Form
    {
        public TramCar Value { get; private set; }

        public Form2(TramCar tramCar)
        {
            InitializeComponent();

            Value = tramCar;

            priceBox.Text = tramCar.Price.ToString();
            priceTicketBox.Text = tramCar.PriceTicket.ToString();
            incomeBox.Text = tramCar.Income.ToString();
            consumpBox.Text=tramCar.Consumption.ToString();
            numberPlacesBox.Text=tramCar.NumberPlaces.ToString();
            hasCardCheckBox.Checked=tramCar.HasCardPayment;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                Value.Price=Double.Parse(priceBox.Text);
                Value.PriceTicket=Double.Parse(priceTicketBox.Text);
                Value.Income=Double.Parse(incomeBox.Text);
                Value.Consumption=Double.Parse(consumpBox.Text);
                Value.NumberPlaces=Int32.Parse(numberPlacesBox.Text);
                Value.HasCardPayment=hasCardCheckBox.Checked;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch(ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Was input no digit and check all string!");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
