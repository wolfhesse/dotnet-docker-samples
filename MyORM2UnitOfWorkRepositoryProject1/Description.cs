namespace MyORM2UnitOfWorkRepositoryProject1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Description")]
    public partial class Description
    {
        public int Id { get; set; }

        public string Desc { get; set; }
    }
}
