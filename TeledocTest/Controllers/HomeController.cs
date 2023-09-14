using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeledocTest.Infrastructure;
using TeledocTest.Models;

namespace TeledocTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientModel client)
        {
            client.CreatedDate = DateTime.Now;
            client.UpdatedDate = DateTime.Now;
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            ClientModel client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client is not null)
            {
                List<FounderModel> founders = _context.Founders.Where(f => f.ClientId == id).ToList();
                _context.Founders.RemoveRange(founders);
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Redirect("~/Service/NotFoundPage");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ClientModel client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client is not null)
            {
                return View(client);
            }
            return Redirect("~/Service/NotFoundPage");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientModel client)
        {
            ClientModel clientDb = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
            clientDb.Inn = client.Inn;
            clientDb.Name = client.Name;
            clientDb.Type = client.Type;
            clientDb.UpdatedDate = DateTime.Now;
            _context.Clients.Update(clientDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        } 

    }
}