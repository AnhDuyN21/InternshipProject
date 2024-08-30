using Application.Interfaces;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternshipProjectContext context;

        public UnitOfWork(InternshipProjectContext _context)
        {
            context = _context;

        }
        public async Task<int> SaveChangeAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
