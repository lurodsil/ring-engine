using System.Globalization;
using System.Xml;
using UnityEditor;
using UnityEngine;


public class XMLReader : EditorWindow
{
    TextAsset xmlToRead;
    Object[] resources;
    GameObject temp;

    [MenuItem("Ring Engine/XML Reader")]
    public static void ShowWindow()
    {
        GetWindow(typeof(XMLReader), false, "XML Reader");
    }

    void OnEnable()
    {
        resources = Resources.LoadAll<GameObject>("");
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        xmlToRead = EditorGUILayout.ObjectField("XML File", xmlToRead, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Read"))
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

                                ////Cameras
                                //case "CameraCollisionBoard": ReadCameraCollisionBoard(node1); break;
                                //case "CameraOffsetBoard": ReadCameraOffsetBoard(node1); break;
                                //case "CameraOffsetBox": ReadCameraOffsetBox(node1); break;
                                //case "CameraOffsetReset": ReadCameraOffsetReset(node1); break;
                                //case "ChangeVolumeCamera": ReadChangeVolumeCamera(node1); break;
                                //case "ObjCameraObjectLook": ReadObjCameraObjectLook(node1); break;
                                //case "ObjCameraPan": ReadObjCameraPan(node1); break;
                                //case "ObjCameraParallel": ReadObjCameraParallel(node1); break;
                                //case "ObjCameraPoint": ReadObjCameraPoint(node1); break;
                                //case "ObjCameraTube": ReadObjCameraTube(node1); break;
                                //case "ObjCameraVertical": ReadObjCameraVertical(node1); break;

                                //Collision
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

                                //Common
                                case "AdlibTrickJump": ReadAdlibTrickJump(node1); break;
                                case "AirSpring": ReadAirSpring(node1); break;
                                case "Bomb": ReadBomb(node1); break;
                                case "ClassicItemBox": ReadClassicItemBox(node1); break;
                                case "DashPanel": ReadDashPanel(node1); break;
                                case "DashRing": ReadDashRing(node1); break;
                                case "DirectionalThorn": ReadDirectionalThorn(node1); break;
                                case "EchoCollision": ReadEchoCollision(node1); break;
                                case "FallSignalFV": ReadFallSignalFV(node1); break;
                                case "FallSignalSV": ReadFallSignalSV(node1); break;
                                case "FixedFloor": ReadFixedFloor(node1); break;
                                case "Flame": ReadFlame(node1); break;
                                case "GeneralFloor": ReadGeneralFloor(node1); break;
                                case "GeneralFloorCustom": ReadGeneralFloorCustom(node1); break;
                                case "GoalRing": ReadGoalRing(node1); break;
                                case "GoalSignboard": ReadGoalSignboard(node1); break;
                                case "GrindDashPanel": ReadGrindDashPanel(node1); break;
                                case "GrindThorn": ReadGrindThorn(node1); break;
                                case "IronPole2D": ReadIronPole2D(node1); break;
                                case "Item": ReadItem(node1); break;
                                case "JumpBoard": ReadJumpBoard(node1); break;
                                case "JumpBoard3D": ReadJumpBoard3D(node1); break;
                                case "JumpPole": ReadJumpPole(node1); break;
                                case "MovingThorn": ReadMovingThorn(node1); break;
                                case "ObjectPhysics": ReadObjectPhysics(node1); break;
                                case "Omochao": ReadOmochao(node1); break;
                                case "OnewayFloor": ReadOnewayFloor(node1); break;
                                case "PointMarker": ReadPointMarker(node1); break;
                                case "Pulley": ReadPulley(node1); break;
                                case "RainbowRing": ReadRainbowRing(node1); break;
                                case "RedMedal": ReadRedMedal(node1); break;
                                case "Ring": ReadRing(node1); break;
                                case "SelectCanon": ReadSelectCanon(node1); break;
                                case "SetParticle": ReadSetParticle(node1); break;
                                case "SetParticleVolume": ReadSetParticleVolume(node1); break;
                                case "SetRigidBody": ReadSetRigidBody(node1); break;
                                case "SonicSpawn": ReadSonicSpawn(node1); break;
                                case "Spring": ReadSpring(node1); break;
                                case "SpringFake": ReadSpringFake(node1); break;
                                case "SuperRing": ReadSuperRing(node1); break;
                                case "UpReel": ReadUpReel(node1); break;
                                case "WallJumpBlock": ReadWallJumpBlock(node1); break;
                                case "WideSpring": ReadWideSpring(node1); break;

                                //Enemies
                                case "EnemyAeroCannon": ReadEnemyAeroCannon(node1); break;
                                case "EnemyBatabata2D": ReadEnemyBatabata2D(node1); break;
                                case "EnemyBeeton2D": ReadEnemyBeeton2D(node1); break;
                                case "EnemyBeeton3D": ReadEnemyBeeton3D(node1); break;
                                case "EnemyEChaserManager": ReadEnemyEChaserManager(node1); break;
                                case "EnemyEFighter3D": ReadEnemyEFighter3D(node1); break;
                                case "EnemyEFighterSword3D": ReadEnemyEFighterSword3D(node1); break;
                                case "EnemyELauncher3D": ReadEnemyELauncher3D(node1); break;
                                case "EnemyGanigani2D": ReadEnemyGanigani2D(node1); break;
                                case "EnemyGanigani3D": ReadEnemyGanigani3D(node1); break;
                                case "EnemyMotora2D": ReadEnemyMotora2D(node1); break;
                                case "EnemyMotora3D": ReadEnemyMotora3D(node1); break;
                                case "EnemyPawnPla2D": ReadEnemyPawnPla2D(node1); break;
                                case "EnemySpanner": ReadEnemySpanner(node1); break;
                                case "EnemySpinner": ReadEnemySpinner(node1); break;
                                case "EnemySpinner2D": ReadEnemySpinner2D(node1); break;

                                //Mode Changers
                                //case "ChangeMode_3Dto2D": ReadChangeMode_3Dto2D(node1); break;
                                //case "ChangeMode_3DtoDash": ReadChangeMode_3DtoDash(node1); break;
                                //case "ChangeMode_3DtoForward": ReadChangeMode_3DtoForward(node1); break;

                                //Sounds
                                case "SoundLine": ReadSoundLine(node1); break;
                                case "SoundPoint": ReadSoundPoint(node1); break;

                                //Unassigned
                                case "Cannon": ReadCannon(node1); break;
                                case "ChangeLightScatteringVolume": ReadChangeLightScatteringVolume(node1); break;
                                case "ClassicDashPanel": ReadClassicDashPanel(node1); break;
                                case "ClassicJumpBoard": ReadClassicJumpBoard(node1); break;
                                case "EnemyPawn2D": ReadEnemyPawn2D(node1); break;
                                case "EnemyPawnGun2D": ReadEnemyPawnGun2D(node1); break;
                                case "EnemyPawnGun3D": ReadEnemyPawnGun3D(node1); break;
                                case "EnemyPawnLance2D": ReadEnemyPawnLance2D(node1); break;
                                case "EnemySpanner2D": ReadEnemySpanner2D(node1); break;
                                case "Fan": ReadFan(node1); break;
                                case "ObjCameraFix": ReadObjCameraFix(node1); break;
                                case "SpringClassic": ReadSpringClassic(node1); break;
                                case "SpringClassicYellow": ReadSpringClassicYellow(node1); break;
                                case "Switch": ReadSwitch(node1); break;
                                case "Test": ReadTest(node1); break;
                                case "ThornBall": ReadThornBall(node1); break;

                                    //Unleashed
                                    //case "BeachFallFloor": ReadBeachFallFloor(node1); break;
                                    //case "BeachFlagA": ReadBeachFlagA(node1); break;
                                    //case "BeachFlagB": ReadBeachFlagB(node1); break;
                                    //case "BeachFlagC": ReadBeachFlagC(node1); break;
                                    //case "BeachFlagD": ReadBeachFlagD(node1); break;
                                    //case "BeachFloorA": ReadBeachFloorA(node1); break;
                                    //case "BeachFloorB": ReadBeachFloorB(node1); break;
                                    //case "BeachFloorC": ReadBeachFloorC(node1); break;
                                    //case "BeachMoveFloorA": ReadBeachMoveFloorA(node1); break;
                                    //case "BeachMoveFloorB": ReadBeachMoveFloorB(node1); break;
                                    //case "Beach_BreakBridge": ReadBeach_BreakBridge(node1); break;
                                    //case "Beach_Buoy": ReadBeach_Buoy(node1); break;
                                    //case "Beach_Door": ReadBeach_Door(node1); break;
                                    //case "Beach_FallPillar": ReadBeach_FallPillar(node1); break;
                                    //case "Beach_FlashFlood": ReadBeach_FlashFlood(node1); break;
                                    //case "Beach_Guillotine": ReadBeach_Guillotine(node1); break;
                                    //case "Beach_MotionDoor": ReadBeach_MotionDoor(node1); break;
                                    //case "Beach_PressThorn": ReadBeach_PressThorn(node1); break;
                                    //case "Beach_PressThornHalf": ReadBeach_PressThornHalf(node1); break;
                                    //case "Beach_ThornBar": ReadBeach_ThornBar(node1); break;
                                    //case "Beach_ThornPillar": ReadBeach_ThornPillar(node1); break;
                                    //case "Beach_UpFloor": ReadBeach_UpFloor(node1); break;
                                    //case "Beach_WaterColumn": ReadBeach_WaterColumn(node1); break;
                                    //case "Bobsleigh": ReadBobsleigh(node1); break;
                                    //case "BobsleighEndCollision": ReadBobsleighEndCollision(node1); break;
                                    //case "ChangeCamera2D_Begin": ReadChangeCamera2D_Begin(node1); break;
                                    //case "eAirCannonGold": ReadeAirCannonGold(node1); break;
                                    //case "eAirCannonNormal": ReadeAirCannonNormal(node1); break;
                                    //case "eAirChaser": ReadeAirChaser(node1); break;
                                    //case "eAirChaserCollisinForceAttack": ReadeAirChaserCollisinForceAttack(node1); break;
                                    //case "eAirChaserReloadChaserCollision": ReadeAirChaserReloadChaserCollision(node1); break;
                                    //case "eBigChaser": ReadeBigChaser(node1); break;
                                    //case "eBigChaserBomb": ReadeBigChaserBomb(node1); break;
                                    //case "eBlizzard": ReadeBlizzard(node1); break;
                                    //case "eFighter": ReadeFighter(node1); break;
                                    //case "eFighterGun": ReadeFighterGun(node1); break;
                                    //case "eFighterShield": ReadeFighterShield(node1); break;
                                    //case "eFighterSword": ReadeFighterSword(node1); break;
                                    //case "eFlame": ReadeFlame(node1); break;
                                    //case "eMoleCannon": ReadeMoleCannon(node1); break;
                                    //case "EndDynamicPreloadingCollision": ReadEndDynamicPreloadingCollision(node1); break;
                                    //case "eShackleFView": ReadeShackleFView(node1); break;
                                    //case "eSpanner": ReadeSpanner(node1); break;
                                    //case "eSpinner": ReadeSpinner(node1); break;
                                    //case "eThunderBall": ReadeThunderBall(node1); break;
                                    //case "EventSetter": ReadEventSetter(node1); break;
                                    //case "Grouper": ReadGrouper(node1); break;
                                    //case "Icicle": ReadIcicle(node1); break;
                                    //case "ItemBox": ReadItemBox(node1); break;
                                    //case "ItemIllustBook": ReadItemIllustBook(node1); break;
                                    //case "ItemRecordA": ReadItemRecordA(node1); break;
                                    //case "ItemVideoTape": ReadItemVideoTape(node1); break;
                                    //case "JumpSelector": ReadJumpSelector(node1); break;
                                    //case "MedalMoon": ReadMedalMoon(node1); break;
                                    //case "MedalSun": ReadMedalSun(node1); break;
                                    //case "ObjBaseSound": ReadObjBaseSound(node1); break;
                                    //case "ObjCamera2D": ReadObjCamera2D(node1); break;
                                    //case "ObjCameraBlend": ReadObjCameraBlend(node1); break;
                                    //case "ObjCameraNormal": ReadObjCameraNormal(node1); break;
                                    //case "ObjCameraPanVertical": ReadObjCameraPanVertical(node1); break;
                                    //case "ObjCameraPathTarget": ReadObjCameraPathTarget(node1); break;
                                    //case "ObjSoundLine": ReadObjSoundLine(node1); break;
                                    //case "ObjSoundPoint": ReadObjSoundPoint(node1); break;
                                    //case "Paraloop": ReadParaloop(node1); break;
                                    //case "Penguin": ReadPenguin(node1); break;
                                    //case "ReactionPlate": ReadReactionPlate(node1); break;
                                    //case "SnowFloorA": ReadSnowFloorA(node1); break;
                                    //case "SnowFloorB0": ReadSnowFloorB0(node1); break;
                                    //case "SnowFloorB1": ReadSnowFloorB1(node1); break;
                                    //case "SnowFloorB2": ReadSnowFloorB2(node1); break;
                                    //case "SnowFloorB3": ReadSnowFloorB3(node1); break;
                                    //case "SnowFloorB4": ReadSnowFloorB4(node1); break;
                                    //case "SnowFloorB5": ReadSnowFloorB5(node1); break;
                                    //case "SnowFloorB6": ReadSnowFloorB6(node1); break;
                                    //case "SnowFloorB7": ReadSnowFloorB7(node1); break;
                                    //case "Snow_Door": ReadSnow_Door(node1); break;
                                    //case "Snow_IcePillar": ReadSnow_IcePillar(node1); break;
                                    //case "Snow_ThornBall": ReadSnow_ThornBall(node1); break;
                                    //case "StageEffect": ReadStageEffect(node1); break;
                                    //case "StartDynamicPreloadingCollision": ReadStartDynamicPreloadingCollision(node1); break;
                                    //case "StompingSwitch": ReadStompingSwitch(node1); break;
                                    //case "ThornSpring": ReadThornSpring(node1); break;
                                    //case "TrickJumper": ReadTrickJumper(node1); break;
                                    //case "WarpPoint": ReadWarpPoint(node1); break;
                                    //case "Whale": ReadWhale(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);

            //FixCameras();
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

        if (GUILayout.Button("Fix Cameras"))
        {
            FixCameras();
        }

        if (GUILayout.Button("Read Splines"))
        {
            ReadSplines();

            TranslateSplines();
        }

        if (GUILayout.Button("Read Sonic Spawns"))
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
                                case "SonicSpawn": ReadSonicSpawn(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read Unleashed Objects"))
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
                                case "BeachFallFloor": ReadBeachFallFloor(node1); break;
                                case "BeachFlagA": ReadBeachFlagA(node1); break;
                                case "BeachFlagB": ReadBeachFlagB(node1); break;
                                case "BeachFlagC": ReadBeachFlagC(node1); break;
                                case "BeachFlagD": ReadBeachFlagD(node1); break;
                                case "BeachFloorA": ReadBeachFloorA(node1); break;
                                case "BeachFloorB": ReadBeachFloorB(node1); break;
                                case "BeachFloorC": ReadBeachFloorC(node1); break;
                                case "BeachMoveFloorA": ReadBeachMoveFloorA(node1); break;
                                case "BeachMoveFloorB": ReadBeachMoveFloorB(node1); break;
                                case "Beach_BreakBridge": ReadBeach_BreakBridge(node1); break;
                                case "Beach_Buoy": ReadBeach_Buoy(node1); break;
                                case "Beach_Door": ReadBeach_Door(node1); break;
                                case "Beach_FallPillar": ReadBeach_FallPillar(node1); break;
                                case "Beach_FlashFlood": ReadBeach_FlashFlood(node1); break;
                                case "Beach_Guillotine": ReadBeach_Guillotine(node1); break;
                                case "Beach_MotionDoor": ReadBeach_MotionDoor(node1); break;
                                case "Beach_PressThorn": ReadBeach_PressThorn(node1); break;
                                case "Beach_PressThornHalf": ReadBeach_PressThornHalf(node1); break;
                                case "Beach_ThornBar": ReadBeach_ThornBar(node1); break;
                                case "Beach_ThornPillar": ReadBeach_ThornPillar(node1); break;
                                case "Beach_UpFloor": ReadBeach_UpFloor(node1); break;
                                case "Beach_WaterColumn": ReadBeach_WaterColumn(node1); break;
                                case "Bobsleigh": ReadBobsleigh(node1); break;
                                case "BobsleighEndCollision": ReadBobsleighEndCollision(node1); break;
                                case "ChangeCamera2D_Begin": ReadChangeCamera2D_Begin(node1); break;
                                case "eAirCannonGold": ReadeAirCannonGold(node1); break;
                                case "eAirCannonNormal": ReadeAirCannonNormal(node1); break;
                                case "eAirChaser": ReadeAirChaser(node1); break;
                                case "eAirChaserCollisinForceAttack": ReadeAirChaserCollisinForceAttack(node1); break;
                                case "eAirChaserReloadChaserCollision": ReadeAirChaserReloadChaserCollision(node1); break;
                                case "eBigChaser": ReadeBigChaser(node1); break;
                                case "eBigChaserBomb": ReadeBigChaserBomb(node1); break;
                                case "eBlizzard": ReadeBlizzard(node1); break;
                                case "eFighter": ReadeFighter(node1); break;
                                case "eFighterGun": ReadeFighterGun(node1); break;
                                case "eFighterShield": ReadeFighterShield(node1); break;
                                case "eFighterSword": ReadeFighterSword(node1); break;
                                case "eFlame": ReadeFlame(node1); break;
                                case "eMoleCannon": ReadeMoleCannon(node1); break;
                                case "EndDynamicPreloadingCollision": ReadEndDynamicPreloadingCollision(node1); break;
                                case "eShackleFView": ReadeShackleFView(node1); break;
                                case "eSpanner": ReadeSpanner(node1); break;
                                case "eSpinner": ReadeSpinner(node1); break;
                                case "eThunderBall": ReadeThunderBall(node1); break;
                                case "EventSetter": ReadEventSetter(node1); break;
                                case "Grouper": ReadGrouper(node1); break;
                                case "Icicle": ReadIcicle(node1); break;
                                case "ItemBox": ReadItemBox(node1); break;
                                case "ItemIllustBook": ReadItemIllustBook(node1); break;
                                case "ItemRecordA": ReadItemRecordA(node1); break;
                                case "ItemVideoTape": ReadItemVideoTape(node1); break;
                                case "JumpSelector": ReadJumpSelector(node1); break;
                                case "MedalMoon": ReadMedalMoon(node1); break;
                                case "MedalSun": ReadMedalSun(node1); break;
                                case "ObjBaseSound": ReadObjBaseSound(node1); break;
                                case "ObjCamera2D": ReadObjCamera2D(node1); break;
                                case "ObjCameraBlend": ReadObjCameraBlend(node1); break;
                                case "ObjCameraNormal": ReadObjCameraNormal(node1); break;
                                case "ObjCameraPanVertical": ReadObjCameraPanVertical(node1); break;
                                case "ObjCameraPathTarget": ReadObjCameraPathTarget(node1); break;
                                case "ObjSoundLine": ReadObjSoundLine(node1); break;
                                case "ObjSoundPoint": ReadObjSoundPoint(node1); break;
                                case "Paraloop": ReadParaloop(node1); break;
                                case "Penguin": ReadPenguin(node1); break;
                                case "ReactionPlate": ReadReactionPlate(node1); break;
                                case "SnowFloorA": ReadSnowFloorA(node1); break;
                                case "SnowFloorB0": ReadSnowFloorB0(node1); break;
                                case "SnowFloorB1": ReadSnowFloorB1(node1); break;
                                case "SnowFloorB2": ReadSnowFloorB2(node1); break;
                                case "SnowFloorB3": ReadSnowFloorB3(node1); break;
                                case "SnowFloorB4": ReadSnowFloorB4(node1); break;
                                case "SnowFloorB5": ReadSnowFloorB5(node1); break;
                                case "SnowFloorB6": ReadSnowFloorB6(node1); break;
                                case "SnowFloorB7": ReadSnowFloorB7(node1); break;
                                case "Snow_Door": ReadSnow_Door(node1); break;
                                case "Snow_IcePillar": ReadSnow_IcePillar(node1); break;
                                case "Snow_ThornBall": ReadSnow_ThornBall(node1); break;
                                case "StageEffect": ReadStageEffect(node1); break;
                                case "StartDynamicPreloadingCollision": ReadStartDynamicPreloadingCollision(node1); break;
                                case "StompingSwitch": ReadStompingSwitch(node1); break;
                                case "ThornSpring": ReadThornSpring(node1); break;
                                case "TrickJumper": ReadTrickJumper(node1); break;
                                case "WarpPoint": ReadWarpPoint(node1); break;
                                case "Whale": ReadWhale(node1); break;
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
                                //Collision
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

        if (GUILayout.Button("Read Set Particle"))
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
                                case "SetParticle": ReadSetParticle(node1); break;
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
                                case "ChangeMode_3DtoDash": ReadChangeMode_3DtoDash(node1); break;
                                case "ChangeMode_3DtoForward": ReadChangeMode_3DtoForward(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read PointMarkers"))
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
                                case "PointMarker": ReadPointMarker(node1); break;
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

        if (GUILayout.Button("Read Select Canons"))
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
                                case "SelectCanon": ReadSelectCanon(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read Egg Fighters"))
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
                                case "EnemyEFighter3D": ReadEnemyEFighter3D(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read Object Physics"))
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
                                case "ObjectPhysics": ReadObjectPhysics(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }

        if (GUILayout.Button("Read Enemy Spinners"))
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
                                case "EnemySpinner": ReadEnemySpinner(node1); break;
                            }
                        }
                        break;
                }
            }
            DestroyImmediate(temp);
        }
    }

    void ReadSplines()
    {
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(xmlToRead.text);

        foreach (XmlNode node0 in xmlDocument.ChildNodes)
        {
            switch (node0.Name)
            {
                case "SonicPath":

                    foreach (XmlNode a in node0.ChildNodes)
                    {
                        switch (a.Name)
                        {
                            case "library":
                                foreach (XmlNode b in a.ChildNodes)
                                {
                                    switch (b.Name)
                                    {
                                        case "geometry":
                                            GameObject gas = new GameObject(b.Attributes[0].Value.Replace("-geometry", string.Empty));
                                            foreach (XmlNode c in b.ChildNodes)
                                            {
                                                switch (c.Name)
                                                {
                                                    case "spline":
                                                        foreach (XmlNode d in c.ChildNodes)
                                                        {

                                                            switch (d.Name)
                                                            {
                                                                case "spline3d":
                                                                    GameObject go = new GameObject(d.Name);
                                                                    go.transform.parent = gas.transform;
                                                                    BezierSpline bezierSpline = go.AddComponent<BezierSpline>();

                                                                    bezierSpline.bezierControlPoints.Clear();

                                                                    foreach (XmlNode e in d.ChildNodes)
                                                                    {
                                                                        BezierControlPoint controlPoint = new BezierControlPoint();

                                                                        switch (e.Attributes[0].Value)
                                                                        {
                                                                            case "auto":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {

                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }


                                                                                }
                                                                                break;
                                                                            case "bezier":

                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;

                                                                            case "corner":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;

                                                                            case "bezier_corner":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;
                                                                        }
                                                                        bezierSpline.bezierControlPoints.Add(controlPoint);
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
                    break;
            }
        }
    }

    void TranslateSplines()
    {
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(xmlToRead.text);

        foreach (XmlNode node0 in xmlDocument.ChildNodes)
        {
            switch (node0.Name)
            {
                case "SonicPath":
                    foreach (XmlNode a in node0.ChildNodes)
                    {
                        switch (a.Name)
                        {
                            case "scene":
                                foreach (XmlNode b in a.ChildNodes)
                                {
                                    switch (b.Name)
                                    {
                                        case "node":

                                            GameObject gas = GameObject.Find(b.Attributes[0].Value);
                                            //Dragon Road Spline
                                            //gas = GameObject.Find(b.Attributes[0].Value + "-spline");


                                            foreach (XmlNode c in b.ChildNodes)
                                            {
                                                switch (c.Name)
                                                {
                                                    case "translate":
                                                        string[] pos = c.InnerText.Split(' ');
                                                        gas.transform.position = new Vector3(-float.Parse(pos[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(pos[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(pos[2], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                    case "scale":
                                                        string[] size = c.InnerText.Split(' ');
                                                        gas.transform.localScale = new Vector3(-float.Parse(size[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(size[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(size[2], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                    case "rotate":
                                                        string[] rot = c.InnerText.Split(' ');
                                                        gas.transform.rotation = new Quaternion(float.Parse(rot[0], CultureInfo.InvariantCulture.NumberFormat), -float.Parse(rot[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(rot[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(rot[3], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                }

                                break;
                        }
                    }
                    break;
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
            CreateObject(component, "ChangeVolumeCamera", "ChangeVolumeCameras", position, rotation);
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
                    rotation = ReadRotation(node);
                    break;
                case "MultiSetParam":
                    ReadMultiSetParam(component, node, "ObjCameraParallel", "ObjCameraParallels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraParallel", "ObjCameraParallels", position, rotation);
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
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetDirection":
                    component.TargetDirection = ReadPosition(node);
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
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "LaunchVelocity":
                    component.LaunchVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NoControlTime":
                    component.NoControlTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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

    //Common
    private void ReadAdlibTrickJump(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AdlibTrickJump>())
        {
            temp.AddComponent<AdlibTrickJump>();
        }

        AdlibTrickJump component = temp.GetComponent<AdlibTrickJump>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AdlibTrickJumps"))
        {
            new GameObject("AdlibTrickJumps");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "ImpulseSpeedOnBoost":
                    component.ImpulseSpeedOnBoost = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseSpeedOnNormal":
                    component.ImpulseSpeedOnNormal = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsTo3D":
                    component.IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "SizeType":
                    component.SizeType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "AdlibTrickJump", "AdlibTrickJumps");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AdlibTrickJump", "AdlibTrickJumps", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AdlibTrickJump");
        }
    }
    private void ReadAirSpring(XmlNode xmlNode)
    {
        if (!temp.GetComponent<AirSpring>())
        {
            temp.AddComponent<AirSpring>();
        }

        AirSpring component = temp.GetComponent<AirSpring>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("AirSprings"))
        {
            new GameObject("AirSprings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AimDirection":
                    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                //case "IsCastShadow":
                //    //component.IsCastShadow = bool.Parse(node.InnerText);
                //    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsSideSet":
                    component.IsSideSet = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionType":
                    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "Range":
                //    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "m_IsConstantFrame":
                    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                    break;
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHunting":
                    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                    break;
                case "m_IsStopBoost":
                    component.m_IsStopBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsTo3D":
                    component.m_IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "m_MonkeyTarget":
                    component.m_MonkeyTarget = ReadPosition(node);
                    break;
                case "HasBase":
                    component.HasBase = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHuntingLowAngle":
                    component.m_IsMonkeyHuntingLowAngle = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "AirSpring", "AirSprings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "AirSpring", "AirSprings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate AirSpring");
        }
    }
    private void ReadBomb(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Bomb>())
        {
            temp.AddComponent<Bomb>();
        }

        Bomb component = temp.GetComponent<Bomb>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Bombs"))
        {
            new GameObject("Bombs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BlastPower":
                    component.BlastPower = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "ThresholdStumble":
                    component.ThresholdStumble = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Bomb", "Bombs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Bomb", "Bombs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Bomb");
        }
    }
    private void ReadClassicItemBox(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ClassicItemBox>())
        {
            temp.AddComponent<ClassicItemBox>();
        }

        ClassicItemBox component = temp.GetComponent<ClassicItemBox>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ClassicItemBoxs"))
        {
            new GameObject("ClassicItemBoxs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAir":
                    component.IsAir = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsRevive":
                    component.IsRevive = bool.Parse(node.InnerText);
                    break;
                case "IsSideGet":
                    component.IsSideGet = bool.Parse(node.InnerText);
                    break;
                case "ItemType":
                    component.ItemType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaunchSpeed":
                    component.LaunchSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TreasureSearchHideType":
                    component.TreasureSearchHideType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ClassicItemBox", "ClassicItemBoxs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ClassicItemBox", "ClassicItemBoxs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ClassicItemBox");
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
    private void ReadDirectionalThorn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<DirectionalThorn>())
        { 
            temp.AddComponent<DirectionalThorn>();
        }

        DirectionalThorn component = temp.GetComponent<DirectionalThorn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("DirectionalThorns"))
        {
            new GameObject("DirectionalThorns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ForetasteTime":
                    component.ForetasteTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsUsePanel":
                    component.IsUsePanel = bool.Parse(node.InnerText);
                    break;
                case "MoveTime":
                    component.MoveTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffTime":
                    component.OffTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnTime":
                    component.OnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UseRigidBody":
                    component.UseRigidBody = bool.Parse(node.InnerText);
                    break;
                case "UsePanel":
                    component.UsePanel = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "DirectionalThorn", "DirectionalThorns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "DirectionalThorn", "DirectionalThorns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate DirectionalThorn");
        }
    }
    private void ReadEchoCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EchoCollision>())
        {
            temp.AddComponent<EchoCollision>();
        }

        EchoCollision component = temp.GetComponent<EchoCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EchoCollisions"))
        {
            new GameObject("EchoCollisions");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Collision_Depth":
                    component.Collision_Depth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EchoBGM_Dst":
                    component.EchoBGM_Dst = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EchoBGM_Src":
                    component.EchoBGM_Src = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EchoSE_Dst":
                    component.EchoSE_Dst = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EchoSE_Src":
                    component.EchoSE_Src = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EchoCollision", "EchoCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EchoCollision", "EchoCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EchoCollision");
        }
    }
    private void ReadFallSignalFV(XmlNode xmlNode)
    {
        if (!temp.GetComponent<FallSignalFV>())
        {
            temp.AddComponent<FallSignalFV>();
        }

        FallSignalFV component = temp.GetComponent<FallSignalFV>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("FallSignalFVs"))
        {
            new GameObject("FallSignalFVs");
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
                case "ItemType":
                    component.ItemType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "FallSignalFV", "FallSignalFVs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "FallSignalFV", "FallSignalFVs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate FallSignalFV");
        }
    }
    private void ReadFallSignalSV(XmlNode xmlNode)
    {
        if (!temp.GetComponent<FallSignalSV>())
        {
            temp.AddComponent<FallSignalSV>();
        }

        FallSignalSV component = temp.GetComponent<FallSignalSV>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("FallSignalSVs"))
        {
            new GameObject("FallSignalSVs");
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
                case "ItemType":
                    component.ItemType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "FallSignalSV", "FallSignalSVs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "FallSignalSV", "FallSignalSVs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate FallSignalSV");
        }
    }
    private void ReadFixedFloor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<FixedFloor>())
        {
            temp.AddComponent<FixedFloor>();
        }

        FixedFloor component = temp.GetComponent<FixedFloor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("FixedFloors"))
        {
            new GameObject("FixedFloors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScaleX":
                    component.ScaleX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScaleY":
                    component.ScaleY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScaleZ":
                    component.ScaleZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsIce":
                    component.IsIce = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "FixedFloor", "FixedFloors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "FixedFloor", "FixedFloors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate FixedFloor");
        }
    }
    private void ReadFlame(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Flame>())
        {
            temp.AddComponent<Flame>();
        }

        Flame component = temp.GetComponent<Flame>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Flames"))
        {
            new GameObject("Flames");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FlameType":
                    component.FlameType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "LengthType":
                    component.LengthType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OffTime":
                    component.OffTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnTime":
                    component.OnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PhaseRate":
                    component.PhaseRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Flame", "Flames");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Flame", "Flames", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Flame");
        }
    }
    private void ReadGeneralFloor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GeneralFloor>())
        {
            temp.AddComponent<GeneralFloor>();
        }

        GeneralFloor component = temp.GetComponent<GeneralFloor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GeneralFloors"))
        {
            new GameObject("GeneralFloors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetX":
                    component.AttachOffsetX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetY":
                    component.AttachOffsetY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetZ":
                    component.AttachOffsetZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "AttachTarget":
                //    component.AttachTarget = id_list.Parse(node.InnerText);
                //    break;
                case "BeginEdge":
                    component.BeginEdge = bool.Parse(node.InnerText);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallPointIndex":
                    component.FallPointIndex = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallPointTime":
                    component.FallPointTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallTime":
                    component.FallTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FloorSize":
                    component.FloorSize = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FloorType":
                    component.FloorType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ForceGrid":
                    component.ForceGrid = bool.Parse(node.InnerText);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InitOffset":
                    component.InitOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreakable":
                    component.IsBreakable = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsEnableFall":
                    component.IsEnableFall = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsRelativePosition":
                    component.IsRelativePosition = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "LightFieldOffset":
                    component.LightFieldOffset = ReadPosition(node);
                    break;
                case "ModelInterval":
                    component.ModelInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ModelNum":
                    component.ModelNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveTypeGeneral":
                    component.MoveTypeGeneral = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "PositionList":
                //    component.PositionList = vector_list.Parse(node.InnerText);
                //    break;
                case "RailDir":
                    component.RailDir = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ratio":
                    component.Ratio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartByNotify":
                    component.StartByNotify = bool.Parse(node.InnerText);
                    break;
                case "UsePointFloor":
                    component.UsePointFloor = bool.Parse(node.InnerText);
                    break;
                case "UseStartSE":
                    component.UseStartSE = bool.Parse(node.InnerText);
                    break;
                case "VisibleRail":
                    component.VisibleRail = bool.Parse(node.InnerText);
                    break;
                case "WaitShakeTime":
                    component.WaitShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "GeneralFloor", "GeneralFloors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GeneralFloor", "GeneralFloors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GeneralFloor");
        }
    }
    private void ReadGeneralFloorCustom(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GeneralFloorCustom>())
        {
            temp.AddComponent<GeneralFloorCustom>();
        }

        GeneralFloorCustom component = temp.GetComponent<GeneralFloorCustom>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GeneralFloorCustoms"))
        {
            new GameObject("GeneralFloorCustoms");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetX":
                    component.AttachOffsetX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetY":
                    component.AttachOffsetY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttachOffsetZ":
                    component.AttachOffsetZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "AttachTarget":
                //    component.AttachTarget = undefined.Parse(node.InnerText);
                //    break;
                case "BeginEdge":
                    component.BeginEdge = bool.Parse(node.InnerText);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallPointIndex":
                    component.FallPointIndex = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallPointTime":
                    component.FallPointTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FallTime":
                    component.FallTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FloorSize":
                    component.FloorSize = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FloorType":
                    component.FloorType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ForceGrid":
                    component.ForceGrid = bool.Parse(node.InnerText);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InitOffset":
                    component.InitOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreakable":
                    component.IsBreakable = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsEnableFall":
                    component.IsEnableFall = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsRelativePosition":
                    component.IsRelativePosition = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "LightFieldOffset":
                    component.LightFieldOffset = ReadPosition(node);
                    break;
                case "ModelInterval":
                    component.ModelInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ModelNum":
                    component.ModelNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveTypeGeneral":
                    component.MoveTypeGeneral = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "PositionList":
                //    component.PositionList = undefined.Parse(node.InnerText);
                //    break;
                case "RailDir":
                    component.RailDir = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ratio":
                    component.Ratio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartByNotify":
                    component.StartByNotify = bool.Parse(node.InnerText);
                    break;
                case "UsePointFloor":
                    component.UsePointFloor = bool.Parse(node.InnerText);
                    break;
                case "UseStartSE":
                    component.UseStartSE = bool.Parse(node.InnerText);
                    break;
                case "VisibleRail":
                    component.VisibleRail = bool.Parse(node.InnerText);
                    break;
                case "WaitShakeTime":
                    component.WaitShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "GeneralFloorCustom", "GeneralFloorCustoms");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GeneralFloorCustom", "GeneralFloorCustoms", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GeneralFloorCustom");
        }
    }
    private void ReadGoalRing(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GoalRing>())
        {
            temp.AddComponent<GoalRing>();
        }

        GoalRing component = temp.GetComponent<GoalRing>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GoalRings"))
        {
            new GameObject("GoalRings");
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
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResultPosition":
                    component.ResultPosition = ReadPosition(node);
                    break;
                case "SENumber":
                    component.SENumber = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BossKeyType":
                    component.BossKeyType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "GoalRing", "GoalRings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GoalRing", "GoalRings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GoalRing");
        }
    }
    private void ReadGoalSignboard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GoalSignboard>())
        {
            temp.AddComponent<GoalSignboard>();
        }

        GoalSignboard component = temp.GetComponent<GoalSignboard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GoalSignboards"))
        {
            new GameObject("GoalSignboards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DefaultPreGoalCameraFovy":
                    component.DefaultPreGoalCameraFovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetPositionX":
                    component.DefaultPreGoalCameraOffsetPositionX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetPositionY":
                    component.DefaultPreGoalCameraOffsetPositionY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetPositionZ":
                    component.DefaultPreGoalCameraOffsetPositionZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetTargetX":
                    component.DefaultPreGoalCameraOffsetTargetX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetTargetY":
                    component.DefaultPreGoalCameraOffsetTargetY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultPreGoalCameraOffsetTargetZ":
                    component.DefaultPreGoalCameraOffsetTargetZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsCustomPreGoalCameraParam":
                    component.IsCustomPreGoalCameraParam = bool.Parse(node.InnerText);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "IsPopCameraAll":
                    component.IsPopCameraAll = bool.Parse(node.InnerText);
                    break;
                case "IsUsePreGoalCameraParam":
                    component.IsUsePreGoalCameraParam = bool.Parse(node.InnerText);
                    break;
                case "OverrideDiffuse":
                    component.OverrideDiffuse = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PreGoalCameraCollisionSizeX":
                    component.PreGoalCameraCollisionSizeX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PreGoalCameraCollisionSizeY":
                    component.PreGoalCameraCollisionSizeY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PreGoalCameraCollisionSizeZ":
                    component.PreGoalCameraCollisionSizeZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResultDegree":
                    component.ResultDegree = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResultPosition":
                    component.ResultPosition = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "GoalSignboard", "GoalSignboards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GoalSignboard", "GoalSignboards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GoalSignboard");
        }
    }
    private void ReadGrindDashPanel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GrindDashPanel>())
        {
            temp.AddComponent<GrindDashPanel>();
        }

        GrindDashPanel component = temp.GetComponent<GrindDashPanel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GrindDashPanels"))
        {
            new GameObject("GrindDashPanels");
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
                case "IsFront":
                    component.IsFront = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "GrindDashPanel", "GrindDashPanels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GrindDashPanel", "GrindDashPanels", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GrindDashPanel");
        }
    }
    private void ReadGrindThorn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<GrindThorn>())
        {
            temp.AddComponent<GrindThorn>();
        }

        GrindThorn component = temp.GetComponent<GrindThorn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("GrindThorns"))
        {
            new GameObject("GrindThorns");
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
                    ReadMultiSetParam(component, node, "GrindThorn", "GrindThorns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "GrindThorn", "GrindThorns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate GrindThorn");
        }
    }
    private void ReadIronPole2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<IronPole2D>())
        {
            temp.AddComponent<IronPole2D>();
        }

        IronPole2D component = temp.GetComponent<IronPole2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("IronPole2Ds"))
        {
            new GameObject("IronPole2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "CameraEaseTimeEnter":
                    component.CameraEaseTimeEnter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraEaseTimeKeep":
                    component.CameraEaseTimeKeep = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraEaseTimeLeave":
                    component.CameraEaseTimeLeave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraID":
                    component.CameraID = int.Parse(node.InnerText);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GuideSide":
                    component.GuideSide = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "IronPole2D", "IronPole2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "IronPole2D", "IronPole2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate IronPole2D");
        }
    }
    private void ReadItem(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Item>())
        {
            temp.AddComponent<Item>();
        }

        Item component = temp.GetComponent<Item>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Items"))
        {
            new GameObject("Items");
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
                case "ItemType":
                    component.ItemType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Item", "Items");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Item", "Items", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Item");
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
    private void ReadJumpBoard3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<JumpBoard3D>())
        {
            temp.AddComponent<JumpBoard3D>();
        }

        JumpBoard3D component = temp.GetComponent<JumpBoard3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("JumpBoard3Ds"))
        {
            new GameObject("JumpBoard3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
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
                case "SizeType":
                    component.SizeType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "JumpBoard3D", "JumpBoard3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "JumpBoard3D", "JumpBoard3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate JumpBoard3D");
        }
    }
    private void ReadJumpPole(XmlNode xmlNode)
    {
        if (!temp.GetComponent<JumpPole>())
        {
            temp.AddComponent<JumpPole>();
        }

        JumpPole component = temp.GetComponent<JumpPole>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("JumpPoles"))
        {
            new GameObject("JumpPoles");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddMaxVelocity":
                    component.AddMaxVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AddMinVelocity":
                    component.AddMinVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "JumpPole", "JumpPoles");
                    break;
            }
        }
        try
        {
            CreateObject(component, "JumpPole", "JumpPoles", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate JumpPole");
        }
    }
    private void ReadMovingThorn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<MovingThorn>())
        {
            temp.AddComponent<MovingThorn>();
        }

        MovingThorn component = temp.GetComponent<MovingThorn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("MovingThorns"))
        {
            new GameObject("MovingThorns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Direction":
                    component.Direction = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time":
                    component.Time = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "MovingThorn", "MovingThorns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "MovingThorn", "MovingThorns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate MovingThorn");
        }
    }
    private void ReadObjectPhysics(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjectPhysics>())
        {
            temp.AddComponent<ObjectPhysics>();
        }

        ObjectPhysics component = temp.GetComponent<ObjectPhysics>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjectPhysics"))
        {
            new GameObject("ObjectPhysics");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CullingRange":
                    component.CullingRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebrisTarget":
                    component.DebrisTarget = ReadPosition(node);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDynamic":
                    component.IsDynamic = bool.Parse(node.InnerText);
                    break;
                case "IsReset":
                    component.IsReset = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = node.InnerText;
                    break;
                case "WrappedObjectID":
                    component.WrappedObjectID = int.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, component.Type, "ObjectPhysics");
                    break;
            }
        }
        try
        {
            CreateObject(component, component.Type, "ObjectPhysics", position, rotation);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Can't Instantiate " + component.Type + ex);
        }
    }
    private void ReadOmochao(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Omochao>())
        {
            temp.AddComponent<Omochao>();
        }

        Omochao component = temp.GetComponent<Omochao>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Omochaos"))
        {
            new GameObject("Omochaos");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Comment":
                    component.Comment = bool.Parse(node.InnerText);
                    break;
                case "CommentE":
                    component.CommentE = bool.Parse(node.InnerText);
                    break;
                case "CommentF":
                    component.CommentF = bool.Parse(node.InnerText);
                    break;
                case "CommentG":
                    component.CommentG = bool.Parse(node.InnerText);
                    break;
                case "CommentI":
                    component.CommentI = bool.Parse(node.InnerText);
                    break;
                case "CommentS":
                    component.CommentS = bool.Parse(node.InnerText);
                    break;
                case "Cond":
                    component.Cond = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "PageNum":
                    component.PageNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PageNumE":
                    component.PageNumE = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PageNumF":
                    component.PageNumF = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PageNumG":
                    component.PageNumG = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PageNumI":
                    component.PageNumI = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PageNumS":
                    component.PageNumS = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuID":
                    component.SerifuID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTime0":
                    component.SerifuTime0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTime1":
                    component.SerifuTime1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTime2":
                    component.SerifuTime2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTime3":
                    component.SerifuTime3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTime4":
                    component.SerifuTime4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeE0":
                    component.SerifuTimeE0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeE1":
                    component.SerifuTimeE1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeE2":
                    component.SerifuTimeE2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeE3":
                    component.SerifuTimeE3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeE4":
                    component.SerifuTimeE4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeF0":
                    component.SerifuTimeF0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeF1":
                    component.SerifuTimeF1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeF2":
                    component.SerifuTimeF2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeF3":
                    component.SerifuTimeF3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeF4":
                    component.SerifuTimeF4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeG0":
                    component.SerifuTimeG0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeG1":
                    component.SerifuTimeG1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeG2":
                    component.SerifuTimeG2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeG3":
                    component.SerifuTimeG3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeG4":
                    component.SerifuTimeG4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeI0":
                    component.SerifuTimeI0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeI1":
                    component.SerifuTimeI1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeI2":
                    component.SerifuTimeI2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeI3":
                    component.SerifuTimeI3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeI4":
                    component.SerifuTimeI4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeS0":
                    component.SerifuTimeS0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeS1":
                    component.SerifuTimeS1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeS2":
                    component.SerifuTimeS2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeS3":
                    component.SerifuTimeS3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SerifuTimeS4":
                    component.SerifuTimeS4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SlowTime":
                    component.SlowTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UseVoiceTime":
                    component.UseVoiceTime = bool.Parse(node.InnerText);
                    break;
                case "UseVoiceTimeE":
                    component.UseVoiceTimeE = bool.Parse(node.InnerText);
                    break;
                case "UseVoiceTimeF":
                    component.UseVoiceTimeF = bool.Parse(node.InnerText);
                    break;
                case "UseVoiceTimeG":
                    component.UseVoiceTimeG = bool.Parse(node.InnerText);
                    break;
                case "UseVoiceTimeI":
                    component.UseVoiceTimeI = bool.Parse(node.InnerText);
                    break;
                case "UseVoiceTimeS":
                    component.UseVoiceTimeS = bool.Parse(node.InnerText);
                    break;
                case "WaitType":
                    component.WaitType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "For2D":
                    component.For2D = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "Omochao", "Omochaos");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Omochao", "Omochaos", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Omochao");
        }
    }
    private void ReadOnewayFloor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<OnewayFloor>())
        {
            temp.AddComponent<OnewayFloor>();
        }

        OnewayFloor component = temp.GetComponent<OnewayFloor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("OnewayFloors"))
        {
            new GameObject("OnewayFloors");
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
                case "TerrainAttribute":
                    component.TerrainAttribute = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Width":
                    component.Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZOffsetEnable":
                    component.ZOffsetEnable = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "OnewayFloor", "OnewayFloors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "OnewayFloor", "OnewayFloors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate OnewayFloor");
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
                case "EndPosition":
                    component.EndPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsJumpCancel":
                    component.IsJumpCancel = bool.Parse(node.InnerText);
                    break;
                case "IsPoleAttackInvSide":
                    component.IsPoleAttackInvSide = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MinInitVel":
                    component.MinInitVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathID":
                    component.PathID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartPosition":
                    component.StartPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "MedalID":
                    component.MedalID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InitDisp":
                    component.InitDisp = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsLightSpeedDashTarget":
                    component.IsLightSpeedDashTarget = bool.Parse(node.InnerText);
                    break;
                case "IsReset":
                    component.IsReset = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TreasureSearchHideType":
                    component.TreasureSearchHideType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
    private void ReadSelectCanon(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SelectCanon>())
        {
            temp.AddComponent<SelectCanon>();
        }

        SelectCanon component = temp.GetComponent<SelectCanon>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SelectCanons"))
        {
            new GameObject("SelectCanons");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InputTmie":
                    component.InputTmie = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl_Fail":
                    component.OutOfControl_Fail = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotForce":
                    component.ShotForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotForce_Fail":
                    component.ShotForce_Fail = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SuccessDir":
                    component.SuccessDir = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SelectCanon", "SelectCanons");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SelectCanon", "SelectCanons", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SelectCanon");
        }
    }
    private void ReadSetParticle(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SetParticle>())
        {
            temp.AddComponent<SetParticle>();
        }

        SetParticle component = temp.GetComponent<SetParticle>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SetParticles"))
        {
            new GameObject("SetParticles");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BootType":
                    component.BootType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CullingRadius":
                    component.CullingRadius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffColScaleA":
                    component.EffColScaleA = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffColScaleB":
                    component.EffColScaleB = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffColScaleG":
                    component.EffColScaleG = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffColScaleR":
                    component.EffColScaleR = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffecScale":
                    component.EffecScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffectName":
                    component.EffectName = node.InnerText;
                    break;
                case "EffectScaleX":
                    component.EffectScaleX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffectScaleY":
                    component.EffectScaleY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffectScaleZ":
                    component.EffectScaleZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EmissionPosType":
                    component.EmissionPosType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "NoStopEvent":
                    component.NoStopEvent = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SeName":
                    component.SeName = node.InnerText;
                    break;
                case "UseSE":
                    component.UseSE = bool.Parse(node.InnerText);
                    break;
                case "effectScaleType":
                    component.effectScaleType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, component.EffectName, "SetParticles");
                    break;
            }
        }
        try
        {
            CreateObject(component, component.EffectName, "SetParticles", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate " + component.EffectName);
        }
    }
    private void ReadSetParticleVolume(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SetParticleVolume>())
        {
            temp.AddComponent<SetParticleVolume>();
        }

        SetParticleVolume component = temp.GetComponent<SetParticleVolume>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SetParticleVolumes"))
        {
            new GameObject("SetParticleVolumes");
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
                case "EFFECTNAME1":
                    component.EFFECTNAME1 = node.InnerText;
                    break;
                case "EFFECTNAME2":
                    component.EFFECTNAME2 = node.InnerText;
                    break;
                case "EFFECT_SCALE1":
                    component.EFFECT_SCALE1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE2":
                    component.EFFECT_SCALE2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_TYPE1":
                    component.EFFECT_SCALE_TYPE1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_TYPE2":
                    component.EFFECT_SCALE_TYPE2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_X1":
                    component.EFFECT_SCALE_X1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_X2":
                    component.EFFECT_SCALE_X2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_Y1":
                    component.EFFECT_SCALE_Y1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_Y2":
                    component.EFFECT_SCALE_Y2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_Z1":
                    component.EFFECT_SCALE_Z1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFFECT_SCALE_Z2":
                    component.EFFECT_SCALE_Z2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_A1":
                    component.EFF_COL_SCALE_A1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_A2":
                    component.EFF_COL_SCALE_A2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_B1":
                    component.EFF_COL_SCALE_B1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_B2":
                    component.EFF_COL_SCALE_B2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_G1":
                    component.EFF_COL_SCALE_G1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_G2":
                    component.EFF_COL_SCALE_G2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_R1":
                    component.EFF_COL_SCALE_R1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EFF_COL_SCALE_R2":
                    component.EFF_COL_SCALE_R2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EMITTER1":
                    component.EMITTER1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EMITTER2":
                    component.EMITTER2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EMITTER_POS1":
                    component.EMITTER_POS1 = ReadPosition(node);
                    break;
                case "EMITTER_POS2":
                    component.EMITTER_POS2 = ReadPosition(node);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "NO_STOP_EVENT1":
                    component.NO_STOP_EVENT1 = bool.Parse(node.InnerText);
                    break;
                case "NO_STOP_EVENT2":
                    component.NO_STOP_EVENT2 = bool.Parse(node.InnerText);
                    break;
                case "ONLY_ONCE1":
                    component.ONLY_ONCE1 = bool.Parse(node.InnerText);
                    break;
                case "ONLY_ONCE2":
                    component.ONLY_ONCE2 = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SENAME1":
                    component.SENAME1 = node.InnerText;
                    break;
                case "SENAME2":
                    component.SENAME2 = node.InnerText;
                    break;
                case "Shape_Type":
                    component.Shape_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Trigger":
                    component.Trigger = int.Parse(node.InnerText);
                    break;
                case "TriggerType":
                    component.TriggerType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "USE1":
                    component.USE1 = bool.Parse(node.InnerText);
                    break;
                case "USE2":
                    component.USE2 = bool.Parse(node.InnerText);
                    break;
                case "USESE1":
                    component.USESE1 = bool.Parse(node.InnerText);
                    break;
                case "USESE2":
                    component.USESE2 = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "SetParticleVolume", "SetParticleVolumes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SetParticleVolume", "SetParticleVolumes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SetParticleVolume");
        }
    }
    private void ReadSetRigidBody(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SetRigidBody>())
        {
            temp.AddComponent<SetRigidBody>();
        }

        SetRigidBody component = temp.GetComponent<SetRigidBody>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SetRigidBodys"))
        {
            new GameObject("SetRigidBodys");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DefaultON":
                    component.DefaultON = bool.Parse(node.InnerText);
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
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsPlayerTerrain":
                    component.IsPlayerTerrain = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Width":
                    component.Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsSearchInsulateOnly":
                    component.m_IsSearchInsulateOnly = bool.Parse(node.InnerText);
                    break;
                case "IsPushBoxWall":
                    component.IsPushBoxWall = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "SetRigidBody", "SetRigidBodys");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SetRigidBody", "SetRigidBodys", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SetRigidBody");
        }
    }
    private void ReadSonicSpawn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SonicSpawn>())
        {
            temp.AddComponent<SonicSpawn>();
        }

        SonicSpawn component = temp.GetComponent<SonicSpawn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SonicSpawns"))
        {
            new GameObject("SonicSpawns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Active":
                    //component.Active = bool.Parse(node.InnerText);
                    break;
                case "Mode":
                    component.Mode = node.InnerText;
                    break;
                case "CameraView":
                    component.CameraView = node.InnerText;
                    break;
                case "Speed":
                    component.Speed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time":
                    component.Time = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SonicSpawn", "SonicSpawns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SonicSpawn", "SonicSpawns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SonicSpawn");
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
                case "AimDirection":
                    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BaseRotation":
                    component.BaseRotation = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsLongBase":
                    component.IsLongBase = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsSideSet":
                    component.IsSideSet = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsWithBase":
                    component.IsWithBase = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionType":
                    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsConstantFrame":
                    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                    break;
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHunting":
                    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                    break;
                case "m_IsStopBoost":
                    component.m_IsStopBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsTo3D":
                    component.m_IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "m_MonkeyTarget":
                    component.m_MonkeyTarget = ReadPosition(node);
                    break;
                case "IsInvisible":
                    component.IsInvisible = bool.Parse(node.InnerText);
                    break;
                case "HasBase":
                    component.HasBase = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHuntingLowAngle":
                    component.m_IsMonkeyHuntingLowAngle = bool.Parse(node.InnerText);
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
    private void ReadSpringFake(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SpringFake>())
        {
            temp.AddComponent<SpringFake>();
        }

        SpringFake component = temp.GetComponent<SpringFake>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SpringFakes"))
        {
            new GameObject("SpringFakes");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AimDirection":
                    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsSideSet":
                    component.IsSideSet = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionType":
                    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsConstantFrame":
                    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                    break;
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHunting":
                    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                    break;
                case "m_IsStopBoost":
                    component.m_IsStopBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsTo3D":
                    component.m_IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "m_MonkeyTarget":
                    component.m_MonkeyTarget = ReadPosition(node);
                    break;
                case "HasBase":
                    component.HasBase = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHuntingLowAngle":
                    component.m_IsMonkeyHuntingLowAngle = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "SpringFake", "SpringFakes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SpringFake", "SpringFakes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SpringFake");
        }
    }
    private void ReadSuperRing(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SuperRing>())
        {
            temp.AddComponent<SuperRing>();
        }

        SuperRing component = temp.GetComponent<SuperRing>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SuperRings"))
        {
            new GameObject("SuperRings");
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
                    ReadMultiSetParam(component, node, "SuperRing", "SuperRings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SuperRing", "SuperRings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SuperRing");
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
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ImpulseVelocity":
                    component.ImpulseVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsWaitUp":
                    component.IsWaitUp = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpSpeedMax":
                    component.UpSpeedMax = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
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
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "IsStartPositionConstant":
                    component.IsStartPositionConstant = bool.Parse(node.InnerText);
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

    //Enemies
    private void ReadEnemyAeroCannon(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyAeroCannon>())
        {
            temp.AddComponent<EnemyAeroCannon>();
        }

        EnemyAeroCannon component = temp.GetComponent<EnemyAeroCannon>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyAeroCannons"))
        {
            new GameObject("EnemyAeroCannons");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "m_ChargeTime":
                    component.m_ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_GapTime":
                    component.m_GapTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Is2DMode":
                    component.m_Is2DMode = bool.Parse(node.InnerText);
                    break;
                case "m_IsAttack":
                    component.m_IsAttack = bool.Parse(node.InnerText);
                    break;
                case "m_IsFixRotate":
                    component.m_IsFixRotate = bool.Parse(node.InnerText);
                    break;
                case "m_IsRebirth":
                    component.m_IsRebirth = bool.Parse(node.InnerText);
                    break;
                case "m_IsShotSpanRotate":
                    component.m_IsShotSpanRotate = bool.Parse(node.InnerText);
                    break;
                case "m_LostTime":
                    component.m_LostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_NumShots":
                    component.m_NumShots = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_RebirthTime":
                    component.m_RebirthTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ShotSpanTime":
                    component.m_ShotSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ShotSpeed":
                    component.m_ShotSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_TurnAccel":
                    component.m_TurnAccel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyAeroCannon", "EnemyAeroCannons");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyAeroCannon", "EnemyAeroCannons", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyAeroCannon");
        }
    }
    private void ReadEnemyBatabata2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyBatabata2D>())
        {
            temp.AddComponent<EnemyBatabata2D>();
        }

        EnemyBatabata2D component = temp.GetComponent<EnemyBatabata2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyBatabata2Ds"))
        {
            new GameObject("EnemyBatabata2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsUseZOffset":
                    component.IsUseZOffset = bool.Parse(node.InnerText);
                    break;
                case "LaunchSpeed":
                    component.LaunchSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SideMoveSpeed":
                    component.SideMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ZBackOffset":
                    component.ZBackOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyBatabata2D", "EnemyBatabata2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyBatabata2D", "EnemyBatabata2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyBatabata2D");
        }
    }
    private void ReadEnemyBeeton2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyBeeton2D>())
        {
            temp.AddComponent<EnemyBeeton2D>();
        }

        EnemyBeeton2D component = temp.GetComponent<EnemyBeeton2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyBeeton2Ds"))
        {
            new GameObject("EnemyBeeton2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ActionType":
                    component.ActionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AfterMoveLength":
                    component.AfterMoveLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeed":
                    component.DashSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "HoveringType":
                    component.HoveringType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "IsOneShotOnOneWay":
                    component.IsOneShotOnOneWay = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "IsRevive":
                    component.IsRevive = bool.Parse(node.InnerText);
                    break;
                case "IsShotEnable":
                    component.IsShotEnable = bool.Parse(node.InnerText);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveWidth":
                    component.MoveWidth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ReviveTime":
                    component.ReviveTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotSpeed":
                    component.ShotSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetPosition":
                    component.TargetPosition = ReadPosition(node);
                    break;
                case "TurnTime":
                    component.TurnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WaitAfterShot":
                    component.WaitAfterShot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemyBeeton2D", "EnemyBeeton2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyBeeton2D", "EnemyBeeton2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyBeeton2D");
        }
    }
    private void ReadEnemyBeeton3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyBeeton3D>())
        {
            temp.AddComponent<EnemyBeeton3D>();
        }

        EnemyBeeton3D component = temp.GetComponent<EnemyBeeton3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyBeeton3Ds"))
        {
            new GameObject("EnemyBeeton3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ActionType":
                    component.ActionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AfterMoveLength":
                    component.AfterMoveLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeed":
                    component.DashSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "HoveringType":
                    component.HoveringType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "IsOneShotOnOneWay":
                    component.IsOneShotOnOneWay = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "IsRevive":
                    component.IsRevive = bool.Parse(node.InnerText);
                    break;
                case "IsShotEnable":
                    component.IsShotEnable = bool.Parse(node.InnerText);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveWidth":
                    component.MoveWidth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ReviveTime":
                    component.ReviveTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotSpeed":
                    component.ShotSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetPosition":
                    component.TargetPosition = ReadPosition(node);
                    break;
                case "TurnTime":
                    component.TurnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WaitAfterShot":
                    component.WaitAfterShot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemyBeeton3D", "EnemyBeeton3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyBeeton3D", "EnemyBeeton3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyBeeton3D");
        }
    }
    private void ReadEnemyEChaserManager(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyEChaserManager>())
        {
            temp.AddComponent<EnemyEChaserManager>();
        }

        EnemyEChaserManager component = temp.GetComponent<EnemyEChaserManager>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyEChaserManagers"))
        {
            new GameObject("EnemyEChaserManagers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AirShipID":
                    component.AirShipID = int.Parse(node.InnerText);
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
                case "m_AttackSpanTime":
                    component.m_AttackSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ChaserParam.m_UpVectorByPath":
                    component.m_UpVectorByPath = bool.Parse(node.InnerText);
                    break;
                case "m_ChaserParam.m_WavingVelocity":
                    component.m_WavingVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_FlyHeight":
                    component.m_FlyHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_NumChasers":
                    component.m_NumChasers = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_NumSubChasers":
                    component.m_NumSubChasers = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyEChaserManager", "EnemyEChaserManagers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyEChaserManager", "EnemyEChaserManagers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyEChaserManager");
        }
    }
    private void ReadEnemyEFighter3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyEFighter3D>())
        {
            temp.AddComponent<EnemyEFighter3D>();
        }

        EnemyEFighter3D component = temp.GetComponent<EnemyEFighter3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyEFighter3Ds"))
        {
            new GameObject("EnemyEFighter3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BarrelID":
                    component.BarrelID = int.Parse(node.InnerText);
                    break;
                case "ChaserManagerID":
                    component.ChaserManagerID = int.Parse(node.InnerText);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "m_AttackMoveSpeedRatio":
                    component.m_AttackMoveSpeedRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ChargeTime":
                    component.m_ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ChaserModeVelocity":
                    component.m_ChaserModeVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_FindMotionType":
                    component.m_FindMotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsAllRangeSearch":
                    component.m_IsAllRangeSearch = bool.Parse(node.InnerText);
                    break;
                case "m_IsAttack":
                    component.m_IsAttack = bool.Parse(node.InnerText);
                    break;
                case "m_IsChaseAfter":
                    component.m_IsChaseAfter = bool.Parse(node.InnerText);
                    break;
                case "m_IsChaserMode":
                    component.m_IsChaserMode = bool.Parse(node.InnerText);
                    break;
                case "m_IsForceSmartTurn":
                    component.m_IsForceSmartTurn = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushBarrelMode":
                    component.m_IsPushBarrelMode = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushBarrelOnce":
                    component.m_IsPushBarrelOnce = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushDirRight":
                    component.m_IsPushDirRight = bool.Parse(node.InnerText);
                    break;
                case "m_IsRestrictMove":
                    component.m_IsRestrictMove = bool.Parse(node.InnerText);
                    break;
                case "m_LostTime":
                    component.m_LostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_MoveSpeedRatio":
                    component.m_MoveSpeedRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_PushBarrelSpanTime":
                    component.m_PushBarrelSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_SeekSpanTime":
                    component.m_SeekSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_TurnAccel":
                    component.m_TurnAccel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_WaitTime":
                    component.m_WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyEFighter3D", "EnemyEFighter3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyEFighter3D", "EnemyEFighter3Ds", position, rotation);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Can't Instantiate EnemyEFighter3D " + ex);
        }
    }
    private void ReadEnemyEFighterSword3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyEFighterSword3D>())
        {
            temp.AddComponent<EnemyEFighterSword3D>();
        }

        EnemyEFighterSword3D component = temp.GetComponent<EnemyEFighterSword3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyEFighterSword3Ds"))
        {
            new GameObject("EnemyEFighterSword3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackType":
                    component.AttackType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BarrelID":
                    component.BarrelID = int.Parse(node.InnerText);
                    break;
                case "ChaserManagerID":
                    component.ChaserManagerID = int.Parse(node.InnerText);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "m_AttackMoveSpeedRatio":
                    component.m_AttackMoveSpeedRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ChargeTime":
                    component.m_ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ChaserModeVelocity":
                    component.m_ChaserModeVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsAllRangeSearch":
                    component.m_IsAllRangeSearch = bool.Parse(node.InnerText);
                    break;
                case "m_IsAttack":
                    component.m_IsAttack = bool.Parse(node.InnerText);
                    break;
                case "m_IsChaseAfter":
                    component.m_IsChaseAfter = bool.Parse(node.InnerText);
                    break;
                case "m_IsChaserMode":
                    component.m_IsChaserMode = bool.Parse(node.InnerText);
                    break;
                case "m_IsForceSmartTurn":
                    component.m_IsForceSmartTurn = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushBarrelMode":
                    component.m_IsPushBarrelMode = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushBarrelOnce":
                    component.m_IsPushBarrelOnce = bool.Parse(node.InnerText);
                    break;
                case "m_IsPushDirRight":
                    component.m_IsPushDirRight = bool.Parse(node.InnerText);
                    break;
                case "m_IsRestrictMove":
                    component.m_IsRestrictMove = bool.Parse(node.InnerText);
                    break;
                case "m_LostTime":
                    component.m_LostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_MoveSpeedRatio":
                    component.m_MoveSpeedRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_PushBarrelSpanTime":
                    component.m_PushBarrelSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_SeekSpanTime":
                    component.m_SeekSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_TurnAccel":
                    component.m_TurnAccel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_WaitTime":
                    component.m_WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyEFighterSword3D", "EnemyEFighterSword3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyEFighterSword3D", "EnemyEFighterSword3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyEFighterSword3D");
        }
    }
    private void ReadEnemyELauncher3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyELauncher3D>())
        {
            temp.AddComponent<EnemyELauncher3D>();
        }

        EnemyELauncher3D component = temp.GetComponent<EnemyELauncher3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyELauncher3Ds"))
        {
            new GameObject("EnemyELauncher3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EquipType":
                    component.EquipType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "m_ChargeTime":
                    component.m_ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsFixRotate":
                    component.m_IsFixRotate = bool.Parse(node.InnerText);
                    break;
                case "m_NearAttackRange":
                    component.m_NearAttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyELauncher3D", "EnemyELauncher3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyELauncher3D", "EnemyELauncher3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyELauncher3D");
        }
    }
    private void ReadEnemyGanigani2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyGanigani2D>())
        {
            temp.AddComponent<EnemyGanigani2D>();
        }

        EnemyGanigani2D component = temp.GetComponent<EnemyGanigani2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyGanigani2Ds"))
        {
            new GameObject("EnemyGanigani2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DistanceMissile":
                    component.DistanceMissile = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DistanceStepMove":
                    component.DistanceStepMove = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChargeInPose":
                    component.IsChargeInPose = bool.Parse(node.InnerText);
                    break;
                case "IsContinueAttack":
                    component.IsContinueAttack = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsEnableAttack":
                    component.IsEnableAttack = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "IsSimpleAttack":
                    component.IsSimpleAttack = bool.Parse(node.InnerText);
                    break;
                case "IsTurnOver":
                    component.IsTurnOver = bool.Parse(node.InnerText);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SeekSpanTime":
                    component.SeekSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SpeedMissile":
                    component.SpeedMissile = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetLostTime":
                    component.TargetLostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetLostWaitTime":
                    component.TargetLostWaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TurnTime":
                    component.TurnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemyGanigani2D", "EnemyGanigani2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyGanigani2D", "EnemyGanigani2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyGanigani2D");
        }
    }
    private void ReadEnemyGanigani3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyGanigani3D>())
        {
            temp.AddComponent<EnemyGanigani3D>();
        }

        EnemyGanigani3D component = temp.GetComponent<EnemyGanigani3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyGanigani3Ds"))
        {
            new GameObject("EnemyGanigani3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DistanceMissile":
                    component.DistanceMissile = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DistanceStepMove":
                    component.DistanceStepMove = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChargeInPose":
                    component.IsChargeInPose = bool.Parse(node.InnerText);
                    break;
                case "IsContinueAttack":
                    component.IsContinueAttack = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsEnableAttack":
                    component.IsEnableAttack = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "IsSimpleAttack":
                    component.IsSimpleAttack = bool.Parse(node.InnerText);
                    break;
                case "IsTurnOver":
                    component.IsTurnOver = bool.Parse(node.InnerText);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SeekSpanTime":
                    component.SeekSpanTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SpeedMissile":
                    component.SpeedMissile = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetLostTime":
                    component.TargetLostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetLostWaitTime":
                    component.TargetLostWaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TurnTime":
                    component.TurnTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemyGanigani3D", "EnemyGanigani3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyGanigani3D", "EnemyGanigani3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyGanigani3D");
        }
    }
    private void ReadEnemyMotora2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyMotora2D>())
        {
            temp.AddComponent<EnemyMotora2D>();
        }

        EnemyMotora2D component = temp.GetComponent<EnemyMotora2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyMotora2Ds"))
        {
            new GameObject("EnemyMotora2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CliffHeight":
                    component.CliffHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeed":
                    component.DashSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeedType":
                    component.DashSpeedType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsEnableAttack":
                    component.IsEnableAttack = bool.Parse(node.InnerText);
                    break;
                case "IsPathMove":
                    component.IsPathMove = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "LookAroundTime":
                    component.LookAroundTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeedType":
                    component.MoveSpeedType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ReboundSpeed":
                    component.ReboundSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetLostTime":
                    component.TargetLostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TerrainCheckHeight":
                    component.TerrainCheckHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyMotora2D", "EnemyMotora2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyMotora2D", "EnemyMotora2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyMotora2D");
        }
    }
    private void ReadEnemyMotora3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyMotora3D>())
        {
            temp.AddComponent<EnemyMotora3D>();
        }

        EnemyMotora3D component = temp.GetComponent<EnemyMotora3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyMotora3Ds"))
        {
            new GameObject("EnemyMotora3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CliffHeight":
                    component.CliffHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeed":
                    component.DashSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DashSpeedType":
                    component.DashSpeedType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsEnableAttack":
                    component.IsEnableAttack = bool.Parse(node.InnerText);
                    break;
                case "IsPathMove":
                    component.IsPathMove = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "LookAroundTime":
                    component.LookAroundTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeedType":
                    component.MoveSpeedType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ReboundSpeed":
                    component.ReboundSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "TargetLostTime":
                    component.TargetLostTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TerrainCheckHeight":
                    component.TerrainCheckHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "EnemyMotora3D", "EnemyMotora3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyMotora3D", "EnemyMotora3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyMotora3D");
        }
    }
    private void ReadEnemyPawnPla2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyPawnPla2D>())
        {
            temp.AddComponent<EnemyPawnPla2D>();
        }

        EnemyPawnPla2D component = temp.GetComponent<EnemyPawnPla2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyPawnPla2Ds"))
        {
            new GameObject("EnemyPawnPla2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackMoveSpeed":
                    component.AttackMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackType":
                    component.AttackType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FarAttackRange":
                    component.FarAttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstState":
                    component.FirstState = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsNoWait":
                    component.IsNoWait = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "MoveSearchTime":
                    component.MoveSearchTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PickChargeTime":
                    component.PickChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PickDistance":
                    component.PickDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PickSwing":
                    component.PickSwing = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PickThrowTime":
                    component.PickThrowTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "fallGravRate":
                    component.fallGravRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "fallSpeed":
                    component.fallSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "isAttackMove":
                    component.isAttackMove = bool.Parse(node.InnerText);
                    break;
                case "isFallDown":
                    component.isFallDown = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EnemyPawnPla2D", "EnemyPawnPla2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyPawnPla2D", "EnemyPawnPla2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyPawnPla2D");
        }
    }
    private void ReadEnemySpanner(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemySpanner>())
        {
            temp.AddComponent<EnemySpanner>();
        }

        EnemySpanner component = temp.GetComponent<EnemySpanner>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemySpanners"))
        {
            new GameObject("EnemySpanners");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearPattern":
                    component.AppearPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearPoint":
                    component.AppearPoint = ReadPosition(node);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Exec":
                    component.ElecTime_Exec = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Interval":
                    component.ElecTime_Interval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Pre":
                    component.ElecTime_Pre = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsLookPlayer":
                    component.IsLookPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsWaitElec":
                    component.IsWaitElec = bool.Parse(node.InnerText);
                    break;
                case "MovePattern":
                    component.MovePattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPattern":
                    component.RebirthPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPoint":
                    component.RebirthPoint = ReadPosition(node);
                    break;
                case "RebirthTime":
                    component.RebirthTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemySpanner", "EnemySpanners");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemySpanner", "EnemySpanners", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemySpanner");
        }
    }
    private void ReadEnemySpinner(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemySpinner>())
        {
            temp.AddComponent<EnemySpinner>();
        }

        EnemySpinner component = temp.GetComponent<EnemySpinner>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemySpinners"))
        {
            new GameObject("EnemySpinners");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearPattern":
                    component.AppearPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearPoint":
                    component.AppearPoint = ReadPosition(node);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsLookPlayer":
                    component.IsLookPlayer = bool.Parse(node.InnerText);
                    break;
                case "MovePattern":
                    component.MovePattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPattern":
                    component.RebirthPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPoint":
                    component.RebirthPoint = ReadPosition(node);
                    break;
                case "RebirthTime":
                    component.RebirthTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemySpinner", "EnemySpinners");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemySpinner", "EnemySpinners", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemySpinner");
        }
    }
    private void ReadEnemySpinner2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemySpinner2D>())
        {
            temp.AddComponent<EnemySpinner2D>();
        }

        EnemySpinner2D component = temp.GetComponent<EnemySpinner2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemySpinner2Ds"))
        {
            new GameObject("EnemySpinner2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearPattern":
                    component.AppearPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearPoint":
                    component.AppearPoint = ReadPosition(node);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsLookPlayer":
                    component.IsLookPlayer = bool.Parse(node.InnerText);
                    break;
                case "MovePattern":
                    component.MovePattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPattern":
                    component.RebirthPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPoint":
                    component.RebirthPoint = ReadPosition(node);
                    break;
                case "RebirthTime":
                    component.RebirthTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemySpinner2D", "EnemySpinner2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemySpinner2D", "EnemySpinner2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemySpinner2D");
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
    private void ReadChangeMode_3DtoDash(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeMode_3DtoDash>())
        {
            temp.AddComponent<ChangeMode_3DtoDash>();
        }

        ChangeMode_3DtoDash component = temp.GetComponent<ChangeMode_3DtoDash>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeMode_3DtoDashs"))
        {
            new GameObject("ChangeMode_3DtoDashs");
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
                case "Template":
                    component.Template = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_CurveCorrectionForce":
                    component.m_CurveCorrectionForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "m_IsLimitEdge":
                    component.m_IsLimitEdge = bool.Parse(node.InnerText);
                    break;
                case "m_IsReverseCameraEnable":
                    component.m_IsReverseCameraEnable = bool.Parse(node.InnerText);
                    break;
                case "m_PathCorrectionForce":
                    component.m_PathCorrectionForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ChangeMode_3DtoDash", "ChangeMode_3DtoDashs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeMode_3DtoDash", "ChangeMode_3DtoDashs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeMode_3DtoDash");
        }
    }
    private void ReadChangeMode_3DtoForward(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeMode_3DtoForward>())
        {
            temp.AddComponent<ChangeMode_3DtoForward>();
        }

        ChangeMode_3DtoForward component = temp.GetComponent<ChangeMode_3DtoForward>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeMode_3DtoForwards"))
        {
            new GameObject("ChangeMode_3DtoForwards");
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
                case "Template":
                    component.Template = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_CurveCorrectionForce":
                    component.m_CurveCorrectionForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_DashPathSideMoveRate":
                    component.m_DashPathSideMoveRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsChangeCamera":
                    component.m_IsChangeCamera = bool.Parse(node.InnerText);
                    break;
                case "m_IsEnableAirBoost":
                    component.m_IsEnableAirBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsEnableFromBack":
                    component.m_IsEnableFromBack = bool.Parse(node.InnerText);
                    break;
                case "m_IsEnableFromFront":
                    component.m_IsEnableFromFront = bool.Parse(node.InnerText);
                    break;
                case "m_IsGravityControl":
                    component.m_IsGravityControl = bool.Parse(node.InnerText);
                    break;
                case "m_IsLimitEdge":
                    component.m_IsLimitEdge = bool.Parse(node.InnerText);
                    break;
                case "m_IsReverseCameraEnable":
                    component.m_IsReverseCameraEnable = bool.Parse(node.InnerText);
                    break;
                case "m_PathCorrectionForce":
                    component.m_PathCorrectionForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ChangeMode_3DtoForward", "ChangeMode_3DtoForwards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeMode_3DtoForward", "ChangeMode_3DtoForwards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeMode_3DtoForward");
        }
    }

    //Sounds
    private void ReadSoundLine(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SoundLine>())
        {
            temp.AddComponent<SoundLine>();
        }

        SoundLine component = temp.GetComponent<SoundLine>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SoundLines"))
        {
            new GameObject("SoundLines");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseVolume":
                    component.BaseVolume = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "FileName":
                    component.FileName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalTime":
                    component.IntervalTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsRegularly":
                    component.IsRegularly = bool.Parse(node.InnerText);
                    break;
                //case "PositionList":
                //    component.PositionList = vector_list.Parse(node.InnerText);
                //    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SoundLine", "SoundLines");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SoundLine", "SoundLines", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SoundLine");
        }
    }
    private void ReadSoundPoint(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SoundPoint>())
        {
            temp.AddComponent<SoundPoint>();
        }

        SoundPoint component = temp.GetComponent<SoundPoint>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SoundPoints"))
        {
            new GameObject("SoundPoints");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseVolume":
                    component.BaseVolume = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "FileName":
                    component.FileName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InsideRadius":
                    component.InsideRadius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalTime":
                    component.IntervalTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsRegularly":
                    component.IsRegularly = bool.Parse(node.InnerText);
                    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SoundPoint", "SoundPoints");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SoundPoint", "SoundPoints", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SoundPoint");
        }
    }

    //Unassigned
    private void ReadCannon(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Cannon>())
        {
            temp.AddComponent<Cannon>();
        }

        Cannon component = temp.GetComponent<Cannon>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Cannons"))
        {
            new GameObject("Cannons");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AutoShot":
                    component.AutoShot = bool.Parse(node.InnerText);
                    break;
                case "BaseVel":
                    component.BaseVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraEaseTime_Enter":
                    component.CameraEaseTime_Enter = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraEaseTime_Keep":
                    component.CameraEaseTime_Keep = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraEaseTime_Leave":
                    component.CameraEaseTime_Leave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraID":
                    component.CameraID = int.Parse(node.InnerText);
                    break;
                case "DstPos":
                    component.DstPos = ReadPosition(node);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "ModeChange":
                    component.ModeChange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveBarrel":
                    component.MoveBarrel = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StaticPercent":
                    component.StaticPercent = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UseFloorModel":
                    component.UseFloorModel = bool.Parse(node.InnerText);
                    break;
                case "VelRatio":
                    component.VelRatio = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Cannon", "Cannons");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Cannon", "Cannons", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Cannon");
        }
    }
    private void ReadChangeLightScatteringVolume(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeLightScatteringVolume>())
        {
            temp.AddComponent<ChangeLightScatteringVolume>();
        }

        ChangeLightScatteringVolume component = temp.GetComponent<ChangeLightScatteringVolume>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeLightScatteringVolumes"))
        {
            new GameObject("ChangeLightScatteringVolumes");
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
                case "ColorB":
                    component.ColorB = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ColorG":
                    component.ColorG = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ColorR":
                    component.ColorR = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DefaultStatus":
                    component.DefaultStatus = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Density":
                    component.Density = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DepthScale":
                    component.DepthScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EaseTime":
                    component.EaseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Far":
                    component.Far = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCommon":
                    component.IsChangeCommon = bool.Parse(node.InnerText);
                    break;
                case "IsChangeFog":
                    component.IsChangeFog = bool.Parse(node.InnerText);
                    break;
                case "IsChangeLightScattering":
                    component.IsChangeLightScattering = bool.Parse(node.InnerText);
                    break;
                case "Mie":
                    component.Mie = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MieP":
                    component.MieP = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Mode":
                    component.Mode = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Near":
                    component.Near = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Rayleigh":
                    component.Rayleigh = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScatteringScale":
                    component.ScatteringScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ChangeLightScatteringVolume", "ChangeLightScatteringVolumes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeLightScatteringVolume", "ChangeLightScatteringVolumes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeLightScatteringVolume");
        }
    }
    private void ReadClassicDashPanel(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ClassicDashPanel>())
        {
            temp.AddComponent<ClassicDashPanel>();
        }

        ClassicDashPanel component = temp.GetComponent<ClassicDashPanel>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ClassicDashPanels"))
        {
            new GameObject("ClassicDashPanels");
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
                    ReadMultiSetParam(component, node, "ClassicDashPanel", "ClassicDashPanels");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ClassicDashPanel", "ClassicDashPanels", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ClassicDashPanel");
        }
    }
    private void ReadClassicJumpBoard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ClassicJumpBoard>())
        {
            temp.AddComponent<ClassicJumpBoard>();
        }

        ClassicJumpBoard component = temp.GetComponent<ClassicJumpBoard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ClassicJumpBoards"))
        {
            new GameObject("ClassicJumpBoards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ClassicJumpAngleOnBoost":
                    component.ClassicJumpAngleOnBoost = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ClassicJumpAngleOnNormal":
                    component.ClassicJumpAngleOnNormal = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_ClassicSpinThreshold":
                    component.m_ClassicSpinThreshold = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ClassicJumpBoard", "ClassicJumpBoards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ClassicJumpBoard", "ClassicJumpBoards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ClassicJumpBoard");
        }
    }
    private void ReadEnemyPawn2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyPawn2D>())
        {
            temp.AddComponent<EnemyPawn2D>();
        }

        EnemyPawn2D component = temp.GetComponent<EnemyPawn2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyPawn2Ds"))
        {
            new GameObject("EnemyPawn2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackMoveSpeed":
                    component.AttackMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "MoveSearchTime":
                    component.MoveSearchTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "fallGravRate":
                    component.fallGravRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "fallSpeed":
                    component.fallSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "isAttackMove":
                    component.isAttackMove = bool.Parse(node.InnerText);
                    break;
                case "isFallDown":
                    component.isFallDown = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EnemyPawn2D", "EnemyPawn2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyPawn2D", "EnemyPawn2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyPawn2D");
        }
    }
    private void ReadEnemyPawnGun2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyPawnGun2D>())
        {
            temp.AddComponent<EnemyPawnGun2D>();
        }

        EnemyPawnGun2D component = temp.GetComponent<EnemyPawnGun2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyPawnGun2Ds"))
        {
            new GameObject("EnemyPawnGun2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackMoveSpeed":
                    component.AttackMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackNum":
                    component.AttackNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletLifeTime":
                    component.BulletLifeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletNum":
                    component.BulletNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletSpeed":
                    component.BulletSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsJoy":
                    component.IsJoy = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "MoveSearchTime":
                    component.MoveSearchTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotInterval":
                    component.ShotInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "fallGravRate":
                    component.fallGravRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "fallSpeed":
                    component.fallSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "isAttackMove":
                    component.isAttackMove = bool.Parse(node.InnerText);
                    break;
                case "isFallDown":
                    component.isFallDown = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EnemyPawnGun2D", "EnemyPawnGun2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyPawnGun2D", "EnemyPawnGun2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyPawnGun2D");
        }
    }
    private void ReadEnemyPawnGun3D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyPawnGun3D>())
        {
            temp.AddComponent<EnemyPawnGun3D>();
        }

        EnemyPawnGun3D component = temp.GetComponent<EnemyPawnGun3D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyPawnGun3Ds"))
        {
            new GameObject("EnemyPawnGun3Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackMoveSpeed":
                    component.AttackMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackNum":
                    component.AttackNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletLifeTime":
                    component.BulletLifeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletNum":
                    component.BulletNum = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BulletSpeed":
                    component.BulletSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsJoy":
                    component.IsJoy = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "MoveSearchTime":
                    component.MoveSearchTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotInterval":
                    component.ShotInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "fallGravRate":
                    component.fallGravRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "fallSpeed":
                    component.fallSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "isAttackMove":
                    component.isAttackMove = bool.Parse(node.InnerText);
                    break;
                case "isFallDown":
                    component.isFallDown = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EnemyPawnGun3D", "EnemyPawnGun3Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyPawnGun3D", "EnemyPawnGun3Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyPawnGun3D");
        }
    }
    private void ReadEnemyPawnLance2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemyPawnLance2D>())
        {
            temp.AddComponent<EnemyPawnLance2D>();
        }

        EnemyPawnLance2D component = temp.GetComponent<EnemyPawnLance2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemyPawnLance2Ds"))
        {
            new GameObject("EnemyPawnLance2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ActionRange":
                    component.ActionRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackMoveSpeed":
                    component.AttackMoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRange":
                    component.AttackRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChargeTime":
                    component.ChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsAimTarget":
                    component.IsAimTarget = bool.Parse(node.InnerText);
                    break;
                case "IsArrivalEffect":
                    component.IsArrivalEffect = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsDamageFromOnlyPlayer":
                    component.IsDamageFromOnlyPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsPlayFindMotion":
                    component.IsPlayFindMotion = bool.Parse(node.InnerText);
                    break;
                case "MoveSearchTime":
                    component.MoveSearchTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveSpeed":
                    component.MoveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SearchType":
                    component.SearchType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = ReadPosition(node);
                    break;
                case "WaitTime":
                    component.WaitTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
                    break;
                case "fallGravRate":
                    component.fallGravRate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "fallSpeed":
                    component.fallSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "isAttackMove":
                    component.isAttackMove = bool.Parse(node.InnerText);
                    break;
                case "isFallDown":
                    component.isFallDown = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EnemyPawnLance2D", "EnemyPawnLance2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemyPawnLance2D", "EnemyPawnLance2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemyPawnLance2D");
        }
    }
    private void ReadEnemySpanner2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EnemySpanner2D>())
        {
            temp.AddComponent<EnemySpanner2D>();
        }

        EnemySpanner2D component = temp.GetComponent<EnemySpanner2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EnemySpanner2Ds"))
        {
            new GameObject("EnemySpanner2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearPattern":
                    component.AppearPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearPoint":
                    component.AppearPoint = ReadPosition(node);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Exec":
                    component.ElecTime_Exec = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Interval":
                    component.ElecTime_Interval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ElecTime_Pre":
                    component.ElecTime_Pre = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsLookPlayer":
                    component.IsLookPlayer = bool.Parse(node.InnerText);
                    break;
                case "IsWaitElec":
                    component.IsWaitElec = bool.Parse(node.InnerText);
                    break;
                case "MovePattern":
                    component.MovePattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveVel":
                    component.MoveVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPattern":
                    component.RebirthPattern = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RebirthPoint":
                    component.RebirthPoint = ReadPosition(node);
                    break;
                case "RebirthTime":
                    component.RebirthTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WayPointA":
                    component.WayPointA = ReadPosition(node);
                    break;
                case "WayPointB":
                    component.WayPointB = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "EnemySpanner2D", "EnemySpanner2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EnemySpanner2D", "EnemySpanner2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EnemySpanner2D");
        }
    }
    private void ReadFan(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Fan>())
        {
            temp.AddComponent<Fan>();
        }

        Fan component = temp.GetComponent<Fan>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Fans"))
        {
            new GameObject("Fans");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Base":
                    component.Base = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IgnoreTime":
                    component.IgnoreTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBDE":
                    component.IsBDE = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsOneShot":
                    component.IsOneShot = bool.Parse(node.InnerText);
                    break;
                case "JumpVel":
                    component.JumpVel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "KeepHeight":
                    component.KeepHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Place":
                    component.Place = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time_Off":
                    component.Time_Off = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time_On":
                    component.Time_On = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time_Wait":
                    component.Time_Wait = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrgHeight":
                    component.TrgHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UseLoopSE":
                    component.UseLoopSE = bool.Parse(node.InnerText);
                    break;
                case "UseModel":
                    component.UseModel = bool.Parse(node.InnerText);
                    break;
                case "WakeStart":
                    component.WakeStart = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "Fan", "Fans");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Fan", "Fans", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Fan");
        }
    }
    private void ReadObjCameraFix(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraFix>())
        {
            temp.AddComponent<ObjCameraFix>();
        }

        ObjCameraFix component = temp.GetComponent<ObjCameraFix>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraFixs"))
        {
            new GameObject("ObjCameraFixs");
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
                case "TargetPosition":
                    component.TargetPosition = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "ObjCameraFix", "ObjCameraFixs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraFix", "ObjCameraFixs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraFix");
        }
    }
    private void ReadSpringClassic(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SpringClassic>())
        {
            temp.AddComponent<SpringClassic>();
        }

        SpringClassic component = temp.GetComponent<SpringClassic>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SpringClassics"))
        {
            new GameObject("SpringClassics");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AimDirection":
                    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsSideSet":
                    component.IsSideSet = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionType":
                    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TreasureSearchHideType":
                    component.TreasureSearchHideType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsConstantFrame":
                    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                    break;
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHunting":
                    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                    break;
                case "m_IsStopBoost":
                    component.m_IsStopBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsTo3D":
                    component.m_IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "m_MonkeyTarget":
                    component.m_MonkeyTarget = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "SpringClassic", "SpringClassics");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SpringClassic", "SpringClassics", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SpringClassic");
        }
    }
    private void ReadSpringClassicYellow(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SpringClassicYellow>())
        {
            temp.AddComponent<SpringClassicYellow>();
        }

        SpringClassicYellow component = temp.GetComponent<SpringClassicYellow>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SpringClassicYellows"))
        {
            new GameObject("SpringClassicYellows");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AimDirection":
                    component.AimDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBreak":
                    component.IsBreak = bool.Parse(node.InnerText);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsHomingAttackEnable":
                    component.IsHomingAttackEnable = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsSideSet":
                    component.IsSideSet = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionType":
                    component.MotionType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TreasureSearchHideType":
                    component.TreasureSearchHideType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_IsConstantFrame":
                    component.m_IsConstantFrame = bool.Parse(node.InnerText);
                    break;
                case "m_IsConstantPosition":
                    component.m_IsConstantPosition = bool.Parse(node.InnerText);
                    break;
                case "m_IsMonkeyHunting":
                    component.m_IsMonkeyHunting = bool.Parse(node.InnerText);
                    break;
                case "m_IsStopBoost":
                    component.m_IsStopBoost = bool.Parse(node.InnerText);
                    break;
                case "m_IsTo3D":
                    component.m_IsTo3D = bool.Parse(node.InnerText);
                    break;
                case "m_MonkeyTarget":
                    component.m_MonkeyTarget = ReadPosition(node);
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
                    ReadMultiSetParam(component, node, "SpringClassicYellow", "SpringClassicYellows");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SpringClassicYellow", "SpringClassicYellows", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SpringClassicYellow");
        }
    }
    private void ReadSwitch(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Switch>())
        {
            temp.AddComponent<Switch>();
        }

        Switch component = temp.GetComponent<Switch>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Switchs"))
        {
            new GameObject("Switchs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "EventOFF":
                    component.EventOFF = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EventON":
                    component.EventON = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "IsMoveCollision":
                    component.IsMoveCollision = bool.Parse(node.InnerText);
                    break;
                case "IsPrimitiveCollision":
                    component.IsPrimitiveCollision = bool.Parse(node.InnerText);
                    break;
                case "OffTimer":
                    component.OffTimer = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "TargetListOFF":
                //    component.TargetListOFF = undefined.Parse(node.InnerText);
                //    break;
                //case "TargetListON":
                //    component.TargetListON = id_list.Parse(node.InnerText);
                //    break;
                case "TimerOFF":
                    component.TimerOFF = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TimerON":
                    component.TimerON = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Switch", "Switchs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Switch", "Switchs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Switch");
        }
    }
    private void ReadTest(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Test>())
        {
            temp.AddComponent<Test>();
        }

        Test component = temp.GetComponent<Test>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Tests"))
        {
            new GameObject("Tests");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
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
                    ReadMultiSetParam(component, node, "Test", "Tests");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Test", "Tests", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Test");
        }
    }
    private void ReadThornBall(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ThornBall>())
        {
            temp.AddComponent<ThornBall>();
        }

        ThornBall component = temp.GetComponent<ThornBall>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ThornBalls"))
        {
            new GameObject("ThornBalls");
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
                    ReadMultiSetParam(component, node, "ThornBall", "ThornBalls");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ThornBall", "ThornBalls", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ThornBall");
        }
    }

    //Unleashed
    private void ReadBeachFallFloor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFallFloor>())
        {
            temp.AddComponent<BeachFallFloor>();
        }

        BeachFallFloor component = temp.GetComponent<BeachFallFloor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFallFloors"))
        {
            new GameObject("BeachFallFloors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFallFloor", "BeachFallFloors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFallFloor", "BeachFallFloors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFallFloor");
        }
    }
    private void ReadBeachFlagA(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFlagA>())
        {
            temp.AddComponent<BeachFlagA>();
        }

        BeachFlagA component = temp.GetComponent<BeachFlagA>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFlagAs"))
        {
            new GameObject("BeachFlagAs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFlagA", "BeachFlagAs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFlagA", "BeachFlagAs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFlagA");
        }
    }
    private void ReadBeachFlagB(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFlagB>())
        {
            temp.AddComponent<BeachFlagB>();
        }

        BeachFlagB component = temp.GetComponent<BeachFlagB>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFlagBs"))
        {
            new GameObject("BeachFlagBs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFlagB", "BeachFlagBs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFlagB", "BeachFlagBs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFlagB");
        }
    }
    private void ReadBeachFlagC(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFlagC>())
        {
            temp.AddComponent<BeachFlagC>();
        }

        BeachFlagC component = temp.GetComponent<BeachFlagC>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFlagCs"))
        {
            new GameObject("BeachFlagCs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFlagC", "BeachFlagCs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFlagC", "BeachFlagCs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFlagC");
        }
    }
    private void ReadBeachFlagD(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFlagD>())
        {
            temp.AddComponent<BeachFlagD>();
        }

        BeachFlagD component = temp.GetComponent<BeachFlagD>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFlagDs"))
        {
            new GameObject("BeachFlagDs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFlagD", "BeachFlagDs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFlagD", "BeachFlagDs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFlagD");
        }
    }
    private void ReadBeachFloorA(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFloorA>())
        {
            temp.AddComponent<BeachFloorA>();
        }

        BeachFloorA component = temp.GetComponent<BeachFloorA>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFloorAs"))
        {
            new GameObject("BeachFloorAs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "GroundOffset":
                //    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                //    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFloorA", "BeachFloorAs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFloorA", "BeachFloorAs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFloorA");
        }
    }
    private void ReadBeachFloorB(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFloorB>())
        {
            temp.AddComponent<BeachFloorB>();
        }

        BeachFloorB component = temp.GetComponent<BeachFloorB>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFloorBs"))
        {
            new GameObject("BeachFloorBs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFloorB", "BeachFloorBs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFloorB", "BeachFloorBs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFloorB");
        }
    }
    private void ReadBeachFloorC(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachFloorC>())
        {
            temp.AddComponent<BeachFloorC>();
        }

        BeachFloorC component = temp.GetComponent<BeachFloorC>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachFloorCs"))
        {
            new GameObject("BeachFloorCs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachFloorC", "BeachFloorCs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachFloorC", "BeachFloorCs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachFloorC");
        }
    }
    private void ReadBeachMoveFloorA(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachMoveFloorA>())
        {
            temp.AddComponent<BeachMoveFloorA>();
        }

        BeachMoveFloorA component = temp.GetComponent<BeachMoveFloorA>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachMoveFloorAs"))
        {
            new GameObject("BeachMoveFloorAs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachMoveFloorA", "BeachMoveFloorAs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachMoveFloorA", "BeachMoveFloorAs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachMoveFloorA");
        }
    }
    private void ReadBeachMoveFloorB(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BeachMoveFloorB>())
        {
            temp.AddComponent<BeachMoveFloorB>();
        }

        BeachMoveFloorB component = temp.GetComponent<BeachMoveFloorB>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BeachMoveFloorBs"))
        {
            new GameObject("BeachMoveFloorBs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BeachMoveFloorB", "BeachMoveFloorBs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BeachMoveFloorB", "BeachMoveFloorBs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BeachMoveFloorB");
        }
    }
    private void ReadBeach_BreakBridge(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_BreakBridge>())
        {
            temp.AddComponent<Beach_BreakBridge>();
        }

        Beach_BreakBridge component = temp.GetComponent<Beach_BreakBridge>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_BreakBridges"))
        {
            new GameObject("Beach_BreakBridges");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShakeTime":
                    component.ShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_BreakBridge", "Beach_BreakBridges");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_BreakBridge", "Beach_BreakBridges", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_BreakBridge");
        }
    }
    private void ReadBeach_Buoy(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_Buoy>())
        {
            temp.AddComponent<Beach_Buoy>();
        }

        Beach_Buoy component = temp.GetComponent<Beach_Buoy>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_Buoys"))
        {
            new GameObject("Beach_Buoys");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutControl":
                    component.OutControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_Buoy", "Beach_Buoys");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_Buoy", "Beach_Buoys", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_Buoy");
        }
    }
    private void ReadBeach_Door(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_Door>())
        {
            temp.AddComponent<Beach_Door>();
        }

        Beach_Door component = temp.GetComponent<Beach_Door>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_Doors"))
        {
            new GameObject("Beach_Doors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_Door", "Beach_Doors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_Door", "Beach_Doors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_Door");
        }
    }
    private void ReadBeach_FallPillar(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_FallPillar>())
        {
            temp.AddComponent<Beach_FallPillar>();
        }

        Beach_FallPillar component = temp.GetComponent<Beach_FallPillar>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_FallPillars"))
        {
            new GameObject("Beach_FallPillars");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownSpeed0":
                    component.DownSpeed0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownSpeed1":
                    component.DownSpeed1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownSpeed2":
                    component.DownSpeed2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownSpeed3":
                    component.DownSpeed3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_FallPillar", "Beach_FallPillars");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_FallPillar", "Beach_FallPillars", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_FallPillar");
        }
    }
    private void ReadBeach_FlashFlood(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_FlashFlood>())
        {
            temp.AddComponent<Beach_FlashFlood>();
        }

        Beach_FlashFlood component = temp.GetComponent<Beach_FlashFlood>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_FlashFloods"))
        {
            new GameObject("Beach_FlashFloods");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "HeraldTime":
                    component.HeraldTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IdleTime":
                    component.IdleTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ModelType":
                    component.ModelType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotTime":
                    component.ShotTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_FlashFlood", "Beach_FlashFloods");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_FlashFlood", "Beach_FlashFloods", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_FlashFlood");
        }
    }
    private void ReadBeach_Guillotine(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_Guillotine>())
        {
            temp.AddComponent<Beach_Guillotine>();
        }

        Beach_Guillotine component = temp.GetComponent<Beach_Guillotine>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_Guillotines"))
        {
            new GameObject("Beach_Guillotines");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_Guillotine", "Beach_Guillotines");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_Guillotine", "Beach_Guillotines", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_Guillotine");
        }
    }
    private void ReadBeach_MotionDoor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_MotionDoor>())
        {
            temp.AddComponent<Beach_MotionDoor>();
        }

        Beach_MotionDoor component = temp.GetComponent<Beach_MotionDoor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_MotionDoors"))
        {
            new GameObject("Beach_MotionDoors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstState":
                    component.FirstState = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_MotionDoor", "Beach_MotionDoors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_MotionDoor", "Beach_MotionDoors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_MotionDoor");
        }
    }
    private void ReadBeach_PressThorn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_PressThorn>())
        {
            temp.AddComponent<Beach_PressThorn>();
        }

        Beach_PressThorn component = temp.GetComponent<Beach_PressThorn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_PressThorns"))
        {
            new GameObject("Beach_PressThorns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BottomStopTime":
                    component.BottomStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownTime":
                    component.DownTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "IsMoveable":
                    component.IsMoveable = bool.Parse(node.InnerText);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TopStoptime":
                    component.TopStoptime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpDownWidth":
                    component.UpDownWidth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpTime":
                    component.UpTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_PressThorn", "Beach_PressThorns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_PressThorn", "Beach_PressThorns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_PressThorn");
        }
    }
    private void ReadBeach_PressThornHalf(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_PressThornHalf>())
        {
            temp.AddComponent<Beach_PressThornHalf>();
        }

        Beach_PressThornHalf component = temp.GetComponent<Beach_PressThornHalf>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_PressThornHalfs"))
        {
            new GameObject("Beach_PressThornHalfs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BottomStopTime":
                    component.BottomStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownTime":
                    component.DownTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsMessageOn":
                    component.IsMessageOn = bool.Parse(node.InnerText);
                    break;
                case "IsMoveable":
                    component.IsMoveable = bool.Parse(node.InnerText);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TopStoptime":
                    component.TopStoptime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpDownWidth":
                    component.UpDownWidth = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpTime":
                    component.UpTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_PressThornHalf", "Beach_PressThornHalfs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_PressThornHalf", "Beach_PressThornHalfs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_PressThornHalf");
        }
    }
    private void ReadBeach_ThornBar(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_ThornBar>())
        {
            temp.AddComponent<Beach_ThornBar>();
        }

        Beach_ThornBar component = temp.GetComponent<Beach_ThornBar>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_ThornBars"))
        {
            new GameObject("Beach_ThornBars");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_ThornBar", "Beach_ThornBars");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_ThornBar", "Beach_ThornBars", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_ThornBar");
        }
    }
    private void ReadBeach_ThornPillar(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_ThornPillar>())
        {
            temp.AddComponent<Beach_ThornPillar>();
        }

        Beach_ThornPillar component = temp.GetComponent<Beach_ThornPillar>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_ThornPillars"))
        {
            new GameObject("Beach_ThornPillars");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveLength":
                    component.MoveLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Num":
                    component.Num = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_ThornPillar", "Beach_ThornPillars");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_ThornPillar", "Beach_ThornPillars", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_ThornPillar");
        }
    }
    private void ReadBeach_UpFloor(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_UpFloor>())
        {
            temp.AddComponent<Beach_UpFloor>();
        }

        Beach_UpFloor component = temp.GetComponent<Beach_UpFloor>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_UpFloors"))
        {
            new GameObject("Beach_UpFloors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StopTime":
                    component.StopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpSpeed":
                    component.UpSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_UpFloor", "Beach_UpFloors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_UpFloor", "Beach_UpFloors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_UpFloor");
        }
    }
    private void ReadBeach_WaterColumn(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Beach_WaterColumn>())
        {
            temp.AddComponent<Beach_WaterColumn>();
        }

        Beach_WaterColumn component = temp.GetComponent<Beach_WaterColumn>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Beach_WaterColumns"))
        {
            new GameObject("Beach_WaterColumns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DamageTime":
                    component.DamageTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EffectType":
                    component.EffectType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Height":
                    component.Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Beach_WaterColumn", "Beach_WaterColumns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Beach_WaterColumn", "Beach_WaterColumns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Beach_WaterColumn");
        }
    }
    private void ReadBobsleigh(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Bobsleigh>())
        {
            temp.AddComponent<Bobsleigh>();
        }

        Bobsleigh component = temp.GetComponent<Bobsleigh>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Bobsleighs"))
        {
            new GameObject("Bobsleighs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
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
                    ReadMultiSetParam(component, node, "Bobsleigh", "Bobsleighs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Bobsleigh", "Bobsleighs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Bobsleigh");
        }
    }
    private void ReadBobsleighEndCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<BobsleighEndCollision>())
        {
            temp.AddComponent<BobsleighEndCollision>();
        }

        BobsleighEndCollision component = temp.GetComponent<BobsleighEndCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("BobsleighEndCollisions"))
        {
            new GameObject("BobsleighEndCollisions");
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
                case "JumpAngle":
                    component.JumpAngle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeaveType":
                    component.LeaveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UncontrollableTime":
                    component.UncontrollableTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Velocity":
                    component.Velocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "BobsleighEndCollision", "BobsleighEndCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "BobsleighEndCollision", "BobsleighEndCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate BobsleighEndCollision");
        }
    }
    private void ReadChangeCamera2D_Begin(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ChangeCamera2D_Begin>())
        {
            temp.AddComponent<ChangeCamera2D_Begin>();
        }

        ChangeCamera2D_Begin component = temp.GetComponent<ChangeCamera2D_Begin>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ChangeCamera2D_Begins"))
        {
            new GameObject("ChangeCamera2D_Begins");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseSpacePathPosition":
                    component.BaseSpacePathPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Height":
                    component.Collision_Height = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Collision_Width":
                    component.Collision_Width = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Ease_Time":
                    component.Ease_Time = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ID":
                    component.ID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBaseSpacePlayer":
                    component.IsBaseSpacePlayer = bool.Parse(node.InnerText);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsPositionBasePlayer":
                    component.IsPositionBasePlayer = bool.Parse(node.InnerText);
                    break;
                case "Rotation_Y":
                    component.Rotation_Y = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Rotation_Z":
                    component.Rotation_Z = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Bias":
                    component.Target_Front_Offset_Bias = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Max":
                    component.Target_Front_Offset_Max = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Speed_Scale":
                    component.Target_Front_Offset_Speed_Scale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Up_Offset":
                    component.Target_Up_Offset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ChangeCamera2D_Begin", "ChangeCamera2D_Begins");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ChangeCamera2D_Begin", "ChangeCamera2D_Begins", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ChangeCamera2D_Begin");
        }
    }
    private void ReadeAirCannonGold(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eAirCannonGold>())
        {
            temp.AddComponent<eAirCannonGold>();
        }

        eAirCannonGold component = temp.GetComponent<eAirCannonGold>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eAirCannonGolds"))
        {
            new GameObject("eAirCannonGolds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Interval":
                    component.Interval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LifeTime":
                    component.LifeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumBullet":
                    component.NumBullet = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumShotOneTime":
                    component.NumShotOneTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusAction":
                    component.RadiusAction = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusSearch":
                    component.RadiusSearch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotType":
                    component.ShotType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ViewAngleTate":
                    component.ViewAngleTate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ViewAngleYoko":
                    component.ViewAngleYoko = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eAirCannonGold", "eAirCannonGolds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eAirCannonGold", "eAirCannonGolds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eAirCannonGold");
        }
    }
    private void ReadeAirCannonNormal(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eAirCannonNormal>())
        {
            temp.AddComponent<eAirCannonNormal>();
        }

        eAirCannonNormal component = temp.GetComponent<eAirCannonNormal>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eAirCannonNormals"))
        {
            new GameObject("eAirCannonNormals");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Interval":
                    component.Interval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumBullet":
                    component.NumBullet = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumShotOneTime":
                    component.NumShotOneTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusAction":
                    component.RadiusAction = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusSearch":
                    component.RadiusSearch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotType":
                    component.ShotType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ViewAngleTate":
                    component.ViewAngleTate = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ViewAngleYoko":
                    component.ViewAngleYoko = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eAirCannonNormal", "eAirCannonNormals");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eAirCannonNormal", "eAirCannonNormals", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eAirCannonNormal");
        }
    }
    private void ReadeAirChaser(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eAirChaser>())
        {
            temp.AddComponent<eAirChaser>();
        }

        eAirChaser component = temp.GetComponent<eAirChaser>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eAirChasers"))
        {
            new GameObject("eAirChasers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AirChaser_01":
                    component.AirChaser_01 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AirChaser_02":
                    component.AirChaser_02 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AirChaser_03":
                    component.AirChaser_03 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearOffset":
                    component.AppearOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearVelocityL":
                    component.AppearVelocityL = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "HeightFromPath":
                    component.HeightFromPath = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsEndAnnihilation":
                    component.IsEndAnnihilation = bool.Parse(node.InnerText);
                    break;
                case "IsUseCameraAppear":
                    component.IsUseCameraAppear = bool.Parse(node.InnerText);
                    break;
                case "IsUseCameraChaser":
                    component.IsUseCameraChaser = bool.Parse(node.InnerText);
                    break;
                case "LaserChargeTime":
                    component.LaserChargeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MaxVelocity":
                    component.MaxVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MinVelocity":
                    component.MinVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumEnemy":
                    component.NumEnemy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SnapOnPath":
                    component.SnapOnPath = bool.Parse(node.InnerText);
                    break;
                case "WavingVelocity":
                    component.WavingVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eAirChaser", "eAirChasers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eAirChaser", "eAirChasers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eAirChaser");
        }
    }
    private void ReadeAirChaserCollisinForceAttack(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eAirChaserCollisinForceAttack>())
        {
            temp.AddComponent<eAirChaserCollisinForceAttack>();
        }

        eAirChaserCollisinForceAttack component = temp.GetComponent<eAirChaserCollisinForceAttack>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eAirChaserCollisinForceAttacks"))
        {
            new GameObject("eAirChaserCollisinForceAttacks");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackType":
                    component.AttackType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eAirChaserCollisinForceAttack", "eAirChaserCollisinForceAttacks");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eAirChaserCollisinForceAttack", "eAirChaserCollisinForceAttacks", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eAirChaserCollisinForceAttack");
        }
    }
    private void ReadeAirChaserReloadChaserCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eAirChaserReloadChaserCollision>())
        {
            temp.AddComponent<eAirChaserReloadChaserCollision>();
        }

        eAirChaserReloadChaserCollision component = temp.GetComponent<eAirChaserReloadChaserCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eAirChaserReloadChaserCollisions"))
        {
            new GameObject("eAirChaserReloadChaserCollisions");
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
                case "NumCurrent":
                    component.NumCurrent = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumTarget":
                    component.NumTarget = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eAirChaserReloadChaserCollision", "eAirChaserReloadChaserCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eAirChaserReloadChaserCollision", "eAirChaserReloadChaserCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eAirChaserReloadChaserCollision");
        }
    }
    private void ReadeBigChaser(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eBigChaser>())
        {
            temp.AddComponent<eBigChaser>();
        }

        eBigChaser component = temp.GetComponent<eBigChaser>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eBigChasers"))
        {
            new GameObject("eBigChasers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearSpeed":
                    component.AppearSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearType":
                    component.AppearType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRatioLaser":
                    component.AttackRatioLaser = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackRatioShockwave":
                    component.AttackRatioShockwave = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTimeAdd":
                    component.AttackTimeAdd = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTimeMultiply":
                    component.AttackTimeMultiply = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CameraAppearLengthToSonic":
                    component.CameraAppearLengthToSonic = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChangeCameraEnterTime":
                    component.ChangeCameraEnterTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChangeCameraLeaveTime":
                    component.ChangeCameraLeaveTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChaseDistance":
                    component.ChaseDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChaseSpeedScaleFasterThanSonic":
                    component.ChaseSpeedScaleFasterThanSonic = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ChaseSpeedScaleSlowerThanSonic":
                    component.ChaseSpeedScaleSlowerThanSonic = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EnterBoostScale":
                    component.EnterBoostScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FinishCameraKeepTime":
                    component.FinishCameraKeepTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsVisibleDefault":
                    component.IsVisibleDefault = bool.Parse(node.InnerText);
                    break;
                case "LaserCount":
                    component.LaserCount = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserImpulseTangent":
                    component.LaserImpulseTangent = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserImpulseY":
                    component.LaserImpulseY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserPreShotTime":
                    component.LaserPreShotTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserShiftScale":
                    component.LaserShiftScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserSpeed":
                    component.LaserSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LaserTime":
                    component.LaserTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeaveBoostScale":
                    component.LeaveBoostScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeaveType":
                    component.LeaveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LifePoint":
                    component.LifePoint = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MaximumSpeed":
                    component.MaximumSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MinimumSpeed":
                    component.MinimumSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PunchImpulseTangent":
                    component.PunchImpulseTangent = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PunchImpulseY":
                    component.PunchImpulseY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShockwaveImpulseTangent":
                    component.ShockwaveImpulseTangent = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShockwaveImpulseY":
                    component.ShockwaveImpulseY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShockwaveSpeed":
                    component.ShockwaveSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SonicAutoRunSpeed":
                    component.SonicAutoRunSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WaitTimeAfterPunch":
                    component.WaitTimeAfterPunch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eBigChaser", "eBigChasers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eBigChaser", "eBigChasers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eBigChaser");
        }
    }
    private void ReadeBigChaserBomb(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eBigChaserBomb>())
        {
            temp.AddComponent<eBigChaserBomb>();
        }

        eBigChaserBomb component = temp.GetComponent<eBigChaserBomb>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eBigChaserBombs"))
        {
            new GameObject("eBigChaserBombs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBigChaserMode":
                    component.IsBigChaserMode = bool.Parse(node.InnerText);
                    break;
                case "ThresholdStumble":
                    component.ThresholdStumble = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eBigChaserBomb", "eBigChaserBombs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eBigChaserBomb", "eBigChaserBombs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eBigChaserBomb");
        }
    }
    private void ReadeBlizzard(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eBlizzard>())
        {
            temp.AddComponent<eBlizzard>();
        }

        eBlizzard component = temp.GetComponent<eBlizzard>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eBlizzards"))
        {
            new GameObject("eBlizzards");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eBlizzard", "eBlizzards");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eBlizzard", "eBlizzards", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eBlizzard");
        }
    }
    private void ReadeFighter(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eFighter>())
        {
            temp.AddComponent<eFighter>();
        }

        eFighter component = temp.GetComponent<eFighter>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eFighters"))
        {
            new GameObject("eFighters");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsUseFootIK":
                    component.IsUseFootIK = bool.Parse(node.InnerText);
                    break;
                case "MoveTypeSideView":
                    component.MoveTypeSideView = bool.Parse(node.InnerText);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusActive":
                    component.RadiusActive = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAttack":
                    component.RadiusAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartWayPointID":
                    component.StartWayPointID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eFighter", "eFighters");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eFighter", "eFighters", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eFighter");
        }
    }
    private void ReadeFighterGun(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eFighterGun>())
        {
            temp.AddComponent<eFighterGun>();
        }

        eFighterGun component = temp.GetComponent<eFighterGun>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eFighterGuns"))
        {
            new GameObject("eFighterGuns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsUseFootIK":
                    component.IsUseFootIK = bool.Parse(node.InnerText);
                    break;
                case "MoveTypeSideView":
                    component.MoveTypeSideView = bool.Parse(node.InnerText);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusActive":
                    component.RadiusActive = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAttack":
                    component.RadiusAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotType":
                    component.ShotType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartWayPointID":
                    component.StartWayPointID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UseChibi":
                    component.UseChibi = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "eFighterGun", "eFighterGuns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eFighterGun", "eFighterGuns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eFighterGun");
        }
    }
    private void ReadeFighterShield(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eFighterShield>())
        {
            temp.AddComponent<eFighterShield>();
        }

        eFighterShield component = temp.GetComponent<eFighterShield>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eFighterShields"))
        {
            new GameObject("eFighterShields");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsUseFootIK":
                    component.IsUseFootIK = bool.Parse(node.InnerText);
                    break;
                case "MoveTypeSideView":
                    component.MoveTypeSideView = bool.Parse(node.InnerText);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusActive":
                    component.RadiusActive = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAttack":
                    component.RadiusAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShieldType":
                    component.ShieldType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartWayPointID":
                    component.StartWayPointID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eFighterShield", "eFighterShields");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eFighterShield", "eFighterShields", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eFighterShield");
        }
    }
    private void ReadeFighterSword(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eFighterSword>())
        {
            temp.AddComponent<eFighterSword>();
        }

        eFighterSword component = temp.GetComponent<eFighterSword>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eFighterSwords"))
        {
            new GameObject("eFighterSwords");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsUseFootIK":
                    component.IsUseFootIK = bool.Parse(node.InnerText);
                    break;
                case "MoveTypeSideView":
                    component.MoveTypeSideView = bool.Parse(node.InnerText);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusActive":
                    component.RadiusActive = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAttack":
                    component.RadiusAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShieldType":
                    component.ShieldType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartWayPointID":
                    component.StartWayPointID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eFighterSword", "eFighterSwords");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eFighterSword", "eFighterSwords", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eFighterSword");
        }
    }
    private void ReadeFlame(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eFlame>())
        {
            temp.AddComponent<eFlame>();
        }

        eFlame component = temp.GetComponent<eFlame>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eFlames"))
        {
            new GameObject("eFlames");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eFlame", "eFlames");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eFlame", "eFlames", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eFlame");
        }
    }
    private void ReadeMoleCannon(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eMoleCannon>())
        {
            temp.AddComponent<eMoleCannon>();
        }

        eMoleCannon component = temp.GetComponent<eMoleCannon>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eMoleCannons"))
        {
            new GameObject("eMoleCannons");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalAttack":
                    component.IntervalAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalShot":
                    component.IntervalShot = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumAttackOneTime":
                    component.NumAttackOneTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "NumShotOneTime":
                    component.NumShotOneTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAppear":
                    component.RadiusAppear = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusEscape":
                    component.RadiusEscape = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ShotType":
                    component.ShotType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "eMoleCannon", "eMoleCannons");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eMoleCannon", "eMoleCannons", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eMoleCannon");
        }
    }
    private void ReadEndDynamicPreloadingCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EndDynamicPreloadingCollision>())
        {
            temp.AddComponent<EndDynamicPreloadingCollision>();
        }

        EndDynamicPreloadingCollision component = temp.GetComponent<EndDynamicPreloadingCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EndDynamicPreloadingCollisions"))
        {
            new GameObject("EndDynamicPreloadingCollisions");
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
                    ReadMultiSetParam(component, node, "EndDynamicPreloadingCollision", "EndDynamicPreloadingCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EndDynamicPreloadingCollision", "EndDynamicPreloadingCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EndDynamicPreloadingCollision");
        }
    }
    private void ReadeShackleFView(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eShackleFView>())
        {
            temp.AddComponent<eShackleFView>();
        }

        eShackleFView component = temp.GetComponent<eShackleFView>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eShackleFViews"))
        {
            new GameObject("eShackleFViews");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalDecRing":
                    component.IntervalDecRing = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "RadiusActive":
                    component.RadiusActive = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "RadiusAttack":
                    component.RadiusAttack = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eShackleFView", "eShackleFViews");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eShackleFView", "eShackleFViews", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eShackleFView");
        }
    }
    private void ReadeSpanner(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eSpanner>())
        {
            temp.AddComponent<eSpanner>();
        }

        eSpanner component = temp.GetComponent<eSpanner>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eSpanners"))
        {
            new GameObject("eSpanners");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eSpanner", "eSpanners");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eSpanner", "eSpanners", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eSpanner");
        }
    }
    private void ReadeSpinner(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eSpinner>())
        {
            temp.AddComponent<eSpinner>();
        }

        eSpinner component = temp.GetComponent<eSpinner>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eSpinners"))
        {
            new GameObject("eSpinners");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ForSideView":
                    component.ForSideView = bool.Parse(node.InnerText);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "eSpinner", "eSpinners");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eSpinner", "eSpinners", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eSpinner");
        }
    }
    private void ReadeThunderBall(XmlNode xmlNode)
    {
        if (!temp.GetComponent<eThunderBall>())
        {
            temp.AddComponent<eThunderBall>();
        }

        eThunderBall component = temp.GetComponent<eThunderBall>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("eThunderBalls"))
        {
            new GameObject("eThunderBalls");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AttackInterval":
                    component.AttackInterval = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AttackTime":
                    component.AttackTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveTypeSideView":
                    component.MoveTypeSideView = bool.Parse(node.InnerText);
                    break;
                case "OnlyPlayerAttack":
                    component.OnlyPlayerAttack = bool.Parse(node.InnerText);
                    break;
                case "PlayAppearEffect":
                    component.PlayAppearEffect = bool.Parse(node.InnerText);
                    break;
                case "StartTime":
                    component.StartTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "StartWayPointID":
                    component.StartWayPointID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "eThunderBall", "eThunderBalls");
                    break;
            }
        }
        try
        {
            CreateObject(component, "eThunderBall", "eThunderBalls", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate eThunderBall");
        }
    }
    private void ReadEventSetter(XmlNode xmlNode)
    {
        if (!temp.GetComponent<EventSetter>())
        {
            temp.AddComponent<EventSetter>();
        }

        EventSetter component = temp.GetComponent<EventSetter>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("EventSetters"))
        {
            new GameObject("EventSetters");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Condition":
                    component.Condition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                //case "TargetList0":
                //    component.TargetList0 = id_list.Parse(node.InnerText);
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
                case "TimesType":
                    component.TimesType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Trigger":
                    component.Trigger = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "TriggerList":
                //    component.TriggerList = id_list.Parse(node.InnerText);
                //    break;
                //case "TargetList1":
                //    component.TargetList1 = id_list.Parse(node.InnerText);
                //    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "TargetList2":
                //    component.TargetList2 = undefined.Parse(node.InnerText);
                //    break;
                //case "TargetList3":
                //    component.TargetList3 = undefined.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "EventSetter", "EventSetters");
                    break;
            }
        }
        try
        {
            CreateObject(component, "EventSetter", "EventSetters", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate EventSetter");
        }
    }
    private void ReadGrouper(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Grouper>())
        {
            temp.AddComponent<Grouper>();
        }

        Grouper component = temp.GetComponent<Grouper>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Groupers"))
        {
            new GameObject("Groupers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroupMove":
                    component.GroupMove = ReadPosition(node);
                    break;
                case "IsCastShadow":
                    //component.IsCastShadow = bool.Parse(node.InnerText);
                    break;
                case "Range":
                    //component.Range = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "TargetList":
                //    component.TargetList = undefined.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "Grouper", "Groupers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Grouper", "Groupers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Grouper");
        }
    }
    private void ReadIcicle(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Icicle>())
        {
            temp.AddComponent<Icicle>();
        }

        Icicle component = temp.GetComponent<Icicle>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Icicles"))
        {
            new GameObject("Icicles");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstVelocity":
                    component.FirstVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsWaterEffect":
                    component.IsWaterEffect = bool.Parse(node.InnerText);
                    break;
                case "Timer":
                    component.Timer = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Icicle", "Icicles");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Icicle", "Icicles", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Icicle");
        }
    }
    private void ReadItemBox(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ItemBox>())
        {
            temp.AddComponent<ItemBox>();
        }

        ItemBox component = temp.GetComponent<ItemBox>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ItemBoxs"))
        {
            new GameObject("ItemBoxs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
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
                    ReadMultiSetParam(component, node, "ItemBox", "ItemBoxs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ItemBox", "ItemBoxs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ItemBox");
        }
    }
    private void ReadItemIllustBook(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ItemIllustBook>())
        {
            temp.AddComponent<ItemIllustBook>();
        }

        ItemIllustBook component = temp.GetComponent<ItemIllustBook>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ItemIllustBooks"))
        {
            new GameObject("ItemIllustBooks");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MediaIndex":
                    component.MediaIndex = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ItemIllustBook", "ItemIllustBooks");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ItemIllustBook", "ItemIllustBooks", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ItemIllustBook");
        }
    }
    private void ReadItemRecordA(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ItemRecordA>())
        {
            temp.AddComponent<ItemRecordA>();
        }

        ItemRecordA component = temp.GetComponent<ItemRecordA>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ItemRecordAs"))
        {
            new GameObject("ItemRecordAs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MediaIndex":
                    component.MediaIndex = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ItemRecordA", "ItemRecordAs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ItemRecordA", "ItemRecordAs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ItemRecordA");
        }
    }
    private void ReadItemVideoTape(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ItemVideoTape>())
        {
            temp.AddComponent<ItemVideoTape>();
        }

        ItemVideoTape component = temp.GetComponent<ItemVideoTape>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ItemVideoTapes"))
        {
            new GameObject("ItemVideoTapes");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MediaIndex":
                    component.MediaIndex = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ItemVideoTape", "ItemVideoTapes");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ItemVideoTape", "ItemVideoTapes", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ItemVideoTape");
        }
    }
    private void ReadJumpSelector(XmlNode xmlNode)
    {
        if (!temp.GetComponent<JumpSelector>())
        {
            temp.AddComponent<JumpSelector>();
        }

        JumpSelector component = temp.GetComponent<JumpSelector>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("JumpSelectors"))
        {
            new GameObject("JumpSelectors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DownShotForce":
                    component.DownShotForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownShotOutOfControl":
                    component.DownShotOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FrontJumpForce":
                    component.FrontJumpForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FrontJumpOutOfControl":
                    component.FrontJumpOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InputTime":
                    component.InputTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDownShot":
                    component.IsDownShot = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsQuestion":
                    component.IsQuestion = bool.Parse(node.InnerText);
                    break;
                case "SuccessButton":
                    component.SuccessButton = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpJumpForce":
                    component.UpJumpForce = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpJumpOutOfControl":
                    component.UpJumpOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpJumpPitch":
                    component.UpJumpPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "JumpSelector", "JumpSelectors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "JumpSelector", "JumpSelectors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate JumpSelector");
        }
    }
    private void ReadMedalMoon(XmlNode xmlNode)
    {
        if (!temp.GetComponent<MedalMoon>())
        {
            temp.AddComponent<MedalMoon>();
        }

        MedalMoon component = temp.GetComponent<MedalMoon>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("MedalMoons"))
        {
            new GameObject("MedalMoons");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Index":
                    component.Index = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "MedalMoon", "MedalMoons");
                    break;
            }
        }
        try
        {
            CreateObject(component, "MedalMoon", "MedalMoons", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate MedalMoon");
        }
    }
    private void ReadMedalSun(XmlNode xmlNode)
    {
        if (!temp.GetComponent<MedalSun>())
        {
            temp.AddComponent<MedalSun>();
        }

        MedalSun component = temp.GetComponent<MedalSun>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("MedalSuns"))
        {
            new GameObject("MedalSuns");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Index":
                    component.Index = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "MedalSun", "MedalSuns");
                    break;
            }
        }
        try
        {
            CreateObject(component, "MedalSun", "MedalSuns", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate MedalSun");
        }
    }
    private void ReadObjBaseSound(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjBaseSound>())
        {
            temp.AddComponent<ObjBaseSound>();
        }

        ObjBaseSound component = temp.GetComponent<ObjBaseSound>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjBaseSounds"))
        {
            new GameObject("ObjBaseSounds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseVolume":
                    component.BaseVolume = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "FileName":
                    component.FileName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalTime":
                    component.IntervalTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsRegularly":
                    component.IsRegularly = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "ObjBaseSound", "ObjBaseSounds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjBaseSound", "ObjBaseSounds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjBaseSound");
        }
    }
    private void ReadObjCamera2D(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCamera2D>())
        {
            temp.AddComponent<ObjCamera2D>();
        }

        ObjCamera2D component = temp.GetComponent<ObjCamera2D>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCamera2Ds"))
        {
            new GameObject("ObjCamera2Ds");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseSpacePathPosition":
                    component.BaseSpacePathPosition = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "Fovy":
                    component.Fovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsBaseSpacePlayer":
                    component.IsBaseSpacePlayer = bool.Parse(node.InnerText);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsPositionBasePlayer":
                    component.IsPositionBasePlayer = bool.Parse(node.InnerText);
                    break;
                case "Rotation_Y":
                    component.Rotation_Y = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Rotation_Z":
                    component.Rotation_Z = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Bias":
                    component.Target_Front_Offset_Bias = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Max":
                    component.Target_Front_Offset_Max = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Front_Offset_Speed_Scale":
                    component.Target_Front_Offset_Speed_Scale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Up_Offset":
                    component.Target_Up_Offset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjCamera2D", "ObjCamera2Ds");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCamera2D", "ObjCamera2Ds", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCamera2D");
        }
    }
    private void ReadObjCameraBlend(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraBlend>())
        {
            temp.AddComponent<ObjCameraBlend>();
        }

        ObjCameraBlend component = temp.GetComponent<ObjCameraBlend>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraBlends"))
        {
            new GameObject("ObjCameraBlends");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BlendBase":
                    component.BlendBase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BlendSpeed":
                    component.BlendSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "BlendType":
                    component.BlendType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                //case "CameraList":
                //    component.CameraList = id_list.Parse(node.InnerText);
                //    break;
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
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                //case "Target":
                //    component.Target = int.Parse(node.InnerText);
                //    break;
                case "TargetOffset_Front":
                    component.TargetOffset_Front = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Right":
                    component.TargetOffset_Right = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetOffset_Up":
                    component.TargetOffset_Up = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjCameraBlend", "ObjCameraBlends");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraBlend", "ObjCameraBlends", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraBlend");
        }
    }
    private void ReadObjCameraNormal(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraNormal>())
        {
            temp.AddComponent<ObjCameraNormal>();
        }

        ObjCameraNormal component = temp.GetComponent<ObjCameraNormal>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraNormals"))
        {
            new GameObject("ObjCameraNormals");
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
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsCameraView":
                    component.IsCameraView = bool.Parse(node.InnerText);
                    break;
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "VerticalOffsetForSonic":
                    component.VerticalOffsetForSonic = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Param.Distance":
                    component.m_ParamDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Param.Fovy":
                    component.m_ParamFovy = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Param.TargetPitch":
                    component.m_ParamTargetPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Param.TargetYaw":
                    component.m_ParamTargetYaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjCameraNormal", "ObjCameraNormals");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraNormal", "ObjCameraNormals", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraNormal");
        }
    }
    private void ReadObjCameraPanVertical(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraPanVertical>())
        {
            temp.AddComponent<ObjCameraPanVertical>();
        }

        ObjCameraPanVertical component = temp.GetComponent<ObjCameraPanVertical>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraPanVerticals"))
        {
            new GameObject("ObjCameraPanVerticals");
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
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjCameraPanVertical", "ObjCameraPanVerticals");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraPanVertical", "ObjCameraPanVerticals", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraPanVertical");
        }
    }
    private void ReadObjCameraPathTarget(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjCameraPathTarget>())
        {
            temp.AddComponent<ObjCameraPathTarget>();
        }

        ObjCameraPathTarget component = temp.GetComponent<ObjCameraPathTarget>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjCameraPathTargets"))
        {
            new GameObject("ObjCameraPathTargets");
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
                case "EyePathType":
                    component.EyePathType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EyeSpeed":
                    component.EyeSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "IsCollision":
                    component.IsCollision = bool.Parse(node.InnerText);
                    break;
                case "IsControllable":
                    component.IsControllable = bool.Parse(node.InnerText);
                    break;
                case "OffsetOnEyePath":
                    component.OffsetOnEyePath = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PanAndTangentBlend":
                    component.PanAndTangentBlend = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathID":
                    component.PathID = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                case "Target_Type":
                    component.Target_Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjCameraPathTarget", "ObjCameraPathTargets");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjCameraPathTarget", "ObjCameraPathTargets", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjCameraPathTarget");
        }
    }
    private void ReadObjSoundLine(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjSoundLine>())
        {
            temp.AddComponent<ObjSoundLine>();
        }

        ObjSoundLine component = temp.GetComponent<ObjSoundLine>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjSoundLines"))
        {
            new GameObject("ObjSoundLines");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseVolume":
                    component.BaseVolume = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "FileName":
                    component.FileName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalTime":
                    component.IntervalTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsRegularly":
                    component.IsRegularly = bool.Parse(node.InnerText);
                    break;
                //case "PositionList":
                //    component.PositionList = vector_list.Parse(node.InnerText);
                //    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjSoundLine", "ObjSoundLines");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjSoundLine", "ObjSoundLines", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjSoundLine");
        }
    }
    private void ReadObjSoundPoint(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ObjSoundPoint>())
        {
            temp.AddComponent<ObjSoundPoint>();
        }

        ObjSoundPoint component = temp.GetComponent<ObjSoundPoint>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ObjSoundPoints"))
        {
            new GameObject("ObjSoundPoints");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "BaseVolume":
                    component.BaseVolume = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "CueName":
                    component.CueName = node.InnerText;
                    break;
                case "FileName":
                    component.FileName = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "InsideRadius":
                    component.InsideRadius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IntervalTime":
                    component.IntervalTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsRegularly":
                    component.IsRegularly = bool.Parse(node.InnerText);
                    break;
                case "Radius":
                    component.Radius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ObjSoundPoint", "ObjSoundPoints");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ObjSoundPoint", "ObjSoundPoints", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ObjSoundPoint");
        }
    }
    private void ReadParaloop(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Paraloop>())
        {
            temp.AddComponent<Paraloop>();
        }

        Paraloop component = temp.GetComponent<Paraloop>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Paraloops"))
        {
            new GameObject("Paraloops");
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
                case "m_MaxLength":
                    component.m_MaxLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Paraloop", "Paraloops");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Paraloop", "Paraloops", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Paraloop");
        }
    }
    private void ReadPenguin(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Penguin>())
        {
            temp.AddComponent<Penguin>();
        }

        Penguin component = temp.GetComponent<Penguin>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Penguins"))
        {
            new GameObject("Penguins");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DivingDist":
                    component.DivingDist = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DivingSpeed":
                    component.DivingSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WalkDist":
                    component.WalkDist = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WalkSpeed":
                    component.WalkSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "WalkingRadius":
                    component.WalkingRadius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Penguin", "Penguins");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Penguin", "Penguins", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Penguin");
        }
    }
    private void ReadReactionPlate(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ReactionPlate>())
        {
            temp.AddComponent<ReactionPlate>();
        }

        ReactionPlate component = temp.GetComponent<ReactionPlate>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ReactionPlates"))
        {
            new GameObject("ReactionPlates");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "MainAcceptingTime":
                    component.MainAcceptingTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PreAcceptingTime":
                    component.PreAcceptingTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Target":
                    component.Target = int.Parse(node.InnerText);
                    break;
                case "Type":
                    component.Type = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Difficulty":
                    component.m_Difficulty = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_FailOutOfControlTime":
                    component.m_FailOutOfControlTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_JumpMaxVelocity":
                    component.m_JumpMaxVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_JumpMinVelocity":
                    component.m_JumpMinVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Score":
                    component.m_Score = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ReactionPlate", "ReactionPlates");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ReactionPlate", "ReactionPlates", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ReactionPlate");
        }
    }
    private void ReadSnowFloorA(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorA>())
        {
            temp.AddComponent<SnowFloorA>();
        }

        SnowFloorA component = temp.GetComponent<SnowFloorA>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorAs"))
        {
            new GameObject("SnowFloorAs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorA", "SnowFloorAs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorA", "SnowFloorAs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorA");
        }
    }
    private void ReadSnowFloorB0(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB0>())
        {
            temp.AddComponent<SnowFloorB0>();
        }

        SnowFloorB0 component = temp.GetComponent<SnowFloorB0>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB0s"))
        {
            new GameObject("SnowFloorB0s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB0", "SnowFloorB0s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB0", "SnowFloorB0s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB0");
        }
    }
    private void ReadSnowFloorB1(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB1>())
        {
            temp.AddComponent<SnowFloorB1>();
        }

        SnowFloorB1 component = temp.GetComponent<SnowFloorB1>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB1s"))
        {
            new GameObject("SnowFloorB1s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB1", "SnowFloorB1s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB1", "SnowFloorB1s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB1");
        }
    }
    private void ReadSnowFloorB2(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB2>())
        {
            temp.AddComponent<SnowFloorB2>();
        }

        SnowFloorB2 component = temp.GetComponent<SnowFloorB2>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB2s"))
        {
            new GameObject("SnowFloorB2s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB2", "SnowFloorB2s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB2", "SnowFloorB2s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB2");
        }
    }
    private void ReadSnowFloorB3(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB3>())
        {
            temp.AddComponent<SnowFloorB3>();
        }

        SnowFloorB3 component = temp.GetComponent<SnowFloorB3>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB3s"))
        {
            new GameObject("SnowFloorB3s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB3", "SnowFloorB3s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB3", "SnowFloorB3s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB3");
        }
    }
    private void ReadSnowFloorB4(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB4>())
        {
            temp.AddComponent<SnowFloorB4>();
        }

        SnowFloorB4 component = temp.GetComponent<SnowFloorB4>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB4s"))
        {
            new GameObject("SnowFloorB4s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB4", "SnowFloorB4s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB4", "SnowFloorB4s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB4");
        }
    }
    private void ReadSnowFloorB5(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB5>())
        {
            temp.AddComponent<SnowFloorB5>();
        }

        SnowFloorB5 component = temp.GetComponent<SnowFloorB5>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB5s"))
        {
            new GameObject("SnowFloorB5s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB5", "SnowFloorB5s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB5", "SnowFloorB5s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB5");
        }
    }
    private void ReadSnowFloorB6(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB6>())
        {
            temp.AddComponent<SnowFloorB6>();
        }

        SnowFloorB6 component = temp.GetComponent<SnowFloorB6>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB6s"))
        {
            new GameObject("SnowFloorB6s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB6", "SnowFloorB6s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB6", "SnowFloorB6s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB6");
        }
    }
    private void ReadSnowFloorB7(XmlNode xmlNode)
    {
        if (!temp.GetComponent<SnowFloorB7>())
        {
            temp.AddComponent<SnowFloorB7>();
        }

        SnowFloorB7 component = temp.GetComponent<SnowFloorB7>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("SnowFloorB7s"))
        {
            new GameObject("SnowFloorB7s");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddRange":
                    component.AddRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Amplitude":
                    component.Amplitude = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearStopTime":
                    component.AppearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "AppearTime":
                    component.AppearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Cycle":
                    component.Cycle = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearStopTime":
                    component.DisappearStopTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DisappearTime":
                    component.DisappearTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Gravity":
                    component.Gravity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsDamage":
                    component.IsDamage = bool.Parse(node.InnerText);
                    break;
                case "IsEffect":
                    component.IsEffect = bool.Parse(node.InnerText);
                    break;
                case "IsMessageON":
                    component.IsMessageON = bool.Parse(node.InnerText);
                    break;
                case "IsReverse":
                    component.IsReverse = bool.Parse(node.InnerText);
                    break;
                case "IsWallJump":
                    component.IsWallJump = bool.Parse(node.InnerText);
                    break;
                case "Length":
                    component.Length = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnFloorTime":
                    component.OnFloorTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OnShakeTime":
                    component.OnShakeTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathReverseTime":
                    component.PathReverseTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PathSpeed":
                    component.PathSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "PressDirection":
                    component.PressDirection = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ResetTime":
                    component.ResetTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "SnowFloorB7", "SnowFloorB7s");
                    break;
            }
        }
        try
        {
            CreateObject(component, "SnowFloorB7", "SnowFloorB7s", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate SnowFloorB7");
        }
    }
    private void ReadSnow_Door(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Snow_Door>())
        {
            temp.AddComponent<Snow_Door>();
        }

        Snow_Door component = temp.GetComponent<Snow_Door>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Snow_Doors"))
        {
            new GameObject("Snow_Doors");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstState":
                    component.FirstState = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Snow_Door", "Snow_Doors");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Snow_Door", "Snow_Doors", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Snow_Door");
        }
    }
    private void ReadSnow_IcePillar(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Snow_IcePillar>())
        {
            temp.AddComponent<Snow_IcePillar>();
        }

        Snow_IcePillar component = temp.GetComponent<Snow_IcePillar>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Snow_IcePillars"))
        {
            new GameObject("Snow_IcePillars");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AddUserRange":
                    component.AddUserRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength0":
                    component.DownLength0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength1":
                    component.DownLength1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength2":
                    component.DownLength2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength3":
                    component.DownLength3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength4":
                    component.DownLength4 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength5":
                    component.DownLength5 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownLength6":
                    component.DownLength6 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MotionSpeed":
                    component.MotionSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Snow_IcePillar", "Snow_IcePillars");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Snow_IcePillar", "Snow_IcePillars", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Snow_IcePillar");
        }
    }
    private void ReadSnow_ThornBall(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Snow_ThornBall>())
        {
            temp.AddComponent<Snow_ThornBall>();
        }

        Snow_ThornBall component = temp.GetComponent<Snow_ThornBall>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Snow_ThornBalls"))
        {
            new GameObject("Snow_ThornBalls");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Distance":
                    component.Distance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "MoveType":
                    component.MoveType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Time":
                    component.Time = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Snow_ThornBall", "Snow_ThornBalls");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Snow_ThornBall", "Snow_ThornBalls", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Snow_ThornBall");
        }
    }
    private void ReadStageEffect(XmlNode xmlNode)
    {
        if (!temp.GetComponent<StageEffect>())
        {
            temp.AddComponent<StageEffect>();
        }

        StageEffect component = temp.GetComponent<StageEffect>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("StageEffects"))
        {
            new GameObject("StageEffects");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "ColorScale_A":
                    component.ColorScale_A = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ColorScale_B":
                    component.ColorScale_B = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ColorScale_G":
                    component.ColorScale_G = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ColorScale_R":
                    component.ColorScale_R = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "EditColorFlag":
                    component.EditColorFlag = bool.Parse(node.InnerText);
                    break;
                case "EffectType":
                    component.EffectType = node.InnerText;
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Loop":
                    component.Loop = bool.Parse(node.InnerText);
                    break;
                case "ScaleX":
                    component.ScaleX = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScaleY":
                    component.ScaleY = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "ScaleZ":
                    component.ScaleZ = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UserRange":
                    component.UserRange = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "VolumeScale":
                    component.VolumeScale = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "StageEffect", "StageEffects");
                    break;
            }
        }
        try
        {
            CreateObject(component, "StageEffect", "StageEffects", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate StageEffect");
        }
    }
    private void ReadStartDynamicPreloadingCollision(XmlNode xmlNode)
    {
        if (!temp.GetComponent<StartDynamicPreloadingCollision>())
        {
            temp.AddComponent<StartDynamicPreloadingCollision>();
        }

        StartDynamicPreloadingCollision component = temp.GetComponent<StartDynamicPreloadingCollision>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("StartDynamicPreloadingCollisions"))
        {
            new GameObject("StartDynamicPreloadingCollisions");
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
                case "m_GIEnable":
                    component.m_GIEnable = bool.Parse(node.InnerText);
                    break;
                case "m_MinGIMipLevel":
                    component.m_MinGIMipLevel = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_TargetRadius":
                    component.m_TargetRadius = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_TerrainEnable":
                    component.m_TerrainEnable = bool.Parse(node.InnerText);
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
                    ReadMultiSetParam(component, node, "StartDynamicPreloadingCollision", "StartDynamicPreloadingCollisions");
                    break;
            }
        }
        try
        {
            CreateObject(component, "StartDynamicPreloadingCollision", "StartDynamicPreloadingCollisions", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate StartDynamicPreloadingCollision");
        }
    }
    private void ReadStompingSwitch(XmlNode xmlNode)
    {
        if (!temp.GetComponent<StompingSwitch>())
        {
            temp.AddComponent<StompingSwitch>();
        }

        StompingSwitch component = temp.GetComponent<StompingSwitch>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("StompingSwitchs"))
        {
            new GameObject("StompingSwitchs");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "Event0":
                    component.Event0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TargetList0":
                    component.TargetList0 = int.Parse(node.InnerText);
                    break;
                case "Timer0":
                    component.Timer0 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "StompingSwitch", "StompingSwitchs");
                    break;
            }
        }
        try
        {
            CreateObject(component, "StompingSwitch", "StompingSwitchs", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate StompingSwitch");
        }
    }
    private void ReadThornSpring(XmlNode xmlNode)
    {
        if (!temp.GetComponent<ThornSpring>())
        {
            temp.AddComponent<ThornSpring>();
        }

        ThornSpring component = temp.GetComponent<ThornSpring>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("ThornSprings"))
        {
            new GameObject("ThornSprings");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "DebugShotTimeLength":
                    component.DebugShotTimeLength = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "DownThornTime":
                    component.DownThornTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsChangeCameraWhenPathChange":
                    component.IsChangeCameraWhenPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsPathChange":
                    component.IsPathChange = bool.Parse(node.InnerText);
                    break;
                case "IsStartVelocityConstant":
                    component.IsStartVelocityConstant = bool.Parse(node.InnerText);
                    break;
                case "IsWallWalk":
                    component.IsWallWalk = bool.Parse(node.InnerText);
                    break;
                case "IsYawUpdate":
                    component.IsYawUpdate = bool.Parse(node.InnerText);
                    break;
                case "KeepVelocityDistance":
                    component.KeepVelocityDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "OutOfControl":
                    component.OutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "Phase":
                    component.Phase = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "UpThornTime":
                    component.UpThornTime = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "ThornSpring", "ThornSprings");
                    break;
            }
        }
        try
        {
            CreateObject(component, "ThornSpring", "ThornSprings", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate ThornSpring");
        }
    }
    private void ReadTrickJumper(XmlNode xmlNode)
    {
        if (!temp.GetComponent<TrickJumper>())
        {
            temp.AddComponent<TrickJumper>();
        }

        TrickJumper component = temp.GetComponent<TrickJumper>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("TrickJumpers"))
        {
            new GameObject("TrickJumpers");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "FirstOutOfControl":
                    component.FirstOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstPitch":
                    component.FirstPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "FirstSpeed":
                    component.FirstSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsSideView":
                    component.IsSideView = bool.Parse(node.InnerText);
                    break;
                case "SecondOutOfControl":
                    component.SecondOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SecondPitch":
                    component.SecondPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SecondSpeed":
                    component.SecondSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickCount1":
                    component.TrickCount1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickCount2":
                    component.TrickCount2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickCount3":
                    component.TrickCount3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickTime1":
                    component.TrickTime1 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickTime2":
                    component.TrickTime2 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "TrickTime3":
                    component.TrickTime3 = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Difficulty":
                    component.m_Difficulty = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "m_Score":
                    component.m_Score = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "TrickJumper", "TrickJumpers");
                    break;
            }
        }
        try
        {
            CreateObject(component, "TrickJumper", "TrickJumpers", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate TrickJumper");
        }
    }
    private void ReadWarpPoint(XmlNode xmlNode)
    {
        if (!temp.GetComponent<WarpPoint>())
        {
            temp.AddComponent<WarpPoint>();
        }

        WarpPoint component = temp.GetComponent<WarpPoint>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("WarpPoints"))
        {
            new GameObject("WarpPoints");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
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
                    ReadMultiSetParam(component, node, "WarpPoint", "WarpPoints");
                    break;
            }
        }
        try
        {
            CreateObject(component, "WarpPoint", "WarpPoints", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate WarpPoint");
        }
    }
    private void ReadWhale(XmlNode xmlNode)
    {
        if (!temp.GetComponent<Whale>())
        {
            temp.AddComponent<Whale>();
        }

        Whale component = temp.GetComponent<Whale>();

        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();

        if (!GameObject.Find("Whales"))
        {
            new GameObject("Whales");
        }

        foreach (XmlNode node in xmlNode.ChildNodes)
        {
            switch (node.Name)
            {
                case "AppearType":
                    component.AppearType = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "GroundOffset":
                    //component.GroundOffset = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "HeadUpAfterSonicJump":
                    component.HeadUpAfterSonicJump = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "IsEnterFromTail":
                    component.IsEnterFromTail = bool.Parse(node.InnerText);
                    break;
                case "JumpKeepVelocity":
                    component.JumpKeepVelocity = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "JumpOutOfControl":
                    component.JumpOutOfControl = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "JumpPitch":
                    component.JumpPitch = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "JumpSpeed":
                    component.JumpSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "JumpYaw":
                    component.JumpYaw = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeapDelay":
                    component.LeapDelay = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeapHeight":
                    component.LeapHeight = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "LeapSpeed":
                    component.LeapSpeed = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case "SwimUpDistance":
                    component.SwimUpDistance = float.Parse(node.InnerText, CultureInfo.InvariantCulture.NumberFormat);
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
                    ReadMultiSetParam(component, node, "Whale", "Whales");
                    break;
            }
        }
        try
        {
            CreateObject(component, "Whale", "Whales", position, rotation);
        }
        catch
        {
            Debug.Log("Can't Instantiate Whale");
        }
    }

    private void CreateObject(Component component, string resourceName, string parentName, Vector3 position, Quaternion rotation)
    {
        GameObject go = PrefabUtility.InstantiatePrefab(FindInResources(resourceName)) as GameObject;
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.parent = GameObject.Find(parentName).transform;
        CopyComponent(component, go);
        //go.GetComponent<GenerationsObject>().OnValidate();
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

    private Vector3 ParseVector3FromArray(string[] floats)
    {
        return new Vector3(float.Parse(floats[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[2], CultureInfo.InvariantCulture.NumberFormat));
    }

    private Vector3 ParseQuaternionFromArray(string[] floats)
    {
        return new Vector3(float.Parse(floats[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[2], CultureInfo.InvariantCulture.NumberFormat));
    }
}