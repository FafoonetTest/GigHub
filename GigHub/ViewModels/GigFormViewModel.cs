using System;
using System.Collections;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable Genres { get; set; }
        public DateTime DateTime => DateTime.Parse($"{Date} {Time}"); //get simplifié en expression lambda (bodied property)
    }
}