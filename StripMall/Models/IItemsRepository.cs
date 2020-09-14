using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public interface IItemsRepository
    {
        Items GetItem(Guid ItemsId);
        IEnumerable<Items> GetAllItems(string id, int? categoryId);
        Task<Items> AddItem(Items item);
        Items UpdateItem(Items item, Items ItemChanges);
        Task<Items> DeleteItem(Guid id);
        Task<Items> ChangeStatus(Guid ItemsId);
    }
}
