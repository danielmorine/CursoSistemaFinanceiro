using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Categoria
    {
        private string idCategoria;
        private string nome;
        private string descricao;
        private string estado;

        public string IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Estado { get => estado; set => estado = value; }

        public Categoria()
        {

        }
        public Categoria(string idCategoria, string nome, string descricao)
        {
            this.idCategoria = idCategoria;
            this.Nome = nome;
            this.Descricao = descricao;
        }
        public Categoria(string idCategoria)
        {
            this.idCategoria = idCategoria;
        }
    }
}
