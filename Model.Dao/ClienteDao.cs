using Model.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace Model.Dao
{

    //A Classe ClienteDao vai herdar da classe Obrigatorio
    //Necessario criar referencia

    /*Passar no parametro (Obrigatorio<>) a classe que estaremos recebendo as informações
        Nesse caso a classe Cliente que pertence a Model.Entity
        Basicamente a Classe cliente receberá todos os parametros da classe Obrigatorio:
            Create, Delete, Update, Find e FindAll.
        Por fim, implemente o obrigatorio
     */
    
    public class ClienteDao : Obrigatorio<Cliente>
    {

        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        //Construtor da classe
        public ClienteDao()
        {
            //Passar a conexão do banco de dados para o objConexaoDB
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Cliente objCliente)
        {
            string create = "insert into cliente(nome, endereco, telefone, cpf) VALUES ('"+ objCliente.Nome + "','" + objCliente.Endereco + "','" + objCliente.Endereco + "','" + objCliente.Telefone + "', '" + objCliente.Cpf + "')";
            try
            {// Passar para o camando a sqlComand com o create, o objeto de conexao
             //e no objeto de conexao, mandar pegar a conexao com o getCon
             //Abrir a conexão com o Open.

                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objCliente.Estado = 1;
            }
            finally
            {//Encerrar conexao com o banco de dados
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

        }

        public void delete(Cliente objCliente)
        {
            string delete = "delete from cliente where idCliente = ' "+ objCliente.IdCliente + " '";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select * from cliente where idCliente = '" + objCliente.IdCliente + "'";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                //temRegistros vai ler os dados
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                } else {
                    objCliente.Estado = 1;
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

        public bool findClientePorCpf(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select * from cliente where cpf = '" + objCliente.Cpf + "'";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                //temRegistros vai ler os dados
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Estado = 99;
                }
                else
                {
                    objCliente.Estado = 1;
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


        public List<Cliente> findAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "  select * from cliente order by name asc ";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                //While vai percorrer e listar todos registros   
                while(reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
    //Apos recuperar todo os registros, inserimos o nosso objeto dentro uma listaAdd
    //e passamos o objeto dentro do parametro.
                    listaClientes.Add(objCliente);
                }
                return listaClientes;
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

        public List<Cliente> findAllCliente(Cliente objCLiente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select* from cliente where nome like '%" + objCLiente.Nome + "%' or cpf like '%" + objCLiente.Cpf + "%' or idCliente like '%" + objCLiente.IdCliente + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();

                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    listaClientes.Add(objCliente);

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

            return listaClientes;

        }

        public void update(Cliente objCliente)
        {
            string update = "update cliente set nome =' " +objCliente.Nome + "', endereco =' " + objCliente.Endereco + "', telefone =' " + objCliente.Telefone + "', cpf =' " + objCliente.Cpf + "', ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
