// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.IntercambiaDocRequestBody
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace App.Infrastructure.HSMService
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DataContract(Namespace = "http://www.e-sign.cl/")]
  public class IntercambiaDocRequestBody
  {
    [DataMember(EmitDefaultValue = false, Order = 0)]
    public EncabezadoRequest Encabezado;
    [DataMember(EmitDefaultValue = false, Order = 1)]
    public DocumentoParametro Parametro;

    public IntercambiaDocRequestBody()
    {
    }

    public IntercambiaDocRequestBody(EncabezadoRequest Encabezado, DocumentoParametro Parametro)
    {
      this.Encabezado = Encabezado;
      this.Parametro = Parametro;
    }
  }
}
