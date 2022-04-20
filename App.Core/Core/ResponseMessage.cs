// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.ResponseMessage
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.Collections.Generic;
using System.Linq;

namespace App.Core.Entities.Core
{
  public class ResponseMessage
  {
    public List<string> Errors { get; private set; }

    public bool IsValid
    {
      get => !this.Errors.Any<string>();
      set
      {
      }
    }

    public int EntityId { get; set; }

    public ResponseMessage() => this.Errors = new List<string>();
  }
}
