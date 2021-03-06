using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class TransmissionType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
