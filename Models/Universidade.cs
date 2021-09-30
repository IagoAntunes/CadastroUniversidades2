using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETfaculdade2.Models
{
    public class Universidade
    {
        public int UniversidadeID { get; set; }
        public String Nome { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }


        public virtual ICollection<Curso> Cursos { get; set; }//Coleção de Cursos




    }
}