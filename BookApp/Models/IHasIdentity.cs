﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public interface IHasIdentity
    {
        public int Id { get; set; }
    }
}
