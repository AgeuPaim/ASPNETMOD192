using ASPNETMOD192.Data;
using ASPNETMOD192.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMOD192.Controllers
{
    public class ClientController : Controller
    {

        private readonly ILogger<ClientController> _logger;

        private readonly ApplicationDbContext _context; // para me ligar o controlador a base de dados construtor aplicationDbcontest

        public ClientController(ILogger<ClientController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }


        //CRUD
        //Create
        //Read
        //Upadate
        //Delete
        
        
        // Read All
        public IActionResult Index()
        {
            return View();
        }


        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Create
        [HttpPost]
        public IActionResult Create(Client newClient)
        {
            _context.Clients.Add(newClient); //regisrto da operação para guardar "novo cliente"
            int v = _context.SaveChanges(); //Execução das operações registadas



            return RedirectToAction(nameof(Index));
        }


        //Delete
        public IActionResult Delete()
        {

            return View();
        }

        //Update
        public IActionResult Update()
        {

            return View();
        }



    }
}
