({
    doinit : function(component, event, helper) {
        
       var action = component.get('c.getContactos');
       var Correo = event.getParam("Correo");
       var self = this;
       action.setParams({ "Correo" : Correo });
        
       if (typeof Correo !== "undefined") {
              
        	
                component.set("v.Errores", null);
                
                action.setCallback(this, function(actionResult) {
                component.set('v.Contactos', actionResult.getReturnValue());
    
                    if(actionResult.getReturnValue()==null){
                       
                        component.set('v.Errores', "No se ha podido mostrar los clientes");
                    }
                });

                $A.enqueueAction(action);
        
        }
        
    
    },
    refreshView : function(component,event,helper){
   				var action = component.get("c.refresh");
       alert('refresjj');
		action.setCallback(this, function(response) {
			var state = response.getState();
			if (state === "SUCCESS") {
				component.set("v.Errores", null);
                
				
			} else {
				console.log("Failed with state: " + state);
			}
		});
		$A.enqueueAction(action);
    
		},

        anadircliente: function(component, event, helper) {
     
            var ctarget = event.currentTarget;
            var id_str = ctarget.dataset.value;
            var myAttribute = id_str;
            var action = component.get("c.anadirContacto"); 
         
            action.setParams({ "columna" : myAttribute ,"Contacto":JSON.stringify(component.get("v.Contactos"))});
            action.setCallback(this, function(response) { });
            component.set("v.Contactos", null);
            alert("Cliente añadido correctamente!");
            $A.enqueueAction(action);
                
                  
                
        },  
    
    
    
    
})