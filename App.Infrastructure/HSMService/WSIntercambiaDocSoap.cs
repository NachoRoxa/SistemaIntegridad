// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.WSIntercambiaDocSoap
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace App.Infrastructure.HSMService
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "HSMService.WSIntercambiaDocSoap", Namespace = "http://www.e-sign.cl/")]
  public interface WSIntercambiaDocSoap
  {
    [OperationContract(Action = "http://www.e-sign.cl/IntercambiaDoc", ReplyAction = "*")]
    IntercambiaDocResponse IntercambiaDoc(IntercambiaDocRequest request);

    [OperationContract(Action = "http://www.e-sign.cl/IntercambiaDoc", ReplyAction = "*")]
    Task<IntercambiaDocResponse> IntercambiaDocAsync(
      IntercambiaDocRequest request);

    [OperationContract(Action = "http://www.e-sign.cl/MantencionDeSistema", ReplyAction = "*")]
    MantencionDeSistemaResponse MantencionDeSistema(
      MantencionDeSistemaRequest request);

    [OperationContract(Action = "http://www.e-sign.cl/MantencionDeSistema", ReplyAction = "*")]
    Task<MantencionDeSistemaResponse> MantencionDeSistemaAsync(
      MantencionDeSistemaRequest request);
  }
}
