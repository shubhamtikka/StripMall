using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    interface ICartRepository
    {
        void addItem(Guid id);

        void removeItem(Guid id);

        void updateCart(Guid id);

        void ClearCart();

    }
}
