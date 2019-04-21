using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula.Exemplo.VO
{
    public class aluno
    {
        [Key]
        public int idAluno { get;  set; }

        [Display(Name = "aluno_nome", ResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno))]
        [Required(ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno), ErrorMessageResourceName = "aluno_nome_required")]
        public string nome { get;  set; }

        [Display(Name = "aluno_email", ResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno))]
        [Required(ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno), ErrorMessageResourceName = "aluno_email_required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "aluno_senha", ResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno))]
        [Required(ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno), ErrorMessageResourceName = "aluno_senha_required")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        #region Propriedades - FK
        [Display(Name = "aluno_idEstadoCivil", ResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno))]
        [Required(ErrorMessageResourceType = typeof(Aula.Exemplo.VO.Resources.ResourcesAluno), ErrorMessageResourceName = "aluno_idEstadoCivil_Required")]
        [ForeignKey("estadoCivil")]
        public virtual int idEstadoCivil { get; set; }
        #endregion

    }
}
