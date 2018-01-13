using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Produto
    {
        private string idProduto;
        private string nome;
        private double precoUnitario;
        private string categoria;
        private int estado;

        public int Estado { get => estado; set => estado = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double PrecoUnitario { get => precoUnitario; set => precoUnitario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string IdProduto { get => idProduto; set => idProduto = value; }


        public Produto(string idProduto)
        {
            this.idProduto = idProduto;
        }

        public Produto(string idProduto, string nome, double precoUnitario, string cateogria)
        {
            this.idProduto = idProduto;
            this.Nome = nome;
            this.PrecoUnitario = precoUnitario;
            this.Categoria = categoria;
        }
    }
}
