
namespace GigHub.Core.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }

        public ApplicationUser Attendee { get; set; }

        public int GigId { get; set; }

        public string AttendeeId { get; set; }
    }

    /*
   
    User, Attendance, Gig arasındaki ilişki aşağıdaki gibidir:

                ________                                 -------
                | User |                                 | Gig |
                --------                                 -------
                   |             |------------|             |
                   |_____________| Attendance |_____________|
                                 |------------|

     */

}