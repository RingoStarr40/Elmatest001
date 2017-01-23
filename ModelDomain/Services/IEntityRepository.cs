using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IEntityRepository<T> where T : class //обобщающие функции
    {
        //создать результат операции
        T Create();
        T Load(int Id);
        bool Delete(int Id);
        void Update(OperationResult operResult);
        IEnumerable<OperationResult> GetAll();
    }
}
