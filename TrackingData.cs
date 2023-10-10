using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Livestock_Tracking
{
    public partial class TrackingData : Form
    {

        string connectionString = "Server=VIVOBOOK\\SQLEXPRESS;Database=EastwoodFarm_DB;Integrated Security=True;";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dataTable;


        public void allAnimalsData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayAllTrackingData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void cowTrackingData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayCowTrackingData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void goatTrackingData() 
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayGoatTrackingData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void simulateDroneFlightCows()
        {
            string path = @"..\..\Scripts\cow_counts.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Cows.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("simulateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@animalCount", int.Parse(text));
                    command.Parameters.AddWithValue("@dateTime", DateTime.Now);

                    command.ExecuteNonQuery();

                }
            }

        }

        public void simulateDroneFlightHorses()
        {
            string path = @"..\..\Scripts\sheep_counts.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Horses.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        }

        public void SimulateDroneFightSheep()
        {
            string path = @"..\..\Scripts\sheep_counts.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Sheep.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        }

        public void simulateThermal()
        {
            string path = @"..\..\Scripts\temperature.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Thermal.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        }

        public void dateList()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("dateDisplayList", connection);
 
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime valueOfDate = reader.GetDateTime(0);
                cbDatesList.Items.Add(valueOfDate.ToString("yyyy-MM-dd")); 
            }

            reader.Close();

            connection.Close();
        }

        public TrackingData()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void TrackingData_Load(object sender, EventArgs e)
        {
            cowTrackingData();
            dateList();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void cbDatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbDatesList.SelectedItem.ToString();

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("viewTrackingViaDate", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@listDate", selectedValue);

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        private void TrackingData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cowTrackingData();
        }

        private void btnCows_Click(object sender, EventArgs e)
        {
            simulateDroneFlightCows();
        }

        private void btnSheep_Click(object sender, EventArgs e)
        {
            SimulateDroneFightSheep();
        }

        private void btnHorse_Click(object sender, EventArgs e)
        {
            simulateDroneFlightHorses();
        }

        private void btnThermal_Click(object sender, EventArgs e)
        {
            simulateThermal();
        }
    }
}
