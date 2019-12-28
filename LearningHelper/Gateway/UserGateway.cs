using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Learning.Models;
using LearningHelper.Models;

namespace LearningHelper.Gateway
{
    public class UserGateway:Learning.Gateway.Gateway

{
    public string CreateUser(User aUser)
    {
        Query = "INSERT INTO TUser(Name,Email,Gender,DOB,UserType,Password,Location) VALUES(@Name,@Email,@Gender,@DOB,@UserType,@Password,@Location)";

        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.AddWithValue("Name", aUser.Name);
        Command.Parameters.AddWithValue("Email", aUser.Email);
        Command.Parameters.AddWithValue("Gender", aUser.Gender);
        Command.Parameters.AddWithValue("DOB", aUser.DOB);
        Command.Parameters.AddWithValue("UserType", aUser.UserType);
        Command.Parameters.AddWithValue("Password", aUser.Password);
        Command.Parameters.AddWithValue("Location", aUser.Location);
        Connection.Open();
        Command.ExecuteNonQuery();
        Connection.Close();
        return "Successful";
    }

    public bool SearchEmail(string aUserEmail)
    {
        Query = "SELECT * FROM TUser where Email = @Email";

        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.AddWithValue("Email", aUserEmail);
        Connection.Open();
        Command.ExecuteNonQuery();
        Reader = Command.ExecuteReader();
        if (Reader.Read())
        {
            return true;
        }
        Reader.Close();
        Connection.Close();
        return false;
        }

    public User LoginUser(User aUser)
    {
        Query = "SELECT * FROM  TUser where Email = @Email";
        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.AddWithValue("Email", aUser.Email);
        Connection.Open();
        Command.ExecuteNonQuery();
        Reader = Command.ExecuteReader();
        if (Reader.Read())
        {
            aUser.Id = (int)Reader["ID"];
            aUser.Name = Reader["Name"].ToString();
            aUser.UserType = (int)Reader["UserType"];
            aUser.Gender = (int) Reader["Gender"];
            aUser.DOB = (DateTime) Reader["DOB"];
            aUser.ConfirmPassword = Reader["Password"].ToString();
            aUser.Status = Reader["Status"].ToString();
            aUser.Mobile =  Reader["Mobile"].ToString();
            aUser.Location = Reader["Location"].ToString();
            aUser.DetailsAddress = Reader["Address"].ToString();
        }
        Reader.Close();
        Connection.Close();
        return aUser;
    }

    public void UpdateStatus(User aUser, string Status)
    {
        //Query = "UPDATE Login SET (Status) =(@Status) WHERE (Email)=(@Email)";
        Query = "UPDATE TUser SET Status='"+Status+"' WHERE Email='"+aUser.Email+"'";

        Command = new SqlCommand(Query, Connection);
        //Command.Parameters.Clear();
        //Command.Parameters.AddWithValue("Email", aUser.Email);
        //Command.Parameters.AddWithValue("Status", aUser.Status);
        Connection.Open();
        Command.ExecuteNonQuery();
        Connection.Close();
        }

    public List<Address> GetAllDiv()
    {
        List<Address> divs;
        Query = "SELECT * FROM Division ";

        divs = new List<Address>();
        Command = new SqlCommand(Query, Connection);
        Connection.Open();
        Command.ExecuteNonQuery();
        Reader = Command.ExecuteReader();
        while (Reader.Read())
        {
            Address aDiv = new Address();
            aDiv.DivCode = (int)Reader["ID"];
            aDiv.DivName = Reader["DivName"].ToString();
            divs.Add(aDiv);
        }
        Reader.Close();
        Connection.Close();
        return divs;
        }

    public List<Address> GetAllDistrict(string divCode)
    {
        List<Address> diss=new List<Address>();
        Query = "SELECT * FROM  District where DivisionId = @DivisionId";

        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.AddWithValue("DivisionId", divCode);
        Connection.Open();
        Command.ExecuteNonQuery();
        Reader = Command.ExecuteReader();
        while (Reader.Read())
        {
            Address aDis = new Address();
            aDis.DisCode = (int)Reader["ID"];
            aDis.District = Reader["Name"].ToString();
            diss.Add(aDis);
        }
        Reader.Close();
        Connection.Close();
        return diss;
        }

    public List<Address> GetAllThana(string discode)
    {
        List<Address> thanas = new List<Address>();
        Query = "SELECT * FROM  Thana where DistrictId = @DistrictId";

        Command = new SqlCommand(Query, Connection);
        Command.Parameters.Clear();
        Command.Parameters.AddWithValue("DistrictId", discode);
        Connection.Open();
        Command.ExecuteNonQuery();
        Reader = Command.ExecuteReader();
        while (Reader.Read())
        {
            Address aThana = new Address();
            aThana.ThanaCode = (int)Reader["ID"];
            aThana.Thana = Reader["Name"].ToString();
            thanas.Add(aThana);
        }
        Reader.Close();
        Connection.Close();
        return thanas;
        }

    public bool UpdateUserDetails(User aUser)
    {

        //Query = "UPDATE Login SET (Status) =(@Status) WHERE (Email)=(@Email)";
        Query = "UPDATE TUser SET Name='" + aUser.Name + "', Gender='" + aUser.Gender + "', DOB='" + aUser.DOB + "', Mobile='" + aUser.Mobile + "', Location='" + aUser.Location + "', Address='" + aUser.DetailsAddress + "' WHERE Email='" + aUser.Email + "'";

        Command = new SqlCommand(Query, Connection);
        //Command.Parameters.Clear();
        //Command.Parameters.AddWithValue("Email", aUser.Email);
        //Command.Parameters.AddWithValue("Status", aUser.Status);
        Connection.Open();
        Command.ExecuteNonQuery();
        Connection.Close();
        return true;
    }

        public int GetTotallLearner(int i)
        {
            int Number=0;
            Query = "SELECT count(*) AS NUM FROM  tUser where UserType = @UserType";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("UserType", i);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                Number = (int)Reader["NUM"];
            }
            Reader.Close();
            Connection.Close();
            return Number;
        }
}
}