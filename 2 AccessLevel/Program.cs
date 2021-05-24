using System;
using System.Linq;

namespace AccessLevel {
  class Program {
    static void Main(string[] args) {
      var zones = new Zones();
      Console.WriteLine(zones.AccessToZoneA(new admin()));  // Access to Zone A for admin is Ok
      Console.WriteLine(zones.AccessToZoneA(new boss()));   // Access to Zone A for boss is Denied
      Console.WriteLine(zones.AccessToZoneA(new user()));   // Access to Zone A for user is Denied

      Console.WriteLine(zones.AccessToZoneB(new admin()));  // Access to Zone B for admin is Ok
      Console.WriteLine(zones.AccessToZoneB(new boss()));   // Access to Zone B for boss is Ok
      Console.WriteLine(zones.AccessToZoneB(new user()));   // Access to Zone B for user is Denied

      Console.WriteLine(zones.AccessToZoneC(new admin()));  // Access to Zone C for admin is Ok
      Console.WriteLine(zones.AccessToZoneC(new boss()));   // Access to Zone C for boss is Ok
      Console.WriteLine(zones.AccessToZoneC(new user()));   // Access to Zone C for user is Ok

      Console.ReadKey();
    }

    abstract class userBase { }

    [Administrator]
    class admin : userBase { }

    [Manager]
    class boss : userBase { }

    [Customer]
    class user : userBase { }

    class Zones {

      [Administrator]
      public string AccessToZoneA(userBase person) {
        return $"Access to Zone A for {person.GetType().Name} is {Authentification(person, "AccessToZoneA")}";
      }

      [Administrator]
      [Manager]
      public string AccessToZoneB(userBase person) {
        return $"Access to Zone B for {person.GetType().Name} is {Authentification(person, "AccessToZoneB")}";
      }

      [Administrator]
      [Manager]
      [Customer]
      public string AccessToZoneC(userBase person) {
        return $"Access to Zone C for {person.GetType().Name} is {Authentification(person, "AccessToZoneC")}";
      }

      string Authentification(userBase person, string method) {
        var methodAttributes = GetType().GetMethod(method).GetCustomAttributesData().Select(s => s.AttributeType.Name);
        var personAttributes = person.GetType().GetCustomAttributesData().Select(s => s.AttributeType.Name);
        var overlap = methodAttributes.Intersect(personAttributes).FirstOrDefault();
        return overlap == null ? "Denied" : "Ok";
      }
    }
  }
}
