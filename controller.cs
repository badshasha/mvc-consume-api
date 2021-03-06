

public classs UserControoler:Controller {

    Uri baseUrl = new("http://localhost:55117/api");
    HttpClinet client;

    public ctor()
    {
        client = new();
        client.BaseAddress = baseAddress;
    }

    public ActionResult Index(){

        List<userViewModel> modelList = new List<userViewModel>();

        HttpResponseMessage response = client.GetAsync(client.baseAddress+"/user").Result();
        if (response.isSuccessStateCode){
            string data = response.Content.ReadAdStringAsync().Result(); // json information 

            // use newton for deseriealize 
            modelList =  JsonConvert.deseriealizeObject<List<UserViewModel>>(data);
        }
        return View(modelList);

    }

    public ActionResult Create(){
        return View();
    }

    [HttpPost]
    public ActionResult Create(UserViewModel model){

        string data = JsonConverot.SerializeObject(model);
        stringContent content = new stringContent(data, Encording.UTF8 , "applicaiton/json");
        HttpResponseMessage response = client.PostAsync(client.BaseAddress+"/user",content).Result;
        if (response.isSuccessStateCode)
        {
            return RedirectToAction("Index"); /// redirect to index page 
        }
        return View(); // redirect to create view 
    }


    
    public ActionResult update(int id){
        UserViewModel model = new UserViewModel();
        HttpResponseMessage response = client.GetAsync(client.baseAddress+"/user/"+ id ).Result;
        if (response.isSuccessStateCode){

                string data = response.Content.ReadAdStringAsync().Result; // json information 
                model =  JsonConvert.deseriealizeObject<UserViewModel>(data);

        }           
        return View(model);

    }


     [HttpPost]
    public ActionResult Update(UserViewModel model){

        string data = JsonConverot.SerializeObject(model);
        stringContent content = new stringContent(data, Encording.UTF8 , "applicaiton/json");

        HttpResponseMessage response = client.PustAsync( client.BaseAddress + "/user/"+model.userId , content ).Result;
        if (response.isSuccessStateCode)
        {
            return RedirectToAction("Index"); /// redirect to index page 
        }
        return View("update",model); // redirect to create view 
    }

}

