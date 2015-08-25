using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dados
{
    public class NgPesquisas : FrameworkBase
    {
        string sSqlCondicao = string.Empty;
        string sSql = string.Empty;

        #region BarraInferior
        #region PesquisarAtrasados
        public long PesquisarAtrasados(long _codUsuario)
        {
            sSqlCondicao = string.Empty;

            sSql = @"SELECT COUNT(Codigo) AS Total FROM Prospect WHERE (DataCT < { fn NOW() }) AND (Status = 1) AND (Gerente = " + _codUsuario + ") ";


            if (sSqlCondicao.Length > 0)
                sSql += " where " + sSqlCondicao.Substring(3);

            DataSet _ds = ExecutarQuerySql(sSql);

            if (_ds.Tables[0].Rows.Count > 0)
                return long.Parse(_ds.Tables[0].Rows[0]["Total"].ToString());
            else
                return 0;
        }
        #endregion

        #region PesquisarClientesCoordenador
        public long PesquisarClientesCoordenador(long _codUsuario)
        {
            sSqlCondicao = string.Empty;

            sSql = @"SELECT COUNT(Notas.Codigo) AS Notas 
                    FROM Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Notas ON Prospect.Codigo = Notas.CodigoCliente 
                    WHERE (Usuarios.Codigo =  " + _codUsuario + @"
	                       AND (MONTH(Notas.Data) = " + DateTime.Now.Month + @") 
	                       AND (YEAR(Notas.Data) = " + DateTime.Now.Year + @"))";

            DataSet _ds = ExecutarQuerySql(sSql);

            if (_ds.Tables[0].Rows.Count > 0)
                return long.Parse(_ds.Tables[0].Rows[0]["Notas"].ToString());
            else
                return 0;
        }
        #endregion

        #region PesquisarPropostas
        public long PesquisarPropostas(long _codUsuario)
        {
            sSqlCondicao = string.Empty;

            sSql = @"SELECT COUNT(Propostas.Codigo) AS Propostas 
                    FROM Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente AND 
									                    Prospect.Codigo = Propostas.CodigoCliente 
                    WHERE (Usuarios.Codigo =  " + _codUsuario + @"
                    AND (MONTH(Propostas.DataCadastro) = " + DateTime.Now.Month + @") 
                    AND (YEAR(Propostas.DataCadastro) = " + DateTime.Now.Year + @"))
                    GROUP BY Usuarios.Nome";

            DataSet _ds = ExecutarQuerySql(sSql);

            if (_ds.Tables[0].Rows.Count > 0)
                return long.Parse(_ds.Tables[0].Rows[0]["Propostas"].ToString());
            else
                return 0;
        }
        #endregion

        #region PesquisarContatos
        public long PesquisarContatos(long _codUsuario)
        {
            sSqlCondicao = string.Empty;

            sSql = @"SELECT COUNT(Notas.Codigo) AS Notas 
                    FROM Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Notas ON Prospect.Codigo = Notas.CodigoCliente 
                    WHERE (Usuarios.Codigo = " + _codUsuario + @") 
                    AND (MONTH(Notas.Data) = " + DateTime.Now.Month + @") 
                    AND (YEAR(Notas.Data) = " + DateTime.Now.Year + @")";

            DataSet _ds = ExecutarQuerySql(sSql);

            if (_ds.Tables[0].Rows.Count > 0)
                return long.Parse(_ds.Tables[0].Rows[0]["Notas"].ToString());
            else
                return 0;
        }
        #endregion
        #endregion

        #region Resultados
        #region ConsultarResultadoACM
        public DataTable ConsultarResultadoACM(long __UserId, long __UserCoordenador)
        {


            if (__UserId == 1 || __UserId == 2)
                sSql = "SELECT Prospect.Fechamento, SUM(Prospect.Valor) AS Valor, COUNT(Prospect.Valor) AS Total, Usuarios.Nome FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo WHERE (Prospect.Status = 1) GROUP BY Prospect.Fechamento, Usuarios.Nome";
            else
                sSql = "SELECT Prospect.Fechamento, SUM(Prospect.Valor) AS Valor, COUNT(Prospect.Valor) AS Total, Usuarios.Nome FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo WHERE (Prospect.Status = 1) AND (Prospect.Coordenador = " + __UserCoordenador + ") GROUP BY Prospect.Fechamento, Usuarios.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoACMTotal
        public DataTable ConsultarResultadoACMTotal(long __UserId, long __UserCoordenador)
        {

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT Prospect.Fechamento, SUM(Prospect.Valor) AS Valor, COUNT(Valor) AS Total FROM Prospect WHERE (Prospect.Status = 1) GROUP BY Prospect.Fechamento ORDER BY Fechamento";
            }
            else
            {
                sSql = "SELECT Prospect.Fechamento, SUM(Prospect.Valor) AS Valor, COUNT(Valor) AS Total FROM Prospect WHERE (Prospect.Status = 1) AND (Coordenador = " + __UserCoordenador + ") GROUP BY Prospect.Fechamento ORDER BY Fechamento";
            }

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoTotal
        public DataTable ConsultarResultadoTotal(long __UserId, long __UserCoordenador)
        {

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT SUM(Prospect.Valor) AS Valor, COUNT(Valor) AS Total FROM Prospect WHERE (Prospect.Status = 1)";
            }
            else
            {
                sSql = "SELECT SUM(Prospect.Valor) AS Valor, COUNT(Valor) AS Total FROM Prospect WHERE (Prospect.Status = 1) AND (Coordenador = " + __UserCoordenador + ")";
            }


            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoTotalProp
        public DataTable ConsultarResultadoTotalProp(long __UserId, long __UserCoordenador)
        {

            var VMes = (DateTime.Now).Month - 1;
            if (VMes == 0)
            {
                if (__UserId == 1 || __UserId == 2)
                {
                    sSql = "SELECT Usuarios.Nome, Usuarios.MetaPropostas FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente AND Prospect.Codigo = Propostas.CodigoCliente WHERE (MONTH(Prospect.Data) = MONTH(GETDATE())) OR (MONTH(Prospect.Data) = 12) GROUP BY Usuarios.Nome, Usuarios.MetaPropostas";
                }
                else
                {
                    sSql = "SELECT Usuarios.Nome, Usuarios.MetaPropostas FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente AND Prospect.Codigo = Propostas.CodigoCliente WHERE (MONTH(Prospect.Data) = MONTH(GETDATE())) AND (Prospect.Coordenador = " + __UserCoordenador + ") OR (MONTH(Prospect.Data) = 12) AND (Prospect.Coordenador = " + __UserCoordenador + ") GROUP BY Usuarios.Nome, Usuarios.MetaPropostas";
                }
            }
            else
            {
                if (__UserId == 1 || __UserId == 2)
                {
                    sSql = "SELECT Usuarios.Nome, Usuarios.MetaPropostas FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente AND Prospect.Codigo = Propostas.CodigoCliente WHERE (MONTH(Prospect.Data) = MONTH(GETDATE())) OR (MONTH(Prospect.Data) = MONTH(GETDATE()) - 1) GROUP BY Usuarios.Nome, Usuarios.MetaPropostas";
                }
                else
                {
                    sSql = "SELECT Usuarios.Nome, Usuarios.MetaPropostas FROM Prospect INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente AND Prospect.Codigo = Propostas.CodigoCliente WHERE (MONTH(Prospect.Data) = MONTH(GETDATE())) AND (Prospect.Coordenador = " + __UserCoordenador + ") OR (MONTH(Prospect.Data) = MONTH(GETDATE()) - 1) AND (Prospect.Coordenador = " + __UserCoordenador + ") GROUP BY Usuarios.Nome, Usuarios.MetaPropostas";
                }
            }

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaProp
        public DataTable ConsultarResultadoContaProp(long __UserId, long __UserCoordenador)
        {
            var MesProp = (DateTime.Now).Month;

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp  FROM Propostas INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.Data) = " + MesProp + ")";
            }
            else
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp  FROM Propostas INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.Data) = " + MesProp + ") AND (Prospect.Coordenador = " + __UserCoordenador + ")";
            }

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaPropOld
        public DataTable ConsultarResultadoContaPropOld(long __UserId, long __UserCoordenador)
        {

            var MesPropOld = (DateTime.Now).Month - 1;
            if (MesPropOld == 0)
            {
                MesPropOld = 12;
            }

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp  FROM Propostas INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.Data) = " + MesPropOld + ")";
            }
            else
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp  FROM Propostas INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.Data) = " + MesPropOld + ") AND (Prospect.Coordenador = " + __UserCoordenador + ")";
            }


            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaPropTotal
        public DataTable ConsultarResultadoContaPropTotal(long __UserId, long __UserCoordenador)
        {

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp FROM Propostas";
            }
            else
            {
                sSql = "SELECT COUNT(Propostas.Codigo) AS TotalProp FROM Propostas INNER JOIN Prospect ON Propostas.Codigo = Prospect.Codigo WHERE (Prospect.Coordenador = " + __UserCoordenador + ")";
            }

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaTipo
        public DataTable ConsultarResultadoContaTipo(long __UserId, long __UserCoordenador)
        {

            if (__UserId == 1 || __UserId == 2)
            {
                sSql = "SELECT Produtos.Produto, COUNT(Propostas.Codigo) AS Total, SUM(Propostas.ValorProposta) AS Mes, SUM(Propostas.ValorInstalacao) AS Inst FROM Propostas INNER JOIN Produtos ON Propostas.Hospedagem = Produtos.Codigo INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.DataCadastro) = " + DateTime.Now.Month + ") GROUP BY Produtos.Produto";
            }
            else
            {
                sSql = "SELECT Produtos.Produto, COUNT(Propostas.Codigo) AS Total, SUM(Propostas.ValorProposta) AS Mes, SUM(Propostas.ValorInstalacao) AS Inst FROM Propostas INNER JOIN Produtos ON Propostas.Hospedagem = Produtos.Codigo INNER JOIN Prospect ON Propostas.CodigoCliente = Prospect.Codigo WHERE (MONTH(Propostas.DataCadastro) = " + DateTime.Now.Month + ") AND (Prospect.Coordenador = " + __UserCoordenador + ") GROUP BY Produtos.Produto";
            }

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoSomaPropGN
        public DataTable ConsultarResultadoSomaPropGN(string __Nome)
        {

            sSql = @"SELECT	Sum(Propostas.ValorProposta) AS Mens, 
		                    Sum(Propostas.ValorInstalacao) AS Inst 
                    FROM Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente 
								                    AND Prospect.Codigo = Propostas.CodigoCliente 
                    WHERE	(Usuarios.Nome = '" + __Nome + @"') 
                    AND		(MONTH(Propostas.DataCadastro) = " + DateTime.Now.Month + @") 
                    AND		(Year(Propostas.DataCadastro) = " + DateTime.Now.Year + @")  
                    GROUP BY Usuarios.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaPropGN
        public DataTable ConsultarResultadoContaPropGN(string __Nome, int __Mes, int __Ano)
        {

            sSql = @"SELECT	COUNT(Propostas.Codigo) AS Propostas 
                    FROM	Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente 
								                    AND Prospect.Codigo = Propostas.CodigoCliente 
                    WHERE	(Usuarios.Nome = '" + __Nome + @"') 
                    AND		(MONTH(Propostas.DataCadastro) = " + __Mes + @") 
                    AND		(YEAR(Propostas.DataCadastro) = " + __Ano + @") 
                    GROUP BY Usuarios.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoContaPropGNTotal
        public DataTable ConsultarResultadoContaPropGNTotal(string __Nome, int __Mes, int __Ano)
        {

            sSql = @"SELECT	COUNT(Propostas.Codigo) AS Propostas 
                    FROM	Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente 
                    AND		Prospect.Codigo = Propostas.CodigoCliente 
                    WHERE	(Usuarios.Nome = '" + __Nome + @"') 
                    AND		(MONTH(Propostas.DataCadastro) = " + __Mes + @") 
                    AND		(Year(Propostas.DataCadastro) = " + __Ano + @") 
                    AND		(Prospect.Status = 2) 
                    GROUP BY Usuarios.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoMetaProp
        public DataTable ConsultarResultadoMetaProp(long __Codigo, int __Mes, int __Ano)
        {

            sSql = @"SELECT COUNT(Propostas.Codigo) AS Propostas 
                    FROM Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente 
								                    AND Prospect.Codigo = Propostas.CodigoCliente 
                    WHERE	(Usuarios.Codigo = " + __Codigo + @") 
                    AND		(MONTH(Propostas.DataCadastro) = " + __Mes + @") 
                    AND		(YEAR(Propostas.DataCadastro) = " + __Ano + @") 
                    GROUP BY Usuarios.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoMetaContato
        public DataTable ConsultarResultadoMetaContato(long __Codigo, int __Mes, int __Ano)
        {
            sSql = @"SELECT	COUNT(Notas.Codigo) AS Notas 
                    FROM	Prospect 
                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo
                    INNER JOIN Notas ON Prospect.Codigo = Notas.CodigoCliente 
                    WHERE	(Usuarios.Codigo = " + __Codigo + @") 
                    AND		(MONTH(Notas.Data) = " + __Mes + @") 
                    AND		(YEAR(Notas.Data) = " + __Ano + @")";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoMetaCliente
        public DataTable ConsultarResultadoMetaCliente(long __Codigo, int __Mes, int __Ano)
        {
            sSql = @"SELECT	COUNT(Prospect.Codigo) AS Clientes 
                    FROM	Usuarios 
                    INNER JOIN Prospect ON Usuarios.Codigo = Prospect.Gerente 
                    WHERE	(Prospect.Gerente = " + __Codigo + @") 
                    AND		(MONTH(Prospect.Data) = " + __Mes + @") 
                    AND		(YEAR(Prospect.Data) = " + __Ano + @")";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion

        #region ConsultarResultadoMetas
        public DataTable ConsultarResultadoMetas(long __Coordenador, int __Mes, int __Ano)
        {
            sSql = @"select	Usu.Codigo,
		                    Usu.Nome,
		                    (SELECT COUNT(Propostas.Codigo) 
			                    FROM Prospect 
			                    INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo 
			                    INNER JOIN Propostas ON Prospect.Codigo = Propostas.CodigoCliente 
			                    WHERE	(Usuarios.Codigo = Usu.Codigo) 
			                    AND		(MONTH(Propostas.DataCadastro) = " + __Mes + @") 
			                    AND		(YEAR(Propostas.DataCadastro) = " + __Ano + @") 
			                    GROUP BY Usuarios.Nome) AS Propostas, 
		                    Usu.MetaPropostas,
		                    (SELECT	COUNT(Notas.Codigo) 
                                FROM	Prospect 
                                INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo
                                INNER JOIN Notas ON Prospect.Codigo = Notas.CodigoCliente 
                                WHERE	(Usuarios.Codigo = Usu.Codigo) 
                                AND		(MONTH(Notas.Data) = " + __Mes + @") 
                                AND		(YEAR(Notas.Data) = " + __Ano + @")) AS Notas,
                            Usu.MetaContatos,
        
                            (SELECT	COUNT(Prospect.Codigo) 
                                        FROM	Usuarios 
                                        INNER JOIN Prospect ON Usuarios.Codigo = Prospect.Gerente 
                                        WHERE	(Prospect.Gerente =Usu.Codigo) 
                                        AND		(MONTH(Prospect.Data) = " + __Mes + @") 
                                        AND		(YEAR(Prospect.Data) = " + __Ano + @")) AS Clientes,
                            Usu.MetaClientes
                    from	Usuarios Usu
                    where	Usu.Vende = 1
                    and		Usu.Status = 0";

            if (__Coordenador > 0)
                sSql += " and Coordenador = " + __Coordenador;


            sSql += " order by Usu.Nome";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];

        }
        #endregion


        #endregion

        public DataTable ConsultaComentarios(long __Total, long __UserCoordenador)
        {

            sSql = @"SELECT TOP " + __Total + @" Notas.CodigoCliente As Codigo, 
		                        Notas.Data, 
		                        Prospect.Nome, 
		                        Notas.Nota, 
		                        Usuarios.Nome as Gerente 
                        FROM Notas 
                        INNER JOIN Prospect ON Notas.CodigoCliente = Prospect.Codigo 
                        INNER JOIN Usuarios ON Prospect.Gerente = Usuarios.Codigo ";

            if (__UserCoordenador > 0)
                sSql += " Where Prospect.coordenador = " + __UserCoordenador;

            sSql += "ORDER BY Notas.Data DESC";

            DataSet ds = ExecutarQuerySql(sSql);

            return ds.Tables[0];
        }
    }
}
