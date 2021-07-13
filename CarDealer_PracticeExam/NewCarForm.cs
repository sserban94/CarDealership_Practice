using CarDealer_PracticeExam.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealer_PracticeExam
{
    public partial class NewCarForm : Form
    {
        #region Attributes
        public static int id = 0;
        public Car Car { get; set; }
        #endregion

        public NewCarForm()
        {
            InitializeComponent();
            DisplayManufacturers();
        }

        public NewCarForm(Car car)
        {
            InitializeComponent();
            DisplayManufacturers();
            Car = car;
        }

        private void DisplayManufacturers()
        {
            foreach (Manufacturer manufacturer in MainForm.manufacturers)
            {
                cbManufacturer.Items.Add(manufacturer.Name);
            }
        }

        public void AddCar()
        {

            if (!ValidateChildren())
            {
                MessageBox.Show(
                    "Validations failed. Check data",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (Car == null)
            {
                Car car = new Car();
                car.Id = ++id;
                car.Model = tbModel.Text;
                car.ManufacturingDate = dtpManufacturingDate.Value;
                car.Price = double.Parse(tbPrice.Text);

                foreach (Manufacturer manufacturer in MainForm.manufacturers)
                {
                    if (cbManufacturer.Text == manufacturer.Name)
                    {
                        car.ManufacturerId = manufacturer.Id;
                    }
                }
                MainForm.cars.Add(car);
            }
            else
            {
                Car.Model = tbModel.Text;
                Car.ManufacturingDate = dtpManufacturingDate.Value;
                Car.Price = double.Parse(tbPrice.Text);

                foreach (Manufacturer manufacturer in MainForm.manufacturers)
                {
                    if (cbManufacturer.Text == manufacturer.Name)
                    {
                        Car.ManufacturerId = manufacturer.Id;
                    }
                }
            }
        }


        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddCar();
            this.Close();
        }

        private void cbManufacturer_Validating(object sender, CancelEventArgs e)
        {
            if (cbManufacturer.SelectedIndex == -1)
            {
                errorProvider.SetError(cbManufacturer, "Must select car manufacturer");
                e.Cancel = true;
            }
        }

        private void cbManufacturer_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(cbManufacturer, null);
        }

        private void tbModel_Validating(object sender, CancelEventArgs e)
        {
            if (tbModel.Text.Length < 1)
            {
                errorProvider.SetError(tbModel, "Field can't be empty");
                e.Cancel = true;
            }
        }

        private void tbModel_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbModel, null);
        }

        private void tbModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void dtpManufacturingDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpManufacturingDate.Value.Date > DateTime.Now.Date || dtpManufacturingDate.Value.Year < DateTime.Now.Year - 1)
            {
                errorProvider.SetError(dtpManufacturingDate, "Invalid date. Only current/previous year accepted");
                e.Cancel = true;
            }
            //else if (dtpManufacturingDate.Value.Year < DateTime.Now.Year - 1)
            //{
            //    errorProvider.SetError(dtpManufacturingDate, "Invalid date. Only current/previous year accepted");
            //    e.Cancel = true;
            //}
        }

        private void dtpManufacturingDate_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dtpManufacturingDate, null);
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if (tbPrice.Text.Length < 1)
            {
                errorProvider.SetError(tbPrice, "Field can't be empty");
                e.Cancel = true;
            }
        }

        private void tbPrice_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbPrice, null);
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void NewCarForm_Load(object sender, EventArgs e)
        {
            if (Car != null)
            {
                foreach (Manufacturer manufacturer in MainForm.manufacturers)
                {
                    if (Car.ManufacturerId == manufacturer.Id)
                    {
                        cbManufacturer.SelectedItem = manufacturer.Name;
                    }
                }
                tbModel.Text = Car.Model;
                dtpManufacturingDate.Value = Car.ManufacturingDate;
                tbPrice.Text = Car.Price.ToString();
            }
        }
    }
}
