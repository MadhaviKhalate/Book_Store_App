using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class UserBL : IUserBL
    {
            private readonly IUserRL iuserRL;

            public UserBL(IUserRL iuserRL)
            {
                this.iuserRL = iuserRL;
            }

            public bool Registration(RegisterModel userRegistrationModel)
            {
                try
                {
                    return iuserRL.Registration(userRegistrationModel);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        public bool Login(LoginModel loginModel)
        {
            try
            {
                return iuserRL.UserLogin(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgetPassword(string EmailId)
        {
            try
            {
                return iuserRL.ForgetPassword(EmailId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
