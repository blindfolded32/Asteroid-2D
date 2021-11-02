using UnityEngine;

namespace Code.Player.Interfaces
{
    public interface IPlayerView
    {
        Transform Transform { get; set; }
        Rigidbody2D Rigidbody2D { get; set; }
    }
}