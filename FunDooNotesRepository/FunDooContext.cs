using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooNotesModel;       //after right clicking depending and adding the reference of this class library. 

namespace FunDooNotesRepository
{
    internal class FunDooContext : DbContext
    {
        public FunDooContext(DbContextOptions<FunDooContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
