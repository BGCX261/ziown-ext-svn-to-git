using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgOpcaoPagamento : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWOpcaoPagamento> Pesquisar(CWOpcaoPagamento _CWOpcaoPagamento)
        {
            return Pesquisar(_CWOpcaoPagamento, "");
        }

        public List<CWOpcaoPagamento> Pesquisar(CWOpcaoPagamento _CWOpcaoPagamento, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Opcoes_Pagamento ";

            if (_CWOpcaoPagamento.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWOpcaoPagamento.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWOpcaoPagamento.Opcao_Pagamento))
            {
                sSqlCondicao += "and Opcao_Pagamento like  '%" + _CWOpcaoPagamento.Opcao_Pagamento + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWOpcaoPagamento> dtPesquisa = ExecutarQuery<CWOpcaoPagamento>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWOpcaoPagamento _CWOpcaoPagamento)
        {

            if (_CWOpcaoPagamento.Codigo > 0)
            {
                sSql = @" update Opcoes_Pagamento set 
                                Opcao_Pagamento  = '" + _CWOpcaoPagamento.Opcao_Pagamento + @"'
                            where 
                                Codigo = " + _CWOpcaoPagamento.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Opcoes_Pagamento
                                (Opcao_Pagamento)
                            VALUES
                                ('" + _CWOpcaoPagamento.Opcao_Pagamento + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Opcoes_Pagamento where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
