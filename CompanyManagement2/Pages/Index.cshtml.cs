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
        Console.WriteLine("Inside OnGet() function");
        _logger.LogDebug("OnGet() function");


    }
    public IActionResult OnPostRetrieve()
    {
        Console.WriteLine("OnPostEnvironment() function");
        string connStr = "server=localhost;user=root;database=company_table;port=3306;password=root";

        MySqlConnection conn = new MySqlConnection(connStr);
        List<Company> companies = new List<Company>();
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            //SQL Query to execute
            //selecting only first 10 rows for demo
            string sql = "SELECT * FROM company_table.companies;";
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

    public IActionResult OnPostAdd([FromBody] Company c)
    {
        Console.WriteLine("OnPostAdd() function");
        string connStr = "server=localhost;user=root;database=company_table;port=3306;password=root";
        Console.WriteLine("Company: " + c);
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            
            string sql = "INSERT INTO company_table.companies (ID, CompanyName, Address, State, City, Phone, Fax, Website, Zipcode)" +
                           " VALUES (" + c.Id.ToString() + ", '" + c.CompanyName + "', '" + c.Address + "','" + c.State + "','" + c.City + "','" +
                           c.Phone + "','" + c.Fax + "','" + c.Website + "','"+c.Zipcode+"');";
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MySqlCommand MyCommand2 = new MySqlCommand(sql, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }

        conn.Close();
        return this.OnPostRetrieve();

    }

    public IActionResult OnPostUpdate([FromBody] Company c)
    {
        Console.WriteLine("OnPostUpdate() function");
        string connStr = "server=localhost;user=root;database=company_table;port=3306;password=root";
        Console.WriteLine("Company: " + c);
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            string sql = "UPDATE company_table.companies" +
                         " SET CompanyName='"+c.CompanyName+"',Address='"+c.Address+
                         "',State='"+c.State+"',City='"+c.City+"',Phone='"+c.Phone+"',Fax='"+c.Fax+"',Website='"+c.Website+"',Zipcode='"+c.Zipcode+"' WHERE ID="+c.Id+";";
            Console.WriteLine("Query: " + sql);
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MySqlCommand MyCommand2 = new MySqlCommand(sql, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }

        conn.Close();
        return this.OnPostRetrieve();
    }

    public IActionResult OnPostDelete([FromBody] Company c)
    {
        Console.WriteLine("OnPostUpdate() function");
        string connStr = "server=localhost;user=root;database=company_table;port=3306;password=root";
        Console.WriteLine("Company: " + c);
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            string sql = "DELETE FROM  company_table.companies WHERE ID="+c.Id+";";
            Console.WriteLine("Query: " + sql);
            MySqlConnection MyConn2 = new MySqlConnection(connStr);
            MySqlCommand MyCommand2 = new MySqlCommand(sql, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }

        conn.Close();
        return this.OnPostRetrieve();
    }
}

