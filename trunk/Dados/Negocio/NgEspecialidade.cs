using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgEspecialidade : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWEspecialidade> Pesquisar(CWEspecialidade _CWEspecialidade)
        {
            return Pesquisar(_CWEspecialidade, "");
        }

        public List<CWEspecialidade> Pesquisar(CWEspecialidade _CWEspecialidade, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Especialidade ";

            if (_CWEspecialidade.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWEspecialidade.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWEspecialidade.Nome))
            {
                sSqlCondicao += "and Nome like  '%" + _CWEspecialidade.Nome + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWEspecialidade> dtPesquisa = ExecutarQuery<CWEspecialidade>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWEspecialidade _CWEspecialidade)
        {

            if (_CWEspecialidade.Codigo > 0)
            {
                sSql = @" update Especialidade set 
                                Nome  = '" + _CWEspecialidade.Nome + @"'
                            where 
                                Codigo = " + _CWEspecialidade.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Especialidade
                                (Nome)
                            VALUES
                                ('" + _CWEspecialidade.Nome + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Especialidade where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
