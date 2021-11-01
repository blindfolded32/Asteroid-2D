using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using System.Collections;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {
        private Camera _camera;
        private IPlayerController _playerController;
        private Event _event;

        private InputManager _inputManager;
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _playerController = new PlayerController(new PlayerModel(), FindObjectOfType<PlayerView>());
            _inputManager = new InputManager(_playerController,_camera);
        }

        // Update is called once per frame
        void OnGUI()
        {
            _event = Event.current;
         //   Debug.Log($"now is {_event}");
            if (_event.isKey)
            {
                _inputManager.OnKeyPressed(_event.keyCode);
            }
            
        
        }
    }
}
