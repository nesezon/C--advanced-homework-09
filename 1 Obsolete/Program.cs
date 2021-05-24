using System;

namespace Obsolete {
  class Program {
    static void Main(string[] args) {
      var car1 = new Car("Nyx", "Subaru", "Black");
      var car2 = new Car("Casper", "Lexus", "White");
      var car3 = new Car("Stacy", "Mazda", "Orange");
      car1.getCarDetails();
      car2.getCarInfo();
      car3.CarInfo();
    }
  }

  public class Car {
    private static int _id = 1;
    public int Id { get; set; }
    public string PetName { get; set; }
    public string Make { get; set; }
    public string Color { get; set; }
    public Car(string n, string m, string c) {
      Id = _id;
      _id++;
      PetName = n;
      Make = m;
      Color = c;
    }
    public void getCarDetails() {
      Console.WriteLine($"Car {Id,-5} PetName: {PetName,-15} Make: {Make,-15} Color: {Color}");
    }
    [Obsolete("Вместо getCarInfo используйте getCarDetails")]
    public void getCarInfo() {
      Console.WriteLine($"PetName: {PetName}, Make: {Make}, Color: {Color}");
    }
    [Obsolete("Забудьте про него! Используйте getCarDetails!", true)]
    public void CarInfo() {
      Console.WriteLine($"My {PetName} is {Color}");
    }
  }
}
