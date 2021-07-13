using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer_PracticeExam.Entities
{
    public class Car : IComparable<Car>
    {
        #region Attributes
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double Price { get; set; }
        public int ManufacturerId { get; set; }
        #endregion

        #region Constructors
        public Car()
        {

        }
        public Car(int id, string model, DateTime manufacturingDate, double price, int manufacturerId)
        {
            Id = id;
            Model = model;
            ManufacturingDate = manufacturingDate;
            Price = price;
            ManufacturerId = manufacturerId;
        }
        #endregion

        public static explicit operator int(Car car)
        {
            TimeSpan daysBetween = DateTime.Now.Date - car.ManufacturingDate.Date;
            return (int)daysBetween.TotalDays;
        }

        public int CompareTo(Car other)
        {
            return this.Model.CompareTo(other.Model);
        }
    }
}
