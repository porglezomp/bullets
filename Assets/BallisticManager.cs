using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallisticManager {

    static Dictionary<PhysicMaterial, BallisticMaterial> materials = new Dictionary<PhysicMaterial, BallisticMaterial>();

    static void RegisterMaterial(PhysicMaterial k, BallisticMaterial v) {
        materials.Add(k, v);
    }

    static BallisticMaterial GetMaterial(PhysicMaterial k) {
        return materials[k];
    }
}
