using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyORM2UnitOfWorkRepositoryProject1
{
    public interface IUnitOfWork
    {
        void StartTransaction();
        void Commit();
    }
}
