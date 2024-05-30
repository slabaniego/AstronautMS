namespace A1ShaneeLabaniego
{
    // Class for mission object 
    public class Mission
    {
        // Mission ID
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        // Mission name
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Mission launch date 
        private DateTime _launchDate;
        public DateTime LaunchDate
        {
            get { return _launchDate; }
            set { _launchDate = value; }
        }

        // Duration 
        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        // Astronauts assigned 
        private List<Astronaut> _assignedAstronauts;
        public List<Astronaut> AssignedAstronauts
        {
            get { return _assignedAstronauts; }
            set { _assignedAstronauts = value; }
        }

        // Constructor for mission object 
        public Mission(int id, string name, DateTime launchDate, int duration)
        {
            _id = id;
            _name = name;
            _launchDate = launchDate;
            _duration = duration;
            _assignedAstronauts = new List<Astronaut>();
        }

        // To String method to override 
        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Launch Date: {_launchDate.ToShortDateString()}, Duration: {_duration} days, Assigned Astronauts: {_assignedAstronauts.Count}";
        }
    }
}