using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }

    }
}
