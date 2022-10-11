using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repositories
{

    public class GenericRepositories<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();


        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TblAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TblDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public void TblUptade(T p)
        {
            db.SaveChanges();
        }
        public T getid(int id)
        {
            return db.Set<T>().Find(id);
        }

       public T Find(Expression <Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);      
        }

      

       
    }
}