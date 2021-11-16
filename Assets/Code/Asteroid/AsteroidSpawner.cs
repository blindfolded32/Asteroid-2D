using Code.CommonClasses;
using UnityEngine;

namespace Code.Asteroid
{
    public class AsteroidSpawner
    {
        private readonly AsteroidPool _asteroidPool;
       

        public AsteroidSpawner(int maxAsteroidCount, Health hp)
        {
            _asteroidPool = new AsteroidPool(maxAsteroidCount, hp);
        }
        public void SpawnAsteroid(int maxAsteroidCount)
        {
            for (int i = 0; i < maxAsteroidCount; i++)
            {
                var asteroid = _asteroidPool.GetEnemy("Asteroid");
                asteroid.transform.position = new Vector2(Random.Range(-10.0f,10.0f),Random.Range(5.0f,15.0f));
                asteroid.gameObject.SetActive(true);
            }
        }
    }
}