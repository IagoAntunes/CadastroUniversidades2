using ASPNETfaculdade2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ASPNETfaculdade2.DAL
{
    public class EFContext : DbContext
    {
        //Classe manipular dados

        public EFContext() : base("EFConnectionString") { }   //Construtor

        //Aqui tem uma função do DBCONTEXT que estamos sobrescrevendo para não colcoar plural nas palavras
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Mudança
            base.OnModelCreating(modelBuilder);//Deixa o DbContext fazer o resto
        }



        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

    }
}