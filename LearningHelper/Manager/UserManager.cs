using System.Collections.Generic;
using Learning.Models;
using LearningHelper.Gateway;
using LearningHelper.Models;

namespace LearningHelper.Manager
{
    public class UserManager:Password
    {
        UserGateway aUserGateway = new UserGateway();
        Status aStatus=new Status();
        
        public int CreateUser(User aUser)
        {
            if (aUserGateway.SearchEmail(aUser.Email))
            {
                return 0;
            }
            aUser.Password = Encrypt(aUser.Password);
            aUserGateway.CreateUser(aUser);
            aStatus.UpdateStatus(aUser);
            return 1;
        }
        
        

        public User LoginUser(User aUser)
        {
            aUser = aUserGateway.LoginUser(aUser);
            if (aUser.Status==null)
            {
                return aUser = null;
            }
            if (aUser.Password == Decrypt(aUser.ConfirmPassword))
            {
                aUser.Password = null;
                return aUser;
            }
            return aUser=null;
        }
        

        public string ConfirmOTP(User aUser)
        {
            string OTPCode = aUser.Status;
            if (aStatus.GetStatus(aUser)==OTPCode)
            {
                aUser.Status = "Active";
                aStatus.UpdateStatus(aUser);
                return "1";
            }
            return "0";

        }

        public List<Address> GetAllDiv()
        {
            return aUserGateway.GetAllDiv();
        }

        public List<Address> GetAllDistrict(string divCode)
        {
            return aUserGateway.GetAllDistrict(divCode);
        }

        public List<Address> GetAllThana(string discode)
        {
            return aUserGateway.GetAllThana(discode);
        }

        public bool UpdateUserDetails(User aUser)
        {
            return aUserGateway.UpdateUserDetails(aUser);
        }

        public int GetTotallLearner(int i)
        {
            return aUserGateway.GetTotallLearner(i);
        }
    }
}