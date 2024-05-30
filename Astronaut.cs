using System;

namespace A1ShaneeLabaniego
{

    public enum AstronautType
    {
        Commander,
        Pilot,
        Scientist,
        Engineer
    }

    public abstract class Astronaut
    {
        // Fields and properties 
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private AstronautType _type;
        public AstronautType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Constructor for astronaut object
        public Astronaut(int id, string name, AstronautType type)
        {
            _id = id;
            _name = name;
            _type = type;
        }

        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Type: {_type}";
        }
    } // EO Austronaut class
} // EOF namespace SpaceData