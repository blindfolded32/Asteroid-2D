using System;
using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class PlayerView : MonoBehaviour,IPlayerView
    {
        public Transform Transform { get; set; }

        private void Awake()
        {
            Transform = transform;
        }
    }
}