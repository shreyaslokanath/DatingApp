using Microsoft.EntityFrameworkCore;
using DatingApp.Api.Models;

namespace DatingApp.Api.Data
{
    public class DataContext:DbContext
    {
        //:base(options) chains to the base constructor i.e to the DB context base constructor
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        //Set model using Dbset and the name is usually
        //the pluralised version of the model which is usually
        //the name of the table in the data base 
        public DbSet<Value> Values{get;set;}
    }
}