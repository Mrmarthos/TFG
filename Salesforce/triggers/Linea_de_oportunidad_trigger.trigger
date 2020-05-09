trigger Linea_de_oportunidad_trigger on Linea_de_oportunidad__c (after delete, after insert, after undelete, after update, before delete, before insert, before update) {
	ManejadorTriggers.createHandler(Linea_de_oportunidad__c.sObjectType);
}