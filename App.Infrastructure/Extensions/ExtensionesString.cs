// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.Extensions.ExtensionesString
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System;
using System.Net.Mail;

namespace App.Infrastructure.Extensions
{
  public static class ExtensionesString
  {
    public static bool IsBoolean(this string texto) => bool.TryParse(texto, out bool _);

    public static bool IsInt(this string texto) => int.TryParse(texto, out int _);

    public static bool IsDecimal(this string texto) => Decimal.TryParse(texto, out Decimal _);

    public static bool IsDouble(this string texto) => double.TryParse(texto, out double _);

    public static bool IsFloat(this string texto) => float.TryParse(texto, out float _);

    public static bool IsDateTime(this string texto) => DateTime.TryParse(texto, out DateTime _);

    public static bool IsHour(this string texto)
    {
      string[] strArray = texto.Split(':');
      int result;
      return strArray.Length == 2 && int.TryParse(strArray[0], out result) && int.TryParse(strArray[1], out result) && DateTime.TryParse(texto, out DateTime _);
    }

    public static bool IsRut(this string texto)
    {
      if (texto == null)
        return false;
      string[] strArray = texto.Split('-');
      texto = texto.Insert(texto.Length - 1, "-");
      int result;
      if (strArray.Length != 2 || !int.TryParse(strArray[0], out result))
        return false;
      string upper = strArray[1].ToUpper();
      int num1 = 2;
      int num2 = 0;
      while (result != 0)
      {
        int num3 = result % 10 * num1;
        num2 += num3;
        result /= 10;
        ++num1;
        if (num1 == 8)
          num1 = 2;
      }
      int num4 = 11 - num2 % 11;
      string str = num4.ToString().Trim();
      if (num4 == 10)
        str = "K";
      if (num4 == 11)
        str = "0";
      return str == upper;
    }

    public static bool IsEmail(this string email)
    {
      try
      {
        MailAddress mailAddress = new MailAddress(email);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool IsUrl(this string texto) => Uri.TryCreate(texto, UriKind.Absolute, out Uri _);

    public static bool IsNullOrWhiteSpace(this string texto) => string.IsNullOrWhiteSpace(texto);

    public static bool IsGuId(this string texto) => Guid.TryParse(texto, out Guid _);

    public static int ToInt(this string texto)
    {
      int result;
      int.TryParse(texto, out result);
      return result;
    }

    public static string enletras(string num)
    {
      string str = "";
      double d;
      try
      {
        d = Convert.ToDouble(num);
      }
      catch
      {
        return "";
      }
      long int64 = Convert.ToInt64(Math.Truncate(d));
      int int32 = Convert.ToInt32(Math.Round((d - (double) int64) * 100.0, 2));
      if (int32 > 0)
        str = " CON " + int32.ToString() + "PESOS";
      return ExtensionesString.toText(Convert.ToDouble(int64)) + str;
    }

    private static string toText(double value)
    {
      value = Math.Truncate(value);
      string text;
      if (value == 0.0)
        text = "CERO";
      else if (value == 1.0)
        text = "UNO";
      else if (value == 2.0)
        text = "DOS";
      else if (value == 3.0)
        text = "TRES";
      else if (value == 4.0)
        text = "CUATRO";
      else if (value == 5.0)
        text = "CINCO";
      else if (value == 6.0)
        text = "SEIS";
      else if (value == 7.0)
        text = "SIETE";
      else if (value == 8.0)
        text = "OCHO";
      else if (value == 9.0)
        text = "NUEVE";
      else if (value == 10.0)
        text = "DIEZ";
      else if (value == 11.0)
        text = "ONCE";
      else if (value == 12.0)
        text = "DOCE";
      else if (value == 13.0)
        text = "TRECE";
      else if (value == 14.0)
        text = "CATORCE";
      else if (value == 15.0)
        text = "QUINCE";
      else if (value < 20.0)
        text = "DIECI" + ExtensionesString.toText(value - 10.0);
      else if (value == 20.0)
        text = "VEINTE";
      else if (value < 30.0)
        text = "VEINTI" + ExtensionesString.toText(value - 20.0);
      else if (value == 30.0)
        text = "TREINTA";
      else if (value == 40.0)
        text = "CUARENTA";
      else if (value == 50.0)
        text = "CINCUENTA";
      else if (value == 60.0)
        text = "SESENTA";
      else if (value == 70.0)
        text = "SETENTA";
      else if (value == 80.0)
        text = "OCHENTA";
      else if (value == 90.0)
        text = "NOVENTA";
      else if (value < 100.0)
        text = ExtensionesString.toText(Math.Truncate(value / 10.0) * 10.0) + " Y " + ExtensionesString.toText(value % 10.0);
      else if (value == 100.0)
        text = "CIEN";
      else if (value < 200.0)
        text = "CIENTO " + ExtensionesString.toText(value - 100.0);
      else if (value == 200.0 || value == 300.0 || value == 400.0 || value == 600.0 || value == 800.0)
        text = ExtensionesString.toText(Math.Truncate(value / 100.0)) + "CIENTOS";
      else if (value == 500.0)
        text = "QUINIENTOS";
      else if (value == 700.0)
        text = "SETECIENTOS";
      else if (value == 900.0)
        text = "NOVECIENTOS";
      else if (value < 1000.0)
        text = ExtensionesString.toText(Math.Truncate(value / 100.0) * 100.0) + " " + ExtensionesString.toText(value % 100.0);
      else if (value == 1000.0)
        text = "MIL";
      else if (value < 2000.0)
        text = "MIL " + ExtensionesString.toText(value % 1000.0);
      else if (value < 1000000.0)
      {
        text = ExtensionesString.toText(Math.Truncate(value / 1000.0)) + " MIL";
        if (value % 1000.0 > 0.0)
          text = text + " " + ExtensionesString.toText(value % 1000.0);
      }
      else if (value == 1000000.0)
        text = "UN MILLON";
      else if (value < 2000000.0)
        text = "UN MILLON " + ExtensionesString.toText(value % 1000000.0);
      else if (value < 1000000000000.0)
      {
        text = ExtensionesString.toText(Math.Truncate(value / 1000000.0)) + " MILLONES ";
        if (value - Math.Truncate(value / 1000000.0) * 1000000.0 > 0.0)
          text = text + " " + ExtensionesString.toText(value - Math.Truncate(value / 1000000.0) * 1000000.0);
      }
      else if (value == 1000000000000.0)
        text = "UN BILLON";
      else if (value < 2000000000000.0)
      {
        text = "UN BILLON " + ExtensionesString.toText(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
      }
      else
      {
        text = ExtensionesString.toText(Math.Truncate(value / 1000000000000.0)) + " BILLONES";
        if (value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0 > 0.0)
          text = text + " " + ExtensionesString.toText(value - Math.Truncate(value / 1000000000000.0) * 1000000000000.0);
      }
      return text;
    }
  }
}
