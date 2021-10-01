# CadastroUniversidades2

<h4> 1- Instalação EntityFramework

```
Install-Package EntityFramework
```

<h4> 2- Adicionando "connectionStrings" para conectar ao banco de dados

```
  <connectionStrings>
    <add name="EFConnectionString" connectionString="NOMEBANCODEDADOS;Language=Brazilian;Initial Catalog=Universidade;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

<h4> 3- Adicionando Models

```C#
        public int AlunoID { get; set; }               public int CursoID { get; set; }                             public int UniversidadeID { get; set; }
        public String Nome { get; set; }               public String Nome { get; set; }                             public String Nome { get; set; }
        public int CursoID { get; set; }               public int UniversidadeID { get; set; }                      public String Cidade { get; set; }
                                                                                                                    public String UF { get; set; }
        [ForeignKey("CursoID")]                        [ForeignKey("UniversidadeID")]   
        public virtual Curso Curso { get; set; }       public virtual Universidade Universidade { get; set; }       public virtual ICollection<Curso> Cursos { get; set; }
```
<h4> 4- Criando pasta Data Access Object e arquivo EFContext

```c#
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
```

<h4> 5- Adicionando Controller e conecta-los ao EFContext

<h4> 6- Comandos banco de dados

```
Enable-Migrations

Add-Migration Initial

Update-Database
```
