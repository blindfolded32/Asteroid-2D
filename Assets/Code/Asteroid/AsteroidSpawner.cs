using Code.CommonClasses;
using UnityEngine;

namespace Code.Asteroid
{
    public class AsteroidSpawner
    {
        private AsteroidPool asteroidPool;
        private Health _hp;

        public AsteroidSpawner(int maxAsteroidCount, Health hp)
        {
            asteroidPool = new AsteroidPool(maxAsteroidCount, hp);

        }

       public void SpawnAsteroid(int maxAsteroidCount)
        {
            
            for (int i = 0; i < maxAsteroidCount; i++)
            {
                var asteroid = asteroidPool.GetEnemy("Asteroid");
                asteroid.transform.position = new Vector2(Random.Range(-10.0f,10.0f),Random.Range(5.0f,15.0f));
                asteroid.gameObject.SetActive(true);
            }
        }
    }
}