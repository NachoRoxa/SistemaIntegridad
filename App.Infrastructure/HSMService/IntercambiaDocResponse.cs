// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.IntercambiaDocResponse
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace App.Infrastructure.HSMService
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = false)]
  public class IntercambiaDocResponse
  {
    [MessageBodyMember(Name = "IntercambiaDocResponse", Namespace = "http://www.e-sign.cl/", Order = 0)]
    public IntercambiaDocResponseBody Body;

    public IntercambiaDocResponse()
    {
    }

    public IntercambiaDocResponse(IntercambiaDocResponseBody Body) => this.Body = Body;
  }
}
