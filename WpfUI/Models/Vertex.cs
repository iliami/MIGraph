﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models.Base;

namespace WpfUI.Models
{
    public class Vertex(string name)
    {
        public string Name { get; set; } = name;
    }
}
