using Core.Entities;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }

    }
}
