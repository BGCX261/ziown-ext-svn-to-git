using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgCoordenador : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWCoordenador> Pesquisar(CWCoordenador _CWCoordenador)
        {
            return Pesquisar(_CWCoordenador, "");
        }

        public List<CWCoordenador> Pesquisar(CWCoordenador _CWCoordenador, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Coordenador ";

            if (_CWCoordenador.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWCoordenador.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWCoordenador.Nome))
            {
                sSqlCondicao += "and Nome like  '%" + _CWCoordenador.Nome + "%'";
            }

            if (!string.IsNullOrEmpty(_CWCoordenador.Email))
            {
                sSqlCondicao += "and Email like  '%" + _CWCoordenador.Email + "%'";
            }

            if (!string.IsNullOrEmpty(_CWCoordenador.Cargo))
            {
                sSqlCondicao += "and Cargo like  '%" + _CWCoordenador.Cargo + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWCoordenador> dtPesquisa = ExecutarQuery<CWCoordenador>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWCoordenador _CWCoordenador)
        {

            if (_CWCoordenador.Codigo > 0)
            {
                sSql = @" update Coordenador set 
                                Nome  = '" + _CWCoordenador.Nome + @"'
                                ,Cargo = '" + _CWCoordenador.Cargo + @"'
                                ,Email = '" + _CWCoordenador.Email + @"'
                            where 
                                Codigo = " + _CWCoordenador.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Coordenador
                                (Nome
                                ,Cargo
                                ,Email)
                            VALUES
                                ('" + _CWCoordenador.Nome + @"'
                                ,'" + _CWCoordenador.Cargo + @"'
                                ,'" + _CWCoordenador.Email + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Coordenador where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
