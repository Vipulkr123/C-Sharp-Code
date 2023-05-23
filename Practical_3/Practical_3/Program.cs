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
            Duck myDuck = (Duck)new Bird();
            myBird.Voice();
            myDuck.Voice(); 

            //! Abstraction
            Laptop myLaptop = new Laptop();
            myLaptop.GetSetBrand = "Acer";
            myLaptop.GetSetModel = "Nitro 5";
            myLaptop.LaptopDetails();
            // We can't Access Private Method in Other Classes
            myLaptop.MotherBoardInfo();
        }
    }
}