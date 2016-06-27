using System;
using System.Collections.Generic;
using UnityEngine;

static class ComponentExtend {
    static public T GetComponentByInterface<T>(this Component component) where T : class {
        return component.GetComponent(typeof(T)) as T;
    }

    static public T GetComponentInParentByInterface<T>(this Component component) where T : class {
        return component.GetComponentInParent(typeof(T)) as T;
    }

    static public T GetComponentInChildrenByInterface<T>(this Component component) where T : class {
        return component.GetComponentInChildren(typeof(T)) as T;
    }
}