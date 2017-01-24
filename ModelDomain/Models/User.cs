using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string SecondName { get; set; }

        public virtual string Password { get; set; }

        //public virtual ISet<OperationResult> OperationResults { get; set; }

    }
}
