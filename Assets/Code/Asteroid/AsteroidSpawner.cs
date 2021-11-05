using UnityEngine;

namespace Code.Asteroid
{
    public class AsteroidSpawner
    {
        private AsteroidPool asteroidPool;

        public AsteroidSpawner(int maxAsteroidCount)
        {
            asteroidPool = new AsteroidPool(maxAsteroidCount);
        }

       public void SpawnAsteroid(int maxAsteroidCount)
        {
            
            for (int i = 0; i < maxAsteroidCount; i++)
            {
                var asteroid = asteroidPool.GetEnemy("Asteroid");
                asteroid.transform.position = new Vector2(Random.Range(-10.0f,10.0f),Random.Range(10.0f,15.0f));
                asteroid.gameObject.SetActive(true);
            }
        }
    }
}