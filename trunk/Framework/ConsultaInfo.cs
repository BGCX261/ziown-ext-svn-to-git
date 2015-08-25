using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Framework
{
    public class ConsultaInfo : CollectionBase
    {
        Hashtable c_objHash = null;

        private object objTipo;
        private object objValor;

        #region Tipo
        public object Tipo
        {
            get
            {
                return objTipo;
            }
            set
            {
                objTipo = value;
            }
        }
        #endregion

        #region Valor
        public object Valor
        {
            get
            {
                return objValor;
            }
            set
            {
                objValor = value;
            }
        }
        #endregion

        #region Adicionar
        /// <summary>
        /// Adiciona um valor ao filtro
        /// </summary>
        /// <param name="p_objPropriedade"></param>
        /// <param name="p_objValor"></param>
        /// <returns></returns>
        public int Adicionar(object p_objPropriedade, object p_objValor)
        {
            object objParametro = new object();

            if (c_objHash == null)
            {
                c_objHash = new Hashtable();
            }

            c_objHash.Add(p_objPropriedade, p_objValor);
            return this.List.Add(p_objPropriedade);
        }
        #endregion

        /// <summary>
        /// Recupera os valores do filtro
        /// </summary>
        /// <param name="p_objPropriedade">Propriedade armazenada</param>
        /// <returns></returns>
        public object Recuperar(object p_objPropriedade)
        {
            if (c_objHash == null)
            {
                CarregarLista();
            }
            return c_objHash[p_objPropriedade];
        }

        /// <summary>
        /// Verifica se a propriedade existe
        /// </summary>
        /// <param name="p_objPropriedade">Propriedade armazenada</param>
        /// <returns>true quando existir</returns>
        public bool Contem(object p_objPropriedade)
        {
            if (c_objHash == null)
            {
                CarregarLista();
            }
            return c_objHash.Contains(p_objPropriedade);
            //return c_objHash.ContainsValue(p_objPropriedade);
        }

       
        private void CarregarLista()
        {
            c_objHash = new Hashtable();
            foreach (object objParametro in this.List)
            {
                c_objHash.Add(objParametro, objParametro);
            }
        }

    }
}
