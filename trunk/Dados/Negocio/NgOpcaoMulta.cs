using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgOpcaoMulta : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWOpcaoMulta> Pesquisar(CWOpcaoMulta _CWOpcaoMulta)
        {
            return Pesquisar(_CWOpcaoMulta, "");
        }

        public List<CWOpcaoMulta> Pesquisar(CWOpcaoMulta _CWOpcaoMulta, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Opcoes_Multa ";

            if (_CWOpcaoMulta.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWOpcaoMulta.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWOpcaoMulta.Opcao_Multa))
            {
                sSqlCondicao += "and Opcao_Multa like  '%" + _CWOpcaoMulta.Opcao_Multa + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWOpcaoMulta> dtPesquisa = ExecutarQuery<CWOpcaoMulta>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWOpcaoMulta _CWOpcaoMulta)
        {

            if (_CWOpcaoMulta.Codigo > 0)
            {
                sSql = @" update Opcoes_Multa set 
                                Opcao_Multa  = '" + _CWOpcaoMulta.Opcao_Multa + @"'
                            where 
                                Codigo = " + _CWOpcaoMulta.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Opcoes_Multa
                                (Opcao_Multa)
                            VALUES
                                ('" + _CWOpcaoMulta.Opcao_Multa + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Opcoes_Multa where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
