using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private Dictionary<string, int> itemQuantities = new Dictionary<string, int>();
        private List<string> removedItems = new List<string>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;

        }





        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label56.Text = DateTime.Now.ToString("dddd");

            

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedIndex = comboBox1.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < tabControlSections.TabPages.Count)
            {
                tabControlSections.SelectedIndex = selectedIndex;
            }

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button80_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count == 0)
            { 
                MessageBox.Show("No items selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string itemName = row.Cells[0].Value.ToString();
                    int quantity = (int)row.Cells[1].Value;
                    itemQuantities[itemName] -= quantity;
                    if (itemQuantities[itemName] <= 0)
                    {
                       
                        itemQuantities.Remove(itemName);
                    }
                    
                    dataGridView1.Rows.Remove(row);

                    removedItems.Add(itemName);
                }

            }
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

       

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

       

        

        private void label57_Click(object sender, EventArgs e)
        {
           CustomMessageBox customMsgBox = new CustomMessageBox();
           // customMsgBox.MessageLabel.Text = "COMPUTER PROGRAMMING\n \nMEMBERS:\n \nADRIAN MORTE\nALFRED VALIENTE\nAHMIR ESPINO\nANDREI CARANTO \nJOSEPH VILLA";
           // customMsgBox.MessageLabel.Font = new Font("Tahoma", 12);
            customMsgBox.ShowDialog();
        }

        private void tabPageCoffee_Click(object sender, EventArgs e)
        {
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        


        private void button13_Click(object sender, EventArgs e)
        {
            Form3 receipt = new Form3(this);
           

            List<string> rowData = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Exclude the new row if exists
                {
                    string rowContent = string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString()));
                    rowData.Add(rowContent);
                }
            }

           
            receipt.SetData(rowData);


            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("No items selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               
                receipt.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label55.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string itemName = "Carbonara Pasta";
            double costOfItem = 179;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void tabPageDrinks_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPageSnacks_Click(object sender, EventArgs e)
        {
            
        }

       
        private void tabControlSections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string itemName = "Hazelnut Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            string itemName = "Affogato";
            double costOfItem = 79;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            string itemName = "Caffe Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            string itemName = "Mocha Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotalPrice();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotalPrice();
        }
        public static string totalPriceFormatted;
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Assuming the prices are in column index 2
                if (row.Cells.Count > 2 && row.Cells[2].Value != null)
                {
                    decimal price = 0;
                    if (Decimal.TryParse(row.Cells[2].Value.ToString(), out price))
                    {
                        totalPrice += price;
                    }
                }
            }

            // Format the total price with a peso sign (PHP)
           
            totalPriceFormatted = string.Format(new CultureInfo("en-PH"), "₱{0:N2}", totalPrice);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string itemName = "Iced Americano";
            double costOfItem = 129;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string itemName = "Pumpkin Spice Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string itemName = "Caramel Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string itemName = "Spanish Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                // Item already exists, increment the quantity
                itemQuantities[itemName]++;
                // Find the row and update its quantity and total cost
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; // Exit the loop once found
                    }
                }
            }
            else
            {
                // Item doesn't exist, add a new row
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }

            // Recalculate and update the total price
            UpdateTotalPrice();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string itemName = "Vanilla Latte";
            double costOfItem = 139;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;
            
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break; 
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string itemName = "Caramel Macchiato";
            double costOfItem = 129;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string itemName = "Cappuccino";
            double costOfItem = 129;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string itemName = "Espresso";
            double costOfItem = 29;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            string itemName = "Lychee Tea";
            double costOfItem = 99;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            string itemName = "Kiwi Tea";
            double costOfItem = 99;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string itemName = "Passion Fruit Tea";
            double costOfItem = 99;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string itemName = "Lemonade";
            double costOfItem = 99;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string itemName = "Strawberry Tea";
            double costOfItem = 99;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string itemName = "Chocolate Frappe";
            double costOfItem = 149;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            string itemName = "Vanilla Frappe";
            double costOfItem = 149;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string itemName = "Java Chip Frappe";
            double costOfItem = 149;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            string itemName = "Caramel Frappe";
            double costOfItem = 149;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string itemName = "Chicken Burger";
            double costOfItem = 129;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string itemName = "Clubhouse Sandwich";
            double costOfItem = 119;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string itemName = "Nachos Overload";
            double costOfItem = 149;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string itemName = "Burger Supreme";
            double costOfItem = 189;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string itemName = "Pesto Pasta";
            double costOfItem = 179;

            if (itemQuantities.ContainsKey(itemName))
            {
                itemQuantities[itemName]++;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemName)
                    {
                        row.Cells[1].Value = itemQuantities[itemName];
                        row.Cells[2].Value = itemQuantities[itemName] * costOfItem;
                        break;
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Add(itemName, 1, costOfItem);
                itemQuantities.Add(itemName, 1);
            }
            UpdateTotalPrice();
        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearDataGridViewAndLists()
        {
            dataGridView1.Rows.Clear();
            removedItems.AddRange(itemQuantities.Keys); // Assuming removedItems is a List<string> to store removed item names
            itemQuantities.Clear();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ClearDataGridViewAndLists();
        
        }
    }
}


