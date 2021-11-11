﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCodeFirstVidly.Models;

namespace MVCCodeFirstVidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}