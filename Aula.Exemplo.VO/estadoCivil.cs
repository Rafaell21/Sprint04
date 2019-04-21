using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Exemplo.VO
{
    public class estadoCivil
    {
        [Key]
        public int idEstadoCivil { get;  set; }

        [Display(Name = "estadoCivil_descricao", ResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno))]
        [Required(ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno), ErrorMessageResourceName = "estadoCivil_descricao_required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesComum), ErrorMessageResourceName = "MessageMaxLenght")]
        public string descricao { get;  set; }
    }
}
