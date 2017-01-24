using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{

    public class UserTable
    {
        [Key]
        public virtual int Id { get; set; }

        [MaxLength(50)]
        public virtual string Login { get; set; }

        [MaxLength(50)]
        public virtual string Password { get; set; }

        [MaxLength(50)]
        public virtual string Name{ get; set; }

        [MaxLength(50)]
        public virtual string Surname { get; set; }


        public virtual string FullName
        {
            get { return $"{Surname} {Name}"; }
        }

       // public virtual ISet<OperationResult> OperationResults { get; set; } //интерфейс для абстракции наборов
    }


}