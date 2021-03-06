using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelId { get; set; }
        public int ColorId { get; set; }
        public int FuelTypeId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int BodyTypeId { get; set; }
        public int Km { get; set; }
        public short MotorPower { get; set; }
        public short ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
