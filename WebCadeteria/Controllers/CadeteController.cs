using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCadeteria.Models;
using System.Text;

namespace WebCadeteria.Controllers;
public class CadeteController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public CadeteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult AltaCadete()
    {
        return View();
    }

    public IActionResult CargarCadete()
    {
        string id, nombre, direccion, telefono;
        string path = @"C:\DIANA\Facultad\3er ANIO\2do Cuatrimestre\Taller de lenguajes II\TP4\tl2-tp4-2022-dianapark411\WebCadeteria\Recursos\cadetes.csv";

        try{
            id = Request.Form["id"]; // lo que va entre comilla son los name del form
            nombre = Request.Form["nombre"];
            direccion = Request.Form["dir"];
            telefono = Request.Form["telefono"];
            System.IO.File.AppendAllText(path, $"{id};{nombre};{direccion};{telefono}\n");
            return View("ListarCadetes");
        }catch(Exception e){
            //Hace falta???
            Console.WriteLine("Error message: " + e.Message);
            return View();
        }
    }
        
    public IActionResult BuscarCadetes(){
        return View();
    }

    public IActionResult MostrarCadetes(){
        return View("ListarCadetes");
    }

    public IActionResult BajarCadete(int id){
        
        string path = @"C:\DIANA\Facultad\3er ANIO\2do Cuatrimestre\Taller de lenguajes II\TP4\tl2-tp4-2022-dianapark411\WebCadeteria\Recursos\cadetes.csv";
        string[] leer = System.IO.File.ReadAllLines(path);
        System.IO.File.WriteAllText(path,"");
        
        for (int i = 0; i < leer.Length; i++){
            string[] datos = leer[i].Split(";");
            if (id == Convert.ToInt32(datos[0])){   
            }else{
                System.IO.File.AppendAllText(path, leer[i] +"\n");
            } 
        }
        return View("ListarCadetes");
    }


 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
