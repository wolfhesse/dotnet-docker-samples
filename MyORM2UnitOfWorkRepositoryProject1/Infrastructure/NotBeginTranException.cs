using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM2UnitOfWorkRepositoryProject1.Infrastructure
{
    /// <summary>
    /// 交易失敗相關 Exception.
    /// </summary>
    public class NotBeginTranException : Exception
    {
        public NotBeginTranException(string Message) : base(Message) { }
    }
}
