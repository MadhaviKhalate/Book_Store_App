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
    }
}
