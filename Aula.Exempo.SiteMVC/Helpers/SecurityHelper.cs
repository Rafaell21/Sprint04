using System.Web;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Aula.Exempo.SiteMVC.Models;

namespace Aula.Exempo.SiteMVC.Helpers
{
    public class SecurityHelper
    {
        public static ObjectSecurity GetObjectSecurity()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["UsuarioLogado"] is Usuario)
            {
                Usuario obj = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
                return (new ObjectSecurity()
                {
                    UserSystem = obj.CodUsuario,
                    IdAluno = obj.CodUsuario,
                    Login = obj.Login,
                    Nome = obj.Nome
                });
            }
            return new ObjectSecurity();
        }

        public static void SetUserLogged(Usuario objUsuario)
        {
            HttpContext.Current.Session["UsuarioLogado"] = objUsuario;
            HttpContext.Current.Session["CodUsuario"] = objUsuario.CodUsuario;
            HttpContext.Current.Session["Login"] = objUsuario.Login;
            HttpContext.Current.Session["cpf"] = objUsuario.CPF;


        }

        public static Usuario getUserLogged()
        {

            if (HttpContext.Current != null && HttpContext.Current.Session["UsuarioLogado"] is Usuario)
            {
                Usuario obj = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
                return obj;
            }
            return new Usuario();
        }

    }

}