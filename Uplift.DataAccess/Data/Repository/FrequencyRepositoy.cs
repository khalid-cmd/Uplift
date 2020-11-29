﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class FrequencyRepositoy : Repository<Frequency>, IFrequencyRepositoy
    {
        private readonly ApplicationDbContext _db;

        public FrequencyRepositoy(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetFrequencyListForDropDown()
        {
            return _db.Frequency.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Frequency frequency)
        {
            Frequency objFormDB = _db.Frequency.FirstOrDefault(f => f.Id == frequency.Id);
            objFormDB.Name = frequency.Name;
            objFormDB.FrequencyCount = frequency.FrequencyCount;
            _db.SaveChanges();
        }
    }
}
