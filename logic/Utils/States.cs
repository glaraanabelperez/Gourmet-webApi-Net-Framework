using System.Collections.Generic;

namespace logic.Utils
{
    public static class  States
    {
        public static bool ValidateState( this string state)
        {
            List<string> states = new List<string>() { "activo", "suspendido", "borrado", "pendiente", "entregado", "cancelado" };
            return states.Contains(state);
        }
    }
}


