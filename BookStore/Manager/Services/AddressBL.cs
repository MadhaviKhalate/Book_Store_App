using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL iaddressRL;
        public AddressBL(IAddressRL iaddressRL)
        {
            this.iaddressRL = iaddressRL;
        }

        public bool AddAddress(AddressModel addressModel, int UserID)
        {
            try
            {
                return iaddressRL.AddAddress(addressModel, UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAddress(AddressModel addressModel, int AddressID)
        {
            try
            {
                return iaddressRL.UpdateAddress(addressModel, AddressID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GetAddressModel> GetAddress(int UserID)
        {
            try
            {
                return iaddressRL.GetAddress(UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
