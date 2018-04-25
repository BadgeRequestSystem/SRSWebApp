using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Methods
/// </summary>
public class Methods
{
    public Methods()
    {
        //
        // TODO: Add constructor logic here
        //
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
}