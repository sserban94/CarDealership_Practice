﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer_PracticeExam.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Manufacturer()
        {

        }
        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
