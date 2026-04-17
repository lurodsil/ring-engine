using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Splines;

[EditorToolContext("Spline Custom Context")]
public class SplineToolContext : EditorToolContext
{
    public override void OnActivated()
    {
        Debug.Log("Spline Context Ativado");
    }

    public override void OnWillBeDeactivated()
    {
        Debug.Log("Spline Context Desativado");
    }
}