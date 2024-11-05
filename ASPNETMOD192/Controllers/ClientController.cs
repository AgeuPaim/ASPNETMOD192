using ASPNETMOD192.Data;
using ASPNETMOD192.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data.Common;

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
            IEnumerable<Client> clients = _context.Clients.ToList();//BD devolve um lista de cliente e guarda na var
            //cliente

            return View(clients); //mostra o que guardei
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
            int v = _context.SaveChanges(); //Execução das operações  e registadas na BD

            return RedirectToAction(nameof(Index));//invoca uma ação que se chama Index
        }
       
        
        //Delete
        public IActionResult Delete()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Client? client = _context.Clients.Find(id);

            if (client is null)
            {
                return NotFound();
            }

            return View (client);
        }

        [HttpPost]
        public IActionResult Edit(Client updatingClient)
        {
            //Client? clientDB = _context.Clients.Find(updateClient.ID);
            // if (clientDB is null)          
            // {             
            //     return NotFound();

            // }          

            try
            {
                _context.Clients.Update(updatingClient);
                _context.SaveChanges();

            }

            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound();
            }

            catch (Exception ex)
            {
                return BadRequest(); //FIXEME
            }

            return RedirectToAction(nameof(Index));         

        }
        //Read
        public IActionResult Details(int id )

        {
            Client? client = _context.Clients.Find(id);

            if (client is null)
            {
                return NotFound();
            }

            return View(client);
        }

        
         //Delete
        [HttpGet]      
        public IActionResult Delete(int id)
        {
            Client? client = _context.Clients.Find(id);

            if (client is null)
            {
                return NotFound();
            }


            return View(client);// caso contrario eledevolve o valor do cliente
        }


        [HttpPost, ActionName("Delete")] //usa o URL da ação do delete
        public IActionResult DeleteConfirmed(int id)
        {

            Client? client = _context.Clients.Find(id);

            if (client is null)
            {
                return NotFound();
            }

            try
            {
                _context.Clients.Remove(client); // Remove o cliente do contexto
                _context.SaveChanges();          // Salva as alterações no banco de dados
                return RedirectToAction(nameof(Index)); // Redireciona para o método Index
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message); // Escreve a mensagem de erro no console
            }

            return View(client); // Retorna a visualização com o cliente em caso de erro
        }

    }
}
