using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using HelpWindowInput;

namespace MainForm
{
    public partial class Form1 : Form
    {
        Assembly Transport;
        IEnumerable<Type> types;

        Type curType;
        object curObj;

        MethodInfo curMethod;
        object[] methodParameters;

        public Form1()
        {
            InitializeComponent();
        }

        void FillComboBox()
        {
            selectMethodComboBox.Items.Clear();
            IEnumerable<string> objectMethods = (new object()).GetType().GetMethods().Select(method => method.Name);

            selectMethodComboBox.Items.AddRange(curType.GetMethods().Where(method => !objectMethods.Contains(method.Name) &&
                method.Name.Substring(0, 3) != "get" &&
                method.Name.Substring(0, 3) != "set").Select(method => method.Name).ToArray());
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            curObj = InputObject(curType);

            if (curMethod?.GetParameters().Length == 0)
                executeMethodButton.Enabled = true;

            ShowObjectProperties();
        }

        private void selectTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curType = types.First(type => type.Name == selectTypecomboBox.SelectedItem.ToString());
            curObj = null;

            FillComboBox();

            createObjectButton.Enabled = true;
            selectMethodComboBox.Enabled = true;

            inputParametersButton.Enabled = false;
            executeMethodButton.Enabled = false;

            propertiesListBox.Items.Clear();
        }

        private void selectMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curMethod = curType.GetMethods()
                .First(method => method.Name == selectMethodComboBox.SelectedItem.ToString());

            executeMethodButton.Enabled = false;

            if (curMethod.GetParameters().Length == 0)
            {
                inputParametersButton.Enabled = false;
                executeMethodButton.Enabled = curObj != null;
            }
            else
                inputParametersButton.Enabled = true;

            methodParameters = null;

            parametersLlistBox.Items.Clear();

            foreach (var item in curMethod.GetParameters())
            {
                parametersLlistBox.Items.Add(item.Name);
            }
        }

        bool InputBool(string message)
        {
            return MessageBox.Show(message, "input answer", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        object InputNumber(string message, string numberType)
        {
            IStringValidator validator;

            if (numberType == typeof(double).Name)
                validator = new NotNegativeDoubleValidator();
            else
                validator = new NotNegativeIntValidator();

            InputStringDialog inputNumber = new InputStringDialog(validator, message);

            if (inputNumber.ShowDialog() == DialogResult.OK)
            {
                if (numberType == typeof(double).Name)
                    return Double.Parse(inputNumber.Value);
                else
                    return Int32.Parse(inputNumber.Value);
            }

            return 0;
        }

        object InputObject(Type type)
        {
            MessageBox.Show($"input {type.Name} object");

            object newObject = Activator.CreateInstance(type);

            foreach (var item in type.GetProperties())
            {
                if (item.PropertyType == typeof(bool))
                    item.SetValue(newObject, InputBool(item.Name + "?"));
                else
                    item.SetValue(newObject, InputNumber("input " + item.Name, item.PropertyType.Name));
            }

            return newObject;
        }

        void ShowObjectProperties()
        {
            propertiesListBox.Items.Clear();

            foreach (var item in curType.GetProperties())
            {
                propertiesListBox.Items.Add(item.Name + ": " + item.GetValue(curObj));
            }
        }

        private void inputParametersButton_Click(object sender, EventArgs e)
        {
            if (curMethod.GetParameters()[0].ParameterType.Name == "TransportVehicle")
                methodParameters = new object[1] { InputObject(curType) };
            else if (curMethod.GetParameters().Length != 0)
                methodParameters = curMethod.GetParameters()
                    .Select(param => (param.ParameterType == typeof(bool)
                    ? InputBool(param.Name + "?")
                    : InputNumber("input" + param.Name, param.ParameterType.Name)))
                    .ToArray();

            if (curObj != null)
                executeMethodButton.Enabled = true;
        }

        private void executeMethodButton_Click(object sender, EventArgs e)
        {
            if (curMethod.ReturnType == typeof(void))
            {
                curMethod.Invoke(curObj, methodParameters);
                MessageBox.Show("Method research complete");
            }
            else
                MessageBox.Show(curMethod.Invoke(curObj, methodParameters).ToString());

            ShowObjectProperties();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Transport=Assembly.Load("MeansTranporationNew");
            types=Transport.GetTypes().Where(type => type.GetInterface("TransportVehicle") != null && !type.IsAbstract);
            selectTypecomboBox.Items.AddRange(types.Select(t => t.Name).ToArray());
        }
    }
}
