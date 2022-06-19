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
    class InputFormCompNet : ICompNetInp
    {
        public string InputNameCorp()
        {
            InputStringDialog input = new InputStringDialog(new WordValidator(), "Input name corporation");
            if (input.ShowDialog() == DialogResult.OK)
                return input.Value;

            return "";
        }

        public int InputNumEmployee()
        {
            InputStringDialog input = new InputStringDialog(new NotNegativeIntValidator(), "Input number of employees");
            if (input.ShowDialog() == DialogResult.OK)
                return Int32.Parse(input.Value);

            return 0;
        }

        public double InputDistance()
        {
            InputStringDialog input = new InputStringDialog(new NotNegativeDoubleValidator(), "Input average distance");
            if (input.ShowDialog() == DialogResult.OK)
                return UInt32.Parse(input.Value);

            return 0.0;
        }

        public double InputTransferRate()
        {
            InputStringDialog input = new InputStringDialog(new NotNegativeDoubleValidator(), "Input average speed of network");
            if (input.ShowDialog() == DialogResult.OK)
                return UInt32.Parse(input.Value);

            return 0.0;
        }
    }
}
