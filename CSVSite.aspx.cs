using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CSVSite : System.Web.UI.Page
    {
        private citiesContext db = new citiesContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Update_Grid(object sender, EventArgs e)
        {
            dt.DataSource = db.Cities.ToList();
            dt.DataBind();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUploader.PostedFile.FileName);
                FileUploader.SaveAs(csvPath);
                //string CSVFile = "cities.csv";
                List<string> rowData = new List<string>();

                string csvData = File.ReadAllText(csvPath);

                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        foreach (string cell in row.Split(','))
                        {
                            rowData.Add(cell);

                        }

                        cities tempCity = new cities();

                        tempCity.LatD = rowData[0];
                        tempCity.LatM = rowData[1];
                        tempCity.LatS = rowData[2];
                        tempCity.NS = rowData[3];
                        tempCity.LonD = rowData[4];
                        tempCity.LonM = rowData[5];
                        tempCity.LonS = rowData[6];
                        tempCity.EW = rowData[7];
                        tempCity.CityName = rowData[8];
                        tempCity.cityState = rowData[9];

                        db.Cities.Add(tempCity);

                        db.SaveChanges();

                        tempCity = null;
                        rowData.Clear();
                    }


                    else
                    {
                        break;
                    }
                   
                }

            }
            catch(System.IO.IOException)
            {

                Server.Transfer("Default.aspx", true);

            }
        }
       
    }
}