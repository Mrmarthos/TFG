({
    buscar: function(component, event, helper) {
        

        var appEvent = $A.get("e.c:Evento_Buscar_Correo"); 
        appEvent.setParams({
            "Correo" : component.get("v.Contacto.Correo") })
        appEvent.fire();
               
    }
})