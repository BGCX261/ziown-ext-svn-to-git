using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class Empresa : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWEmpresa> Pesquisar(CWEmpresa _CWEmpresa)
        {
            return Pesquisar(_CWEmpresa, "");
        }

        public List<CWEmpresa> Pesquisar(CWEmpresa _CWEmpresa, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from EMPRESA ";

            if (_CWEmpresa.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWEmpresa.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWEmpresa.RazaoSocial))
            {
                sSqlCondicao += "and Nome like  '%" + _CWEmpresa.RazaoSocial + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWEmpresa> dtPesquisa = ExecutarQuery<CWEmpresa>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWEmpresa _CWEmpresa)
        {

            if (_CWEmpresa.Codigo > 0)
            {
                sSql = @" update EMPRESA set 
                                Nome  = '" + _CWEmpresa.RazaoSocial + @"'
                            where 
                                Codigo = " + _CWEmpresa.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO EMPRESA
                                (Nome)
                            VALUES
                                ('" + _CWEmpresa.RazaoSocial + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from EMPRESA where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
