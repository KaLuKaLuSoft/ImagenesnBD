USE [db_InsertarImagen]
GO
/****** Object:  Table [dbo].[tb_imagen]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_imagen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [int] NULL,
	[fechaCumple] [date] NULL,
	[imagen] [image] NULL,
 CONSTRAINT [PK_tb_imgen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[actualizardatos]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[actualizardatos]
	@id int,
	@nombre varchar(50),
	@direccion varchar(50),
	@telefono int,
	@fechaCumple date,
	@imagen image
as
begin
update tb_imagen set nombre=@nombre,direccion=@direccion,telefono=@telefono,fechaCumple=@fechaCumple,imagen=@imagen
where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[eliminardatos]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminardatos]
	@id bigint
AS 
delete from tb_imagen where id = @id
GO
/****** Object:  StoredProcedure [dbo].[insertardatos]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertardatos]
@nombre varchar(50),
@direccion varchar(50),
@telefono int,
@fechaCumple date,
@imagen image
as
begin
insert into tb_imagen values
(@nombre,@direccion,@telefono,@fechaCumple,@imagen)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listar]
as
SELECT id AS Id, nombre AS Nombre, direccion AS Dirección, telefono AS Telefono, fechaCumple AS Cumpleaños
FROM     tb_imagen
GO
/****** Object:  StoredProcedure [dbo].[sp_listarDatos]    Script Date: 20/08/2021 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listarDatos]
as
SELECT id AS Id, nombre AS Nombre,direccion AS Dirección,telefono AS Telefono,fechaCumple AS Cumpleaños,imagen AS Imagenes
FROM     tb_imagen
GO
