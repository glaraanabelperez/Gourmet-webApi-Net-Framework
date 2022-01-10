using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    interface IQuerie <T>
    {
        List<T> GetAllQuerie();

        T GetByIdQuerie(int id) ;

        void DeleteQuerie(int  id);

        void InsertQuerie (T entity);

        void UpdateQuerie(T entity);


    }
}
