trigger Contact_Triger on Contact (after insert) {
    
 
    
      for(Contact c: Trigger.new){
          if(c.AccountId!=null || !system.isBatch() || !system.isFuture()){
               Account cuenta = [Select ID_ERP__c from Account where id=:c.AccountId];
          	//ContactosController.InsertarContacto(c.Email,c.MobilePhone,c.Phone,c.Firstname,c.Lastname,c.Lastname,cuenta.ID_ERP__c,c.Id);

          }
         
        System.debug('id is: ' + c.Id);

        System.debug('name is : ' + c.Firstname);

     }
}