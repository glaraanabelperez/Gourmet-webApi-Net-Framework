

using System;
using System.Collections.Generic;

namespace logic.validations
{
    public static class States
    {
        public static bool ValidateState(string stateInput)
        {
            List<string> states = new List<string>() { "activo", "suspendido", "borrado", "pendiente", "entregado", "cancelado" };

            return states.Contains(stateInput);
        }
    }
        
}


