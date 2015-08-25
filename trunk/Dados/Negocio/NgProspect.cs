using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dados
{
    public class NgProspect : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWProspect> Pesquisar(CWProspect _CWProspect)
        {
            return Pesquisar(_CWProspect, "");
        }

        public List<CWProspect> Pesquisar(CWProspect _CWProspect, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Prospect ";

            if (_CWProspect.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWProspect.Codigo;
            }


            if (!string.IsNullOrEmpty(_CWProspect.CNPJ))
            {
                sSqlCondicao += "and CNPJ like  '%" + _CWProspect.CNPJ + "%'";
            }

            if (_CWProspect.Data != DateTime.MinValue)
            {
                sSqlCondicao += "and Data = '" + _CWProspect.Data + "'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Nome))
            {
                sSqlCondicao += "and Nome like  '%" + _CWProspect.Nome + "%'";
            }

            if (_CWProspect.Gerente > 0)
            {
                sSqlCondicao += "and Gerente = " + _CWProspect.Gerente;
            }

            if (_CWProspect.Coordenador > 0)
            {
                sSqlCondicao += "and Coordenador = " + _CWProspect.Coordenador;
            }

            if (_CWProspect.Produto > 0)
            {
                sSqlCondicao += "and Produto = " + _CWProspect.Produto;
            }

            if (_CWProspect.ValorEve > 0)
            {
                sSqlCondicao += "and ValorEve = " + _CWProspect.ValorEve;
            }

            if (_CWProspect.Valor > 0)
            {
                sSqlCondicao += "and Valor = " + _CWProspect.Valor;
            }

            if (_CWProspect.Fechamento > 0)
            {
                sSqlCondicao += "and Fechamento = " + _CWProspect.Fechamento;
            }

            if (_CWProspect.Status > 0)
            {
                sSqlCondicao += "and Status = " + _CWProspect.Status;
            }

            if (!string.IsNullOrEmpty(_CWProspect.Dominio))
            {
                sSqlCondicao += "and Dominio like  '%" + _CWProspect.Dominio + "%'";
            }

            if (_CWProspect.DataCT != DateTime.MinValue)
            {
                sSqlCondicao += "and DataCT = '" + _CWProspect.DataCT + "'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.txt_contato))
            {
                sSqlCondicao += "and txt_contato like  '%" + _CWProspect.txt_contato + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.txt_fone))
            {
                sSqlCondicao += "and txt_fone like  '%" + _CWProspect.txt_fone + "%'";
            }

            if (_CWProspect.Periodo > 0)
            {
                sSqlCondicao += "and Periodo = " + _CWProspect.Periodo;
            }

            if (!string.IsNullOrEmpty(_CWProspect.email))
            {
                sSqlCondicao += "and email like  '%" + _CWProspect.email + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Cep))
            {
                sSqlCondicao += "and Cep like  '%" + _CWProspect.Cep + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Endereco))
            {
                sSqlCondicao += "and Endereco like  '%" + _CWProspect.Endereco + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Numero))
            {
                sSqlCondicao += "and Numero like  '%" + _CWProspect.Numero + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Complemento))
            {
                sSqlCondicao += "and Complemento like  '%" + _CWProspect.Complemento + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Bairro))
            {
                sSqlCondicao += "and Bairro like  '%" + _CWProspect.Bairro + "%'";
            }

            if (!string.IsNullOrEmpty(_CWProspect.Cidade))
            {
                sSqlCondicao += "and Cidade like  '%" + _CWProspect.Cidade + "%'";
            }

            if (_CWProspect.Estado > 0)
            {
                sSqlCondicao += "and Estado = " + _CWProspect.Estado;
            }

            if (_CWProspect.Form)
            {
                sSqlCondicao += "and Form = 1";
            }

            if (_CWProspect.Indicacao > 0)
            {
                sSqlCondicao += "and Indicacao = " + _CWProspect.Indicacao;
            }

            if (!string.IsNullOrEmpty(_CWProspect.Cargo))
            {
                sSqlCondicao += "and Cargo like  '%" + _CWProspect.Cargo + "%'";
            }

            if (_CWProspect.N_Maquinas > 0)
            {
                sSqlCondicao += "and N_Maquinas = " + _CWProspect.N_Maquinas;
            }

            if (_CWProspect.AV_Anterior > 0)
            {
                sSqlCondicao += "and AV_Anterior = " + _CWProspect.AV_Anterior;
            }

            if (_CWProspect.Vencimento_AV != DateTime.MinValue)
            {
                sSqlCondicao += "and Vencimento_AV = '" + _CWProspect.Vencimento_AV + "'";
            }

            if (_CWProspect.Cliente_Top > 0)
            {
                sSqlCondicao += "and Cliente_Top = " + _CWProspect.Cliente_Top;
            }


            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            if (!string.IsNullOrEmpty(_Order))
                sSql += " order by " + _Order;

            List<CWProspect> dtPesquisa = ExecutarQuery<CWProspect>(sSql);

            return dtPesquisa;
        }
        #endregion

        #region Salvar
        public long Salvar(CWProspect _CWProspect)
        {

            if (_CWProspect.Codigo > 0)
            {
                sSql = @" update Prospect set 
                                CNPJ = '" + _CWProspect.CNPJ + @"'
                                , Data = '" + (_CWProspect.Data == DateTime.MinValue ? "" : _CWProspect.Data.ToString("yyyy") + "-" + _CWProspect.Data.ToString("MM") + "-" + _CWProspect.Data.ToString("dd") + " " + _CWProspect.Data.ToString("hh") + ":" + _CWProspect.Data.ToString("mm") + ":" + _CWProspect.Data.ToString("ss")) + @"'
                                , Nome = '" + _CWProspect.Nome + @"'
                                , Gerente = " + _CWProspect.Gerente + @"
                                , Coordenador = " + _CWProspect.Coordenador + @"
                                , Produto = " + _CWProspect.Produto + @"
                                , ValorEve = " + _CWProspect.ValorEve.ToString().Replace(',', '.') + @"
                                , Valor = " + _CWProspect.Valor.ToString().Replace(',', '.') + @"
                                , Fechamento = " + _CWProspect.Fechamento + @"
                                , Status = " + _CWProspect.Status + @"
                                , Dominio = '" + _CWProspect.Dominio + @"'
                                , DataCT = '" + (_CWProspect.DataCT == DateTime.MinValue ? "" : _CWProspect.DataCT.ToString("yyyy") + "-" + _CWProspect.DataCT.ToString("MM") + "-" + _CWProspect.DataCT.ToString("dd")) + @"'
                                , txt_contato = '" + _CWProspect.txt_contato + @"'
                                , txt_fone = '" + _CWProspect.txt_fone + @"'
                                , Periodo = " + _CWProspect.Periodo + @"
                                , email = '" + _CWProspect.email + @"'
                                , Cep = '" + _CWProspect.Cep + @"'
                                , Endereco = '" + _CWProspect.Endereco + @"'
                                , Numero = '" + _CWProspect.Numero + @"'
                                , Complemento = '" + _CWProspect.Complemento + @"'
                                , Bairro = '" + _CWProspect.Bairro + @"'
                                , Cidade = '" + _CWProspect.Cidade + @"'
                                , Estado = " + _CWProspect.Estado + @"
                                , Form = " + (_CWProspect.Form == true ? "1" : "0") + @"
                                , Indicacao = " + _CWProspect.Indicacao + @"
                                , Cargo = '" + _CWProspect.Cargo + @"'
                                , N_Maquinas = " + _CWProspect.N_Maquinas + @"
                                , AV_Anterior = " + _CWProspect.AV_Anterior + @"
                                , Vencimento_AV = '" + (_CWProspect.Vencimento_AV == DateTime.MinValue ? "" : _CWProspect.Vencimento_AV.ToString("yyyy") + "-" + _CWProspect.Vencimento_AV.ToString("MM") + "-" + _CWProspect.Vencimento_AV.ToString("dd")) + @"'
                                , Cliente_Top = " + _CWProspect.Cliente_Top + @"
                            where 
                                Codigo = " + _CWProspect.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Prospect
                                (CNPJ
                                , Data
                                , Nome
                                , Gerente
                                , Coordenador
                                , Produto
                                , ValorEve
                                , Valor
                                , Fechamento
                                , Status
                                , Dominio
                                , DataCT
                                , txt_contato
                                , txt_fone
                                , Periodo
                                , email
                                , Cep
                                , Endereco
                                , Numero
                                , Complemento
                                , Bairro
                                , Cidade
                                , Estado
                                , Form
                                , Indicacao
                                , Cargo
                                , N_Maquinas
                                , AV_Anterior
                                , Vencimento_AV
                                , Cliente_Top)
                            VALUES
                               ('" + _CWProspect.CNPJ + @"'
                                , '" + (_CWProspect.Data == DateTime.MinValue ? "" : _CWProspect.Data.ToString("yyyy") + "-" + _CWProspect.Data.ToString("MM") + "-" + _CWProspect.Data.ToString("dd") + " " + _CWProspect.Data.ToString("hh") + ":" + _CWProspect.Data.ToString("mm") + ":" + _CWProspect.Data.ToString("ss")) + @"'
                                , '" + _CWProspect.Nome + @"'
                                , " + _CWProspect.Gerente + @"
                                , " + _CWProspect.Coordenador + @"
                                , " + _CWProspect.Produto + @"
                                , " + _CWProspect.ValorEve.ToString().Replace(',', '.') + @"
                                , " + _CWProspect.Valor.ToString().Replace(',', '.') + @"
                                , " + _CWProspect.Fechamento + @"
                                , " + _CWProspect.Status + @"
                                , '" + _CWProspect.Dominio + @"'
                                , '" + (_CWProspect.DataCT == DateTime.MinValue ? "" : _CWProspect.DataCT.ToString("yyyy") + "-" + _CWProspect.DataCT.ToString("MM") + "-" + _CWProspect.DataCT.ToString("dd")) + @"'
                                , '" + _CWProspect.txt_contato + @"'
                                , '" + _CWProspect.txt_fone + @"'
                                , " + _CWProspect.Periodo + @"
                                , '" + _CWProspect.email + @"'
                                , '" + _CWProspect.Cep + @"'
                                , '" + _CWProspect.Endereco + @"'
                                , '" + _CWProspect.Numero + @"'
                                , '" + _CWProspect.Complemento + @"'
                                , '" + _CWProspect.Bairro + @"'
                                , '" + _CWProspect.Cidade + @"'
                                , " + _CWProspect.Estado + @"
                                , " + (_CWProspect.Form == true ? "1" : "0") + @"
                                , " + _CWProspect.Indicacao + @"
                                , '" + _CWProspect.Cargo + @"'
                                , " + _CWProspect.N_Maquinas + @"
                                , " + _CWProspect.AV_Anterior + @"
                                , '" + (_CWProspect.Vencimento_AV == DateTime.MinValue ? "" : _CWProspect.Vencimento_AV.ToString("yyyy") + "-" + _CWProspect.Vencimento_AV.ToString("MM") + "-" + _CWProspect.Vencimento_AV.ToString("dd")) + @"'
                                , " + _CWProspect.Cliente_Top + ")";

            }

            return Executar(sSql, "Prospect");

        }
        #endregion

        #region Excluir
        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Prospect where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }
        #endregion

        #region ConsultarCadastrosAtrasados
        public DataTable ConsultarCadastrosAtrasados()
        {


            sSql = @"select count(exp.codigo) as atrasados,exu.nome 
                    from Prospect exp,Usuarios exu 
                    where exp.Gerente = exu.Codigo 
                    AND (exp.DataCT < { fn NOW() }) 
                    AND (exp.Status = 1) 
                    AND (exu.Funil_Vendas = 1) Group By exu.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }

        public List<CWProspect> ConsultarCadastrosAtrasadosLista(long __UserId)
        {


            sSql = @"Select	Codigo, 
		                    Data, 
		                    Nome, 
		                    Gerente, 
		                    Fechamento, 
		                    Dominio, 
		                    Valor, 
		                    Produto, 
		                    Status, 
		                    DataCT 
                    from	[Prospect] 
                    Where	(DataCT < { fn NOW() }) 
                    AND		(Status = 1) ";


            if (__UserId > 0)
                sSql += " and Gerente = " + __UserId;

            sSql += "ORDER BY DataCT, Status, Fechamento, Gerente, Nome";

            List<CWProspect> dtPesquisa = ExecutarQuery<CWProspect>(sSql);

            return dtPesquisa;

        }
        #endregion

        #region ConsultarUltimosCadastrosExtranet
        public DataTable ConsultarUltimosCadastrosExtranet()
        {


            sSql = @"Select top (15) [Prospect].Codigo, 
				                     [Prospect].Data, 
				                     [Prospect].Nome, 
				                     [Usuarios].Nome AS Gerente 
                    from [Prospect] 
                    INNER JOIN [Usuarios] ON [Prospect].Gerente = [Usuarios].Codigo 
                    group by [Prospect].Codigo, 
		                     [Prospect].Nome, 
		                     [Usuarios].Nome, 
		                     [Prospect].Data 
                    Order by [Prospect].Codigo desc";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

    }
}
