using UnityEngine;

namespace Code.Bullet.Interfaces
{
    public interface IBulletFactory
    {
        Bullet Create(Vector3 spawnPosition);
    }
}