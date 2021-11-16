using Code.Player.PlayerCode;
using Code.Ship.ShipCode;
using UnityEngine;

namespace Code.Player.Interfaces
{
    public interface IPlayerController
    {
        ShipController Ship { get;}
        PlayerShoot PlayerShoot { get;}
        Transform GetTransform();
        void RotateShip(Vector2 direction);
        
    }
}