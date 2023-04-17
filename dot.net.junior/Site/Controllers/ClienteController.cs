using LogicaNegocio.Exceptions;
using LogicaNegocio.Interfaces;
using Model.Entidades.Mappers;
using Model.Entidades.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ActionResult Create()
        {
            return View(new ClienteViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.Save(ClienteViewModelMapper.MapModelToEntity(model));

                    TempData["MensagemSucesso"] = $"O cliente '{model.NomeCliente}' foi cadastrado com secesso!";

                    return RedirectToAction("Search");
                }
                catch (BusinessException ex)
                {
                    TempData["MensagemAlerta"] = ex.Message;
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao cadastrar cliente.";
                }
            }
            else
            {
                TempData["MensagemAlerta"] = RetornaErroValidacao();
            }
            return View(model);
        }

        private string RetornaErroValidacao()
        {
            foreach (var modelStateEntry in ModelState.Values)
                foreach (var error in modelStateEntry.Errors)
                    return error.ErrorMessage;
            return "";
        }

        public async Task<ActionResult> Search()
        {
            var clientes = await _clienteService.GetAll();

            return View(ClienteViewModelMapper.MapEntityToModelList(clientes.ToList()));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var cliente = await _clienteService.GetById(id);

            var model = ClienteViewModelMapper.MapEntityToModel(cliente);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ClienteViewModel model)
        {
            try
            {
                var cliente = ClienteViewModelMapper.MapModelToEntity(model);

                await _clienteService.Update(cliente);

                TempData["MensagemSucesso"] = $"O cliente '{cliente.NomeCliente}' foi alterado com secesso!";

                return RedirectToAction("Search");
            }
            catch (BusinessException ex)
            {
                TempData["MensagemAlerta"] = ex.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var cliente = await _clienteService.GetById(id);

            var model = ClienteViewModelMapper.MapEntityToModel(cliente);

            return View(model);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var cliente = await _clienteService.GetById(id);

            await _clienteService.Delete(cliente);

            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirme(ClienteViewModel model)
        {
            var cliente = ClienteViewModelMapper.MapModelToEntity(model);

            await _clienteService.Delete(cliente);

            return RedirectToAction("Search");
        }

    }
}
