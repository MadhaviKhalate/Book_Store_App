using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IAdminBL
    {
        public bool AdminLogin(LoginModel loginModel);

    }
}
