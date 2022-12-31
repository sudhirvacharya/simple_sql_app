using simple_sql_app.eContactClasses;
using System.Data;
using System.Drawing.Text;

namespace simple_sql_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ContactClass c = new contactClass();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getthe value from the input field
            c.FirstName = txtboxLasteName.Text;
            c.LastName = txtboxLasteName.Text;
            c.ContactNo = txtboxcontactNumber.text;
            c.address=txtboxAdress.Text;
            c.Gendder= xtboxGender.Text;

            bool success = c.Insert(c);
            if (success) 
            {
                MessageBox.Show("New contact succesfully inserted");
            }
            else
            {
                MessageBox.Show("Failed to add new contactd");
            }
            DataTable dt = c.Select();
            dgvcontactlist.datasource = dt;

            Private void Econtact_load(object sender, EventArgs e) 
            {
                DataTable dt = c.Select();
                dgvContactList.datasource = dt;
            }
        }
    }
}