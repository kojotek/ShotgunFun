using UnityEngine;
using System.Collections.Generic;

public class AvatarInputMapperUnityContext : MonoBehaviour {

    private AvatarController _avatarController;

    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    private Dictionary<ProjectileType, KeyCode> ShotKeys = new Dictionary<ProjectileType, KeyCode>();

    private Vector2 _lastDirectionalKeysState = Vector2.zero;
    private Vector2 _currentDirectionalKeysState = Vector2.zero;

    private KeyCode[] _KeyCodesInitializationHelper = 
        { KeyCode.I, KeyCode.O, KeyCode.P,
        KeyCode.K, KeyCode.L, KeyCode.Semicolon,
        KeyCode.Less, KeyCode.Greater, KeyCode.Question };

    void Awake () {
        _avatarController = GetComponent<AvatarController>();

        var types = EnumUtil.GetValues<ProjectileType>();
        int iter = 0;
        foreach (var t in types)  {
            ShotKeys.Add(t, _KeyCodesInitializationHelper[iter]);
            iter++;
        }
    }

    void Update () {
	    
        if (Input.GetKeyDown(JumpKey)){
            _avatarController.JumpSignal();
        }
        
        _currentDirectionalKeysState.x = (Input.GetKey(LeftKey) ? -1.0f : 0.0f) + (Input.GetKey(RightKey) ? 1.0f : 0.0f);
        _currentDirectionalKeysState.y = (Input.GetKey(DownKey) ? -1.0f : 0.0f) + (Input.GetKey(UpKey) ? 1.0f : 0.0f);

        if (_currentDirectionalKeysState  != _lastDirectionalKeysState){
            _avatarController.DirectionalInputChangeSignal(_currentDirectionalKeysState);
        }

        _lastDirectionalKeysState = _currentDirectionalKeysState;
        

        foreach (var s in ShotKeys) {
            if (Input.GetKeyDown(s.Value)) {
                _avatarController.ShotSignal(s.Key);
            }
        }

    }
}
