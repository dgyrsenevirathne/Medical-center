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
    public partial class ViewAppoinment : Form
    {
        string connectionString = @"Data Source=LAPTOP-4VMD8P7I;Initial Catalog=medical_center;Integrated Security=True;";
        public ViewAppoinment()
        {
            InitializeComponent();
        }

        private void ViewAppoinment_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    // Open the connection
                    sqlCon.Open();

                    // Create a SqlDataAdapter to fetch data from the AppointmentDetailsView
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AppointmentDetailsView", sqlCon);

                    // Create a DataTable to hold the data
                    DataTable dt = new DataTable();

                    // Fill the DataTable with data from the view
                    da.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void doctartb_TextChanged(object sender, EventArgs e)
        {
            appoinmenttb.Text = string.Empty;

        }

        private void appoinmenttb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if DoctorID is provided
                if (!string.IsNullOrEmpty(doctartb.Text) && !string.IsNullOrEmpty(appodatetb.Text))
                {
                    int doctorID = int.Parse(doctartb.Text); // Parse the DoctorID from the textbox
                    DateTime appoinmentDate = DateTime.Parse(appodatetb.Text); // Parse the AppointmentDate from the textbox
                    // Call the SQL function to get total appointments for the doctor
                    int totalAppointments = GetTotalAppointmentsForDoctor(doctorID, appoinmentDate);

                    // Display the result in the textbox
                    appoinmenttb.Text = totalAppointments.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter a Doctor ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        private int GetTotalAppointmentsForDoctor(int doctorID, DateTime appoinmentDate)
        {
            int totalAppointments = 0;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Open the connection
                sqlCon.Open();

                // Create a SqlCommand to execute the SQL function
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.GetTotalAppointmentsForDoctor(@DoctorID, @AppoinmentDate)", sqlCon))
                {
                    // Add parameter for DoctorID
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    cmd.Parameters.AddWithValue("@AppoinmentDate", appoinmentDate);

                    // Execute the command and get the result
                    totalAppointments = (int)cmd.ExecuteScalar();
                }
            }
            return totalAppointments;
        }

        private void appodatetb_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
