﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    interface IABM <T>
    {
        List<T> GetAll();

        void Insert (T entity);

        void Delete(int id);
    }
}

