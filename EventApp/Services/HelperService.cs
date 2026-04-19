using EventApp.Models;

namespace EventApp.Services
{
    public class HelperService
    {
        public string GetTranslateType(ItemType type)
        {
            switch (type)
            {
                case ItemType.Event:
                    return "Událost";
                case ItemType.Task:
                    return "Úkol";
                case ItemType.Birthday:
                    return "Narozeniny";
                case ItemType.NameDay:
                    return "Svátek";
                case ItemType.Holiday:
                    return "Svátky";
                case ItemType.ShoppingList:
                    return "Nákup";
                case ItemType.House:
                    return "Domeček";
                case ItemType.Work:
                    return "Práce";
                default:
                    return "Různé";
            }
        }

        public string GetColorClass(ItemType type)
        {
            switch (type)
            {
                case ItemType.Event:
                    return "events-color";
                case ItemType.Task:
                    return "task-color";
                case ItemType.Birthday:
                    return "birthday-color";
                case ItemType.NameDay:
                    return "nameday-color";
                case ItemType.Holiday:
                    return "holiday-color";
                case ItemType.ShoppingList:
                    return "shop-color";
                case ItemType.House:
                    return "house-color";
                case ItemType.Work:
                    return "work-color";
                default:
                    return "other-color";
            }
        }

        public string GetBackgroundClass(ItemType type)
        {
            switch (type)
            {
                case ItemType.Event:
                    return "events-background";
                case ItemType.Task:
                    return "task-background";
                case ItemType.Birthday:
                    return "birthday-background";
                case ItemType.NameDay:
                    return "nameday-background";
                case ItemType.Holiday:
                    return "holiday-background";
                case ItemType.ShoppingList:
                    return "shop-background";
                case ItemType.House:
                    return "house-background";
                case ItemType.Work:
                    return "work-background";
                default:
                    return "other-background";
            }
        }
    }
}
