using UnityEngine;
using System.Collections;
using System;

public class AvatarExplosionReceiverUnityContext : MonoBehaviour, IExplosionReceiver {
    private GameObject _rigidbodyHoldingObject;
    private AvatarController _controller;

    void Awake() {
        _rigidbodyHoldingObject = gameObject.GetMasterObject().GetComponentInChildren<Rigidbody2D>().gameObject;
        _controller = GetComponent<AvatarController>();
    }

    public void TakeExplosionEffect(ExplosionEffectInfo info) {
        _controller.ExternalVelocityAddedSignal(info.Force);
    }


    public Vector2 AffectedObjectPosition() {
        return _rigidbodyHoldingObject.transform.position;
    }
}
