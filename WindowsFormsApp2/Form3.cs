using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {

        private Form1 form1Instance;
        public Form3(Form1 form1)
        {
            InitializeComponent();
           
            form1Instance = form1;


        }



        private void Form3_Load(object sender, EventArgs e)
        {

            label3.Text = Form1.totalPriceFormatted;
            

        }

        public void SetData(List<string> rowData)
        {
            foreach (string rowContent in rowData)
            {
                string[] cellData = rowContent.Split(',');

                int rowIndex = dataGridView1.Rows.Add(cellData);

                // You might need to handle additional logic for formatting or validation here
            }
        }





        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Thank you for purchasing!", " ", MessageBoxButtons.OK);

            this.Close();
            if (dr == DialogResult.OK)
            {

                form1Instance.ClearDataGridViewAndLists(); // Call the method in Form1


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
