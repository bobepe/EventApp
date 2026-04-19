using EventApp.Data;
using EventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Services
{
    public class ItemService
    {
        private readonly EventAppDbContext _db;
        private readonly UserService _userService;

        public ItemService(EventAppDbContext db, UserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public List<Item> GetAll()
        {
            var userId = _userService.GetUserId();

            if (userId == null)
                return new List<Item>();

            return _db.items.ToList();
                /*.Where(i => i.CreatedById == userId.Value)
                .ToList();*/
        }

        public void Add(Item item)
        {
            var userId = _userService.GetUserId();

            if (userId == null)
                return;

            item.CreatedById = userId.Value;
            item.Creted = DateTime.Now;

            _db.items.Add(item);
            _db.SaveChanges();
        }

        public void Update(Item item)
        {
            var userId = _userService.GetUserId();

            if (userId == null)
                return;

            var existing = _db.items.FirstOrDefault(i => i.Id == item.Id);
                //.FirstOrDefault(i => i.Id == item.Id && i.CreatedById == userId.Value);

            if (existing == null)
                return;

            existing.Subject = item.Subject;
            existing.Type = item.Type;
            existing.Description = item.Description;
            existing.Deadline = item.Deadline;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var userId = _userService.GetUserId();

            if (userId == null)
                return;

            var item = _db.items
                .FirstOrDefault(i => i.Id == id && i.CreatedById == userId.Value);

            if (item == null)
                return;

            _db.items.Remove(item);
            _db.SaveChanges();
        }
    }
}