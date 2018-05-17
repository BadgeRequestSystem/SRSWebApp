﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;

public partial class Login : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "script", "LoginFadeIn();", true); //fade effects script (see JS.js file)
        /*
        ************************Currently just used to generate password hashes*************************
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        System.Security.Cryptography.Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes("Adams", salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        string savedPasswordHash = Convert.ToBase64String(hashBytes);
        userBox.Text = savedPasswordHash; //+ " Salt:" + Convert.ToBase64String(salt);
        *************************************************************************************************
        */

    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        Methods m = new Methods();
        bool isManager = false;
        bool isHR = false;
        string tempID;
        string tempMan;
        string tempEmail;
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand(@"Select PasswordHash FROM Credentials   WHERE Username=@uname", Connection);
                cmd.Parameters.AddWithValue("@uname", m.sanitizeInput(userBox.Text));

                string temp2 = (string)cmd.ExecuteScalar();
                byte[] hashBytes = Convert.FromBase64String(temp2);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                System.Security.Cryptography.Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passBox.Text, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                int result = 1;
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                    {
                        result = 0;
                    }

                if (result == 1)
                {
                    //logged in succesfully, storing isManager and isHR to fields and then to cookie
                    SqlCommand cmdGetManager = new SqlCommand(@"SELECT isManager FROM Credentials 
                                                    WHERE Username=@uname", Connection);
                    cmdGetManager.Parameters.AddWithValue("@uname", userBox.Text);
                    bool temp = (bool)cmdGetManager.ExecuteScalar();
                    isManager = temp;

                    SqlCommand cmdGetHR = new SqlCommand(@"SELECT isHR FROM Credentials 
                                                    WHERE Username=@uname", Connection);
                    cmdGetHR.Parameters.AddWithValue("@uname", userBox.Text);
                    temp = (bool)cmdGetHR.ExecuteScalar();
                    isHR = temp;
                    
                    SqlCommand cmdGetUserID = new SqlCommand(@"SELECT UserID FROM Credentials 
                                                    WHERE Username=@uname", Connection);
                    cmdGetUserID.Parameters.AddWithValue("@uname", userBox.Text);
                    tempID = (string)cmdGetUserID.ExecuteScalar();

                    SqlCommand cmdGetManagerName = new SqlCommand(@"SELECT [Manager Name] FROM Employees
                                                    WHERE UserID=@tempID", Connection);
                    cmdGetManagerName.Parameters.AddWithValue("@tempID", tempID);
                    tempMan = (string)cmdGetManagerName.ExecuteScalar();

                    SqlCommand cmdGetEmail = new SqlCommand(@"SELECT Email FROM Credentials
                                                    WHERE Username=@uname", Connection);
                    cmdGetEmail.Parameters.AddWithValue("@uname", userBox.Text);
                    tempEmail = (string)cmdGetEmail.ExecuteScalar();

                    HttpCookie aCookie = new HttpCookie("userInfo");
                    aCookie.Values["userName"] = userBox.Text;
                    aCookie.Values["isManager"] = isManager.ToString();
                    aCookie.Values["isHR"] = isHR.ToString();
                    aCookie.Values["UserID"] = tempID;
                    aCookie.Values["Manager"] = tempMan;
                    aCookie.Values["Email"] = tempEmail;
                    Response.Cookies.Add(aCookie);

                    Connection.Close();
                    Response.Redirect("~/MainMenuForm.aspx");

                }

                else //LOGIN UNSUCCESFUL
                {
                    Connection.Close();
                    Response.Redirect("~/Login.aspx");

                }
                    
            }
            catch (Exception ex)
            {

            }
        }

    }
}