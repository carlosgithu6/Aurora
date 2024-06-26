SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LecturaAnterior]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'




CREATE FUNCTION [dbo].[LecturaAnterior]
(
 @idpropiedad int,
 @mesactual int,
 @ano int,
 @CodCuenta int
)
RETURNS decimal
AS
BEGIN
declare @lecturaAnterior decimal
declare @mesanterior int
declare @anoanterior int
if @mesactual = 1 
begin
    set @mesanterior = 12
    set @anoanterior = @ano-1
end
else
begin
	set @mesanterior = @mesactual-1
	set @anoanterior =@ano
end

select @lecturaAnterior =  GVCLECTURACATUAL from dbo.GASTOSCV
where idpropiedad=@idpropiedad and CTVCODIGO = @CodCuenta and ANO=@anoanterior and MES = @mesanterior
return @lecturaAnterior
--if @lecturaAnterior <> null
--begin
--	return @lecturaAnterior
--end
--return 0
END




' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LecturasMedidorAnterior]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'



CREATE FUNCTION [dbo].[LecturasMedidorAnterior]
(
 @idpropiedad int,
 @mes int,
 @ano int,
 @CodCuenta int
)
RETURNS decimal(18,2)
AS
BEGIN
declare @suma decimal(18,2)
select @suma =(select Sum(cm.CMLECTURA) from dbo.CAMBIOMEDIDOR cm where cm.IDPROPIEDAD = @IDPROPIEDAD and  Month(cm.CMFECHACAMBIO)=@MES and Year(cm.CMFECHACAMBIO)=@ANO and CTVCODIGO = @CodCuenta)

return isnull(@suma,0)
END
--declare @suma bigint
--set @suma= LecturasMedidorAnterior(16,7,2009,4)
--print @suma

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrecioCV]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'





CREATE FUNCTION [dbo].[PrecioCV]
(
 @idpropiedad int,
 @CodCuenta int
)
RETURNS decimal(10,2)
AS
BEGIN
declare @_return  decimal(10,2)
SELECT @_return = 
(SELECT case TARIFAESPECIAL when -1 then (select CTVPRECIO  FROM dbo.CUENTAVARIABLE WHERE CTVCODIGO = @CodCuenta) else TARIFAESPECIAL end tarif 
   from dbo.CUENTAVARIABLE_X_PROPIETARIO  where IDPROPIEDAD =  @idpropiedad and CTVCODIGO=@CodCuenta) 
return @_return
END





' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MontoCV]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'






CREATE FUNCTION [dbo].[MontoCV]
(
 @IDPROPIEDAD int,
 @CTVCODIGO int,
 @MES int,
 @ANO int
)
RETURNS decimal(10,2)
AS
BEGIN
declare @_return  decimal(10,2)
SELECT @_return = 
(SELECT ''COSTO'' =
case 
	when (((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))>100 and TRIFASICO=0 and CTVTIPO = 4)  then CAST((((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))* TARIFAAPLICADA +MONTOFIJO)AS INT)
    when (((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))>100 and TRIFASICO=1 and CTVTIPO = 4)  then CAST((((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))* FACTOR * TARIFAAPLICADA +MONTOFIJO)AS INT)
    when (((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))<=100 and TRIFASICO=0 and CTVTIPO = 4) then CAST(100*TARIFAAPLICADA+MONTOFIJO AS INT)
    when ((((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))*FACTOR)<=100 and TRIFASICO=1 and CTVTIPO = 4) then CAST(100*TARIFAAPLICADA+MONTOFIJO AS INT)
    when ((((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))*FACTOR)>100 and TRIFASICO=1 and CTVTIPO = 4) then CAST(((((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( @IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))*FACTOR))*TARIFAAPLICADA+MONTOFIJO AS INT)
else
  CAST( (((GVCLECTURACATUAL+dbo.LecturasMedidorAnterior(@IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))-dbo.LecturaAnterior( GASTOSCV.IDPROPIEDAD, @MES, @ANO,GASTOSCV.CTVCODIGO))* TARIFAAPLICADA +MONTOFIJO) as int)
end
from
dbo.GASTOSCV inner join dbo.CUENTAVARIABLE_X_PROPIETARIO cvp on  cvp.CTVCODIGO = GASTOSCV.CTVCODIGO and cvp.IDPROPIEDAD = GASTOSCV.IDPROPIEDAD inner join CUENTAVARIABLE on CUENTAVARIABLE.CTVCODIGO = GASTOSCV.CTVCODIGO
where GASTOSCV.IDPROPIEDAD=@IDPROPIEDAD and
GASTOSCV.CTVCODIGO = @CTVCODIGO and
ANO =@ANO and 
MES = @MES
)

return isnull(@_return,0)
END






' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EsDiaHabil]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'




create FUNCTION [dbo].[EsDiaHabil]
(
 @dia Datetime
)
RETURNS int
AS
BEGIN
if datepart(d,@dia)=1 or datepart(d,@dia)=7 or exists(Select FERIADO from FERIADOS where FERIADO = @dia)
begin
 return 0
end
return 1
END






' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProximoDiaHabil]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'




CREATE FUNCTION [dbo].[ProximoDiaHabil]
(
 @dia Datetime
)
RETURNS Datetime
AS
BEGIN
declare @diai datetime
if dbo.EsDiaHabil(@dia)=1 begin return @dia end
else
begin
    
    set @diai = dateadd(dd,1,@dia)
	WHILE  dbo.EsDiaHabil(@diai) = 0
	BEGIN  
      set @diai = dateadd(dd,1,@dia)
      if dbo.EsDiaHabil(@diai) = 1 break;
	END  

end
return @diai
END


--declare @a datetime
--set @a = dbo.ProximoDiaHabil (''08/25/2017 0:00:00'')
--print @a
' 
END

