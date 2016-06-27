using UnityEngine;
using System.Collections.Generic;

public class TagManager : MonoBehaviour {

    [SerializeField]
    private List<InGameTag> _tags = new List<InGameTag>();
    
    public bool Contains(InGameTag tag) {
        return _tags.Contains(tag);
    }

}
