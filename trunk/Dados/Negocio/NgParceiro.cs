using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class NgParceiro : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region Pesquisar
        public List<CWParceiro> Pesquisar(CWParceiro _CWParceiro)
        {
            return Pesquisar(_CWParceiro, "");
        }

        public List<CWParceiro> Pesquisar(CWParceiro _CWParceiro, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from Parceiros";

            if (_CWParceiro.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWParceiro.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWParceiro.Nome))
            {
                sSqlCondicao += "and Nome like '%" + _CWParceiro.Nome + "%'";
            }

            if (!string.IsNullOrEmpty(_CWParceiro.Fantasia))
            {
                sSqlCondicao += "and Fantasia like '%" + _CWParceiro.Fantasia + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.CNPJ))
            {
                sSqlCondicao += "and CNPJ like '%" + _CWParceiro.CNPJ + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Contato))
            {
                sSqlCondicao += "and Contato like '%" + _CWParceiro.Contato + "%'";
            }


            if (_CWParceiro.DataNC != DateTime.MinValue)
            {
                sSqlCondicao += "and DataNC = '" + _CWParceiro.DataNC + "'";
            }

            if (!string.IsNullOrEmpty(_CWParceiro.CargoC))
            {
                sSqlCondicao += "and CargoC like '%" + _CWParceiro.CargoC + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.CelularC))
            {
                sSqlCondicao += "and CelularC like '%" + _CWParceiro.CelularC + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.EmailC))
            {
                sSqlCondicao += "and EmailC like '%" + _CWParceiro.EmailC + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.ContatoTec))
            {
                sSqlCondicao += "and ContatoTec like '%" + _CWParceiro.ContatoTec + "%'";
            }


            if (_CWParceiro.DataNCT != DateTime.MinValue)
            {
                sSqlCondicao += "and DataNCT = '" + _CWParceiro.DataNCT + "'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.CargoCT))
            {
                sSqlCondicao += "and CargoCT like '%" + _CWParceiro.CargoCT + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.CelularCT))
            {
                sSqlCondicao += "and CelularCT like '%" + _CWParceiro.CelularCT + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.EmailCT))
            {
                sSqlCondicao += "and EmailCT like '%" + _CWParceiro.EmailCT + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Fone))
            {
                sSqlCondicao += "and Fone like '%" + _CWParceiro.Fone + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.FoneFax))
            {
                sSqlCondicao += "and FoneFax like '%" + _CWParceiro.FoneFax + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Email))
            {
                sSqlCondicao += "and Email like '%" + _CWParceiro.Email + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Endereco))
            {
                sSqlCondicao += "and Endereco like '%" + _CWParceiro.Endereco + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Bairro))
            {
                sSqlCondicao += "and Bairro like '%" + _CWParceiro.Bairro + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.CEP))
            {
                sSqlCondicao += "and CEP like '%" + _CWParceiro.CEP + "%'";
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Cidade))
            {
                sSqlCondicao += "and Cidade like '%" + _CWParceiro.Cidade + "%'";
            }


            if (_CWParceiro.Estado > 0)
            {
                sSqlCondicao += "and Estado = " + _CWParceiro.Estado;
            }


            if (!string.IsNullOrEmpty(_CWParceiro.Site))
            {
                sSqlCondicao += "and Site like '%" + _CWParceiro.Site + "%'";
            }

            if (_CWParceiro.Especialidade > 0)
            {
                sSqlCondicao += "and Especialidade = " + _CWParceiro.Especialidade;
            }


            if (_CWParceiro.DataContato != DateTime.MinValue)
            {
                sSqlCondicao += "and DataContato = '" + _CWParceiro.DataContato + "'";
            }

            if (_CWParceiro.DataVisita != DateTime.MinValue)
            {
                sSqlCondicao += "and DataVisita = '" + _CWParceiro.DataVisita + "'";
            }

            if (_CWParceiro.DataCadastro != DateTime.MinValue)
            {
                sSqlCondicao += "and DataCadastro = '" + _CWParceiro.DataCadastro + "'";
            }

            if (_CWParceiro.Proposta > 0)
            {
                sSqlCondicao += "and Proposta = " + _CWParceiro.Proposta;
            }

            if (_CWParceiro.Contrato > 0)
            {
                sSqlCondicao += "and Contrato = " + _CWParceiro.Contrato;
            }

            if (_CWParceiro.Logo > 0)
            {
                sSqlCondicao += "and Logo = " + _CWParceiro.Logo;
            }

            if (_CWParceiro.Gerente > 0)
            {
                sSqlCondicao += "and Gerente = " + _CWParceiro.Gerente;
            }

            if (_CWParceiro.Coordenador > 0)
            {
                sSqlCondicao += "and Coordenador = " + _CWParceiro.Coordenador;
            }

            if (_CWParceiro.Classificacao > 0)
            {
                sSqlCondicao += "and Classificacao = " + _CWParceiro.Classificacao;
            }

            if (_CWParceiro.Especial > 0)
            {
                sSqlCondicao += "and Especial = " + _CWParceiro.Especial;
            }

            if (_CWParceiro.EspecialVisita > 0)
            {
                sSqlCondicao += "and EspecialVisita = " + _CWParceiro.EspecialVisita;
            }

            if (_CWParceiro.EspecialContato > 0)
            {
                sSqlCondicao += "and EspecialContato = " + _CWParceiro.EspecialContato;
            }

            if (!string.IsNullOrEmpty(_CWParceiro.Observacao))
            {
                sSqlCondicao += "and Observacao like '%" + _CWParceiro.Observacao + "%'";
            }

            if (_CWParceiro.DataCadastroSistema != DateTime.MinValue)
            {
                sSqlCondicao += "and DataCadastroSistema = '" + _CWParceiro.DataCadastroSistema + "'";
            }

            if (_CWParceiro.Status > 0)
            {
                sSqlCondicao += "and Status = " + _CWParceiro.Status;
            }

            //if (!string.IsNullOrEmpty(_CWParceiro.Logomarca))
            //{
            //    sSqlCondicao += "and Logomarca like '%" + _CWParceiro.Logomarca + "%'";
            //}


            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            List<CWParceiro> dtPesquisa = ExecutarQuery<CWParceiro>(sSql);

            return dtPesquisa;
        }
        #endregion

        public void Salvar(CWParceiro _CWParceiro)
        {

            if (_CWParceiro.Codigo > 0)
            {
                sSql = @" update Parceiros set 
                                Nome = '" + _CWParceiro.Nome + @"'
                                , Fantasia = '" + _CWParceiro.Fantasia + @"'
                                , CNPJ = '" + _CWParceiro.CNPJ + @"'
                                , Contato = '" + _CWParceiro.Contato + @"'
                                , DataNC = '" + (_CWParceiro.DataNC == DateTime.MinValue ? "" : _CWParceiro.DataNC.ToString("yyyy") + "-" + _CWParceiro.DataNC.ToString("MM") + "-" + _CWParceiro.DataNC.ToString("dd")) + @"'
                                , CargoC = '" + _CWParceiro.CargoC + @"'
                                , CelularC = '" + _CWParceiro.CelularC + @"'
                                , EmailC = '" + _CWParceiro.EmailC + @"'
                                , ContatoTec = '" + _CWParceiro.ContatoTec + @"'
                                , DataNCT = '" + (_CWParceiro.DataNCT == DateTime.MinValue ? "" : _CWParceiro.DataNCT.ToString("yyyy") + "-" + _CWParceiro.DataNCT.ToString("MM") + "-" + _CWParceiro.DataNCT.ToString("dd")) + @"'
                                , CargoCT = '" + _CWParceiro.CargoCT + @"'
                                , CelularCT = '" + _CWParceiro.CelularCT + @"'
                                , EmailCT = '" + _CWParceiro.EmailCT + @"'
                                , Fone = '" + _CWParceiro.Fone + @"'
                                , FoneFax = '" + _CWParceiro.FoneFax + @"'
                                , Email = '" + _CWParceiro.Email + @"'
                                , Endereco = '" + _CWParceiro.Endereco + @"'
                                , Bairro = '" + _CWParceiro.Bairro + @"'
                                , CEP = '" + _CWParceiro.CEP + @"'
                                , Cidade = '" + _CWParceiro.Cidade + @"'
                                , Estado = " + _CWParceiro.Estado + @"
                                , Site = '" + _CWParceiro.Site + @"'
                                , Especialidade = " + _CWParceiro.Especialidade + @"
                                , DataContato = '" + (_CWParceiro.DataContato == DateTime.MinValue ? "" : _CWParceiro.DataContato.ToString("yyyy") + "-" + _CWParceiro.DataContato.ToString("MM") + "-" + _CWParceiro.DataContato.ToString("dd")) + @"'
                                , DataVisita = '" + (_CWParceiro.DataVisita == DateTime.MinValue ? "" : _CWParceiro.DataVisita.ToString("yyyy") + "-" + _CWParceiro.DataVisita.ToString("MM") + "-" + _CWParceiro.DataVisita.ToString("dd")) + @"'
                                , DataCadastro = '" + (_CWParceiro.DataCadastro == DateTime.MinValue ? "" : _CWParceiro.DataCadastro.ToString("yyyy") + "-" + _CWParceiro.DataCadastro.ToString("MM") + "-" + _CWParceiro.DataCadastro.ToString("dd")) + @"'
                                , Proposta = " + _CWParceiro.Proposta + @"
                                , Contrato = " + _CWParceiro.Contrato + @"
                                , Logo = " + _CWParceiro.Logo + @"
                                , Gerente = " + _CWParceiro.Gerente + @"
                                , Coordenador = " + _CWParceiro.Coordenador + @"
                                , Classificacao = " + _CWParceiro.Classificacao + @"
                                , Especial = " + _CWParceiro.Especial + @"
                                , EspecialVisita = " + _CWParceiro.EspecialVisita + @"
                                , EspecialContato = " + _CWParceiro.EspecialContato + @"
                                , Observacao = '" + _CWParceiro.Observacao + @"'
                                , Status = " + _CWParceiro.Status + @"                                
                            where 
                                Codigo = " + _CWParceiro.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO Parceiros
                                (Nome
                                , Fantasia
                                , CNPJ
                                , Contato
                                , DataNC
                                , CargoC
                                , CelularC
                                , EmailC
                                , ContatoTec
                                , DataNCT
                                , CargoCT
                                , CelularCT
                                , EmailCT
                                , Fone
                                , FoneFax
                                , Email
                                , Endereco
                                , Bairro
                                , CEP
                                , Cidade
                                , Estado
                                , Site
                                , Especialidade
                                , DataContato
                                , DataVisita
                                , DataCadastro
                                , Proposta
                                , Contrato
                                , Logo
                                , Gerente
                                , Coordenador
                                , Classificacao
                                , Especial
                                , EspecialVisita
                                , EspecialContato
                                , Observacao
                                , DataCadastroSistema
                                , Status)
                            VALUES
                                ('" + _CWParceiro.Nome + @"'
                                , '" + _CWParceiro.Fantasia + @"'
                                , '" + _CWParceiro.CNPJ + @"'
                                , '" + _CWParceiro.Contato + @"'
                                , '" + (_CWParceiro.DataNC == DateTime.MinValue ? "" : _CWParceiro.DataNC.ToString("yyyy") + "-" + _CWParceiro.DataNC.ToString("MM") + "-" + _CWParceiro.DataNC.ToString("dd")) + @"'
                                , '" + _CWParceiro.CargoC + @"'
                                , '" + _CWParceiro.CelularC + @"'
                                , '" + _CWParceiro.EmailC + @"'
                                , '" + _CWParceiro.ContatoTec + @"'
                                , '" + (_CWParceiro.DataNCT == DateTime.MinValue ? "" : _CWParceiro.DataNCT.ToString("yyyy") + "-" + _CWParceiro.DataNCT.ToString("MM") + "-" + _CWParceiro.DataNCT.ToString("dd")) + @"'
                                , '" + _CWParceiro.CargoCT + @"'
                                , '" + _CWParceiro.CelularCT + @"'
                                , '" + _CWParceiro.EmailCT + @"'
                                , '" + _CWParceiro.Fone + @"'
                                , '" + _CWParceiro.FoneFax + @"'
                                , '" + _CWParceiro.Email + @"'
                                , '" + _CWParceiro.Endereco + @"'
                                , '" + _CWParceiro.Bairro + @"'
                                , '" + _CWParceiro.CEP + @"'
                                , '" + _CWParceiro.Cidade + @"'
                                , " + _CWParceiro.Estado + @"
                                , '" + _CWParceiro.Site + @"'
                                , '" + _CWParceiro.Especialidade + @"'
                                , '" + (_CWParceiro.DataContato == DateTime.MinValue ? "" : _CWParceiro.DataContato.ToString("yyyy") + "-" + _CWParceiro.DataContato.ToString("MM") + "-" + _CWParceiro.DataContato.ToString("dd")) + @"'
                                , '" + (_CWParceiro.DataVisita == DateTime.MinValue ? "" : _CWParceiro.DataVisita.ToString("yyyy") + "-" + _CWParceiro.DataVisita.ToString("MM") + "-" + _CWParceiro.DataVisita.ToString("dd")) + @"'
                                , '" + (_CWParceiro.DataCadastro == DateTime.MinValue ? "" : _CWParceiro.DataCadastro.ToString("yyyy") + "-" + _CWParceiro.DataCadastro.ToString("MM") + "-" + _CWParceiro.DataCadastro.ToString("dd")) + @"'
                                , " + _CWParceiro.Proposta + @"
                                , " + _CWParceiro.Contrato + @"
                                , " + _CWParceiro.Logo + @"
                                , " + _CWParceiro.Gerente + @"
                                , " + _CWParceiro.Coordenador + @"
                                , " + _CWParceiro.Classificacao + @"
                                , " + _CWParceiro.Especial + @"
                                , " + _CWParceiro.EspecialVisita + @"
                                , " + _CWParceiro.EspecialContato + @"
                                , '" + _CWParceiro.Observacao + @"'
                                , GETDATE()
                                , " + _CWParceiro.Status + @")";

            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from Parceiros where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }

    }
}
