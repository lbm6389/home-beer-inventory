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
            InitializeIndexChangeHandlers();
            //InitializeVintageComboBox();
            //InitializeBeerStyleComboBox();
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
            using (SQLiteCommand breweriesCommand = new SQLiteCommand(breweriesQuery, databaseConnection))
            {
                SQLiteDataReader breweriesReader = breweriesCommand.ExecuteReader();
                if (breweriesReader.HasRows)
                {
                    while (breweriesReader.Read())
                    {
                        breweryComboBox.Items.Add(breweriesReader.GetString(0));
                    }
                }
                breweriesReader.Dispose();
            }
        }

        private void InitializeIndexChangeHandlers()
        {
            this.breweryComboBox.SelectedIndexChanged += new EventHandler(BreweryNameChanged);
        }

        private void BreweryNameChanged(object sender, EventArgs e)
        {
            InitializeBeerNameComboBox();
        }

        private void InitializeBeerNameComboBox()
        {
            beerNameComboBox.Items.Clear();
            beerNameComboBox.Text = string.Empty;
            string beersQuery = string.Format("select distinct BeerName from BeerInventory where Brewery = '{0}'", breweryComboBox.Text);
            using (SQLiteCommand beersCommand = new SQLiteCommand(beersQuery, databaseConnection))
            {                
                SQLiteDataReader beersReader = beersCommand.ExecuteReader();
                if (beersReader.HasRows)
                {
                    while (beersReader.Read())
                    {
                        beerNameComboBox.Items.Add(beersReader.GetString(0));
                    }
                }
                beersReader.Dispose();
            }
        }

        private void InitializeVintageComboBox()
        {
            string vintageQuery = "select distinct Vintage from BeerInventory";
            using (SQLiteCommand vintageCommand = new SQLiteCommand(vintageQuery, databaseConnection))
            {
                SQLiteDataReader vintageReader = vintageCommand.ExecuteReader();
                if (vintageReader.HasRows)
                {
                    while (vintageReader.Read())
                    {
                        vintageComboBox.Items.Add(vintageReader.GetInt32(0));
                    }
                }
                vintageReader.Dispose();
            }
        }

        private void InitializeBeerStyleComboBox()
        {
            string beerStyleQuery = "select distinct BeerStyle from BeerInventory";
            using (SQLiteCommand beerStyleCommand = new SQLiteCommand(beerStyleQuery, databaseConnection))
            {
                SQLiteDataReader beerStyleReader = beerStyleCommand.ExecuteReader();
                if (beerStyleReader.HasRows)
                {
                    while (beerStyleReader.Read())
                    {
                        beerStyleComboBox.Items.Add(beerStyleReader.GetString(0));
                    }
                }
                beerStyleReader.Dispose();
            }
        }
    }
}
