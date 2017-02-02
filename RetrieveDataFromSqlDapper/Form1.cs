using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetrieveDataFromSqlDapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = DataService.GetAllCategory();
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "CategoryID";
            Category obj = categoryComboBox.SelectedItem as Category;

            if(obj != null)
            {
                dataGridView1.DataSource = DataService.GetProductByCategoryID(obj.CategoryID);
            }
        }

        private void categoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Category obj = categoryComboBox.SelectedItem as Category;

            if (obj != null)
            {
                dataGridView1.DataSource = DataService.GetProductByCategoryID(obj.CategoryID);
            }
        }
    }
}
