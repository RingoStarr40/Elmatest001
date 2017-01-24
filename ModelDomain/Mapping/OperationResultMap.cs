using FluentNHibernate.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain.Mapping
{
    public class OperationResultMap: ClassMap<OperationResult>
    {
        public OperationResultMap()
        {
            Id(x => x.Id);
            Map(x => x.ArgumentCount);
            Map(x => x.Arguments);
            Map(x => x.Result);
            Map(x => x.ExecTimeMs);
            References(x => x.Operation, "OperationID").Cascade.SaveUpdate().Not.LazyLoad();
            References(x => x.Author, "UserID").Cascade.SaveUpdate().Not.LazyLoad();
        }
            
    }
}