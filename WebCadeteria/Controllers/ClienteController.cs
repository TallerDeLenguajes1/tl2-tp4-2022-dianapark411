using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCadeteria.Models;
using System.Text;

namespace WebCadeteria.Controllers;
public class ClienteController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ClienteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult AltaCliente()
    {
        return View();
    }

    public IActionResult CargarCliente()
    {
        string id, nombre, direccion, telefono, ref_dir;
        string path = @"C:\DIANA\Facultad\3er ANIO\2do Cuatrimestre\Taller de lenguajes II\TP4\tl2-tp4-2022-dianapark411\WebCadeteria\Recursos\clientes.csv";
        
        try{
            id = Request.Form["id"]; // lo que va entre comilla son los name del form
            nombre = Request.Form["nombre"];
            direccion = Request.Form["dir"];
            telefono = Request.Form["telefono"];
            ref_dir = Request.Form["ref_dir"];

            System.IO.File.AppendAllText(path, $"{id};{nombre};{direccion};{telefono};{ref_dir}\n");
            return View("ListarClientes");
        }catch(Exception e){
            //Hace falta???
            Console.WriteLine("Error message: " + e.Message);
            return View();
        }
    }

    public IActionResult MostrarClientes()
    {
        return View("ListarClientes");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
