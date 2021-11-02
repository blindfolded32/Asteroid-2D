﻿using System;
using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour,IPlayerView
    {
        public Transform Transform { get; set; }
        public Rigidbody2D Rigidbody2D { get => _rigidbody2D ; private set => _rigidbody2D = value; }
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            Transform = transform;
            TryGetComponent(out _rigidbody2D);
        }
    }
}