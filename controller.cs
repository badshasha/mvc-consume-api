

public classs UserControoler:Controller {

    Uri baseUrl = new("http://localhost:55117/api");
    HttpClinet client;

    public ctor()
    {
        client = new();
        client.BaseAddress = baseAddress;
    }

    public ActionResult Index(){
        HttpResponseMessage response = client.GetAsync(client.baseAddress+"/user").Result();
        if (response.isSuccessStateCode){
            string data = response.Content.ReadAdStringAsync().Result();
        }
        return View();

    }

}

