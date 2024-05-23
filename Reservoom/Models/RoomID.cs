using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class RoomID
    {
        public int RoomNumber { get; }

        public int FloorNumber { get; }
        public RoomID(int roomNumber, int floorNumber)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
        }
        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
        public override bool Equals(object? obj)
        {
            return obj is RoomID roomID &&
                FloorNumber==roomID.FloorNumber && RoomNumber==roomID.RoomNumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(RoomNumber, FloorNumber);
        }

        public static bool operator ==(RoomID left, RoomID right) 
        {
            if (left is null && right is null)
            {
                return true;
            }
            return !(left is null) && left.Equals(right);
        }
        public static bool operator !=(RoomID left, RoomID right)
        {
            
            return !(left == right);
        }
    }
}
