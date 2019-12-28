using Learning.Models;
using LearningHelper.Gateway;

namespace LearningHelper.Manager
{
    public class Status
    {
        SendMail aMail = new SendMail();
        UserGateway aUserGateway = new UserGateway();
        public void UpdateStatus(User aUser)
        {
            if (aUser.Status=="Active")
            {
                aUserGateway.UpdateStatus(aUser,"Active");
            }
            else
            {
                aUserGateway.UpdateStatus(aUser,aMail.SendOTP(aUser.Email).ToString());
            }
        }

        public string GetStatus(User aUser)
        {
            aUser=aUserGateway.LoginUser(aUser);
            return aUser.Status;
        }
    }
}