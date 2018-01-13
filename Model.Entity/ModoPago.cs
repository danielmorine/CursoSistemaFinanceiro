using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ModoPago
    {
        private Int32 numPago;
        private string nome;
        private string outros;
        private int estado;

        public int NumPago { get => numPago; set => numPago = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Outros { get => outros; set => outros = value; }
        public int Estado { get => estado; set => estado = value; }

        public ModoPago()
        {

        }
        public ModoPago(Int32 numPago, string nome, string outros)
        {
            this.NumPago = numPago;
            this.Nome = nome;
            this.Outros = outros;
        }

        public ModoPago(Int32 numPago)
        {
            this.NumPago = numPago;
        }
    }
}
