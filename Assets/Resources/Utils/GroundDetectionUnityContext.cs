using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]

public class GroundDetectionUnityContext : MonoBehaviour {
    
    private bool _isGrounded = false;
    public bool IsGrounded {
        get { return _isGrounded; }
    }

    void OnTriggerEnter2D(Collider2D collider){
        _isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        _isGrounded = false;
    }
}
