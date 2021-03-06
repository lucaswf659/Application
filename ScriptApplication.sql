USE [Application]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 08/11/2020 15:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[id_application] [int] IDENTITY(1,1) NOT NULL,
	[url] [nvarchar](200) NULL,
	[pathlocal] [nvarchar](200) NULL,
	[debugging_mode] [bit] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[id_application] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Application] ON 

INSERT [dbo].[Application] ([id_application], [url], [pathlocal], [debugging_mode]) VALUES (8, N'www.softdesign.com.br', N'inetpub\wwwroot', 1)
INSERT [dbo].[Application] ([id_application], [url], [pathlocal], [debugging_mode]) VALUES (9, N'www.softdesign.com.br', N'inetpub\wwwroot', 0)
INSERT [dbo].[Application] ([id_application], [url], [pathlocal], [debugging_mode]) VALUES (10, N'www.softdesign.com.br', N'inetpub\wwwroot', 0)
SET IDENTITY_INSERT [dbo].[Application] OFF
/****** Object:  StoredProcedure [dbo].[Application_Delete]    Script Date: 08/11/2020 15:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Lucas Weber
-- =============================================
CREATE PROCEDURE [dbo].[Application_Delete]
	@ApplicationId int,
	@Deleted bit OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET @Deleted = 0
	DELETE 
	FROM Application
	WHERE id_application = @ApplicationId
	SET @Deleted = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Application_Get]    Script Date: 08/11/2020 15:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Lucas Weber
-- =============================================
CREATE PROCEDURE [dbo].[Application_Get]  
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
    FROM
	Application
END
GO
/****** Object:  StoredProcedure [dbo].[Application_GetById]    Script Date: 08/11/2020 15:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Lucas Weber
-- =============================================
CREATE PROCEDURE [dbo].[Application_GetById] 
	@ApplicationId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM
	APPLICATION 
	WHERE id_application = @ApplicationId
END
GO
/****** Object:  StoredProcedure [dbo].[Application_Save]    Script Date: 08/11/2020 15:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Lucas Weber
-- =============================================
CREATE PROCEDURE [dbo].[Application_Save]
	@Url NVARCHAR(200),
	@PathLocal NVARCHAR(200),
	@DebuggingMode bit,
	@Saved  bit OUTPUT
AS
BEGIN

	SET NOCOUNT ON;
	set @Saved = 0
	INSERT INTO Application 
	values
	(
	 @Url,
	 @PathLocal,
	 @DebuggingMode
	)
    set @Saved = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Application_Update]    Script Date: 08/11/2020 15:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Lucas Weber
-- =============================================
CREATE PROCEDURE [dbo].[Application_Update]
	@ApplicationId int,
	@Url NVARCHAR(200) = NULL,
	@PathLocal NVARCHAR(200) = NULL,
	@DebuggingMode bit = NULL,
	@Updated  bit OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SET @Updated = 0
	UPDATE Application
	SET 
	url = ISNULL(@Url,url),
	pathlocal = ISNULL(@PathLocal,pathlocal),
	debugging_mode = ISNULL(@DebuggingMode,debugging_mode) 
	WHERE id_application = @ApplicationId
	SET @Updated = 1
END
GO
