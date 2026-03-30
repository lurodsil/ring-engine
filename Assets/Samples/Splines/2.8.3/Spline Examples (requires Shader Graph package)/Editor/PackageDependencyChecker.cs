using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Unity.Splines.Examples.Editor
{
    static class PackageDependencyChecker
    {
        const string k_SessionStateCheck = "SplinePackageExampleDependencyCheckPerformed";
        static ListRequest s_Request;
        static readonly List<string> s_PackageIDs = new()
        {
            "com.unity.render-pipelines.high-definition",
            "com.unity.render-pipelines.universal",
            "com.unity.shadergraph"
        };

        [InitializeOnLoadMethod]
        static void CheckDependencies()
        {
            if (SessionState.GetBool(k_SessionStateCheck, false))
                return;
            SessionState.SetBool(k_SessionStateCheck, true);
            s_Request = Client.List();
            EditorApplication.update += PollRequest;
        }

        static void PollRequest()
        {
            if (s_Request.IsCompleted)
            {
                var found = false;
                if (s_Request.Status == StatusCode.Success)
                {
                    foreach (var package in s_Request.Result)
                    {
                        if (s_PackageIDs.Contains(package.name))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                    Debug.LogError("To properly view Splines Samples please install the Shader Graph package.");

                EditorApplication.update -= PollRequest;
            }
        }
    }
}
