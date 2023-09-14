using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TeledocTest.Infrastructure;
using TeledocTest.Models;

namespace TeledocTest.Controllers
{
    public class FounderController: Controller
    {
        private readonly ApplicationContext _context;

        public FounderController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(int clientId)
        {
            ClientModel client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            if (client.Type != 0)
            {
                return Redirect("~/Service/Forbidden");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FounderModel founder, int clientId)
        {
            founder.ClientId = clientId;
            founder.CreatedDate = DateTime.Now;
            founder.UpdatedDate = DateTime.Now;

            _context.Founders.Add(founder);
            await _context.SaveChangesAsync();
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> Index(int id)
        {
            ClientModel client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            List<FounderModel> founders = _context.Founders.Where(f => f.ClientId == id).ToList();
            
            if (founders.IsNullOrEmpty())
            {
                return Redirect("~/Service/NotFoundPage");
            }
            
            return View(founders);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            FounderModel founder = await _context.Founders.FirstOrDefaultAsync(f => f.Id == id);
            if (founder is not null)
            {
                _context.Founders.Remove(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Redirect("~/Service/NotFoundPage");
        }

        public async Task<IActionResult> Edit(int id)
        {
            FounderModel founder = await _context.Founders.FirstOrDefaultAsync(f => f.Id == id);
            if (founder is not null)
            {
                return View(founder);
            }
            return Redirect("~/Service/NotFoundPage");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FounderModel founder)
        {
            FounderModel founderDb = await _context.Founders.FirstOrDefaultAsync(f => f.Id == founder.Id);
            founderDb.Inn = founder.Inn;
            founderDb.FullName = founder.FullName;
            founderDb.UpdatedDate = DateTime.Now;
            _context.Founders.Update(founderDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
