using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgValidadeProposta : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWValidadeProposta> Pesquisar(CWValidadeProposta _CWValidadeProposta)
        {
            return Pesquisar(_CWValidadeProposta, "");
        }

        public List<CWValidadeProposta> Pesquisar(CWValidadeProposta _CWValidadeProposta, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Validade_Proposta ";

            if (_CWValidadeProposta.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWValidadeProposta.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWValidadeProposta.Validade_Proposta))
            {
                sSqlCondicao += "and Validade_Proposta like  '%" + _CWValidadeProposta.Validade_Proposta + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWValidadeProposta> dtPesquisa = ExecutarQuery<CWValidadeProposta>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWValidadeProposta _CWValidadeProposta)
        {

            if (_CWValidadeProposta.Codigo > 0)
            {
                sSql = @" update Validade_Proposta set 
                                Validade_Proposta  = '" + _CWValidadeProposta.Validade_Proposta + @"'
                            where 
                                Codigo = " + _CWValidadeProposta.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Validade_Proposta
                                (Validade_Proposta)
                            VALUES
                                ('" + _CWValidadeProposta.Validade_Proposta + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Validade_Proposta where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
