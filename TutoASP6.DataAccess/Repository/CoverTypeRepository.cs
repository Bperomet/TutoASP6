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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly AppDBContext _db;
        public CoverTypeRepository(AppDBContext db) : base(db)
        {
            _db = db;

        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(CoverType coverType)
        {
            _db.coverTypes.Update(coverType);
        }
    }
}
