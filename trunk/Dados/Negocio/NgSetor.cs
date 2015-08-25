using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgSetor : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWSetor> Pesquisar(CWSetor _CWSetor)
        {
            return Pesquisar(_CWSetor, "");
        }

        public List<CWSetor> Pesquisar(CWSetor _CWSetor, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Setor ";

            if (_CWSetor.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWSetor.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWSetor.Setor))
            {
                sSqlCondicao += "and Setor like  '%" + _CWSetor.Setor + "%'";
            }

            if (!string.IsNullOrEmpty(_CWSetor.Descricao))
            {
                sSqlCondicao += "and Descricao like  '%" + _CWSetor.Descricao + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWSetor> dtPesquisa = ExecutarQuery<CWSetor>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWSetor _CWSetor)
        {

            if (_CWSetor.Codigo > 0)
            {
                sSql = @" update Setor set 
                                Setor  = '" + _CWSetor.Setor + @"'
                                ,Descricao  = '" + _CWSetor.Descricao + @"'
                            where 
                                Codigo = " + _CWSetor.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Setor
                                (Setor
                                ,Descricao)
                            VALUES
                                ('" + _CWSetor.Setor + @"'
                                ,'" + _CWSetor.Descricao + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Setor where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
