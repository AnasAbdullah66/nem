using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Ninth_Mid_Evid.Models
{
    public class Client
    {
        public Client()
        {
            this.BookingEntrys = new List<BookingEntry>();
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public bool MaritalStatus { get; set; }
        public string Picture { get; set; }

        //
        public virtual ICollection<BookingEntry> BookingEntrys { get; set; }


    }

    public class Spot
    {
        public Spot()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int SpotId { get; set; }
        public string SpotName { get; set; }

        //
        public virtual ICollection<BookingEntry> BookingEntries { get; set; }

    }

    public class BookingEntry
    {
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Spot")]
        public int SpotId { get; set; }

        //
        public virtual Client Client { get; set; }
        public virtual Spot Spot { get; set; }
    }
    public class TourBdContext : DbContext
    {
        public TourBdContext(DbContextOptions<TourBdContext>options):base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<BookingEntry> BookingEntries { get; set; }
    }
}
