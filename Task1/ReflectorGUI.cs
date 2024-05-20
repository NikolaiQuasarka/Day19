using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class ReflectorGUI : Form
    {
        public ReflectorGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string className = textBox1.Text;
            if (Reflector.WriteTextFIle("classInfo.txt", className))
            {
                using (StreamReader fs = new StreamReader("classInfo.txt"))
                {
                    textBox2.Text = fs.ReadToEnd();
                }
            }
            else MessageBox.Show("Имя класса введено неверно");
            
        }
    }
}
