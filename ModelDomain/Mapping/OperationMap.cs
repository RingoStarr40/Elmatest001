using FluentNHibernate.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain.Mapping
{
    public class OperationMap : ClassMap<Operation>
    {
        public OperationMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
        }

    }
}
