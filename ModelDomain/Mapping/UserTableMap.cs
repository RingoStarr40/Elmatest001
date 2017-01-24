using FluentNHibernate.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain.Mapping
{
    public class UserTableMap : ClassMap<UserTable>
    {
        public UserTableMap()
        {
            Id(x => x.Id);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.Name);
            Map(x => x.Surname);
        }

    }
}
