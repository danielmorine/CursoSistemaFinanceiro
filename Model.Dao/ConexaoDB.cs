using System.Data.SqlClient;

namespace Model.Dao
{
    class ConexaoDB
    {

        //CRIANDO A CONEXAO COM O DB, INICIA NULL
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        //CRIAR CONSTRUTOR E CONFIGURAR STRING DE CONEXAO COM O BANCO
        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=DESKTOP-RNV9ESI; Initial Catalog=Financeiro; Integrated Security=True");
        }
        //SABER O ESTADO DA CONEXAO (INICIAR A CONEXAO E ENCERRAR A CONEXAO)   
        public static ConexaoDB saberEstado()
        {
            if (objConexaoDB == null)
            {
                //CHAMAR CONSTRUTOR PARA INICIAR A CONEXAO COM O BANCO DE DADOS
                objConexaoDB = new ConexaoDB();
            }
            //RETORNAR COM O OBJETO DA CONEXAO, NESSE CASO É O objConexaoDB
            return objConexaoDB;
        }

        //PEGAR CONEXAO
        public SqlConnection getCon()
        {
            return con;
        }

        //ENCERRAR CONEXAO COM O BANCO
        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
