using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora.Clases.Base
{
    public sealed class Adicional
    {
        #region Validación
        public static bool ValidaRut(string strRut)
        {
            bool _returnValue = false;
            string[] _arrRut;

            _returnValue = false;
            if (strRut.IndexOf("-") >= 0)
            {
                strRut = strRut.Replace(".", "");
                _arrRut = strRut.Split("-".ToCharArray());
                _returnValue = (CalculaDigito(_arrRut[0]) == _arrRut[1].ToUpper());
            }
            return _returnValue;
        }

        public static string CalculaDigito(string strRut)
        {
            string returnValue = "";
            int intSum = 0;
            int intCont = 0;
            int intLargo = 0;
            int intResto = 0;
            int intPos = 0;
            string strNum = "";

            try
            {
                strRut = long.Parse(strRut).ToString();
            }
            catch
            {
                strRut = "";
            }
            intLargo = strRut.Length;
            intCont = 2;
            intSum = 0;
            for (intPos = 1; intPos <= intLargo; intPos++)
            {
                strNum = strRut.Substring(intLargo - intPos, 1);
                intSum += int.Parse(strNum) * intCont;
                if (intCont < 7)
                    intCont += 1;
                else
                    intCont = 2;
            }
            intResto = (intSum % 11);
            if ((11 - intResto) == 10)
                returnValue = "K";
            else
            {
                if (intResto == 0)
                    returnValue = "0";
                else
                    returnValue = (11 - intResto).ToString();
            }
            return returnValue;
        }
        public static string Verificar_Valor(string strValor, int intLargo, bool blnEsNumero)
        {
            string _returnValue = "";
            _returnValue = strValor;
            if (blnEsNumero)
            {
                try
                {
                    _returnValue = Convert.ToDecimal(_returnValue).ToString();
                }
                catch
                {
                    try
                    {
                        _returnValue = Convert.ToDecimal("0" + _returnValue).ToString();
                    }
                    catch
                    {
                        _returnValue = "0";
                    }
                }
            }
            else
            {
                _returnValue = _returnValue.Replace("<", "&lt;").Replace(">", "&gt;");
                if (Convert.ToBoolean(intLargo) && Convert.ToBoolean(_returnValue.Length) && _returnValue.Length > intLargo)
                    _returnValue = _returnValue.Substring(0, intLargo);
            }
            return _returnValue;
        }
        #endregion

    
    }
}
