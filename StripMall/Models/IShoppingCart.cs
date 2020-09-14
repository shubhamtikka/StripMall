using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public interface IShoppingCart
    {
        Task AddToCartAsync(Items item, int Amount, ApplicationUser User);
        Task DecCount(string UserId, string ItemId);
        Task InCount(string UserId, string ItemId);
        Task DelFromCart(string UserId, string ItemId);
        IEnumerable<ShoppingCartItem> GetCart(string id);

        void ClearCart(string UserId);
    }
}
