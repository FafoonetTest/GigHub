using System;

namespace GigHub.ViewModels
{
    public class GigDetailViewModel
    {
        public int Id { get; set; }

        public string Venue { get; set; }

        public DateTime DateTime { get; set; }

        public string ArtistId { get; set; }

        public string ArtistName { get; set; }

        public bool Following { get; set; }

        public bool Attending { get; set; }

    }
}