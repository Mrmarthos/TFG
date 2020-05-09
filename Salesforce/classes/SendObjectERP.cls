public class SendObjectERP {


    /**
     * Este método llama al siguiente pero de forma asíncrona porque se utiliza en un trigger
       El método no va a poder devolver la HttpResponse así su procesamiento tendrá q ser en el propio método,
       por lo tanto, para hacerlo genérico, le pasamos el tipo de objeto como argumento
     * @author: Andres Martos (2019/05/10)
     */

     @future(callout=true)
    public static void sendObjsToERPFromTrigger(String serializedObjs, String tipoObjeto) 
    {
        system.debug('from trigger');
        sendObjsToERP(serializedObjs, tipoObjeto);
    }


    public static void sendObjsToERP(String serializedObjs, String tipoObjeto)
    {

    try {

         if(tipoObjeto == 'Account'){


             System.debug(serializedObjs);

               System.debug('ENVÍO DE CUENTAS');

                    List<Account> accs = (List<Account>) JSON.deserialize(serializedObjs, List<Account>.class);      
                    List<Account> cuentas = new List<Account>();   

                    for (Account acc : accs) 
                    {
                        String IdSalesforce =             acc.Id                    == null ? '' : String.valueOf(acc.Id);
                        String RazonSocial =                   acc.Razon_Social__c       == null ? '' : String.valueOf(acc.Razon_Social__c);
                        String IdERP =                    acc.ID_ERP__c             == null ? '' : String.valueOf(acc.ID_ERP__c);
                        String NIF_CIF =                   acc.NIF_CIF__c            == null ? '' : String.valueOf(acc.NIF_CIF__c);
                        String Cod_Postal =      acc.BillingPostalCode     == null ? '' : String.valueOf(acc.BillingPostalCode); 
                        String Pais =         acc.BillingCountry    == null ? '' : String.valueOf(acc.BillingCountry);
                        String Ciudad =            acc.BillingCity           == null ? '' : String.valueOf(acc.BillingCity);
                        String Nombre =                   acc.Name       == null ? '' : String.valueOf(acc.Name);
                        String Propietario =             acc.Owner.EmployeeNumber  == null ? '' : String.valueOf(acc.Owner.EmployeeNumber);
                        String Direccion =             String.valueOf(acc.billingstreet+' '+ acc.billingcity +' '+  acc.billingstate +' '+  acc.billingPostalCode+' '+  acc.BillingCountry );
                        

                         String endpoint=null;
                        String Direccion_Facturacion =            acc.BillingStreet  == null ? '' : String.valueOf(acc.BillingStreet);
                        
                        if(IdERP!=''){
                        endpoint = 'https://erpserver.azurewebsites.net/api/Cliente/ModifyClient';
                        }                   
                         else {endpoint = 'https://erpserver.azurewebsites.net/api/Cliente/InsertClient';}
                        String body = 'IdSalesforce='+IdSalesforce + '&Razon_Social=' +RazonSocial+ '&NIF_CIF='+NIF_CIF+'&Cod_Postal='+Cod_Postal+'&Pais='+Pais+'&Ciudad='+Ciudad+'&Nombre='+Nombre+'&Propietario='+Propietario+'&Direccion='+Direccion+'&Direccion_Facturacion='+Direccion_Facturacion+'&Id='+IdERP;//Introducimos los parametros.
                      //String body = 'IdSalesforce=345345'+ '&RazonSocial=jhjkhj' + '&NIF_CIF=7777'+'&Cod_Postal=28'+'&Pais=es'+'&Ciudad=kii'+'&Nombre=mose'+'&Propietario=77'+'&Direccion=aqrt'+'&Direccion_Facturacion=jj';//Introducimos los parametros.
                      SYSTEM.debug(body);
                     HttpRequest req = new HttpRequest();
                     req.setEndpoint(endpoint);
                    req.setMethod('POST');
                    req.setHeader('Authorization', GetAccessToken.getToken().substring(1, GetAccessToken.getToken().length()-1));
                    req.setbody(body);
                    Http http = new Http();
                    HTTPResponse response = http.send(req);
                    Map<String, Object> JsonSerializado = (Map<String, Object>)JSON.deserializeUntyped(response.getBody());
                    system.debug(response);
                    integer errorcode = integer.valueof(JsonSerializado.get('ErrorCode'));
                    integer Results = integer.valueof(JsonSerializado.get('Results'));
                    System.debug(errorcode);
                    System.debug('---------------');
                    system.debug(JsonSerializado);

                    if(errorcode==0  ){
                                String id = String.valueof(JsonSerializado.get('id'));
                                system.debug('ID DE CUENTA -----'+id);
                                cuentas.add( new Account
                                                (
                                                    ID                     = IdSalesforce == null ? '' : IdSalesforce,
                                                    ID_ERP__c              = id == null ? '' : id,
                                                    Sincronizado_ERP__c    = true
                                                ) 
                                );


                               



                    } else { logutil.newLog(acc, 'No se ha podido sincronizar la cuenta por' + JsonSerializado.get('ErrorMessage') ); }

            
                    
                    }   


                    system.debug('Cuentas modificadas-----'+cuentas);
                      if (cuentas.size()>0) {update cuentas;}
   


             





         }else if (tipoObjeto == 'Lineas'){

                   System.debug(serializedObjs);

               System.debug('ENVÍO DE Lineas');
          
                    List<Linea_de_oportunidad__c> lps = (List<Linea_de_oportunidad__c>) JSON.deserialize(serializedObjs, List<Linea_de_oportunidad__c>.class);      
                    List<Linea_de_oportunidad__c> lineas = new List<Linea_de_oportunidad__c>();   

                    for (Linea_de_oportunidad__c lp : lps) 
                    {
                        String IdSalesforce =             lp.Id                    == null ? '' : String.valueOf(lp.Id);
                        String Nombre =                     lp.Name       == null ? '' : String.valueOf(lp.Name);
                        String Importe=                    lp.Importe_Total__c             == null ? '' : String.valueOf(lp.Importe_Total__c);
                        String Gerente =                   lp.Responsable_de_rea__r.EmployeeNumber            == null ? '' : String.valueOf(lp.Responsable_de_rea__r.EmployeeNumber);
                        String Comercial =      lp.Oportunidad__r.Owner.EmployeeNumber     == null ? '' : String.valueOf(lp.Oportunidad__r.Owner.EmployeeNumber); 
                        String Fecha_Inicio =         lp.Fecha_Inicio__c    == null ? '' : String.valueOf(lp.Fecha_Inicio__c);
                        String Fecha_fin =            lp.Fecha_fin__c           == null ? '' : String.valueOf(lp.Fecha_fin__c);
                        String Jefe_Proyecto =                   lp.Jefe_de_proyecto2__r.Codigo_de_empleado__c       == null ? '' : String.valueOf(lp.Jefe_de_proyecto2__r.Codigo_de_empleado__c);
                        String CodOferta =             lp.Oportunidad__r.Codigo_de_oportuniidad__c  == null ? '' : String.valueOf(lp.Oportunidad__r.Codigo_de_oportuniidad__c);
                        String Cliente =             lp.Oportunidad__r.Account.ID_ERP__c  == null ? '' : String.valueOf(lp.Oportunidad__r.Account.ID_ERP__c);
                        system.debug(lp.Oportunidad__r.Account.ID_ERP__c);
                        String IdERP =                    lp.ID_ERP__c             == null ? '' : String.valueOf(lp.ID_ERP__c);
                         String endpoint=null;
                        String area =                    lp.area__c             == null ? '' : String.valueOf(lp.area__c);
                        
                        if(IdERP!=''){
                        endpoint = 'https://erpserver.azurewebsites.net/api/PEPS/ModifyPEP';
                        }                   
                         else {endpoint = 'https://erpserver.azurewebsites.net/api/PEPS/InsertPEP';}

                         system.debug(endpoint);
                       
                        String body = 'IdSalesforce='+IdSalesforce + '&Importe=' +Importe+ '&Gerente='+Gerente+'&Comercial='+Comercial+'&Fecha_Inicio='+Fecha_Inicio+'&Nombre='+Nombre+'&Fecha_Fin='+Fecha_Fin+'&Jefe_Proyecto='+Jefe_Proyecto+'&Cod_Oferta='+CodOferta+ '&Cliente=' +Cliente + '&Area='+area +'&Id='+IdERP  ;//Introducimos los parametros.
                      //String body = 'IdSalesforce=345345'+ '&RazonSocial=jhjkhj' + '&NIF_CIF=7777'+'&Cod_Postal=28'+'&Pais=es'+'&Ciudad=kii'+'&Nombre=mose'+'&Propietario=77'+'&Direccion=aqrt'+'&Direccion_Facturacion=jj';//Introducimos los parametros.
                      SYSTEM.debug(body);
                     HttpRequest req = new HttpRequest();
                     req.setEndpoint(endpoint);
                    req.setMethod('POST');
                    req.setHeader('Authorization', GetAccessToken.getToken().substring(1, GetAccessToken.getToken().length()-1));
                    req.setbody(body);
                    Http http = new Http();
                    HTTPResponse response = http.send(req);
                    Map<String, Object> JsonSerializado = (Map<String, Object>)JSON.deserializeUntyped(response.getBody());
                    system.debug(response);
                    integer errorcode = integer.valueof(JsonSerializado.get('ErrorCode'));
                    integer Results = integer.valueof(JsonSerializado.get('Results'));
                    System.debug(response.getBody());
                    System.debug('---------------');

                    if(errorcode==0 ){
                                String id = String.valueof(JsonSerializado.get('id'));
                                system.debug('id de la nueva linea' +id);
                                lineas.add( new Linea_de_oportunidad__c
                                                (
                                                    ID                     = IdSalesforce == null ? '' : IdSalesforce,
                                                    ID_ERP__c              = id == null ? '' : id,
                                                    Sincronizado_ERP__c    = true
                                                ) 
                                );


                               



                    }
                        else { logutil.newLog(lp, 'No se ha podido sincronizar la linea por' + JsonSerializado.get('ErrorMessage') ); }
            
                    
                    }   

                     if (lineas.size()>0) update lineas;

         }







          }      catch (Exception ex) 
        {

        } 
            finally 
        {
          
        }

    }

}