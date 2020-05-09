public class ContactosController {
	@future(callout=true)
    public static void InsertarContacto(String Correo,String Movil,String Telefono,String Nombre,String Apellido_1,String Apellido_2,String Cuenta_id,String idSalesforce){
            String endpoint = 'https://erpserver.azurewebsites.net/api/Contactos/InsertContact';
            String body = 'Correo='+Correo + '&Nombre='+Nombre+'&Movil=' + Movil + '&Telefono=' +Telefono + '&Apellido_1='+Apellido_1+'&Apellido_2='+Apellido_2+ '&Cuenta_id=' +Cuenta_id +'&idSalesforce='+idSalesforce ;//Introducimos los parametros.
            system.debug(body);   
            HttpRequest req = new HttpRequest();
            req.setEndpoint(endpoint);
            req.setMethod('POST');
            req.setbody(body);
            req.setHeader('Authorization', GetAccessToken.getToken().substring(1, GetAccessToken.getToken().length()-1));
            Http http = new Http();
            HTTPResponse response = http.send(req);
            Map<String, Object> JsonSerializado = (Map<String, Object>)JSON.deserializeUntyped(response.getBody());
            integer errorcode = integer.valueof(JsonSerializado.get('ErrorCode'));
            system.System.debug(errorcode);
            system.debug(response.getBody());
  
            system.debug(response);
        	Contact ct = [Select id from contact where id=:idSalesforce];
        	ct.ERPID__c=String.valueof(JsonSerializado.get('id'));
        
        	update ct;
        }
}