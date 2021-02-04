using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repository
{
    public class LanguageRepo
    {
        private readonly BookDBContext _context = null;

        public LanguageRepo(BookDBContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetAll()
        {
            return await _context.language.Select(language => new LanguageModel() {
                Id = language.Id,
                Name = language.Name            
            }).ToListAsync();
        }
    }
}
