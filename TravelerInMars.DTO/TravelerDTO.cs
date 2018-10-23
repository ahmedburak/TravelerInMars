namespace TravelerInMars.DTO
{
    public class TravelerDTO
    {
        public CoordinateDTO Coordinate { get; set; } = new CoordinateDTO();
        public char Direction { get; set; }

        public override string ToString()
        {
            return $"{Coordinate.X} {Coordinate.Y} {Direction}";
        }

        public string FirstCoordinates { get; set; }
        public string Commands { get; set; }
    }
}
