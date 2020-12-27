using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora.Clases.Base
{
    public sealed class Codificacion
    {
        private static int _XOR = 46;

        public static string Codificar(string strACodificar)
        {
            byte[] _bytEntrada = Encoding.UTF8.GetBytes(strACodificar);
            for (int _intPos = 0; _intPos < _bytEntrada.Length; _intPos++)
                _bytEntrada[_intPos] = Convert.ToByte(_XOR ^ Convert.ToInt32(_bytEntrada[_intPos]));
            return Convert.ToBase64String(_bytEntrada).Replace("+", "|");
        }

        public static string DeCodificar(string strADecodificar)
        {
            byte[] _bytEntrada = Convert.FromBase64String(strADecodificar.Replace("|", "+"));
            for (int _intPos = 0; _intPos < _bytEntrada.Length; _intPos++)
                _bytEntrada[_intPos] = Convert.ToByte(_XOR ^ Convert.ToInt32(_bytEntrada[_intPos]));
            return Encoding.UTF8.GetString(_bytEntrada);
        }
    }
}
