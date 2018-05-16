using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for Methods
/// </summary>
public class Methods
{
    //So we won't have the connection string hanging around every page and changing it here will change it everywhere!
    public string SQL_STRING = "Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3";
    //~~

    public Methods()
    {

    }

    public string sanitizeInput(string x)
    {
        string toReturn = x;

        if (toReturn.Contains("'"))
        {
            toReturn = toReturn.Replace("'", "");
        }


        return toReturn;
    }

    public string lastFourOnly(string x)
    {
        string toReturn = "*****" + x[5] + x[6] + x[7] + x[8];

        return toReturn;

    }

    public void EditEmployee(string CASE, string LName, string FName, string MName, string Initials, string UserID, string ECompany, string Department, string WLocation, string WPhone, string MWLocation, string MWPhone, string EManager)
    {
        SqlCommand query = new SqlCommand(); //store the command here

        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            if (CASE == "NEW")
                query = new SqlCommand(@"INSERT INTO Employees
                    VALUES (@LName, @FName, @MName, @Initials, @UserID, @ECompany, @Department, @WLocation, @WPhone, @EManager, @MWLocation, @MWPhone);", Connection);
            if (CASE == "UPDATE")
                query = new SqlCommand(@"Update Employees
                    SET [First Name]=@FName, [Last Name]=@LName, [Middle Name]=@MName, [Initials]=@Initials, [Employee Company]=@ECompany, [Department]=@Department, [Work Location]=@WLocation, [Work Phone Number]=@WPhone, [Manager Name]=@EManager, [Manager Work Location]=@MWLocation, [Manager Work Phone Number]=@MWPhone
                    WHERE UserID=@UserID;", Connection);
            //NewEmployee(TextBox3.Text,TextBox1.Text,TextBox2.Text,TextBox4.Text,TextBox5.Text,TextBox6.Text,TextBox7.Text,TextBox8.Text,TextBox9.Text,TextBox10.Text,TextBox11.Text,EmployeeDDL.SelectedItem.Text);
            Connection.Open();
            SqlCommand cmd = query;
            cmd.Parameters.AddWithValue("@LName", sanitizeInput(LName));
            cmd.Parameters.AddWithValue("@FName", sanitizeInput(FName));
            cmd.Parameters.AddWithValue("@MName", sanitizeInput(MName));
            cmd.Parameters.AddWithValue("@Initials", sanitizeInput(Initials));
            cmd.Parameters.AddWithValue("@UserID", UserID); //one would think 5 characters would be enough to deter sql injection attempts :)
            cmd.Parameters.AddWithValue("@ECompany", sanitizeInput(ECompany));
            cmd.Parameters.AddWithValue("@Department", sanitizeInput(Department));
            cmd.Parameters.AddWithValue("@WLocation", sanitizeInput(WLocation));
            cmd.Parameters.AddWithValue("@WPhone", sanitizeInput(WPhone));
            cmd.Parameters.AddWithValue("@MWLocation", sanitizeInput(MWLocation));
            cmd.Parameters.AddWithValue("@MWPhone", sanitizeInput(MWPhone));
            if (EManager == "No Manager") //if the 'No Manager' option is selected then Manager Name in database is empty
            {
                cmd.Parameters.AddWithValue("@EManager", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@EManager", sanitizeInput(EManager));
            }
            cmd.ExecuteNonQuery();
        }
    }


}