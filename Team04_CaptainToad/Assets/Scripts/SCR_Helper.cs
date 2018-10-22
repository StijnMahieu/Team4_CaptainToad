using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SCR_Helper
{
        public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
        {
            Transform t = parent.transform;
            foreach (Transform tr in t)
            {
                if (tr.tag == tag)
                {
                    return tr.GetComponent<T>();
                }
            }
            return null;
        }

    public static GameObject FindParentWithTag(GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }

}
