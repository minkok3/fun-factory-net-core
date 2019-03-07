using System;
using System.ComponentModel;
using WebApp.Domain;

namespace WebApp.Extensions
{
    public static class ComponentExtensions
    {
        public static void AdjustStockQuantities(this Domain.Component product, int qty)
        {
            product.StockQty = product.StockQty - qty;
        }
    }
}
