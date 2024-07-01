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

namespace medical_center_managment
{
    public partial class DoctarDetails : Form
    {
        string connectionString = @"Data Source=LAPTOP-4VMD8P7I;Initial Catalog=medical_center;Integrated Security=True;";
        public DoctarDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("insertDoctarData", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@doctorid", doctorTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@firstname", firstTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@secondname", secondTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@hospital", hospitalTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@email", emailTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@specialization", specialTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@dotortype", typeTB.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    display_data();
                    doctorTB.Text = "";
                    firstTB.Text = "";
                    MessageBox.Show("Register is successfull !");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        void Clear()
        {
            doctorTB.Text = firstTB.Text = secondTB.Text = hospitalTB.Text = emailTB.Text = specialTB.Text = typeTB.Text = "";
        }

        public void display_data()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Doctar";
                    cmd.ExecuteNonQuery();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void DoctarDetails_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Doctar WHERE DoctarID = '" + doctorTB.Text + "'";

                    cmd.ExecuteNonQuery();
                    connectionString.Clone();
                    display_data();
                    MessageBox.Show("Delect is succesfull !");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Doctar WHERE DoctarID = @doctorid OR FirstName = @firstname";
                    cmd.Parameters.AddWithValue("@doctorid", doctorTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@firstname", firstTB.Text.Trim());
                    cmd.ExecuteNonQuery();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doctorTB.Text = reader["DoctarID"].ToString();
                        firstTB.Text = reader["FirstName"].ToString();
                        secondTB.Text = reader["SecondName"].ToString();
                        hospitalTB.Text = reader["HospitalName"].ToString();
                        emailTB.Text = reader["Email"].ToString();
                        specialTB.Text = reader["Specialization"].ToString();
                        typeTB.Text = reader["DoctarType"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No matching records found.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Doctar SET FirstName = @firstname, SecondName = @secondname, HospitalName = @hospital, Email = @email, Specialization = @specialization, DoctarType = @dotortype  WHERE DoctarID = @doctorid";
                    cmd.Parameters.AddWithValue("@doctorid", doctorTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@firstname", firstTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@secondname", secondTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@hospital", hospitalTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", emailTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@specialization", specialTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@dotortype", typeTB.Text.Trim());
                    cmd.ExecuteNonQuery();
                    display_data();
                    MessageBox.Show("Update is successful!");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // Create an instance of the target form
            ParentDetails ParentDetails = new ParentDetails();

            // Display the target form
            ParentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            DoctarDetails DoctarDetails = new DoctarDetails();

            // Display the target form
            DoctarDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            AppoinmentDetails AppoinmentDetails = new AppoinmentDetails();

            // Display the target form
            AppoinmentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PatientHistoryDetails PatientHistoryDetails = new PatientHistoryDetails();

            // Display the target form
            PatientHistoryDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PaymentDetails PaymentDetails = new PaymentDetails();

            // Display the target form
            PaymentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PharmacyPayment PharmacyPayment = new PharmacyPayment();

            // Display the target form
            PharmacyPayment.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            SupplyerOrderDetails SupplyerOrderDetails = new SupplyerOrderDetails();

            // Display the target form
            SupplyerOrderDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            DrugsDetails DrugsDetails = new DrugsDetails();

            // Display the target form
            DrugsDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PatientDrudOrders PatientDrudOrders = new PatientDrudOrders();

            // Display the target form
            PatientDrudOrders.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;

        }

        private void Test_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            LabTest LabTest = new LabTest();

            // Display the target form
            LabTest.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            LabassistantDetails LabassistantDetails = new LabassistantDetails();

            // Display the target form
            LabassistantDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            VierOldFemailPatient VierOldFemailPatient = new VierOldFemailPatient();

            // Display the target form
            VierOldFemailPatient.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            ViewAppoinment ViewAppoinment = new ViewAppoinment();

            // Display the target form
            ViewAppoinment.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;

        }
    }
}
