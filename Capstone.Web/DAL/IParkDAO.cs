﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IParkDAO
    {
        List<Park> GetAllParks();
        Park GetParkDetail(string parkCode);
        List<Park> GetFavoriteParks();
    }
}
