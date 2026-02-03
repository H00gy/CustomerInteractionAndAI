using NUnit.Framework.Internal;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInstance : MonoBehaviour
{
    [Header("Generators")]
    public shapePicker shapeP;
    bool initialized = false;

    void Awake()
    {
        // Rebind or clone components to ensure each watch instance has unique generator components
        shapeP = GetOrCloneComponent(shapeP);
    }


    void Start() // so generate isn't called before start()
    {
        initialized = true;
        StartCoroutine(waitGen());
    }

    // Helper to clone prefab-level components or reuse instance-level ones
    T GetOrCloneComponent<T>(T existing) where T : Component
    {
        if (existing == null)
            return GetComponentInChildren<T>(true);

        // If this component belongs to a prefab (not the scene), clone it under this instance
        if (existing.gameObject.scene.rootCount == 0)
        {
            GameObject clone = Instantiate(existing.gameObject, transform);
            clone.name = existing.gameObject.name; // keep clean name
            return clone.GetComponent<T>();
        }

        return existing;
    }
    IEnumerator waitGen()
    {
        yield return null;
        shapeP = GetComponentInChildren<shapePicker>(true);
        shapeP.pickRandomShape();
    }
    /*
    public void Generate()
    {
        if (!initialized)
        {
            StartCoroutine(GenerateNextFrame());
            return;
        }
        // Always re-fetch the components within this instance, in case Awake() missed a runtime clone
        shapeP = GetComponentInChildren<shapePicker>(true);

        // Run all procedural generation steps
        shapeP.pickRandomShape();

        // Force Unity to "register" the change to the sprite,
        // even if it references the same asset as another instance.
        // This helps avoid Unity’s internal optimization that skips “unchanged” assignments.
        shapeP.sr.sprite = shapeP.sr.sprite;

    }
    IEnumerator GenerateNextFrame()
    {
        yield return null;
        Generate();
    }
    */
}
