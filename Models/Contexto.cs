﻿using Microsoft.EntityFrameworkCore;

namespace Oráculo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Comunidades> Comunidades { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<MaisComentados> MaisComentados { get; set; }
        public DbSet<Novidade> Novidade { get; set; }
        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}