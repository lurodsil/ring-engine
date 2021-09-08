using System.Globalization;
using System.Xml;
using UnityEditor;
using UnityEngine;


public class GenerationsObjectReader : EditorWindow
{
    TextAsset xmlToRead;
    Object[] resources;
    GameObject temp;

    [MenuItem("Window/Ring Engine Tools/Generations Object Reader")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GenerationsObjectReader), false, "XML Reader");
    }

    void OnEnable()
    {
        resources = Resources.LoadAll<GameObject>("");
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        xmlToRead = EditorGUILayout.ObjectField("XML File", xmlToRead, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Read Springs"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "Spring": ReadSpring(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Dash Panels"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "DashPanel": ReadDashPanel(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Wide Springs"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "WideSpring": ReadWideSpring(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Rings"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "Ring": ReadRing(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Dash Rings"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "DashRing": ReadDashRing(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Jump Boards"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "JumpBoard": ReadJumpBoard(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Up Reels"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "UpReel": ReadUpReel(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read ModeChangers"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                case "ChangeMode_3Dto2D": ReadChangeMode_3Dto2D(node1); break;
                                //case "ChangeMode_3DtoDash": ReadChangeMode_3DtoDash(node1); break;
                                //case "ChangeMode_3DtoForward": ReadChangeMode_3DtoForward(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
        if (GUILayout.Button("Read Cameras"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                //case "LayerDefine":

                                //    foreach (XmlNode node2 in node1.ChildNodes)
                                //    {

                                //    }
                                //    break;

                                //Cameras
                                case "CameraCollisionBoard": ReadCameraCollisionBoard(node1); break;
                                case "CameraOffsetBoard": ReadCameraOffsetBoard(node1); break;
                                case "CameraOffsetBox": ReadCameraOffsetBox(node1); break;
                                case "CameraOffsetReset": ReadCameraOffsetReset(node1); break;
                                case "ChangeVolumeCamera": ReadChangeVolumeCamera(node1); break;
                                case "ObjCameraObjectLook": ReadObjCameraObjectLook(node1); break;
                                case "ObjCameraPan": ReadObjCameraPan(node1); break;
                                case "ObjCameraParallel": ReadObjCameraParallel(node1); break;
                                case "ObjCameraPathTarget": ReadObjCameraPathParallel(node1); break;
                                case "ObjCameraPoint": ReadObjCameraPoint(node1); break;
                                case "ObjCameraTube": ReadObjCameraTube(node1); break;
                                case "ObjCameraVertical": ReadObjCameraVertical(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read Collisions"))
        {
            temp = new GameObject();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlToRead.text);

            foreach (XmlNode node0 in xmlDocument.ChildNodes)
            {
                switch (node0.Name)
                {
                    case "SetObject":
                        foreach (XmlNode node1 in node0.ChildNodes)
                        {
                            switch (node1.Name)
                            {
                                //case "LayerDefine":

                                //    foreach (XmlNode node2 in node1.ChildNodes)
                                //    {

                                //    }
                                //    break;

        
                                case "AutorunFinishCollision": ReadAutorunFinishCollision(node1); break;
                                case "AutorunFinishSimpleCollision": ReadAutorunFinishSimpleCollision(node1); break;
                                case "AutorunStartCollision": ReadAutorunStartCollision(node1); break;
                                case "AutorunStartSimpleCollision": ReadAutorunStartSimpleCollision(node1); break;
                                case "ChangePathCollision": ReadChangePathCollision(node1); break;
                                case "ChangeSkyCollision": ReadChangeSkyCollision(node1); break;
                                case "ChangeSkyProxy": ReadChangeSkyProxy(node1); break;
                                case "ChangeToneMapVolume": ReadChangeToneMapVolume(node1); break;
                                case "EventCollision": ReadEventCollision(node1); break;
                                case "EventPathHolding": ReadEventPathHolding(node1); break;
                                case "EventPathHoldingFinish": ReadEventPathHoldingFinish(node1); break;
                                case "EventPathHoldingStart": ReadEventPathHoldingStart(node1); break;
                                case "FallDeadCollision": ReadFallDeadCollision(node1); break;
                                case "GravityChangeCollision": ReadGravityChangeCollision(node1); break;
                                case "JumpCollision": ReadJumpCollision(node1); break;
                                case "LaunchSpinCollision": ReadLaunchSpinCollision(node1); break;
                                case "NavigationCollision": ReadNavigationCollision(node1); break;
                                case "SlidingCollision": ReadSlidingCollision(node1); break;
                                case "SpeedDownCollision": ReadSpeedDownCollision(node1); break;
                                case "StumbleCollision": ReadStumbleCollision(node1); break;
                                case "WallWalkEnableCollision": ReadWallWalkEnableCollision(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

    }

    private void ReadSpring(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Spring>())
        {
            temp.AddComponent<Spring>();
        }

        Spring component = temp.GetComponent<Spring>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Springs"))
        {
            new GameObject("Springs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "AimDirection":
                //    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "BaseRotation":
                //    component.BaseRotation = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.firstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsBreak":
                //    component.IsBreak = bool.Parse(node.InnerText);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                //case "IsChangeCameraWhenPathChange":
                //    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    //break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                //case "IsLongBase":
                //    component.IsLongBase = bool.Parse(node.InnerText);
                //    break;
                //case "IsPathChange":
                //    component.IsPathChange = bool.Parse(node.InnerText);
                //    break;
                //case "IsSideSet":
                //    component.IsSideSet = bool.Parse(node.InnerText);
                //    break;
                //case "IsStartVelocityConstant":
                //    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                //    break;
                //case "IsWallWalk":
                //    component.IsWallWalk = bool.Parse(node.InnerText);
                //    break;
                //case "IsWithBase":
                //    component.IsWithBase = bool.Parse(node.InnerText);
                //    break;
                //case "IsYawUpdate":
                //    component.IsYawUpdate = bool.Parse(node.InnerText);
                //    break;
                case "KeepVelocityDistance":
                    component.keepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "MotionType":
                //    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "m_IsConstantFrame":
                //    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                //    break;
                //case "m_IsConstantPosition":
                //    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                //    break;
                //case "m_IsMonkeyHunting":
                //    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                //    break;
                case "m_IsStopBoost":
                    component.isBoostCancel = bool.Parse(node.InnerText);
                    break;
                //case "m_IsTo3D":
                //    component.m_IsTo3D = bool.Parse(node.InnerText);
                //    break;
                //case "m_MonkeyTarget":
                //    component.m_MonkeyTarget = ReadPosition(node);
                //    break;
                //case "IsInvisible":
                //    component.IsInvisible = bool.Parse(node.InnerText);
                //    break;
                //case "HasBase":
                //    component.HasBase = bool.Parse(node.InnerText);
                //    break;
                //case "m_IsMonkeyHuntingLowAngle":
                //    component.m_IsMonkeyHuntingLowAngle = bool.Parse(node.InnerText);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "Spring", "Springs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Spring", "Springs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Spring");
        }
    }
    private void ReadUpReel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<UpReel>())
        {
            temp.AddComponent<UpReel>();
        }

        UpReel component = temp.GetComponent<UpReel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("UpReels"))
        {
            new GameObject("UpReels");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "ImpulseVelocity":
                    component.impulseVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsWaitUp":
                    component.active = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.outOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "UpSpeedMax":
                    component.upSpeedMax = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "UpReel", "UpReels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "UpReel", "UpReels", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate UpReel");
        }
    }
    private void ReadJumpBoard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<JumpBoard>())
        {
            temp.AddComponent<JumpBoard>();
        }

        JumpBoard component = temp.GetComponent<JumpBoard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("JumpBoards"))
        {
            new GameObject("JumpBoards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AngleType":
                    component.AngleType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseSpeedOnBoost":
                    component.ImpulseSpeedOnBoost = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseSpeedOnNormal":
                    component.ImpulseSpeedOnNormal = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsTo3D":
                    component.IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "LookBack":
                    component.LookBack = bool.Parse(node.InnerText);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RigidBody":
                    component.RigidBody = bool.Parse(node.InnerText);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "JumpBoard", "JumpBoards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "JumpBoard", "JumpBoards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate JumpBoard");
        }
    }

    private void ReadDashPanel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<DashPanel>())
        {
            temp.AddComponent<DashPanel>();
        }

        DashPanel component = temp.GetComponent<DashPanel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("DashPanels"))
        {
            new GameObject("DashPanels");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenChangePath":
                    component.IsChangeCameraWhenChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsChangePath":
                    component.IsChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsConstantStartVelocity":
                    component.IsConstantStartVelocity = bool.Parse(node.InnerText);
                    break;
                case "IsInvisible":
                    component.IsInvisible = bool.Parse(node.InnerText);
                    break;
                case "IsTo3D":
                    component.IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "IsUseDelayCamera":
                    component.IsUseDelayCamera = bool.Parse(node.InnerText);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Speed":
                    component.Speed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SpeedMax":
                    component.SpeedMax = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SpeedMin":
                    component.SpeedMin = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "DashPanel", "DashPanels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "DashPanel", "DashPanels", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate DashPanel");
        }
    }
    private void ReadDashRing(XmlNode xmlNode)
    {
        if (!temp.GetComponent<DashRing>())
        {
            temp.AddComponent<DashRing>();
        }

        DashRing component = temp.GetComponent<DashRing>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("DashRings"))
        {
            new GameObject("DashRings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenChangePath":
                    component.IsChangeCameraWhenChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsChangePath":
                    component.IsChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsHeadToVelocity":
                    component.IsHeadToVelocity = bool.Parse(node.InnerText);
                    break;
                case "IsTo3D":
                    component.IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "DashRing", "DashRings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "DashRing", "DashRings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate DashRing");
        }
    }

    private void ReadPointMarker(XmlNode xmlNode)
    {
        if (!temp.GetComponent<PointMarker>())
        {
            temp.AddComponent<PointMarker>();
        }

        PointMarker component = temp.GetComponent<PointMarker>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("PointMarkers"))
        {
            new GameObject("PointMarkers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DimensionType":
                    component.DimensionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Height":
                    component.Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "PointMarkerID":
                    component.PointMarkerID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Width":
                    component.Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StageType":
                    component.StageType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "PointMarker", "PointMarkers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "PointMarker", "PointMarkers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate PointMarker");
        }
    }
    private void ReadPulley(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Pulley>())
        {
            temp.AddComponent<Pulley>();
        }

        Pulley component = temp.GetComponent<Pulley>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Pulleys"))
        {
            new GameObject("Pulleys");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "EndPosition":
                //    component.EndPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsJumpCancel":
                    component.isJumpCancel = bool.Parse(node.InnerText);
                    break;
                //case "IsPoleAttackInvSide":
                //    component.IsPoleAttackInvSide = bool.Parse(node.InnerText);
                //    break;
                //case "Length":
                //    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "MinInitVel":
                //    component.MinInitVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "PathID":
                //    component.PathID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "StartPosition":
                //    component.StartPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "Pulley", "Pulleys");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Pulley", "Pulleys", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Pulley");
        }
    }
    private void ReadRainbowRing(XmlNode xmlNode)
    {
        if (!temp.GetComponent<RainbowRing>())
        {
            temp.AddComponent<RainbowRing>();
        }

        RainbowRing component = temp.GetComponent<RainbowRing>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("RainbowRings"))
        {
            new GameObject("RainbowRings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenChangePath":
                    component.IsChangeCameraWhenChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsChangePath":
                    component.IsChangePath = bool.Parse(node.InnerText);
                    break;
                case "IsHeadToVelocity":
                    component.IsHeadToVelocity = bool.Parse(node.InnerText);
                    break;
                case "IsTo3D":
                    component.IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "RainbowRing", "RainbowRings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "RainbowRing", "RainbowRings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate RainbowRing");
        }
    }
    private void ReadRedMedal(XmlNode xmlNode)
    {
        if (!temp.GetComponent<RedMedal>())
        {
            temp.AddComponent<RedMedal>();
        }

        RedMedal component = temp.GetComponent<RedMedal>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("RedMedals"))
        {
            new GameObject("RedMedals");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "MedalID":
                    component.MedalID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "RedMedal", "RedMedals");
                    break;
            }
        }
        try
        {
            CreateObject(component, "RedMedal", "RedMedals", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate RedMedal");
        }
    }
    private void ReadRing(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Ring>())
        {
            temp.AddComponent<Ring>();
        }

        Ring component = temp.GetComponent<Ring>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Rings"))
        {
            new GameObject("Rings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "InitDisp":
                //    component.InitDisp = bool.Parse(node.InnerText);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsLightSpeedDashTarget":
                    component.IsLightSpeedDashTarget = bool.Parse(node.InnerText);
                    break;
                //case "IsReset":
                //    component.IsReset = bool.Parse(node.InnerText);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "ResetTime":
                //    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "TreasureSearchHideType":
                //    component.TreasureSearchHideType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "Ring", "Rings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Ring", "Rings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Ring");
        }
    }
    private void ReadWallJumpBlock(XmlNode xmlNode)
    {
        if (!temp.GetComponent<WallJumpBlock>())
        {
            temp.AddComponent<WallJumpBlock>();
        }

        WallJumpBlock component = temp.GetComponent<WallJumpBlock>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("WallJumpBlocks"))
        {
            new GameObject("WallJumpBlocks");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SizeX":
                    component.SizeX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SizeY":
                    component.SizeY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SizeZ":
                    component.SizeZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "WallJumpBlock", "WallJumpBlocks");
                    break;
            }
        }
        try
        {
            CreateObject(component, "WallJumpBlock", "WallJumpBlocks", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate WallJumpBlock");
        }
    }
    private void ReadWideSpring(XmlNode xmlNode)
    {
        if (!temp.GetComponent<WideSpring>())
        {
            temp.AddComponent<WideSpring>();
        }

        WideSpring component = temp.GetComponent<WideSpring>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("WideSprings"))
        {
            new GameObject("WideSprings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstSpeed":
                    component.firstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsBreak":
                //    component.IsBreak = bool.Parse(node.InnerText);
                //    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                //case "IsStartVelocityConstant":
                //    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                //    break;
                case "KeepVelocityDistance":
                    component.keepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "m_IsConstantPosition":
                //    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                //    break;
                //case "IsStartPositionConstant":
                //    component.IsStartPositionConstant = bool.Parse(node.InnerText);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "WideSpring", "WideSprings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "WideSpring", "WideSprings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate WideSpring");
        }
    }


    //Mode Changers
    private void ReadChangeMode_3Dto2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeMode_3Dto2D>())
        {
            temp.AddComponent<ChangeMode_3Dto2D>();
        }

        ChangeMode_3Dto2D component = temp.GetComponent<ChangeMode_3Dto2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeMode_3Dto2Ds"))
        {
            new GameObject("ChangeMode_3Dto2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetDirection":
                    component.TargetDirection = ReadPosition(node);
                    break;
                case "m_IsAutoChange2DPath":
                    component.m_IsAutoChange2DPath = bool.Parse(node.InnerText);
                    break;
                case "m_IsChangeCamera":
                    component.m_IsChangeCamera = bool.Parse(node.InnerText);
                    break;
                case "m_IsEnableFromBack":
                    component.m_IsEnableFromBack = bool.Parse(node.InnerText);
                    break;
                case "m_IsEnableFromFront":
                    component.m_IsEnableFromFront = bool.Parse(node.InnerText);
                    break;
                case "m_IsPadCorrect":
                    component.m_IsPadCorrect = bool.Parse(node.InnerText);
                    break;
                case "m_PathEaseTime":
                    component.m_PathEaseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangeMode_3Dto2D", "ChangeMode_3Dto2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeMode_3Dto2D", "ChangeMode_3Dto2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeMode_3Dto2D");
        }
    }

    //Cameras
    private void ReadCameraCollisionBoard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<CameraCollisionBoard>())
        {
            temp.AddComponent<CameraCollisionBoard>();
        }

        CameraCollisionBoard component = temp.GetComponent<CameraCollisionBoard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("CameraCollisionBoards"))
        {
            new GameObject("CameraCollisionBoards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ACameraID":
                    component.ACameraID = int.Parse(node.InnerText);
                    break;
                case "ACameraPriority":
                    component.ACameraPriority = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ALinkObjID":
                    component.ALinkObjID = int.Parse(node.InnerText);
                    break;
                case "ALinkSide":
                    component.ALinkSide = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AObjType":
                    component.AObjType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BCameraID":
                    component.BCameraID = int.Parse(node.InnerText);
                    break;
                case "BCameraPriority":
                    component.BCameraPriority = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BLinkObjID":
                    component.BLinkObjID = int.Parse(node.InnerText);
                    break;
                case "BLinkSide":
                    component.BLinkSide = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BObjType":
                    component.BObjType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTime_AtoB":
                    component.EaseTime_AtoB = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTime_BtoA":
                    component.EaseTime_BtoA = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ValidFlag":
                    component.m_ValidFlag = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "CameraCollisionBoard", "CameraCollisionBoards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "CameraCollisionBoard", "CameraCollisionBoards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate CameraCollisionBoard");
        }
    }
    private void ReadCameraOffsetBoard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<CameraOffsetBoard>())
        {
            temp.AddComponent<CameraOffsetBoard>();
        }

        CameraOffsetBoard component = temp.GetComponent<CameraOffsetBoard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("CameraOffsetBoards"))
        {
            new GameObject("CameraOffsetBoards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTimeIn":
                    component.EaseTimeIn = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTimeOut":
                    component.EaseTimeOut = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ExecTime":
                    component.ExecTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatio":
                    component.FollowRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatioCam":
                    component.FollowRatioCam = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatioTrg":
                    component.FollowRatioTrg = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowXYZ":
                    component.FollowXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsResetOld":
                    component.IsResetOld = bool.Parse(node.InnerText);
                    break;
                case "OffsetPosX":
                    component.OffsetPosX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetPosY":
                    component.OffsetPosY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetPosZ":
                    component.OffsetPosZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgX":
                    component.OffsetTrgX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgY":
                    component.OffsetTrgY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgZ":
                    component.OffsetTrgZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "CameraOffsetBoard", "CameraOffsetBoards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "CameraOffsetBoard", "CameraOffsetBoards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate CameraOffsetBoard");
        }
    }
    private void ReadCameraOffsetBox(XmlNode xmlNode)
    {
        if (!temp.GetComponent<CameraOffsetBox>())
        {
            temp.AddComponent<CameraOffsetBox>();
        }

        CameraOffsetBox component = temp.GetComponent<CameraOffsetBox>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("CameraOffsetBoxs"))
        {
            new GameObject("CameraOffsetBoxs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTimeIn":
                    component.EaseTimeIn = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTimeOut":
                    component.EaseTimeOut = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatio":
                    component.FollowRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatioCam":
                    component.FollowRatioCam = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowRatioTrg":
                    component.FollowRatioTrg = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowXYZ":
                    component.FollowXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "OffsetPosX":
                    component.OffsetPosX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetPosY":
                    component.OffsetPosY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetPosZ":
                    component.OffsetPosZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgX":
                    component.OffsetTrgX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgY":
                    component.OffsetTrgY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetTrgZ":
                    component.OffsetTrgZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "CameraOffsetBox", "CameraOffsetBoxs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "CameraOffsetBox", "CameraOffsetBoxs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate CameraOffsetBox");
        }
    }
    private void ReadCameraOffsetReset(XmlNode xmlNode)
    {
        if (!temp.GetComponent<CameraOffsetReset>())
        {
            temp.AddComponent<CameraOffsetReset>();
        }

        CameraOffsetReset component = temp.GetComponent<CameraOffsetReset>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("CameraOffsetResets"))
        {
            new GameObject("CameraOffsetResets");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTimeIn":
                    component.EaseTimeIn = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "CameraOffsetReset", "CameraOffsetResets");
                    break;
            }
        }
        try
        {
            CreateObject(component, "CameraOffsetReset", "CameraOffsetResets", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate CameraOffsetReset");
        }
    }
    private void ReadChangeVolumeCamera(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeVolumeCamera>())
        {
            temp.AddComponent<ChangeVolumeCamera>();
        }

        ChangeVolumeCamera component = temp.GetComponent<ChangeVolumeCamera>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeVolumeCameras"))
        {
            new GameObject("ChangeVolumeCameras");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsEnableCollision":
                    component.IsEnableCollision = bool.Parse(node.InnerText);
                    break;
                case "LineType":
                    component.LineType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Priority":
                    component.Priority = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                //case "PositionList":
                //    component.PositionList = undefined.Parse(node.InnerText);
                //    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangeVolumeCamera", "ChangeVolumeCameras");
                    break;
            }
        }
        try
        {
            Vector3 scale = new Vector3(component.Collision_Width, component.Collision_Height, component.Collision_Length);
            CreateObject(component, "ChangeVolumeCamera", "ChangeVolumeCameras", position, rotation, scale);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Can't Instantiate ChangeVolumeCamera - Cause: " + ex);
        }
    }
    private void ReadObjCameraObjectLook(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraObjectLook>())
        {
            temp.AddComponent<ObjCameraObjectLook>();
        }

        ObjCameraObjectLook component = temp.GetComponent<ObjCameraObjectLook>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraObjectLooks"))
        {
            new GameObject("ObjCameraObjectLooks");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetObject":
                    component.TargetObject = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_WorldX":
                    component.TargetOffset_WorldX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_WorldY":
                    component.TargetOffset_WorldY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_WorldZ":
                    component.TargetOffset_WorldZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraObjectLook", "ObjCameraObjectLooks");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraObjectLook", "ObjCameraObjectLooks", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraObjectLook");
        }
    }
    private void ReadObjCameraPan(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraPan>())
        {
            temp.AddComponent<ObjCameraPan>();
        }

        ObjCameraPan component = temp.GetComponent<ObjCameraPan>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraPans"))
        {
            new GameObject("ObjCameraPans");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "CameraPositionMode":
                    component.CameraPositionMode = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FaceType":
                    component.FaceType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "OffsetPitch":
                    component.OffsetPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetYaw":
                    component.OffsetYaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraPan", "ObjCameraPans");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraPan", "ObjCameraPans", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraPan");
        }
    }
    private void ReadObjCameraParallel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraParallel>())
        {
            temp.AddComponent<ObjCameraParallel>();
        }

        ObjCameraParallel component = temp.GetComponent<ObjCameraParallel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraParallels"))
        {
            new GameObject("ObjCameraParallels");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "OffsetPitch":
                    component.OffsetPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetYaw":
                    component.OffsetYaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Pitch":
                    component.Pitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Yaw":
                    component.Yaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);//Quaternion.Euler(component.Pitch, component.Yaw, component.ZRot);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraParallel", "ObjCameraParallels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraParallel", "ObjCameraParallels", position, rotation, Vector3.one, new Vector3(component.Pitch, component.Yaw, component.ZRot));
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraParallel");
        }
    }
    private void ReadObjCameraPathParallel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraPathParallel>())
        {
            temp.AddComponent<ObjCameraPathParallel>();
        }

        ObjCameraPathParallel component = temp.GetComponent<ObjCameraPathParallel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraPathParallels"))
        {
            new GameObject("ObjCameraPathParallels");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "LerpRatio":
                    component.LerpRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetPitch":
                    component.OffsetPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffsetYaw":
                    component.OffsetYaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Pitch":
                    component.Pitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Yaw":
                    component.Yaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraPathParallel", "ObjCameraPathParallels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraPathParallel", "ObjCameraPathParallels", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraPathParallel");
        }
    }
    private void ReadObjCameraPoint(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraPoint>())
        {
            temp.AddComponent<ObjCameraPoint>();
        }

        ObjCameraPoint component = temp.GetComponent<ObjCameraPoint>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraPoints"))
        {
            new GameObject("ObjCameraPoints");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraPoint", "ObjCameraPoints");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraPoint", "ObjCameraPoints", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraPoint");
        }
    }
    private void ReadObjCameraTube(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraTube>())
        {
            temp.AddComponent<ObjCameraTube>();
        }

        ObjCameraTube component = temp.GetComponent<ObjCameraTube>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraTubes"))
        {
            new GameObject("ObjCameraTubes");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EyeOffsetY":
                    component.EyeOffsetY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EyeOffsetZ":
                    component.EyeOffsetZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EyeRatio":
                    component.EyeRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "PathID":
                    component.PathID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrgOffsetY":
                    component.TrgOffsetY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrgOffsetZ":
                    component.TrgOffsetZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrgRatio":
                    component.TrgRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraTube", "ObjCameraTubes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraTube", "ObjCameraTubes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraTube");
        }
    }
    private void ReadObjCameraVertical(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraVertical>())
        {
            temp.AddComponent<ObjCameraVertical>();
        }

        ObjCameraVertical component = temp.GetComponent<ObjCameraVertical>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraVerticals"))
        {
            new GameObject("ObjCameraVerticals");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Enter":
                    component.Ease_Time_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time_Leave":
                    component.Ease_Time_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Vel":
                    component.TargetOffset_Vel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetPositionFix":
                    component.TargetPositionFix = ReadPosition(node);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VelOffsetXYZ":
                    component.VelOffsetXYZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZRot":
                    component.ZRot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraVertical", "ObjCameraVerticals");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraVertical", "ObjCameraVerticals", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraVertical");
        }
    }

    //Collision
    private void ReadAutorunFinishCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AutorunFinishCollision>())
        {
            temp.AddComponent<AutorunFinishCollision>();
        }

        AutorunFinishCollision component = temp.GetComponent<AutorunFinishCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AutorunFinishCollisions"))
        {
            new GameObject("AutorunFinishCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "AutorunFinishCollision", "AutorunFinishCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AutorunFinishCollision", "AutorunFinishCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AutorunFinishCollision");
        }
    }
    private void ReadAutorunFinishSimpleCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AutorunFinishSimpleCollision>())
        {
            temp.AddComponent<AutorunFinishSimpleCollision>();
        }

        AutorunFinishSimpleCollision component = temp.GetComponent<AutorunFinishSimpleCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AutorunFinishSimpleCollisions"))
        {
            new GameObject("AutorunFinishSimpleCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "AutorunFinishSimpleCollision", "AutorunFinishSimpleCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AutorunFinishSimpleCollision", "AutorunFinishSimpleCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AutorunFinishSimpleCollision");
        }
    }
    private void ReadAutorunStartCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AutorunStartCollision>())
        {
            temp.AddComponent<AutorunStartCollision>();
        }

        AutorunStartCollision component = temp.GetComponent<AutorunStartCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AutorunStartCollisions"))
        {
            new GameObject("AutorunStartCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTime":
                    component.EaseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsForceToGround":
                    component.IsForceToGround = bool.Parse(node.InnerText);
                    break;
                case "KeepTime":
                    component.KeepTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "Speed":
                    component.Speed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ToPathEaseTime":
                    component.ToPathEaseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "AutorunStartCollision", "AutorunStartCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AutorunStartCollision", "AutorunStartCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AutorunStartCollision");
        }
    }
    private void ReadAutorunStartSimpleCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AutorunStartSimpleCollision>())
        {
            temp.AddComponent<AutorunStartSimpleCollision>();
        }

        AutorunStartSimpleCollision component = temp.GetComponent<AutorunStartSimpleCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AutorunStartSimpleCollisions"))
        {
            new GameObject("AutorunStartSimpleCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "Speed":
                    component.Speed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "AutorunStartSimpleCollision", "AutorunStartSimpleCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AutorunStartSimpleCollision", "AutorunStartSimpleCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AutorunStartSimpleCollision");
        }
    }
    private void ReadChangePathCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangePathCollision>())
        {
            temp.AddComponent<ChangePathCollision>();
        }

        ChangePathCollision component = temp.GetComponent<ChangePathCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangePathCollisions"))
        {
            new GameObject("ChangePathCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "Collision_Height":
                //    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Collision_Length":
                //    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Collision_Width":
                //    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "DefaultStatus":
                //    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Shape_Type":
                //    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "TargetDirection":
                //    component.TargetDirection = ReadPosition(node);
                //    break;
                //case "Type":
                //    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                //    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangePathCollision", "ChangePathCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangePathCollision", "ChangePathCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangePathCollision");
        }
    }
    private void ReadChangeSkyCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeSkyCollision>())
        {
            temp.AddComponent<ChangeSkyCollision>();
        }

        ChangeSkyCollision component = temp.GetComponent<ChangeSkyCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeSkyCollisions"))
        {
            new GameObject("ChangeSkyCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowUpRatioYBack":
                    component.FollowUpRatioYBack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FollowUpRatioYFront":
                    component.FollowUpRatioYFront = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntensityBack":
                    component.IntensityBack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntensityFront":
                    component.IntensityFront = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "ModelTailNumberBack":
                    component.ModelTailNumberBack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ModelTailNumberFront":
                    component.ModelTailNumberFront = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangeSkyCollision", "ChangeSkyCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeSkyCollision", "ChangeSkyCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeSkyCollision");
        }
    }
    private void ReadChangeSkyProxy(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeSkyProxy>())
        {
            temp.AddComponent<ChangeSkyProxy>();
        }

        ChangeSkyProxy component = temp.GetComponent<ChangeSkyProxy>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeSkyProxys"))
        {
            new GameObject("ChangeSkyProxys");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangeSkyProxy", "ChangeSkyProxys");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeSkyProxy", "ChangeSkyProxys", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeSkyProxy");
        }
    }
    private void ReadChangeToneMapVolume(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeToneMapVolume>())
        {
            temp.AddComponent<ChangeToneMapVolume>();
        }

        ChangeToneMapVolume component = temp.GetComponent<ChangeToneMapVolume>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeToneMapVolumes"))
        {
            new GameObject("ChangeToneMapVolumes");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTime":
                    component.EaseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ID":
                    component.ID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "LuminanceHigh":
                    component.LuminanceHigh = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LuminanceLow":
                    component.LuminanceLow = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ToneMapMiddleGray":
                    component.ToneMapMiddleGray = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ToneMapSimpleScale":
                    component.ToneMapSimpleScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ChangeToneMapVolume", "ChangeToneMapVolumes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeToneMapVolume", "ChangeToneMapVolumes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeToneMapVolume");
        }
    }
    private void ReadEventCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EventCollision>())
        {
            temp.AddComponent<EventCollision>();
        }

        EventCollision component = temp.GetComponent<EventCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EventCollisions"))
        {
            new GameObject("EventCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Durability":
                    component.Durability = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Event0":
                    component.Event0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Event1":
                    component.Event1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Event2":
                    component.Event2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Event3":
                    component.Event3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "TargetList0":
                //    component.TargetList0 = id_list.Parse(node.InnerText);
                //    break;
                //case "TargetList1":
                //    component.TargetList1 = id_list.Parse(node.InnerText);
                //    break;
                //case "TargetList2":
                //    component.TargetList2 = id_list.Parse(node.InnerText);
                //    break;
                //case "TargetList3":
                //    component.TargetList3 = int.Parse(node.InnerText);
                //    break;
                case "Timer0":
                    component.Timer0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Timer1":
                    component.Timer1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Timer2":
                    component.Timer2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Timer3":
                    component.Timer3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Trigger":
                    component.Trigger = int.Parse(node.InnerText);
                    break;
                case "TriggerType":
                    component.TriggerType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "EventCollision", "EventCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EventCollision", "EventCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EventCollision");
        }
    }
    private void ReadEventPathHolding(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EventPathHolding>())
        {
            temp.AddComponent<EventPathHolding>();
        }

        EventPathHolding component = temp.GetComponent<EventPathHolding>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EventPathHoldings"))
        {
            new GameObject("EventPathHoldings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "EventPathHolding", "EventPathHoldings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EventPathHolding", "EventPathHoldings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EventPathHolding");
        }
    }
    private void ReadEventPathHoldingFinish(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EventPathHoldingFinish>())
        {
            temp.AddComponent<EventPathHoldingFinish>();
        }

        EventPathHoldingFinish component = temp.GetComponent<EventPathHoldingFinish>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EventPathHoldingFinishs"))
        {
            new GameObject("EventPathHoldingFinishs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "EventPathHoldingFinish", "EventPathHoldingFinishs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EventPathHoldingFinish", "EventPathHoldingFinishs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EventPathHoldingFinish");
        }
    }
    private void ReadEventPathHoldingStart(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EventPathHoldingStart>())
        {
            temp.AddComponent<EventPathHoldingStart>();
        }

        EventPathHoldingStart component = temp.GetComponent<EventPathHoldingStart>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EventPathHoldingStarts"))
        {
            new GameObject("EventPathHoldingStarts");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "EventPathHoldingStart", "EventPathHoldingStarts");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EventPathHoldingStart", "EventPathHoldingStarts", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EventPathHoldingStart");
        }
    }
    private void ReadFallDeadCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<FallDeadCollision>())
        {
            temp.AddComponent<FallDeadCollision>();
        }

        FallDeadCollision component = temp.GetComponent<FallDeadCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("FallDeadCollisions"))
        {
            new GameObject("FallDeadCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "FallDeadCollision", "FallDeadCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "FallDeadCollision", "FallDeadCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate FallDeadCollision");
        }
    }
    private void ReadGravityChangeCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GravityChangeCollision>())
        {
            temp.AddComponent<GravityChangeCollision>();
        }

        GravityChangeCollision component = temp.GetComponent<GravityChangeCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GravityChangeCollisions"))
        {
            new GameObject("GravityChangeCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EnteringLimitTime":
                    component.EnteringLimitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "GravityChangeCollision", "GravityChangeCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GravityChangeCollision", "GravityChangeCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GravityChangeCollision");
        }
    }
    private void ReadJumpCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<JumpCollision>())
        {
            temp.AddComponent<JumpCollision>();
        }

        JumpCollision component = temp.GetComponent<JumpCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("JumpCollisions"))
        {
            new GameObject("JumpCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseSpeedOnBoost":
                    component.ImpulseSpeedOnBoost = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseSpeedOnNormal":
                    component.ImpulseSpeedOnNormal = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Pitch":
                    component.Pitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SpeedMin":
                    component.SpeedMin = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TerrainIgnoreTime":
                    component.TerrainIgnoreTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ClassicSpinThreshold":
                    component.m_ClassicSpinThreshold = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsGroundOnly":
                    component.m_IsGroundOnly = bool.Parse(node.InnerText);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "JumpCollision", "JumpCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "JumpCollision", "JumpCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate JumpCollision");
        }
    }
    private void ReadLaunchSpinCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<LaunchSpinCollision>())
        {
            temp.AddComponent<LaunchSpinCollision>();
        }

        LaunchSpinCollision component = temp.GetComponent<LaunchSpinCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("LaunchSpinCollisions"))
        {
            new GameObject("LaunchSpinCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Depth":
                    component.Depth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Height":
                    component.Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IgnoreInputSecond":
                    component.IgnoreInputSecond = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "LaunchType":
                    component.LaunchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Velocity":
                    component.Velocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Width":
                    component.Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "LaunchSpinCollision", "LaunchSpinCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "LaunchSpinCollision", "LaunchSpinCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate LaunchSpinCollision");
        }
    }
    private void ReadNavigationCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<NavigationCollision>())
        {
            temp.AddComponent<NavigationCollision>();
        }

        NavigationCollision component = temp.GetComponent<NavigationCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("NavigationCollisions"))
        {
            new GameObject("NavigationCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "CancelAngle":
                    component.CancelAngle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CollisionType":
                    component.CollisionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DelayTime":
                    component.DelayTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DelayType":
                    component.DelayType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DirectionType":
                    component.DirectionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InputAngle":
                    component.InputAngle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "NavigationType":
                    component.NavigationType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffSpeed":
                    component.OffSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnSpeed":
                    component.OnSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutputTime":
                    component.OutputTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "QSType":
                    component.QSType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SlidingPosition":
                    component.SlidingPosition = ReadPosition(node);
                    break;
                case "TargetObject_RelationSetObject":
                    component.TargetObject_RelationSetObject = int.Parse(node.InnerText);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "NavigationCollision", "NavigationCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "NavigationCollision", "NavigationCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate NavigationCollision");
        }
    }
    private void ReadSlidingCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SlidingCollision>())
        {
            temp.AddComponent<SlidingCollision>();
        }

        SlidingCollision component = temp.GetComponent<SlidingCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SlidingCollisions"))
        {
            new GameObject("SlidingCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Depth":
                    component.Depth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Height":
                    component.Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Velocity":
                    component.Velocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Width":
                    component.Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "SlidingCollision", "SlidingCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SlidingCollision", "SlidingCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SlidingCollision");
        }
    }
    private void ReadSpeedDownCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SpeedDownCollision>())
        {
            temp.AddComponent<SpeedDownCollision>();
        }

        SpeedDownCollision component = temp.GetComponent<SpeedDownCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SpeedDownCollisions"))
        {
            new GameObject("SpeedDownCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Speed":
                    component.Speed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "SpeedDownCollision", "SpeedDownCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SpeedDownCollision", "SpeedDownCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SpeedDownCollision");
        }
    }
    private void ReadStumbleCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<StumbleCollision>())
        {
            temp.AddComponent<StumbleCollision>();
        }

        StumbleCollision component = temp.GetComponent<StumbleCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("StumbleCollisions"))
        {
            new GameObject("StumbleCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "Collision_Height":
                //    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Collision_Length":
                //    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "Collision_Width":
                //    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "DefaultStatus":
                //    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                //case "LaunchVelocity":
                //    component.LaunchVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "NoControlTime":
                    component.outOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Shape_Type":
                //    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                //case "SetObjectID":
                //    component.SetObjectID = int.Parse(node.InnerText);
                    //break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "StumbleCollision", "StumbleCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "StumbleCollision", "StumbleCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate StumbleCollision");
        }
    }
    private void ReadWallWalkEnableCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<WallWalkEnableCollision>())
        {
            temp.AddComponent<WallWalkEnableCollision>();
        }

        WallWalkEnableCollision component = temp.GetComponent<WallWalkEnableCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("WallWalkEnableCollisions"))
        {
            new GameObject("WallWalkEnableCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Length":
                    component.Collision_Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsEnableWallWalk":
                    component.m_IsEnableWallWalk = bool.Parse(node.InnerText);
                    break;
                case "SetObjectID":
                    component.SetObjectID = int.Parse(node.InnerText);
                    break;
                case "Position":
                    position = ReadPosition(node);
                    break;
                case "Rotation":
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "WallWalkEnableCollision", "WallWalkEnableCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "WallWalkEnableCollision", "WallWalkEnableCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate WallWalkEnableCollision");
        }
    }



    private Vector3 ReadPosition(XmlNode xmlNode)
    {
        Vector3 position = new Vector3();

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "x":
                    position.x = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat) * -1;
                    break;
                case "y":
                    position.y = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "z":
                    position.z = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
            }
        }

        return position;
    }
    private Quaternion ReadRotation(XmlNode xmlNode)
    {
        Quaternion rotation = new Quaternion();

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "x":
                    rotation.x = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "y":
                    rotation.y = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat) * -1;
                    break;
                case "z":
                    rotation.z = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat) * -1;
                    break;
                case "w":
                    rotation.w = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
            }
        }

        return rotation;
    }

    private void CreateObject(Component component, string resourceName, string parentName, Vector3 position, Quaternion rotation)
    {
        CreateObject(component, resourceName, parentName, position, rotation, Vector3.one);
    }
    private void CreateObject(Component component, string resourceName, string parentName, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        CreateObject(component, resourceName, parentName, position, rotation, scale, Vector3.zero);
    }
    private void CreateObject(Component component, string resourceName, string parentName, Vector3 position, Quaternion rotation, Vector3 scale, Vector3 euler)
    {
        GameObject go = PrefabUtility.InstantiatePrefab(FindInResources(resourceName)) as GameObject;
        go.transform.position = position;
        if(euler == Vector3.zero)
        {
            go.transform.rotation = rotation;
        }
        else
        {
            go.transform.rotation = Quaternion.Euler(rotation.eulerAngles.x + euler.x, rotation.eulerAngles.y - euler.y + 180, rotation.eulerAngles.z + euler.z);
        }
        go.transform.localScale = scale;
        go.transform.parent = GameObject.Find(parentName).transform;
        CopyComponent(component, go);
        go.GetComponent<GenerationsObject>().OnValidate();
    }
    private void ReadMultiSetParam(Component component, XmlNode xmlNode, string resourceName, string parentName)
    {
        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        foreach (XmlNode node0 in xmlNode.ChildNodes)
        {
            switch (node0.Name)
            {
                case "Element":
                    foreach (XmlNode node1 in node0.ChildNodes)
                    {
                        switch (node1.Name)
                        {
                            case "Position":
                                position = ReadPosition(node1);
                                break;
                            case "Rotation":
                                rotation = ReadRotation(node1);
                                break;
                        }
                    }
                    try
                    {
                        CreateObject(component, resourceName, parentName, position, rotation);
                    }
                    catch
                    {
                        Debug.Log("Can't Instantiate " + resourceName);
                    }

                    break;
            }
        }
    }
    private Object FindInResources(string name)
    {
        Object resource = new Object();

        foreach (Object o in resources)
        {
            if (o.name == name)
            {
                resource = o;
            }
        }
        return resource;
    }
    private void CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();

        if (!destination.GetComponent(type))
        {
            destination.AddComponent(type);
        }

        Component copy = destination.GetComponent(type);

        System.Reflection.FieldInfo[] fields = type.GetFields();

        foreach (System.Reflection.FieldInfo field in fields)
        {
            if (field.GetValue(original) != null)
            {
                field.SetValue(copy, field.GetValue(original));
            }
        }
    }
    private void FixCameras()
    {
        ChangeVolumeCamera[] changeVolumeCameras = GameObject.Find("ChangeVolumeCameras").GetComponentsInChildren<ChangeVolumeCamera>();
        ObjCameraParallel[] objCameraParalell = GameObject.Find("ObjCameraParallels").GetComponentsInChildren<ObjCameraParallel>();
        ObjCameraPan[] objCameraPan = GameObject.Find("ObjCameraPans").GetComponentsInChildren<ObjCameraPan>();
        ObjCameraPoint[] objCameraPoint = GameObject.Find("ObjCameraPoints").GetComponentsInChildren<ObjCameraPoint>();
        ObjCameraPathParallel[] objCameraPathParallel = GameObject.Find("ObjCameraPathParallels").GetComponentsInChildren<ObjCameraPathParallel>();

        foreach (ObjCameraParallel paralell in objCameraParalell)
        {

            foreach (ChangeVolumeCamera volumeCam in changeVolumeCameras)
            {
                if (paralell.SetObjectID == volumeCam.Target)
                {
                    paralell.transform.parent = volumeCam.transform;
                }
            }

            paralell.transform.eulerAngles = new Vector3(paralell.Pitch, -paralell.Yaw + 180, 0);
        }

        foreach (ObjCameraPan pan in objCameraPan)
        {
            foreach (ChangeVolumeCamera volumeCam in changeVolumeCameras)
            {
                if (pan.SetObjectID == volumeCam.Target)
                {
                    pan.transform.parent = volumeCam.transform;
                }
            }
        }

        foreach (ObjCameraPoint point in objCameraPoint)
        {
            foreach (ChangeVolumeCamera volumeCam in changeVolumeCameras)
            {
                if (point.SetObjectID == volumeCam.Target)
                {
                    point.transform.parent = volumeCam.transform;
                }
            }
        }

        foreach (ObjCameraPathParallel path in objCameraPathParallel)
        {
            foreach (ChangeVolumeCamera volumeCam in changeVolumeCameras)
            {
                if (path.SetObjectID == volumeCam.Target)
                {
                    path.transform.parent = volumeCam.transform;
                }
            }
        }

    }
}
