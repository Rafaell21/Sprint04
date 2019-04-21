using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aula.Exemplo.VO;
using Aula.Exemplo.BO;
using System.Web.Mvc;

namespace Aula.Exempo.SiteMVC.Helpers
{
    public class SelectListHelper
    {

        #region Propriedades 
        IList<estadoCivil> estadoCivilList = null;

        #endregion

        #region classe - AdmMarca
        public SelectList GetEstadoCivilList(string descricao)
        {
            if (estadoCivilList == null)
            {
                estadoCivil filtro = new estadoCivil();
                filtro.descricao = descricao;
                
                estadoCivilBO bo = new estadoCivilBO(SecurityHelper.GetObjectSecurity());

                //  filtro.active = true;
                estadoCivilList = bo.ListForLookup(filtro);
            }

            // lista, value, text
            var retorno = new SelectList(estadoCivilList, "idEstadoCivil", "descricao");

            return retorno;
        }

        #endregion


    }
}