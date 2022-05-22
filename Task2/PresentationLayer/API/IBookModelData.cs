﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IBookModelData
    {
        int Book_Id { get; }
        string Name { get; }
        int Pages { get; }
        double Price { get; }
    }
}
