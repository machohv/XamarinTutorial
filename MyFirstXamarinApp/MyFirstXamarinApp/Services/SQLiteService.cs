using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MyFirstXamarinApp.Models;

namespace MyFirstXamarinApp.Services
{
    public class SQLiteService
    {
        private readonly SQLiteConnection conn;

        public string StatusMessage { get; set; }

        public SQLiteService(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<LocalNote>();
        }

        public void AddNewNote(LocalNote note)
        {
            try
            {
                if (string.IsNullOrEmpty(note.Title))
                    throw new Exception("Valid title required");

                //insert a new note into the Note table
                var result = conn.Insert(new LocalNote {
                    Title = note.Title,
                    Description = note.Description,
                    Date = note.Date,
                    ImagePath = note.ImagePath
                });

                StatusMessage = "Se agregó la nota correctamente";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error agregando la nota";
            }

        }

        public List<LocalNote> GetAllNotes()
        {
            //return a list of notes saved to the Note table in the database
            return conn.Table<LocalNote>().ToList();
        }
    }
}
