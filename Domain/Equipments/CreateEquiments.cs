﻿using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Equipments
{
    public class CreateEquiments
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //public List<Exercise> exercises { get; set; }
    }
}