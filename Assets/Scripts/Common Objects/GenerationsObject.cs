using UnityEngine;

public class GenerationsObject : RingEngineObject
{
    public bool active
    {
        get
        {
            return Active;
        }
        set
        {
            if (Active != value)
            {
                if (Active == false)
                {
                    SendMessage("OnBecomeActive", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    SendMessage("OnBecomeInactive", SendMessageOptions.DontRequireReceiver);
                }
            }

            Active = value;
        }
    }

    private bool Active;

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

