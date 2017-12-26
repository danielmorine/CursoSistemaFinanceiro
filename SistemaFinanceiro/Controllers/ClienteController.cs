using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class ClienteController : Controller
    {

        ClienteNeg objClienteNeg;

        //INSTANCIAR  E REALIZAR A CHAMADA DO ClienteNeg

        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();
        }


        // MOSTRAR Cliente
        public ActionResult Index()
        { // CRIAR UMA LISTA 
          //VAMOS LÁ DENTRO DO objClienteNeg e acesar o método FindAll
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
          //  mensagemInicioRegistrar();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        //Passar no parametro dados do Cliente que está na classe Cliente com nome
        //objCliente
        public ActionResult Create(Cliente objCliente)
        {
           // mensagemInicioRegistrar();
            objClienteNeg.create(objCliente);
            //LIMPA
            ModelState.Clear();
            //RETORNA A VIEW DE CRIAÇÃO
            return View("create");
            
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
