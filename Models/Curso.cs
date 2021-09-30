using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETfaculdade2.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public String Nome { get; set; }


        public int UniversidadeID { get; set; }

        [ForeignKey("UniversidadeID")]//OBJETO SAIBA QUE A CHAVE ESTRANGERA É SOBRE ESSE CAMPO AQUI
        public virtual Universidade Universidade { get; set; }
        //Objeto do tipo universidade (Instancia)

    }
}