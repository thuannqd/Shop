using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business
{
    public class ProductCategoriesBUS
    {
        public void Insert(ProductCategories obj)
        {
            new ProductCategories().Insert(obj);
        }
        public void Update(ProductCategories obj)
        {
            new ProductCategories().Update(obj);
        }
        public void Delete(int ID)
        {
            new ProductCategories().Delete(ID);
        }
        public ProductCategories GetByID(int ID)
        {
            return new ProductCategories().GetByID(ID);
        }
        public List<ProductCategories> GetAll()
        {
            return new ProductCategories().GetAll();
        }
    }
}
