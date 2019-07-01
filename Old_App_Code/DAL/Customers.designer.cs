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
	public partial class CustomersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomers(Customers instance);
    partial void UpdateCustomers(Customers instance);
    partial void DeleteCustomers(Customers instance);
    partial void InsertCustomerPictures(CustomerPictures instance);
    partial void UpdateCustomerPictures(CustomerPictures instance);
    partial void DeleteCustomerPictures(CustomerPictures instance);
    #endregion
		
		public CustomersDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AmburerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CustomersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customers> Customers
		{
			get
			{
				return this.GetTable<Customers>();
			}
		}
		
		public System.Data.Linq.Table<CustomerPictures> CustomerPictures
		{
			get
			{
				return this.GetTable<CustomerPictures>();
			}
		}
		
		public System.Data.Linq.Table<vCustomerPictures> vCustomerPictures
		{
			get
			{
				return this.GetTable<vCustomerPictures>();
			}
		}
		
		public System.Data.Linq.Table<vCustomers> vCustomers
		{
			get
			{
				return this.GetTable<vCustomers>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customers")]
	public partial class Customers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private string _Title;
		
		private string _Address;
		
		private string _LogoFile;
		
		private string _Description;
		
		private EntitySet<CustomerPictures> _CustomerPictures;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnLogoFileChanging(string value);
    partial void OnLogoFileChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Customers()
		{
			this._CustomerPictures = new EntitySet<CustomerPictures>(new Action<CustomerPictures>(this.attach_CustomerPictures), new Action<CustomerPictures>(this.detach_CustomerPictures));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(500)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogoFile", DbType="NVarChar(500)")]
		public string LogoFile
		{
			get
			{
				return this._LogoFile;
			}
			set
			{
				if ((this._LogoFile != value))
				{
					this.OnLogoFileChanging(value);
					this.SendPropertyChanging();
					this._LogoFile = value;
					this.SendPropertyChanged("LogoFile");
					this.OnLogoFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customers_CustomerPictures", Storage="_CustomerPictures", ThisKey="Code", OtherKey="CustomerCode")]
		public EntitySet<CustomerPictures> CustomerPictures
		{
			get
			{
				return this._CustomerPictures;
			}
			set
			{
				this._CustomerPictures.Assign(value);
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
		
		private void attach_CustomerPictures(CustomerPictures entity)
		{
			this.SendPropertyChanging();
			entity.Customers = this;
		}
		
		private void detach_CustomerPictures(CustomerPictures entity)
		{
			this.SendPropertyChanging();
			entity.Customers = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CustomerPictures")]
	public partial class CustomerPictures : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Code;
		
		private System.Nullable<int> _CustomerCode;
		
		private string _PicFile;
		
		private string _SmallPicFile;
		
		private EntityRef<Customers> _Customers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeChanging(int value);
    partial void OnCodeChanged();
    partial void OnCustomerCodeChanging(System.Nullable<int> value);
    partial void OnCustomerCodeChanged();
    partial void OnPicFileChanging(string value);
    partial void OnPicFileChanged();
    partial void OnSmallPicFileChanging(string value);
    partial void OnSmallPicFileChanged();
    #endregion
		
		public CustomerPictures()
		{
			this._Customers = default(EntityRef<Customers>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerCode", DbType="Int")]
		public System.Nullable<int> CustomerCode
		{
			get
			{
				return this._CustomerCode;
			}
			set
			{
				if ((this._CustomerCode != value))
				{
					if (this._Customers.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerCodeChanging(value);
					this.SendPropertyChanging();
					this._CustomerCode = value;
					this.SendPropertyChanged("CustomerCode");
					this.OnCustomerCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PicFile", DbType="NVarChar(200)")]
		public string PicFile
		{
			get
			{
				return this._PicFile;
			}
			set
			{
				if ((this._PicFile != value))
				{
					this.OnPicFileChanging(value);
					this.SendPropertyChanging();
					this._PicFile = value;
					this.SendPropertyChanged("PicFile");
					this.OnPicFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SmallPicFile", DbType="NVarChar(200)")]
		public string SmallPicFile
		{
			get
			{
				return this._SmallPicFile;
			}
			set
			{
				if ((this._SmallPicFile != value))
				{
					this.OnSmallPicFileChanging(value);
					this.SendPropertyChanging();
					this._SmallPicFile = value;
					this.SendPropertyChanged("SmallPicFile");
					this.OnSmallPicFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customers_CustomerPictures", Storage="_Customers", ThisKey="CustomerCode", OtherKey="Code", IsForeignKey=true)]
		public Customers Customers
		{
			get
			{
				return this._Customers.Entity;
			}
			set
			{
				Customers previousValue = this._Customers.Entity;
				if (((previousValue != value) 
							|| (this._Customers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customers.Entity = null;
						previousValue.CustomerPictures.Remove(this);
					}
					this._Customers.Entity = value;
					if ((value != null))
					{
						value.CustomerPictures.Add(this);
						this._CustomerCode = value.Code;
					}
					else
					{
						this._CustomerCode = default(Nullable<int>);
					}
					this.SendPropertyChanged("Customers");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vCustomerPictures")]
	public partial class vCustomerPictures
	{
		
		private int _Code;
		
		private System.Nullable<int> _CustomerCode;
		
		private string _PicFile;
		
		private string _SmallPicFile;
		
		public vCustomerPictures()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerCode", DbType="Int")]
		public System.Nullable<int> CustomerCode
		{
			get
			{
				return this._CustomerCode;
			}
			set
			{
				if ((this._CustomerCode != value))
				{
					this._CustomerCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PicFile", DbType="NVarChar(200)")]
		public string PicFile
		{
			get
			{
				return this._PicFile;
			}
			set
			{
				if ((this._PicFile != value))
				{
					this._PicFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SmallPicFile", DbType="NVarChar(200)")]
		public string SmallPicFile
		{
			get
			{
				return this._SmallPicFile;
			}
			set
			{
				if ((this._SmallPicFile != value))
				{
					this._SmallPicFile = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vCustomers")]
	public partial class vCustomers
	{
		
		private int _Code;
		
		private string _Title;
		
		private string _Address;
		
		private string _LogoFile;
		
		private string _Description;
		
		public vCustomers()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(500)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this._Address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogoFile", DbType="NVarChar(500)")]
		public string LogoFile
		{
			get
			{
				return this._LogoFile;
			}
			set
			{
				if ((this._LogoFile != value))
				{
					this._LogoFile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
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
