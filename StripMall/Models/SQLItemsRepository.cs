using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace StripMall.Models
{
    public class SQLItemsRepository : IItemsRepository
    {
         
        //private Items item;
        private AppDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        public DbSet<Items> ItemEntity { get; }

        public SQLItemsRepository(AppDbContext context,
            IHostingEnvironment hostingEnvironment)    // Items item)
        {
           // this.item = item;
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
            ItemEntity = context.Set<Items>();
        }

        public async Task<Items> AddItem(Items item)
        {
            context.Entry(item).State = EntityState.Added;
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Items> DeleteItem(Guid id)
        {
            //id = id.ToString();
            Items item =await context.S_items.FindAsync(id);
            //throw new NotImplementedException();
            if (item != null)
            {
                if (item.PhotoPath != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images\\item");
                    string filePath = Path.Combine(uploadsFolder, item.PhotoPath);
                    File.Delete(filePath);
                }
                context.S_items.Remove(item);
            }
            await context.SaveChangesAsync();
            return item;
        }

        public IEnumerable<Items> GetAllItems(string id, int? categoryId)
        {
            IEnumerable<Items> items;
            if (categoryId == null)
            {
                items = context.S_items.Include(u => u.Seller).Include(c=>c.category)
                    .Where(x => x.Id == id).ToList();
            }
            else
            {
                items = context.S_items.Include(c => c.category).Include(s => s.Seller).
                                        Where(a => a.Id == id).
                                        Where(x => x.category.CategoryId == categoryId).
                                        ToList();
            }
            return items;
        }

        

        public Items GetItem(Guid Id)
        {
            IEnumerable<Items> item = context.S_items.Include(u => u.Seller).
                Include(c=> c.category).Where(x=> x.ItemsId == Id);
            return item.FirstOrDefault();
        }

        public async Task<Items> ChangeStatus(Guid ItemsId)
        {
            Items item = await context.S_items.FindAsync(ItemsId);
            item.IsInStock = item.IsInStock ? false : true;
            await context.SaveChangesAsync();
            return item;
        }

        public Items UpdateItem(Items item, Items itemChanges)
        {
            item.ItemName = itemChanges.ItemName;
            item.ItemPrice = itemChanges.ItemPrice;
            item.ItemDesc = itemChanges.ItemDesc;
            item.ItemWeight = itemChanges.ItemWeight;
            item.category = itemChanges.category;
            context.SaveChangesAsync();
            return item;
        }
    }
}