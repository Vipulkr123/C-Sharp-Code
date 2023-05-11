
namespace Practical_3
{
    internal class Laptop
    {
        private string _brand = string.Empty;
        private string _model = string.Empty;
        public string GetSetBrand { get => _brand; set => _brand = value; }
        public string GetSetModel { get => _model; set => _model = value; }

        public void LaptopDetails()
        {
            Console.WriteLine("Brand: " + _brand);
            Console.WriteLine("Model: " + _model);
        }

        private void MotherBoardInfo()
        {
            Console.WriteLine("MotherBoard Information");
        }
    }
}
