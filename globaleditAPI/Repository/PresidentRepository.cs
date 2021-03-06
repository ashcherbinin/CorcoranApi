﻿using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CorcoranAPI.Models.PresidentModel;

namespace CorcoranAPI.Repository
{
    public class PresidentRepository:IPresidentRepository
    {
       

        private readonly PresidentContext _presidentContext;

        public PresidentRepository(PresidentContext context)
        {
            _presidentContext = context;
        }


        public async Task <IEnumerable> getPresidentList(bool descending)
        {
            
            IEnumerable result = !descending
                ? await _presidentContext.Presidents.Select(a => new { a.president, a.birthday, a.birthplace, a.deathday, a.Deathplace })
                                                 .OrderBy(b => b.president).ToListAsync()
                : await _presidentContext.Presidents.Select(a => new { a.president, a.birthday, a.birthplace, a.deathday, a.Deathplace })
                                                 .OrderByDescending(b => b.president).ToListAsync();
            return result;
        }
    }
}
