﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amburer.Old_App_Code.DAL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Amburer")]
	public partial class LinksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLinks(Links instance);
    partial void UpdateLinks(Links instance);
    partial void DeleteLinks(Links instance);
    #endregion
		
		public LinksDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AmburerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Links> Links
		{
			get
			{
				return this.GetTable<Links>();
			}
		}
		
		public System.Data.Linq.Table<vLinks> vLinks
		{
			get
			{
				return this.GetTable<vLinks>();
			}
		}
		
		public System.Data.Linq.Table<vRandLinks> vRandLinks
		{
			get
			{
				return this.GetTable<vRandLinks>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Links")]
	public partial class Links : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private System.Nullable<int> _CatCode;
		
		private string _Title;
		
		private string _Url;
		
		private string _Description;
		
		private string _FileName;
		
		private System.Nullable<int> _ShowOrder;
		
		private System.Nullable<int> _HCLanguageCode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnCatCodeChanging(System.Nullable<int> value);
    partial void OnCatCodeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnFileNameChanging(string value);
    partial void OnFileNameChanged();
    partial void OnShowOrderChanging(System.Nullable<int> value);
    partial void OnShowOrderChanged();
    partial void OnHCLanguageCodeChanging(System.Nullable<int> value);
    partial void OnHCLanguageCodeChanged();
    #endregion
		
		public Links()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatCode", DbType="Int")]
		public System.Nullable<int> CatCode
		{
			get
			{
				return this._CatCode;
			}
			set
			{
				if ((this._CatCode != value))
				{
					this.OnCatCodeChanging(value);
					this.SendPropertyChanging();
					this._CatCode = value;
					this.SendPropertyChanged("CatCode");
					this.OnCatCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(500)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(1000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileName", DbType="NVarChar(200)")]
		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				if ((this._FileName != value))
				{
					this.OnFileNameChanging(value);
					this.SendPropertyChanging();
					this._FileName = value;
					this.SendPropertyChanged("FileName");
					this.OnFileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShowOrder", DbType="Int")]
		public System.Nullable<int> ShowOrder
		{
			get
			{
				return this._ShowOrder;
			}
			set
			{
				if ((this._ShowOrder != value))
				{
					this.OnShowOrderChanging(value);
					this.SendPropertyChanging();
					this._ShowOrder = value;
					this.SendPropertyChanged("ShowOrder");
					this.OnShowOrderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HCLanguageCode", DbType="Int")]
		public System.Nullable<int> HCLanguageCode
		{
			get
			{
				return this._HCLanguageCode;
			}
			set
			{
				if ((this._HCLanguageCode != value))
				{
					this.OnHCLanguageCodeChanging(value);
					this.SendPropertyChanging();
					this._HCLanguageCode = value;
					this.SendPropertyChanged("HCLanguageCode");
					this.OnHCLanguageCodeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vLinks")]
	public partial class vLinks
	{
		
		private int _Code;
		
		private string _Title;
		
		private string _Url;
		
		private string _CatName;
		
		private string _FileName;
		
		private System.Nullable<int> _ShowOrder;
		
		private System.Nullable<int> _CatCode;
		
		private System.Nullable<int> _HCLanguageCode;
		
		private string _Description;
		
		public vLinks()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="Int NOT NULL")]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(500)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this._Url = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatName", DbType="NVarChar(500)")]
		public string CatName
		{
			get
			{
				return this._CatName;
			}
			set
			{
				if ((this._CatName != value))
				{
					this._CatName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileName", DbType="NVarChar(200)")]
		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				if ((this._FileName != value))
				{
					this._FileName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShowOrder", DbType="Int")]
		public System.Nullable<int> ShowOrder
		{
			get
			{
				return this._ShowOrder;
			}
			set
			{
				if ((this._ShowOrder != value))
				{
					this._ShowOrder = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatCode", DbType="Int")]
		public System.Nullable<int> CatCode
		{
			get
			{
				return this._CatCode;
			}
			set
			{
				if ((this._CatCode != value))
				{
					this._CatCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HCLanguageCode", DbType="Int")]
		public System.Nullable<int> HCLanguageCode
		{
			get
			{
				return this._HCLanguageCode;
			}
			set
			{
				if ((this._HCLanguageCode != value))
				{
					this._HCLanguageCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(1000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vRandLinks")]
	public partial class vRandLinks
	{
		
		private int _Code;
		
		private System.Nullable<int> _CatCode;
		
		private string _Title;
		
		private string _Url;
		
		private string _Description;
		
		public vRandLinks()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatCode", DbType="Int")]
		public System.Nullable<int> CatCode
		{
			get
			{
				return this._CatCode;
			}
			set
			{
				if ((this._CatCode != value))
				{
					this._CatCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(500)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this._Url = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(1000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
