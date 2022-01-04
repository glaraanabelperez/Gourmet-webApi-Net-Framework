using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    interface IABM <T>
    {
        List<T> GetAll();

        T GetById(int id) ;

        void Delete(int  id);

        void Insert (T entity);

        void Update(T entity);
    }
}
