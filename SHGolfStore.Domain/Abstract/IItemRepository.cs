using SHGolfStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHGolfStore.Domain.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> Items { get; }

        void SaveItem(Item item);

        Item  DeleteItem(int itemId);
    }
}
