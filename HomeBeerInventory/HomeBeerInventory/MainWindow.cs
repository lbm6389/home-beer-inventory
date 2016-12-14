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
using Microsoft.VisualBasic.FileIO;

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
            if (databaseConnection.State == ConnectionState.Open)
                CloseDatabase();
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
            if (databaseConnection.State == ConnectionState.Open)
                CloseDatabase();
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

        private void createFromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (databaseConnection.State == ConnectionState.Open)
                CloseDatabase();
            OpenFileDialog csvLocationDialog = new OpenFileDialog();
            csvLocationDialog.Filter = "Comma Separated Values|*.csv";
            DialogResult csvLocationResult = csvLocationDialog.ShowDialog();
            if(csvLocationResult == DialogResult.OK)
            {
                createNewBeerDatabaseToolStripMenuItem_Click(sender, e);
                TextFieldParser parser = new TextFieldParser(csvLocationDialog.FileName);
                parser.SetDelimiters(",");
                parser.ReadFields();
                using (SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source = {0};Version=3;", databaseLocation)))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        using (var trans = conn.BeginTransaction())
                        {
                            while (!parser.EndOfData)
                            {
                                string[] currentRow = parser.ReadFields();
                                string insertQry = string.Format("insert into BeerInventory select '{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}'", currentRow[0], currentRow[1], currentRow[2], currentRow[3], currentRow[4], currentRow[5], currentRow[6], currentRow[7], currentRow[8], currentRow[9], currentRow[10], currentRow[11], currentRow[12]);
                                MessageBox.Show(currentRow[3].ToString());
                                cmd.CommandText = insertQry;
                                cmd.ExecuteNonQuery();
                            }
                            trans.Commit();
                        }
                    }
                }

            }
        }
    }
}
