﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Book Book { get; set; }
    }
}
