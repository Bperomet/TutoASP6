using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoASP6.DataAccess.Data;
using TutoASP6.DataAccess.Repository.IRepository;
using TutoASP6.Models;

namespace TutoASP6.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        //add-migration addProduct
        //update-database
        private readonly AppDBContext _db;
        public ProductRepository(AppDBContext db) : base(db)
        {
            _db = db;

        }
        public void Update(Product obj)
        {
            var objFromDb = _db.products.FirstOrDefault(x =>x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price50 = obj.Price50;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;

                if (objFromDb.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }

            }
        }
    }
}
