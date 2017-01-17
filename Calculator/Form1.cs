using Calcspace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Calcspace.Calc Calc { get; set; }

        private IEnumerable<string> OperationNames { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();

            #region Получение
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
               .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file); 
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();

                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        var oper = Activator.CreateInstance(type) as IOperation;

                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }
            #endregion

            Calc = new Calcspace.Calc(operations);

            OperationNames = Calc.GetOperationNames();

            // заполнить комбобокс
            FillCombobox();

        }

        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();

            #region Получение
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
               .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file); 
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();

                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        var oper = Activator.CreateInstance(type) as IOperation;

                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }
            #endregion

            var Calc = new Calcspace.Calc(operations);

            OperationNames = Calc.GetOperationNames();

            var activeoper = OperationNames;
           
            var result = Calc.Execute(comboBox1.Text, new object[] { Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text) });
            label2.Text = Convert.ToString(result);
            

        }
    }
}
