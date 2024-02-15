using CursoWindowsFormsBiblioteca.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioDB
    {
        public string Tabela;
        public bool Status;
        public string Mensagem;
        public LocalDBClass Db;

        //construtor
        public FicharioDB(string tabela)
        {
            Status = true;
            try
            {
                Db = new LocalDBClass();
                Tabela = tabela;
                Mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com a tabela com erro: {ex.Message}";
            }
        }

        public void Incluir(string id, string jsonUnit)
        {
            Status = true;
            try
            {
                //INSERT INTO CLIENTE(ID, JSON) VALUES ('000001', '{...}')
                var sql = $"INSERT INTO {Tabela} (Id, Json) VALUES ('{id}', '{jsonUnit}')";
                Db.SQLCommand(sql);
                Status = true;
                Mensagem = "Inclusão efetuada com sucesso. Identificador: " + id;
                
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public string Buscar(string id)
        {
            Status = true;
            try
            {
                //SELECT ID, JSON FROM CLIENTE WHERE ID='000001'
                var sql = $"SELECT Id, Json FROM {Tabela} WHERE Id='{id}'";
                var dt = Db.SQLQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["Json"].ToString();
                    Status = true;
                    Mensagem = "Inclusão efetuada com sucesso. Identificador: " + id;
                    return conteudo;
                } 
                else
                {
                    Status = false;
                    Mensagem = $"Código de cliente {id} não existe";
                }

                
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            Status = true;
            List<string> List = new List<string>();
            try
            {
                //SELECT ID, JSON FROM CLIENTE
                var sql = $"SELECT Id, Json FROM {Tabela}";
                var dt = Db.SQLQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["Json"].ToString();
                        List.Add(conteudo);
                    }
                    return List;
                }
                else
                {
                    Status = false;
                    Mensagem = $"Não existem clientes na base de dados";
                }

             
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        public void Apagar(string id)
        {
            Status = true;
            try
            {
                var sql = $"SELECT Id, Json FROM {Tabela} WHERE Id='{id}'";
                var dt = Db.SQLQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    //DELETE FROM CLIENTE WHERE ID = '00010'
                    sql = $"DELETE FROM {Tabela} WHERE Id='{id}'";
                    Db.SQLCommand(sql);
                    Status = true;
                    Mensagem = "Deleção efetuada com sucesso. Identificador deletado: " + id;
                }
                else
                {
                    Status = false;
                    Mensagem = $"Código de cliente {id} não existe";
                }

           }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string id, string jsonUnit)
        {
            Status = true;
            try
            {

                var sql = $"SELECT Id, Json FROM {Tabela} WHERE Id='{id}'";
                var dt = Db.SQLQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    //UPDATE CLIENTE SET JSON = '{...}' WHERE ID = '00010'
                    sql = $"UPDATE {Tabela} SET JSON='{jsonUnit}' WHERE Id='{id}'";
                    Db.SQLCommand(sql);
                    Status = true;
                    Mensagem = "Alteração efetuada com sucesso. Identificador: " + id;
                }
                else
                {
                    Status = false;
                    Mensagem = "Alteração não permitida porque o identificador não existe: " + id;
                }

            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

    }
}
