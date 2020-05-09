public class ActualizadorEmpleados {

      @future(callout=true)
    public static void actualizadorEmpleado()
    {
                system.debug('Adddddddddddddddddd------');

                List<map<String,String>> Contactos;
            Map<String, String> Contacto=new Map<String, String>();
            Contactos=new List<map<String,String>>();

             List<Contact> EmpleadosActualizar = new List<Contact>();
             List<User> UsuariosActualizar = new List<User>();
      		
            String endpoint = 'https://erpserver.azurewebsites.net/api/Empleados/GetEmpleados';
            String body = '';//Introducimos los parametros.
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
    try 
     {

            if(errorcode==0){
                        Contactos=new List<map<String,String>>();
                         List<Map<String, Object>> myMaps = new List<Map<String, Object>>();
            			 List<Object> myMapObjects = (List<Object>) JsonSerializado.get('Data');
                      

                         for (Object obj : myMapObjects) {
                         myMaps.add((Map<String, Object>)obj);
                            }
                        integer numeroEmpleados = integer.valueof(JsonSerializado.get('Results'));

            

             Contactos=new List<map<String,String>>();
             for(integer i =0; i<numeroEmpleados;i++){
                                      

                        if(String.valueof(myMaps.get(i).get('Usuario_Salesforce'))=='False'){
                               EmpleadosActualizar.add( new Contact(
                                RecordTypeId = Schema.SObjectType.Contact.getRecordTypeInfosByDeveloperName().get('Empleado_Interno').RecordTypeId,
                                Codigo_de_empleado__c   = String.valueof(myMaps.get(i).get('Num_Empleado')),
                                FirstName               = String.valueof(myMaps.get(i).get('Nombre')),
                                LastName                = String.valueof(myMaps.get(i).get('Apellido_1')) + ' ' +String.valueof(myMaps.get(i).get('Apellido_2')),
                                Activo__c               = String.valueof(myMaps.get(i).get('Activo')) == 'False' ? false : true,
                                Email                   = String.valueof(myMaps.get(i).get('Correo')),
                                MobilePhone                   = String.valueof(myMaps.get(i).get('Movil')),
                                JP__c              = String.valueof(myMaps.get(i).get('Jefe_de_proyecto')) == 'False' ? false : true,
                                Gerente__c          =String.valueof(myMaps.get(i).get('Gerente')) == 'False' ? false : true,
                                Sincronizado_ERP__c =true,

                                AccountId='0011i00000Bt7EcAAJ'

                  
                        ));
                     
                            
                        }else if (String.valueof(myMaps.get(i).get('Usuario_Salesforce'))=='True'){

         

                            List<User> activeUser = [Select Email From User where Email = : String.valueof(myMaps.get(i).get('Correo')) limit 1];
                            system.debug(activeUser);
                            if(activeUser.size()==0){                      
                           	Id perfilid =[SELECT Id FROM Profile WHERE Name ='Chatter Free User'].Id;
                            system.debug(perfilid);


                                UsuariosActualizar.add( new User(
                                EmployeeNumber   = String.valueof(myMaps.get(i).get('Num_Empleado')),
                                IsActive               = String.valueof(myMaps.get(i).get('Activo')) == 'False' ? false : true,
                                Email                   = String.valueof(myMaps.get(i).get('Correo')),
                                MobilePhone                   = String.valueof(myMaps.get(i).get('Movil')),
                                FirstName               = String.valueof(myMaps.get(i).get('Nombre')),
                                LastName                = String.valueof(myMaps.get(i).get('Apellido_1')) + ' ' +String.valueof(myMaps.get(i).get('Apellido_2')),
                                LanguageLocaleKey = 'es',
                                TimeZoneSidKey ='Europe/Paris',
                                EmailEncodingKey = 'UTF-8',
                                Alias = String.valueof(myMaps.get(i).get('Num_Empleado')),
                                 Username=String.valueof(myMaps.get(i).get('Correo')),
                                 LocaleSidKey = 'es_ES',
                                 CommunityNickname=String.valueof(myMaps.get(i).get('Nombre'))+String.valueof(myMaps.get(i).get('Apellido_1')),
                                 ProfileId= perfilid
                                 



                  
                        ));
                        }
                        }


                            
                          
                            
                        }   
                        
            }
            Schema.SObjectField f = Contact.Codigo_de_empleado__c;
            List<Database.UpsertResult> result = Database.upsert(EmpleadosActualizar,Contact.Codigo_de_empleado__c);
            List<Database.UpsertResult> result2 = Database.upsert(UsuariosActualizar);
            system.debug(result2);
      } catch (Exception e) 
        {
           system.debug('EXCEPCION----->' +e);
           System.debug(e.getMessage());
        
        }
        finally
        {
      
        }
    }

}