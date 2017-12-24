using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    //A classe precisa ser publica para passar para outra Model.
    public class Cliente
    {
        //idCliente vai dar referencia ao idCliente do Banco

        private long idCliente;
        private string nome;
        private string cpf;
        private string endereco;
        private string telefone;
        private int estado;

        //METODOS GET E SET
        [Display(Name = "Código")]
        public long IdCliente { get => idCliente; set => idCliente = value; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get => nome; set => nome = value; }

        [Display(Name = "Endereço")]
        public string Endereco { get => endereco; set => endereco = value; }

        [Display(Name = "Telefone")]
        public string Telefone { get => telefone; set => telefone = value; }

        [Display(Name = "CPF")]
        public string Cpf { get => cpf; set => cpf = value; }
        public int Estado { get => Estado1; set => Estado1 = value; }


        //Instanciar Classe Cliente
        public Cliente()
        {

        }

       public Cliente(long idCliente)
        {
            this.idCliente = idCliente;
        }

        public Cliente(long idCliente, string nome, string cpf, string endereco, string telefone)
        {
            this.idCliente = idCliente;
            this.nome = nome;
            this.cpf = Cpf;
            this.endereco = endereco;
            this.telefone = telefone;
        }

    }
}
