global class ActualizarEmpleados implements Schedulable 
{
    global void execute(SchedulableContext ctx) 
    {
        System.debug('Ejecutando actualización de Empleados a día y hora: ' + System.now());
        ActualizadorEmpleados.actualizadorEmpleado();
    }
    
}