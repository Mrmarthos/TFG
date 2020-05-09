public class EnvioCuentasERP {

        public static void SerializarCuentas(list<Opportunity> oportunidades, map<Id,SObject> oldMap){

            String serializedCuentas;
            Set<String> Accounts = new Set<String>();

            for (Opportunity opp: oportunidades) 
         {
            if (opp.stageName.equals('Solicitada') && ((Opportunity)oldMap.get(opp.Id)).get('stageName').equals('Identificada')) 
            {
                Accounts.add(opp.AccountId);

            }
            
         }


          List<Account> cuentas = [SELECT
                                  Id, 
                                  Name,
                                  Razon_Social__c,
                                  ID_ERP__c,
                                  NIF_CIF__c,                         
                                  BillingAddress, 
                                  BillingStreet, 
                                  BillingCity, 
                                  BillingCountry, 
                                  BillingPostalCode,
                                  Phone, 
                                  Fax,
                                  Owner.EmployeeNumber
                                FROM Account
                                WHERE Id IN :Accounts
                                AND (
                                    ID_ERP__c = null
                                    OR ID_ERP__c = ''
                                    )];
                                
        system.debug('Cuentas a enviar a SAP despues de preventa: '+cuentas);
        if(cuentas.size()>0) 
        {
            serializedCuentas = JSON.serialize(cuentas);
            SendObjectERP.sendObjsToERPFromTrigger(serializedCuentas, 'Account');
        }

      


        }


         public static void SerializarCuentasModificacion(list<SObject> accounts, map<Id,SObject> oldMap){

            String serializedCuentas;


             List<String> camposAComprobar = EnvioCuentasERP.CAMPOS_A_COMPROBAR_ACCOUNT;
         if(Trigger.IsExecuting)
        {   
            Set<String> Ids = new Set<String>();

        for(Account acc : (List<Account>)accounts)
                { 
                    for(String campo : camposAComprobar)
                    {
                        if(acc.get(campo) != ((Account)oldMap.get(acc.Id)).get(campo))
                        {
                            Ids.add(acc.Id);
                            System.debug('Id ' + acc.Id);
                        }
                    }
                }


          List<Account> cuentas = [SELECT
                                  Id, 
                                  Name,
                                  Razon_Social__c,
                                  ID_ERP__c,
                                  NIF_CIF__c,                         
                                  BillingAddress, 
                                  BillingStreet, 
                                  BillingCity, 
                                  BillingCountry, 
                                  BillingPostalCode,
                                  Phone, 
                                  Fax,
                                  Owner.EmployeeNumber
                                FROM Account
                                WHERE Id in :Ids 
                                  AND ID_ERP__c != '' 
                                  AND ID_ERP__c != null];
                                
         System.debug('Cuentas a enviar a ERP Modifcicacion: '+cuentas);
            if(cuentas.size()>0) 
        {
            serializedCuentas = JSON.serialize(cuentas);
            SendObjectERP.sendObjsToERPFromTrigger(serializedCuentas, 'Account');

           system.debug('djdfj');
        }
      
        }

        }

     public static final List<string> CAMPOS_A_COMPROBAR_ACCOUNT = new List<String>
    {   
                                                                                        'Name', 
                                                                                        'Razon_Social__c', 
                                                                                        'NIF_CIF__c', 
                                                                                        'BillingAddress', 
                                                                                        'BillingStreet', 
                                                                                        'BillingCity', 
                                                                                        'BillingPostalCode', 
                                                                                        'Phone', 
                                                                                        'Fax', 
                                                                                        'Sector__c'
    };
    
    

}