using BackEnd.Repository.Clases;
using BackEnd.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    public class AutorController : Controller
    {
        private readonly IRepositorioAutor repositorioAutor;

        public AutorController()
        {
            repositorioAutor = new RepositorioAutor();
        }

        [HttpPost, Route("ConsultarAutores")]
        public ActionResult ConsultarAutores()
        {
            var resultado = repositorioAutor.ConsultarAutores();
            return Json(resultado);
        }

        [HttpPost, Route("AgregarAutor")]
        public ActionResult AgregarAutor(Autor autor)
        {
            var resultado = repositorioAutor.CrearAutor(autor);
            return Json(resultado);
        }

        [HttpPost, Route("ModificarAutor")]
        public ActionResult ModificarAutor(Autor autor)
        {
            var resultado = repositorioAutor.ModificarAutor(autor);
            return Json(resultado);
        }

        [HttpPost, Route("EliminarAutor")]
        public ActionResult EliminarAutor(Autor autor)
        {
            var resultado = repositorioAutor.EliminarAutor(autor);
            return Json(resultado);
        }

        [HttpPost, Route("ConsultarPaises")]
        public ActionResult ConsultarPaises(Autor autor)
        {
            var resultado = repositorioAutor.ConsultarPaises();
            return Json(resultado);
        }

        [HttpPost, Route("ConsultarCiudades")]
        public ActionResult ConsultarCiudades(Autor autor)
        {
            var resultado = repositorioAutor.ConsultarCiudades();
            return Json(resultado);
        }

        [HttpPost, Route("ConsultarGeneros")]
        public ActionResult ConsultarGeneros(Autor autor)
        {
            var resultado = repositorioAutor.ConsultarGeneros();
            return Json(resultado);
        }
    }
}
