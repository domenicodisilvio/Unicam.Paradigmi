﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli.Context
{
    public class MyDbContext : DbContext {

        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config) { }
        public DbSet<Libro> Libri { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
