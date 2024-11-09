using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class HomeController : Controller
{
    
    private readonly IBeneficiarioRepository _beneficiarioRepository;


    public HomeController(IBeneficiarioRepository beneficiarioRepository)
    {
        _beneficiarioRepository = beneficiarioRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var beneficiarios = _beneficiarioRepository.ObterTodos();
        return View(beneficiarios);
    }
    
    
    [HttpGet]
    public IActionResult Beneficiario(int? id)
    {
        var beneficiario = _beneficiarioRepository.ObterPorId(id ?? 0);
        return View(beneficiario);
    }
    
    // public IActionResult Lista()
    // {
    //     var listaBeneficiarios = new List<BeneficiarioEntity>
    //     {
    //         new BeneficiarioEntity
    //         {
    //             Cpf = "46813246578", Nome = "Fulano", Password = "12345678", Telefone = "0987654321",
    //             Tipo = TipoBeneficiarioEnum.Pessoal, DataAdesao = DateTime.Now
    //         },
    //         new BeneficiarioEntity
    //         {
    //             Cpf = "46813246578", Nome = "Ciclano", Password = "12345678", Telefone = "0987654321",
    //             Tipo = TipoBeneficiarioEnum.Empresa, DataAdesao = DateTime.Now
    //         },
    //         new BeneficiarioEntity
    //         {
    //             Cpf = "46813246578", Nome = "Beltrano", Password = "12345678", Telefone = "0987654321",
    //             Tipo = TipoBeneficiarioEnum.Familiar, DataAdesao = DateTime.Now
    //         },
    //         new BeneficiarioEntity
    //         {
    //             Cpf = "46813246578", Nome = "Zé", Password = "12345678", Telefone = "0987654321",
    //             Tipo = TipoBeneficiarioEnum.Familiar, DataAdesao = DateTime.Now
    //         },
    //         new BeneficiarioEntity
    //         {
    //             Cpf = "46813246578", Nome = "Pedro", Password = "12345678", Telefone = "0987654321",
    //             Tipo = TipoBeneficiarioEnum.Empresa, DataAdesao = DateTime.Now
    //         },
    //
    //     };
    //     return View(listaBeneficiarios);
    // }
    
    [HttpPost]
    public IActionResult Cadastrar(BeneficiarioEntity beneficiario)
    {
        if (ModelState.IsValid)
        {
            _beneficiarioRepository.SalvarDados(beneficiario);
            return RedirectToAction(nameof(Index));
        }
        return View(beneficiario);
    }
    
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(BeneficiarioEntity beneficiario)
    {
        if (ModelState.IsValid)
        {
            _beneficiarioRepository.EditarDados(beneficiario.Id, beneficiario);
    
            return RedirectToAction(nameof(Index));
        }
        return View(beneficiario);
    }
    
    
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var beneficiario = _beneficiarioRepository.ObterPorId(id ?? 0);
    
        return View(beneficiario);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}