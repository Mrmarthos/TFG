({
    getContactos : function(component) {
        var action = component.get("c.getContactosa");
        var self = this;        
        action.setCallback(this, function(actionResult) {
        component.set('v.Contactos', actionResult.getReturnValue());
         });
          $A.enqueueAction(action);
    }
})