using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunDooRepository.Entities;

namespace FunDooRepository.DbContextFolder
{
    public class FunDooNotesDbContext : DbContext
    {
        public FunDooNotesDbContext(DbContextOptions<FunDooNotesDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelNote> LabelNotes { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<NoteHistory> NotesHistory { get; set; }

        public DbSet<EmailOtp> EmailOtps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit many-to-many configuration
            modelBuilder.Entity<LabelNote>()
                .HasOne(ln => ln.Note)
                .WithMany(n => n.LabelNotes)
                .HasForeignKey(ln => ln.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LabelNote>()
                .HasOne(ln => ln.Label)
                .WithMany(l => l.LabelNotes)
                .HasForeignKey(ln => ln.LabelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Collaborator>()
           .HasOne(c => c.Owner)
           .WithMany()
           .HasForeignKey(c => c.OwnerUserId)
           .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
