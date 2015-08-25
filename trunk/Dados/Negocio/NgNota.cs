using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgNota : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWNota> Pesquisar(CWNota _CWNota)
        {
            return Pesquisar(_CWNota, "");
        }

        public List<CWNota> Pesquisar(CWNota _CWNota, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Notas ";

            if (_CWNota.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWNota.Codigo;
            }

            if (_CWNota.CodigoCliente > 0)
            {
                sSqlCondicao += "and CodigoCliente = " + _CWNota.CodigoCliente;
            }

            if (_CWNota.Data != DateTime.MinValue)
            {
                sSqlCondicao += "and Data = '" + _CWNota.Data + "'";
            }

            if (!string.IsNullOrEmpty(_CWNota.Nota))
            {
                sSqlCondicao += "and Nota like  '%" + _CWNota.Nota + "%'";
            }
            
            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWNota> dtPesquisa = ExecutarQuery<CWNota>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWNota _CWNota)
        {

            if (_CWNota.Codigo > 0)
            {
                sSql = @" update Notas set 
                                CodigoCliente  = " + _CWNota.CodigoCliente + @"
                                , Data  = '" + (_CWNota.Data == DateTime.MinValue ? "" : _CWNota.Data.ToString("yyyy") + "-" + _CWNota.Data.ToString("MM") + "-" + _CWNota.Data.ToString("dd") + " " + _CWNota.Data.ToString("HH") + ":" + _CWNota.Data.ToString("mm") + ":" + _CWNota.Data.ToString("ss")) + @"'
                                , Nota  = '" + _CWNota.Nota + @"'
                            where 
                                Codigo = " + _CWNota.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Notas
                                (CodigoCliente
                                , Data
                                , Nota)
                            VALUES
                                (" + _CWNota.CodigoCliente + @"
                                , '" + (_CWNota.Data == DateTime.MinValue ? "" : _CWNota.Data.ToString("yyyy") + "-" + _CWNota.Data.ToString("MM") + "-" + _CWNota.Data.ToString("dd") + " " + _CWNota.Data.ToString("HH") + ":" + _CWNota.Data.ToString("mm") + ":" + _CWNota.Data.ToString("ss")) + @"'
                                , '" + _CWNota.Nota + @"')";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Notas where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
    }
}
