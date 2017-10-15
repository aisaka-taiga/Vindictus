﻿using System;
using System.Data.Linq.Mapping;

namespace ServiceCore.HeroesContents
{
	[Table(Name = "dbo.GemstoneInfo")]
	public class GemstoneInfo
	{
		[Column(Storage = "_ID", DbType = "Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if (this._ID != value)
				{
					this._ID = value;
				}
			}
		}

		[Column(Storage = "_Type", DbType = "Int NOT NULL")]
		public int Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if (this._Type != value)
				{
					this._Type = value;
				}
			}
		}

		[Column(Storage = "_ItemClass", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
		public string ItemClass
		{
			get
			{
				return this._ItemClass;
			}
			set
			{
				if (this._ItemClass != value)
				{
					this._ItemClass = value;
				}
			}
		}

		[Column(Storage = "_Grade", DbType = "Int NOT NULL")]
		public int Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				if (this._Grade != value)
				{
					this._Grade = value;
				}
			}
		}

		[Column(Storage = "_CombinationPrice", DbType = "Int NOT NULL")]
		public int CombinationPrice
		{
			get
			{
				return this._CombinationPrice;
			}
			set
			{
				if (this._CombinationPrice != value)
				{
					this._CombinationPrice = value;
				}
			}
		}

		[Column(Storage = "_ChangingPrice", DbType = "Int NOT NULL")]
		public int ChangingPrice
		{
			get
			{
				return this._ChangingPrice;
			}
			set
			{
				if (this._ChangingPrice != value)
				{
					this._ChangingPrice = value;
				}
			}
		}

		[Column(Storage = "_ATK", DbType = "Int NOT NULL")]
		public int ATK
		{
			get
			{
				return this._ATK;
			}
			set
			{
				if (this._ATK != value)
				{
					this._ATK = value;
				}
			}
		}

		[Column(Storage = "_ATK_Speed", DbType = "Int NOT NULL")]
		public int ATK_Speed
		{
			get
			{
				return this._ATK_Speed;
			}
			set
			{
				if (this._ATK_Speed != value)
				{
					this._ATK_Speed = value;
				}
			}
		}

		[Column(Storage = "_Critical", DbType = "Int NOT NULL")]
		public int Critical
		{
			get
			{
				return this._Critical;
			}
			set
			{
				if (this._Critical != value)
				{
					this._Critical = value;
				}
			}
		}

		[Column(Storage = "_Balance", DbType = "Int NOT NULL")]
		public int Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if (this._Balance != value)
				{
					this._Balance = value;
				}
			}
		}

		[Column(Storage = "_MATK", DbType = "Int NOT NULL")]
		public int MATK
		{
			get
			{
				return this._MATK;
			}
			set
			{
				if (this._MATK != value)
				{
					this._MATK = value;
				}
			}
		}

		[Column(Storage = "_DEF", DbType = "Int NOT NULL")]
		public int DEF
		{
			get
			{
				return this._DEF;
			}
			set
			{
				if (this._DEF != value)
				{
					this._DEF = value;
				}
			}
		}

		[Column(Storage = "_Res_Critical", DbType = "Int NOT NULL")]
		public int Res_Critical
		{
			get
			{
				return this._Res_Critical;
			}
			set
			{
				if (this._Res_Critical != value)
				{
					this._Res_Critical = value;
				}
			}
		}

		[Column(Storage = "_PVP_ATK", DbType = "Int NOT NULL")]
		public int PVP_ATK
		{
			get
			{
				return this._PVP_ATK;
			}
			set
			{
				if (this._PVP_ATK != value)
				{
					this._PVP_ATK = value;
				}
			}
		}

		[Column(Storage = "_PVP_MATK", DbType = "Int NOT NULL")]
		public int PVP_MATK
		{
			get
			{
				return this._PVP_MATK;
			}
			set
			{
				if (this._PVP_MATK != value)
				{
					this._PVP_MATK = value;
				}
			}
		}

		[Column(Storage = "_PVP_DEF", DbType = "Int NOT NULL")]
		public int PVP_DEF
		{
			get
			{
				return this._PVP_DEF;
			}
			set
			{
				if (this._PVP_DEF != value)
				{
					this._PVP_DEF = value;
				}
			}
		}

		[Column(Storage = "_STR", DbType = "Int NOT NULL")]
		public int STR
		{
			get
			{
				return this._STR;
			}
			set
			{
				if (this._STR != value)
				{
					this._STR = value;
				}
			}
		}

		[Column(Storage = "_DEX", DbType = "Int NOT NULL")]
		public int DEX
		{
			get
			{
				return this._DEX;
			}
			set
			{
				if (this._DEX != value)
				{
					this._DEX = value;
				}
			}
		}

		[Column(Storage = "_INT", DbType = "Int NOT NULL")]
		public int INT
		{
			get
			{
				return this._INT;
			}
			set
			{
				if (this._INT != value)
				{
					this._INT = value;
				}
			}
		}

		[Column(Storage = "_WILL", DbType = "Int NOT NULL")]
		public int WILL
		{
			get
			{
				return this._WILL;
			}
			set
			{
				if (this._WILL != value)
				{
					this._WILL = value;
				}
			}
		}

		[Column(Storage = "_LUCK", DbType = "Int NOT NULL")]
		public int LUCK
		{
			get
			{
				return this._LUCK;
			}
			set
			{
				if (this._LUCK != value)
				{
					this._LUCK = value;
				}
			}
		}

		[Column(Storage = "_HP", DbType = "Int NOT NULL")]
		public int HP
		{
			get
			{
				return this._HP;
			}
			set
			{
				if (this._HP != value)
				{
					this._HP = value;
				}
			}
		}

		[Column(Storage = "_STAMINA", DbType = "Int NOT NULL")]
		public int STAMINA
		{
			get
			{
				return this._STAMINA;
			}
			set
			{
				if (this._STAMINA != value)
				{
					this._STAMINA = value;
				}
			}
		}

		[Column(Storage = "_TOWN_SPEED", DbType = "Int NOT NULL")]
		public int TOWN_SPEED
		{
			get
			{
				return this._TOWN_SPEED;
			}
			set
			{
				if (this._TOWN_SPEED != value)
				{
					this._TOWN_SPEED = value;
				}
			}
		}

		[Column(Storage = "_Feature", DbType = "NVarChar(128)")]
		public string Feature
		{
			get
			{
				return this._Feature;
			}
			set
			{
				if (this._Feature != value)
				{
					this._Feature = value;
				}
			}
		}

		private int _ID;

		private int _Type;

		private string _ItemClass;

		private int _Grade;

		private int _CombinationPrice;

		private int _ChangingPrice;

		private int _ATK;

		private int _ATK_Speed;

		private int _Critical;

		private int _Balance;

		private int _MATK;

		private int _DEF;

		private int _Res_Critical;

		private int _PVP_ATK;

		private int _PVP_MATK;

		private int _PVP_DEF;

		private int _STR;

		private int _DEX;

		private int _INT;

		private int _WILL;

		private int _LUCK;

		private int _HP;

		private int _STAMINA;

		private int _TOWN_SPEED;

		private string _Feature;
	}
}
