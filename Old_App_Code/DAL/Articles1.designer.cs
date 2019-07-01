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
	public partial class ArticlesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertArticles(Articles instance);
    partial void UpdateArticles(Articles instance);
    partial void DeleteArticles(Articles instance);
    #endregion
		
		public ArticlesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AmburerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ArticlesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArticlesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArticlesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArticlesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Articles> Articles
		{
			get
			{
				return this.GetTable<Articles>();
			}
		}
		
		public System.Data.Linq.Table<vArticles> vArticles
		{
			get
			{
				return this.GetTable<vArticles>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Articles")]
	public partial class Articles : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private string _Title;
		
		private string _ArticleFile;
		
		private System.Nullable<System.DateTime> _ArticleDate;
		
		private string _ArticleContent;
		
		private string _Url;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnArticleFileChanging(string value);
    partial void OnArticleFileChanged();
    partial void OnArticleDateChanging(System.Nullable<System.DateTime> value);
    partial void OnArticleDateChanged();
    partial void OnArticleContentChanging(string value);
    partial void OnArticleContentChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    #endregion
		
		public Articles()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArticleFile", DbType="NVarChar(200)")]
		public string ArticleFile
		{
			get
			{
				return this._ArticleFile;
			}
			set
			{
				if ((this._ArticleFile != value))
				{
					this.OnArticleFileChanging(value);
					this.SendPropertyChanging();
					this._ArticleFile = value;
					this.SendPropertyChanged("ArticleFile");
					this.OnArticleFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArticleDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ArticleDate
		{
			get
			{
				return this._ArticleDate;
			}
			set
			{
				if ((this._ArticleDate != value))
				{
					this.OnArticleDateChanging(value);
					this.SendPropertyChanging();
					this._ArticleDate = value;
					this.SendPropertyChanged("ArticleDate");
					this.OnArticleDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArticleContent", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ArticleContent
		{
			get
			{
				return this._ArticleContent;
			}
			set
			{
				if ((this._ArticleContent != value))
				{
					this.OnArticleContentChanging(value);
					this.SendPropertyChanging();
					this._ArticleContent = value;
					this.SendPropertyChanged("ArticleContent");
					this.OnArticleContentChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vArticles")]
	public partial class vArticles
	{
		
		private int _Code;
		
		private string _Title;
		
		private string _Url;
		
		private string _ArticleFile;
		
		private string _ArticleContent;
		
		private string _ADate;
		
		public vArticles()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArticleFile", DbType="NVarChar(200)")]
		public string ArticleFile
		{
			get
			{
				return this._ArticleFile;
			}
			set
			{
				if ((this._ArticleFile != value))
				{
					this._ArticleFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArticleContent", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ArticleContent
		{
			get
			{
				return this._ArticleContent;
			}
			set
			{
				if ((this._ArticleContent != value))
				{
					this._ArticleContent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADate", DbType="VarChar(10)")]
		public string ADate
		{
			get
			{
				return this._ADate;
			}
			set
			{
				if ((this._ADate != value))
				{
					this._ADate = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
