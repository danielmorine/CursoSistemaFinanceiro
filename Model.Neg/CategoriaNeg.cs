using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class CategoriaNeg
    {
        private CategoriaDao objCategoriaDao;

        public CategoriaNeg()
        {
            objCategoriaDao = new Dao.CategoriaDao();
            
        }
        public void create(Categoria objCategoria)
        {
            bool verificacao = true;

            string codigo = objCategoria.IdCategoria;
            if (codigo==null)
            {
                objCategoria.Estado = 10;
                return;
            }
            else
            {
                codigo = objCategoria.IdCategoria.Trim();
                verificacao = codigo.Length > 0 && codigo.Length <= 5;
                if(!verificacao)
                {
                    objCategoria.Estado = 1;
                    return;
                }
            }

            string nome = objCategoria.Nome;
            if(nome==null)
            {
                objCategoria.Estado = 20;
                return;
            }
            else
            {
                nome = objCategoria.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if(!verificacao)
                {
                    objCategoria.Estado = 2;
                    return;
                }
            }

            string descricao = objCategoria.Descricao;
            if(descricao == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descricao = objCategoria.Descricao.Trim();
                verificacao = descricao.Length > 0 && descricao.Length <= 50;
                if(!verificacao)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }

            Categoria objCategoriaAux = new Categoria();
            objCategoriaAux.IdCategoria = objCategoria.IdCategoria;
            verificacao = !objCategoriaDao.find(objCategoriaAux);
            if(!verificacao)
            {
                objCategoria.Estado = 4;
                return;
            }
            //se tudo estiver ok, será salvo
            objCategoria.Estado = 99;
            objCategoriaDao.create(objCategoria);
            return;
        }

        public void update(Categoria objCategoria)
        {
            bool verificacao = true;

            string nome = objCategoria.Nome;
            if (nome == null)
            {
                objCategoria.Estado = 20;
                return;
            }
            else
            {
                nome = objCategoria.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objCategoria.Estado = 2;
                    return;
                }
            }

            string descricao = objCategoria.Descricao;
            if(descricao == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descricao = objCategoria.Descricao.Trim();
                verificacao = descricao.Length > 0 && descricao.Length <= 50;
                if(!verificacao)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }

            //se estiver ok, será atualizado
            objCategoria.Estado = 99;
            objCategoriaDao.update(objCategoria);
            return;
        }

        public void delete(Categoria objCategoria)
        {
            bool verificacao = true;

            Categoria objCategoriaAux = new Categoria();
            objCategoriaAux.IdCategoria = objCategoria.IdCategoria;
            if(!verificacao)
            {
                objCategoria.Estado = 3;
                return;
            }
            //verifica depois se tem produto associado
            //Produto objProduto = new Produto();
             // objProduto.Categoria = objCategoria.IdCategoria;
              //verificacao = !objProdutoDao.findProdutoPorCategoriaId(objProduto);
              //if(!verificacao)
              //{
               //    objCategoria.Estado = 34;
                //   return;
              //}
              
            //  se estiver ok, será deletado
              objCategoria.Estado = 99;
              objCategoriaDao.delete(objCategoria);
              return;
            
        }

        public bool find(Categoria objCategoria)
        {
            return objCategoriaDao.find(objCategoria);
        }
        public List<Categoria> findAll()
        {
            return objCategoriaDao.findAll();
        }

    }
}
