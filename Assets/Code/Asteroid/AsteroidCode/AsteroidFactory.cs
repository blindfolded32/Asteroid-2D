using Code.Asteroid.Interfaces;
using Code.CommonClasses;
using UnityEngine;

namespace Code.Asteroid.AsteroidCode
{
    public sealed class AsteroidFactory : IAsteroidFactory
    {
        public AbstractAsteroid Create(Health hp)
        {
            var asteroid = Object.Instantiate(Resources.Load<AbstractAsteroid>("Enemy/Asteroid"));
        
            asteroid.DependencyInjectHealth(hp);
        
            return asteroid;

        }
    }
}