// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.Extensions.ISConvert
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System;
using System.Globalization;
using System.Text;

namespace App.Infrastructure.Extensions
{
  public class ISConvert
  {
    public static char ToChar(object obj) => obj != null && !string.IsNullOrEmpty(obj.ToString()) ? Convert.ToChar(obj.ToString().Trim()) : char.MinValue;

    public static string ToString(object obj) => obj != null && !string.IsNullOrEmpty(obj.ToString()) ? obj.ToString().Trim() : string.Empty;

    public static int ToInteger(object obj)
    {
      int result = 0;
      if (obj == null)
        return 0;
      if (int.TryParse(obj.ToString(), out result))
        return result;
      return string.Compare(ISConvert.ToString(obj), "true", true) == 0 ? 1 : 0;
    }

    public static double ToDouble(object obj)
    {
      double result = 0.0;
      return obj != null && double.TryParse(obj.ToString(), out result) ? result : 0.0;
    }

    public static Decimal ToDecimal(object obj)
    {
      Decimal result = 0M;
      return obj != null && Decimal.TryParse(obj.ToString(), out result) ? result : 0M;
    }

    public static byte[] ToByteArray(string str)
    {
      string s = ISConvert.ToString((object) str);
      if (s != string.Empty)
      {
        try
        {
          return new UTF8Encoding().GetBytes(s);
        }
        catch
        {
        }
      }
      return new byte[0];
    }

    public static bool ToBoolean(object obj)
    {
      if (obj == null)
        return false;
      bool result;
      if (bool.TryParse(obj.ToString().ToLower(), out result))
        return result;
      return ISConvert.ToString(obj) == "1";
    }

    public static DateTime ToDateTime(object obj)
    {
      CultureInfo provider = new CultureInfo("es-ES");
      DateTime result = DateTime.MinValue;
      return obj != null && DateTime.TryParse(obj.ToString(), (IFormatProvider) provider, DateTimeStyles.None, out result) ? result : DateTime.MinValue;
    }

    public static TimeSpan ToTimeSpam(object obj)
    {
      TimeSpan result = new TimeSpan();
      if (obj == null)
        return result;
      TimeSpan.TryParse(obj.ToString(), out result);
      return result;
    }

    public static object ToDbSqlValue(object obj)
    {
      if (obj == null)
        return (object) DBNull.Value;
      if (string.Compare("string", obj.GetType().Name, true) == 0)
        return string.IsNullOrEmpty(obj.ToString()) || obj.ToString().Trim() == "-1" ? (object) DBNull.Value : obj;
      if (string.Compare("int32", obj.GetType().Name, true) == 0)
      {
        int? nullableInteger = ISConvert.ToNullableInteger(obj);
        if (nullableInteger.HasValue)
        {
          nullableInteger = ISConvert.ToNullableInteger(obj);
          int num = -1;
          if (!(nullableInteger.GetValueOrDefault() == num & nullableInteger.HasValue))
            return obj;
        }
        return (object) DBNull.Value;
      }
      return string.Compare("int16", obj.GetType().Name, true) == 0 ? (!ISConvert.ToNullableInteger(obj).HasValue ? (object) DBNull.Value : obj) : (string.Compare("decimal", obj.GetType().Name, true) == 0 ? (!ISConvert.ToNullableDecimal(obj).HasValue ? (object) DBNull.Value : obj) : (string.Compare("double", obj.GetType().Name, true) == 0 ? (!ISConvert.ToNullableDouble(obj).HasValue ? (object) DBNull.Value : obj) : (string.Compare("datetime", obj.GetType().Name, true) == 0 ? (ISConvert.ToDateTime(obj) <= DateTime.MinValue ? (object) DBNull.Value : obj) : (string.Compare("timespan", obj.GetType().Name, true) == 0 ? (ISConvert.ToTimeSpam(obj) <= TimeSpan.MinValue ? (object) DBNull.Value : obj) : (string.Compare("boolean", obj.GetType().Name, true) == 0 && !ISConvert.ToNullableBoolean(obj).HasValue ? (object) DBNull.Value : obj)))));
    }

    public static string ToNullableString(object obj) => obj != null && !string.IsNullOrEmpty(obj.ToString()) ? obj.ToString().Trim() : (string) null;

    public static int? ToNullableInteger(object obj)
    {
      int result = 0;
      if (obj == null)
        return new int?();
      if (int.TryParse(obj.ToString(), out result))
        return new int?(result);
      if (ISConvert.ToString(obj).ToLower() == "true")
        return new int?(1);
      return ISConvert.ToString(obj).ToLower() == "false" ? new int?(0) : new int?();
    }

    public static double? ToNullableDouble(object obj)
    {
      double result = 0.0;
      return obj != null && double.TryParse(obj.ToString(), out result) ? new double?(result) : new double?();
    }

    public static Decimal? ToNullableDecimal(object obj)
    {
      Decimal result = 0M;
      return obj != null && Decimal.TryParse(obj.ToString(), out result) ? new Decimal?(result) : new Decimal?();
    }

    public static bool? ToNullableBoolean(object obj)
    {
      if (obj == null)
        return new bool?();
      bool result;
      if (bool.TryParse(obj.ToString().ToLower(), out result))
        return new bool?(result);
      if (ISConvert.ToString(obj) == "1")
        return new bool?(true);
      return ISConvert.ToString(obj) == "0" ? new bool?(false) : new bool?();
    }

    public static DateTime? ToNullableDateTime(object obj)
    {
      CultureInfo provider = new CultureInfo("es-es");
      DateTime result = DateTime.MinValue;
      return obj != null && DateTime.TryParse(obj.ToString(), (IFormatProvider) provider, DateTimeStyles.None, out result) ? new DateTime?(result) : new DateTime?();
    }

    public static DateTime? ToNullableDateTimeEnd(object obj)
    {
      CultureInfo provider = new CultureInfo("es-es");
      DateTime result = DateTime.MinValue;
      return obj != null && !obj.ToString().Trim().Equals(string.Empty) && DateTime.TryParse(obj.ToString() + " 23:59:59", (IFormatProvider) provider, DateTimeStyles.None, out result) ? new DateTime?(result) : new DateTime?();
    }

    public static TimeSpan? ToNullableTimeSpam(object obj)
    {
      TimeSpan result = new TimeSpan();
      return obj != null && TimeSpan.TryParse(obj.ToString(), out result) ? new TimeSpan?(result) : new TimeSpan?();
    }

    public static string[] ToStringArray(string strValue, char chrSeparator)
    {
      if (string.IsNullOrEmpty(strValue))
        return new string[0];
      return strValue.Split(chrSeparator);
    }

    public static string ToStringBoolean(object obj)
    {
      bool result;
      return obj != null && bool.TryParse(obj.ToString().ToLower(), out result) && result ? "Si" : "No";
    }

    public static string ToStringSplit(object obj, int indice, string separador)
    {
      if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
      {
        string[] strArray = obj.ToString().Split(new string[1]
        {
          separador
        }, StringSplitOptions.RemoveEmptyEntries);
        if (strArray.Length > indice)
          return strArray[indice];
      }
      return string.Empty;
    }
  }
}
