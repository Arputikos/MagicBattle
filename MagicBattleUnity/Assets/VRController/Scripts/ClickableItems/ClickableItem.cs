using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableItem: MonoBehaviour {
    //ref
    public abstract void Click(RaycastHit hit);
    //public abstract bool HighLightMaterial(ref GameObject gameObject, float distance);
    public abstract bool HighLightMaterial(float distance);
    public abstract void UnHighLightMaterial();
}
