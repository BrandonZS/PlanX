﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanXBackend.Acceso_Datos
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PLANXAPP")]
	public partial class ConexionLINQDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public ConexionLINQDataContext() : 
				base(global::PlanXBackend.Properties.Settings.Default.PLANXAPPConnectionString5, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLINQDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLINQDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLINQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLINQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_REGISTRO_USUARIO_REGULAR")]
		public int SP_REGISTRO_USUARIO_REGULAR([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NOMBRE", DbType="NVarChar(255)")] string nOMBRE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="APELLIDOS", DbType="NVarChar(255)")] string aPELLIDOS, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CORREO_ELECTRONICO", DbType="NVarChar(MAX)")] string cORREO_ELECTRONICO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PASSWORD", DbType="NVarChar(MAX)")] string pASSWORD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CODPAIS", DbType="NVarChar(2)")] string cODPAIS, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nOMBRE, aPELLIDOS, cORREO_ELECTRONICO, pASSWORD, cODPAIS, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(5)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ACTUALIZAR_EVENTO")]
		public int SP_ACTUALIZAR_EVENTO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TITULO", DbType="NVarChar(255)")] string tITULO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DESCRIPCION", DbType="NVarChar(255)")] string dESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INVI", DbType="NVarChar(6)")] string cOD_INVI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tITULO, dESCRIPCION, iD_USER, cOD_INVI, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(4)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ACTUALIZAR_TAREA")]
		public int SP_ACTUALIZAR_TAREA([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TITULO", DbType="NVarChar(255)")] string tITULO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DESCRIPCION", DbType="NVarChar(255)")] string dESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_TAREA", DbType="Int")] System.Nullable<int> iD_TAREA, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tITULO, dESCRIPCION, iD_USER, iD_TAREA, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(4)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ACTUALIZAR_USUARIO_REGULAR")]
		public int SP_ACTUALIZAR_USUARIO_REGULAR([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NOMBRE", DbType="NVarChar(255)")] string nOMBRE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="APELLIDO", DbType="NVarChar(255)")] string aPELLIDO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CONTRA_ANTIGUA", DbType="NVarChar(255)")] string cONTRA_ANTIGUA, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CONTRA_NUEVA", DbType="NVarChar(255)")] string cONTRA_NUEVA, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_PAIS", DbType="VarChar(2)")] string cOD_PAIS, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nOMBRE, aPELLIDO, cONTRA_ANTIGUA, cONTRA_NUEVA, iD_USER, cOD_PAIS, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_DEFINIR_EVENTO")]
		public int SP_DEFINIR_EVENTO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_INICIAL", DbType="DateTime")] System.Nullable<System.DateTime> fEC_INICIAL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_FINAL", DbType="DateTime")] System.Nullable<System.DateTime> fEC_FINAL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INVI", DbType="NVarChar(6)")] string cOD_INVI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fEC_INICIAL, fEC_FINAL, iD_USER, cOD_INVI, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(4)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ELIMINAR_EVENTO")]
		public int SP_ELIMINAR_EVENTO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INV", DbType="NVarChar(6)")] string cOD_INV, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, cOD_INV, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(2)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(3)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ELIMINAR_TAREA")]
		public int SP_ELIMINAR_TAREA([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_TAREA", DbType="Int")] System.Nullable<int> iD_TAREA)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, iD_TAREA);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ELIMINAR_USUARIO_REGULAR")]
		public int SP_ELIMINAR_USUARIO_REGULAR([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PASSWORD", DbType="NVarChar(MAX)")] string pASSWORD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, pASSWORD, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(2)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(3)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_INSERTAR_EVENTO")]
		public int SP_INSERTAR_EVENTO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NOMBRE", DbType="NVarChar(255)")] string nOMBRE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DESCRIPCION", DbType="NVarChar(255)")] string dESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FECHORA_INICIO", DbType="DateTime")] System.Nullable<System.DateTime> fECHORA_INICIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FECHORA_FIN", DbType="DateTime")] System.Nullable<System.DateTime> fECHORA_FIN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="LIMITE_USUARIO", DbType="Int")] System.Nullable<int> lIMITE_USUARIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DURACION", DbType="Float")] System.Nullable<double> dURACION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nOMBRE, dESCRIPCION, fECHORA_INICIO, fECHORA_FIN, lIMITE_USUARIO, dURACION, iD_USER, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(7)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(8)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(9)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_INSERTAR_TAREA")]
		public int SP_INSERTAR_TAREA([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TITULO", DbType="VarChar(255)")] string tITULO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DESCRIPCION", DbType="VarChar(255)")] string dESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FECHORA_INICIO", DbType="DateTime")] System.Nullable<System.DateTime> fECHORA_INICIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FECHORA_FIN", DbType="DateTime")] System.Nullable<System.DateTime> fECHORA_FIN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PRIORIDAD", DbType="VarChar(50)")] string pRIORIDAD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tITULO, dESCRIPCION, fECHORA_INICIO, fECHORA_FIN, iD_USER, pRIORIDAD, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(7)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(8)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_LOGIN")]
		public ISingleResult<SP_LOGINResult> SP_LOGIN([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CORREO_ELECTRONICO", DbType="NVarChar(50)")] string cORREO_ELECTRONICO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PASSWORD", DbType="NVarChar(MAX)")] string pASSWORD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(50)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), cORREO_ELECTRONICO, pASSWORD, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(2)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(3)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(4)));
			return ((ISingleResult<SP_LOGINResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_OBTENER_EVENTO")]
		public ISingleResult<SP_OBTENER_EVENTOResult> SP_OBTENER_EVENTO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INVI", DbType="VarChar(6)")] string cOD_INVI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(255)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), cOD_INVI, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(2)));
			return ((ISingleResult<SP_OBTENER_EVENTOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_OBTENER_LISTA_EVENTOS")]
		public ISingleResult<SP_OBTENER_LISTA_EVENTOSResult> SP_OBTENER_LISTA_EVENTOS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(255)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(2)));
			return ((ISingleResult<SP_OBTENER_LISTA_EVENTOSResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_OBTENER_REGISTRO")]
		public ISingleResult<SP_OBTENER_REGISTROResult> SP_OBTENER_REGISTRO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INV", DbType="NVarChar(6)")] string cOD_INV, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(50)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), cOD_INV, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(2)));
			return ((ISingleResult<SP_OBTENER_REGISTROResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_OBTENER_TAREA")]
		public ISingleResult<SP_OBTENER_TAREAResult> SP_OBTENER_TAREA([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(50)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, eRRORID, eRRORDESCRIPCION);
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(1)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(2)));
			return ((ISingleResult<SP_OBTENER_TAREAResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_REGISTRO_EVENTO_INVITADO")]
		public int SP_REGISTRO_EVENTO_INVITADO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NOMBRE", DbType="VarChar(255)")] string nOMBRE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="APELLIDO", DbType="VarChar(255)")] string aPELLIDO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INVI", DbType="VarChar(6)")] string cOD_INVI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_INICIO", DbType="DateTime")] System.Nullable<System.DateTime> fEC_INICIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_FIN", DbType="DateTime")] System.Nullable<System.DateTime> fEC_FIN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nOMBRE, aPELLIDO, cOD_INVI, fEC_INICIO, fEC_FIN, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(5)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_REGISTRO_EVENTO_REGULAR")]
		public int SP_REGISTRO_EVENTO_REGULAR([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USER", DbType="Int")] System.Nullable<int> iD_USER, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="COD_INVI", DbType="VarChar(6)")] string cOD_INVI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_INICIO", DbType="DateTime")] System.Nullable<System.DateTime> fEC_INICIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FEC_FIN", DbType="DateTime")] System.Nullable<System.DateTime> fEC_FIN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USER, cOD_INVI, fEC_INICIO, fEC_FIN, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(4)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(5)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(6)));
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class SP_LOGINResult
	{
		
		private int _ID_USUARIO;
		
		private string _NOMBRE;
		
		private string _APELLIDOS;
		
		private string _CORREO_ELECTRONICO;
		
		private string _CODIGO_PAIS;
		
		public SP_LOGINResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_USUARIO", DbType="Int NOT NULL")]
		public int ID_USUARIO
		{
			get
			{
				return this._ID_USUARIO;
			}
			set
			{
				if ((this._ID_USUARIO != value))
				{
					this._ID_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOMBRE", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string NOMBRE
		{
			get
			{
				return this._NOMBRE;
			}
			set
			{
				if ((this._NOMBRE != value))
				{
					this._NOMBRE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APELLIDOS", DbType="VarChar(255)")]
		public string APELLIDOS
		{
			get
			{
				return this._APELLIDOS;
			}
			set
			{
				if ((this._APELLIDOS != value))
				{
					this._APELLIDOS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CORREO_ELECTRONICO", DbType="VarChar(255)")]
		public string CORREO_ELECTRONICO
		{
			get
			{
				return this._CORREO_ELECTRONICO;
			}
			set
			{
				if ((this._CORREO_ELECTRONICO != value))
				{
					this._CORREO_ELECTRONICO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CODIGO_PAIS", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string CODIGO_PAIS
		{
			get
			{
				return this._CODIGO_PAIS;
			}
			set
			{
				if ((this._CODIGO_PAIS != value))
				{
					this._CODIGO_PAIS = value;
				}
			}
		}
	}
	
	public partial class SP_OBTENER_EVENTOResult
	{
		
		private string _NOMBRE_EVENTO;
		
		private string _DESCRIPCION;
		
		private System.DateTime _HORA_INICIO;
		
		private System.DateTime _HORA_FINAL;
		
		private System.Nullable<int> _LIM_USERS;
		
		private double _DURACION;
		
		private string _COD_INV;
		
		public SP_OBTENER_EVENTOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOMBRE_EVENTO", DbType="VarChar(255)")]
		public string NOMBRE_EVENTO
		{
			get
			{
				return this._NOMBRE_EVENTO;
			}
			set
			{
				if ((this._NOMBRE_EVENTO != value))
				{
					this._NOMBRE_EVENTO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPCION", DbType="VarChar(255)")]
		public string DESCRIPCION
		{
			get
			{
				return this._DESCRIPCION;
			}
			set
			{
				if ((this._DESCRIPCION != value))
				{
					this._DESCRIPCION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HORA_INICIO", DbType="DateTime NOT NULL")]
		public System.DateTime HORA_INICIO
		{
			get
			{
				return this._HORA_INICIO;
			}
			set
			{
				if ((this._HORA_INICIO != value))
				{
					this._HORA_INICIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HORA_FINAL", DbType="DateTime NOT NULL")]
		public System.DateTime HORA_FINAL
		{
			get
			{
				return this._HORA_FINAL;
			}
			set
			{
				if ((this._HORA_FINAL != value))
				{
					this._HORA_FINAL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LIM_USERS", DbType="Int")]
		public System.Nullable<int> LIM_USERS
		{
			get
			{
				return this._LIM_USERS;
			}
			set
			{
				if ((this._LIM_USERS != value))
				{
					this._LIM_USERS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DURACION", DbType="Float NOT NULL")]
		public double DURACION
		{
			get
			{
				return this._DURACION;
			}
			set
			{
				if ((this._DURACION != value))
				{
					this._DURACION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COD_INV", DbType="VarChar(255)")]
		public string COD_INV
		{
			get
			{
				return this._COD_INV;
			}
			set
			{
				if ((this._COD_INV != value))
				{
					this._COD_INV = value;
				}
			}
		}
	}
	
	public partial class SP_OBTENER_LISTA_EVENTOSResult
	{
		
		private string _NOMBRE_EVENTO;
		
		private string _DESCRIPCION;
		
		private System.DateTime _HORA_INICIO;
		
		private System.DateTime _HORA_FINAL;
		
		private System.Nullable<int> _LIM_USERS;
		
		private double _DURACION;
		
		private string _COD_INVI;
		
		private bool _ESTADO;
		
		public SP_OBTENER_LISTA_EVENTOSResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOMBRE_EVENTO", DbType="VarChar(255)")]
		public string NOMBRE_EVENTO
		{
			get
			{
				return this._NOMBRE_EVENTO;
			}
			set
			{
				if ((this._NOMBRE_EVENTO != value))
				{
					this._NOMBRE_EVENTO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPCION", DbType="VarChar(255)")]
		public string DESCRIPCION
		{
			get
			{
				return this._DESCRIPCION;
			}
			set
			{
				if ((this._DESCRIPCION != value))
				{
					this._DESCRIPCION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HORA_INICIO", DbType="DateTime NOT NULL")]
		public System.DateTime HORA_INICIO
		{
			get
			{
				return this._HORA_INICIO;
			}
			set
			{
				if ((this._HORA_INICIO != value))
				{
					this._HORA_INICIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HORA_FINAL", DbType="DateTime NOT NULL")]
		public System.DateTime HORA_FINAL
		{
			get
			{
				return this._HORA_FINAL;
			}
			set
			{
				if ((this._HORA_FINAL != value))
				{
					this._HORA_FINAL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LIM_USERS", DbType="Int")]
		public System.Nullable<int> LIM_USERS
		{
			get
			{
				return this._LIM_USERS;
			}
			set
			{
				if ((this._LIM_USERS != value))
				{
					this._LIM_USERS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DURACION", DbType="Float NOT NULL")]
		public double DURACION
		{
			get
			{
				return this._DURACION;
			}
			set
			{
				if ((this._DURACION != value))
				{
					this._DURACION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COD_INVI", DbType="VarChar(255)")]
		public string COD_INVI
		{
			get
			{
				return this._COD_INVI;
			}
			set
			{
				if ((this._COD_INVI != value))
				{
					this._COD_INVI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ESTADO", DbType="Bit NOT NULL")]
		public bool ESTADO
		{
			get
			{
				return this._ESTADO;
			}
			set
			{
				if ((this._ESTADO != value))
				{
					this._ESTADO = value;
				}
			}
		}
	}
	
	public partial class SP_OBTENER_REGISTROResult
	{
		
		private string _NOMBRE_USUARIO;
		
		private string _APELLIDO_USUARIO;
		
		private double _DURACION;
		
		private string _COD_INV;
		
		private System.DateTime _FEC_INICIAL;
		
		private System.DateTime _FEC_FINAL;
		
		public SP_OBTENER_REGISTROResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOMBRE_USUARIO", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string NOMBRE_USUARIO
		{
			get
			{
				return this._NOMBRE_USUARIO;
			}
			set
			{
				if ((this._NOMBRE_USUARIO != value))
				{
					this._NOMBRE_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APELLIDO_USUARIO", DbType="VarChar(255)")]
		public string APELLIDO_USUARIO
		{
			get
			{
				return this._APELLIDO_USUARIO;
			}
			set
			{
				if ((this._APELLIDO_USUARIO != value))
				{
					this._APELLIDO_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DURACION", DbType="Float NOT NULL")]
		public double DURACION
		{
			get
			{
				return this._DURACION;
			}
			set
			{
				if ((this._DURACION != value))
				{
					this._DURACION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COD_INV", DbType="VarChar(255)")]
		public string COD_INV
		{
			get
			{
				return this._COD_INV;
			}
			set
			{
				if ((this._COD_INV != value))
				{
					this._COD_INV = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FEC_INICIAL", DbType="DateTime NOT NULL")]
		public System.DateTime FEC_INICIAL
		{
			get
			{
				return this._FEC_INICIAL;
			}
			set
			{
				if ((this._FEC_INICIAL != value))
				{
					this._FEC_INICIAL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FEC_FINAL", DbType="DateTime NOT NULL")]
		public System.DateTime FEC_FINAL
		{
			get
			{
				return this._FEC_FINAL;
			}
			set
			{
				if ((this._FEC_FINAL != value))
				{
					this._FEC_FINAL = value;
				}
			}
		}
	}
	
	public partial class SP_OBTENER_TAREAResult
	{
		
		private string _TITULO;
		
		private string _DESCRIPCION;
		
		private System.DateTime _FECINICIAL;
		
		private System.DateTime _FECFINAL;
		
		private string _PRIORIDAD;
		
		public SP_OBTENER_TAREAResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITULO", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TITULO
		{
			get
			{
				return this._TITULO;
			}
			set
			{
				if ((this._TITULO != value))
				{
					this._TITULO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPCION", DbType="VarChar(255)")]
		public string DESCRIPCION
		{
			get
			{
				return this._DESCRIPCION;
			}
			set
			{
				if ((this._DESCRIPCION != value))
				{
					this._DESCRIPCION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FECINICIAL", DbType="DateTime NOT NULL")]
		public System.DateTime FECINICIAL
		{
			get
			{
				return this._FECINICIAL;
			}
			set
			{
				if ((this._FECINICIAL != value))
				{
					this._FECINICIAL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FECFINAL", DbType="DateTime NOT NULL")]
		public System.DateTime FECFINAL
		{
			get
			{
				return this._FECFINAL;
			}
			set
			{
				if ((this._FECFINAL != value))
				{
					this._FECFINAL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRIORIDAD", DbType="VarChar(255)")]
		public string PRIORIDAD
		{
			get
			{
				return this._PRIORIDAD;
			}
			set
			{
				if ((this._PRIORIDAD != value))
				{
					this._PRIORIDAD = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
