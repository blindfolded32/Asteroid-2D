﻿using Code.Player.PlayerCode;
using Code.Ship.ShipCode;
using UnityEngine;

namespace Code.Player.Interfaces
{
    public interface IPlayerController
    {
        public ShipController Ship { get; set; }
        public PlayerShoot PlayerShoot { get; set; }
        Transform GetTransform();
        void RotateShip(Vector3 direction);
        
    }
}