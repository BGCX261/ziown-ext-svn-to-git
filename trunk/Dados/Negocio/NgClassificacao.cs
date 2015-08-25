using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgClassificacao : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWClassificacao> Pesquisar(CWClassificacao _CWClassificacao)
        {
            return Pesquisar(_CWClassificacao, "");
        }

        public List<CWClassificacao> Pesquisar(CWClassificacao _CWClassificacao, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Classificacao ";

            if (_CWClassificacao.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWClassificacao.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWClassificacao.Classificacao))
            {
                sSqlCondicao += "and Classificacao like  '%" + _CWClassificacao.Classificacao + "%'";
            }

            if (!string.IsNullOrEmpty(_CWClassificacao.TempoContato))
            {
                sSqlCondicao += "and TempoContato like  '%" + _CWClassificacao.TempoContato + "%'";
            }

            if (!string.IsNullOrEmpty(_CWClassificacao.TempoVisita))
            {
                sSqlCondicao += "and TempoVisita like  '%" + _CWClassificacao.TempoVisita + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWClassificacao> dtPesquisa = ExecutarQuery<CWClassificacao>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWClassificacao _CWClassificacao)
        {

            if (_CWClassificacao.Codigo > 0)
            {
                sSql = @" update Classificacao set 
                                Classificacao  = '" + _CWClassificacao.Classificacao + @"'
                                , TempoContato  = '" + _CWClassificacao.TempoContato + @"'
                                , TempoVisita  = '" + _CWClassificacao.TempoVisita + @"'
                            where 
                                Codigo = " + _CWClassificacao.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Classificacao
                                (Classificacao
                                , TempoContato
                                , TempoVisita)
                            VALUES
                                ('" + _CWClassificacao.Classificacao + @"'
                                , '" + _CWClassificacao.TempoContato + @"'
                                , '" + _CWClassificacao.TempoVisita + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Classificacao where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
