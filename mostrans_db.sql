USE [DC_Monitoring]
GO
/****** Object:  Table [dbo].[dc_cab]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_cab](
	[kodecab] [varchar](5) NULL,
	[namacab] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_expedisi]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_expedisi](
	[expcode] [varchar](20) NULL,
	[expname] [varchar](100) NULL,
	[expnamespell] [varchar](200) NULL,
	[email] [varchar](100) NULL,
	[hpWA] [varchar](20) NULL,
	[UserID] [varchar](20) NULL,
	[UserPass] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_jeniskend]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_jeniskend](
	[kodekend] [varchar](20) NULL,
	[jeniskend] [varchar](100) NULL,
	[kubikasi] [numeric](10, 2) NULL,
	[Tonase] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kedatangani]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kedatangani](
	[kodedc] [varchar](20) NULL,
	[noantrian] [varchar](20) NULL,
	[expcode] [varchar](20) NULL,
	[kodekend] [varchar](20) NULL,
	[nokend] [varchar](20) NULL,
	[namadriver] [varchar](100) NULL,
	[pkedatangan] [varchar](100) NULL,
	[kedatangan] [datetime] NULL,
	[punload] [varchar](100) NULL,
	[startunload] [datetime] NULL,
	[finunload] [datetime] NULL,
	[tpantrian] [varchar](50) NULL,
	[flagstatus] [varchar](20) NULL,
	[pcheckdokumen] [varchar](100) NULL,
	[tcheckdokumen] [datetime] NULL,
	[dc_petugas] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kedatangano]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kedatangano](
	[listpick] [varchar](20) NULL,
	[kodecaba] [varchar](5) NULL,
	[expcode] [varchar](20) NULL,
	[kodekend] [varchar](20) NULL,
	[nokend] [varchar](20) NULL,
	[namadriver] [varchar](100) NULL,
	[pkedatangan] [varchar](100) NULL,
	[kedatangan] [datetime] NULL,
	[dock_no] [varchar](10) NULL,
	[staging_line] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kedatanganp]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kedatanganp](
	[attribute1] [varchar](240) NULL,
	[attribute2] [varchar](240) NULL,
	[attribute3] [varchar](240) NULL,
	[attribute4] [varchar](240) NULL,
	[attribute5] [bigint] IDENTITY(1,1) NOT NULL,
	[attribute6] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kedatanganq]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kedatanganq](
	[attribute1] [varchar](500) NULL,
	[attribute2] [varchar](100) NULL,
	[attribute3] [datetime] NULL,
	[attribute4] [varchar](1) NULL,
	[dc] [varchar](10) NULL,
	[myseq] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kontak]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kontak](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [varchar](50) NOT NULL,
	[ExternalID] [varchar](50) NOT NULL,
	[Nama] [varchar](100) NOT NULL,
	[NamaPerusahaan] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Alamat] [varchar](250) NOT NULL,
	[DetailAlamat] [varchar](250) NOT NULL,
	[latitude] [varchar](50) NOT NULL,
	[longitude] [varchar](50) NOT NULL,
	[NomorKontak] [varchar](50) NOT NULL,
	[Kota] [varchar](50) NOT NULL,
	[KodePos] [varchar](10) NOT NULL,
	[TipeCustomer] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dc_kontak] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_kontak_admin]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_kontak_admin](
	[AdminID] [varchar](50) NOT NULL,
	[PerusahaanID] [int] NOT NULL,
	[Nama] [varchar](100) NOT NULL,
	[NomorKontak] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[FileFoto] [varchar](100) NOT NULL,
	[MyPWD] [varbinary](8000) NOT NULL,
 CONSTRAINT [PK_dc_kontak_admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_logproses]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_logproses](
	[dc] [varchar](3) NULL,
	[dc_status] [varchar](1) NULL,
	[dc_tgl] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_manp]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_manp](
	[manp01] [varchar](100) NOT NULL,
	[manp02] [varchar](100) NOT NULL,
	[shift01] [varchar](20) NOT NULL,
	[shiftflag] [varchar](1) NOT NULL,
	[tgl01] [date] NOT NULL,
	[tgl02] [date] NOT NULL,
	[idmanp] [varbinary](8000) NULL,
	[rdc] [varchar](10) NULL,
	[attribute1] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_master_perusahaan]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_master_perusahaan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NamaPerusahaan] [varchar](100) NOT NULL,
	[KodePerusahaan] [varchar](3) NOT NULL,
 CONSTRAINT [PK_dc_master_perusahaan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_mstexpedisi]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_mstexpedisi](
	[mynum] [numeric](18, 0) NULL,
	[txtnum] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_nothing]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_nothing](
	[nothing01] [varchar](100) NOT NULL,
	[nothing02] [varchar](100) NOT NULL,
	[nothing03] [varchar](100) NOT NULL,
	[nothing04] [varchar](100) NOT NULL,
	[nothing05] [varchar](100) NOT NULL,
	[nothing06] [varchar](100) NOT NULL,
	[nothing07] [varchar](100) NOT NULL,
	[nothing08] [varchar](100) NOT NULL,
	[nothing09] [varchar](100) NOT NULL,
	[nothing10] [varchar](100) NOT NULL,
	[survey01] [varchar](100) NOT NULL,
	[survey02] [varchar](100) NOT NULL,
	[survey03] [varchar](100) NOT NULL,
	[survey04] [varchar](100) NOT NULL,
	[survey05] [varchar](100) NOT NULL,
	[survey06] [varchar](100) NOT NULL,
	[survey07] [varchar](100) NOT NULL,
	[survey08] [varchar](100) NOT NULL,
	[survey09] [varchar](100) NOT NULL,
	[survey10] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nothing01] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_petugas]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_petugas](
	[dc_type] [varchar](50) NULL,
	[dc_petugas] [varchar](100) NULL,
	[dc_foto] [varchar](100) NULL,
	[dc_jabatan] [varchar](100) NULL,
	[dc] [varchar](3) NULL,
	[dc_level] [numeric](3, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_plano]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_plano](
	[listpick] [varchar](20) NULL,
	[kodecaba] [varchar](5) NULL,
	[dateplan] [datetime] NULL,
	[dateactual] [datetime] NULL,
	[kodecabt] [varchar](5) NULL,
	[expcode] [varchar](20) NULL,
	[kodekend] [varchar](20) NULL,
	[plankonsol] [datetime] NULL,
	[actualkonsol] [datetime] NULL,
	[splanload] [datetime] NULL,
	[fplanload] [datetime] NULL,
	[sactualload] [datetime] NULL,
	[factualload] [datetime] NULL,
	[splan_sj] [datetime] NULL,
	[fplan_sj] [datetime] NULL,
	[sactual_sj] [datetime] NULL,
	[factual_sj] [datetime] NULL,
	[screated_by] [varchar](50) NULL,
	[screated_date] [datetime] NULL,
	[supdated_by] [varchar](50) NULL,
	[supdated_date] [datetime] NULL,
	[planpicking] [datetime] NULL,
	[actualpicking] [datetime] NULL,
	[planpacking] [datetime] NULL,
	[actualpacking] [datetime] NULL,
	[upload_batch] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_seq]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_seq](
	[kodedc] [varchar](20) NULL,
	[prd] [varchar](20) NULL,
	[seq] [numeric](3, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_statuscode]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_statuscode](
	[KodeStatus] [int] IDENTITY(1,1) NOT NULL,
	[NamaStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DC_StatusCode] PRIMARY KEY CLUSTERED 
(
	[KodeStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dc_temp_email]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dc_temp_email](
	[email] [varchar](100) NOT NULL,
	[date] [varchar](100) NOT NULL,
	[id] [varchar](100) NOT NULL,
	[flag] [int] NOT NULL,
	[createdate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_driver_info]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_driver_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[external_id] [varchar](30) NOT NULL,
	[no_ktp] [varchar](16) NOT NULL,
	[no_sim] [varchar](16) NOT NULL,
	[foto_driver] [varchar](50) NOT NULL,
	[foto_ktp] [varchar](50) NOT NULL,
	[foto_sim] [varchar](50) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_jenis_kendaraan]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_jenis_kendaraan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jenis_kendaraan] [varchar](30) NOT NULL,
	[category] [varchar](20) NOT NULL,
	[berat_maksimal] [decimal](18, 2) NOT NULL,
	[dimensi_maksimal] [decimal](18, 2) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
 CONSTRAINT [PK__mt_maste__3213E83F84A097CE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_kendaraan]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_kendaraan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[external_id] [varchar](30) NOT NULL,
	[jenis_kendaraan] [int] NOT NULL,
	[plat_nomor] [varchar](10) NOT NULL,
	[active] [varchar](1) NOT NULL,
	[nomor_kir] [varchar](30) NOT NULL,
	[jatuh_tempo_kir] [date] NOT NULL,
	[pool_id] [int] NOT NULL,
	[dedicated] [varchar](1) NOT NULL,
	[kendaraan_id] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
 CONSTRAINT [PK__mt_maste__3213E83F62F01301] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_kota]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_kota](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_pool]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_pool](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[kode] [varchar](10) NOT NULL,
	[alamat1] [varchar](255) NOT NULL,
	[alamat2] [varchar](255) NOT NULL,
	[phone] [varchar](15) NOT NULL,
	[kota] [varchar](20) NOT NULL,
	[kode_pos] [varchar](10) NOT NULL,
	[kordinat_lokasi] [varchar](25) NOT NULL,
	[transporter_id] [int] NOT NULL,
	[foto_pool] [varchar](50) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_shipper]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_shipper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kode_shipper] [varchar](3) NOT NULL,
	[nama_shipper] [varchar](30) NOT NULL,
	[alamat] [varchar](50) NOT NULL,
	[phone] [varchar](15) NOT NULL,
	[foto_npwp] [varchar](50) NOT NULL,
	[foto_siup] [varchar](50) NOT NULL,
	[foto_tdp] [varchar](50) NOT NULL,
	[foto_akte] [varchar](50) NOT NULL,
	[active] [varchar](1) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_tipe_customer]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_tipe_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipe_customer] [varchar](20) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_transporter]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_transporter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama_transporter] [varchar](30) NOT NULL,
	[alamat] [varchar](255) NOT NULL,
	[phone] [varchar](15) NOT NULL,
	[jam_mulai] [time](4) NOT NULL,
	[jam_tutup] [time](4) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_trip]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_trip](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_trip] [varchar](30) NOT NULL,
	[transporter_id] [int] NOT NULL,
	[driver_id] [int] NOT NULL,
	[kendaraan_id] [int] NOT NULL,
	[asal] [int] NOT NULL,
	[tujuan] [int] NOT NULL,
	[tanggal_pengiriman] [date] NOT NULL,
	[jam_pengiriman] [time](4) NOT NULL,
	[tanggal_sampai] [date] NOT NULL,
	[jam_sampai] [time](4) NOT NULL,
	[status] [varchar](15) NOT NULL,
	[lat] [varchar](20) NOT NULL,
	[lang] [varchar](20) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_master_user]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_master_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[hp] [varchar](15) NOT NULL,
	[email] [varchar](80) NOT NULL,
	[password] [varbinary](8000) NOT NULL,
	[role] [varchar](15) NOT NULL,
	[hak_akses] [varchar](5) NOT NULL,
	[active] [varchar](1) NOT NULL,
	[shipper_id] [int] NOT NULL,
	[transporter_id] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
 CONSTRAINT [PK__mt_maste__3213E83FD638102C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_shipper_contact]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_shipper_contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[external_id] [varchar](30) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[nama_perusahaan] [varchar](50) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[alamat1] [varchar](255) NOT NULL,
	[alamat2] [varchar](255) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[kota] [varchar](30) NOT NULL,
	[kode_pos] [varchar](10) NOT NULL,
	[is_transit] [varchar](1) NOT NULL,
	[shipper_id] [int] NOT NULL,
	[jenis_kendaraan_id] [int] NOT NULL,
	[lat] [varchar](20) NOT NULL,
	[lang] [varchar](20) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
 CONSTRAINT [PK__mt_shipp__3213E83FB97ED2D0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_shipper_order]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_shipper_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [varchar](30) NOT NULL,
	[status] [int] NOT NULL,
	[customer_reference] [varchar](255) NOT NULL,
	[remarks] [varchar](255) NOT NULL,
	[shipment_number] [varchar](50) NOT NULL,
	[weight] [decimal](18, 2) NOT NULL,
	[dimension] [decimal](18, 2) NOT NULL,
	[tipe_customer_id] [int] NOT NULL,
	[shipper_id] [int] NOT NULL,
	[tipe_kendaraan] [varchar](10) NOT NULL,
	[booked_date] [datetime] NOT NULL,
	[booked_by] [int] NOT NULL,
	[confirmed_date] [datetime] NOT NULL,
	[confirmed_by] [int] NOT NULL,
	[accepted_date] [datetime] NOT NULL,
	[accepted_by] [int] NOT NULL,
	[arrival_date] [datetime] NOT NULL,
	[startLoaded_date] [datetime] NOT NULL,
	[finishLoaded_date] [datetime] NOT NULL,
	[onTheWay_date] [datetime] NOT NULL,
	[startUnloaded_date] [datetime] NOT NULL,
	[finishUnloaded_date] [datetime] NOT NULL,
	[pod_date] [datetime] NOT NULL,
	[cancel_date] [datetime] NOT NULL,
	[length] [decimal](18, 2) NOT NULL,
	[width] [decimal](18, 2) NOT NULL,
	[height] [decimal](18, 2) NOT NULL,
	[fee] [decimal](18, 2) NOT NULL,
	[asal] [int] NOT NULL,
	[tujuan] [int] NOT NULL,
	[tipe_muatan] [varchar](15) NOT NULL,
	[tipe_armada] [varchar](15) NOT NULL,
	[instruksi] [varchar](255) NOT NULL,
	[dokumen_pod] [varchar](50) NOT NULL,
	[deskripsi_dokumen] [varchar](255) NOT NULL,
	[jadwal_penjemputan] [datetime] NOT NULL,
	[jadwal_sampai] [datetime] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_shipper_order_detail]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_shipper_order_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[tipe] [varchar](10) NOT NULL,
	[deskripsi] [varchar](255) NOT NULL,
	[qty] [int] NOT NULL,
	[dimensi] [decimal](18, 2) NOT NULL,
	[berat] [decimal](18, 2) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_shipper_order_status]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_shipper_order_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](20) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_shipper_rekening]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_shipper_rekening](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama_bank] [varchar](20) NOT NULL,
	[no_rekening] [varchar](20) NOT NULL,
	[contact_id] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_transporter_contact]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_transporter_contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[external_id] [varchar](30) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[nama_perusahaan] [varchar](50) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[alamat1] [varchar](255) NOT NULL,
	[alamat2] [varchar](255) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[kota] [varchar](30) NOT NULL,
	[kode_pos] [varchar](10) NOT NULL,
	[is_transit] [varchar](1) NOT NULL,
	[transporter_id] [int] NOT NULL,
	[jenis_kendaraan_id] [int] NOT NULL,
	[lat] [varchar](20) NOT NULL,
	[lang] [varchar](20) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
 CONSTRAINT [PK__mt_trans__3213E83F382D1C35] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_transporter_rekening]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_transporter_rekening](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama_bank] [varchar](20) NOT NULL,
	[no_rekening] [varchar](20) NOT NULL,
	[contact_id] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mt_trip_order_transaction]    Script Date: 23/03/2020 13:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mt_trip_order_transaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NOT NULL,
	[id_trip] [int] NOT NULL,
	[status] [varchar](15) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[create_by] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
	[update_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dc_expedisi] ADD  CONSTRAINT [DF_dc_expedisi_email]  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[dc_expedisi] ADD  CONSTRAINT [DF_dc_expedisi_hpWA]  DEFAULT ('') FOR [hpWA]
GO
ALTER TABLE [dbo].[dc_expedisi] ADD  CONSTRAINT [DF_dc_expedisi_UserID]  DEFAULT ('') FOR [UserID]
GO
ALTER TABLE [dbo].[dc_expedisi] ADD  CONSTRAINT [DF_dc_expedisi_UserPass]  DEFAULT ('') FOR [UserPass]
GO
ALTER TABLE [dbo].[dc_kedatangano] ADD  DEFAULT ('') FOR [dock_no]
GO
ALTER TABLE [dbo].[dc_kedatangano] ADD  DEFAULT ('') FOR [staging_line]
GO
ALTER TABLE [dbo].[dc_kedatanganq] ADD  DEFAULT (getdate()) FOR [attribute3]
GO
ALTER TABLE [dbo].[dc_kedatanganq] ADD  DEFAULT ('N') FOR [attribute4]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_AdminID]  DEFAULT ('') FOR [AdminID]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_ExternalID]  DEFAULT ('') FOR [ExternalID]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_Nama]  DEFAULT ('') FOR [Nama]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_NamaPerusahaan]  DEFAULT ('') FOR [NamaPerusahaan]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_Alamat]  DEFAULT ('') FOR [Alamat]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_DetailAlamat]  DEFAULT ('') FOR [DetailAlamat]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_latitude]  DEFAULT ('') FOR [latitude]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_longitude]  DEFAULT ('') FOR [longitude]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_NomorKontak]  DEFAULT ('') FOR [NomorKontak]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_Kota]  DEFAULT ('') FOR [Kota]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_KodePos]  DEFAULT ('') FOR [KodePos]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_TipeCustomer]  DEFAULT ('') FOR [TipeCustomer]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_Status]  DEFAULT ('N') FOR [Status]
GO
ALTER TABLE [dbo].[dc_kontak] ADD  CONSTRAINT [DF_dc_kontak_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT ('') FOR [manp01]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT ('') FOR [manp02]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT ('') FOR [shift01]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT ('I') FOR [shiftflag]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT (getdate()) FOR [tgl01]
GO
ALTER TABLE [dbo].[dc_manp] ADD  DEFAULT (getdate()) FOR [tgl02]
GO
ALTER TABLE [dbo].[dc_master_perusahaan] ADD  CONSTRAINT [DF_dc_master_perusahaan_KodePerusahaan]  DEFAULT ('') FOR [KodePerusahaan]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing01]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing02]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing03]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing04]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing05]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing06]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing07]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing08]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing09]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [nothing10]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey01]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey02]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey03]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey04]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey05]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey06]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey07]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey08]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey09]
GO
ALTER TABLE [dbo].[dc_nothing] ADD  DEFAULT ('') FOR [survey10]
GO
ALTER TABLE [dbo].[dc_temp_email] ADD  CONSTRAINT [DF_dc_temp_email_flag]  DEFAULT ((0)) FOR [flag]
GO
ALTER TABLE [dbo].[dc_temp_email] ADD  CONSTRAINT [DF_dc_temp_email_createdate]  DEFAULT (getdate()) FOR [createdate]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [external_id]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [no_ktp]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [no_sim]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [foto_driver]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [foto_ktp]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT ('') FOR [foto_sim]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_driver_info] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_jenis_kendaraan] ADD  CONSTRAINT [DF__mt_master__jenis__7FEAFD3E]  DEFAULT ('') FOR [jenis_kendaraan]
GO
ALTER TABLE [dbo].[mt_master_jenis_kendaraan] ADD  CONSTRAINT [DF__mt_master__categ__00DF2177]  DEFAULT ('') FOR [category]
GO
ALTER TABLE [dbo].[mt_master_jenis_kendaraan] ADD  CONSTRAINT [DF__mt_master__creat__01D345B0]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_jenis_kendaraan] ADD  CONSTRAINT [DF__mt_master__updat__02C769E9]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__exter__43A1090D]  DEFAULT ('') FOR [external_id]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__plat___44952D46]  DEFAULT ('') FOR [plat_nomor]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__activ__4589517F]  DEFAULT ('I') FOR [active]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__nomor__467D75B8]  DEFAULT ('') FOR [nomor_kir]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__dedic__477199F1]  DEFAULT ('n') FOR [dedicated]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF_mt_master_kendaraan_kendaraan_id]  DEFAULT ((0)) FOR [kendaraan_id]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__creat__4865BE2A]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_kendaraan] ADD  CONSTRAINT [DF__mt_master__updat__4959E263]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [nama]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [kode]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [alamat1]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [alamat2]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [kota]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [kode_pos]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [kordinat_lokasi]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT ('') FOR [foto_pool]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_pool] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [kode_shipper]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [nama_shipper]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [alamat]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [foto_npwp]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [foto_siup]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [foto_tdp]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('') FOR [foto_akte]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT ('I') FOR [active]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_shipper] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_tipe_customer] ADD  DEFAULT ('') FOR [tipe_customer]
GO
ALTER TABLE [dbo].[mt_master_tipe_customer] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_tipe_customer] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT ('') FOR [nama_transporter]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT ('') FOR [alamat]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT ('0:0:0') FOR [jam_mulai]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT ('0:0:0') FOR [jam_tutup]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_transporter] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_trip] ADD  DEFAULT ('') FOR [id_trip]
GO
ALTER TABLE [dbo].[mt_master_trip] ADD  DEFAULT ('planning') FOR [status]
GO
ALTER TABLE [dbo].[mt_master_trip] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_trip] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master___nama__731B1205]  DEFAULT ('') FOR [nama]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master_us__hp__740F363E]  DEFAULT ('') FOR [hp]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master__email__75035A77]  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master___role__76EBA2E9]  DEFAULT ('') FOR [role]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master__hak_a__77DFC722]  DEFAULT ('') FOR [hak_akses]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master__activ__78D3EB5B]  DEFAULT ('I') FOR [active]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master__creat__79C80F94]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_master_user] ADD  CONSTRAINT [DF__mt_master__updat__7ABC33CD]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__exter__0B5CAFEA]  DEFAULT ('') FOR [external_id]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF_mt_shipper_contact_nama]  DEFAULT ('') FOR [nama]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__nama___0C50D423]  DEFAULT ('') FOR [nama_perusahaan]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__email__0D44F85C]  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__alama__0E391C95]  DEFAULT ('') FOR [alamat1]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__alama__0F2D40CE]  DEFAULT ('') FOR [alamat2]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__phone__10216507]  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shipper__kota__11158940]  DEFAULT ('') FOR [kota]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__kode___1209AD79]  DEFAULT ('') FOR [kode_pos]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__is_tr__12FDD1B2]  DEFAULT ('') FOR [is_transit]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__creat__13F1F5EB]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_shipper_contact] ADD  CONSTRAINT [DF__mt_shippe__updat__14E61A24]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [id_order]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [customer_reference]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [remarks]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [shipment_number]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [tipe_kendaraan]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [booked_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ((0)) FOR [booked_by]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [confirmed_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ((0)) FOR [confirmed_by]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [accepted_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ((0)) FOR [accepted_by]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [arrival_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [startLoaded_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [finishLoaded_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [onTheWay_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [startUnloaded_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [finishUnloaded_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [pod_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [cancel_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [tipe_muatan]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [tipe_armada]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [instruksi]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [dokumen_pod]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT ('') FOR [deskripsi_dokumen]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_shipper_order] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_shipper_order_detail] ADD  DEFAULT ('') FOR [tipe]
GO
ALTER TABLE [dbo].[mt_shipper_order_detail] ADD  DEFAULT ('') FOR [deskripsi]
GO
ALTER TABLE [dbo].[mt_shipper_order_detail] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_shipper_order_detail] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_shipper_order_status] ADD  DEFAULT ('booked') FOR [nama]
GO
ALTER TABLE [dbo].[mt_shipper_order_status] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_shipper_order_status] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_shipper_rekening] ADD  DEFAULT ('') FOR [nama_bank]
GO
ALTER TABLE [dbo].[mt_shipper_rekening] ADD  DEFAULT ('') FOR [no_rekening]
GO
ALTER TABLE [dbo].[mt_shipper_rekening] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_shipper_rekening] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__exter__17C286CF]  DEFAULT ('') FOR [external_id]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF_mt_transporter_contact_nama]  DEFAULT ('') FOR [nama]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__nama___18B6AB08]  DEFAULT ('') FOR [nama_perusahaan]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__email__19AACF41]  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__alama__1A9EF37A]  DEFAULT ('') FOR [alamat1]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__alama__1B9317B3]  DEFAULT ('') FOR [alamat2]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__phone__1C873BEC]  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transpo__kota__1D7B6025]  DEFAULT ('') FOR [kota]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__kode___1E6F845E]  DEFAULT ('') FOR [kode_pos]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__is_tr__1F63A897]  DEFAULT ('') FOR [is_transit]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__creat__2057CCD0]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_transporter_contact] ADD  CONSTRAINT [DF__mt_transp__updat__214BF109]  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_transporter_rekening] ADD  DEFAULT ('') FOR [nama_bank]
GO
ALTER TABLE [dbo].[mt_transporter_rekening] ADD  DEFAULT ('') FOR [no_rekening]
GO
ALTER TABLE [dbo].[mt_transporter_rekening] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_transporter_rekening] ADD  DEFAULT (getdate()) FOR [update_date]
GO
ALTER TABLE [dbo].[mt_trip_order_transaction] ADD  DEFAULT ('waiting') FOR [status]
GO
ALTER TABLE [dbo].[mt_trip_order_transaction] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[mt_trip_order_transaction] ADD  DEFAULT (getdate()) FOR [update_date]
GO
