USE [sistema_control_comercio]
GO
/****** Object:  Table [dbo].[category]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[category_id] [uniqueidentifier] NOT NULL,
	[category_code] [varchar](50) NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[category_name] [varchar](50) NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[company_id] [uniqueidentifier] NOT NULL,
	[company_cuit] [int] NULL,
	[company_name] [varchar](50) NULL,
	[company_address] [varchar](50) NULL,
	[company_cellphone] [int] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[employee_id] [uniqueidentifier] NOT NULL,
	[employee_dni] [int] NULL,
	[employee_name] [varchar](50) NULL,
	[employee_lastname] [varchar](50) NULL,
	[employee_address] [varchar](50) NULL,
	[employee_cellphone] [int] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventary]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventary](
	[inventary_id] [uniqueidentifier] NOT NULL,
	[raw_material_id] [uniqueidentifier] NULL,
	[quantity] [int] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_inventary] PRIMARY KEY CLUSTERED 
(
	[inventary_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_method]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_method](
	[payment_method_id] [uniqueidentifier] NOT NULL,
	[payment_method_name] [varchar](50) NULL,
	[company_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_payment_method] PRIMARY KEY CLUSTERED 
(
	[payment_method_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_service]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_service](
	[payment_service_id] [uniqueidentifier] NOT NULL,
	[service_id] [uniqueidentifier] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[payment_service_price] [int] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_payment_service] PRIMARY KEY CLUSTERED 
(
	[payment_service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_suppliers]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_suppliers](
	[payment_suppliers_id] [uniqueidentifier] NOT NULL,
	[supplier_id] [uniqueidentifier] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[payment_suppliers_cost] [int] NULL,
	[payment_suppliers_pay] [int] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_payment_suppliers] PRIMARY KEY CLUSTERED 
(
	[payment_suppliers_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_suppliers_order]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_suppliers_order](
	[payment_suppliers_order_id] [uniqueidentifier] NOT NULL,
	[payment_suppliers_id] [uniqueidentifier] NULL,
	[raw_material_id] [uniqueidentifier] NULL,
	[quantity] [int] NULL,
	[payment_suppliers_cost] [int] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_payment_suppliers_order] PRIMARY KEY CLUSTERED 
(
	[payment_suppliers_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permission]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permission](
	[permission_id] [uniqueidentifier] NOT NULL,
	[permission_name] [varchar](50) NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_permission] PRIMARY KEY CLUSTERED 
(
	[permission_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[physical_location]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[physical_location](
	[physical_location_id] [uniqueidentifier] NOT NULL,
	[physical_location_cuit] [int] NULL,
	[physical_location_name] [varchar](50) NULL,
	[physical_location_cellphone] [int] NULL,
	[physical_location_address] [varchar](50) NULL,
	[company_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_physical_location] PRIMARY KEY CLUSTERED 
(
	[physical_location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [uniqueidentifier] NOT NULL,
	[product_code] [varchar](50) NULL,
	[product_name] [varchar](50) NULL,
	[product_cost] [int] NULL,
	[product_price] [int] NULL,
	[category_id] [uniqueidentifier] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_rawmaterial]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_rawmaterial](
	[product_rawmaterial_id] [uniqueidentifier] NOT NULL,
	[product_id] [uniqueidentifier] NULL,
	[raw_material_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_product_rawmaterial] PRIMARY KEY CLUSTERED 
(
	[product_rawmaterial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile](
	[profile_id] [uniqueidentifier] NOT NULL,
	[profile_name] [varchar](50) NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_profile] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile_permission]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile_permission](
	[profile_permission_id] [uniqueidentifier] NOT NULL,
	[profile_id] [uniqueidentifier] NULL,
	[permission_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_profile_permission] PRIMARY KEY CLUSTERED 
(
	[profile_permission_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile_profile]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile_profile](
	[profile_profile_id] [uniqueidentifier] NOT NULL,
	[profile_father_id] [uniqueidentifier] NULL,
	[profile_child_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_profile_profile] PRIMARY KEY CLUSTERED 
(
	[profile_profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[raw_material]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raw_material](
	[raw_material_id] [uniqueidentifier] NOT NULL,
	[raw_material_code] [varchar](50) NULL,
	[raw_material_name] [varchar](50) NULL,
	[raw_material_cost] [int] NULL,
	[company_id] [uniqueidentifier] NULL,
	[unit_of_measurement_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_raw_material] PRIMARY KEY CLUSTERED 
(
	[raw_material_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sale]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[sale_id] [uniqueidentifier] NOT NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[employee_id] [uniqueidentifier] NULL,
	[sale_price] [int] NULL,
	[payment_method_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_sale] PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sale_order]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale_order](
	[sale_order_id] [uniqueidentifier] NOT NULL,
	[sale_id] [uniqueidentifier] NULL,
	[product_id] [uniqueidentifier] NULL,
	[quantity] [int] NULL,
	[sale_order_price] [int] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_sale_order] PRIMARY KEY CLUSTERED 
(
	[sale_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[service_id] [uniqueidentifier] NOT NULL,
	[service_code] [varchar](50) NULL,
	[service_name] [varchar](50) NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier](
	[supplier_id] [uniqueidentifier] NOT NULL,
	[supplier_cuit] [int] NULL,
	[supplier_name] [varchar](50) NULL,
	[supplier_cellphone] [int] NULL,
	[supplier_address] [varchar](50) NULL,
	[supplier_debt] [int] NULL,
	[physical_location_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modificatrion_date] [datetime] NULL,
 CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unit_of_measurement]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unit_of_measurement](
	[unit_of_measurement_id] [uniqueidentifier] NOT NULL,
	[unit_of_measurement_name] [varchar](50) NULL,
	[company_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_unit_of_measurement] PRIMARY KEY CLUSTERED 
(
	[unit_of_measurement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [uniqueidentifier] NOT NULL,
	[user_name] [varchar](50) NULL,
	[user_password] [varchar](50) NULL,
	[employee_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_permission]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_permission](
	[user_permission_id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NULL,
	[permission_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_user_permission] PRIMARY KEY CLUSTERED 
(
	[user_permission_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_profile]    Script Date: 11/3/2023 19:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_profile](
	[user_profile_id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NULL,
	[profile_id] [uniqueidentifier] NULL,
	[creation_date] [datetime] NULL,
	[modification_date] [datetime] NULL,
 CONSTRAINT [PK_user_profile] PRIMARY KEY CLUSTERED 
(
	[user_profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_physical_location]
GO
ALTER TABLE [dbo].[inventary]  WITH CHECK ADD  CONSTRAINT [FK_inventary_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[inventary] CHECK CONSTRAINT [FK_inventary_physical_location]
GO
ALTER TABLE [dbo].[inventary]  WITH CHECK ADD  CONSTRAINT [FK_inventary_raw_material] FOREIGN KEY([raw_material_id])
REFERENCES [dbo].[raw_material] ([raw_material_id])
GO
ALTER TABLE [dbo].[inventary] CHECK CONSTRAINT [FK_inventary_raw_material]
GO
ALTER TABLE [dbo].[payment_method]  WITH CHECK ADD  CONSTRAINT [FK_payment_method_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([company_id])
GO
ALTER TABLE [dbo].[payment_method] CHECK CONSTRAINT [FK_payment_method_company]
GO
ALTER TABLE [dbo].[payment_service]  WITH CHECK ADD  CONSTRAINT [FK_payment_service_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[payment_service] CHECK CONSTRAINT [FK_payment_service_physical_location]
GO
ALTER TABLE [dbo].[payment_service]  WITH CHECK ADD  CONSTRAINT [FK_payment_service_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([service_id])
GO
ALTER TABLE [dbo].[payment_service] CHECK CONSTRAINT [FK_payment_service_service]
GO
ALTER TABLE [dbo].[payment_suppliers]  WITH CHECK ADD  CONSTRAINT [FK_payment_suppliers_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[payment_suppliers] CHECK CONSTRAINT [FK_payment_suppliers_physical_location]
GO
ALTER TABLE [dbo].[payment_suppliers]  WITH CHECK ADD  CONSTRAINT [FK_payment_suppliers_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[payment_suppliers] CHECK CONSTRAINT [FK_payment_suppliers_supplier]
GO
ALTER TABLE [dbo].[payment_suppliers_order]  WITH CHECK ADD  CONSTRAINT [FK_payment_suppliers_order_payment_suppliers] FOREIGN KEY([payment_suppliers_id])
REFERENCES [dbo].[payment_suppliers] ([payment_suppliers_id])
GO
ALTER TABLE [dbo].[payment_suppliers_order] CHECK CONSTRAINT [FK_payment_suppliers_order_payment_suppliers]
GO
ALTER TABLE [dbo].[payment_suppliers_order]  WITH CHECK ADD  CONSTRAINT [FK_payment_suppliers_order_raw_material] FOREIGN KEY([raw_material_id])
REFERENCES [dbo].[raw_material] ([raw_material_id])
GO
ALTER TABLE [dbo].[payment_suppliers_order] CHECK CONSTRAINT [FK_payment_suppliers_order_raw_material]
GO
ALTER TABLE [dbo].[physical_location]  WITH CHECK ADD  CONSTRAINT [FK_physical_location_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([company_id])
GO
ALTER TABLE [dbo].[physical_location] CHECK CONSTRAINT [FK_physical_location_company]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([category_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_category]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_physical_location]
GO
ALTER TABLE [dbo].[product_rawmaterial]  WITH CHECK ADD  CONSTRAINT [FK_product_rawmaterial_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[product_rawmaterial] CHECK CONSTRAINT [FK_product_rawmaterial_product]
GO
ALTER TABLE [dbo].[product_rawmaterial]  WITH CHECK ADD  CONSTRAINT [FK_product_rawmaterial_raw_material] FOREIGN KEY([raw_material_id])
REFERENCES [dbo].[raw_material] ([raw_material_id])
GO
ALTER TABLE [dbo].[product_rawmaterial] CHECK CONSTRAINT [FK_product_rawmaterial_raw_material]
GO
ALTER TABLE [dbo].[profile_permission]  WITH CHECK ADD  CONSTRAINT [FK_profile_permission_permission] FOREIGN KEY([permission_id])
REFERENCES [dbo].[permission] ([permission_id])
GO
ALTER TABLE [dbo].[profile_permission] CHECK CONSTRAINT [FK_profile_permission_permission]
GO
ALTER TABLE [dbo].[profile_permission]  WITH CHECK ADD  CONSTRAINT [FK_profile_permission_profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[profile] ([profile_id])
GO
ALTER TABLE [dbo].[profile_permission] CHECK CONSTRAINT [FK_profile_permission_profile]
GO
ALTER TABLE [dbo].[profile_profile]  WITH CHECK ADD  CONSTRAINT [FK_profile_profile_profile] FOREIGN KEY([profile_father_id])
REFERENCES [dbo].[profile] ([profile_id])
GO
ALTER TABLE [dbo].[profile_profile] CHECK CONSTRAINT [FK_profile_profile_profile]
GO
ALTER TABLE [dbo].[profile_profile]  WITH CHECK ADD  CONSTRAINT [FK_profile_profile_profile1] FOREIGN KEY([profile_child_id])
REFERENCES [dbo].[profile] ([profile_id])
GO
ALTER TABLE [dbo].[profile_profile] CHECK CONSTRAINT [FK_profile_profile_profile1]
GO
ALTER TABLE [dbo].[raw_material]  WITH CHECK ADD  CONSTRAINT [FK_raw_material_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([company_id])
GO
ALTER TABLE [dbo].[raw_material] CHECK CONSTRAINT [FK_raw_material_company]
GO
ALTER TABLE [dbo].[raw_material]  WITH CHECK ADD  CONSTRAINT [FK_raw_material_unit_of_measurement] FOREIGN KEY([unit_of_measurement_id])
REFERENCES [dbo].[unit_of_measurement] ([unit_of_measurement_id])
GO
ALTER TABLE [dbo].[raw_material] CHECK CONSTRAINT [FK_raw_material_unit_of_measurement]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [FK_sale_payment_method] FOREIGN KEY([payment_method_id])
REFERENCES [dbo].[payment_method] ([payment_method_id])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [FK_sale_payment_method]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [FK_sale_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [FK_sale_physical_location]
GO
ALTER TABLE [dbo].[sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sale_order_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[sale_order] CHECK CONSTRAINT [FK_sale_order_product]
GO
ALTER TABLE [dbo].[sale_order]  WITH CHECK ADD  CONSTRAINT [FK_sale_order_sale] FOREIGN KEY([sale_id])
REFERENCES [dbo].[sale] ([sale_id])
GO
ALTER TABLE [dbo].[sale_order] CHECK CONSTRAINT [FK_sale_order_sale]
GO
ALTER TABLE [dbo].[service]  WITH CHECK ADD  CONSTRAINT [FK_service_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_physical_location]
GO
ALTER TABLE [dbo].[supplier]  WITH CHECK ADD  CONSTRAINT [FK_supplier_physical_location] FOREIGN KEY([physical_location_id])
REFERENCES [dbo].[physical_location] ([physical_location_id])
GO
ALTER TABLE [dbo].[supplier] CHECK CONSTRAINT [FK_supplier_physical_location]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employee] ([employee_id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_employee]
GO
ALTER TABLE [dbo].[user_permission]  WITH CHECK ADD  CONSTRAINT [FK_user_permission_permission] FOREIGN KEY([permission_id])
REFERENCES [dbo].[permission] ([permission_id])
GO
ALTER TABLE [dbo].[user_permission] CHECK CONSTRAINT [FK_user_permission_permission]
GO
ALTER TABLE [dbo].[user_permission]  WITH CHECK ADD  CONSTRAINT [FK_user_permission_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[user_permission] CHECK CONSTRAINT [FK_user_permission_user]
GO
ALTER TABLE [dbo].[user_profile]  WITH CHECK ADD  CONSTRAINT [FK_user_profile_profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[profile] ([profile_id])
GO
ALTER TABLE [dbo].[user_profile] CHECK CONSTRAINT [FK_user_profile_profile]
GO
ALTER TABLE [dbo].[user_profile]  WITH CHECK ADD  CONSTRAINT [FK_user_profile_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[user_profile] CHECK CONSTRAINT [FK_user_profile_user]
GO
