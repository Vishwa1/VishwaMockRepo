using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHGolfStore.Domain.Abstract;
using SHGolfStore.Domain.Entities;

namespace SHGolfStore.Domain.Concrete
{
    public class EFItemRepository : IItemRepository 
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Item> Items
        {
            get { return context.Items; }
        }

        public void SaveItem(Item item)
        {
            if (item.ItemId == 0)
            {
                context.Items.Add(item);
            }
            else
            {
                Item i = context.Items.Find(item.ItemId);

                if (i != null)
                {
                    
                    i.ItemName = item.ItemName;
                    i.ItemDesc = item.ItemDesc;
                    i.ItemPrice = item.ItemPrice;
                    i.Brand = item.Brand;
                    i.Category = item.Category;
                }
            }

            context.SaveChanges();
        }

        public Item DeleteItem(int itemId)
        {
            Item i = context.Items.Find(itemId);

            if (i != null)
            {
                context.Items.Remove(i);
                context.SaveChanges();
            }
            return i;
            
        }

    }
}
