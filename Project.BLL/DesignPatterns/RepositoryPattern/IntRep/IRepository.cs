using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Listeleme metotları

        List<T> GetAll();

        List<T> GetActives();

        List<T> GetModifieds();

        List<T> GetPassives();

        //Ekleme/Silme/Güncelleme/Yok etme

        void Add(T item);

        void Delete(T item);

        void Update(T item);

        void Destroy(T item);

        //Sorgulama

        //Where(12);
        //Where("hello");

        //db.Products.Where(x => x.ProductName=="Chai").ToList();

        List<T> Where(Expression<Func<T,bool>> exp);
        //Where( x => x.ProductName=="Chai")

        bool Any(Expression<Func<T,bool>> exp);

        object Select(Expression<Func<T, object>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        T Find(int id);
    }
    
}
