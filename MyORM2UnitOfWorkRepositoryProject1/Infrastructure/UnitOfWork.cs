using MyORM2UnitOfWorkRepositoryProject1.Models;
using MyORM2UnitOfWorkRepositoryProject1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM2UnitOfWorkRepositoryProject1.Infrastructure
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private Model _context = null;
        private DbContextTransaction _transaction = null;

        

        public UnitOfWork()
        {
            _context = new Model();
        }

        /// <summary>
        /// 開始交易
        /// </summary>
        public void StartTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
    
        /// <summary>
        /// 確認交易
        /// </summary>
        public void Commit()
        {
            if (_transaction == null)
                throw new NotBeginTranException("必須先呼叫 StartTransaction 方法。");

            
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}

