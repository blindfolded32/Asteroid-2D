using Code.Player.PlayerCode;
using UnityEngine;

namespace Code.Player.Interfaces
{
    public interface IPlayerController
    {
        public ShipController Ship { get; set; }
        Transform GetTransform();
        void RotateShip(Vector3 direction);
    }
}