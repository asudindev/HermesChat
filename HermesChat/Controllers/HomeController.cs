using HermesChat.Data;
using HermesChat.Enums;
using HermesChat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Hermes.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index() => View();

        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            var chat = _appDbContext.Chats
                .Include(item => item.Messages)
                .FirstOrDefault(item => item.Id == id);
            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            _appDbContext.Chats.Add(new Chat
            {
                Name = name,
                Type = ChatType.Room
            });

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}