
namespace Framework
{	
	public class Criptografia
	{
		/// <summary>
		/// Criptografa uma string
		/// </summary>
		/// <param name="p_strTexto">Texto puro</param>
		/// <returns>Texto criptografado</returns>
        public string CriptografarString(string p_strTexto)
		{
			CriptografiaRijndael objCripto = new CriptografiaRijndael();
            return objCripto.Criptografar(p_strTexto);
		}

		/// <summary>
		/// Decriptografa uma string
		/// </summary>
		/// <param name="p_strTexto">Texto criptografado</param>
		/// <returns>Texto puro</returns>
        public string DecriptografarString(string p_strTexto)
		{
			CriptografiaRijndael objCripto = new CriptografiaRijndael();
			return objCripto.Decriptografar(p_strTexto);
		}
	}
}

