using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositorio
{
    public class acProduto
    {
        Conexao cn = new Conexao();

        public void cadastraProduto(Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirProduto(@nome, @qtd, @valor, @cod)", cn.abrirConexao());
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = prod.nomeProduto;
            cmd.Parameters.Add("@qtd", MySqlDbType.VarChar).Value = prod.qtdProduto;
            cmd.Parameters.Add("@valor", MySqlDbType.Float).Value = prod.valorProduto;
            cmd.Parameters.Add("@cod", MySqlDbType.Int32).Value = prod.codFornecedor;

            cmd.ExecuteNonQuery();
            cn.fecharConexao();

        }

        public List<Produto> consultaProduto()
        {
            List<Produto> produtos = new List<Produto>();
            MySqlCommand cmd = new MySqlCommand("select cod_prod, nome_prod, qtd_prod, valor_unitario, nome_fornecedor from Produto pd inner join Fornecedor fn on pd.cod_fornecedor = fn.cod_fornecedor;", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()){
                produtos.Add(
                   new Produto{
                       codProduto = Convert.ToInt32(dr["cod_prod"]),
                       nomeProduto = dr["nome_prod"].ToString(),
                       qtdProduto = Convert.ToInt32(dr["qtd_prod"]),
                       valorProduto = Math.Round(Convert.ToDouble(dr["valor_unitario"]), 2),
                       nomeFornecedor = dr["nome_fornecedor"].ToString(),
                   }
                );
            }
            cn.fecharConexao();
            return produtos;
        } 
        
        public List<Produto> consultaProdutoPorId(int id)
        {
            List<Produto> produtos = new List<Produto>();
            MySqlCommand cmd = new MySqlCommand("select cod_prod, nome_prod, qtd_prod, valor_unitario, nome_fornecedor from Produto pd inner join Fornecedor fn on pd.cod_fornecedor = fn.cod_fornecedor where cod_prod = @id;", cn.abrirConexao());
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()){
                produtos.Add(
                   new Produto{
                       codProduto = Convert.ToInt32(dr["cod_prod"]),
                       nomeProduto = dr["nome_prod"].ToString(),
                       qtdProduto = Convert.ToInt32(dr["qtd_prod"]),
                       valorProduto = Math.Round(Convert.ToDouble(dr["valor_unitario"]), 2),
                       nomeFornecedor = dr["nome_fornecedor"].ToString(),
                   }
                );
            }
            cn.fecharConexao();
            return produtos;
        }

        public void atualizaProduto(Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("call alterarProduto(@codProd, @nome, @qtd, @valor, @codForn);", cn.abrirConexao());
            cmd.Parameters.Add("@codProd", MySqlDbType.Int32).Value = prod.codProduto;
            cmd.Parameters.Add("@@nome", MySqlDbType.VarChar).Value = prod.nomeProduto;
            cmd.Parameters.Add("@qtd", MySqlDbType.Int32).Value = prod.qtdProduto;
            cmd.Parameters.Add("@valor", MySqlDbType.Float).Value = prod.valorProduto;
            cmd.Parameters.Add("@codForn", MySqlDbType.Int32).Value = prod.codFornecedor;

            cmd.ExecuteNonQuery();
            cn.fecharConexao();
        }

        public void excluiProduto(int IdProd)
        {
            MySqlCommand cmd = new MySqlCommand("call deletaProduto(@cod);", cn.abrirConexao());
            cmd.Parameters.AddWithValue("@cod", MySqlDbType.Int32).Value = IdProd;

            cmd.ExecuteNonQuery();
            cn.fecharConexao();
        }
    }
}