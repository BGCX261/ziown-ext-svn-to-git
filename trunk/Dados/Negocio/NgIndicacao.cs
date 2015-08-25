using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgIndicacao : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWIndicacao> Pesquisar(CWIndicacao _CWIndicacao)
        {
            return Pesquisar(_CWIndicacao, "");
        }

        public List<CWIndicacao> Pesquisar(CWIndicacao _CWIndicacao, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Indicacao ";

            if (_CWIndicacao.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWIndicacao.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWIndicacao.Nome))
            {
                sSqlCondicao += "and Nome like  '%" + _CWIndicacao.Nome + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWIndicacao> dtPesquisa = ExecutarQuery<CWIndicacao>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWIndicacao _CWIndicacao)
        {

            if (_CWIndicacao.Codigo > 0)
            {
                sSql = @" update Indicacao set 
                                Nome  = '" + _CWIndicacao.Nome + @"'
                            where 
                                Codigo = " + _CWIndicacao.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Indicacao
                                (Nome)
                            VALUES
                                ('" + _CWIndicacao.Nome + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Indicacao where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
