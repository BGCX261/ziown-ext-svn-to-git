using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;

namespace Dados
{
    public class Usuario : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;
        Criptografia _cripto = new Criptografia();
        public List<CWUsuario> Pesquisar(CWUsuario _CWUsuario)
        {
            return Pesquisar(_CWUsuario, "");
        }

        public List<CWUsuario> Pesquisar(CWUsuario _CWUsuario, string _Order)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from USUARIO";

            if (_CWUsuario.Codigo > 0)
            {
                sSqlCondicao += " and Codigo = " + _CWUsuario.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Usuario))
            {
                sSqlCondicao += " and Usuario like '%" + _CWUsuario.Usuario + "%'";
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Email))
            {
                sSqlCondicao += " and Email like '%" + _CWUsuario.Email + "%'";
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Senha))
            {
                sSqlCondicao += " and Senha like '%" + _CWUsuario.Senha + "%'";
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Nome))
            {
                sSqlCondicao += " and Nome like '%" + _CWUsuario.Nome + "%'";
            }

            if (_Order.Length > 0)
                sSql += " order by  " + _Order;

            List<CWUsuario> dtPesquisa = ExecutarQuery<CWUsuario>(sSql);

            return dtPesquisa;
        }

        public long ValidarAcesso(CWUsuario _CWUsuario)
        {
            sSqlCondicao = string.Empty;

            sSql = @" Select *
                    from USUARIO ";

            if (_CWUsuario.Codigo > 0)
            {
                sSqlCondicao += "and Codigo = " + _CWUsuario.Codigo;
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Usuario))
            {
                sSqlCondicao += "and Usuario = '" + _CWUsuario.Usuario + "'";
            }

            if (!string.IsNullOrEmpty(_CWUsuario.Senha))
            {
                sSqlCondicao += "and Senha = '" + new CriptografiaRijndael().Criptografar(_CWUsuario.Senha) + "'";
            }

            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            List<CWUsuario> dtPesquisa = ExecutarQuery<CWUsuario>(sSql);

            if (dtPesquisa.Count > 0)
            {
                return long.Parse(dtPesquisa.FirstOrDefault().Codigo.ToString());
            }
            else
                return 0;

        }

        public void Salvar(CWUsuario _CWUsuario)
        {

            if (_CWUsuario.Codigo > 0)
            {
                sSql = @" update USUARIO set 
                                  Usuario = '" + _CWUsuario.Usuario + @"'
                                , Senha = '" + _CWUsuario.Senha + @"'
                                , Nome = '" + _CWUsuario.Nome + @"'
                                , Email = '" + _CWUsuario.Email + @"'
                            where 
                                Codigo = " + _CWUsuario.Codigo;
            }
            else
            {
                sSql = @" INSERT INTO USUARIO
                                ( Usuario
                                , Email
                                , Senha
                                , Nome
                                , Status)
                            VALUES
                                ('" + _CWUsuario.Usuario + @"'
                                , '" + _CWUsuario.Email + @"'
                                , '" + _CWUsuario.Senha + @"'
                                , '" + _CWUsuario.Nome + @"'
                                , '" + _CWUsuario.Status + @"')";

            }

            Executar(sSql);

        }

        public void AlteraSenha(CWUsuario _CWUsuario)
        {

            if (_CWUsuario.Codigo > 0)
            {
                sSql = @" update USUARIO set 
                                Senha = '" + _CWUsuario.Senha + @"'
                            where 
                                Codigo = " + _CWUsuario.Codigo;
            }

            Executar(sSql);

        }

        public void Excluir(long __Codigo)
        {

            if (__Codigo > 0)
            {
                sSql = @" delete from USUARIO where Codigo = " + __Codigo;
            }

            Executar(sSql);

        }

    }
}
