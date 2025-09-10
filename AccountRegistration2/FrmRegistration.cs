using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountRegistration2
{
    public partial class FrmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public FrmRegistration()
        {
            InitializeComponent();
            // Fill combobox with sample college courses
            cboProgram.Items.AddRange(new string[]
            {
                "BS Computer Science",
                "BS Information Technology",
                "BS Information Systems",
                "BS Software Engineering",
                "BS Data Science",
                "BS Civil Engineering",
                "BS Electrical Engineering",
                "BS Mechanical Engineering",
                "BS Architecture",
                "BS Accountancy",
                "BS Business Administration",
                "BS Marketing Management",
                "BS Psychology",
                "BS Nursing",
                "BS Medical Technology",
                "BS Pharmacy",
                "BS Biology",
                "BS Mathematics",
                "BA Communication",
                "BA Political Science",
                "BA Economics",
                "BA English Language Studies",
                "Bachelor of Elementary Education",
                "Bachelor of Secondary Education"
            });

            // Optional: Select first item by default
            if (cboProgram.Items.Count > 0)
                cboProgram.SelectedIndex = 0;

            cbGender.Items.AddRange(new string[]
            {
                "Male",
                "Female",

            });
            if (cbGender.Items.Count > 0)
                cbGender.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Assign textbox/combobox values to static variables
            try
            {
                StudentInfoClass.Program = cboProgram.Text;
                StudentInfoClass.FirstName = txtFirstName.Text;
                StudentInfoClass.LastName = txtLastName.Text;
                StudentInfoClass.MiddleName = txtMiddleName.Text;
                StudentInfoClass.Birthday = datePickerBirtday.Text;
                StudentInfoClass.Gender = cbGender.Text;

                StudentInfoClass.Age = long.TryParse(txtAge.Text, out long age) ? age : 0;
                StudentInfoClass.ContactNo = long.TryParse(txtContactNo.Text, out long contact) ? contact : 0;
                StudentInfoClass.StudentNo = long.TryParse(txtStudentNo.Text, out long studNo) ? studNo : 0;
            }

            catch (FormatException)
            {
                MessageBox.Show("Please input numbers only for Student Number, Age, and Contact Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please input numbers only for Student Number, Age, and Contact Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Please input numbers only for Student Number, Age, and Contact Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please input numbers only for Student Number, Age, and Contact Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please input numbers only for Student Number, Age, and Contact Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally {
                MessageBox.Show("Please input numbers only for Student Number, Age, and Contact Number. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            // Open FrmConfirm as dialog
            FrmConfirm frm = new FrmConfirm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Enrolled kana! SOlID!", "Success");
            }
        }

        private void datePickerBirtday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }
        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }
    }
}

