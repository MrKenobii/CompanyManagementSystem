using System;
using System.Data;
using CompanyManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace CompanyManagement2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
        _logger.LogDebug("OnGet() function");


    }
    public IActionResult OnPostEnvironment()
    {
        _logger.LogDebug("OnPostEnvironment() function");
        string connStr = "server=localhost;user=root;database=company_table;port=3306;password=root";

        MySqlConnection conn = new MySqlConnection(connStr);
        List<Company> companies = new List<Company>();
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            //SQL Query to execute
            //selecting only first 10 rows for demo
            string sql = "select * from company_table.companies;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0].ToString() + " -- " + rdr[1].ToString() + " -- " + rdr[2].ToString());
                companies.Add(new Company(Int32.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), rdr[8].ToString()));
            }
            rdr.Close();
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }

        conn.Close();
        return new JsonResult(companies);
    }


   
}

