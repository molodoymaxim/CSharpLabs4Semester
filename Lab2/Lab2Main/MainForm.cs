using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerNetworks;

namespace Lab2Main
{
    public partial class MainForm : Form
    {
        FirstLevel firstLevel = new FirstLevel();
        SecondLevel secondLevel = new SecondLevel(); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void InpFirstClassCompNet_Click(object sender, EventArgs e)
        {
            firstLevel.Input(new InputFormCompNet());
        }

        private void OutFirstClassCompNet_Click(object sender, EventArgs e)
        {
            try
            {
                firstLevel.Print(new OutputFormCompNet(firstLevelClassNameCorp, firstLevelClassNumEmpl, firstLevelClassAverDist,
                    firstLevelClassQual));
            }
            catch(InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void InpSecondClassCompNet_Click(object sender, EventArgs e)
        {
            secondLevel.Input(new InputFormCompNet());
        }

        private void OutSecondClassCompNet_Click(object sender, EventArgs e)
        {
            try
            {
                secondLevel.Print(new OutputFormCompNet(SecondLevelClassNameCorp, SecondLevelClassNumEmpl, secondLevelClassAverDist,secnodLevelClassQual, secondLevelClassAverSpeedNet));
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
