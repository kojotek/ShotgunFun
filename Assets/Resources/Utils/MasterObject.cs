using UnityEngine;
using System.Collections;

public class MasterObject : MonoBehaviour {

    void Awake() {
        if (GetComponent<TagManager>() == null) {
            gameObject.AddComponent<TagManager>();
        }
    }

}
