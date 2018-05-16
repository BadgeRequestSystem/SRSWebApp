using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;


/// <summary>
/// Summary description for Methods
/// </summary>
public class Methods : System.Web.UI.Page
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

    public void DeleteCookie(string CookieName)
    {
        HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
    }

    public string sliceEmployee(string Employee, string CASE) //given an employee, return either the First or Last name
    {
        int firstIndex, secondIndex = -1;
        string lName, fName = string.Empty;

        if (CASE == "First Name")
        {
            firstIndex = Employee.IndexOf(' ');
            fName = Employee.Substring(0, firstIndex);
            return fName;
        }
        if (CASE == "Last Name")
        {
            secondIndex = Employee.LastIndexOf(' ');
            lName = Employee.Substring(secondIndex + 1);
            return lName;
        }
        else
            return "";

    }


    /*SQL RELATED METHODS BELOW!*/

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
            Connection.Close();
        }
    }

    public void HRForm_Read(HttpCookie bCookie, string UID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Employees WHERE UserID=@UID", Connection);
            cmd.Parameters.AddWithValue("@UID", UID);
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bCookie["Last Name"] = reader["Last Name"].ToString().Trim();
                    bCookie["First Name"] = reader["First Name"].ToString().Trim();
                    bCookie["Middle Name"] = reader["Middle Name"].ToString().Trim();
                    bCookie["Initials"] = reader["Initials"].ToString().Trim();
                    bCookie["UserID"] = reader["UserID"].ToString().Trim();
                    bCookie["Employee Company"] = reader["Employee Company"].ToString().Trim();
                    bCookie["Department"] = reader["Department"].ToString().Trim();
                    bCookie["Work Location"] = reader["Work Location"].ToString().Trim();
                    bCookie["Work Phone Number"] = reader["Work Phone Number"].ToString().Trim();
                    bCookie["Manager Name"] = reader["Manager Name"].ToString().Trim();
                    bCookie["Manager Work Location"] = reader["Manager Work Location"].ToString().Trim();
                    bCookie["Manager Work Phone Number"] = reader["Manager Work Phone Number"].ToString().Trim();

                }
                Connection.Close();
            }
        }
    }

    public void DeleteFromEmployeesByUID(string UID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Employees WHERE [UserID] = @uid", Connection);
            cmd.Parameters.AddWithValue("@uid", UID);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }

    public void Request_Read(HttpCookie bCookie,string REQID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Requests WHERE RequestID=@RequestID", Connection);
            cmd.Parameters.AddWithValue("@RequestID", REQID);
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bCookie["Employee"] = reader["Employee"].ToString();
                    bCookie["Reason"] = reader["ReasonForRequest"].ToString();
                    bCookie["GET"] = reader["GETDate"].ToString();
                    bCookie["SSN"] = reader["SSN"].ToString();
                    bCookie["DOB"] = reader["DateOfBirth"].ToString();
                    bCookie["TOB"] = reader["TypeOfBadge"].ToString();
                    bCookie["Proximity"] = reader["ProximityCard"].ToString();
                    bCookie["Emergency"] = reader["EmergencyAccess"].ToString();
                    bCookie["Accounts"] = reader["ContinueAccounts"].ToString();
                    bCookie["Notes"] = reader["Notes"].ToString();
                }
                Connection.Close();
            }

            SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Employees WHERE [First Name]=@fName AND [Last Name]=@lName", Connection);
            cmd2.Parameters.AddWithValue("@fName", sliceEmployee(bCookie["Employee"],"First Name"));
            cmd2.Parameters.AddWithValue("@lName", sliceEmployee(bCookie["Employee"], "Last Name"));



            Connection.Open();
            using (SqlDataReader reader2 = cmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    bCookie["Initials"] = reader2["Initials"].ToString();
                    bCookie["UserID"] = reader2["UserID"].ToString();
                    bCookie["Company"] = reader2["Employee Company"].ToString();
                    bCookie["Department"] = reader2["Department"].ToString();
                    bCookie["Location"] = reader2["Work Location"].ToString();
                    bCookie["Phone"] = reader2["Work Phone Number"].ToString();
                    bCookie["Manager"] = reader2["Manager Name"].ToString();
                    bCookie["ManagerLocation"] = reader2["Manager Work Location"].ToString();
                    bCookie["ManagerPhone"] = reader2["Manager Work Phone Number"].ToString();
                }
                Connection.Close();
            }
        }
    }

    public void Pending_Request_Read(HttpCookie bCookie, string REQID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Requests WHERE RequestID=@RequestID", Connection);
            cmd.Parameters.AddWithValue("@RequestID", REQID);
            bCookie["RequestID"] = REQID;
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bCookie["Employee"] = reader["Employee"].ToString();
                    bCookie["Reason"] = reader["ReasonForRequest"].ToString();
                    bCookie["GET"] = reader["GETDate"].ToString();
                    bCookie["SSN"] = reader["SSN"].ToString();
                    bCookie["DOB"] = reader["DateOfBirth"].ToString();
                    bCookie["TOB"] = reader["TypeOfBadge"].ToString();
                    bCookie["Proximity"] = reader["ProximityCard"].ToString();
                    bCookie["Emergency"] = reader["EmergencyAccess"].ToString();
                    bCookie["Accounts"] = reader["ContinueAccounts"].ToString();
                    bCookie["Notes"] = reader["Notes"].ToString();
                    bCookie["Editable"] = reader["Editable"].ToString(); //'Is this request editable' flag
                }
                Connection.Close();
            }

            SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Employees WHERE [First Name]=@fName AND [Last Name]=@lName", Connection);
            cmd2.Parameters.AddWithValue("@fName", sliceEmployee(bCookie["Employee"], "First Name"));
            cmd2.Parameters.AddWithValue("@lName", sliceEmployee(bCookie["Employee"], "Last Name"));



            Connection.Open();
            using (SqlDataReader reader2 = cmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    bCookie["Initials"] = reader2["Initials"].ToString();
                    bCookie["UserID"] = reader2["UserID"].ToString();
                    bCookie["Company"] = reader2["Employee Company"].ToString();
                    bCookie["Department"] = reader2["Department"].ToString();
                    bCookie["Location"] = reader2["Work Location"].ToString();
                    bCookie["Phone"] = reader2["Work Phone Number"].ToString();
                    bCookie["Manager"] = reader2["Manager Name"].ToString();
                    bCookie["ManagerLocation"] = reader2["Manager Work Location"].ToString();
                    bCookie["ManagerPhone"] = reader2["Manager Work Phone Number"].ToString();
                }
                Connection.Close();
            }
        }
    }
}