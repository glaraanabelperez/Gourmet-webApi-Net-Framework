using System.Collections.Generic;

namespace Domain.States
{
    public static class States
    {
        public static string available="available";
        public static string deleted = "deleted";
        public static string pending = "pending";
        public static string delivered = "delivered";
        public static string cancel = "cancel";

        public static List<string> statesMenusMeals = new List<string>() { "available", "deleted" };
        public static List<string> statesOrders = new List<string>() { "pending", "delivered", "cancel" };
    }
}



