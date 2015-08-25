using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgNivel : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWNivel> Pesquisar(CWNivel _CWNivel)
        {
            return Pesquisar(_CWNivel, "");
        }

        public List<CWNivel> Pesquisar(CWNivel _CWNivel, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Nivel ";

            if (_CWNivel.Codigo > 0)
            {
                sSqlCondicao += " and Codigo = " + _CWNivel.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWNivel.Nivel))
            {
                sSqlCondicao += " and Nivel like  '%" + _CWNivel.Nivel + "%'";
            }

            if (!string.IsNullOrEmpty(_CWNivel.Descricao))
            {
                sSqlCondicao += " and Descricao like  '%" + _CWNivel.Descricao + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(4);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWNivel> dtPesquisa = ExecutarQuery<CWNivel>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWNivel _CWNivel)
        {

            if (_CWNivel.Codigo > 0)
            {
                sSql = @" update Nivel set 
                                Nivel  = '" + _CWNivel.Nivel + @"'
                                , Descricao  = '" + _CWNivel.Descricao + @"'
                            where 
                                Codigo = " + _CWNivel.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Nivel
                                (Nivel
                                , Descricao)
                            VALUES
                                ('" + _CWNivel.Nivel + @"'
                                , '" + _CWNivel.Descricao + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Nivel where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
