using System.Collections.Generic;

namespace PedidoCompra.Domain
{
    public class Resultado
    {
        public static Resultado Ok = new Resultado();
        public bool HasValidation => _validations.Count > 0;
        private List<string> _validations = new List<string>();
        public IList<string> Validations => _validations;

        public void AddValidation(string validation)
            => _validations.Add(validation);
    }
}
