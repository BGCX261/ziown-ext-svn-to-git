using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;
using Framework;
using MySql.Data.MySqlClient;


/// <summary>
/// Summary description for Database
/// </summary>
public class FrameworkBase
{
    MySqlConnection objConn;
    
    #region Abrir
    private void Abrir()
    {

        try
        {
            objConn = new MySqlConnection(@"Data Source=localhost;Initial Catalog=DBLICITACAO;Persist Security Info=True;User ID=tsm;Password=informatica");
            objConn.Open();

        }
        catch (Exception ex)
        {
            throw new Exception("Houve um problema ao abrir o Banco de dados: " + ex.Message);
        }
    }
    #endregion

    #region ExecutarQuery
    public List<T> ExecutarQuery<T>(string sComando)
    {
        DataTable dtRetorno;
        try
        {

            Abrir();
            MySqlCommand cmd = objConn.CreateCommand();

            cmd.CommandText = sComando;

            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            DataSet dsRetorno = new DataSet();
            dr.Fill(dsRetorno);

            dtRetorno = dsRetorno.Tables[0];

        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar a Query: " + ex.Message);
        }
        finally
        {
            objConn.Close();

        }

        return PreencheObjeto<T>(dtRetorno);
    }
    #endregion

    #region PreencheObjeto
    private static List<T> PreencheObjeto<T>(DataTable _dt)
    {
        List<T> _lstRetorno = new List<T>();

        foreach (DataRow _dr in _dt.Rows)
        {
            T _novoObjeto = (T)Activator.CreateInstance(typeof(T));
            foreach (DataColumn _dc in _dt.Columns)
            {
                var _propertyInfo = typeof(T).GetProperties().Where(x => x.Name == _dc.ColumnName).FirstOrDefault();

                if (_propertyInfo != default(PropertyInfo))
                {
                    if(!string.IsNullOrEmpty(_dr[_dc].ToString()))
                        _propertyInfo.SetValue(_novoObjeto, _dr[_dc], null);
                }

            }
            _lstRetorno.Add(_novoObjeto);
        }

        return _lstRetorno;
    }
    #endregion

    #region ExecutarQueryDS
    public DataSet ExecutarQueryDS(string sComando)
    {

        try
        {

            Abrir();
            MySqlCommand cmd = objConn.CreateCommand();

            cmd.CommandText = sComando;

            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            DataSet dsRetorno = new DataSet();
            dr.Fill(dsRetorno);

            return dsRetorno;

        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar a Query: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion

    #region ExecutarQuerySql
    public DataSet ExecutarQuerySql(string sComando)
    {

        try
        {

            Abrir();
            MySqlCommand cmd = objConn.CreateCommand();

            cmd.CommandText = sComando;

            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            DataSet dsRetorno = new DataSet();
            dr.Fill(dsRetorno);

            return dsRetorno;

        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar a Query: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion

    #region Executar
    public long Executar(string sMySql)
    {
        try
        {
            Abrir();
            MySqlCommand comando;
            comando = new MySqlCommand(sMySql, objConn);
            comando.CommandText = sMySql;
            var intRetorno = comando.ExecuteScalar();

            if (intRetorno != null)
                return long.Parse(intRetorno.ToString());
            else
                return 1;
        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar o comando: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion

    #region Executar
    public long Executar(string sMySql, string sTabela)
    {
        try
        {
            Abrir();
            MySqlCommand comando;
            comando = new MySqlCommand(sMySql, objConn);
            comando.CommandText = sMySql;
            var intRetorno = comando.ExecuteScalar();

            string _MySql = "select max(Codigo) from " + sTabela;

            DataSet ds = ExecutarQuerySql(_MySql);

            return long.Parse(ds.Tables[0].Rows[0][0].ToString()); 
        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar o comando: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion

    #region ExecutarQueryDA
    public MySqlDataAdapter ExecutarQueryDA(string sComando)
    {

        try
        {

            Abrir();
            MySqlCommand cmd = objConn.CreateCommand();

            cmd.CommandText = sComando;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            return da;

        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar a Query: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion

    #region ProximoCodigo
    public int ProximoCodigo(string strTabela)
    {

        try
        {

            Abrir();
            MySqlCommand cmd = objConn.CreateCommand();

            string strMySql = "Select max(Codigo) + 1 " +
                           "From " + strTabela;

            cmd.CommandText = strMySql;

            MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
            DataSet dsRetorno = new DataSet();
            dr.Fill(dsRetorno);

            DataTable dtRetorno = dsRetorno.Tables[0];

            if (dtRetorno.Rows[0][0].ToString() != string.Empty)
                return Convert.ToInt32(dtRetorno.Rows[0][0].ToString());
            else
                return 1;

        }
        catch (Exception ex)
        {
            throw new Exception("Problemas ao executar a Query: " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion


}

