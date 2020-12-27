using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Web.UI
{
    public class Utiles
    {
        public static bool CompararBytes(byte[] obj1, byte[] obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;
            if (obj1.Length != obj2.Length)
                return false;
            for (int i = 0; i < obj1.Length; i++)
                if (obj1[i] != obj2[i])
                    return false;
            return true;
        }
        public static bool CompararBytes(Array obj1, Array obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;
            if (obj1.Length != obj2.Length)
                return false;
            for (int i = 0; i < obj1.Length; i++)
                if ((byte)obj1.GetValue(i) != (byte)obj2.GetValue(i))
                    return false;
            return true;
        }
        public static DateTime ConvertirAFecha(string strFecha, DateTime datRetorno, bool blnRetornoError)
        {
            strFecha = strFecha.Trim();
            if (strFecha.Length > 0)
            {
                                        
                if (Regex.Match(strFecha, @"(0[1-9]|[1-2]{0,1}[0-9]|30|31)-(0[1-9]|10|11|12)-((?:19|20)[0-9]{2})").Success)
                    try
                    {
                       // datRetorno = Convert.ToDateTime(strFecha);
                       datRetorno= DateTime.ParseExact(strFecha,"dd-MM-yyyy",null);
                    }
                    catch
                    {
                        if (blnRetornoError)
                            throw new Exception();
                    }
                else if (blnRetornoError)
                    throw new Exception();
            }
            else if (blnRetornoError)
                throw new Exception();

            return datRetorno;
        }
      /// <summary>
      /// Esta función llena un combobox 
      /// </summary>
      /// <param name="combox"></param>
      /// <param name="items">Es un dicccionario con el id y el valor de cada item del combox a llenar</param>
      /// <param name="tipoLista"></param>
      /// <param name="valorDefecto"></param>
      /// <param name="textoDefecto"></param>
        public static void LlenarCombox(DropDownList combox,Dictionary<string,string> items ,string valorDefecto, string textoDefecto)
        {
            combox.Items.Clear();
            if (!String.IsNullOrEmpty(textoDefecto)&& !String.IsNullOrEmpty(valorDefecto))
            {
                combox.Items.Add(new ListItem(textoDefecto, valorDefecto));
                combox.SelectedValue = valorDefecto;
            }
            foreach (string id in items.Keys)
            {
                ListItem item = new ListItem(items[id],id);
                combox.Items.Add(item);
            }
        }
        public static void LlenarRadioButtonList(RadioButtonList radiobuttonlist, Dictionary<string, string> items)
        {
            radiobuttonlist.Items.Clear();
            foreach (string id in items.Keys)
            {
                ListItem item = new ListItem(items[id], id);
                radiobuttonlist.Items.Add(item);
            }
        }
        public static string Chequear_Valor(string strValor, int intLargo, bool blnEsNumero, bool blnValScript)
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
                if (blnValScript) _returnValue = _returnValue.Replace("<", "&lt;").Replace(">", "&gt;");
                if (Convert.ToBoolean(intLargo) && Convert.ToBoolean(_returnValue.Length) && _returnValue.Length > intLargo)
                    _returnValue = _returnValue.Substring(0, intLargo);
            }
            return _returnValue;
        }
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
            long parametro = 0;

            if (!long.TryParse(strRut, out parametro))
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
        /// <summary>
        /// Retorna las llaves de un dictionary en un string separado por ","
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string DictionaryKeyToString(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in dic.Keys)
            {
                sb.Append(key);
                sb.Append(",");
            }
            sb.Remove(sb.Length-1, 1);
            return sb.ToString();
        }
        public static Dictionary<string,string> StringToDictionaryKeyValue(string keys)
        {
            Dictionary<string,string> _result =  new Dictionary<string,string>();
            string[] arr = keys.Split(',');
            foreach (string key in arr)
            {
                _result.Add(key, key);
            }

            return _result;
        }
        public static void LlenarCombox(ref DevExpress.Web.ASPxEditors.ASPxComboBox combox, List<InfoItem> items)
        {
            combox.Items.Clear();
            if (items != null)
            {
                foreach (InfoItem infoitem in items)
                {
                    DevExpress.Web.ASPxEditors.ListEditItem item = new DevExpress.Web.ASPxEditors.ListEditItem();
                    item.Text = infoitem.Text;
                    item.Value = infoitem.Value.ToString();
                    combox.Items.Add(item);
                }
            }
            else
            {
                combox.Items.Add("TODOS", "-1");
            }
        }
        public static List<InfoItem> Anos(int Base)
        {
            List<InfoItem> result = new List<InfoItem>();
            for (int i = Base; i <= DateTime.Now.Year; i++)
            {
                InfoItem ano = new InfoItem();
                ano.Text = i.ToString();
                ano.Value = i;
                result.Add(ano);
            }
            return result;
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "^(([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5}){1,25}(($)|( *;+ *$)|( *;+ *(?=[a-zA-Z0-9_\\-\\.]))))*$";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
      
    }
    
}

