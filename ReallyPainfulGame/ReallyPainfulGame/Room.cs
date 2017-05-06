using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public enum Direction { North, South, West, East };
    class Room
    {
        private string _name;
        private string _description;
        private Enemy _monster;
        private Dictionary<Direction, Room> _rooms;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public Enemy Monster
        {
            get
            {
                return _monster;
            }

            set
            {
                _monster = value;
            }
        }
        internal Dictionary<Direction, Room> Rooms
        {
            get
            {
                return _rooms;
            }

            set
            {
                _rooms = value;
            }
        }

        public Room(string name, string description, Enemy monster)
        {
            Name = name;
            Rooms = new Dictionary<Direction, Room>();
            _monster = monster;
            Rooms.Add(Direction.North, null);
            Rooms.Add(Direction.South, null);
            Rooms.Add(Direction.West, null);
            Rooms.Add(Direction.East, null);
        }

        public void linkRoom(ref Room room, Direction direction)
        {
            Rooms[direction] = room;

            Direction opposite = Direction.North;
            switch (direction)
            {
                case Direction.North:
                    opposite = Direction.South;
                    break;
                case Direction.South:
                    opposite = Direction.North;
                    break;
                case Direction.West:
                    opposite = Direction.East;
                    break;
                case Direction.East:
                    opposite = Direction.West;
                    break;
            }

            room.Rooms[opposite] = this;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
