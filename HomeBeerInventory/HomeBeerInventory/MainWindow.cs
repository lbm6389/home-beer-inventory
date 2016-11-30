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
    public partial class MainWindow : Form
    {
        private string databaseLocation;
        private SQLiteConnection databaseConnection;

        public MainWindow()
        {
            InitializeComponent();
            if(Properties.Settings.Default.databaseLocation == string.Empty)
            {
                MessageBox.Show("No database. Please create a new database or connect to an existing one from the file menu.");
            }
            else
            {
                databaseLocation = Properties.Settings.Default.databaseLocation;
                ConnectToDatabase();
            }
        }

        private void addBeerButton_Click(object sender, EventArgs e)
        {
            CloseDatabase();
            AddBeer addBeer = new AddBeer(databaseLocation);
            addBeer.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            databaseConnection.Close();
            Close();
        }

        private void createNewBeerDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog databaseLocationDialog = new SaveFileDialog();
            databaseLocationDialog.Filter = "SQLite Database File|*.sqlite";
            DialogResult databaseLocationResult = databaseLocationDialog.ShowDialog();
            if (databaseLocationResult == DialogResult.OK)
            {
                SQLiteConnection.CreateFile(string.Format("{0}", databaseLocationDialog.FileName));
                databaseLocation = databaseLocationDialog.FileName;
                Properties.Settings.Default.databaseLocation = databaseLocation;
                Properties.Settings.Default.Save();
                ConnectToDatabase();
                CreateDatabaseTable();
            }
        }

        private void ConnectToDatabase()
        {
            databaseConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", databaseLocation));
            databaseConnection.Open();
        }

        private void CloseDatabase()
        {
            databaseConnection.Close();
        }

        private void CreateDatabaseTable()
        {
            string createTableQuery = @"create table BeerInventory (
                                            PurchaseDate date,
                                            Brewery varchar(100),
                                            BeerName varchar(100),
                                            Vintage int,
                                            BeerStyle varchar(100),
                                            BeerSize varchar(100),
                                            ContainerFormat varchar(100),
                                            BottledDate date,
                                            PurchasePrice float,
                                            EnjoyByDate date,
                                            ForTrade char(1),
                                            EnjoyedDate date,
                                            TradedDate date)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, databaseConnection);
            createTableCommand.ExecuteNonQuery();
            createTableCommand.Dispose();
        }

        private void connectToExistingDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog databaseLocationDialog = new OpenFileDialog();
            databaseLocationDialog.Filter = "SQLite Database File|*.sqlite";
            DialogResult databaseLocationResult = databaseLocationDialog.ShowDialog();
            if (databaseLocationResult == DialogResult.OK)
            {
                databaseLocation = databaseLocationDialog.FileName;
                Properties.Settings.Default.databaseLocation = databaseLocation;
                Properties.Settings.Default.Save();
                ConnectToDatabase();
            }
        }
    }
}
