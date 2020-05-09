global class ManejadorTriggers {

    	private class TriggerHandlerException extends Exception {}


global static void createHandler(Schema.sObjectType soType)
	{
		ITrigger handler = getHandler(soType);
		
		if (handler == null)	throw new TriggerHandlerException('No Trigger Handler registered for Object Type: ' + soType);
		
		execute(handler);
	}

  private static ITrigger getHandler(Schema.sObjectType soType)
	{
		
	 if	(soType == Opportunity.sObjectType)			    return new OpportunityHandler();
	 else  if 		(soType == Account.sObjectType)					return new AccountHandler();
	 else  if 		(soType == Linea_de_oportunidad__c.sObjectType)					return new LineadeoportundidadHandler();
       else														return null;
	}


	private static void execute(ITrigger handler)
	{
		if(Trigger.isBefore)
		{
			handler.bulkBefore(trigger.new, trigger.oldMap);
			
			if		(Trigger.isInsert)		handler.beforeInsert(trigger.new);
			else if	(Trigger.isUpdate)		handler.beforeUpdate(trigger.new, trigger.oldMap);
			else if	(Trigger.isDelete)		handler.beforeDelete(trigger.oldMap);
		}
		else
		{
			handler.bulkAfter(trigger.new, trigger.oldMap);
			
			if 		(Trigger.isInsert)		handler.afterInsert(trigger.new);
			else if (Trigger.isUpdate)		handler.afterUpdate(trigger.new, trigger.oldMap);
			else if (Trigger.isDelete)		handler.afterDelete(trigger.oldMap);
		}

		handler.andFinally();
	}

}