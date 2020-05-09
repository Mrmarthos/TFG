public class BuscarCorreoController {
    
    @AuraEnabled
    public static List<map<String,String>> getContactos(String Correo){
       
             List<map<String,String>> Contactos;
            Map<String, String> Contacto=new Map<String, String>();
            Contactos=new List<map<String,String>>();
            List<Account> cuenta =new List<Account>();
      		
            String endpoint = 'https://erpserver.azurewebsites.net/api/Contactos/GetByCompany';
            String body = 'Company='+Correo;//Introducimos los parametros.
            String headers=GetAccessToken.getToken();
            
            HttpRequest req = new HttpRequest();
            req.setEndpoint(endpoint);
            req.setMethod('POST');
            req.setbody(body);
            req.setHeader('Authorization', GetAccessToken.getToken().substring(1, GetAccessToken.getToken().length()-1));
            Http http = new Http();
            HTTPResponse response = http.send(req);
        	Map<String, Object> JsonSerializado = (Map<String, Object>)JSON.deserializeUntyped(response.getBody());
            integer errorcode = integer.valueof(JsonSerializado.get('ErrorCode'));
        	system.debug('Reuest-->' + req.getBody());
            system.System.debug(errorcode);

            system.debug(JsonSerializado);

            if(errorcode==0){
                        Contactos=new List<map<String,String>>();
                         List<Map<String, Object>> myMaps = new List<Map<String, Object>>();
            			 List<Object> myMapObjects = (List<Object>) JsonSerializado.get('Data');
                      

                         for (Object obj : myMapObjects) {
                         myMaps.add((Map<String, Object>)obj);
                            }
                        integer numeroContactos = integer.valueof(JsonSerializado.get('Results'));

            

             Contactos=new List<map<String,String>>();
             for(integer i =0; i<numeroContactos;i++){
                          
                            Contacto = new Map<String, String>();
                            Contacto.put('Correo',String.valueof(myMaps.get(i).get('Correo')));
                            Contacto.put('Movil',String.valueof(myMaps.get(i).get('Movil')));
                            Contacto.put('Telefono',String.valueof(myMaps.get(i).get('Telefono')));
                            Contacto.put('Nombre',String.valueof(myMaps.get(i).get('Nombre')));
                            Contacto.put('Apellido_1',String.valueof(myMaps.get(i).get('Apellido_1')));
                            Contacto.put('Apellido_2',String.valueof(myMaps.get(i).get('Apellido_2')));
                            Contacto.put('Comentario',String.valueof(myMaps.get(i).get('Comentario')));
                            if(String.valueof(myMaps.get(i).get('Cuenta_id'))!=null){


                                     cuenta = [SELECT Account.Name FROM  Account  WHERE ID_ERP__c =:String.valueof(myMaps.get(i).get('Cuenta_id'))];
                                        if(cuenta.size()!=0){
                                    Contacto.put('Cliente',cuenta.get(0).Name); 
                            }
                            }
                            
                            
                        
                            
                            system.debug(String.valueof(myMaps.get(i).get('compania'))) ;
                 			Contacto.put('ID',String.valueof(myMaps.get(i).get('id')));   
                            Contacto.put('columna',String.valueof(i));          
                                 						                                                     
                            Contactos.add(Contacto);

                            
                          
                            
                        }   
            }
            system.debug(Contactos);
            if(Contactos.size()==0){
                return null;
            }else return Contactos;
          
    }

       @AuraEnabled
    public static void refresh(){
        
        system.debug('refresh');
    }

        @AuraEnabled
    public static void anadirContacto(String  columna  ,String Contacto ){
     	  List<map<String,String>> lstFilters = (  List<map<String,String>>)System.JSON.deserializeStrict(Contacto,   List<map<String,String>>.Class);
      		       
 
        
              	list<Contact> contacts = new list<Contact>(); 
                Contact Cont = new Contact();
                system.debug(lstFilters.get(Integer.valueOf(columna)).get('Correo'));
                Cont.Email=lstFilters.get(Integer.valueOf(columna)).get('Correo');
                Cont.Phone=lstFilters.get(Integer.valueOf(columna)).get('Telefono');
                Cont.Firstname=lstFilters.get(Integer.valueOf(columna)).get('Nombre');
                Cont.Lastname=lstFilters.get(Integer.valueOf(columna)).get('Apellido_1')+' '+lstFilters.get(Integer.valueOf(columna)).get('Apellido_2');
                Cont.MobilePhone= lstFilters.get(Integer.valueOf(columna)).get('Movil');     
        		cont.Sincronizado_ERP__c=True;
        		cont.ERPID__c=lstFilters.get(Integer.valueOf(columna)).get('ID');  
                cont.Comentario_ERP__c=lstFilters.get(Integer.valueOf(columna)).get('Comentario');  
                List<Account> cuenta=[SELECT id FROM  Account  WHERE Name =:lstFilters.get(Integer.valueOf(columna)).get('Cliente')];
                
        		if(cuenta.size()!=0){
                    cont.AccountId= cuenta.get(0).id; 
                }
        		
            	contacts.add(cont);
        		
            
        		insert cont;
       
    }
  
    

}