public class GetAccessToken {
    
    public static string getToken(){

            String endpoint = 'https://erpserver.azurewebsites.net/api/login/authenticate';
            String body = 'Username='+Label.Username+'&Password=' + Label.Password;//Introducimos los parametros.
            HttpRequest req = new HttpRequest();
            req.setEndpoint(endpoint);
            req.setMethod('GET');
            req.setbody(body);
            Http http = new Http();
            HTTPResponse response = http.send(req);
            Token__mdt token= new Token__mdt();
            token.TokenValue__c=response.getBody();
        if(response.getStatusCode()==200){
            
             return response.getBody();
            
            
            
            
        }
          
       		return 'KO';
    }
   

}