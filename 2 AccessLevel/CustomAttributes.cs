using System;

namespace AccessLevel {
  public enum AccessLevel { admin, manager, customer }
  public class AdministratorAttribute : Attribute {
    public const AccessLevel Access  = AccessLevel.admin;
  }
  public class ManagerAttribute : Attribute {
    public const AccessLevel Access  = AccessLevel.manager;
  }
  public class CustomerAttribute : Attribute {
    public const AccessLevel Access  = AccessLevel.customer;
  }
}
