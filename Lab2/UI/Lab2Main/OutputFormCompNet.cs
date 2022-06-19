using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerNetworks;
using HelpWindowInput;

namespace Lab2Main
{
    class OutputFormCompNet: ICompNetPrint
    {
        TextBox nameCorpTextBox, numEmployeeTextBox,distanceTextBox,qualityTextBox, transferRateTextBox;

        public OutputFormCompNet(TextBox nameCorpTextBox, TextBox numEmployeeTextBox, TextBox distanceTextBox, TextBox qualityTextBox)
        {
            this.nameCorpTextBox= nameCorpTextBox;
            this.numEmployeeTextBox= numEmployeeTextBox;    
            this.distanceTextBox= distanceTextBox;  
            this.qualityTextBox= qualityTextBox;    
        }

        public OutputFormCompNet(TextBox nameCorpTextBox, TextBox numEmployeeTextBox, TextBox distanceTextBox, TextBox qualityTextBox, TextBox transferRateTextBox)
        {
            this.nameCorpTextBox= nameCorpTextBox;
            this.numEmployeeTextBox= numEmployeeTextBox;
            this.distanceTextBox= distanceTextBox;
            this.qualityTextBox= qualityTextBox;
            this.transferRateTextBox= transferRateTextBox;
        }

        public void PrintNameCorp(string nameCorp_)
        {
            nameCorpTextBox.Text=nameCorp_;
        }

        public void PrintNumEmployee(int numEmployee_)
        {
            numEmployeeTextBox.Text=numEmployee_.ToString();
        }

        public void PrintDistance(double distance_)
        {
            distanceTextBox.Text=distance_.ToString(); 
        }

        public void PrintQuality(double quality_)
        {
            qualityTextBox.Text=quality_.ToString();    
        }

        public void PrintTransferRate(double transferRate_)
        {
            transferRateTextBox.Text=transferRate_.ToString();
        }
    }
}
