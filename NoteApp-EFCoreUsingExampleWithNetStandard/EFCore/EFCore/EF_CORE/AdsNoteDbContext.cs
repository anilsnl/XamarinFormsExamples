using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.EF_CORE
{
    public class AdsNoteDbContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }
        private static string DbPath;
        public AdsNoteDbContext(string path)
        {
            DbPath = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

        //for creation
        public static AdsNoteDbContext CreateDB(string db)
        {
            var ctx = new AdsNoteDbContext(db);
            ctx.Database.EnsureCreated();
            ctx.Database.Migrate();
            
            if (ctx.Notes.Any()==false)
            {
                ctx.Notes.AddRange(new Note[]
                    {
                        new Note(){Title="Note 1",NoteDetail="Detail 1"},
                       new Note(){Title="Note 2",NoteDetail="Detail 2"}
                    });
                ctx.SaveChanges();
            }
            return ctx;
        }
    }
}
