namespace Business
{
    public class LegalityOfMove
    {
        public readonly bool CantMoveBecauseOffscreen;
        public readonly bool CantMoveBecauseRoverInWay;

        public LegalityOfMove(bool cantMoveBecauseOffscreen, bool cantMoveBecauseRoverInWay)
        {
            CantMoveBecauseOffscreen = cantMoveBecauseOffscreen;
            CantMoveBecauseRoverInWay = cantMoveBecauseRoverInWay;
        }
        public bool IsLegal()
        {
            return !CantMoveBecauseOffscreen && !CantMoveBecauseRoverInWay;
        }

        public override string ToString()
        {
            if (CantMoveBecauseOffscreen) return "Cant Move Because Offscreen";
            return CantMoveBecauseRoverInWay ? "Cant Move Because Rover Is In The Way" : "Move Is Legal";
        }
    }
}