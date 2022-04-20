// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.WSIntercambiaDocSoapClient
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace App.Infrastructure.HSMService
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class WSIntercambiaDocSoapClient : ClientBase<WSIntercambiaDocSoap>, WSIntercambiaDocSoap
  {
    public WSIntercambiaDocSoapClient()
    {
    }

    public WSIntercambiaDocSoapClient(string endpointConfigurationName)
      : base(endpointConfigurationName)
    {
    }

    public WSIntercambiaDocSoapClient(string endpointConfigurationName, string remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public WSIntercambiaDocSoapClient(
      string endpointConfigurationName,
      EndpointAddress remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public WSIntercambiaDocSoapClient(Binding binding, EndpointAddress remoteAddress)
      : base(binding, remoteAddress)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    IntercambiaDocResponse WSIntercambiaDocSoap.IntercambiaDoc(
      IntercambiaDocRequest request)
    {
      return this.Channel.IntercambiaDoc(request);
    }

    public EncabezadoResponse IntercambiaDoc(
      EncabezadoRequest Encabezado,
      DocumentoParametro Parametro)
    {
      IntercambiaDocRequest request = new IntercambiaDocRequest()
      {
        Body = new IntercambiaDocRequestBody()
      };
      request.Body.Encabezado = Encabezado;
      request.Body.Parametro = Parametro;
      return ((WSIntercambiaDocSoap) this).IntercambiaDoc(request).Body.IntercambiaDocResult;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    Task<IntercambiaDocResponse> WSIntercambiaDocSoap.IntercambiaDocAsync(
      IntercambiaDocRequest request)
    {
      return this.Channel.IntercambiaDocAsync(request);
    }

    public Task<IntercambiaDocResponse> IntercambiaDocAsync(
      EncabezadoRequest Encabezado,
      DocumentoParametro Parametro)
    {
      IntercambiaDocRequest request = new IntercambiaDocRequest()
      {
        Body = new IntercambiaDocRequestBody()
      };
      request.Body.Encabezado = Encabezado;
      request.Body.Parametro = Parametro;
      return ((WSIntercambiaDocSoap) this).IntercambiaDocAsync(request);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    MantencionDeSistemaResponse WSIntercambiaDocSoap.MantencionDeSistema(
      MantencionDeSistemaRequest request)
    {
      return this.Channel.MantencionDeSistema(request);
    }

    public string MantencionDeSistema() => ((WSIntercambiaDocSoap) this).MantencionDeSistema(new MantencionDeSistemaRequest()
    {
      Body = new MantencionDeSistemaRequestBody()
    }).Body.MantencionDeSistemaResult;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    Task<MantencionDeSistemaResponse> WSIntercambiaDocSoap.MantencionDeSistemaAsync(
      MantencionDeSistemaRequest request)
    {
      return this.Channel.MantencionDeSistemaAsync(request);
    }

    public Task<MantencionDeSistemaResponse> MantencionDeSistemaAsync() => ((WSIntercambiaDocSoap) this).MantencionDeSistemaAsync(new MantencionDeSistemaRequest()
    {
      Body = new MantencionDeSistemaRequestBody()
    });
  }
}
