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
    public partial class PharmacyPayment : Form
    {
        string connectionString = @"Data Source=LAPTOP-4VMD8P7I;Initial Catalog=medical_center;Integrated Security=True;";
        public PharmacyPayment()
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
                    SqlCommand sqlCmd = new SqlCommand("pharmacyPayments", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@paymentDate", paydateTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amount", amountTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@paymentType", paymenttypeTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@phStatus", texpaystatusTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@patientId", paytentidTB.Text.Trim());
                   
                    sqlCmd.ExecuteNonQuery();
                    display_data();
                    paytentidTB.Text = "";
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
            paydateTB.Text = amountTB.Text = paymenttypeTB.Text = texpaystatusTB.Text = paytentidTB.Text = "";
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
                    cmd.CommandText = "select * from PhPayments";
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

        private void PharmacyPayment_Load(object sender, EventArgs e)
        {
            display_data();
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
                    cmd.CommandText = "SELECT * FROM PhPayments WHERE  PatientID = @patientId";
                    cmd.Parameters.AddWithValue("@patientId", paytentidTB.Text.Trim());
                    cmd.ExecuteNonQuery();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        paydateTB.Text = reader["PaymentDate"].ToString();
                        amountTB.Text = reader["Amount"].ToString();
                        paymenttypeTB.Text = reader["Phtype"].ToString();
                        texpaystatusTB.Text = reader["PhStatus"].ToString();
                        paytentidTB.Text = reader["PatientID"].ToString();
                       
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
            // Create an instance of the target form
            ParentDetails ParentDetails = new ParentDetails();

            // Display the target form
            ParentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            DoctarDetails DoctarDetails = new DoctarDetails();

            // Display the target form
            DoctarDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            AppoinmentDetails AppoinmentDetails = new AppoinmentDetails();

            // Display the target form
            AppoinmentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Create an instance of the target form
            PatientHistoryDetails PatientHistoryDetails = new PatientHistoryDetails();

            // Display the target form
            PatientHistoryDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PaymentDetails PaymentDetails = new PaymentDetails();

            // Display the target form
            PaymentDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            PharmacyPayment PharmacyPayment = new PharmacyPayment();

            // Display the target form
            PharmacyPayment.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            DrugsDetails DrugsDetails = new DrugsDetails();

            // Display the target form
            DrugsDetails.Show();

            // Optionally, hide the current form if you don't need it anymore
            Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Create an instance of the target form
            SupplyerOrderDetails SupplyerOrderDetails = new SupplyerOrderDetails();

            // Display the target form
            SupplyerOrderDetails.Show();

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
