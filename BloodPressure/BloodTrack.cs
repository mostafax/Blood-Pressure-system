using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodPressure
{
    public class BloodTrack
    {
        public BloodTrack() { this.BloodTrackID = 0;this.TrackDate = DateTime.Now; }

        public int BloodTrackID;
        public float HighBloodPressure;
        public float LowBloodPressure;
        public int PersonID;
        public DateTime TrackDate;
    }
}