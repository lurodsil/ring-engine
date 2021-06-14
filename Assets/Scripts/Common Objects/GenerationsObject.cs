using UnityEngine;

public class GenerationsObject : RingEngineObject
{
    public int SetObjectID;

    public GenerationsObject FindObjectByID(int id)
    {
        GenerationsObject[] gos = FindObjectsOfType<GenerationsObject>();

        foreach (GenerationsObject go in gos)
        {
            if (go.SetObjectID == id)
            {
                return go;
            }
        }
        return null;
    }

    public virtual void OnValidate()
    {

    }
}

