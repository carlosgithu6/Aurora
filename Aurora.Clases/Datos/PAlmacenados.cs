using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Datos
{
    internal class PA
    {
        public const string USUARIOCREAR = "UsuarioCrear";
        public const string USUARIOBUSCAR  = "UsuarioBuscar";
        public const string USUARIOSLISTAR = "UsuarioListarTodos";
        public const string USUARIOSMODIFICAR = "UsuarioModificar";
        public const string USUARIOELIMINAR = "UsuarioEliminar";
        public const string USUARIOCAMBIARPASS = "UsuarioCambiarPass";

        public const string PROPIETARIOCREAR = "PropietarioCrear";
        public const string PROPIETARIOBUSCAR = "PropietarioBuscar";
        public const string PROPIETARIOLISTAR = "PropietarioListar";
        public const string PROPIETARIOMODIFICAR = "PropietarioModificar";
        public const string PROPIETARIOELIMINAR = "PropietarioEliminar";
        public const string PROPIETARIOCUENTAFIJABUSCAR ="PropietarioCuentaFijaBuscar";
        public const string PROPIETARIOCUENTAVARIABLEBUSCAR = "PropietarioCuentaVariableBuscar";
        public const string PROPIETARIOLISTARDEUDA = "PropietarioListarDeudaInicial";
        public const string PROPIETARIOSETDEUDAINICIAL = "PropietarioSetDeudaInicial";
        public const string PROPIETARIOPAGARDEUDA = "PropietarioPagarDeuda";
        public const string PROPIETARIOABONAR = "PropietarioAbonar";
        public const string PROPIETARIOLISTARMOROSOS = "PropietarioListarMorosos";
        public const string PROPIETARIOPAGARDEUDASCUENTAS = "PropietarioPagarDeudaCuentas";
        public const string PROPIETARIODEUDASFIJAS = "PropietarioBuscarDeudasFija";
        public const string PROPIETARIODEUDASVARIABLES = "PropietarioBuscarDeudasVariable";
        public const string PROPIETARIODEUDASVARIABLESPORTIPO = "PropietarioBuscarDeudasVarPorTipo";
        public const string PROPIETARIODEUDASFIJASPORTIPO = "PropietarioBuscarDeudasFijaPorTipo";
        public const string PROPIETARIOELIMINARULTIMOABONO = "PropietarioEliminarUltimoAbono";
        public const string PROPIETARIOLISTARESPECIAL = "PropietarioListarEspecial";
        public const string PROPIETARIOCARTOLA = "PropietarioCartola";
        public const string PROPIETARIODEUDASACERO = "PropietarioSetDeudasCero";
        public const string PROPIETARIOFECHACORTEDEUDASVARIABLESPORTIPO = "PropietarioBuscarFechaPrimeraDeudasVarPorTipo";
        public const string PROPIETARIOFECHACORTEFECHACORTEDEUDASFIJASPORTIPO = "PropietarioBuscarDeudasFechaCorteFijaPorTipo";
        public const string PROPIETARIOSSINLECTURAACTUALENLUZOAGUA = "PropietariosSinLectaraActualEnLuzOAgua";
        public const string PROPIETARIOMAILENVIOCREAR= "MailEnvioCrear";
        public const string PROPIETARIOBORRARMAIL = "MailEnvioBorrar";
        public const string PROPIETARIOBUSCARMAILENVIADOS = "PropietariosMailEnviados";
        public const string PROPIETARIOBUSCARPAGO = "PropietarioBuscarPagos";
        public const string PROPIETARIOBUSCARPAGOCTAVARIABLE = "PropietarioBuscarPagoCtaVariable";
        public const string PROPIETARIOSELLARRECIBO = "PropietarioSellarRecibo";
        public const string PROPIETARIOLISTARCONSUMO = "PropietarioListarConsumo";

        public const string UFCREAR = "UFCrear"; 
        public const string UFBUSCAR = "UFBuscar"; 
        public const string UFELIMINAR = "UFEliminar"; 
        public const string UFMODIFICAR = "UFModificar"; 
        public const string UFLISTAR = "UFListar";

        public const string CUENTAFIJACREAR = "CuentaFijaCrear";
        public const string CUENTAFIJABUSCAR = "CuentaFijaBuscar";
        public const string CUENTAFIJALISTAR = "CuentaFijaListar";
        public const string CUENTAFIJAELIMINAR = "CuentaFijaEliminar";
        public const string CUENTAFIJAMODIFICAR = "CuentaFijaModificar";
        public const string CUENTAFIJACREARHISTORICO = "CuentaFijaCrearHistorico";
        public const string CUENTAFIJAASOCIARPROPIETARIO = "CuentaFijaAsociarPropietario";
        public const string CUENTAFIJADESASOCIARPROPIETARIO = "CuentaFijaDesAsociarPropietario";
        public const string CUENTAFIJAPROPIETARIOEXISTE = "CuentaFijaPropietarioExiste";
        public const string CUENTAFIJAMODIFTARIFAPROPIETARIO="CuentaFijaModificarTarifaPropietario";
        public const string CUENTAFIJAMODIFTARIFADEUDAPROPIETARIO = "CuentaFijaModificarDeudaPropietario";

        public const string CUENTAVARIABLECREAR = "CuentaVariableCrear";
        public const string CUENTAVARIABLEBUSCAR = "CuentaVariableBuscar";
        public const string CUENTAVARIABLELISTAR = "CuentaVariableListar";
        public const string CUENTAVARIABLEELIMINAR = "CuentaVariableEliminar";
        public const string CUENTAVARIABLEMODIFICAR = "CuentaVariableModificar";
        public const string CUENTAVARIABLECREARHISTORICO = "CuentaVariableCrearHistorico";
        public const string CUENTAVARIABLELISTARHISTORICO = "CuentaVariableListarHistorico";
        public const string CUENTAVARIABLEASOCIARPROPIETARIO = "CuentaVariableAsociarPropietario";
        public const string CUENTAVARIABLEDESASOCIARPROPIETARIO = "CuentaVariableDesAsociarPropietario";
        public const string CUENTAVARIABLEPROPIETARIOEXISTE = "CuentaVariablePropietarioExiste";
        public const string CUENTAVARIABLEMODIFTARIFAPROPIETARIO = "CuentaVariableModificarTarifaPropietario";
        public const string CUENTAVARIABLEMODIFDEUDAPROPIETARIO = "CuentaVariableModificarDeudaPropietario";


        public const string CUENTAESPECIALCREAR = "CuentaEspecialCrear";
        public const string CUENTAESPECIALBUSCAR = "CuentaEspecialBuscar";
        public const string CUENTAESPECIALLISTAR = "CuentaEspecialListar";
        public const string CUENTAESPECIALELIMINAR = "CuentaEspecialEliminar";
        public const string CUENTAESPECIALMODIFICAR = "CuentaEspecialModificar";

        public const string CTEPROPIETARIOCREAR = "CtePropietarioCrear";
        public const string CTEPROPIETARIOBUSCAR = "CtePropietarioBuscar";
        public const string CTEPROPIETARIOLISTAR = "CtePropietarioListarByRut";
        public const string CTEPROPIETARIOELIMINAR = "CtePropietarioEliminar";
        public const string CTEPROPIETARIOMODIFICAR = "CtePropietarioModificar";

        public const string GASTOSRESUMENCREAR = "usp_InsertGASTOSRESUMEN";
        public const string GASTOSRESUMENBUSCAR = "usp_SelectGASTOSRESUMEN";
        public const string GASTOSRESUMENLISTAR = "usp_SelectGASTOSRESUMENsAll";
        public const string GASTOSRESUMENELIMINAR = "usp_DeleteGASTOSRESUMEN";
        public const string GASTOSRESUMENMODIFICAR = "usp_UpdateGASTOSRESUME";
        public const string GASTOSRESUMENLISTARMESANO = "usp_ListarMesAnoGASTOSRESUMEN";

        public const string GASTOSCECREAR = "usp_InsertGASTOSCE";
        public const string GASTOSCEBUSCAR = "usp_SelectGASTOSCE";
        public const string GASTOSCELISTAR = "usp_SelectGASTOSCEsAll";
        public const string GASTOSCEELIMINAR = "usp_DeleteGASTOSCE";
        public const string GASTOSCEMODIFICAR = "usp_UpdateGASTOSCE";
        public const string GASTOSCEBYIDGASTO = "usp_SelectGASTOSCEsByIDGasto";
        public const string GASTOSCEBYPROPMESANO = "usp_SelectGASTOSCEPorMesAno";
        public const string GASTOSCEBYPROPIETARIO = "usp_SelectGASTOSCEPropietario";
        public const string GASTOSCEPROPIETARIOBUSCAR = "GastoEspecialPropietarioBuscar";
                                                   
        public const string GASTOSCFCREAR = "usp_InsertGASTOSCF";
        public const string GASTOSCFBUSCAR = "usp_SelectGASTOSCF";
        public const string GASTOSCFLISTAR = "usp_SelectGASTOSCFsAll";
        public const string GASTOSCFELIMINAR = "usp_DeleteGASTOSCF";
        public const string GASTOSCFELIMINARDETALLE = "usp_DeleteGASTOSCFDetalle";
        public const string GASTOSCFMODIFICAR = "usp_UpdateGASTOSCF";
        public const string GASTOSCFBYPROMESANO = "GastosFijoPropietariosBuscar";
        public const string GASTOSCFBYPROMESANODETALLE = "GastosFijoPropietariosBuscarDetalles";
        public const string GASTOSCFBYPROMESANOINACTIVOS = "GastosFijoPropietariosBuscarInactivos";
        public const string GASTOSCFBUSCARDEUDA = "GastosFijoPropietariosBuscarDeudas";
        public const string GASTOSCFBUSCARTODASDEUDA = "GastosFijoPropietariosBuscarTODASDeudas";
      
        public const string GASTOSCVCREAR = "usp_InsertGASTOSCV";
        public const string GASTOSCVBUSCAR = "usp_SelectGASTOSCV";
        public const string GASTOSCVBUSCARTODO = "usp_SelectGASTOSCV_TODO";
        public const string GASTOSCVBUSCARDETALLES = "usp_SelectGASTOSCVDetalles";
        public const string GASTOSCVELIMINARDETALLE = "usp_DeleteGASTOSCVDetalle";
        public const string GASTOSCVBUSCARINACTIVOS = "usp_SelectGASTOSCVInactivos";
        public const string GASTOSCVLISTAR = "usp_SelectGASTOSCVsAll";
        public const string GASTOSCVELIMINAR = "usp_DeleteGASTOSCV";
        public const string GASTOSCVMODIFICAR = "usp_UpdateGASTOSCV";
        public const string GASTOSCVPAGAR = "usp_UpdateGASTOSCVPagar";
        public const string GASTOSCVBYIDGASTO = "usp_SelectGASTOSCVsByRUTAndDate";
        public const string GASTOSCVBYMESANOTIPO = "usp_SelectGASTOSCVsByMESANO";
        public const string GASTOSCVSETPRIMERALECTURA = "GastoCVSetPrimeraLectura";
        //public const string GASTOSCVBUSCARDEUDA = "GastosVariablePropietariosBuscarDeudas";
        public const string GASTOSCVBUSCARTODASDEUDA = "GastosVariablePropietariosBuscarTODASDeudas";
        public const string GASTOSCVBORRARLECTURAANOMESCOGIDO = "GastosCVBorrarLecturaMesAnoCodigo";
        public const string GASTOSCVACTUALIZARLECTURAANOMESCOGIDOPROP = "GastosCVActualizarLecturaMesAnoCodigoProp";
        public const string GASTOSCVBYMESANOTIPOFORCSV = "usp_SelectGASTOSCVsByMESANOforcsv";


        public const string CAMBIOMEDIDORCREAR = "usp_InsertCAMBIOMEDIDOR";
        public const string CAMBIOMEDIDORBUSCAR = "usp_SelectCAMBIOMEDIDOR";
        public const string CAMBIOMEDIDORLISTAR = "usp_SelectCAMBIOMEDIDORsAll";
        public const string CAMBIOMEDIDORELIMINAR = "usp_DeleteCAMBIOMEDIDOR";
        public const string CAMBIOMEDIDORMODIFICAR = "usp_UpdateCAMBIOMEDIDOR";
        public const string CAMBIOMEDIDORMODIFICARBUSCARPORPROPIEDAD = "usp_SelectCAMBIOMEDIDORByRut";
        
        public const string NOMINACREARDEUSUARIO = "NominaCrearDeUsuario";
        public const string NOMINAEXISTEACTUAL = "NominaExisteActual";
        public const string NOMINAACTIVAR = "NominaActivar";
        public const string NOMINACERRAR = "NominaCerrar";
        public const string NOMINABUSCAR = "NominaBuscar";
        public const string NOMINABUSCAR_ID = "NominaBuscar_x_ID";
        public const string NOMINABUSCARABIERTA = "NominaBuscarAbierta";
        public const string NOMINABUSCARINGRESOSREALES = "BuscarIngresosReales";
        public const string NOMINABUSCARINGRESOSREALESPORFECHASPAGOS = "BuscarIngresosRealesFechaPagos";
        public const string NOMINABUSCARTOTALESAPAGAR_X_CUENTAS = "BuscarTotalesaPagarPorCuentas";
        public const string NOMINALISTAR = "NominaListar";
        public const string NOMINAACTUALIZARMSG = "NominaActualizarMSG";
        public const string NOMINABUSCARMSG = "NominaBuscarMSG";
        public const string CHEQUESLISTAR = "ChequeListar";
        public const string CHEQUESELIMINAR = "ChequeEliminar";
        public const string CHEQUESCREAR = "ChequeCrear";
        public const string CHEQUESBUSCAR = "ChequeBuscar";
        public const string CHEQUESMODIFICAR = "ChequeModificar";


        public const string FERIADOLISTAR = "FeriadoListar";
        public const string FERIADOELIMINAR = "FeriadoEliminar";
        public const string FERIADOBUSCAR = "FeriadoBuscar";
        public const string FERIADOCREAR = "FeriadoCrear";
        public const string FOLIO = "GetFolio";
    }
}
