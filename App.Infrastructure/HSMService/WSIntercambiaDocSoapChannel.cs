// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.WSIntercambiaDocSoapChannel
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace App.Infrastructure.HSMService
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public interface WSIntercambiaDocSoapChannel : 
    WSIntercambiaDocSoap,
    IClientChannel,
    IContextChannel,
    IChannel,
    ICommunicationObject,
    IExtensibleObject<IContextChannel>,
    IDisposable
  {
  }
}
