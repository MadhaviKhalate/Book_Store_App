using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IAddressRL
    {
        public bool AddAddress(AddressModel addressModel, int UserID);
        public bool UpdateAddress(AddressModel addressModel, int AddressID);
        public IEnumerable<GetAddressModel> GetAddress(int UserID);

    }
}
