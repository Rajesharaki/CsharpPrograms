using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.StockAccountManagement
{
    class Stock
    {
        public String StockName;
        public long NumberOfShare;
        public long SharePrice;
        public long TotalStockPrice;
        public override string ToString()
        {
            string st = $"StockName: {StockName}\nNumberOfShare: {NumberOfShare}\nSharePrice: {SharePrice}\nTotalStockPrice: {TotalStockPrice}";
            return st;
        }
    }
    class StockPortFoili
    {
        public List<Stock> Stocks;
        public long GrandTotalStockPrice;
    }
}
