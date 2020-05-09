public class OpportunityHandler implements ITrigger
{
	Map<String,Id> mapRolId = new Map<String,Id>();

	private List<Opportunity> listOppsConAcc = new List<Opportunity>();

    // Equipo de oportunidad - Variables usadas
 
    List<Opportunity> opportunities;

    // Oportunidades pendientes de actualización
    private List<Opportunity> updateOpportunities;

    // Para hacer las DML e insertar nuevas oportunidades al ganar Licencias o AMs
    private List<Opportunity> insertOpportunities;


    public OpportunityHandler() {}
 
    public void bulkBefore(list<SObject> newList, map<Id,SObject> oldMap)   
    {   
      
    }
    
    public void bulkAfter(list<SObject> newList, map<Id,SObject> oldMap)    
    {  
    	
    }

    public void beforeInsert(list<SObject> newList)                         
    { 
    	
    }
    
    public void beforeUpdate(list<SObject> newList, map<Id,SObject> oldMap) 
    {
    	
    }
    
    public void beforeDelete(map<Id,SObject> oldMap)                        {   }
    
    /**
     * These methods ara called for records to be processed during a AFTER 
     * trigger.
     */ 
    public void afterInsert(list<SObject> newList)
    {
    }
     
    public void afterUpdate(list<SObject> newList, map<Id,SObject> oldMap)  
    {  

    
        if (newList != null && !newList.isEmpty() && oldMap != null && !oldMap.isEmpty()) 
        {
            system.debug('cambia oport');
            EnvioCuentasERP.SerializarCuentas(newList, oldMap);

            EnvioLineasERP.SerializarLineas(newList, oldMap);
        }
        
    
    }
     
    public void afterDelete(map<Id,SObject> oldMap)                         {   }
     
    /**
     * andFinally
     *
     * This method is called once all records have been processed by the trigger. Use this
     * method to accomplish any final operations such as creation or updates of other records.
     * Any new DML operation should be included in this method
     */
    public void andFinally()                                                
    {
        
    }
}