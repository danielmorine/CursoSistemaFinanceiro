using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class VendedorDao : Obrigatorio<Vendedor>
    {

        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;


        public VendedorDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        
        public void create(Vendedor objVendedor)
        {
            string create = "insert into vendedor values('" + objVendedor.IdVendedor + "','" + objVendedor.Nome + "', '" + objVendedor.Cpf + "','" + objVendedor.Telefone + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Vendedor objVendedor)
        {
            try
            {
                string delete = "delete from vendedor whre idVendedor='" + objVendedor.IdVendedor + "'";
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

        }

        public bool find(Vendedor objVendedor)
        {
            bool temRegistros;
            string find = "select*from vendedor where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                    if(temRegistros)
                {
                    objVendedor.Nome = reader[1].ToString();
                    objVendedor.Cpf = reader[2].ToString();
                    objVendedor.Telefone = reader[3].ToString();
                    objVendedor.Estado = 99;
                }
                else
                {
                    objVendedor.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return temRegistros;

        }

        public List<Vendedor> findAll()
        {
            List<Vendedor> listaVendedores = new List<Vendedor>();
            string find = "select*from vendedor order by name asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while(reader.Read())
                {
                    Vendedor objVendedor = new Vendedor();
                    objVendedor.IdVendedor = reader[0].ToString();
                    objVendedor.Nome = reader[1].ToString();
                    objVendedor.Cpf = reader[2].ToString();
                    objVendedor.Telefone = reader[3].ToString();
                    listaVendedores.Add(objVendedor);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return listaVendedores;
        }

        public void update(Vendedor objVendedor)
        {
            string update = "update vendedor set nome='" + objVendedor.IdVendedor +"',cpf='" + objVendedor.Cpf + "',telefone='" + objVendedor.Telefone + "' where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            objConexaoDB.getCon().Close();
            objConexaoDB.CloseDB();

        }
    }
}
