SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[USUARIOS](
	[RUT] [varchar](15) NOT NULL,
	[NOMBRES] [varchar](100) NOT NULL,
	[APPATERNO] [varchar](100) NOT NULL,
	[APMATERNO] [varchar](100) NOT NULL,
	[DIRECCION] [varchar](250) NOT NULL,
	[TELEFONO] [varchar](25) NOT NULL,
	[PASSWORD] [varchar](200) NOT NULL,
	[IDPERFIL] [int] NOT NULL,
	[EMAIL] [varchar](100) NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[FECHAACTUALIZACION] [datetime] NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[RUT] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAVARIABLE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAVARIABLE](
	[CTVCODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CTVTIPO] [int] NOT NULL,
	[CTVPRECIO] [decimal](10, 2) NOT NULL,
	[CTVUNIDADMEDIDA] [int] NOT NULL,
	[CTVDESCRIPCION] [varchar](50) NOT NULL,
	[FECHAMODIFICACION] [datetime] NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
 CONSTRAINT [PK_CUENTAVARIABLE] PRIMARY KEY CLUSTERED 
(
	[CTVCODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FOLIOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FOLIOS](
	[FOLIO] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UF](
	[IDUF] [int] IDENTITY(1,1) NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[UF] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_UF] PRIMARY KEY CLUSTERED 
(
	[IDUF] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REPORTE_CONSUMO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REPORTE_CONSUMO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[CUENTA] [varchar](50) NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[NOMBRE] [varchar](302) NOT NULL,
	[SECTOR] [varchar](50) NOT NULL,
	[LETRAPARCELA] [varchar](10) NOT NULL,
	[NUMEROPARCELA] [int] NOT NULL,
	[GVCLECTURACATUAL] [decimal](18, 2) NOT NULL,
	[LECTURAANTERIOR] [decimal](21, 2) NULL,
	[CONSUMO] [decimal](22, 2) NULL,
	[MEDIDOR] [varchar](50) NULL,
	[TARIFAAPLICADA] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ABONODEUDAS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ABONODEUDAS](
	[IDPROPIEDAD] [int] NOT NULL,
	[ABONODEUDA] [decimal](18, 2) NOT NULL,
	[FECHAABONO] [datetime] NOT NULL,
	[DESDECCTE] [bit] NOT NULL,
 CONSTRAINT [PK_ABONODEUDAS] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[FECHAABONO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CHEQUES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CHEQUES](
	[NUMCHEQUE] [varchar](15) NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[BANCO] [int] NOT NULL,
	[MONTO] [decimal](18, 2) NOT NULL,
	[FECHARECEP] [datetime] NOT NULL,
	[FECHACOBRO] [datetime] NOT NULL,
	[ESTADO] [int] NOT NULL,
 CONSTRAINT [PK_CHEQUES] PRIMARY KEY CLUSTERED 
(
	[NUMCHEQUE] ASC,
	[IDPROPIEDAD] ASC,
	[BANCO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAVARIABLEHISTORICO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAVARIABLEHISTORICO](
	[CODIGO] [int] NOT NULL,
	[TARIFAANTERIOR] [decimal](18, 2) NOT NULL,
	[TARIFANUEVA] [decimal](18, 2) NOT NULL,
	[FECHACAMBIO] [datetime] NOT NULL,
	[RUTUSUARIO] [int] NOT NULL,
 CONSTRAINT [PK_CUENTAVARIABLEHISTORICO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC,
	[FECHACAMBIO] ASC,
	[RUTUSUARIO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CONTROLNOMINAS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CONTROLNOMINAS](
	[FECHAAPERTURA] [datetime] NOT NULL,
	[FECHACIERRE] [datetime] NULL,
	[MES] [int] NULL,
	[ANO] [int] NULL,
	[MSG] [text] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CONTROLNOMINAS] PRIMARY KEY CLUSTERED 
(
	[FECHAAPERTURA] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAVARIABLE_X_PROPIETARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAVARIABLE_X_PROPIETARIO](
	[CTVCODIGO] [int] NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[TARIFAESPECIAL] [decimal](18, 2) NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[FECHAACTUALIZACION] [datetime] NOT NULL,
	[DEUDAACUMULADA] [decimal](18, 2) NOT NULL,
	[MEDIDOR] [nvarchar](50) NULL,
 CONSTRAINT [PK_CUENTAVARIABLE_X_PROPIETARIO_1] PRIMARY KEY CLUSTERED 
(
	[CTVCODIGO] ASC,
	[IDPROPIEDAD] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSCF_X_PAGOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSCF_X_PAGOS](
	[NUMMOV] [int] IDENTITY(1,1) NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[CFCODIGO] [int] NOT NULL,
	[SUBMONTOCANCELADO] [decimal](18, 2) NOT NULL,
	[FORMAPAGO] [int] NOT NULL,
	[FECHAPAGO] [datetime] NOT NULL,
	[ESTADORECIBO] [int] NOT NULL CONSTRAINT [DF_GASTOSCF_X_PAGOS_ESTADORECIBO]  DEFAULT ((0)),
	[FOLIO] [int] NOT NULL CONSTRAINT [DF_GASTOSCF_X_PAGOS_FOLIO]  DEFAULT ((0)),
 CONSTRAINT [PK_GASTOSCF_X_PAGOS] PRIMARY KEY CLUSTERED 
(
	[NUMMOV] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAESPECIAL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAESPECIAL](
	[CTECODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CTEPRECIO] [decimal](10, 2) NULL,
	[CTEDESCRIPCION] [varchar](50) NULL,
	[FECHAMODIFICACION] [datetime] NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
 CONSTRAINT [PK_CUENTAESPECIAL] PRIMARY KEY CLUSTERED 
(
	[CTECODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSCV_X_PAGOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSCV_X_PAGOS](
	[NUMMOV] [int] IDENTITY(1,1) NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[CTVCODIGO] [int] NOT NULL,
	[SUBMONTOCANCELADO] [decimal](18, 2) NOT NULL,
	[FORMAPAGO] [int] NOT NULL,
	[FECHAPAGO] [datetime] NOT NULL,
	[ESTADORECIBO] [int] NOT NULL CONSTRAINT [DF_GASTOSCV_X_PAGOS_ESTADORECIBO]  DEFAULT ((0)),
	[FOLIO] [int] NOT NULL CONSTRAINT [DF_GASTOSCV_X_PAGOS_FOLIO]  DEFAULT ((0)),
 CONSTRAINT [PK_GASTOSCV_X_PAGOS] PRIMARY KEY CLUSTERED 
(
	[NUMMOV] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FERIADOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FERIADOS](
	[FERIADO] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSRESUMEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSRESUMEN](
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[GATOTAL] [decimal](18, 0) NOT NULL,
	[GAPAGADO] [decimal](18, 4) NOT NULL,
	[GATIENECAMBIO] [bit] NOT NULL,
 CONSTRAINT [PK_GASTOSRESUMEN] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[MES] ASC,
	[ANO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MAILENVIADOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MAILENVIADOS](
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[FECHAHORA] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAFIJA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAFIJA](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL,
	[TIPOCUENTA] [int] NOT NULL,
	[TARIFAACTUAL] [decimal](18, 2) NOT NULL,
	[FECHAINICIO] [datetime] NOT NULL,
	[FECHAFIN] [datetime] NOT NULL,
	[FECHAULTIMOCAMBIOTARIFA] [datetime] NOT NULL,
	[FECHACREACION] [nchar](10) NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
 CONSTRAINT [PK_TARIFASFIJA] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAMBIOMEDIDOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAMBIOMEDIDOR](
	[IDPROPIEDAD] [int] NOT NULL,
	[CMFECHACAMBIO] [datetime] NOT NULL,
	[CTVCODIGO] [int] NOT NULL,
	[CMLECTURA] [decimal](18, 2) NOT NULL,
	[CMMOTIVO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CAMBIOMEDIDOR] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[CMFECHACAMBIO] ASC,
	[CTVCODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPIETARIOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROPIETARIOS](
	[IDPROPIEDAD] [int] IDENTITY(1,1) NOT NULL,
	[RUT] [varchar](15) NOT NULL,
	[NOMBRES] [varchar](100) NOT NULL,
	[APPATERNO] [varchar](100) NOT NULL,
	[APMATERNO] [varchar](100) NOT NULL,
	[SOCIO] [bit] NOT NULL,
	[FECHAINGRESOSOCIO] [datetime] NULL,
	[FECHASALIDASOCIO] [datetime] NULL,
	[DIRECCIONCONTACTO] [varchar](250) NOT NULL,
	[MAIL] [varchar](500) NOT NULL,
	[TELEFONO] [varchar](25) NOT NULL,
	[SECTOR] [varchar](50) NOT NULL,
	[LETRAPARCELA] [varchar](10) NOT NULL,
	[NUMEROPARCELA] [int] NOT NULL,
	[TAMANOHECT] [decimal](18, 2) NOT NULL,
	[NUMEROCASAS] [int] NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[FECHAACTUALIZACION] [datetime] NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
	[SALDOCTE] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PROPIETARIOS_SALDOCTE]  DEFAULT ((0)),
	[DEUDAINICIAL] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PROPIETARIOS_DEUDAINICAL]  DEFAULT ((0)),
	[DEUDAPENDIENTE] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PROPIETARIOS_CANCELADODEUDA]  DEFAULT ((0)),
	[ACTIVA] [bit] NULL,
 CONSTRAINT [PK_PROPIETARIOS] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAESPECIAL_X_PROPIETARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAESPECIAL_X_PROPIETARIO](
	[IDCUENTAESPECIALPROP] [int] IDENTITY(1,1) NOT NULL,
	[IDPROPIEDAD] [int] NOT NULL,
	[CTECODIGO] [int] NOT NULL,
	[CEPFECHAINICIO] [datetime] NOT NULL,
	[CEPNUMEROCUOTAS] [int] NOT NULL,
	[PAGADOMONTO] [decimal](18, 2) NULL CONSTRAINT [DF_CUENTAESPECIAL_X_PROPIETARIO_PAGADOMONTO]  DEFAULT ((0)),
	[FECHACREACION] [datetime] NOT NULL,
	[FECHAMODIFICACION] [datetime] NOT NULL,
	[ELIMINADO] [bit] NOT NULL,
	[DEUDAACUMULADA] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CUENTAESPECIAL_X_PROPIETARIO] PRIMARY KEY CLUSTERED 
(
	[IDCUENTAESPECIALPROP] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAFIJA_X_PROPIETARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAFIJA_X_PROPIETARIO](
	[IDPROPIEDAD] [int] NOT NULL,
	[IDCUENTAFIJA] [int] NOT NULL,
	[TARIFAESPECIAL] [decimal](18, 2) NOT NULL,
	[FECHACREACION] [datetime] NOT NULL,
	[FECHAACTUALIZACION] [datetime] NOT NULL,
	[DEUDAACUMULADA] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CUENTAFIJA_X_PROPIETARIO] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[IDCUENTAFIJA] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUENTAFIJAHISTORICO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUENTAFIJAHISTORICO](
	[CODIGO] [int] NOT NULL,
	[TARIFAANTERIOR] [decimal](18, 2) NOT NULL,
	[TARIFANUEVA] [decimal](18, 2) NOT NULL,
	[FECHACAMBIO] [datetime] NOT NULL,
 CONSTRAINT [PK_TARIFASFIJAHISTORICO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC,
	[FECHACAMBIO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSCF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSCF](
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[CFCODIGO] [int] NOT NULL,
	[GCFMONTO] [decimal](18, 2) NOT NULL,
	[GCFMONTOCANCELADO] [decimal](18, 2) NOT NULL,
	[FECHAPAGO] [datetime] NOT NULL,
	[FORMAPAGO] [int] NOT NULL,
 CONSTRAINT [PK_GASTOSCF] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[MES] ASC,
	[ANO] ASC,
	[CFCODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSCV]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSCV](
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[CTVCODIGO] [int] NOT NULL,
	[TARIFAAPLICADA] [decimal](18, 2) NOT NULL,
	[GVCLECTURACATUAL] [decimal](18, 2) NOT NULL,
	[GVFECHAVTO] [datetime] NOT NULL,
	[GVMONTOCANCELADO] [int] NOT NULL,
	[MONTOFIJO] [int] NOT NULL,
	[FECHAPAGO] [datetime] NOT NULL,
	[FORMAPAGO] [int] NOT NULL,
	[TRIFASICO] [int] NOT NULL CONSTRAINT [DF_GASTOSCV_TRIFASICO]  DEFAULT ((0)),
	[FACTOR] [decimal](18, 2) NOT NULL CONSTRAINT [DF_GASTOSCV_FACTOR]  DEFAULT ((0)),
	[FECHALEC] [datetime] NULL,
 CONSTRAINT [PK_GASTOSCV] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[MES] ASC,
	[ANO] ASC,
	[CTVCODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GASTOSCE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GASTOSCE](
	[IDPROPIEDAD] [int] NOT NULL,
	[MES] [int] NOT NULL,
	[ANO] [int] NOT NULL,
	[CTECODIGO] [int] NOT NULL,
	[GCECUOTA] [decimal](18, 2) NOT NULL,
	[GCEMONTO] [decimal](18, 2) NOT NULL,
	[FECHAPAGO] [datetime] NOT NULL,
	[FORMAPAGO] [int] NOT NULL,
	[NUMEROCUOTA] [int] NOT NULL,
 CONSTRAINT [PK_GASTOSCE] PRIMARY KEY CLUSTERED 
(
	[IDPROPIEDAD] ASC,
	[MES] ASC,
	[ANO] ASC,
	[CTECODIGO] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CUENTAESPECIAL_X_PROPIETARIO_CUENTAESPECIAL]') AND parent_object_id = OBJECT_ID(N'[dbo].[CUENTAESPECIAL_X_PROPIETARIO]'))
ALTER TABLE [dbo].[CUENTAESPECIAL_X_PROPIETARIO]  WITH CHECK ADD  CONSTRAINT [FK_CUENTAESPECIAL_X_PROPIETARIO_CUENTAESPECIAL] FOREIGN KEY([CTECODIGO])
REFERENCES [dbo].[CUENTAESPECIAL] ([CTECODIGO])
GO
ALTER TABLE [dbo].[CUENTAESPECIAL_X_PROPIETARIO] CHECK CONSTRAINT [FK_CUENTAESPECIAL_X_PROPIETARIO_CUENTAESPECIAL]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CUENTAESPECIAL_X_PROPIETARIO_PROPIETARIOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CUENTAESPECIAL_X_PROPIETARIO]'))
ALTER TABLE [dbo].[CUENTAESPECIAL_X_PROPIETARIO]  WITH CHECK ADD  CONSTRAINT [FK_CUENTAESPECIAL_X_PROPIETARIO_PROPIETARIOS] FOREIGN KEY([IDPROPIEDAD])
REFERENCES [dbo].[PROPIETARIOS] ([IDPROPIEDAD])
GO
ALTER TABLE [dbo].[CUENTAESPECIAL_X_PROPIETARIO] CHECK CONSTRAINT [FK_CUENTAESPECIAL_X_PROPIETARIO_PROPIETARIOS]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CUENTAFIJA_X_PROPIETARIO_CUENTAFIJA]') AND parent_object_id = OBJECT_ID(N'[dbo].[CUENTAFIJA_X_PROPIETARIO]'))
ALTER TABLE [dbo].[CUENTAFIJA_X_PROPIETARIO]  WITH CHECK ADD  CONSTRAINT [FK_CUENTAFIJA_X_PROPIETARIO_CUENTAFIJA] FOREIGN KEY([IDCUENTAFIJA])
REFERENCES [dbo].[CUENTAFIJA] ([CODIGO])
GO
ALTER TABLE [dbo].[CUENTAFIJA_X_PROPIETARIO] CHECK CONSTRAINT [FK_CUENTAFIJA_X_PROPIETARIO_CUENTAFIJA]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CUENTAFIJA_X_PROPIETARIO_PROPIETARIOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CUENTAFIJA_X_PROPIETARIO]'))
ALTER TABLE [dbo].[CUENTAFIJA_X_PROPIETARIO]  WITH CHECK ADD  CONSTRAINT [FK_CUENTAFIJA_X_PROPIETARIO_PROPIETARIOS] FOREIGN KEY([IDPROPIEDAD])
REFERENCES [dbo].[PROPIETARIOS] ([IDPROPIEDAD])
GO
ALTER TABLE [dbo].[CUENTAFIJA_X_PROPIETARIO] CHECK CONSTRAINT [FK_CUENTAFIJA_X_PROPIETARIO_PROPIETARIOS]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CUENTAFIJAHISTORICO_CUENTAFIJA]') AND parent_object_id = OBJECT_ID(N'[dbo].[CUENTAFIJAHISTORICO]'))
ALTER TABLE [dbo].[CUENTAFIJAHISTORICO]  WITH CHECK ADD  CONSTRAINT [FK_CUENTAFIJAHISTORICO_CUENTAFIJA] FOREIGN KEY([CODIGO])
REFERENCES [dbo].[CUENTAFIJA] ([CODIGO])
GO
ALTER TABLE [dbo].[CUENTAFIJAHISTORICO] CHECK CONSTRAINT [FK_CUENTAFIJAHISTORICO_CUENTAFIJA]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GASTOSCF_CUENTAFIJA]') AND parent_object_id = OBJECT_ID(N'[dbo].[GASTOSCF]'))
ALTER TABLE [dbo].[GASTOSCF]  WITH CHECK ADD  CONSTRAINT [FK_GASTOSCF_CUENTAFIJA] FOREIGN KEY([CFCODIGO])
REFERENCES [dbo].[CUENTAFIJA] ([CODIGO])
GO
ALTER TABLE [dbo].[GASTOSCF] CHECK CONSTRAINT [FK_GASTOSCF_CUENTAFIJA]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GASTOSCF_PROPIETARIOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[GASTOSCF]'))
ALTER TABLE [dbo].[GASTOSCF]  WITH CHECK ADD  CONSTRAINT [FK_GASTOSCF_PROPIETARIOS] FOREIGN KEY([IDPROPIEDAD])
REFERENCES [dbo].[PROPIETARIOS] ([IDPROPIEDAD])
GO
ALTER TABLE [dbo].[GASTOSCF] CHECK CONSTRAINT [FK_GASTOSCF_PROPIETARIOS]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GASTOSCV_PROPIETARIOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[GASTOSCV]'))
ALTER TABLE [dbo].[GASTOSCV]  WITH CHECK ADD  CONSTRAINT [FK_GASTOSCV_PROPIETARIOS] FOREIGN KEY([IDPROPIEDAD])
REFERENCES [dbo].[PROPIETARIOS] ([IDPROPIEDAD])
GO
ALTER TABLE [dbo].[GASTOSCV] CHECK CONSTRAINT [FK_GASTOSCV_PROPIETARIOS]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GASTOSCE_PROPIETARIOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[GASTOSCE]'))
ALTER TABLE [dbo].[GASTOSCE]  WITH CHECK ADD  CONSTRAINT [FK_GASTOSCE_PROPIETARIOS] FOREIGN KEY([IDPROPIEDAD])
REFERENCES [dbo].[PROPIETARIOS] ([IDPROPIEDAD])
GO
ALTER TABLE [dbo].[GASTOSCE] CHECK CONSTRAINT [FK_GASTOSCE_PROPIETARIOS]
