using UnityEngine;

namespace Code.Bullet.Interfaces
{
    public interface IBulletFactory
    {
        BulletCode.Bullet Create(Vector3 spawnPosition);
    }
}