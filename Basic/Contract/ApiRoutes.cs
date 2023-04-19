using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic.Contract
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "V1";
        public const string Base = Root +"/" +Version;



        public static  class Home
        {
            //api/v1/home 
            public const string GetAll = Base + "/home/GetAll";

            public const string Secret = Base + "/home/Secret";

            public const string Authenticate = Base + "/home/Authenticate";
    

        }

    }
}
