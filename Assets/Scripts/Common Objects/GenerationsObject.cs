using UnityEngine;

public class GenerationsObject : CommonObject
{
    public int SetObjectID;

    public GenerationsObject FindObjectByID(int id)
    {
        GenerationsObject[] gos = FindObjectsByType<GenerationsObject>(FindObjectsSortMode.InstanceID);

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

