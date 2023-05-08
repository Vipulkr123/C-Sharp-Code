namespace Practical_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //! Inheritance 
            Team team = new("Vipul");
            string result = team.PrintInfo();
            Console.WriteLine(result);

            //! Polymorphism
            Bird myBird = new Bird();
            Bird myDuck = new Duck();
            myBird.Voice();
            myDuck.Voice();

            //! Abstraction
            //Laptop myLaptop = new Laptop();
            //myLaptop.GetSetBrand = "Acer";
            //myLaptop.GetSetModel = "Nitro 5";
            //myLaptop.LaptopDetails();
        }
    }
}