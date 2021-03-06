﻿using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business
{
    public class ProductCategoriesBUS
    {
        public void Insert()
        {
            new ProductCategories().Insert();
        }
        public void Update()
        {
            new ProductCategories().Update();
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
        public List<ProductCategories> GetAllPaging(int page,int pageSize,out int TotalRow)
        {
            List<ProductCategories> lstCat = new ProductCategories().GetAll();
            TotalRow = lstCat.Count();
            return lstCat.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }
    }
}
