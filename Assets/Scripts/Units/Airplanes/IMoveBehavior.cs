namespace Units.Airplanes
{
    public interface IMoveBehavior
    {
        void Up(float speed);
        void Down(float speed);
        void Right(float speed);
        void Left(float speed);
        void RotationCanceled();
    }
}