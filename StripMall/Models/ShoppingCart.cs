using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private AppDbContext context;
        public ShoppingCart(AppDbContext context)
        {
            this.context = context;
        }

        public string ShoppingCartId { get; set; }
        
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public IEnumerable<ShoppingCartItem> GetCart(string id)
        {
            //string strid = id.ToString();
            var s = context.ShoppingCartItems.Where(x => x.CustomerId == id);
            return s;
        }

        public async Task AddToCartAsync(Items item, int Amount, ApplicationUser User)
        {
            ShoppingCartItem ExsItem = 
                await context.ShoppingCartItems.FindAsync(User.Id, item.ItemsId.ToString());
            
            if (ExsItem != null)
            {
                await InCount(User.Id, item.ItemsId.ToString());
            }
            else
            {
                ShoppingCartItem shoppingCartItem = new ShoppingCartItem
                {
                    Customer = User,
                    CustomerId = User.Id,
                    Item = item.ItemsId.ToString(),
                    ItemName = item.ItemName,
                    SellerId = item.Id,
                    ShopName = context.Users.Find(item.Id).ShopName,
                    ItemPrice = item.ItemPrice,
                    ItemCount = Amount,
                    ItemTotal = item.ItemPrice * Amount
                };
                await context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            await context.SaveChangesAsync();
        }

        public async Task InCount(string UserId, string ItemId)
        {
            ShoppingCartItem ExsItem =
                await context.ShoppingCartItems.FindAsync(UserId, ItemId);
            ExsItem.ItemCount += 1;
            ExsItem.ItemTotal = ExsItem.ItemPrice * ExsItem.ItemCount;
            await context.SaveChangesAsync();
        }

        public async Task DecCount(string UserId, string ItemId)
        {
            ShoppingCartItem ExsItem =
                await context.ShoppingCartItems.FindAsync(UserId, ItemId);
            
            if(ExsItem.ItemCount == 1)
            {
                await DelFromCart(UserId,ItemId);
            }
            else
            {
                ExsItem.ItemCount -= 1;

            }
            ExsItem.ItemTotal = ExsItem.ItemPrice * ExsItem.ItemCount;
            await context.SaveChangesAsync();
        }

        public async Task DelFromCart(string UserId, string ItemId)
        {
            ShoppingCartItem ExsItem = 
                await context.ShoppingCartItems.FindAsync(UserId, ItemId);
            context.ShoppingCartItems.Remove(ExsItem);
            await context.SaveChangesAsync();
        }

        public async void ClearCart(string UserId)
        {
            IEnumerable<ShoppingCartItem> items = context.ShoppingCartItems.Where(x => x.CustomerId == UserId);
            context.ShoppingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}