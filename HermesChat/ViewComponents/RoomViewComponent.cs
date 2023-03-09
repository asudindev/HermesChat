using HermesChat.Data;
using Microsoft.AspNetCore.Mvc;

namespace HermesChat.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private AppDbContext _appDbContext;

        public RoomViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var chats = _appDbContext.Chats.ToList();
            return View(chats);
        }
    }
}
