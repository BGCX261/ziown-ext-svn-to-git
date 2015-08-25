using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dados
{
    public class NgProposta : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWProposta> Pesquisar(CWProposta _CWProposta)
        {
            return Pesquisar(_CWProposta, "");
        }

        public List<CWProposta> Pesquisar(CWProposta _CWProposta, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Propostas ";

            if (_CWProposta.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWProposta.Codigo;
            }


            if (_CWProposta.CodigoCliente > 0)
            {
                sSqlCondicao += "and CodigoCliente = " + _CWProposta.CodigoCliente;
            }

            if (_CWProposta.Hospedagem > 0)
            {
                sSqlCondicao += "and Hospedagem = " + _CWProposta.Hospedagem;
            }

            if (_CWProposta.Data != DateTime.MinValue)
            {
                sSqlCondicao += "and Data = '" + _CWProposta.Data + "'";
            }

            if (!string.IsNullOrEmpty(_CWProposta.Arquivo))
            {
                sSqlCondicao += "and Arquivo like '%" + _CWProposta.Arquivo + "%'";
            }

            if (_CWProposta.DataCadastro != DateTime.MinValue)
            {
                sSqlCondicao += "and DataCadastro = '" + _CWProposta.DataCadastro + "'";
            }

            if (_CWProposta.NProposta > 0)
            {
                sSqlCondicao += "and NProposta = " + _CWProposta.NProposta;
            }

            if (_CWProposta.ValorProposta > 0)
            {
                sSqlCondicao += "and ValorProposta = " + _CWProposta.ValorProposta;
            }

            if (_CWProposta.ValorInstalacao > 0)
            {
                sSqlCondicao += "and ValorInstalacao = " + _CWProposta.ValorInstalacao;
            }

            if (_CWProposta.NMaquinas > 0)
            {
                sSqlCondicao += "and NMaquinas = " + _CWProposta.NMaquinas;
            }

            if (!string.IsNullOrEmpty(_CWProposta.Periodicidade))
            {
                sSqlCondicao += "and Periodicidade like '%" + _CWProposta.Periodicidade + "%'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWProposta> dtPesquisa = ExecutarQuery<CWProposta>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWProposta _CWProposta)
        {

            if (_CWProposta.Codigo > 0)
            {
                sSql = @" update Propostas set 
                                CodigoCliente = " + _CWProposta.CodigoCliente + @"
                                , Hospedagem = " + _CWProposta.Hospedagem + @"
                                , Data = '" + (_CWProposta.Data == DateTime.MinValue ? "" : _CWProposta.Data.ToString("yyyy") + "-" + _CWProposta.Data.ToString("MM") + "-" + _CWProposta.Data.ToString("dd")) + @"'
                                , Arquivo = '" + _CWProposta.Arquivo + @"'
                                , DataCadastro = '" + _CWProposta.DataCadastro + @"'
                                , NProposta = " + _CWProposta.NProposta + @"
                                , ValorProposta = " + _CWProposta.ValorProposta + @"
                                , ValorInstalacao = " + _CWProposta.ValorInstalacao + @"
                                , NMaquinas = " + _CWProposta.NMaquinas + @"'
                                , Periodicidade = '" + _CWProposta.Periodicidade + @"'
                            where 
                                Codigo = " + _CWProposta.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Propostas
                                (CodigoCliente
                                , Hospedagem
                                , Data
                                , Arquivo
                                , DataCadastro
                                , NProposta
                                , ValorProposta
                                , ValorInstalacao
                                , NMaquinas
                                , Periodicidade)
                            VALUES
                                ( " + _CWProposta.CodigoCliente + @"
                                , " + _CWProposta.Hospedagem + @"
                                , '" + (_CWProposta.Data == DateTime.MinValue ? "" : _CWProposta.Data.ToString("yyyy") + "-" + _CWProposta.Data.ToString("MM") + "-" + _CWProposta.Data.ToString("dd")) + @"'
                                , '" + _CWProposta.Arquivo + @"'
                                , '" + _CWProposta.DataCadastro + @"'
                                , " + _CWProposta.NProposta + @"
                                , " + _CWProposta.ValorProposta.ToString().Replace(',','.') + @"
                                , " + _CWProposta.ValorInstalacao.ToString().Replace(',', '.') + @"
                                , " + _CWProposta.NMaquinas + @"
                                , '" + _CWProposta.Periodicidade + @"')";

            }

            Executar(sSql);

            //sSql = @"select max(Codigo) as NumeroProposta from Propostas";

            //return ExecutarQuerySql(sSql).Tables[0].Rows[0]["NumeroProposta"].ToString();

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Propostas where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }

        public string ProximoCodigo(long __cliente, ref long CodigoSoma)
        {

            if (__cliente > 0)
            {
                sSql = @"SELECT COUNT(*) AS Total, MAX(NProposta) AS MaxProposta FROM Propostas WHERE CodigoCliente = " + __cliente;
            }

            DataSet ds = ExecutarQuerySql(sSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(ds.Tables[0].Rows[0]["Total"].ToString()) > 0)
                {
                    CodigoSoma = long.Parse(ds.Tables[0].Rows[0]["MaxProposta"].ToString());
                    CodigoSoma += 1;
                }
                else
                {
                    CodigoSoma = 1;
                }

                return __cliente + "-" + CodigoSoma;

            }
            else
                return __cliente + "-" + 1;

        }
    }
}
