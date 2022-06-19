using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputString;
using Home;
 

namespace Lab1Main
{
    public class FormInputNumDoor
    {
        public DoorHome InputNumDoors()
        {
            InputStringDialog input = new InputStringDialog(new NotNegativeIntValidator(), "Input number of ddors in home");
            if (input.ShowDialog() == DialogResult.OK)
                return new DoorHome(Int32.Parse(input.Value));

            return 0;
        }
    }

    public 

}
