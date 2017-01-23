using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{

    public class Operation
    {
        [Key]
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual ISet<OperationResult> OperationResults { get; set; } //интерфейс для абстракции наборов
    }


}