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

namespace PlanXBackend.AccesoDatos
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
	public partial class ConexionLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public ConexionLinqDataContext() : 
				base(global::PlanXBackend.Properties.Settings.Default.PLANXAPPConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConexionLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_REGISTRO_USUARIO_REGULAR")]
		public int SP_REGISTRO_USUARIO_REGULAR([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NOMBRE", DbType="NVarChar(50)")] string nOMBRE, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="APELLIDOS", DbType="NVarChar(50)")] string aPELLIDOS, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CORREO_ELECTRONICO", DbType="NVarChar(MAX)")] string cORREO_ELECTRONICO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PASSWORD", DbType="NVarChar(MAX)")] string pASSWORD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FECNACIMIENTO", DbType="Date")] System.Nullable<System.DateTime> fECNACIMIENTO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PAISRESIDENCIA", DbType="TinyInt")] System.Nullable<byte> pAISRESIDENCIA, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nOMBRE, aPELLIDOS, cORREO_ELECTRONICO, pASSWORD, fECNACIMIENTO, pAISRESIDENCIA, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(7)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(8)));
			return ((int)(result.ReturnValue));
		}
	}
}
#pragma warning restore 1591
