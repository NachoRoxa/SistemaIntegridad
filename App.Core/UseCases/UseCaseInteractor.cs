// Decompiled with JetBrains decompiler
// Type: App.Core.UseCases.UseCaseInteractor
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: D:\Users\IROCHA\Documents\Projects\BackUps\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Cometido;
using App.Core.Entities.Core;
using App.Core.Entities.FlujosIntegridad;
using App.Core.Entities.GestionDocumental;
using App.Core.Entities.Pasajes;
using App.Core.Entities.Shared;
using App.Core.Entities.SIAC;
using App.Core.Entities.SIGPER;
using App.Core.Interfaces;
using FluentDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace App.Core.UseCases
{
  public class UseCaseInteractor
  {
    protected readonly IGestionProcesos _repository;
    protected readonly IEmail _email;
    protected readonly IHSM _hsm;
    protected readonly ISIGPER _sigper;
    protected readonly IFile _file;

    public UseCaseInteractor(IGestionProcesos repositoryGestionProcesos, IHSM hsm)
    {
      this._repository = repositoryGestionProcesos;
      this._hsm = hsm;
    }

    public UseCaseInteractor(IGestionProcesos repositoryGestionProcesos) => this._repository = repositoryGestionProcesos;

    public UseCaseInteractor(IGestionProcesos repository, ISIGPER sigper)
    {
      this._repository = repository;
      this._sigper = sigper;
    }

    public UseCaseInteractor(IGestionProcesos repository, IEmail email)
    {
      this._repository = repository;
      this._email = email;
    }

    public UseCaseInteractor(IGestionProcesos repository, IEmail email, ISIGPER sigper)
    {
      this._repository = repository;
      this._email = email;
      this._sigper = sigper;
    }

    public UseCaseInteractor(IGestionProcesos repository, IFile file)
    {
      this._repository = repository;
      this._file = file;
    }

    public ResponseMessage DefinicionProcesoInsert(App.Core.Entities.Core.DefinicionProceso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      if (string.IsNullOrEmpty(obj.Nombre))
        responseMessage.Errors.Add("Debe especificar el nombre");
      if (string.IsNullOrEmpty(obj.Descripcion))
        responseMessage.Errors.Add("Debe especificar la descripción");
      if (obj.DuracionHoras <= 0)
        responseMessage.Errors.Add("La duración debe ser mayor a 0");
      if (!responseMessage.IsValid)
        return responseMessage;
      this._repository.Create<App.Core.Entities.Core.DefinicionProceso>(obj);
      this._repository.Save();
      return responseMessage;
    }

    public ResponseMessage DefinicionProcesoUpdate(App.Core.Entities.Core.DefinicionProceso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (string.IsNullOrEmpty(obj.Descripcion))
          responseMessage.Errors.Add("Debe especificar la descripción");
        if (obj.DuracionHoras <= 0)
          responseMessage.Errors.Add("La duración debe ser mayor a 0");
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.Core.DefinicionProceso>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DefinicionProcesoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.Core.DefinicionProceso byId = this._repository.GetById<App.Core.Entities.Core.DefinicionProceso>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (byId != null && byId.Procesos.Any<Proceso>())
          responseMessage.Errors.Add("La definición de proceso no puede ser eliminada ya que tiene procesos asociados");
        foreach (DefinicionWorkflow entity in byId.DefinicionWorkflows.ToList<DefinicionWorkflow>())
          this._repository.Delete<DefinicionWorkflow>(entity);
        if (responseMessage.IsValid)
        {
          this._repository.Delete<App.Core.Entities.Core.DefinicionProceso>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DefinicionWorkflowInsert(DefinicionWorkflow obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          int? nullable;
          if (obj.Pl_UndCod.HasValue)
          {
            ISIGPER sigper = this._sigper;
            nullable = obj.Pl_UndCod;
            int codigo = nullable.Value;
            PLUNILAB unidad = sigper.GetUnidad(codigo);
            if (unidad != null)
            {
              obj.Pl_UndCod = new int?(unidad.Pl_UndCod);
              obj.Pl_UndDes = unidad.Pl_UndDes;
            }
          }
          nullable = obj.GrupoId;
          if (nullable.HasValue)
            obj.Grupo = this._repository.GetById<App.Core.Entities.Core.Grupo>((object) obj.GrupoId);
          obj.Habilitado = true;
          this._repository.Create<DefinicionWorkflow>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DefinicionWorkflowUpdate(DefinicionWorkflow obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          int? nullable1;
          if (obj.TipoEjecucionId == 5)
          {
            if (obj.Pl_UndCod.HasValue)
            {
              ISIGPER sigper = this._sigper;
              nullable1 = obj.Pl_UndCod;
              int codigo = nullable1.Value;
              PLUNILAB unidad = sigper.GetUnidad(codigo);
              if (unidad != null)
              {
                obj.Pl_UndCod = new int?(unidad.Pl_UndCod);
                obj.Pl_UndDes = unidad.Pl_UndDes;
              }
            }
            nullable1 = obj.GrupoId;
            if (nullable1.HasValue)
              obj.Grupo = this._repository.GetById<App.Core.Entities.Core.Grupo>((object) obj.GrupoId);
            obj.Email = (string) null;
          }
          if (obj.TipoEjecucionId == 6)
          {
            DefinicionWorkflow definicionWorkflow = obj;
            nullable1 = new int?();
            int? nullable2 = nullable1;
            definicionWorkflow.GrupoId = nullable2;
            App.Core.Entities.SIGPER.SIGPER userByEmail = this._sigper.GetUserByEmail(obj.Email);
            if (userByEmail != null)
            {
              obj.Pl_UndCod = new int?(userByEmail.Unidad.Pl_UndCod);
              obj.Pl_UndDes = userByEmail.Unidad.Pl_UndDes;
              obj.Email = userByEmail.Funcionario.Rh_Mail.Trim();
            }
          }
          this._repository.Update<DefinicionWorkflow>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DefinicionWorkflowDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        DefinicionWorkflow byId = this._repository.GetById<DefinicionWorkflow>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          byId.Habilitado = false;
          this._repository.Update<DefinicionWorkflow>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GrupoInsert(App.Core.Entities.Core.Grupo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Create<App.Core.Entities.Core.Grupo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GrupoUpdate(App.Core.Entities.Core.Grupo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.Core.Grupo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GrupoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.Core.Grupo byId = this._repository.GetById<App.Core.Entities.Core.Grupo>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          foreach (Usuario usuario in byId.Usuarios.ToList<Usuario>())
            usuario.Habilitado = false;
          this._repository.Delete<App.Core.Entities.Core.Grupo>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ProcesoInsert(Proceso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (!this._repository.GetExists<App.Core.Entities.Core.DefinicionProceso>((Expression<Func<App.Core.Entities.Core.DefinicionProceso, bool>>) (q => q.DefinicionProcesoId == obj.DefinicionProcesoId)))
          throw new ArgumentNullException("No se encontró la definición del proceso");
        if (string.IsNullOrWhiteSpace(obj.Email))
          throw new ArgumentNullException("No se encontró el usuario que ejecutó el workflow.");
        App.Core.Entities.Core.DefinicionProceso byId = this._repository.GetById<App.Core.Entities.Core.DefinicionProceso>((object) obj.DefinicionProcesoId);
        if (byId == null)
          throw new ArgumentNullException("No se encontró la definición proceso.");
        DefinicionWorkflow definicionWorkflow = this._repository.Get<DefinicionWorkflow>((Expression<Func<DefinicionWorkflow, bool>>) (q => q.Habilitado && q.DefinicionProcesoId == obj.DefinicionProcesoId)).OrderBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.Secuencia)).ThenBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.DefinicionWorkflowId)).FirstOrDefault<DefinicionWorkflow>();
        if (definicionWorkflow == null)
          throw new ArgumentNullException("No se encontró la definición de tarea del proceso asociado al workflow.");
        Proceso entity = new Proceso();
        entity.DefinicionProcesoId = obj.DefinicionProcesoId;
        entity.Observacion = obj.Observacion;
        entity.FechaCreacion = DateTime.Now;
        entity.FechaVencimiento = new DateTime?(DateTime.Now.AddBusinessDays(byId.DuracionHoras));
        entity.FechaTermino = new DateTime?();
        entity.Email = obj.Email;
        Workflow workflow = new Workflow();
        workflow.FechaCreacion = DateTime.Now;
        workflow.TipoAprobacionId = new int?(1);
        workflow.Terminada = false;
        workflow.Proceso = entity;
        workflow.DefinicionWorkflow = definicionWorkflow;
        workflow.FechaVencimiento = new DateTime?(DateTime.Now.AddBusinessDays(definicionWorkflow.DefinicionProceso.DuracionHoras));
        App.Core.Entities.SIGPER.SIGPER sigper = new App.Core.Entities.SIGPER.SIGPER();
        switch (definicionWorkflow.TipoEjecucionId)
        {
          case 2:
            App.Core.Entities.SIGPER.SIGPER userByEmail1 = this._sigper.GetUserByEmail(entity.Email);
            if (userByEmail1.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail1.Funcionario.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail1.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail1.Unidad.Pl_UndDes;
            break;
          case 3:
            App.Core.Entities.SIGPER.SIGPER userByEmail2 = this._sigper.GetUserByEmail(entity.Email);
            if (userByEmail2.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail2.Jefatura.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail2.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail2.Unidad.Pl_UndDes;
            break;
          case 5:
            workflow.GrupoId = definicionWorkflow.GrupoId;
            workflow.Pl_UndCod = definicionWorkflow.Pl_UndCod;
            workflow.Pl_UndDes = definicionWorkflow.Pl_UndDes;
            break;
          case 6:
            App.Core.Entities.SIGPER.SIGPER userByEmail3 = this._sigper.GetUserByEmail(definicionWorkflow.Email);
            if (userByEmail3.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail3.Funcionario.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail3.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail3.Unidad.Pl_UndDes.Trim();
            break;
        }
        entity.Workflows.Add(workflow);
        this._repository.Create<Proceso>(entity);
        this._repository.Save();
        responseMessage.EntityId = entity.ProcesoId;
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
        responseMessage.Errors.Add(ex.InnerException.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ProcesoConsultaInsert(Proceso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (!this._repository.GetExists<App.Core.Entities.Core.DefinicionProceso>((Expression<Func<App.Core.Entities.Core.DefinicionProceso, bool>>) (q => q.DefinicionProcesoId == obj.DefinicionProcesoId)))
          throw new ArgumentNullException("No se encontró la definición del proceso");
        App.Core.Entities.Core.DefinicionProceso byId = this._repository.GetById<App.Core.Entities.Core.DefinicionProceso>((object) obj.DefinicionProcesoId);
        if (byId == null)
          throw new ArgumentNullException("No se encontró la definición proceso.");
        DefinicionWorkflow definicionWorkflow = this._repository.Get<DefinicionWorkflow>((Expression<Func<DefinicionWorkflow, bool>>) (q => q.Habilitado && q.DefinicionProcesoId == obj.DefinicionProcesoId)).OrderBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.Secuencia)).ThenBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.DefinicionWorkflowId)).FirstOrDefault<DefinicionWorkflow>();
        if (definicionWorkflow == null)
          throw new ArgumentNullException("No se encontró la definición de tarea del proceso asociado al workflow.");
        Proceso entity = new Proceso();
        entity.DefinicionProcesoId = obj.DefinicionProcesoId;
        entity.Observacion = obj.Observacion;
        entity.FechaCreacion = DateTime.Now;
        entity.FechaVencimiento = new DateTime?(DateTime.Now.AddBusinessDays(byId.DuracionHoras));
        entity.FechaTermino = new DateTime?();
        Workflow workflow = new Workflow();
        workflow.FechaCreacion = DateTime.Now;
        workflow.TipoAprobacionId = new int?(1);
        workflow.Terminada = false;
        workflow.Proceso = entity;
        workflow.DefinicionWorkflow = definicionWorkflow;
        workflow.FechaVencimiento = new DateTime?(DateTime.Now.AddBusinessDays(definicionWorkflow.DefinicionProceso.DuracionHoras));
        App.Core.Entities.SIGPER.SIGPER sigper = new App.Core.Entities.SIGPER.SIGPER();
        switch (definicionWorkflow.TipoEjecucionId)
        {
          case 2:
            App.Core.Entities.SIGPER.SIGPER userByEmail1 = this._sigper.GetUserByEmail(entity.Email);
            if (userByEmail1.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail1.Funcionario.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail1.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail1.Unidad.Pl_UndDes;
            break;
          case 3:
            App.Core.Entities.SIGPER.SIGPER userByEmail2 = this._sigper.GetUserByEmail(entity.Email);
            if (userByEmail2.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail2.Jefatura.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail2.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail2.Unidad.Pl_UndDes;
            break;
          case 5:
            workflow.GrupoId = definicionWorkflow.GrupoId;
            workflow.Pl_UndCod = definicionWorkflow.Pl_UndCod;
            workflow.Pl_UndDes = definicionWorkflow.Pl_UndDes;
            break;
          case 6:
            sigper = this._sigper.GetUserByEmail(definicionWorkflow.Email);
            App.Core.Entities.SIGPER.SIGPER userByEmail3;
            try
            {
              userByEmail3 = this._sigper.GetUserByEmail(definicionWorkflow.Email);
            }
            catch (Exception ex)
            {
              throw new Exception("Error al conectar con SIGPER");
            }
            if (userByEmail3.Funcionario == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow.Email = userByEmail3.Funcionario.Rh_Mail.Trim();
            workflow.Pl_UndCod = new int?(userByEmail3.Unidad.Pl_UndCod);
            workflow.Pl_UndDes = userByEmail3.Unidad.Pl_UndDes.Trim();
            break;
        }
        entity.Workflows.Add(workflow);
        this._repository.Create<Consulta>(new Consulta()
        {
          CampoPrivacidad = obj.Denuncia.CampoPrivacidad,
          Ciudad = obj.Denuncia.Ciudad,
          CodigoPostal = obj.Denuncia.CodigoPostal,
          Comuna = obj.Denuncia.Comuna,
          DeptoOficina = obj.Denuncia.DeptoOficina,
          Descripcion = obj.Denuncia.Descripcion,
          Direccion = obj.Denuncia.Direccion,
          DV = obj.Denuncia.DV,
          Email = obj.Denuncia.Email,
          Fecha = obj.Denuncia.Fecha,
          Nombre = obj.Denuncia.Nombre,
          Numero = obj.Denuncia.Numero,
          Region = obj.Denuncia.Region,
          Rut = obj.Denuncia.Rut,
          TipoRespuesta = obj.Denuncia.TipoRespuesta,
          Proceso = entity,
          Workflow = workflow
        });
        this._repository.Create<Proceso>(entity);
        this._repository.Save();
        responseMessage.EntityId = entity.ProcesoId;
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add("Metodo caso de uso => " + ex.Message);
        responseMessage.Errors.Add("Metodo caso de uso => " + (object) ex.InnerException);
      }
      return responseMessage;
    }

    public ResponseMessage ProcesoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Proceso byId = this._repository.GetById<Proceso>((object) id);
        if (responseMessage.IsValid)
        {
          foreach (Workflow workflow in byId.Workflows.Where<Workflow>((Func<Workflow, bool>) (q => !q.Terminada)))
          {
            workflow.FechaTermino = new DateTime?(DateTime.Now);
            workflow.Terminada = true;
            workflow.Anulada = true;
          }
          byId.FechaTermino = new DateTime?(DateTime.Now);
          byId.Terminada = true;
          byId.Anulada = true;
          this._repository.Save();
          this._email.NotificarInicioProceso(byId, this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 9), this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 2));
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WorkflowUpdate(Workflow obj)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UseCaseInteractor.c__DisplayClass23_0 cDisplayClass230 = new UseCaseInteractor.c__DisplayClass23_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass230.obj = obj;
      ResponseMessage responseMessage = new ResponseMessage();
      App.Core.Entities.SIGPER.SIGPER sigper1 = new App.Core.Entities.SIGPER.SIGPER();
      try
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1 cDisplayClass231 = new UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1();
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass230.obj == null)
          throw new Exception("Debe especificar un workflow.");
        // ISSUE: reference to a compiler-generated field
        Workflow workflow1 = this._repository.GetFirst<Workflow>((Expression<Func<Workflow, bool>>) (q => q.WorkflowId == cDisplayClass230.obj.WorkflowId)) ?? (Workflow) null;
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual = workflow1;
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual == null)
          throw new Exception("No se encontró el workflow.");
        // ISSUE: reference to a compiler-generated field
        IOrderedEnumerable<DefinicionWorkflow> source = this._repository.Get<DefinicionWorkflow>((Expression<Func<DefinicionWorkflow, bool>>) (q => q.Habilitado && q.DefinicionProcesoId == cDisplayClass231.workflowActual.Proceso.DefinicionProcesoId)).OrderBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.Secuencia)).ThenBy<DefinicionWorkflow, int>((Func<DefinicionWorkflow, int>) (q => q.DefinicionWorkflowId)) ?? (IOrderedEnumerable<DefinicionWorkflow>) null;
        if (!source.Any<DefinicionWorkflow>())
          throw new Exception("No se encontró la definición de tarea del proceso asociado al workflow.");
        // ISSUE: reference to a compiler-generated field
        if (string.IsNullOrWhiteSpace(cDisplayClass230.obj.Email))
          throw new Exception("No se encontró el usuario que ejecutó el workflow.");
        int? nullable;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual.DefinicionWorkflow != null && cDisplayClass231.workflowActual.DefinicionWorkflow.RequiereAprobacionAlEnviar)
        {
          // ISSUE: reference to a compiler-generated field
          nullable = cDisplayClass230.obj.TipoAprobacionId;
          if (nullable.HasValue)
          {
            // ISSUE: reference to a compiler-generated field
            nullable = cDisplayClass230.obj.TipoAprobacionId;
            int num = 0;
            if (!(nullable.GetValueOrDefault() == num & nullable.HasValue))
              goto label_13;
          }
          throw new Exception("La tarea requiere aprobación.");
        }
label_13:
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual != null && cDisplayClass231.workflowActual.DefinicionWorkflow != null && cDisplayClass231.workflowActual.DefinicionWorkflow.RequireDocumentacion && cDisplayClass231.workflowActual.Proceso != null && !cDisplayClass231.workflowActual.Proceso.Documentos.Any<Documento>())
          throw new Exception("Debe adjuntar documentos.");
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual != null && cDisplayClass231.workflowActual.DefinicionWorkflow != null && cDisplayClass231.workflowActual.DefinicionWorkflow.RequiereObservacion && cDisplayClass231.workflowActual.Proceso != null && !cDisplayClass231.workflowActual.Proceso.Documentos.Any<Documento>() && string.IsNullOrEmpty(cDisplayClass230.obj.Observacion))
          throw new Exception("Requiere Observaciones.");
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.FechaTermino = new DateTime?(DateTime.Now);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.Observacion = cDisplayClass230.obj.Observacion;
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.Terminada = true;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.Pl_UndCod = cDisplayClass230.obj.Pl_UndCod;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.GrupoId = cDisplayClass230.obj.GrupoId;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.Email = cDisplayClass230.obj.Email;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass231.workflowActual.To = cDisplayClass230.obj.To;
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual.DefinicionWorkflow.RequiereAprobacionAlEnviar)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          cDisplayClass231.workflowActual.TipoAprobacionId = cDisplayClass230.obj.TipoAprobacionId;
        }
        // ISSUE: reference to a compiler-generated field
        if (!cDisplayClass231.workflowActual.DefinicionWorkflow.RequiereAprobacionAlEnviar)
        {
          // ISSUE: reference to a compiler-generated field
          cDisplayClass231.workflowActual.TipoAprobacionId = new int?(2);
        }
        DefinicionWorkflow definicionWorkflow = (DefinicionWorkflow) null;
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass231.workflowActual.DefinicionWorkflow.PermitirMultipleEvaluacion)
        {
          // ISSUE: reference to a compiler-generated field
          definicionWorkflow = this._repository.GetById<DefinicionWorkflow>((object) cDisplayClass231.workflowActual.DefinicionWorkflowId);
        }
        // ISSUE: reference to a compiler-generated field
        if (!cDisplayClass231.workflowActual.DefinicionWorkflow.PermitirMultipleEvaluacion)
        {
          // ISSUE: reference to a compiler-generated field
          nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
          int num = 2;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__5)) : source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__4));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!(cDisplayClass231.workflowActual.DefinicionWorkflow.Entidad.Codigo == App.Core.Enum.Enum.Entidad.Cometido.ToString()) && !(cDisplayClass231.workflowActual.DefinicionWorkflow.Entidad.Codigo == App.Core.Enum.Enum.Entidad.Pasaje.ToString()))
        {
          // ISSUE: reference to a compiler-generated field
          if (cDisplayClass231.workflowActual.DefinicionWorkflow.Entidad.Codigo == App.Core.Enum.Enum.Entidad.Denuncia.ToString())
          {
            Denuncia denuncia = new Denuncia();
            IGestionProcesos repository = this._repository;
            // ISSUE: reference to a compiler-generated field
            Expression<Func<Denuncia, bool>> filter = (Expression<Func<Denuncia, bool>>) (q => q.WorkflowId == (int?) cDisplayClass230.obj.WorkflowId);
            nullable = new int?();
            int? skip = nullable;
            nullable = new int?();
            int? take = nullable;
            // ISSUE: reference to a compiler-generated field
            if (repository.Get<Denuncia>(filter, skip: skip, take: take).FirstOrDefault<Denuncia>() != null && !cDisplayClass231.workflowActual.DefinicionWorkflow.PermitirMultipleEvaluacion)
            {
              // ISSUE: reference to a compiler-generated field
              if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 5)
              {
                // ISSUE: reference to a compiler-generated field
                nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                int num = 2;
                definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 7)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 6));
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 2)
                {
                  // ISSUE: reference to a compiler-generated field
                  nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                  int num = 2;
                  definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 1)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 3));
                }
                else
                {
                  // ISSUE: reference to a compiler-generated method
                  definicionWorkflow = source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__13));
                }
              }
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (cDisplayClass231.workflowActual.DefinicionWorkflow.Entidad.Codigo == App.Core.Enum.Enum.Entidad.Consulta.ToString())
            {
              Consulta consulta = new Consulta();
              IGestionProcesos repository = this._repository;
              // ISSUE: reference to a compiler-generated field
              Expression<Func<Consulta, bool>> filter = (Expression<Func<Consulta, bool>>) (q => q.WorkflowId == (int?) cDisplayClass230.obj.WorkflowId);
              nullable = new int?();
              int? skip = nullable;
              nullable = new int?();
              int? take = nullable;
              // ISSUE: reference to a compiler-generated field
              if (repository.Get<Consulta>(filter, skip: skip, take: take).FirstOrDefault<Consulta>() != null && !cDisplayClass231.workflowActual.DefinicionWorkflow.PermitirMultipleEvaluacion)
              {
                // ISSUE: reference to a compiler-generated field
                if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 2)
                {
                  // ISSUE: reference to a compiler-generated field
                  nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                  int num = 2;
                  definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 1)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 3));
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 5)
                  {
                    // ISSUE: reference to a compiler-generated field
                    nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                    int num = 2;
                    definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 4)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 6));
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated method
                    definicionWorkflow = source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__19));
                  }
                }
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              if (cDisplayClass231.workflowActual.DefinicionWorkflow.Entidad.Codigo == App.Core.Enum.Enum.Entidad.WebConsulta.ToString())
              {
                WebConsulta webConsulta = new WebConsulta();
                IGestionProcesos repository = this._repository;
                // ISSUE: reference to a compiler-generated field
                Expression<Func<WebConsulta, bool>> filter = (Expression<Func<WebConsulta, bool>>) (q => q.WorkflowId == (int?) cDisplayClass230.obj.WorkflowId);
                nullable = new int?();
                int? skip = nullable;
                nullable = new int?();
                int? take = nullable;
                // ISSUE: reference to a compiler-generated field
                if (repository.Get<WebConsulta>(filter, skip: skip, take: take).FirstOrDefault<WebConsulta>() != null && !cDisplayClass231.workflowActual.DefinicionWorkflow.PermitirMultipleEvaluacion)
                {
                  // ISSUE: reference to a compiler-generated field
                  if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 2)
                  {
                    // ISSUE: reference to a compiler-generated field
                    nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                    int num = 2;
                    definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 6)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 3));
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (cDisplayClass231.workflowActual.DefinicionWorkflow.Secuencia == 5)
                    {
                      // ISSUE: reference to a compiler-generated field
                      nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                      int num = 2;
                      definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 4)) : source.FirstOrDefault<DefinicionWorkflow>((Func<DefinicionWorkflow, bool>) (q => q.Secuencia == 6));
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated method
                      definicionWorkflow = source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__25));
                    }
                  }
                }
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                nullable = cDisplayClass231.workflowActual.TipoAprobacionId;
                int num = 2;
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated method
                definicionWorkflow = !(nullable.GetValueOrDefault() == num & nullable.HasValue) ? source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__7)) : source.FirstOrDefault<DefinicionWorkflow>(new Func<DefinicionWorkflow, bool>(cDisplayClass231.\u003CWorkflowUpdate\u003Eb__6));
              }
            }
          }
        }
        if (definicionWorkflow == null)
        {
          // ISSUE: reference to a compiler-generated field
          cDisplayClass231.workflowActual.Proceso.Terminada = true;
          // ISSUE: reference to a compiler-generated field
          cDisplayClass231.workflowActual.Proceso.FechaTermino = new DateTime?(DateTime.Now);
          this._repository.Save();
        }
        if (definicionWorkflow != null)
        {
          Workflow workflow2 = new Workflow();
          workflow2.FechaCreacion = DateTime.Now;
          workflow2.TipoAprobacionId = new int?(1);
          workflow2.Terminada = false;
          workflow2.DefinicionWorkflow = definicionWorkflow;
          // ISSUE: reference to a compiler-generated field
          workflow2.ProcesoId = cDisplayClass231.workflowActual.ProcesoId;
          // ISSUE: reference to a compiler-generated field
          workflow2.Mensaje = cDisplayClass230.obj.Observacion;
          workflow2.TareaPersonal = false;
          if (definicionWorkflow.TipoEjecucionId == 1)
          {
            // ISSUE: reference to a compiler-generated field
            nullable = cDisplayClass230.obj.Pl_UndCod;
            if (nullable.HasValue)
            {
              ISIGPER sigper2 = this._sigper;
              // ISSUE: reference to a compiler-generated field
              nullable = cDisplayClass230.obj.Pl_UndCod;
              int codigo = nullable.Value;
              PLUNILAB unidad = sigper2.GetUnidad(codigo);
              workflow2.Pl_UndCod = unidad != null ? new int?(unidad.Pl_UndCod) : throw new Exception("No se encontró la unidad en SIGPER.");
              workflow2.Pl_UndDes = unidad.Pl_UndDes;
            }
            // ISSUE: reference to a compiler-generated field
            if (!string.IsNullOrEmpty(cDisplayClass230.obj.To))
            {
              // ISSUE: reference to a compiler-generated field
              workflow2.Email = (this._sigper.GetUserByEmail(cDisplayClass230.obj.To) ?? throw new Exception("No se encontró el usuario en SIGPER.")).Funcionario.Rh_Mail.Trim();
              workflow2.TareaPersonal = true;
            }
          }
          if (definicionWorkflow.TipoEjecucionId == 4)
          {
            IGestionProcesos repository = this._repository;
            ParameterExpression parameterExpression = Expression.Parameter(typeof (Workflow), "q");
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            BinaryExpression left1 = Expression.Equal((Expression) Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_ProcesoId))), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass231, typeof (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1)), FieldInfo.GetFieldFromHandle(__fieldref (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1.workflowActual))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_ProcesoId))));
            // ISSUE: method reference
            BinaryExpression left2 = Expression.NotEqual((Expression) Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_To))), (Expression) Expression.Constant((object) null, typeof (string)));
            // ISSUE: method reference
            MemberExpression left3 = Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_Pl_UndCod)));
            nullable = new int?();
            ConstantExpression right1 = Expression.Constant((object) nullable, typeof (int?));
            BinaryExpression right2 = Expression.NotEqual((Expression) left3, (Expression) right1);
            BinaryExpression right3 = Expression.OrElse((Expression) left2, (Expression) right2);
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            Expression<Func<Workflow, bool>> filter = Expression.Lambda<Func<Workflow, bool>>((Expression) Expression.AndAlso((Expression) Expression.AndAlso((Expression) left1, (Expression) right3), (Expression) Expression.NotEqual((Expression) Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_WorkflowId))), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass231, typeof (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1)), FieldInfo.GetFieldFromHandle(__fieldref (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1.workflowActual))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_WorkflowId))))), parameterExpression);
            nullable = new int?();
            int? skip = nullable;
            nullable = new int?();
            int? take = nullable;
            Workflow workflow3 = repository.Get<Workflow>(filter, skip: skip, take: take).OrderByDescending<Workflow, int>((Func<Workflow, int>) (q => q.WorkflowId)).FirstOrDefault<Workflow>();
            nullable = workflow3 != null ? workflow3.Pl_UndCod : throw new Exception("No se encontró el workflow inicial.");
            if (nullable.HasValue)
            {
              ISIGPER sigper3 = this._sigper;
              nullable = workflow3.Pl_UndCod;
              int codigo = nullable.Value;
              PLUNILAB unidad = sigper3.GetUnidad(codigo);
              workflow2.Pl_UndCod = unidad != null ? new int?(unidad.Pl_UndCod) : throw new Exception("No se encontró la unidad en SIGPER.");
              workflow2.Pl_UndDes = unidad.Pl_UndDes;
            }
            if (!string.IsNullOrEmpty(workflow3.To))
            {
              workflow2.Email = (this._sigper.GetUserByEmail(workflow3.To) ?? throw new Exception("No se encontró el usuario en SIGPER.")).Funcionario.Rh_Mail.Trim();
              workflow2.TareaPersonal = true;
            }
          }
          if (definicionWorkflow.TipoEjecucionId == 8)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            UseCaseInteractor.\u003C\u003Ec__DisplayClass23_2 cDisplayClass232 = new UseCaseInteractor.\u003C\u003Ec__DisplayClass23_2();
            IGestionProcesos repository = this._repository;
            ParameterExpression parameterExpression = Expression.Parameter(typeof (Workflow), "q");
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            BinaryExpression left4 = Expression.Equal((Expression) Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_ProcesoId))), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass231, typeof (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1)), FieldInfo.GetFieldFromHandle(__fieldref (UseCaseInteractor.\u003C\u003Ec__DisplayClass23_1.workflowActual))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_ProcesoId))));
            // ISSUE: method reference
            MemberExpression left5 = Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Workflow.get_EntityId)));
            nullable = new int?();
            ConstantExpression right4 = Expression.Constant((object) nullable, typeof (int?));
            BinaryExpression right5 = Expression.NotEqual((Expression) left5, (Expression) right4);
            Expression<Func<Workflow, bool>> filter = Expression.Lambda<Func<Workflow, bool>>((Expression) Expression.AndAlso((Expression) left4, (Expression) right5), parameterExpression);
            nullable = new int?();
            int? skip = nullable;
            nullable = new int?();
            int? take = nullable;
            Workflow workflow4 = repository.Get<Workflow>(filter, skip: skip, take: take).OrderByDescending<Workflow, int>((Func<Workflow, int>) (q => q.WorkflowId)).FirstOrDefault<Workflow>();
            // ISSUE: reference to a compiler-generated field
            cDisplayClass232.workflowInicial = workflow4;
            // ISSUE: reference to a compiler-generated field
            if (cDisplayClass232.workflowInicial == null)
              throw new Exception("No se encontró el workflow inicial.");
            // ISSUE: reference to a compiler-generated field
            GDIngreso first = this._repository.GetFirst<GDIngreso>((Expression<Func<GDIngreso, bool>>) (q => (int?) q.GDIngresoId == cDisplayClass232.workflowInicial.EntityId));
            if (first == null)
              throw new Exception("No se encontró el ingreso de gestión documental.");
            if (first != null)
            {
              workflow2.Pl_UndCod = first.Pl_UndCod;
              workflow2.Pl_UndDes = first.Pl_UndDes;
              workflow2.Email = first.UsuarioDestino;
              workflow2.TareaPersonal = !string.IsNullOrWhiteSpace(workflow2.Email);
            }
          }
          if (definicionWorkflow.TipoEjecucionId == 2)
          {
            // ISSUE: reference to a compiler-generated field
            App.Core.Entities.SIGPER.SIGPER userByEmail = this._sigper.GetUserByEmail(cDisplayClass231.workflowActual.Proceso.Email);
            if (userByEmail == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow2.Email = userByEmail.Funcionario.Rh_Mail.Trim();
            workflow2.Pl_UndCod = new int?(userByEmail.Unidad.Pl_UndCod);
            workflow2.Pl_UndDes = userByEmail.Unidad.Pl_UndDes;
            workflow2.TareaPersonal = true;
          }
          if (definicionWorkflow.TipoEjecucionId == 3)
          {
            // ISSUE: reference to a compiler-generated field
            App.Core.Entities.SIGPER.SIGPER userByEmail = this._sigper.GetUserByEmail(cDisplayClass231.workflowActual.Proceso.Email);
            if (userByEmail == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow2.Email = userByEmail.Jefatura.Rh_Mail.Trim();
            workflow2.Pl_UndCod = new int?(userByEmail.Unidad.Pl_UndCod);
            workflow2.Pl_UndDes = userByEmail.Unidad.Pl_UndDes;
            workflow2.TareaPersonal = true;
          }
          if (definicionWorkflow.TipoEjecucionId == 7)
          {
            // ISSUE: reference to a compiler-generated field
            App.Core.Entities.SIGPER.SIGPER userByEmail = this._sigper.GetUserByEmail(cDisplayClass230.obj.Email);
            if (userByEmail == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow2.Email = userByEmail.Jefatura.Rh_Mail.Trim();
            workflow2.Pl_UndCod = new int?(userByEmail.Unidad.Pl_UndCod);
            workflow2.Pl_UndDes = userByEmail.Unidad.Pl_UndDes;
            workflow2.TareaPersonal = true;
          }
          if (definicionWorkflow.TipoEjecucionId == 5)
          {
            workflow2.GrupoId = definicionWorkflow.GrupoId;
            workflow2.Pl_UndCod = definicionWorkflow.Pl_UndCod;
            workflow2.Pl_UndDes = definicionWorkflow.Pl_UndDes;
          }
          if (definicionWorkflow.TipoEjecucionId == 6)
          {
            App.Core.Entities.SIGPER.SIGPER userByEmail = this._sigper.GetUserByEmail(definicionWorkflow.Email);
            if (userByEmail == null)
              throw new Exception("No se encontró el usuario en SIGPER.");
            workflow2.Pl_UndCod = new int?(userByEmail.Unidad.Pl_UndCod);
            workflow2.Pl_UndDes = userByEmail.Unidad.Pl_UndDes.Trim();
            workflow2.Email = userByEmail.Funcionario.Rh_Mail.Trim();
            workflow2.TareaPersonal = true;
          }
          this._repository.Create<Workflow>(workflow2);
          this._repository.Save();
          // ISSUE: reference to a compiler-generated field
          if (cDisplayClass231.workflowActual.DefinicionWorkflow.NotificarAlAutor)
          {
            // ISSUE: reference to a compiler-generated field
            this._email.NotificarCambioWorkflow(cDisplayClass231.workflowActual, this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 10), this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 2));
          }
          if (workflow2.DefinicionWorkflow.NotificarAsignacion)
            this._email.NotificarCambioWorkflow(workflow2, this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 1), this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 2));
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WorkflowForward(Workflow obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (obj == null)
          throw new Exception("Debe especificar un workflow.");
        Workflow workflow1 = this._repository.GetFirst<Workflow>((Expression<Func<Workflow, bool>>) (q => q.WorkflowId == obj.WorkflowId)) ?? (Workflow) null;
        if (workflow1 == null)
          throw new Exception("No se encontró el workflow.");
        if (string.IsNullOrWhiteSpace(obj.Email))
          throw new Exception("No se encontró el usuario que ejecutó el workflow.");
        workflow1.FechaTermino = new DateTime?(DateTime.Now);
        workflow1.Observacion = obj.Observacion;
        workflow1.Email = obj.Email;
        workflow1.Terminada = true;
        workflow1.TipoAprobacionId = new int?(2);
        Workflow workflow2 = new Workflow();
        workflow2.FechaCreacion = DateTime.Now;
        workflow2.TipoAprobacionId = new int?(1);
        workflow2.Terminada = false;
        workflow2.DefinicionWorkflow = workflow1.DefinicionWorkflow;
        workflow2.ProcesoId = workflow1.ProcesoId;
        workflow2.Mensaje = obj.Observacion;
        if (obj.Pl_UndCod.HasValue)
        {
          PLUNILAB unidad = this._sigper.GetUnidad(obj.Pl_UndCod.Value);
          workflow2.Pl_UndCod = unidad != null ? new int?(unidad.Pl_UndCod) : throw new Exception("No se encontró la unidad en SIGPER.");
          workflow2.Pl_UndDes = unidad.Pl_UndDes;
        }
        workflow2.Email = obj.To;
        workflow2.GrupoId = obj.GrupoId;
        this._repository.Create<Workflow>(workflow2);
        this._repository.Save();
        if (workflow2.DefinicionWorkflow.NotificarAsignacion)
          this._email.NotificarCambioWorkflow(workflow2, this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 1), this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 2));
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WorkflowArchive(Workflow obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (obj == null)
          throw new Exception("Debe especificar un workflow.");
        Workflow workflow = this._repository.GetFirst<Workflow>((Expression<Func<Workflow, bool>>) (q => q.WorkflowId == obj.WorkflowId)) ?? (Workflow) null;
        if (workflow == null)
          throw new Exception("No se encontró el workflow.");
        if (string.IsNullOrWhiteSpace(obj.Email))
          throw new Exception("No se encontró el usuario que ejecutó el workflow.");
        workflow.FechaTermino = new DateTime?(DateTime.Now);
        workflow.Observacion = obj.Observacion;
        workflow.Email = obj.Email;
        workflow.Terminada = true;
        workflow.TipoAprobacionId = new int?(2);
        workflow.Proceso.Terminada = true;
        workflow.Proceso.FechaTermino = new DateTime?(DateTime.Now);
        this._repository.Save();
        if (workflow.DefinicionWorkflow.NotificarAsignacion)
          this._email.NotificarCambioWorkflow(workflow, this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 7), this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 2));
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConfiguracionInsert(App.Core.Entities.Core.Configuracion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (string.IsNullOrEmpty(obj.Valor))
          responseMessage.Errors.Add("Debe especificar el valor");
        if (responseMessage.IsValid)
        {
          this._repository.Create<App.Core.Entities.Core.Configuracion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConfiguracionUpdate(App.Core.Entities.Core.Configuracion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (string.IsNullOrEmpty(obj.Valor))
          responseMessage.Errors.Add("Debe especificar el valor");
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.Core.Configuracion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage UsuarioInsert(Usuario obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Email))
          responseMessage.Errors.Add("Debe especificar el email");
        if (responseMessage.IsValid)
        {
          this._repository.Create<Usuario>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage UsuarioUpdate(Usuario obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Email))
          responseMessage.Errors.Add("Debe especificar el email");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Usuario>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage UsuarioDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Usuario byId = this._repository.GetById<Usuario>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          byId.Habilitado = false;
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RegionInsert(Region obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Codigo))
          responseMessage.Errors.Add("Debe especificar el código");
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Create<Region>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RegionUpdate(Region obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Codigo))
          responseMessage.Errors.Add("Debe especificar el código");
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Region>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RegionDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Region byId = this._repository.GetById<Region>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Region>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneroInsert(Genero obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Create<Genero>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneroUpdate(Genero obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Genero>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneroDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Genero byId = this._repository.GetById<Genero>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Genero>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RubricaInsert(Rubrica obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Rubrica>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RubricaUpdate(Rubrica obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<Rubrica>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RubricaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Rubrica byId = this._repository.GetById<Rubrica>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Rubrica>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SubsecretariaInsert(Subsecretaria obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Codigo))
          responseMessage.Errors.Add("Debe especificar el código");
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Create<Subsecretaria>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SubsecretariaUpdate(Subsecretaria obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Codigo))
          responseMessage.Errors.Add("Debe especificar el código");
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Subsecretaria>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SubsecretariaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Subsecretaria byId = this._repository.GetById<Subsecretaria>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Subsecretaria>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CuentaRedInsert(App.Core.Entities.CuentaRed.CuentaRed obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          if (obj.Pl_CodCar.HasValue)
          {
            PECARGOS cargo = this._sigper.GetCargo(obj.Pl_CodCar.Value);
            if (cargo != null)
              obj.Pl_DesCar = cargo.Pl_DesCar;
          }
          if (obj.Pl_UndCod.HasValue)
          {
            PLUNILAB unidad = this._sigper.GetUnidad(obj.Pl_UndCod.Value);
            if (unidad != null)
              obj.Pl_UndDes = unidad.Pl_UndDes;
          }
          this._repository.Create<App.Core.Entities.CuentaRed.CuentaRed>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CuentaRedUpdate(App.Core.Entities.CuentaRed.CuentaRed obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          if (obj.Pl_CodCar.HasValue)
          {
            PECARGOS cargo = this._sigper.GetCargo(obj.Pl_CodCar.Value);
            if (cargo != null)
              obj.Pl_DesCar = cargo.Pl_DesCar;
          }
          if (obj.Pl_UndCod.HasValue)
          {
            PLUNILAB unidad = this._sigper.GetUnidad(obj.Pl_UndCod.Value);
            if (unidad != null)
              obj.Pl_UndDes = unidad.Pl_UndDes;
          }
          this._repository.Update<App.Core.Entities.CuentaRed.CuentaRed>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ContratoInsert(App.Core.Entities.Contrato.Contrato obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          if (obj.Pl_CodCar.HasValue)
          {
            PECARGOS cargo = this._sigper.GetCargo(obj.Pl_CodCar.Value);
            if (cargo != null)
              obj.Pl_DesCar = cargo.Pl_DesCar;
          }
          if (obj.Pl_UndCod.HasValue)
          {
            PLUNILAB unidad = this._sigper.GetUnidad(obj.Pl_UndCod.Value);
            if (unidad != null)
              obj.Pl_UndDes = unidad.Pl_UndDes;
          }
          this._repository.Create<App.Core.Entities.Contrato.Contrato>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ContratoCreatePDF(App.Core.Entities.Contrato.Contrato obj)
    {
      ResponseMessage pdf = new ResponseMessage();
      try
      {
        if (pdf.IsValid)
        {
          this._repository.Update<App.Core.Entities.Contrato.Contrato>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        pdf.Errors.Add(ex.Message);
      }
      return pdf;
    }

    public ResponseMessage ContratoUpdate(App.Core.Entities.Contrato.Contrato obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          if (obj.Pl_CodCar.HasValue)
          {
            PECARGOS cargo = this._sigper.GetCargo(obj.Pl_CodCar.Value);
            if (cargo != null)
              obj.Pl_DesCar = cargo.Pl_DesCar;
          }
          if (obj.Pl_UndCod.HasValue)
          {
            PLUNILAB unidad = this._sigper.GetUnidad(obj.Pl_UndCod.Value);
            if (unidad != null)
              obj.Pl_UndDes = unidad.Pl_UndDes;
          }
          this._repository.Update<App.Core.Entities.Contrato.Contrato>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ProgramaInsert(Programa obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Create<Programa>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ProgramaUpdate(Programa obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (string.IsNullOrEmpty(obj.Nombre))
          responseMessage.Errors.Add("Debe especificar el nombre");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Programa>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ProgramaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Programa byId = this._repository.GetById<Programa>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Programa>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DocumentoSign(Documento obj, string email)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Documento byId1 = this._repository.GetById<Documento>((object) obj.DocumentoId);
        if (byId1 == null)
          responseMessage.Errors.Add("Documento no encontrado");
        App.Core.Entities.Core.Configuracion byId2 = this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 4);
        if (byId2 == null)
          responseMessage.Errors.Add("No se encontró la configuración de usuario de HSM.");
        if (byId2 != null && string.IsNullOrWhiteSpace(byId2.Valor))
          responseMessage.Errors.Add("La configuración de usuario de HSM es inválida.");
        App.Core.Entities.Core.Configuracion byId3 = this._repository.GetById<App.Core.Entities.Core.Configuracion>((object) 5);
        if (byId3 == null)
          responseMessage.Errors.Add("No se encontró la configuración de usuario de HSM.");
        if (byId3 != null && string.IsNullOrWhiteSpace(byId3.Valor))
          responseMessage.Errors.Add("La configuración de password de HSM es inválida.");
        if (responseMessage.IsValid)
        {
          byte[] numArray = this._hsm.Sign(byId1.File);
          byId1.File = numArray;
          this._repository.Update<Documento>(byId1);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CDPInsert(App.Core.Entities.CDP.CDP obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<App.Core.Entities.CDP.CDP>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CDPUpdate(App.Core.Entities.CDP.CDP obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.CDP.CDP>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CDPDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.CDP.CDP byId = this._repository.GetById<App.Core.Entities.CDP.CDP>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<App.Core.Entities.CDP.CDP>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage InformeHSAInsert(App.Core.Entities.InformeHSA.InformeHSA obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<App.Core.Entities.InformeHSA.InformeHSA>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage InformeHSAUpdate(App.Core.Entities.InformeHSA.InformeHSA obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.InformeHSA.InformeHSA>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage InformeHSADelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.InformeHSA.InformeHSA byId = this._repository.GetById<App.Core.Entities.InformeHSA.InformeHSA>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<App.Core.Entities.InformeHSA.InformeHSA>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RadioTaxiInsert(App.Core.Entities.RadioTaxi.RadioTaxi obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<App.Core.Entities.RadioTaxi.RadioTaxi>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RadioTaxiUpdate(App.Core.Entities.RadioTaxi.RadioTaxi obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<App.Core.Entities.RadioTaxi.RadioTaxi>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage RadioTaxiDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.RadioTaxi.RadioTaxi byId = this._repository.GetById<App.Core.Entities.RadioTaxi.RadioTaxi>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<App.Core.Entities.RadioTaxi.RadioTaxi>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage IngresoInsert(GDIngreso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          obj.GetFolio();
          obj.BarCode = this._file.CreateBarCode(obj.Folio);
          this._repository.Create<GDIngreso>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage IngresoUpdate(GDIngreso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          obj.GetFolio();
          obj.BarCode = this._file.CreateBarCode(obj.Folio);
          this._repository.Update<GDIngreso>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage IngresoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        GDIngreso byId = this._repository.GetById<GDIngreso>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<GDIngreso>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SIACIngresoInsert(SIACSolicitud obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<SIACSolicitud>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SIACIngresoUpdate(SIACSolicitud obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<SIACSolicitud>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage SIACIngresoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        SIACSolicitud byId = this._repository.GetById<SIACSolicitud>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<SIACSolicitud>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CometidoInsert(App.Core.Entities.Cometido.Cometido obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        int? nullable;
        if (obj.Vehiculo)
        {
          nullable = obj.TipoVehiculoId;
          if (!nullable.HasValue)
            responseMessage.Errors.Add("Se ha selecionado la opcion de vehiculo, por lo tanto debe señalar el tipo de vehiculo");
        }
        IGestionProcesos repository1 = this._repository;
        nullable = new int?();
        int? skip = nullable;
        nullable = new int?();
        int? take = nullable;
        if (repository1.Get<Destinos>(skip: skip, take: take).Count<Destinos>() > 0)
        {
          nullable = this._repository.Get<Destinos>((Expression<Func<Destinos, bool>>) (c => c.Cometido.NombreId == obj.NombreId && c.Cometido.FechaSolicitud.Month == DateTime.Now.Month)).Sum<Destinos>((Func<Destinos, int?>) (d => d.Dias100));
          int num1 = 10;
          if (nullable.GetValueOrDefault() > num1 & nullable.HasValue)
            responseMessage.Errors.Add("La cantidad de dias al 100%, supera el maximo permitido para el mes señalado");
          nullable = this._repository.Get<Destinos>((Expression<Func<Destinos, bool>>) (c => c.Cometido.NombreId == obj.NombreId && c.Cometido.FechaSolicitud.Year == DateTime.Now.Year)).Sum<Destinos>((Func<Destinos, int?>) (d => d.Dias100));
          int num2 = 90;
          if (nullable.GetValueOrDefault() > num2 & nullable.HasValue)
            responseMessage.Errors.Add("La cantidad de dias al 100%, supera el maximo permitido para el año señalado");
        }
        if (string.IsNullOrEmpty(obj.CometidoDescripcion))
          responseMessage.Errors.Add("Debe ingresar la descripción del cometido.");
        if (string.IsNullOrEmpty(obj.ConglomeradoDescripcion))
          obj.IdConglomerado = new int?(Convert.ToInt32(obj.ConglomeradoDescripcion));
        if (string.IsNullOrEmpty(obj.ProgramaDescripcion))
          obj.IdPrograma = new int?(Convert.ToInt32(obj.ProgramaDescripcion));
        if (responseMessage.IsValid)
        {
          nullable = obj.NombreId;
          if (nullable.HasValue)
          {
            ISIGPER sigper = this._sigper;
            nullable = obj.NombreId;
            int rut = nullable.Value;
            string peDatPerChq = sigper.GetUserByRut(rut).Funcionario.PeDatPerChq;
            obj.Nombre = peDatPerChq.Trim();
            obj.FechaSolicitud = DateTime.Now;
          }
          this._repository.Create<App.Core.Entities.Cometido.Cometido>(obj);
          this._repository.Save();
          IGestionProcesos repository2 = this._repository;
          Mantenedor entity1 = new Mantenedor();
          int num = obj.CometidoId;
          entity1.IdCometido = num.ToString();
          entity1.NombreCampo = "Rut";
          num = obj.Rut;
          entity1.ValorCampo = num.ToString();
          repository2.Create<Mantenedor>(entity1);
          IGestionProcesos repository3 = this._repository;
          Mantenedor entity2 = new Mantenedor();
          num = obj.CometidoId;
          entity2.IdCometido = num.ToString();
          entity2.NombreCampo = "Dv";
          entity2.ValorCampo = obj.DV.ToString();
          repository3.Create<Mantenedor>(entity2);
          IGestionProcesos repository4 = this._repository;
          Mantenedor entity3 = new Mantenedor();
          num = obj.CometidoId;
          entity3.IdCometido = num.ToString();
          entity3.NombreCampo = "Cargo";
          nullable = obj.IdCargo;
          entity3.ValorCampo = nullable.ToString();
          repository4.Create<Mantenedor>(entity3);
          IGestionProcesos repository5 = this._repository;
          Mantenedor entity4 = new Mantenedor();
          num = obj.CometidoId;
          entity4.IdCometido = num.ToString();
          entity4.NombreCampo = "Calidad Juridica";
          nullable = obj.IdCalidad;
          entity4.ValorCampo = nullable.ToString();
          repository5.Create<Mantenedor>(entity4);
          IGestionProcesos repository6 = this._repository;
          Mantenedor entity5 = new Mantenedor();
          num = obj.CometidoId;
          entity5.IdCometido = num.ToString();
          entity5.NombreCampo = "Grado";
          entity5.ValorCampo = obj.IdGrado.ToString();
          repository6.Create<Mantenedor>(entity5);
          IGestionProcesos repository7 = this._repository;
          Mantenedor entity6 = new Mantenedor();
          num = obj.CometidoId;
          entity6.IdCometido = num.ToString();
          entity6.NombreCampo = "Estamento";
          nullable = obj.IdEstamento;
          entity6.ValorCampo = nullable.ToString();
          repository7.Create<Mantenedor>(entity6);
          IGestionProcesos repository8 = this._repository;
          Mantenedor entity7 = new Mantenedor();
          num = obj.CometidoId;
          entity7.IdCometido = num.ToString();
          entity7.NombreCampo = "Programa";
          nullable = obj.IdPrograma;
          entity7.ValorCampo = nullable.ToString();
          repository8.Create<Mantenedor>(entity7);
          IGestionProcesos repository9 = this._repository;
          Mantenedor entity8 = new Mantenedor();
          num = obj.CometidoId;
          entity8.IdCometido = num.ToString();
          entity8.NombreCampo = "Conglomerado";
          nullable = obj.IdConglomerado;
          entity8.ValorCampo = nullable.ToString();
          repository9.Create<Mantenedor>(entity8);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CometidoUpdate(App.Core.Entities.Cometido.Cometido obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        int? nullable = this._repository.Get<Destinos>((Expression<Func<Destinos, bool>>) (c => c.Cometido.NombreId == obj.NombreId && c.Cometido.FechaSolicitud.Month == DateTime.Now.Month)).Sum<Destinos>((Func<Destinos, int?>) (d => d.Dias100));
        int num1 = 10;
        if (nullable.GetValueOrDefault() > num1 & nullable.HasValue)
          responseMessage.Errors.Add("La cantidad de dias al 100%, supera el maximo permitido para el mes señalado");
        nullable = this._repository.Get<Destinos>((Expression<Func<Destinos, bool>>) (c => c.Cometido.NombreId == obj.NombreId && c.Cometido.FechaSolicitud.Year == DateTime.Now.Year)).Sum<Destinos>((Func<Destinos, int?>) (d => d.Dias100));
        int num2 = 90;
        if (nullable.GetValueOrDefault() > num2 & nullable.HasValue)
          responseMessage.Errors.Add("La cantidad de dias al 100%, supera el maximo permitido para el año señalado");
        IGestionProcesos repository1 = this._repository;
        Expression<Func<Destinos, bool>> filter = (Expression<Func<Destinos, bool>>) (c => c.CometidoId == (int?) obj.CometidoId);
        nullable = new int?();
        int? skip1 = nullable;
        nullable = new int?();
        int? take1 = nullable;
        List<Destinos> list = repository1.Get<Destinos>(filter, skip: skip1, take: take1).ToList<Destinos>();
        if (list.Count == 0)
        {
          responseMessage.Errors.Add("Se debe agregar por lo menos un destino al cometido");
        }
        else
        {
          if (list.LastOrDefault<Destinos>().FechaHasta < list.FirstOrDefault<Destinos>().FechaInicio)
            responseMessage.Errors.Add("La fecha de termino no pueder ser mayor a la fecha de inicio");
          if (list.Count > 1)
            responseMessage.Errors.Add("Usted ha ingresado más de un destino para el cometido, pero solo se le asignara un viático");
          IGestionProcesos repository2 = this._repository;
          nullable = new int?();
          int? skip2 = nullable;
          nullable = new int?();
          int? take2 = nullable;
          foreach (Destinos destinos in repository2.Get<Destinos>(skip: skip2, take: take2))
          {
            if (destinos.FechaInicio == list.FirstOrDefault<Destinos>().FechaInicio)
            {
              nullable = destinos.CometidoId;
              int? cometidoId = list.FirstOrDefault<Destinos>().CometidoId;
              if (!(nullable.GetValueOrDefault() == cometidoId.GetValueOrDefault() & nullable.HasValue == cometidoId.HasValue))
                responseMessage.Errors.Add("El rango de fachas señalados esta en conflicto con otros destinos");
            }
          }
        }
        if (responseMessage.IsValid)
        {
          obj.CometidoOk = new bool?(true);
          this._repository.Update<App.Core.Entities.Cometido.Cometido>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CometidoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        App.Core.Entities.Cometido.Cometido byId = this._repository.GetById<App.Core.Entities.Cometido.Cometido>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<App.Core.Entities.Cometido.Cometido>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DestinosInsert(Destinos obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        DateTime fechaInicio1 = obj.FechaInicio;
        DateTime fechaHasta = obj.FechaHasta;
        if (obj.FechaHasta < obj.FechaInicio)
          responseMessage.Errors.Add("La fecha de inicio no puede ser superior o igual a la de término");
        if ((obj.FechaHasta - obj.FechaInicio).TotalHours < 4.0)
        {
          responseMessage.Errors.Add("El cometido tiene una duración menor a 4 horas, por lo tanto no  le corresponde viático");
          obj.Dias100 = new int?(0);
          obj.Dias60 = new int?(0);
          obj.Dias40 = new int?(0);
          obj.Dias100Aprobados = new int?(0);
          obj.Dias60Aprobados = new int?(0);
          obj.Dias40Aprobados = new int?(0);
          obj.Dias100Monto = new int?(0);
          obj.Dias60Monto = new int?(0);
          obj.Dias40Monto = new int?(0);
          obj.TotalViatico = new int?(0);
          obj.Total = new int?(0);
        }
        bool flag = false;
        App.Core.Entities.Cometido.Cometido cometido = this._repository.Get<App.Core.Entities.Cometido.Cometido>((Expression<Func<App.Core.Entities.Cometido.Cometido, bool>>) (c => (int?) c.CometidoId == obj.CometidoId)).FirstOrDefault<App.Core.Entities.Cometido.Cometido>();
        int? nullable1;
        int? nullable2;
        if (cometido != null)
        {
          switch (cometido.IdConglomerado.Value)
          {
            case 1:
              if (obj.IdComuna == "01101" || obj.IdComuna == "01107")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable3 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable4;
                if (!(nullable3.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable4 = nullable1;
                }
                else
                  nullable4 = new int?(nullable3.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable5 = nullable4;
                int num = 0;
                if (nullable5.GetValueOrDefault() > num & nullable5.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 2:
              if (obj.IdComuna == "02101" || obj.IdComuna == "02102")
              {
                int? dias100 = obj.Dias100;
                nullable2 = obj.Dias60;
                int? nullable6 = dias100.HasValue & nullable2.HasValue ? new int?(dias100.GetValueOrDefault() + nullable2.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable7;
                if (!(nullable6.HasValue & dias40.HasValue))
                {
                  nullable2 = new int?();
                  nullable7 = nullable2;
                }
                else
                  nullable7 = new int?(nullable6.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable8 = nullable7;
                int num = 0;
                if (nullable8.GetValueOrDefault() > num & nullable8.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  flag = true;
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 3:
              if (obj.IdComuna == "03101")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable9 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable10;
                if (!(nullable9.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable10 = nullable1;
                }
                else
                  nullable10 = new int?(nullable9.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable11 = nullable10;
                int num = 0;
                if (nullable11.GetValueOrDefault() > num & nullable11.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 4:
              if (obj.IdComuna == "04101" || obj.IdComuna == "04102")
              {
                int? dias100 = obj.Dias100;
                nullable2 = obj.Dias60;
                int? nullable12 = dias100.HasValue & nullable2.HasValue ? new int?(dias100.GetValueOrDefault() + nullable2.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable13;
                if (!(nullable12.HasValue & dias40.HasValue))
                {
                  nullable2 = new int?();
                  nullable13 = nullable2;
                }
                else
                  nullable13 = new int?(nullable12.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable14 = nullable13;
                int num = 0;
                if (nullable14.GetValueOrDefault() > num & nullable14.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 5:
              if (obj.IdComuna == "05101" || obj.IdComuna == "05109" || obj.IdComuna == "05103" || obj.IdComuna == "05801" || obj.IdComuna == "05804" || obj.IdComuna == "05802" || obj.IdComuna == "05803" || obj.IdComuna == "05501" || obj.IdComuna == "05107" || obj.IdComuna == "05602" || obj.IdComuna == "05603" || obj.IdComuna == "05604" || obj.IdComuna == "05605" || obj.IdComuna == "05601" || obj.IdComuna == "05606")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable15 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable16;
                if (!(nullable15.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable16 = nullable1;
                }
                else
                  nullable16 = new int?(nullable15.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable17 = nullable16;
                int num = 0;
                if (nullable17.GetValueOrDefault() > num & nullable17.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 6:
              if (obj.IdComuna == "06101" || obj.IdComuna == "06108" || obj.IdComuna == "06102" || obj.IdComuna == "06110" || obj.IdComuna == "06106" || obj.IdComuna == "06111" || obj.IdComuna == "06116" || obj.IdComuna == "06103" || obj.IdComuna == "06104" || obj.IdComuna == "06105")
              {
                int? dias100 = obj.Dias100;
                nullable2 = obj.Dias60;
                int? nullable18 = dias100.HasValue & nullable2.HasValue ? new int?(dias100.GetValueOrDefault() + nullable2.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable19;
                if (!(nullable18.HasValue & dias40.HasValue))
                {
                  nullable2 = new int?();
                  nullable19 = nullable2;
                }
                else
                  nullable19 = new int?(nullable18.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable20 = nullable19;
                int num = 0;
                if (nullable20.GetValueOrDefault() > num & nullable20.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 7:
              if (obj.IdComuna == "07101" || obj.IdComuna == "07105" || obj.IdComuna == "07106" || obj.IdComuna == "07107" || obj.IdComuna == "07109" || obj.IdComuna == "07110")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable21 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable22;
                if (!(nullable21.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable22 = nullable1;
                }
                else
                  nullable22 = new int?(nullable21.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable23 = nullable22;
                int num = 0;
                if (nullable23.GetValueOrDefault() > num & nullable23.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 8:
              if (obj.IdComuna == "08101" || obj.IdComuna == "08108" || obj.IdComuna == "08103" || obj.IdComuna == "08107" || obj.IdComuna == "08110" || obj.IdComuna == "08112" || obj.IdComuna == "08102" || obj.IdComuna == "08106" || obj.IdComuna == "08401" || obj.IdComuna == "08406")
              {
                int? dias100 = obj.Dias100;
                nullable2 = obj.Dias60;
                int? nullable24 = dias100.HasValue & nullable2.HasValue ? new int?(dias100.GetValueOrDefault() + nullable2.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable25;
                if (!(nullable24.HasValue & dias40.HasValue))
                {
                  nullable2 = new int?();
                  nullable25 = nullable2;
                }
                else
                  nullable25 = new int?(nullable24.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable26 = nullable25;
                int num = 0;
                if (nullable26.GetValueOrDefault() > num & nullable26.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 9:
              if (obj.IdComuna == "09101" || obj.IdComuna == "09112")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable27 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable28;
                if (!(nullable27.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable28 = nullable1;
                }
                else
                  nullable28 = new int?(nullable27.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable29 = nullable28;
                int num = 0;
                if (nullable29.GetValueOrDefault() > num & nullable29.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 10:
              if (obj.IdComuna == "10101" || obj.IdComuna == "10107" || obj.IdComuna == "10105" || obj.IdComuna == "10109")
              {
                int? dias100 = obj.Dias100;
                nullable2 = obj.Dias60;
                int? nullable30 = dias100.HasValue & nullable2.HasValue ? new int?(dias100.GetValueOrDefault() + nullable2.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable31;
                if (!(nullable30.HasValue & dias40.HasValue))
                {
                  nullable2 = new int?();
                  nullable31 = nullable2;
                }
                else
                  nullable31 = new int?(nullable30.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable32 = nullable31;
                int num = 0;
                if (nullable32.GetValueOrDefault() > num & nullable32.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
            case 13:
              if (obj.IdComuna == "13101" || obj.IdComuna == "13130" || obj.IdComuna == "13129" || obj.IdComuna == "13131" || obj.IdComuna == "13109" || obj.IdComuna == "13401" || obj.IdComuna == "13201" || obj.IdComuna == "13111" || obj.IdComuna == "13112" || obj.IdComuna == "13110" || obj.IdComuna == "13122" || obj.IdComuna == "13118" || obj.IdComuna == "13120" || obj.IdComuna == "13113" || obj.IdComuna == "13114" || obj.IdComuna == "13123" || obj.IdComuna == "13104" || obj.IdComuna == "13125" || obj.IdComuna == "13128" || obj.IdComuna == "13117" || obj.IdComuna == "13103" || obj.IdComuna == "13126" || obj.IdComuna == "13124" || obj.IdComuna == "13106" || obj.IdComuna == "13119" || obj.IdComuna == "13102" || obj.IdComuna == "13105" || obj.IdComuna == "13127" || obj.IdComuna == "13132" || obj.IdComuna == "13116" || obj.IdComuna == "13108" || obj.IdComuna == "13121" || obj.IdComuna == "13107" || obj.IdComuna == "13115" || obj.IdComuna == "13302" || obj.IdComuna == "13403" || obj.IdComuna == "13604" || obj.IdComuna == "13605" || obj.IdComuna == "13602" || obj.IdComuna == "13603" || obj.IdComuna == "13402" || obj.IdComuna == "13404" || obj.IdComuna == "13202" || obj.IdComuna == "13301")
              {
                int? dias100 = obj.Dias100;
                nullable1 = obj.Dias60;
                int? nullable33 = dias100.HasValue & nullable1.HasValue ? new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
                int? dias40 = obj.Dias40;
                int? nullable34;
                if (!(nullable33.HasValue & dias40.HasValue))
                {
                  nullable1 = new int?();
                  nullable34 = nullable1;
                }
                else
                  nullable34 = new int?(nullable33.GetValueOrDefault() + dias40.GetValueOrDefault());
                int? nullable35 = nullable34;
                int num = 0;
                if (nullable35.GetValueOrDefault() > num & nullable35.HasValue)
                {
                  responseMessage.Errors.Add("El destino señalado es una localidad adyacente, por lo tanto no le corresponde viatico");
                  this.metodoMensaje(obj);
                  break;
                }
                flag = true;
                break;
              }
              break;
          }
        }
        int? nullable36 = obj.Dias100;
        int num1 = 0;
        int? nullable37;
        if (nullable36.GetValueOrDefault() > num1 & nullable36.HasValue)
        {
          int num2 = 0;
          int num3 = 0;
          DateTime dateTime = DateTime.Now;
          int month = dateTime.Month;
          dateTime = DateTime.Now;
          int year = dateTime.Year;
          IGestionProcesos repository1 = this._repository;
          ParameterExpression parameterExpression = Expression.Parameter(typeof (Destinos), "d");
          // ISSUE: method reference
          MemberExpression left = Expression.Property((Expression) parameterExpression, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Destinos.get_CometidoId)));
          nullable36 = new int?();
          ConstantExpression right = Expression.Constant((object) nullable36, typeof (int?));
          Expression<Func<Destinos, bool>> filter1 = Expression.Lambda<Func<Destinos, bool>>((Expression) Expression.NotEqual((Expression) left, (Expression) right), parameterExpression);
          nullable36 = new int?();
          int? skip1 = nullable36;
          nullable36 = new int?();
          int? take1 = nullable36;
          foreach (Destinos destinos1 in repository1.Get<Destinos>(filter1, skip: skip1, take: take1))
          {
            Destinos destinos = destinos1;
            IGestionProcesos repository2 = this._repository;
            Expression<Func<App.Core.Entities.Cometido.Cometido, bool>> filter2 = (Expression<Func<App.Core.Entities.Cometido.Cometido, bool>>) (c => (int?) c.CometidoId == destinos.CometidoId);
            nullable36 = new int?();
            int? skip2 = nullable36;
            nullable36 = new int?();
            int? take2 = nullable36;
            int? nombreId1 = repository2.Get<App.Core.Entities.Cometido.Cometido>(filter2, skip: skip2, take: take2).FirstOrDefault<App.Core.Entities.Cometido.Cometido>().NombreId;
            IGestionProcesos repository3 = this._repository;
            Expression<Func<App.Core.Entities.Cometido.Cometido, bool>> filter3 = (Expression<Func<App.Core.Entities.Cometido.Cometido, bool>>) (c => (int?) c.CometidoId == obj.CometidoId);
            nullable36 = new int?();
            int? skip3 = nullable36;
            nullable36 = new int?();
            int? take3 = nullable36;
            int? nombreId2 = repository3.Get<App.Core.Entities.Cometido.Cometido>(filter3, skip: skip3, take: take3).FirstOrDefault<App.Core.Entities.Cometido.Cometido>().NombreId;
            nullable36 = nombreId1;
            int? nullable38 = nombreId2;
            if (nullable36.GetValueOrDefault() == nullable38.GetValueOrDefault() & nullable36.HasValue == nullable38.HasValue)
            {
              dateTime = destinos.FechaInicio;
              if (dateTime.Month == month)
              {
                nullable38 = destinos.Dias100;
                int num4 = 0;
                if (!(nullable38.GetValueOrDefault() == num4 & nullable38.HasValue))
                {
                  nullable38 = destinos.Dias100;
                  if (nullable38.HasValue)
                  {
                    int num5 = num2;
                    nullable38 = destinos.Dias100;
                    int num6 = nullable38.Value;
                    num2 = num5 + num6;
                  }
                }
              }
              dateTime = destinos.FechaInicio;
              if (dateTime.Year == year)
              {
                nullable38 = destinos.Dias100;
                int num7 = 0;
                if (!(nullable38.GetValueOrDefault() == num7 & nullable38.HasValue))
                {
                  nullable38 = destinos.Dias100;
                  if (nullable38.HasValue)
                  {
                    int num8 = num3;
                    nullable38 = destinos.Dias100;
                    int num9 = nullable38.Value;
                    num3 = num8 + num9;
                  }
                }
              }
            }
          }
          int num10 = num2;
          nullable36 = obj.Dias100;
          int? nullable39 = nullable36.HasValue ? new int?(num10 + nullable36.GetValueOrDefault()) : new int?();
          int num11 = 10;
          int num12;
          if (nullable39.GetValueOrDefault() > num11 & nullable39.HasValue)
          {
            List<string> errors = responseMessage.Errors;
            num12 = num2 + obj.Dias100.Value - 10;
            string str = "Se ha excedido en: " + num12.ToString() + " la cantidad permitida de dias solicitados al 100%, dentro del Mes";
            errors.Add(str);
          }
          int num13 = num3;
          nullable36 = obj.Dias100;
          int? nullable40 = nullable36.HasValue ? new int?(num13 + nullable36.GetValueOrDefault()) : new int?();
          num12 = 90;
          if (nullable40.GetValueOrDefault() > num12 & nullable40.HasValue)
          {
            List<string> errors = responseMessage.Errors;
            num12 = num3;
            nullable37 = obj.Dias100;
            int? nullable41;
            if (!nullable37.HasValue)
            {
              nullable36 = new int?();
              nullable41 = nullable36;
            }
            else
              nullable41 = new int?(num12 + nullable37.GetValueOrDefault() - 90);
            nullable36 = nullable41;
            string str = "Se ha excedido en :" + nullable36.ToString() + " la cantidad permitida de dias solicitados al 100%, dentro de un año";
            errors.Add(str);
          }
        }
        if (!flag)
        {
          int num14 = (obj.FechaHasta - obj.FechaInicio).Days + 1;
          int? dias100 = obj.Dias100;
          nullable1 = obj.Dias60;
          int? nullable42;
          if (!(dias100.HasValue & nullable1.HasValue))
          {
            nullable2 = new int?();
            nullable42 = nullable2;
          }
          else
            nullable42 = new int?(dias100.GetValueOrDefault() + nullable1.GetValueOrDefault());
          nullable37 = nullable42;
          nullable36 = obj.Dias40;
          int? nullable43;
          if (!(nullable37.HasValue & nullable36.HasValue))
          {
            nullable1 = new int?();
            nullable43 = nullable1;
          }
          else
            nullable43 = new int?(nullable37.GetValueOrDefault() + nullable36.GetValueOrDefault());
          nullable36 = nullable43;
          int valueOrDefault = nullable36.GetValueOrDefault();
          if (!(num14 == valueOrDefault & nullable36.HasValue))
            responseMessage.Errors.Add("la cantidad de dias no coincide con los viaticos solicitados");
        }
        IGestionProcesos repository4 = this._repository;
        ParameterExpression parameterExpression1 = Expression.Parameter(typeof (Destinos), "d");
        // ISSUE: method reference
        MemberExpression left1 = Expression.Property((Expression) parameterExpression1, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (Destinos.get_CometidoId)));
        nullable36 = new int?();
        ConstantExpression right1 = Expression.Constant((object) nullable36, typeof (int?));
        Expression<Func<Destinos, bool>> filter4 = Expression.Lambda<Func<Destinos, bool>>((Expression) Expression.NotEqual((Expression) left1, (Expression) right1), parameterExpression1);
        nullable36 = new int?();
        int? skip4 = nullable36;
        nullable36 = new int?();
        int? take4 = nullable36;
        foreach (Destinos destinos2 in repository4.Get<Destinos>(filter4, skip: skip4, take: take4))
        {
          Destinos destinos = destinos2;
          IGestionProcesos repository5 = this._repository;
          Expression<Func<App.Core.Entities.Cometido.Cometido, bool>> filter5 = (Expression<Func<App.Core.Entities.Cometido.Cometido, bool>>) (c => (int?) c.CometidoId == destinos.CometidoId);
          nullable36 = new int?();
          int? skip5 = nullable36;
          nullable36 = new int?();
          int? take5 = nullable36;
          int? nombreId3 = repository5.Get<App.Core.Entities.Cometido.Cometido>(filter5, skip: skip5, take: take5).FirstOrDefault<App.Core.Entities.Cometido.Cometido>().NombreId;
          IGestionProcesos repository6 = this._repository;
          Expression<Func<App.Core.Entities.Cometido.Cometido, bool>> filter6 = (Expression<Func<App.Core.Entities.Cometido.Cometido, bool>>) (c => (int?) c.CometidoId == obj.CometidoId);
          nullable36 = new int?();
          int? skip6 = nullable36;
          nullable36 = new int?();
          int? take6 = nullable36;
          int? nombreId4 = repository6.Get<App.Core.Entities.Cometido.Cometido>(filter6, skip: skip6, take: take6).FirstOrDefault<App.Core.Entities.Cometido.Cometido>().NombreId;
          nullable36 = nombreId3;
          nullable37 = nombreId4;
          if (nullable36.GetValueOrDefault() == nullable37.GetValueOrDefault() & nullable36.HasValue == nullable37.HasValue)
          {
            DateTime fechaInicio2 = destinos.FechaInicio;
            DateTime date1 = fechaInicio2.Date;
            fechaInicio2 = obj.FechaInicio;
            DateTime date2 = fechaInicio2.Date;
            if (date1 == date2)
              responseMessage.Errors.Add("El rango de fachas señalados esta en conflicto con otros destinos");
          }
        }
        if (obj.IdComuna != null)
        {
          string str = this._sigper.GetDGCOMUNAs().FirstOrDefault<DGCOMUNAS>((Func<DGCOMUNAS, bool>) (c => c.Pl_CodCom == obj.IdComuna.ToString())).Pl_DesCom.Trim();
          obj.ComunaDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la comuna de destino");
        if (obj.IdRegion != null)
        {
          string str = this._sigper.GetRegion().FirstOrDefault<DGREGIONES>((Func<DGREGIONES, bool>) (c => c.Pl_CodReg == obj.IdRegion.ToString())).Pl_DesReg.Trim();
          obj.RegionDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        int? nullable44 = obj.Dias00;
        if (!nullable44.HasValue)
          obj.Dias00 = new int?(0);
        nullable44 = obj.Dias50;
        if (!nullable44.HasValue)
          obj.Dias50 = new int?(0);
        if (responseMessage.IsValid)
        {
          this._repository.Create<Destinos>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    private void metodoMensaje(Destinos obj)
    {
      obj.Dias100 = new int?(0);
      obj.Dias60 = new int?(0);
      obj.Dias40 = new int?(0);
      obj.Dias100Aprobados = new int?(0);
      obj.Dias60Aprobados = new int?(0);
      obj.Dias40Aprobados = new int?(0);
      obj.Dias100Monto = new int?(0);
      obj.Dias60Monto = new int?(0);
      obj.Dias40Monto = new int?(0);
      obj.TotalViatico = new int?(0);
      obj.Total = new int?(0);
    }

    public ResponseMessage DestinosUpdate(Destinos obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        DateTime fechaInicio = obj.FechaInicio;
        DateTime fechaHasta = obj.FechaHasta;
        int num = (obj.FechaHasta - obj.FechaInicio).Days + 1;
        int? dias100Aprobados = obj.Dias100Aprobados;
        int? nullable1 = obj.Dias60Aprobados;
        int? nullable2 = dias100Aprobados.HasValue & nullable1.HasValue ? new int?(dias100Aprobados.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new int?();
        int? dias40Aprobados = obj.Dias40Aprobados;
        int? nullable3;
        if (!(nullable2.HasValue & dias40Aprobados.HasValue))
        {
          nullable1 = new int?();
          nullable3 = nullable1;
        }
        else
          nullable3 = new int?(nullable2.GetValueOrDefault() + dias40Aprobados.GetValueOrDefault());
        int? nullable4 = nullable3;
        int? dias50Aprobados = obj.Dias50Aprobados;
        int? nullable5 = nullable4.HasValue & dias50Aprobados.HasValue ? new int?(nullable4.GetValueOrDefault() + dias50Aprobados.GetValueOrDefault()) : new int?();
        int valueOrDefault = nullable5.GetValueOrDefault();
        if (!(num == valueOrDefault & nullable5.HasValue))
          responseMessage.Errors.Add("la cantidad de dias no coincide con los viaticos solicitados");
        if (obj.FechaHasta < obj.FechaInicio)
          responseMessage.Errors.Add("La fecha de inicio no puede ser superior o igual a la de término");
        if ((obj.FechaHasta - obj.FechaInicio).TotalHours < 4.0)
        {
          responseMessage.Errors.Add("El cometido tiene una duración menor a 4 horas, por lo tanto no  le corresponde viático");
          obj.Dias100 = new int?(0);
          obj.Dias60 = new int?(0);
          obj.Dias40 = new int?(0);
          obj.Dias100Aprobados = new int?(0);
          obj.Dias60Aprobados = new int?(0);
          obj.Dias40Aprobados = new int?(0);
          obj.Dias100Monto = new int?(0);
          obj.Dias60Monto = new int?(0);
          obj.Dias40Monto = new int?(0);
          obj.TotalViatico = new int?(0);
          obj.Total = new int?(0);
        }
        if (obj.IdComuna != null)
        {
          string plDesCom = this._sigper.GetDGCOMUNAs().FirstOrDefault<DGCOMUNAS>((Func<DGCOMUNAS, bool>) (c => c.Pl_CodCom == obj.IdComuna)).Pl_DesCom;
          obj.ComunaDescripcion = plDesCom;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la comuna de destino");
        if (obj.IdRegion != null)
        {
          string plDesReg = this._sigper.GetRegion().FirstOrDefault<DGREGIONES>((Func<DGREGIONES, bool>) (c => c.Pl_CodReg == obj.IdRegion)).Pl_DesReg;
          obj.RegionDescripcion = plDesReg;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (responseMessage.IsValid)
        {
          this._repository.Update<Destinos>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DestinosDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Destinos byId = this._repository.GetById<Destinos>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Destinos>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoInsert(Viatico obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Viatico>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoUpdate(Viatico obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<Viatico>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Viatico byId = this._repository.GetById<Viatico>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Viatico>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoHonorarioInsert(ViaticoHonorario obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<ViaticoHonorario>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoHonorarioUpdate(ViaticoHonorario obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<ViaticoHonorario>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ViaticoHonorarioDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        ViaticoHonorario byId = this._repository.GetById<ViaticoHonorario>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<ViaticoHonorario>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoAsignacionInsert(TipoAsignacion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoAsignacion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoAsignacionUpdate(TipoAsignacion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoAsignacion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoAsignacionDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoAsignacion byId = this._repository.GetById<TipoAsignacion>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoAsignacion>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoCapituloInsert(TipoCapitulo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoCapitulo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoCapituloUpdate(TipoCapitulo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoCapitulo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoCapituloDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoCapitulo byId = this._repository.GetById<TipoCapitulo>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoCapitulo>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoItemInsert(TipoItem obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoItem>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoItemUpdate(TipoItem obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoItem>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoItemDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoItem byId = this._repository.GetById<TipoItem>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoItem>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoPartidaInsert(TipoPartida obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoPartida>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoPartidaUpdate(TipoPartida obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoPartida>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoPartidaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoPartida byId = this._repository.GetById<TipoPartida>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoPartida>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubAsignacionInsert(TipoSubAsignacion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoSubAsignacion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubAsignacionUpdate(TipoSubAsignacion obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoSubAsignacion>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubAsignacionDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoSubAsignacion byId = this._repository.GetById<TipoSubAsignacion>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoSubAsignacion>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubTituloInsert(TipoSubTitulo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<TipoSubTitulo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubTituloUpdate(TipoSubTitulo obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<TipoSubTitulo>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage TipoSubTituloDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        TipoSubTitulo byId = this._repository.GetById<TipoSubTitulo>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<TipoSubTitulo>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CentroCostoInsert(CentroCosto obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<CentroCosto>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CentroCostoUpdate(CentroCosto obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<CentroCosto>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage CentroCostoDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        CentroCosto byId = this._repository.GetById<CentroCosto>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<CentroCosto>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneracionCDPInsert(GeneracionCDP obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<GeneracionCDP>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneracionCDPUpdate(GeneracionCDP obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<GeneracionCDP>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage GeneracionCDPDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        GeneracionCDP byId = this._repository.GetById<GeneracionCDP>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<GeneracionCDP>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ParrafosInsert(Parrafos obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Parrafos>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ParrafosUpdate(Parrafos obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<Parrafos>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ParrafosDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Parrafos byId = this._repository.GetById<Parrafos>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Parrafos>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage PasajeInsert(Pasaje obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (obj.IdRegion != null)
        {
          string str = this._sigper.GetRegion().FirstOrDefault<DGREGIONES>((Func<DGREGIONES, bool>) (c => c.Pl_CodReg == obj.IdRegion.ToString())).Pl_DesReg.Trim();
          obj.RegionDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (obj.IdComuna != null)
        {
          string str = this._sigper.GetDGCOMUNAs().FirstOrDefault<DGCOMUNAS>((Func<DGCOMUNAS, bool>) (c => c.Pl_CodReg == obj.IdComuna)).Pl_DesCom.Trim();
          obj.ComunaDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (obj.IdPais != null)
        {
          string str = this._sigper.GetDGPAISESs().FirstOrDefault<DGPAISES>((Func<DGPAISES, bool>) (c => (int) c.Pl_CodPai == Convert.ToInt32(obj.IdPais))).pl_DesPai.Trim();
          obj.PaisDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (responseMessage.IsValid)
        {
          int? nombreId = obj.NombreId;
          if (nombreId.HasValue)
          {
            ISIGPER sigper = this._sigper;
            nombreId = obj.NombreId;
            int rut = nombreId.Value;
            string peDatPerChq = sigper.GetUserByRut(rut).Funcionario.PeDatPerChq;
            obj.Nombre = peDatPerChq.Trim();
          }
          this._repository.Create<Pasaje>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage PasajeUpdate(Pasaje obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (obj.IdRegion != null)
        {
          string str = this._sigper.GetRegion().FirstOrDefault<DGREGIONES>((Func<DGREGIONES, bool>) (c => c.Pl_CodReg == obj.IdRegion.ToString())).Pl_DesReg.Trim();
          obj.RegionDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (obj.IdComuna != null)
        {
          string str = this._sigper.GetDGCOMUNAs().FirstOrDefault<DGCOMUNAS>((Func<DGCOMUNAS, bool>) (c => c.Pl_CodReg == obj.IdComuna)).Pl_DesCom.Trim();
          obj.ComunaDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (obj.IdPais != null)
        {
          string str = this._sigper.GetDGPAISESs().FirstOrDefault<DGPAISES>((Func<DGPAISES, bool>) (c => (int) c.Pl_CodPai == Convert.ToInt32(obj.IdPais))).pl_DesPai.Trim();
          obj.PaisDescripcion = str;
        }
        else
          responseMessage.Errors.Add("Se debe señalar la region de destino");
        if (responseMessage.IsValid)
        {
          int? nombreId = obj.NombreId;
          if (nombreId.HasValue)
          {
            ISIGPER sigper = this._sigper;
            nombreId = obj.NombreId;
            int rut = nombreId.Value;
            string peDatPerChq = sigper.GetUserByRut(rut).Funcionario.PeDatPerChq;
            obj.Nombre = peDatPerChq.Trim();
          }
          this._repository.Update<Pasaje>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage PasajeDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Pasaje byId = this._repository.GetById<Pasaje>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Pasaje>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DenunciaInsert(Denuncia obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Denuncia>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DenunciaUpdate(Denuncia obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<Denuncia>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage DenunciaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Denuncia byId = this._repository.GetById<Denuncia>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Denuncia>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConsultaInsert(Consulta obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Consulta>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConsultaInsert(Proceso obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<Proceso>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConsultaUpdate(Consulta obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<Consulta>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage ConsultaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        Consulta byId = this._repository.GetById<Consulta>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<Consulta>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WebConsultaInsert(WebConsulta obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Create<WebConsulta>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WebConsultaUpdate(WebConsulta obj)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        if (responseMessage.IsValid)
        {
          this._repository.Update<WebConsulta>(obj);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public ResponseMessage WebConsultaDelete(int id)
    {
      ResponseMessage responseMessage = new ResponseMessage();
      try
      {
        WebConsulta byId = this._repository.GetById<WebConsulta>((object) id);
        if (byId == null)
          responseMessage.Errors.Add("Dato no encontrado");
        if (responseMessage.IsValid)
        {
          this._repository.Delete<WebConsulta>(byId);
          this._repository.Save();
        }
      }
      catch (Exception ex)
      {
        responseMessage.Errors.Add(ex.Message);
      }
      return responseMessage;
    }

    public void Sync()
    {
    }
  }
}
