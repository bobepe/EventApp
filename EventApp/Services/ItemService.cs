using EventApp.Models;

namespace EventApp.Services
{
    public class ItemService
    {
        public ItemService() { }

        public List<Item> GetAll()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Id = 1, Subject = "Test", Type = ItemType.Event, CreatedById = 1 });
            return items;
        }

        public void Add(Item item)
        {
            // save
        }

        public void Update(Item item)
        {
            // update
        }

        public void Delete(int id)
        {
            // delete
        }
    }
}
