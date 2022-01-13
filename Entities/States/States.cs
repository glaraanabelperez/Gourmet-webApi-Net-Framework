using System.Collections.Generic;

namespace Domain.States
{
    public static class States
    {
        public static List<string> statesMenusMeals = new List<string>() { "disponible", "no-disponible" };
        public static List<string> statesOrders = new List<string>() { "pendiente", "entregado", "cancelado" };
    }
}



