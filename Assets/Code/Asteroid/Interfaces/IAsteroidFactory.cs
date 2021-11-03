using Code.CommonClasses;

namespace Code.Asteroid.Interfaces
{
    public interface IAsteroidFactory
    {
        AbstractAsteroid Create(Health hp);

    }
}