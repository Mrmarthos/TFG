global virtual class LogUtil {

    private static List<Log__c> exceptionList = new List<Log__c>();

    global static void newLog(String error)
        {
           
                    exceptionList.add(
                    new Log__c (
                            error__c = error
                            
                            )
                    );
                    insert exceptionList;
                        exceptionList.clear();
        }


    global static void newLog( Linea_de_oportunidad__c lp , String error)
        {

              exceptionList.add(
                    new Log__c (
                            error__c = error,
                            L_nea_de_oportunidad__c=lp.Id
                            )
                    );
                    insert exceptionList;
                        exceptionList.clear();
           
        }

     global static void newLog( Account acc , String error)
        {
            
              exceptionList.add(
                    new Log__c (
                            error__c = error,
                            Cuenta__c	=acc.id
                            )
                    );
                    insert exceptionList;
                        exceptionList.clear();
        }


    global static void newLog( User us , String error)
        {
         
            exceptionList.add(
                    new Log__c (
                            error__c = error,
                            Usuario__c	=us.id
                            )
                    );
                    insert exceptionList;
                        exceptionList.clear();
        }


        
    global static void newLog( Contact con , String error)
        {
                 exceptionList.add(
                    new Log__c (
                            error__c = error,
                            Contacto__c	=con.id
                            )
                    );
                    insert exceptionList;
                        exceptionList.clear();

        }


}