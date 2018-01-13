using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Vendedor
    {
        private string idVendedor;
        private string nome;

        private string cpf;
        private string telefone;
        private int estado;

        public string IdVendedor { get => idVendedor; set => idVendedor = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public int Estado { get => estado; set => estado = value; }

        public Vendedor()
        {

        }
        public Vendedor(string idVendedor)
        {
            this.idVendedor = idVendedor;
        }

        public Vendedor(string idVendedor, string cpf, string telefone)
        {
            this.idVendedor = idVendedor;
            this.Cpf = cpf;
            this.Telefone = telefone;

        }
    }
}
