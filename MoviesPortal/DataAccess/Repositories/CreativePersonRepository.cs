﻿using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CreativePersonRepository : ICreativePersonRepository
    {
        private readonly MoviePortalContext _context;

        public CreativePersonRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreativePersonModel creativePerson)
        {
            _context.CreativePersons.Add(creativePerson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.CreativePersons.FindAsync(id);
            _context.CreativePersons.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CreativePersonModel creativePerson)
        {
            var creativePersonOld = _context.CreativePersons.Find(id);
            if(creativePersonOld != null)
            {
                creativePersonOld.Name = creativePerson.Name;
                creativePersonOld.SurName = creativePerson.SurName;
                creativePersonOld.PhotographyPath = creativePerson.PhotographyPath;
                creativePersonOld.DateOfBirth = creativePerson.DateOfBirth;                
                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CreativePersonModel>> GetAllCreativePersons()
        {
            return await _context.CreativePersons.ToArrayAsync();
        }

        public async Task<CreativePersonModel> GetCreativePersonsById(int id)
        {
            var person = await _context.CreativePersons
                .Include(cm => cm.RoleCreativeMovie).ThenInclude(cm => cm.Movie)
                .Include(r => r.RoleCreativeMovie).ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

    }
}
