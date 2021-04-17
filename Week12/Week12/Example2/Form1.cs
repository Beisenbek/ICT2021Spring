using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();

            LoadContacts();
        }

        BLL bll = default(BLL);

        private void LoadContacts()
        {

            ContactDBMock contacts = new ContactDBMock();
            ContactDB contacts2 = new ContactDB();

            bll = new BLL(contacts2);

            bindingSource1.DataSource = bll.GetContacts();


            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = bll.GetContacts().Count.ToString();
            bindingSource1.DataSource = bll.GetContacts();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //MessageBox.Show("ok");
           
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // MessageBox.Show("dataGridView1_RowsAdded");
           
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        CreateContactForm createContactForm = new CreateContactForm();

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (createContactForm.ShowDialog() == DialogResult.OK)
            {
                CreateContactCommand command = new CreateContactCommand();
                command.Name = createContactForm.nameTxtBx.Text;
                command.Phone = createContactForm.phoneTxtBx.Text;
                command.Addr = createContactForm.addressTxtBx.Text;
                bll.CreateContact(command);
                bindingSource1.DataSource = bll.GetContacts();
            }
        }
    }
}
