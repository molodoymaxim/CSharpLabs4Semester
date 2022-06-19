using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListObjects;
using MeansTranporation;
using HelpWindowInput;

namespace MainForm
{
    public partial class MainForm : Form
    {
        IObject object_;
        public MainForm()
        {
            InitializeComponent();
            object_=new ListObject();
        }

        void ShowObj()
        {
            IEnumerable<TransportVehicle> allTransport = object_.GetAll();

            dataGridView1.Rows.Clear();

            foreach(var item in allTransport)
            {
                int rowIndx = dataGridView1.Rows.Add();
                DataGridViewRow curRow = dataGridView1.Rows[rowIndx];

                curRow.Cells[0].Value = item.Id;
                curRow.Cells[1].Value=item.Price;

                if (item is TramCar)
                {
                    var itemtramCar = item as TramCar;
                    curRow.Cells[2].Value=itemtramCar.PriceTicket;
                    curRow.Cells[3].Value=itemtramCar.Income;
                    curRow.Cells[4].Value=itemtramCar.Consumption;
                    curRow.Cells[5].Value=itemtramCar.GrandTotal();
                    curRow.Cells[6].Value=itemtramCar.HasCardPayment ? "Yep" : "Nope";
                    curRow.Cells[7].Value=itemtramCar.NumberPlaces;
                    curRow.Cells[8].Value=itemtramCar.SitPlace();
                    curRow.Cells[9].Value=itemtramCar.StandingPlace();
                    curRow.Cells[10].Value=itemtramCar.Tax();
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 addTramCar = new Form2(new TramCar());
            if (addTramCar.ShowDialog() == DialogResult.OK)
            {
                object_.Add(addTramCar.Value);
                ShowObj();
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputStringDialog inputId = new InputStringDialog(new NotNegativeIntValidator(), "Enter Id of Tram car");

            if (inputId.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TransportVehicle editItem = object_.Get(Int32.Parse(inputId.Value));
                    Form2 editTramCar = new Form2(editItem as TramCar);
                    if (editTramCar.ShowDialog() == DialogResult.OK)
                    {
                        object_.Update(editTramCar.Value);
                    }
                    ShowObj();
                }
                catch (ArgumentException excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputStringDialog inputId = new InputStringDialog(new NotNegativeIntValidator(), "Enter Id of Tram car");

            if (inputId.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    object_.Delete(Int32.Parse(inputId.Value));
                    ShowObj();
                }
                catch(ArgumentException excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }
    }
}
