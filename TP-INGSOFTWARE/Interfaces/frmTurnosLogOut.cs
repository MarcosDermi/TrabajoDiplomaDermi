using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_INGSOFTWARE
{
    public partial class frmTurnosLogOut : Form
    {
        public frmTurnosLogOut()
        {
            InitializeComponent();
        }

        //public IActionResult Calendar()
        //{
        //    var calendar = new Calendar();

        //    var icalEvent = new CalendarEvent
        //    {
        //        Summary = "Title of event",
        //        Description = "Description for event",
        //        15th of march 2021 12 o'clock.
        //        Start = new CalDateTime(2021, 3, 15, 12, 0, 0),
        //        Ends 3 hours later.
        //        End = new CalDateTime(2021, 3, 15, 15, 0, 0)
        //    };

        //    calendar.Events.Add(icalEvent);

        //    var iCalSerializer = new CalendarSerializer();
        //    string result = iCalSerializer.SerializeToString(calendar);

        //    return File(Encoding.ASCII.GetBytes(result), "text/calendar", "calendar.ics");
        //}
    }
}
