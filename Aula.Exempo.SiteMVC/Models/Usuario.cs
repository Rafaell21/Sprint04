using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula.Exempo.SiteMVC.Models
{
   public class Usuario
        {
            public Int32 CodUsuario { get; set; }
            public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
            public string Senha { get; set; }
            public string CPF { get; set; }
          
        }
 
}