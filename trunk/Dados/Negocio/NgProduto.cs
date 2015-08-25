using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgProduto : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWProduto> Pesquisar(CWProduto _CWProduto)
        {
            return Pesquisar(_CWProduto, "");
        }

        public List<CWProduto> Pesquisar(CWProduto _CWProduto, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Produtos ";

            if (_CWProduto.Codigo > 0)
            {
                sSqlCondicao += " and Codigo = " + _CWProduto.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWProduto.Produto))
            {
                sSqlCondicao += " and Produto like  '%" + _CWProduto.Produto + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProduto.Descritivo))
            {
                sSqlCondicao += " and Descritivo like  '%" + _CWProduto.Descritivo + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(4);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWProduto> dtPesquisa = ExecutarQuery<CWProduto>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWProduto _CWProduto)
        {

            if (_CWProduto.Codigo > 0)
            {
                sSql = @" update Produtos set 
                                Produto  = '" + _CWProduto.Produto + @"'
                                ,Descritivo = '" + _CWProduto.Descritivo + @"'
                            where 
                                Codigo = " + _CWProduto.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Produtos
                                (Produto
                                ,Descritivo)
                            VALUES
                                ('" + _CWProduto.Produto + @"'
                                ,'" + _CWProduto.Descritivo + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Produtos where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
