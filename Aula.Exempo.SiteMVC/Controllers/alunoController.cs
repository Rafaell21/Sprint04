using Aula.Exemplo.BO;
using Aula.Exemplo.VO;
using Aula.Exemplo.VO.Resources;
using Aula.Exempo.SiteMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula.Exempo.SiteMVC.Controllers
{
    public class alunoController : Controller
    {
        private alunoBO alunoBO = new alunoBO(SecurityHelper.GetObjectSecurity());
        private SelectListHelper selectHelper = new SelectListHelper();


        // GET: aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            ViewBag.idEstadoCivilList = selectHelper.GetEstadoCivilList("");
            return View();

        }

        [HttpPost]
        public ActionResult Create(aluno a)
        {
            alunoBO.Insert(a);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax(aluno a)
        {
            try
            {
                alunoBO.Insert(a);
                return Json(new { success = true, responseText = "Alterado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult Edit(int id)
        {

           var aluno = alunoBO.SelectByPK(id);
            ViewBag.idEstadoCivilList = selectHelper.GetEstadoCivilList("");
            return View(aluno);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAjax(aluno a)
        {
            try
            {
                alunoBO.Update(a);
                return Json(new { success = true, responseText = "Alterado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);

            }

        }


    }
}