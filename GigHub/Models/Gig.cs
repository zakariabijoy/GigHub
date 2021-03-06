﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }    

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public DateTime Date { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);


            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);

            }
        }

        public void Modify(DateTime viewModelDateTime, string viewModelVenue, byte viewModelGenre)
        {
            var notification = Notification.GigUpdated(this,Date,Venue);

            Venue = viewModelVenue;
            GenreId = viewModelGenre;
            Date = viewModelDateTime;

            foreach (var attendee in Attendances.Select(a=>a.Attendee))
            {
                attendee.Notify(notification);
            }

        }
    }
}