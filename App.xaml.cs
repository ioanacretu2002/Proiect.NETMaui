using System;
using ProiectMedii.Data;
using System.IO;

namespace ProiectMedii;

public partial class App : Application
{
    static ProjectDatabase database;
    public static ProjectDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
                ProjectDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                LocalApplicationData), "Project.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
