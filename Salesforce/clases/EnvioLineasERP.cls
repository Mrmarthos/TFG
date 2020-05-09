public class EnvioLineasERP {
    
    public static void SerializarLineas(list<Opportunity> oportunidades, map<Id,SObject> oldMap){
       	    
               
            String serializedLineas;
            Set<String> Peps = new Set<String>();
             Set<String> Accounts = new Set<String>();

              for (Opportunity opp: oportunidades) 
         {
            if (opp.stageName.equals('Preventa') && ((Opportunity)oldMap.get(opp.Id)).get('stageName').equals('Solicitada')) 
            {
                Accounts.add(opp.Id);

            }
         }
            
            List<Linea_de_oportunidad__c> lineas = [SELECT
                                  Id, 
                                  Name,
                                  Importe_Total__c,
                                  Responsable_de_rea__r.EmployeeNumber,
                                  Oportunidad__r.Owner.EmployeeNumber,                         
                                  Fecha_Inicio__c, 
                                  Fecha_fin__c, 
                                  Jefe_de_proyecto2__r.Codigo_de_empleado__c,
                                   ID_ERP__c,
                                  Oportunidad__r.Codigo_de_oportuniidad__c,
                                  Oportunidad__r.Account.ID_ERP__c,
                                  area__c
                              
                                FROM Linea_de_oportunidad__c
                                WHERE  Oportunidad__c IN :Accounts
                                AND (
                                    ID_ERP__c = null
                                    OR ID_ERP__c = '' 
                                    ) AND  Validado_para_preventa__c =true];

            System.debug('Lineas a enviar a SAP despues de preventa: '+lineas);
        if(lineas.size()>0) 
        {
             serializedLineas = JSON.serialize(lineas);
             SendObjectERP.sendObjsToERPFromTrigger(serializedLineas, 'Lineas');
        }

        
        
    }

     public static void SerializarLineaModificacion(list<SObject> Lineas, map<Id,SObject> oldMap){
       	    
           
            String serializedLineas;
            Set<String> Peps = new Set<String>();

             Set<String> Ids = new Set<String>();
            for(SObject lp : Lineas)
                    { 
                        Ids.add(lp.Id);
                    }
            List<Linea_de_oportunidad__c> lineas2 = [SELECT
                                  Id, 
                                  Name,
                                  Importe_Total__c,
                                  Responsable_de_rea__r.EmployeeNumber,
                                  Oportunidad__r.Owner.EmployeeNumber,                         
                                  Fecha_Inicio__c, 
                                  Fecha_fin__c, 
                                  Jefe_de_proyecto2__r.Codigo_de_empleado__c,
                                   ID_ERP__c,
                                  Oportunidad__r.Codigo_de_oportuniidad__c,
                                  Oportunidad__r.Account.ID_ERP__c,
                                  area__c
                              
                                FROM Linea_de_oportunidad__c
                                WHERE  Id IN :Ids
                                  AND  ID_ERP__c != '' 
                                  AND ID_ERP__c != null AND  Validado_para_preventa__c =true
                                    ];

            System.debug('Lineas a enviar a SAP despues de preventa: '+lineas2);
        if(lineas2.size()>0) 
        {
             serializedLineas = JSON.serialize(lineas2);
             if(System.IsBatch() == false && System.isFuture() == false){ 
                  system.debug('aquiiii1');
            SendObjectERP.sendObjsToERPFromTrigger(serializedLineas, 'Lineas');}
             
        }

        
        
    }

}