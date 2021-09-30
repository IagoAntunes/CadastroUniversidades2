using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETfaculdade2.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public String Nome { get; set; }
        public int CursoID { get; set; }
        
        [ForeignKey("CursoID")]
        public virtual Curso Curso { get; set; }




    }
}