using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigHub.Core.Models
{
    // Gig: Konser
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        // Sisteme giriş yapan kullanıcının id değeri (string tipini kullanıyoruz)
        public string ArtistId { get; set; }

        // Konserin verilme zamanı
        public DateTime DateTime { get; set; }

        // Konserin verileceği yer
        public string Venue { get; set; }

        // Konserin türü
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        // Konsere yapılan katılımlar. Dışarıdan bir liste set edilmesin diye private set olarak ayarlandı.
        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        // Konser iptal edilirse Iscanceled = true olsun. Çünkü iptal edilen konseri sistemden silmeyeceğiz. Böyle bir yöntem kullandık.
        // Konser iptal edilirse kullanıcıya "x ismindeki x tarihindeki konser iptal edildi" şeklinde bildirim yollayacağız Modify() metodunda.
        public void Cancel()
        {
            IsCanceled = true;

            // Konserin iptaliyle ilgili bildirim yolla:
            var notification = Notification.GigCanceled(this);

            // Yukarıda oluşturulmuş olan "konser iptal edildi" bildirimini, konsere katılacak olan kullanıcılara gönder:
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        // Bir konser update edildiğinde ilgili kullanıcılara yollanacak olan bildirim işlemleri
        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    }
}