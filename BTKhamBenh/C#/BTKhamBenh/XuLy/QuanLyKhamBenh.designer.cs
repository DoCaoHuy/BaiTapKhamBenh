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

namespace XuLy
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QLBenhNhan")]
	public partial class QuanLyKhamBenhDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertbacsy(bacsy instance);
    partial void Updatebacsy(bacsy instance);
    partial void Deletebacsy(bacsy instance);
    partial void Insertkhambenh(khambenh instance);
    partial void Updatekhambenh(khambenh instance);
    partial void Deletekhambenh(khambenh instance);
    partial void Insertbenhnhan(benhnhan instance);
    partial void Updatebenhnhan(benhnhan instance);
    partial void Deletebenhnhan(benhnhan instance);
    #endregion
		
		public QuanLyKhamBenhDataContext() : 
				base(global::XuLy.Properties.Settings.Default.QLBenhNhanConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyKhamBenhDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyKhamBenhDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyKhamBenhDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyKhamBenhDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<bacsy> bacsies
		{
			get
			{
				return this.GetTable<bacsy>();
			}
		}
		
		public System.Data.Linq.Table<khambenh> khambenhs
		{
			get
			{
				return this.GetTable<khambenh>();
			}
		}
		
		public System.Data.Linq.Table<benhnhan> benhnhans
		{
			get
			{
				return this.GetTable<benhnhan>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.bacsy")]
	public partial class bacsy : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _msbacsy;
		
		private string _hotenbacsy;
		
		private EntitySet<khambenh> _khambenhs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmsbacsyChanging(string value);
    partial void OnmsbacsyChanged();
    partial void OnhotenbacsyChanging(string value);
    partial void OnhotenbacsyChanged();
    #endregion
		
		public bacsy()
		{
			this._khambenhs = new EntitySet<khambenh>(new Action<khambenh>(this.attach_khambenhs), new Action<khambenh>(this.detach_khambenhs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_msbacsy", DbType="VarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string msbacsy
		{
			get
			{
				return this._msbacsy;
			}
			set
			{
				if ((this._msbacsy != value))
				{
					this.OnmsbacsyChanging(value);
					this.SendPropertyChanging();
					this._msbacsy = value;
					this.SendPropertyChanged("msbacsy");
					this.OnmsbacsyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hotenbacsy", DbType="VarChar(150)")]
		public string hotenbacsy
		{
			get
			{
				return this._hotenbacsy;
			}
			set
			{
				if ((this._hotenbacsy != value))
				{
					this.OnhotenbacsyChanging(value);
					this.SendPropertyChanging();
					this._hotenbacsy = value;
					this.SendPropertyChanged("hotenbacsy");
					this.OnhotenbacsyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="bacsy_khambenh", Storage="_khambenhs", ThisKey="msbacsy", OtherKey="msbacsy")]
		public EntitySet<khambenh> khambenhs
		{
			get
			{
				return this._khambenhs;
			}
			set
			{
				this._khambenhs.Assign(value);
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
		
		private void attach_khambenhs(khambenh entity)
		{
			this.SendPropertyChanging();
			entity.bacsy = this;
		}
		
		private void detach_khambenhs(khambenh entity)
		{
			this.SendPropertyChanging();
			entity.bacsy = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.khambenh")]
	public partial class khambenh : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _msbn;
		
		private string _msbacsy;
		
		private System.Nullable<System.DateTime> _ngaykham;
		
		private string _ghichu;
		
		private EntityRef<bacsy> _bacsy;
		
		private EntityRef<benhnhan> _benhnhan;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmsbnChanging(string value);
    partial void OnmsbnChanged();
    partial void OnmsbacsyChanging(string value);
    partial void OnmsbacsyChanged();
    partial void OnngaykhamChanging(System.Nullable<System.DateTime> value);
    partial void OnngaykhamChanged();
    partial void OnghichuChanging(string value);
    partial void OnghichuChanged();
    #endregion
		
		public khambenh()
		{
			this._bacsy = default(EntityRef<bacsy>);
			this._benhnhan = default(EntityRef<benhnhan>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_msbn", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string msbn
		{
			get
			{
				return this._msbn;
			}
			set
			{
				if ((this._msbn != value))
				{
					if (this._benhnhan.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmsbnChanging(value);
					this.SendPropertyChanging();
					this._msbn = value;
					this.SendPropertyChanged("msbn");
					this.OnmsbnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_msbacsy", DbType="VarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string msbacsy
		{
			get
			{
				return this._msbacsy;
			}
			set
			{
				if ((this._msbacsy != value))
				{
					if (this._bacsy.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmsbacsyChanging(value);
					this.SendPropertyChanging();
					this._msbacsy = value;
					this.SendPropertyChanged("msbacsy");
					this.OnmsbacsyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaykham", DbType="Date")]
		public System.Nullable<System.DateTime> ngaykham
		{
			get
			{
				return this._ngaykham;
			}
			set
			{
				if ((this._ngaykham != value))
				{
					this.OnngaykhamChanging(value);
					this.SendPropertyChanging();
					this._ngaykham = value;
					this.SendPropertyChanged("ngaykham");
					this.OnngaykhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ghichu", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string ghichu
		{
			get
			{
				return this._ghichu;
			}
			set
			{
				if ((this._ghichu != value))
				{
					this.OnghichuChanging(value);
					this.SendPropertyChanging();
					this._ghichu = value;
					this.SendPropertyChanged("ghichu");
					this.OnghichuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="bacsy_khambenh", Storage="_bacsy", ThisKey="msbacsy", OtherKey="msbacsy", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public bacsy bacsy
		{
			get
			{
				return this._bacsy.Entity;
			}
			set
			{
				bacsy previousValue = this._bacsy.Entity;
				if (((previousValue != value) 
							|| (this._bacsy.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._bacsy.Entity = null;
						previousValue.khambenhs.Remove(this);
					}
					this._bacsy.Entity = value;
					if ((value != null))
					{
						value.khambenhs.Add(this);
						this._msbacsy = value.msbacsy;
					}
					else
					{
						this._msbacsy = default(string);
					}
					this.SendPropertyChanged("bacsy");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="benhnhan_khambenh", Storage="_benhnhan", ThisKey="msbn", OtherKey="msbn", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public benhnhan benhnhan
		{
			get
			{
				return this._benhnhan.Entity;
			}
			set
			{
				benhnhan previousValue = this._benhnhan.Entity;
				if (((previousValue != value) 
							|| (this._benhnhan.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._benhnhan.Entity = null;
						previousValue.khambenhs.Remove(this);
					}
					this._benhnhan.Entity = value;
					if ((value != null))
					{
						value.khambenhs.Add(this);
						this._msbn = value.msbn;
					}
					else
					{
						this._msbn = default(string);
					}
					this.SendPropertyChanged("benhnhan");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.benhnhan")]
	public partial class benhnhan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _msbn;
		
		private string _socmnd;
		
		private string _hoten;
		
		private string _diachi;
		
		private EntitySet<khambenh> _khambenhs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmsbnChanging(string value);
    partial void OnmsbnChanged();
    partial void OnsocmndChanging(string value);
    partial void OnsocmndChanged();
    partial void OnhotenChanging(string value);
    partial void OnhotenChanged();
    partial void OndiachiChanging(string value);
    partial void OndiachiChanged();
    #endregion
		
		public benhnhan()
		{
			this._khambenhs = new EntitySet<khambenh>(new Action<khambenh>(this.attach_khambenhs), new Action<khambenh>(this.detach_khambenhs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_msbn", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string msbn
		{
			get
			{
				return this._msbn;
			}
			set
			{
				if ((this._msbn != value))
				{
					this.OnmsbnChanging(value);
					this.SendPropertyChanging();
					this._msbn = value;
					this.SendPropertyChanged("msbn");
					this.OnmsbnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_socmnd", DbType="VarChar(25)")]
		public string socmnd
		{
			get
			{
				return this._socmnd;
			}
			set
			{
				if ((this._socmnd != value))
				{
					this.OnsocmndChanging(value);
					this.SendPropertyChanging();
					this._socmnd = value;
					this.SendPropertyChanged("socmnd");
					this.OnsocmndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hoten", DbType="VarChar(25)")]
		public string hoten
		{
			get
			{
				return this._hoten;
			}
			set
			{
				if ((this._hoten != value))
				{
					this.OnhotenChanging(value);
					this.SendPropertyChanging();
					this._hoten = value;
					this.SendPropertyChanged("hoten");
					this.OnhotenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diachi", DbType="VarChar(250)")]
		public string diachi
		{
			get
			{
				return this._diachi;
			}
			set
			{
				if ((this._diachi != value))
				{
					this.OndiachiChanging(value);
					this.SendPropertyChanging();
					this._diachi = value;
					this.SendPropertyChanged("diachi");
					this.OndiachiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="benhnhan_khambenh", Storage="_khambenhs", ThisKey="msbn", OtherKey="msbn")]
		public EntitySet<khambenh> khambenhs
		{
			get
			{
				return this._khambenhs;
			}
			set
			{
				this._khambenhs.Assign(value);
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
		
		private void attach_khambenhs(khambenh entity)
		{
			this.SendPropertyChanging();
			entity.benhnhan = this;
		}
		
		private void detach_khambenhs(khambenh entity)
		{
			this.SendPropertyChanging();
			entity.benhnhan = null;
		}
	}
}
#pragma warning restore 1591
