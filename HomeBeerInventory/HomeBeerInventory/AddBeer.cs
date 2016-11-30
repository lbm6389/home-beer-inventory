using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace HomeBeerInventory
{
    public partial class AddBeer : Form
    {
        string databaseLocation;
        SQLiteConnection databaseConnection;

        public AddBeer(string dbLoc)
        {
            InitializeComponent();
            databaseLocation = dbLoc;
            OpenConnection();
            InitializeBreweryComboBox();
        }

        private void OpenConnection()
        {
            databaseConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", databaseLocation));
            databaseConnection.Open();
        }

        private void CloseConnection()
        {
            databaseConnection.Close();
            databaseConnection.Dispose();
        }

        private void addBeerButton_Click(object sender, EventArgs e)
        {
            //Check Mandatory Fields

        }

        private void InitializeBreweryComboBox()
        {
            string breweriesQuery = "select distinct Brewery from BeerInventory";
            SQLiteCommand breweriesCommand = new SQLiteCommand(breweriesQuery, databaseConnection);
            SQLiteDataReader breweriesReader = breweriesCommand.ExecuteReader();
            if (breweriesReader.HasRows)
            {
                while (breweriesReader.Read())
                {
                    BreweryComboBox.Items.Add(breweriesReader.GetString(0));
                }
            }
            breweriesReader.Dispose();
            breweriesCommand.Dispose();
        }
    }
}
