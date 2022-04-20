// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.Email.Email
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Entities.Core;
using App.Core.Interfaces;
using System;
using System.Net.Mail;

namespace App.Infrastructure.Email
{
  public class Email : IEmail
  {
    public void NotificarInicioProceso(
      Proceso proceso,
      Configuracion plantillaCorreo,
      Configuracion asunto)
    {
      if (plantillaCorreo == null || plantillaCorreo != null && string.IsNullOrWhiteSpace(plantillaCorreo.Valor))
        throw new Exception("No existe la plantilla de notificación de tareas");
      if (asunto == null || asunto != null && string.IsNullOrWhiteSpace(asunto.Valor))
        throw new Exception("No se ha configurado el asunto de los correos electrónicos");
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Id]", proceso.ProcesoId.ToString());
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Proceso]", proceso.DefinicionProceso.Nombre);
      SmtpClient smtpClient = new SmtpClient();
      MailMessage mailMessage = new MailMessage()
      {
        IsBodyHtml = true,
        Body = plantillaCorreo.Valor,
        Subject = asunto.Valor,
        To = {
          proceso.Email
        }
      };
    }

    public void NotificarCambioWorkflow(
      Workflow workflow,
      Configuracion plantillaCorreo,
      Configuracion asunto)
    {
      if (plantillaCorreo == null || plantillaCorreo != null && string.IsNullOrWhiteSpace(plantillaCorreo.Valor))
        throw new Exception("No existe la plantilla de notificación de tareas");
      if (asunto == null || asunto != null && string.IsNullOrWhiteSpace(asunto.Valor))
        throw new Exception("No se ha configurado el asunto de los correos electrónicos");
      Configuracion configuracion = plantillaCorreo;
      string valor = plantillaCorreo.Valor;
      int num = workflow.WorkflowId;
      string newValue = num.ToString();
      string str = valor.Replace("[Id]", newValue);
      configuracion.Valor = str;
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Proceso]", workflow.DefinicionWorkflow.DefinicionProceso.Nombre);
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Tarea]", workflow.DefinicionWorkflow.Nombre);
      if (plantillaCorreo.Valor.Contains("[Estado]"))
      {
        int? tipoAprobacionId = workflow.TipoAprobacionId;
        num = 2;
        if (tipoAprobacionId.GetValueOrDefault() == num & tipoAprobacionId.HasValue)
          plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Estado]", "Aprobado");
      }
      if (plantillaCorreo.Valor.Contains("[Estado]"))
      {
        int? tipoAprobacionId = workflow.TipoAprobacionId;
        num = 3;
        if (tipoAprobacionId.GetValueOrDefault() == num & tipoAprobacionId.HasValue)
          plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Estado]", "Rechazado");
      }
      SmtpClient smtpClient = new SmtpClient();
      MailMessage mailMessage = new MailMessage();
      mailMessage.IsBodyHtml = true;
      mailMessage.Body = plantillaCorreo.Valor;
      mailMessage.Subject = asunto.Valor;
      num = workflow.DefinicionWorkflow.TipoEjecucionId;
      switch (num)
      {
        case 1:
        case 2:
        case 3:
          mailMessage.To.Add(workflow.Email);
          break;
      }
    }

    public void NotificarRespuestaSIAC(
      Proceso proceso,
      Configuracion plantillaCorreo,
      Configuracion asunto)
    {
      if (plantillaCorreo == null || plantillaCorreo != null && string.IsNullOrWhiteSpace(plantillaCorreo.Valor))
        throw new Exception("No existe la plantilla de notificación de tareas");
      if (asunto == null || asunto != null && string.IsNullOrWhiteSpace(asunto.Valor))
        throw new Exception("No se ha configurado el asunto de los correos electrónicos");
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Id]", proceso.ProcesoId.ToString());
      plantillaCorreo.Valor = plantillaCorreo.Valor.Replace("[Proceso]", proceso.DefinicionProceso.Nombre);
      SmtpClient smtpClient = new SmtpClient();
      MailMessage mailMessage = new MailMessage()
      {
        IsBodyHtml = true,
        Body = plantillaCorreo.Valor,
        Subject = asunto.Valor,
        To = {
          proceso.Email
        }
      };
    }
  }
}
