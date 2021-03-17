using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int Km { get; set; }
        public short MotorPower { get; set; }
        public short ModelYear { get; set; }
        public string FuelTypeName { get; set; }
        public string Description { get; set; }
        public string TransmissionTypeName { get; set; }
        public string BodyTypeName { get; set; }

    }
}
