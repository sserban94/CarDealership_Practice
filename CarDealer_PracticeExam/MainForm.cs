using CarDealer_PracticeExam.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CarDealer_PracticeExam
{
    public partial class MainForm : Form
    {
        #region Attributes
        public static List<Manufacturer> manufacturers;
        public static List<Car> cars;
        public string connectionString = "data source=cars.db";
        #endregion
        public MainForm()
        {
            InitializeComponent();
            manufacturers = new List<Manufacturer>();
            cars = new List<Car>();
        }

        #region Methods
        public void ImportManufacturersTxt()
        {
            using (StreamReader reader = File.OpenText("Manufacturer.txt"))
            {
                reader.ReadLine();
                while (reader.Peek() != -1)
                {
                    Manufacturer manufacturer = new Manufacturer();
                    string line = reader.ReadLine();
                    char[] delimiters = { ' ' };
                    string[] words = line.Split(delimiters);
                    manufacturer.Id = int.Parse(words[0]);
                    manufacturer.Name = words[1];
                    manufacturers.Add(manufacturer);
                }
            }
        }

        public void DisplayCars()
        {
            // 1. Clear dgv
            dgvCars.Rows.Clear();
            cars.Sort();
            // 2. go through each element in list
            foreach (Car car in cars)
            {
                int rowIndex = dgvCars.Rows.Add(
                    new object[]
                    {
                        car.Id,
                        car.Model,
                        car.ManufacturingDate.ToShortDateString(),
                        car.Price,
                        car.ManufacturerId
                    });
                dgvCars.Rows[rowIndex].Tag = car;
            }
        }

        public void DeleteCar()
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("No car selected");
            }
            if (MessageBox.Show(
                "Are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteFromSql();
                foreach (DataGridViewRow row in dgvCars.SelectedRows)
                {
                    Car car = (Car)row.Tag;
                    cars.Remove(car);
                }
            }

        }

        public void EditCar()
        {
            Car car = (Car)dgvCars.SelectedRows[0].Tag;
            NewCarForm newCarForm = new NewCarForm(car);
            if (newCarForm.ShowDialog() == DialogResult.OK)
            {
                DisplayCars();
            }
        }
        #endregion

        public void CalculateAverageCarAge()
        {
            if (cars.Count != 0)
            {
                int total = 0;
                foreach (Car car in cars)
                {
                    total += (int)car;
                }
                toolStripStatusCarAge.Text = (total / cars.Count).ToString();
            }

        }

        public void ImportFromSql()
        {
            // IMPORT
            // 1. write query
            string query = "SELECT * FROM Cars";
            // 2. instantiate connection
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                // 3. instantiate command
                SqliteCommand command = new SqliteCommand(query, connection);
                // 4. open connection 
                connection.Open();
                // 5. execute reader from command
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.Id = int.Parse(reader["Id"].ToString());
                    car.Model = reader["Model"].ToString();
                    car.ManufacturingDate = DateTime.Parse(reader["ManufacturingDate"].ToString());
                    car.Price = double.Parse(reader["Price"].ToString());
                    car.ManufacturerId = int.Parse(reader["ManufacturerId"].ToString());
                    cars.Add(car);
                }
            }
        }

        public void ExportToSql()
        {
            string query = "INSERT INTO Cars (Id, Model, ManufacturingDate, Price, ManufacturerId) VALUES " +
                "(@Id, @Model, @ManufacturingDate, @Price, @ManufacturerId)";
            foreach (var car in cars)
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", car.Id);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@ManufacturingDate", car.ManufacturingDate);
                    command.Parameters.AddWithValue("@Price", car.Price);
                    command.Parameters.AddWithValue("@ManufacturerId", car.ManufacturerId);
                    connection.Open();
                    command.ExecuteNonQuery();  // i already have an id
                }
            }
        }

        public void DeleteFromSql()
        {
            string query = "DELETE FROM Cars WHERE Id = @Id";

            foreach (DataGridViewRow row in dgvCars.SelectedRows)
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    Car car = (Car)row.Tag;
                    command.Parameters.AddWithValue("@Id", car.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAllFromSql()
        {
            string query = "DELETE FROM Cars";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            ImportManufacturersTxt();
            ImportFromSql();
            DeleteAllFromSql();
            DisplayCars();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            NewCarForm form = new NewCarForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DisplayCars();
                CalculateAverageCarAge();
            }

        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            DeleteCar();
            DisplayCars();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            EditCar();
            DisplayCars();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExportToSql();
        }

        private void btnViewChart_Click(object sender, EventArgs e)
        {

        }
    }
}
