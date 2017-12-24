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
            string find = "select * from cliente where idCliente = '"+ objCliente.IdCliente +"'";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
        }

        public List<Cliente> findAll()
        {
            throw new System.NotImplementedException();
        }

        public void update(Cliente obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
