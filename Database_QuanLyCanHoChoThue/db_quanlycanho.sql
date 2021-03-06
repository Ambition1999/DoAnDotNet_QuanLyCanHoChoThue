USE [QL_CANHO]
GO
/****** Object:  Table [dbo].[can_ho]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[can_ho](
	[Ma_CanHo] [varchar](10) NOT NULL,
	[Ma_ToaNha] [int] NOT NULL,
	[Tang] [int] NULL,
	[TienThue] [money] NULL,
	[DonViTien] [nvarchar](50) NULL,
	[DienTich] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_can_ho_1] PRIMARY KEY CLUSTERED 
(
	[Ma_CanHo] ASC,
	[Ma_ToaNha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chi_tiet_can_ho]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chi_tiet_can_ho](
	[MaCanHo] [varchar](10) NOT NULL,
	[MaToaNha] [int] NOT NULL,
	[ThangMay] [nvarchar](5) NULL,
	[BanCong] [nvarchar](5) NULL,
	[NoiThat] [nvarchar](50) NULL,
	[HinhAnh] [varchar](150) NULL,
 CONSTRAINT [PK_chi_tiet_can_ho] PRIMARY KEY CLUSTERED 
(
	[MaCanHo] ASC,
	[MaToaNha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[giao_dich]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giao_dich](
	[Ma_GD] [int] IDENTITY(1,1) NOT NULL,
	[NgayDaoHan] [datetime] NULL,
	[PhiThue] [money] NULL,
	[PhiTraCham] [money] NULL,
	[Ma_HDThue] [int] NOT NULL,
	[Ma_ThanhToan] [int] NOT NULL,
 CONSTRAINT [PK_giao_dich] PRIMARY KEY CLUSTERED 
(
	[Ma_GD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hd_thue]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hd_thue](
	[Ma_HDThue] [int] IDENTITY(1,1) NOT NULL,
	[NgayBatDau] [smalldatetime] NULL,
	[NgayKetThuc] [smalldatetime] NULL,
	[SoNgayThue] [int] NULL,
	[TongTien] [money] NULL,
	[TienCoc] [money] NULL,
	[TienConLai] [money] NULL,
	[Ma_ToaNha] [int] NOT NULL,
	[Ma_CanHo] [varchar](10) NOT NULL,
	[CMND] [varchar](10) NOT NULL,
 CONSTRAINT [PK_hd_thue] PRIMARY KEY CLUSTERED 
(
	[Ma_HDThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[khach_hang]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[khach_hang](
	[CMND] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[SoDT] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](5) NULL,
 CONSTRAINT [PK_khach_hang_1] PRIMARY KEY CLUSTERED 
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[login]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[login](
	[UserName] [char](20) NOT NULL,
	[PassWord] [char](10) NOT NULL,
	[DiaChiEmail] [varchar](50) NULL,
	[ChucVu] [nchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[thanh_toan]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thanh_toan](
	[Ma_TT] [int] IDENTITY(1,1) NOT NULL,
	[Ma_HDThue] [int] NOT NULL,
	[TienTT] [money] NULL,
	[NgayTT] [datetime] NULL,
 CONSTRAINT [PK_thanh_toan_1] PRIMARY KEY CLUSTERED 
(
	[Ma_TT] ASC,
	[Ma_HDThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[toa_nha]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[toa_nha](
	[Ma_ToaNha] [int] IDENTITY(1,1) NOT NULL,
	[Ten_ToaNha] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Sl_CanHo] [int] NULL,
 CONSTRAINT [PK_toa_nha] PRIMARY KEY CLUSTERED 
(
	[Ma_ToaNha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_101', 13, 1, 7000000.0000, N'VNĐ', N'40(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_101', 19, 1, 10000000.0000, N'VNĐ', N'55(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_101', 20, 1, 12000000.0000, N'VNĐ', N'65(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_102', 12, 1, 7000000.0000, N'VNĐ', N'40(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_103', 12, 1, 7700000.0000, N'VNĐ', N'42(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'1_103', 13, 1, 8500000.0000, N'VNĐ', N'46(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_201', 10, 2, 10000000.0000, N'VNĐ', N'50(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_201', 12, 2, 9000000.0000, N'VNĐ', N'50(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_201', 14, 2, 6500000.0000, N'VNĐ', N'35(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_202', 10, 2, 9000000.0000, N'VNĐ', N'45(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_202', 12, 2, 10000000.0000, N'VNĐ', N'55(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_202', 14, 2, 8000000.0000, N'VNĐ', N'55(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_202', 15, 2, 9000000.0000, N'VNĐ', N'55(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_203', 10, 2, 11000000.0000, N'VNĐ', N'50(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_205', 15, 2, 11000000.0000, N'VNĐ', N'65(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'2_207', 15, 2, 9400000.0000, N'VNĐ', N'57(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'3_301', 11, 3, 8000000.0000, N'VNĐ', N'43(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'3_302', 11, 3, 9000000.0000, N'VNĐ', N'45(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'3_302', 18, 3, 8900000.0000, N'VNĐ', N'45(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'3_303', 10, 3, 10000000.0000, N'VNĐ', N'50(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'3_304', 10, 3, 9000000.0000, N'VNĐ', N'48(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_401', 11, 4, 8000000.0000, N'VNĐ', N'44(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_401', 16, 4, 8000000.0000, N'VNĐ', N'57(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_402', 11, 4, 7000000.0000, N'VNĐ', N'40(m2)', N'Đã thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_402', 16, 4, 8600000.0000, N'VNĐ', N'45(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_402', 17, 4, 7600000.0000, N'VNĐ', N'35(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_403', 17, 4, 100000.0000, N'VNĐ', N'60(m2)', N'Chưa thuê')
INSERT [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha], [Tang], [TienThue], [DonViTien], [DienTich], [TrangThai]) VALUES (N'4_403', 18, 4, 9900000.0000, N'VNĐ', N'55(m2)', N'Đã thuê')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'1_101', 13, N'Không', N'Không', N'Máy lạnh;Tủ lạnh;Bếp ăn', N'vietcombanktower.jpg;vietcombanktower2.jpg;vietcombanktower3.jpg;vietcombanktower4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'1_101', 19, N'Không', N'Không', N'Máy lạnh;Tủ lạnh;Bếp ăn', N'cienco4building.jpg;cienco4building2.jpg;cienco4building3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'1_101', 20, N'Không', N'Không', N'Máy lạnh;Tủ lạnh;Bếp ăn', N'delioffice.jpg;delioffice2.jpg;delioffice4.jpg;delioffice5.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'1_102', 12, N'Không', N'Không', N'Máy lạnh;Tủ lạnh', N'sonatus.jpg;sonatus2.jpg;sonatus3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'1_103', 12, N'Không', N'Không', N'Máy lạnh;Tivi', N'sonatus.jpg;sonatus2.jpg;sonatus3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_201', 10, N'Có', N'Không', N'Máy lạnh;', N'nguyenduytrinh.jpg;nguyenduytrinh2.jpg;nguyenduytrin3.jpg;nguyenduytrinh4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_201', 12, N'Có', N'Có', N'Máy lạnh;', N'sonatus.jpg;sonatus2.jpg;sonatus3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_201', 14, N'Có', N'Có', N'Máy lạnh;', N'vincomcenter.jpg;vincomcenter2.jpg;vincomcenter3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_202', 10, N'Không', N'Có', N'Máy lạnh;Tủ lạnh', N'nguyenduytrinh.jpg;nguyenduytrinh2.jpg;nguyenduytrin3.jpg;nguyenduytrinh4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_202', 12, N'Có', N'Không', N'Máy lạnh;Tủ lạnh', N'sonatus.jpg;sonatus2.jpg;sonatus3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_202', 14, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'vincomcenter.jpg;vincomcenter2.jpg;vincomcenter3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_202', 15, N'Có', N'Không', N'Máy lạnh;Tủ lạnh', N'centectower.jpg;centectower2.jpg;centectower3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_203', 10, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'nguyenduytrinh.jpg;nguyenduytrinh2.jpg;nguyenduytrin3.jpg;nguyenduytrinh4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_205', 15, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Bếp ăn', N'centectower.jpg;centectower2.jpg;centectower3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'2_207', 15, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'centectower.jpg;centectower2.jpg;centectower3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'3_301', 11, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'vovbuiding.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'3_302', 11, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'vovbuiding.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'3_302', 18, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Bếp ăn', N'mekongoffice.jpg;mekongoffice2.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'3_303', 10, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'nguyenduytrinh.jpg;nguyenduytrinh2.jpg;nguyenduytrin3.jpg;nguyenduytrinh4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'3_304', 10, N'Có', N'Có', N'Máy lạnh;Tủ lạnh', N'nguyenduytrinh.jpg;nguyenduytrinh2.jpg;nguyenduytrin3.jpg;nguyenduytrinh4.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_401', 11, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'vovbuiding.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_401', 16, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'abtower.jpg;abtower2.jpg;abtower3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_402', 11, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'vovbuiding.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_402', 16, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'abtower.jpg;abtower2.jpg;abtower3.jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_402', 17, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'viettelcomplex.jpg;viettelcomplex.2jpg;viettelcomplex.3jpg')
INSERT [dbo].[chi_tiet_can_ho] ([MaCanHo], [MaToaNha], [ThangMay], [BanCong], [NoiThat], [HinhAnh]) VALUES (N'4_403', 18, N'Có', N'Có', N'Máy lạnh;Tủ lạnh;Sân thượng', N'mekongoffice.jpg;mekongoffice2.jpg')
SET IDENTITY_INSERT [dbo].[hd_thue] ON 

INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (6, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xAB750000 AS SmallDateTime), 121, 40333333.3293, 15000000.0000, 7333333.3293, 19, N'1_101', N'011744741')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (7, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xAB940000 AS SmallDateTime), 152, 60800000.0000, 20000000.0000, 40800000.0000, 20, N'1_101', N'011744741')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (9, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xABD10000 AS SmallDateTime), 213, 63900000.0000, 20000000.0000, 43900000.0000, 12, N'2_201', N'230511800')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (10, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xAB750000 AS SmallDateTime), 121, 26216666.6586, 20000000.0000, 6216666.6586, 14, N'2_201', N'230511800')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (11, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xABEF0000 AS SmallDateTime), 243, 72900000.0000, 50000000.0000, 22900000.0000, 10, N'2_202', N'031224439')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (12, CAST(0xAAFC0000 AS SmallDateTime), CAST(0xAD5C0000 AS SmallDateTime), 608, 222933333.2928, 100000000.0000, 122933333.2928, 10, N'2_203', N'022749812')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (13, CAST(0xAAD90000 AS SmallDateTime), CAST(0xACA30000 AS SmallDateTime), 458, 122133333.3028, 60000000.0000, 62133333.3028, 14, N'2_202', N'022073389')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (14, CAST(0xAAD00000 AS SmallDateTime), CAST(0xADAB0000 AS SmallDateTime), 731, 219300000.0000, 90000000.0000, 129300000.0000, 15, N'2_202', N'012398578')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (15, CAST(0xAAAA0000 AS SmallDateTime), CAST(0xAD290000 AS SmallDateTime), 639, 200219999.9787, 40000000.0000, 160219999.9787, 15, N'2_207', N'230511800')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (16, CAST(0xAAAA0000 AS SmallDateTime), CAST(0xAB430000 AS SmallDateTime), 153, 45900000.0000, 20000000.0000, 25900000.0000, 11, N'3_302', N'022749812')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (18, CAST(0xAA120000 AS SmallDateTime), CAST(0xAB9F0000 AS SmallDateTime), 397, 105866666.6402, 30000000.0000, 75866666.6402, 11, N'4_401', N'022749812')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (19, CAST(0xAAC50000 AS SmallDateTime), CAST(0xAC140000 AS SmallDateTime), 335, 89333333.3110, 40000000.0000, 49333333.3110, 16, N'4_401', N'022073389')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (20, CAST(0xA9F10000 AS SmallDateTime), CAST(0xAC140000 AS SmallDateTime), 547, 127633333.3151, 40000000.0000, 87633333.3151, 11, N'4_402', N'022073389')
INSERT [dbo].[hd_thue] ([Ma_HDThue], [NgayBatDau], [NgayKetThuc], [SoNgayThue], [TongTien], [TienCoc], [TienConLai], [Ma_ToaNha], [Ma_CanHo], [CMND]) VALUES (25, CAST(0xA9D80000 AS SmallDateTime), CAST(0xACB30000 AS SmallDateTime), 731, 241230000.0000, 50000000.0000, 101230000.0000, 18, N'4_403', N'022749812')
SET IDENTITY_INSERT [dbo].[hd_thue] OFF
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'011744741', N'Đỗ Thị Thu Hường', N'0903.445.640', NULL, N'Tổ 71, Phường Hoàng Văn Thụ, Hoàng Mai, Hà Nội', N'Nữ')
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'012398578', N'Nguyễn Trọng Thông', N'0913.209.706', NULL, N'Số nhà 19/67/61, Trần Duy Hưng, Trung Hoà, Cầu Giấy, Hà Nội', N'Nam')
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'022073389', N'Trần Quang Trường', N'0903.844.838', NULL, N'Hà Nội', N'Nam')
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'022749812', N'Nguyễn Thanh Nghĩa', N'0903.723.725', NULL, N'23/28 D2, CX Văn Thánh Bắc, P 25, Bình Thạnh, Tp HCM', N'Nam')
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'031224439', N'Đỗ Hữu Hậu', N'0908.858.888', NULL, N'324 Tô Hiệu, Lê Chân, Hải Phòng', N'Nam')
INSERT [dbo].[khach_hang] ([CMND], [TenKH], [SoDT], [Email], [DiaChi], [GioiTinh]) VALUES (N'230511800', N'Đoàn Nguyên Thu', N'0913.437.640', NULL, N'143 Trần Phú, TP Pleiku, tỉnh Gia Lai', N'Nữ')
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'admin               ', N'123       ', NULL, N'admin                                             ')
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'abc                 ', N'1234      ', NULL, NULL)
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'admin123            ', N'abc       ', NULL, NULL)
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'lechitoan           ', N'123       ', NULL, NULL)
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'admin3110           ', N'123       ', NULL, NULL)
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'test12              ', N'123       ', NULL, N'Nhân viên                                         ')
INSERT [dbo].[login] ([UserName], [PassWord], [DiaChiEmail], [ChucVu]) VALUES (N'userTest            ', N'123       ', NULL, N'Nhân viên                                         ')
SET IDENTITY_INSERT [dbo].[thanh_toan] ON 

INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (1, 6, 3000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (3, 6, 10000000.0000, CAST(0x0000AAFD00000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (4, 7, 15000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (5, 7, 12000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (6, 7, 5000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (7, 7, 10000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (9, 6, 5000000.0000, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[thanh_toan] ([Ma_TT], [Ma_HDThue], [TienTT], [NgayTT]) VALUES (10, 25, 90000000.0000, CAST(0x0000AB0100000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[thanh_toan] OFF
SET IDENTITY_INSERT [dbo].[toa_nha] ON 

INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (10, N'TÒA NHÀ 55 NGUYỄN DUY TRINH', N'số 55 Nguyễn Duy Trinh phường Bình Trưng Tây, Quận 2, TPHCM', 5)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (11, N'TÒA NHÀ VOV BUILDING', N'đường Nguyễn Thị Minh Khai phường Bến Nghé, Quận 1, Thành Phố Hồ Chí Minh', 4)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (12, N'TÒA NHÀ SONATUS', N'đường Lê Thánh Tôn phường Bến Nghé, Quận 1, Thành Phố Hồ Chí Minh', 4)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (13, N'TÒA NHÀ VIETCOM BANK TOWER', N'đường Công Trường Mê Linh, Quận 1, TP. Hồ Chí Minh', 2)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (14, N'TÒA NHÀ VINCOM CENTER ', N'đường Lê Thánh Tôn Phường Bến Nghé, Quận 1, Thành Phố Hồ Chí Minh', 2)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (15, N'TÒA NHÀ CENTEC TOWER', N'đường  Nguyễn Thị Minh Khai Phường 6, Quận 3, Thành Phố Hồ Chí Minh', 3)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (16, N'TÒA NHÀ AB TOWER', N'đường Lê Lai phường Bến Nghé, Quận 1, Thành Phố Hồ Chí Minh', 2)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (17, N'TÒA NHÀ VIETTEL COMPLEX', N'đường Cách Mạng tháng 8 phường 12, quận 10, Tp.HCM', 2)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (18, N'TÒA NHÀ MEKONG OFFICE', N'đường Bạch Đằng Phường 2, Quận Tân Bình ,TP.HCM', 2)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (19, N'TÒA NHÀ CIENCO 4 BUILDING', N'đường Nguyễn Thị Minh Khai Phường 6, Quận 3, Thành Phố Hồ Chí Minh', 1)
INSERT [dbo].[toa_nha] ([Ma_ToaNha], [Ten_ToaNha], [DiaChi], [Sl_CanHo]) VALUES (20, N'TÒA NHÀ DELI OFFICE', N'đường Hoàng Văn Thụ , quận Phú Nhuận, Thành Phố Hồ Chí Minh', 1)
SET IDENTITY_INSERT [dbo].[toa_nha] OFF
ALTER TABLE [dbo].[login] ADD  CONSTRAINT [df_chucvu]  DEFAULT (N'Nhân viên') FOR [ChucVu]
GO
ALTER TABLE [dbo].[toa_nha] ADD  CONSTRAINT [DF_toa_nha_Sl_CanHo]  DEFAULT ((0)) FOR [Sl_CanHo]
GO
ALTER TABLE [dbo].[can_ho]  WITH CHECK ADD  CONSTRAINT [FK_can_ho_toa_nha] FOREIGN KEY([Ma_ToaNha])
REFERENCES [dbo].[toa_nha] ([Ma_ToaNha])
GO
ALTER TABLE [dbo].[can_ho] CHECK CONSTRAINT [FK_can_ho_toa_nha]
GO
ALTER TABLE [dbo].[chi_tiet_can_ho]  WITH CHECK ADD  CONSTRAINT [FK_chi_tiet_can_ho_chi_tiet_can_ho] FOREIGN KEY([MaCanHo], [MaToaNha])
REFERENCES [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha])
GO
ALTER TABLE [dbo].[chi_tiet_can_ho] CHECK CONSTRAINT [FK_chi_tiet_can_ho_chi_tiet_can_ho]
GO
ALTER TABLE [dbo].[hd_thue]  WITH CHECK ADD  CONSTRAINT [FK_hd_thue_hd_thue] FOREIGN KEY([Ma_CanHo], [Ma_ToaNha])
REFERENCES [dbo].[can_ho] ([Ma_CanHo], [Ma_ToaNha])
GO
ALTER TABLE [dbo].[hd_thue] CHECK CONSTRAINT [FK_hd_thue_hd_thue]
GO
ALTER TABLE [dbo].[hd_thue]  WITH CHECK ADD  CONSTRAINT [FK_hd_thue_khach_hang] FOREIGN KEY([CMND])
REFERENCES [dbo].[khach_hang] ([CMND])
GO
ALTER TABLE [dbo].[hd_thue] CHECK CONSTRAINT [FK_hd_thue_khach_hang]
GO
ALTER TABLE [dbo].[thanh_toan]  WITH CHECK ADD  CONSTRAINT [FK_thanh_toan_hd_thue] FOREIGN KEY([Ma_HDThue])
REFERENCES [dbo].[hd_thue] ([Ma_HDThue])
GO
ALTER TABLE [dbo].[thanh_toan] CHECK CONSTRAINT [FK_thanh_toan_hd_thue]
GO
ALTER TABLE [dbo].[hd_thue]  WITH CHECK ADD  CONSTRAINT [CK_NGAYBD_KETTHUC] CHECK  ((datediff(day,[NgayBatDau],[NgayKetThuc])>=(90)))
GO
ALTER TABLE [dbo].[hd_thue] CHECK CONSTRAINT [CK_NGAYBD_KETTHUC]
GO
ALTER TABLE [dbo].[thanh_toan]  WITH CHECK ADD  CONSTRAINT [ck_ngayTT] CHECK  (([ngayTT]<=getdate()))
GO
ALTER TABLE [dbo].[thanh_toan] CHECK CONSTRAINT [ck_ngayTT]
GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATSL]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_CAPNHATSL] ON  [dbo].[can_ho] 
AFTER INSERT, UPDATE
AS 
BEGIN
	UPDATE toa_nha
	SET Sl_CanHo = (SELECT COUNT(*) FROM can_ho WHERE Ma_ToaNha = (SELECT Ma_ToaNha FROM inserted))
	FROM toa_nha
	JOIN inserted ON toa_nha.Ma_ToaNha = inserted.Ma_ToaNha
END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATSLSAUKHIXOA]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATSLSAUKHIXOA]
   ON  [dbo].[can_ho]
   AFTER DELETE
AS 
BEGIN
	UPDATE toa_nha
	SET Sl_CanHo = (SELECT COUNT(*) FROM can_ho WHERE Ma_ToaNha = (SELECT Ma_ToaNha FROM deleted))
	FROM toa_nha
	JOIN deleted ON toa_nha.Ma_ToaNha = deleted.Ma_ToaNha
END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTINHTRANG]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATTINHTRANG]
   ON  [dbo].[hd_thue]
   AFTER INSERT,UPDATE
AS 
BEGIN
	DECLARE @MA_CANHO VARCHAR(10), @MA_TOANHA INT
	SELECT @MA_CANHO = Ma_CanHo, @MA_TOANHA = Ma_ToaNha  FROM inserted
	UPDATE can_ho
	SET TrangThai = N'Đã thuê'
	WHERE Ma_CanHo = @MA_CANHO AND Ma_ToaNha = @MA_TOANHA
END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTINHTRANG_SAUKHIXOA]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATTINHTRANG_SAUKHIXOA]
   ON  [dbo].[hd_thue]
   AFTER DELETE
AS 
BEGIN
	DECLARE @MA_CANHO VARCHAR(10), @MA_TOANHA INT
	SELECT @MA_CANHO = Ma_CanHo, @MA_TOANHA = Ma_ToaNha  FROM deleted
	UPDATE can_ho
	SET TrangThai = N'Chưa thuê'
	WHERE Ma_CanHo = @MA_CANHO AND Ma_ToaNha = @MA_TOANHA
END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTONGTIEN]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATTONGTIEN]
   ON  [dbo].[hd_thue]
   AFTER INSERT,UPDATE
AS 
BEGIN
	DECLARE @TIENTHUE MONEY, @TIENCOC MONEY, @MA_HD INT, @NGAYTHUE INT, @NGAYBATDAU DATETIME, @NGAYKETTHUC DATETIME, @TONGTIEN_TT MONEY, @TONGTIEN MONEY
	DECLARE @MA_CANHO VARCHAR(10)
	DECLARE @MA_TOANHA INT
	SELECT @MA_HD = MA_HDTHUE, @MA_CANHO = Ma_CanHo, @MA_TOANHA = Ma_ToaNha, @TIENCOC = TienCoc, @NGAYBATDAU=NgayBatDau, @NGAYKETTHUC = NgayKetThuc FROM inserted
	SET @TIENTHUE = (SELECT TienThue FROM can_ho WHERE Ma_CanHo=@MA_CANHO AND Ma_ToaNha=@MA_TOANHA)
	SET @NGAYTHUE = DATEDIFF(DAY,@NGAYBATDAU,@NGAYKETTHUC)
	SELECT @TONGTIEN_TT = SUM(thanh_toan.TienTT) FROM thanh_toan WHERE @MA_HD = Ma_HDThue
	SELECT @TONGTIEN = TongTien FROM hd_thue WHERE @MA_HD = Ma_HDThue

	IF(@TONGTIEN_TT IS NULL)
		BEGIN
			SET @TONGTIEN_TT = 0
		END

	UPDATE hd_thue
	SET TongTien = @TIENTHUE/30 * @NGAYTHUE, SoNgayThue = (DATEDIFF(DAY,NgayBatDau,NgayKetThuc))
	WHERE Ma_HDThue = @MA_HD
	
	IF(@TONGTIEN - @TIENCOC - @TONGTIEN_TT < 0)
		BEGIN
			PRINT(N'Số tiền thanh toán vượt quá số tiền phải trả. Không thể thực hiện')
			ROLLBACK
		END
	ELSE
		BEGIN
			UPDATE hd_thue
			SET TienConLai = @TONGTIEN - @TIENCOC - @TONGTIEN_TT
			WHERE Ma_HDThue = @MA_HD
		END
	
END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG]
   ON  [dbo].[thanh_toan]
   AFTER UPDATE
AS 
BEGIN
	DECLARE @MA_HDTHUE INT, @MA_TT INT, @TIENCONLAI MONEY, @TIEN_TT_NEW MONEY, @TIEN_TT_OLD MONEY
	SELECT @TIEN_TT_OLD = TienTT FROM deleted
	SELECT @MA_HDTHUE = Ma_HDThue, @MA_TT = Ma_TT, @TIEN_TT_NEW = TienTT FROM inserted
	SELECT @TIENCONLAI = TienConLai  FROM hd_thue WHERE Ma_HDThue = @MA_HDTHUE


	IF(@TIENCONLAI + @TIEN_TT_OLD - @TIEN_TT_NEW <0)
		BEGIN
			PRINT(N'Tiền thanh toán không được vượt quá tiền còn lại')
			ROLLBACK
		END
	ELSE
		BEGIN
			UPDATE hd_thue
			SET TienConLai = @TIENCONLAI + @TIEN_TT_OLD - @TIEN_TT_NEW
			WHERE Ma_HDThue = @MA_HDTHUE
		END

END
GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG_DELETE]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG_DELETE]
   ON [dbo].[thanh_toan]
   AFTER DELETE
AS 
BEGIN
	DECLARE @MA_HDTHUE INT, @MA_TT INT, @TIENCONLAI MONEY, @TIEN_TT_OLD MONEY
	SELECT @MA_HDTHUE = Ma_HDThue, @MA_TT = Ma_TT, @TIEN_TT_OLD = TienTT FROM deleted
	SELECT @TIENCONLAI = TienConLai  FROM hd_thue WHERE Ma_HDThue = @MA_HDTHUE

	UPDATE hd_thue
	SET TienConLai = @TIENCONLAI + @TIEN_TT_OLD
	WHERE Ma_HDThue = @MA_HDTHUE

END

GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG_INSERT]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_CAPNHATTIENCONLAI_TBLHOPDONG_INSERT]
   ON  [dbo].[thanh_toan]
   AFTER INSERT
AS 
BEGIN
	DECLARE @MA_HDTHUE INT, @MA_TT INT, @TIENCONLAI MONEY, @TIEN_TT_NEW MONEY
	SELECT @MA_HDTHUE = Ma_HDThue, @MA_TT = Ma_TT, @TIEN_TT_NEW = TienTT FROM inserted
	SELECT @TIENCONLAI = TienConLai  FROM hd_thue WHERE Ma_HDThue = @MA_HDTHUE


	IF(@TIENCONLAI - @TIEN_TT_NEW <0)
		BEGIN
			PRINT(N'Tiền thanh toán không được vượt quá tiền còn lại')
			ROLLBACK
		END
	ELSE
		BEGIN
			UPDATE hd_thue
			SET TienConLai = @TIENCONLAI - @TIEN_TT_NEW
			WHERE Ma_HDThue = @MA_HDTHUE
		END

END

GO
/****** Object:  Trigger [dbo].[TRG_SETDEFAULT]    Script Date: 18/11/2019 18:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRG_SETDEFAULT] 
   ON  [dbo].[toa_nha]
   AFTER INSERT
AS 
BEGIN
	UPDATE toa_nha
	SET Sl_CanHo = 0
	WHERE Ma_ToaNha = (SELECT Ma_ToaNha FROM inserted)
END

GO
