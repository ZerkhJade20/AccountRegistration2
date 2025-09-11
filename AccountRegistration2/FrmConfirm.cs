using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AccountRegistration2
{
    public partial class FrmConfirm : Form
    {
        private StudentInfoClass.DelegateText delProgram, delLastName, delFirstName, delMiddleName, delAddress, delGender;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private StudentInfoClass.DelegateNumber delStudentNo, delContactNo, delAge;

        public FrmConfirm()
        {
            InitializeComponent();
            InitializeComponent();
            // Initialize delegates
            delProgram = new StudentInfoClass.DelegateText(StudentInfoClass.GetProgram);
            delLastName = new StudentInfoClass.DelegateText(StudentInfoClass.GetLastName);
            delFirstName = new StudentInfoClass.DelegateText(StudentInfoClass.GetFirstName);
            delMiddleName = new StudentInfoClass.DelegateText(StudentInfoClass.GetMiddleName);
            delAddress = new StudentInfoClass.DelegateText(StudentInfoClass.GetBirthday);
            delStudentNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetStudentNo);
            delContactNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetContactNo);
            delAge = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetAge);
            delGender = new StudentInfoClass.DelegateText(StudentInfoClass.GetGender);

            // Display data
            lblStudentNo.Text = delStudentNo(StudentInfoClass.StudentNo).ToString();
            lblProgram.Text = delProgram(StudentInfoClass.Program);
            lblLastName.Text = delLastName(StudentInfoClass.LastName);
            lblFirstName.Text = delFirstName(StudentInfoClass.FirstName);
            lblMiddleName.Text = delMiddleName(StudentInfoClass.MiddleName);
            lblAge.Text = delAge(StudentInfoClass.Age).ToString();
            cbGender.Text = delGender(StudentInfoClass.Gender);
            lblAddress.Text = delAddress(StudentInfoClass.Birthday);
            lblContactNo.Text = delContactNo(StudentInfoClass.ContactNo).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True;Trust Server Certificate=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Registration]\r\n           
            ([StudentNo]\r\n           
            ,[LastName]\r\n           
            ,[FirstName]\r\n           
            ,[MiddleName]\r\n           
            ,[Age]\r\n           
            ,[Birthday]\r\n           
            ,[ContactNo]\r\n          
            ,[Program]\r\n           
            ,[Gender])\r\n     
            VALUES\r\n          
                ('" + lblStudentNo.Text + "', '" + lblLastName.Text + "', '" + lblMiddleName.Text + "', '" + lblFirstName.Text + "', '" + lblAge.Text + "', '" + lblContactNo.Text + "', '" + cbGender.ToString() + "', '" + lblProgram.ToString() + "', '" + lblAddress.ToString() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Register Successfully");
            }
            catch (Exception ex) 
            {
            }

        }



        private void FrmConfirm_Load(object sender, EventArgs e)
        {

        }
    }
}
