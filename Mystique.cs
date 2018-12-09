using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using ProtoBuf;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using Facepunch.Steamworks;
using System.Net;
using System.Net.Sockets;
using System.Linq;


public class Mystique : MonoBehaviour
{
    
    public static BasePlayer localplayer;


    private static Rect rect_esp = new Rect(50f, 100f, 235f, 120f);

    private static UnityEngine.Color color_0 = new UnityEngine.Color(0.28f, 0.8f, 1f, 1f);
    private static UnityEngine.Color color_1 = new UnityEngine.Color(0.13f, 0.9f, 0.55f, 1f);

    public static UnityEngine.Color EspRGBAPlayers = new UnityEngine.Color(1f, 0f, 0f, 1f);
    public static System.Collections.Generic.List<GameObject> ViewerCaches = new System.Collections.Generic.List<GameObject>();

    public static Dictionary<int, Resource> dictResources = new Dictionary<int, Resource> { };
    public static Dictionary<int, Animal> dictAnimals = new Dictionary<int, Animal> { };
    public static Dictionary<int, Dropped> dictDropped = new Dictionary<int, Dropped> { };
    public static Dictionary<int, CLock> dictCodelocks = new Dictionary<int, CLock> { };
    public static Dictionary<int, Airdrop> dictAirdrops = new Dictionary<int, Airdrop> { };
    public static Dictionary<int, Barrel> dictBarrels = new Dictionary<int, Barrel> { };
    public static Dictionary<int, Crate> dictCrates = new Dictionary<int, Crate> { };
    public static Dictionary<int, Stash> dictStashes = new Dictionary<int, Stash> { };
    public static Dictionary<int, Hemp> dictHemp = new Dictionary<int, Hemp> { };
    public static Dictionary<int, TC> dictTC = new Dictionary<int, TC> { };
    public static Dictionary<int, Corpse> dictCorpses = new Dictionary<int, Corpse> { };
    public static Dictionary<int, Autoturret> dictTurrets = new Dictionary<int, Autoturret> { };
    public static Dictionary<int, Flameturret> dictFlames = new Dictionary<int, Flameturret> { };
    public static Dictionary<int, Beartrap> dictBeartraps = new Dictionary<int, Beartrap> { };
    public static Dictionary<int, Landmine> dictLandmines = new Dictionary<int, Landmine> { };
    public static Dictionary<int, Shotguntrap> dictShotguns = new Dictionary<int, Shotguntrap> { };
    public static Dictionary<int, Painting> dictPaintings = new Dictionary<int, Painting> { };
    public static Dictionary<string, Vector3> dictLocations = new Dictionary<string, Vector3> { };

    public static BaseHelicopter heliObject;

    public static List<string> Whitelist = new List<string> { };


    public struct Resource
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Animal
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Dropped
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }


    public struct CLock
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Airdrop
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Barrel
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Crate
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Stash
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Hemp
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Corpse
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct TC
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Autoturret
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Flameturret
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Landmine
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Beartrap
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Shotguntrap
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }

    public struct Painting
    {
        public string name;
        public Vector3 position;
        public BaseEntity entity;
    }


    #region "Settings"
    public static bool ESP_Active;
    public static bool ESP_OnlinePlayers;
    public static UnityEngine.Color Color_ESPOnlinePlayers;
    public static bool ESP_Far;
    public static int ESP_FarRange;
    public static UnityEngine.Color Color_ESPFar;
    public static bool ESP_Sleepers;
    public static UnityEngine.Color Color_ESPSleepers;
    public static bool ESP_Bones;
    public static UnityEngine.Color Color_ESPBones;
    public static bool ESP_Boxes;
    public static bool ESP_Boxes3D;
    public static int ESP_ActiveRange;
    public static bool ESP_Heli;
    public static UnityEngine.Color Color_ESPHeli;
    public static bool ESP_Node;
    public static UnityEngine.Color Color_ESPNode;
    public static bool ESP_Animal;
    public static UnityEngine.Color Color_ESPAnimal;
    public static bool ESP_Dropped;
    public static UnityEngine.Color Color_ESPDropped;
    public static bool ESP_Airdrop;
    public static UnityEngine.Color Color_ESPAirdrop;
    public static bool ESP_Barrel;
    public static UnityEngine.Color Color_ESPBarrel;
    public static bool ESP_Crate;
    public static UnityEngine.Color Color_ESPCrate;
    public static bool ESP_Stash;
    public static UnityEngine.Color Color_ESPStash;
    public static bool ESP_Hemp;
    public static UnityEngine.Color Color_ESPHemp;
    public static bool ESP_TC;
    public static UnityEngine.Color Color_ESPTC;
    public static bool ESP_Corpse;
    public static UnityEngine.Color Color_ESPCorpse;
    public static int ESP_TrapRange;
    public static bool ESP_BearTrap;
    public static UnityEngine.Color Color_ESPBearTrap;
    public static bool ESP_Landmine;
    public static UnityEngine.Color Color_ESPLandmine;
    public static bool ESP_Autoturret;
    public static UnityEngine.Color Color_ESPAutoturret;
    public static bool ESP_Flameturret;
    public static UnityEngine.Color Color_ESPFlameturret;
    public static bool ESP_Shotgun;
    public static UnityEngine.Color Color_ESPShotgun;
    public static bool ESP_ShowTCAuth;
    public static bool ESP_ShowInventory;
    public static bool Aim_Active;
    public static int AimMode;
    public static bool Aim_Smooth;
    public static bool Aim_VisCheck;
    public static bool Aim_Heli;
    public static bool Aim_ForceAuto;
    public static bool Aim_Whitelist;
    public static bool Aim_BoltFast;
    public static int Aim_Range;
    public static int Aim_Fov;
    public static bool Aim_DrawFov;
    public static UnityEngine.Color Color_AimDrawFov;
    public static bool Aim_Xhair;
    public static UnityEngine.Color Color_AimXhair;
    public static int Aim_Position;
    public static bool Aim_NoRecoil;
    public static bool Aim_NoSpread;
    public static bool Aim_NoSway;
    public static bool Aim_NoDrag;
    public static bool Aim_NoDrop;
    public static bool Radar_Active;
    public static bool Radar_Friends;
    public static UnityEngine.Color Color_RadarFriends;
    public static bool Radar_Enemies;
    public static UnityEngine.Color Color_RadarEnemies;
    public static bool Radar_Animals;
    public static UnityEngine.Color Color_RadarAnimals;
    public static int Radar_X;
    public static int Radar_Y;
    public static int Radar_Size;
    public static int Radar_Range;
    public static bool ESP_Locations;
    public static UnityEngine.Color Color_ESPLocations;
    public static bool Misc_AdminPriv;
    public static bool Misc_Spider;
    public static bool Misc_Speed;
    public static bool Misc_Freeze;
    public static int Misc_FreezeValue;
    public static bool Misc_FastGather;
    public static bool Misc_LowGravity;
    public static bool Misc_NoSink;
    public static bool Misc_MultiJump;
    public static bool Misc_ShootAnywhere;
    public static bool Misc_DisarmBearTraps;
    public static bool Misc_AutoLock;
    public static string Misc_LockPIN;
    public static bool Misc_AutoUnlock;
    public static string Misc_UnlockPIN;
    public static bool Misc_DrawImage;
    public static string Misc_ImgPath;
    public static bool Misc_DisableP2P;
    public static bool Misc_InstantRevive;
    #endregion


    public static int FovRadius;

 

    public Vector3 ClampAngles(Vector3 angles)
    {
        if (angles.x > 89f)
            angles.x -= 360f;
        else if (angles.x < -89f)
            angles.x += 360f;
        if (angles.y > 180f)
            angles.y -= 360f;
        else if (angles.y < -180f)
            angles.y += 360f;

        angles.z = 0f;
        return angles;
    }


    private Vector3 v3FrontTopLeft;
    private Vector3 v3FrontTopRight;
    private Vector3 v3FrontBottomLeft;
    private Vector3 v3FrontBottomRight;
    private Vector3 v3BackTopLeft;
    private Vector3 v3BackTopRight;
    private Vector3 v3BackBottomLeft;
    private Vector3 v3BackBottomRight;

    private Vector2 v2FrontTopLeft;
    private Vector2 v2FrontTopRight;
    private Vector2 v2FrontBottomLeft;
    private Vector2 v2FrontBottomRight;
    private Vector2 v2BackTopLeft;
    private Vector2 v2BackTopRight;
    private Vector2 v2BackBottomLeft;
    private Vector2 v2BackBottomRight;


    void CalcPositons(BasePlayer p)
    {
        Bounds bounds = new Bounds();

        if (p.IsDucked())
        {
            bounds.center = p.transform.position + new Vector3(0f, 0.55f, 0f);
            bounds.extents = new Vector3(0.5f, 0.55f, 0.5f);
        }
        else
        {
            bounds.center = p.transform.position + new Vector3(0f, 0.9f, 0f);
            bounds.extents = new Vector3(0.5f, 0.9f, 0.5f);
        }

        Vector3 v3Center = bounds.center;
        Vector3 v3Extents = bounds.extents;

        v3FrontTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top left corner
        v3FrontTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top right corner
        v3FrontBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom left corner
        v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom right corner
        v3BackTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top left corner
        v3BackTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top right corner
        v3BackBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom left corner
        v3BackBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom right corner

        v3FrontTopLeft = transform.TransformPoint(v3FrontTopLeft);
        v3FrontTopRight = transform.TransformPoint(v3FrontTopRight);
        v3FrontBottomLeft = transform.TransformPoint(v3FrontBottomLeft);
        v3FrontBottomRight = transform.TransformPoint(v3FrontBottomRight);
        v3BackTopLeft = transform.TransformPoint(v3BackTopLeft);
        v3BackTopRight = transform.TransformPoint(v3BackTopRight);
        v3BackBottomLeft = transform.TransformPoint(v3BackBottomLeft);
        v3BackBottomRight = transform.TransformPoint(v3BackBottomRight);

        v2FrontTopLeft = MainCamera.mainCamera.WorldToScreenPoint(v3FrontTopLeft);
        v2FrontTopLeft.y = UnityEngine.Screen.height - v2FrontTopLeft.y;

        v2FrontTopRight = MainCamera.mainCamera.WorldToScreenPoint(v3FrontTopRight);
        v2FrontTopRight.y = UnityEngine.Screen.height - v2FrontTopRight.y;

        v2FrontBottomLeft = MainCamera.mainCamera.WorldToScreenPoint(v3FrontBottomLeft);
        v2FrontBottomLeft.y = UnityEngine.Screen.height - v2FrontBottomLeft.y;

        v2FrontBottomRight = MainCamera.mainCamera.WorldToScreenPoint(v3FrontBottomRight);
        v2FrontBottomRight.y = UnityEngine.Screen.height - v2FrontBottomRight.y;

        v2BackTopLeft = MainCamera.mainCamera.WorldToScreenPoint(v3BackTopLeft);
        v2BackTopLeft.y = UnityEngine.Screen.height - v2BackTopLeft.y;

        v2BackTopRight = MainCamera.mainCamera.WorldToScreenPoint(v3BackTopRight);
        v2BackTopRight.y = UnityEngine.Screen.height - v2BackTopRight.y;

        v2BackBottomLeft = MainCamera.mainCamera.WorldToScreenPoint(v3BackBottomLeft);
        v2BackBottomLeft.y = UnityEngine.Screen.height - v2BackBottomLeft.y;

        v2BackBottomRight = MainCamera.mainCamera.WorldToScreenPoint(v3BackBottomRight);
        v2BackBottomRight.y = UnityEngine.Screen.height - v2BackBottomRight.y;


    }


    bool VisibleOnScreen(Vector3 point)
    {
        Vector3 onscreen = point - MainCamera.mainCamera.transform.position;
        if (Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onscreen) <= 0)
            return false;
        else
            return true;
    }

    void DrawBox()
    {

        if (VisibleOnScreen(v3FrontTopLeft) && VisibleOnScreen(v3FrontTopRight) && VisibleOnScreen(v3FrontBottomLeft) && VisibleOnScreen(v3FrontBottomRight) && VisibleOnScreen(v3BackTopLeft) && VisibleOnScreen(v3BackTopRight) && VisibleOnScreen(v3BackBottomLeft) && VisibleOnScreen(v3BackBottomRight))
        {

            Drawing.DrawLine(v2FrontTopLeft, v2FrontTopRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontTopRight, v2FrontBottomRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontBottomRight, v2FrontBottomLeft, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontBottomLeft, v2FrontTopLeft, UnityEngine.Color.green, 1.5f, false);

            Drawing.DrawLine(v2BackTopLeft, v2BackTopRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2BackTopRight, v2BackBottomRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2BackBottomRight, v2BackBottomLeft, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2BackBottomLeft, v2BackTopLeft, UnityEngine.Color.green, 1.5f, false);

            Drawing.DrawLine(v2FrontTopLeft, v2BackTopLeft, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontTopRight, v2BackTopRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontBottomRight, v2BackBottomRight, UnityEngine.Color.green, 1.5f, false);
            Drawing.DrawLine(v2FrontBottomLeft, v2BackBottomLeft, UnityEngine.Color.green, 1.5f, false);

        }
    }

    float NormalizeAngle(float angle)
    {
        while (angle > 360)
            angle -= 360;
        while (angle < 0)
            angle += 360;
        return angle;
    }

    Vector3 NormalizeAngles(Vector3 angles)
    {
        angles.x = NormalizeAngle(angles.x);
        angles.y = NormalizeAngle(angles.y);
        angles.z = NormalizeAngle(angles.z);
        return angles;
    }

    Vector3 EulerAngles(Quaternion q1)
    {
        float sqw = q1.w * q1.w;
        float sqx = q1.x * q1.x;
        float sqy = q1.y * q1.y;
        float sqz = q1.z * q1.z;
        float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
        float test = q1.x * q1.w - q1.y * q1.z;
        Vector3 v;

        if (test > 0.4995f * unit)
        { // singularity at north pole
            v.y = 2.0f * Mathf.Atan2(q1.y, q1.x);
            v.x = Mathf.PI / 2;
            v.z = 0;
            return NormalizeAngles(v * 57.2958f);
        }
        if (test < -0.4995f * unit)
        { // singularity at south pole
            v.y = -2.0f * Mathf.Atan2(q1.y, q1.x);
            v.x = -Mathf.PI / 2;
            v.z = 0;
            return NormalizeAngles(v * 57.2958f);
        }
        Quaternion q = new Quaternion(q1.w, q1.z, q1.x, q1.y);
        v.y = (float)Mathf.Atan2(2.0f * q.x * q.w + 2.0f * q.y * q.z, 1 - 2.0f * (q.z * q.z + q.w * q.w));     // Yaw
        v.x = (float)Mathf.Asin(2.0f * (q.x * q.z - q.w * q.y));                             // Pitch
        v.z = (float)Mathf.Atan2(2.0f * q.x * q.y + 2.0f * q.z * q.w, 1 - 2.0f * (q.y * q.y + q.z * q.z));      // Roll
        return NormalizeAngles(v * 57.2958f);
    }



    Vector3 RotatePoint(Vector3 center, Vector3 origin, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        float s = -Mathf.Sin(rad);
        float c = Mathf.Cos(rad);

        origin.x -= center.x;
        origin.z -= center.z;

        float xnew = origin.x * c - origin.z * s;
        float znew = origin.x * s + origin.z * c;

        xnew += center.x;
        znew += center.z;


        return new Vector3(xnew, origin.y, znew);
    }


    void DrawBoundingBox(BasePlayer p, UnityEngine.Color dwColor, bool ThreeD)
    {

        Vector2 v2FrontTopLeft;
        Vector2 v2FrontTopRight;
        Vector2 v2FrontBottomLeft;
        Vector2 v2FrontBottomRight;
        Vector2 v2BackTopLeft;
        Vector2 v2BackTopRight;
        Vector2 v2BackBottomLeft;
        Vector2 v2BackBottomRight;



        if (PlayerBoxes.ContainsKey(p.userID.ToString()))
        {

            v2FrontTopRight = PlayerBoxes[p.userID.ToString()].frontTopright;
            v2FrontTopLeft = PlayerBoxes[p.userID.ToString()].frontTopleft;
            v2FrontBottomRight = PlayerBoxes[p.userID.ToString()].frontBottomright;
            v2FrontBottomLeft = PlayerBoxes[p.userID.ToString()].frontBottomleft;
            v2BackTopRight = PlayerBoxes[p.userID.ToString()].backTopright;
            v2BackTopLeft = PlayerBoxes[p.userID.ToString()].backTopleft;
            v2BackBottomRight = PlayerBoxes[p.userID.ToString()].backBottomright;
            v2BackBottomLeft = PlayerBoxes[p.userID.ToString()].backBottomleft;

            if (ThreeD)
            {
                Drawing.DrawLine(v2FrontTopLeft, v2FrontTopRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontTopRight, v2FrontBottomRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontBottomRight, v2FrontBottomLeft, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontBottomLeft, v2FrontTopLeft, dwColor, 1.85f, true);

                Drawing.DrawLine(v2BackTopLeft, v2BackTopRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2BackTopRight, v2BackBottomRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2BackBottomRight, v2BackBottomLeft, dwColor, 1.85f, true);
                Drawing.DrawLine(v2BackBottomLeft, v2BackTopLeft, dwColor, 1.85f, true);

                Drawing.DrawLine(v2FrontTopLeft, v2BackTopLeft, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontTopRight, v2BackTopRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontBottomRight, v2BackBottomRight, dwColor, 1.85f, true);
                Drawing.DrawLine(v2FrontBottomLeft, v2BackBottomLeft, dwColor, 1.85f, true);
            }
            else
            {
                Vector2[] boundsarry = { v2FrontBottomLeft, v2BackTopRight, v2BackBottomLeft, v2FrontTopRight, v2FrontBottomRight, v2BackBottomRight, v2BackTopLeft, v2FrontTopLeft };

                float l = v2FrontBottomLeft.x; // left
                float t = v2FrontBottomLeft.y; // top
                float r = v2FrontBottomLeft.x; // right
                float b = v2FrontBottomLeft.y; // bottom

                for (int i = 1; i < 8; i++)
                {
                    if (l > boundsarry[i].x) l = boundsarry[i].x;
                    if (t < boundsarry[i].y) t = boundsarry[i].y;
                    if (r < boundsarry[i].x) r = boundsarry[i].x;
                    if (b > boundsarry[i].y) b = boundsarry[i].y;
                }


                Drawing.DrawLine(new Vector2(l, b), new Vector2(l, t), dwColor, 1.85f, true);
                Drawing.DrawLine(new Vector2(l, t), new Vector2(r, t), dwColor, 1.85f, true);
                Drawing.DrawLine(new Vector2(r, t), new Vector2(r, b), dwColor, 1.85f, true);
                Drawing.DrawLine(new Vector2(r, b), new Vector2(l, b), dwColor, 1.85f, true);
            }


        }


    }


    void DrawBones(BasePlayer p, UnityEngine.Color color)
    {

        if (PlayerBones.ContainsKey(p.userID.ToString()))
        {

            Vector2 head2 = PlayerBones[p.userID.ToString()].head;
            Vector2 spine2 = PlayerBones[p.userID.ToString()].spine;
            Vector2 l_upper2 = PlayerBones[p.userID.ToString()].l_shoulder;
            Vector2 r_upper2 = PlayerBones[p.userID.ToString()].r_shoulder;
            Vector2 l_fore2 = PlayerBones[p.userID.ToString()].l_elbow;
            Vector2 r_fore2 = PlayerBones[p.userID.ToString()].r_elbow;
            Vector2 l_hand2 = PlayerBones[p.userID.ToString()].l_hand;
            Vector2 r_hand2 = PlayerBones[p.userID.ToString()].r_hand;
            Vector2 pelvis2 = PlayerBones[p.userID.ToString()].pelvis;
            Vector2 l_hip2 = PlayerBones[p.userID.ToString()].l_hip;
            Vector2 r_hip2 = PlayerBones[p.userID.ToString()].r_hip;
            Vector2 l_knee2 = PlayerBones[p.userID.ToString()].l_knee;
            Vector2 r_knee2 = PlayerBones[p.userID.ToString()].r_knee;
            Vector2 l_foot2 = PlayerBones[p.userID.ToString()].l_foot;
            Vector2 r_foot2 = PlayerBones[p.userID.ToString()].r_foot;


            Drawing.DrawLine(head2, spine2, color, 1.2f, true);
            Drawing.DrawLine(spine2, l_upper2, color, 1.2f, true);
            Drawing.DrawLine(l_upper2, l_fore2, color, 1.2f, true);
            Drawing.DrawLine(l_fore2, l_hand2, color, 1.2f, true);
            Drawing.DrawLine(spine2, r_upper2, color, 1.2f, true);
            Drawing.DrawLine(r_upper2, r_fore2, color, 1.2f, true);
            Drawing.DrawLine(r_fore2, r_hand2, color, 1.2f, true);
            Drawing.DrawLine(spine2, pelvis2, color, 1.2f, true);
            Drawing.DrawLine(pelvis2, l_hip2, color, 1.2f, true);
            Drawing.DrawLine(l_hip2, l_knee2, color, 1.2f, true);
            Drawing.DrawLine(l_knee2, l_foot2, color, 1.2f, true);
            Drawing.DrawLine(pelvis2, r_hip2, color, 1.2f, true);
            Drawing.DrawLine(r_hip2, r_knee2, color, 1.2f, true);
            Drawing.DrawLine(r_knee2, r_foot2, color, 1.2f, true);

        }


    }


    public struct ItemInventory
    {
        public int count;
        public string name;
    }


    internal static object GetInstanceField(Type type, object instance, string fieldName)
    {
        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static;
        FieldInfo field = type.GetField(fieldName, bindFlags);
        return field.GetValue(instance);
    }

    private void OnGUI()
    {

        try
        {

            if (heliObject != null)
            {
                if (!heliObject.IsAlive())
                {
                    heliObject = null;
                }
            }


            if (localplayer == null)
            {
                foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
                {
                    if (player.IsLocalPlayer())
                    {
                        localplayer = player;
                    }
                }
            }


            if (Renders.initialized == false)
            {
                Renders.Initialize();
            }

          


            if (Radar_Active)
            {
                if (Radar_Size % 2 != 0)
                    Radar_Size -= 1;

                Renders.DrawRadarBackground(new Rect(Radar_X, Radar_Y, Radar_Size, Radar_Size));
                Renders.BoxRect(new Rect(Radar_X + (Radar_Size / 2) - 3, Radar_Y + (Radar_Size / 2) - 3, 6f, 6f), UnityEngine.Color.magenta);


                foreach (BasePlayer p in BasePlayer.VisiblePlayerList)
                {
                    if (p != null && p.health > 0f && !p.IsSleeping() && !p.IsLocalPlayer())
                    {

                        if (Radar_Enemies && Whitelist.Contains(p.userID.ToString()) == false)
                        {

                            Vector3 centerPos = localplayer.transform.position;
                            Vector3 extPos = p.transform.position;

                            float dist = Vector3.Distance(centerPos, extPos);

                            float dx = centerPos.x - extPos.x;
                            float dz = centerPos.z - extPos.z;

                            float deltay = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg - 270 - localplayer.transform.eulerAngles.y;

                            float bX = dist * Mathf.Cos(deltay * Mathf.Deg2Rad);
                            float bY = dist * Mathf.Sin(deltay * Mathf.Deg2Rad);

                            bX = bX * ((float)Radar_Size / (float)Radar_Range) / 2f;
                            bY = bY * ((float)Radar_Size / (float)Radar_Range) / 2f;

                            if (dist <= Radar_Range)
                            {
                                Renders.BoxRect(new Rect(Radar_X + (Radar_Size / 2) + bX - 3, Radar_Y + (Radar_Size / 2) + bY - 3, 6f, 6f), Color_RadarEnemies);
                            }

                        }

                        if (Radar_Friends && Whitelist.Contains(p.userID.ToString()) == true)
                        {

                            Vector3 centerPos = localplayer.transform.position;
                            Vector3 extPos = p.transform.position;

                            float dist = Vector3.Distance(centerPos, extPos);

                            float dx = centerPos.x - extPos.x;
                            float dz = centerPos.z - extPos.z;

                            float deltay = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg - 270 - localplayer.transform.eulerAngles.y;

                            float bX = dist * Mathf.Cos(deltay * Mathf.Deg2Rad);
                            float bY = dist * Mathf.Sin(deltay * Mathf.Deg2Rad);

                            bX = bX * ((float)Radar_Size / (float)Radar_Range) / 2f;
                            bY = bY * ((float)Radar_Size / (float)Radar_Range) / 2f;

                            if (dist <= Radar_Range)
                            {
                                Renders.BoxRect(new Rect(Radar_X + (Radar_Size / 2) + bX - 3, Radar_Y + (Radar_Size / 2) + bY - 3, 6f, 6f), Color_RadarFriends);
                            }

                        }


                    }
                }

                if (Radar_Animals)
                {
                    List<Animal> animalList = new List<Animal>(dictAnimals.Values);
                    foreach (Animal a in animalList)
                    {
                        Vector3 centerPos = localplayer.transform.position;
                        Vector3 extPos = a.position;

                        float dist = Vector3.Distance(centerPos, extPos);

                        float dx = centerPos.x - extPos.x;
                        float dz = centerPos.z - extPos.z;

                        float deltay = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg - 270 - localplayer.transform.eulerAngles.y;

                        float bX = dist * Mathf.Cos(deltay * Mathf.Deg2Rad);
                        float bY = dist * Mathf.Sin(deltay * Mathf.Deg2Rad);

                        bX = bX * ((float)Radar_Size / (float)Radar_Range) / 2f;
                        bY = bY * ((float)Radar_Size / (float)Radar_Range) / 2f;

                        if (dist <= Radar_Range)
                        {
                            Renders.BoxRect(new Rect(Radar_X + (Radar_Size / 2) + bX - 3, Radar_Y + (Radar_Size / 2) + bY - 3, 6f, 6f), Color_RadarAnimals);
                        }
                    }
                }



            }

            if (ESP_Active && localplayer != null)
            {
        

                if (ESP_Node == true && dictResources.Count > 0)
                {
                    foreach (Resource r in dictResources.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(r.position);
                        if (vector.z > 0f)
                        {
                            int node_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, r.position);

                            if (node_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", r.name, node_distance), Color_ESPNode, true, 12);
                            }
                        }

                    }
                }



                if (ESP_Animal == true && dictAnimals.Count > 0)
                {
                    foreach (Animal a in dictAnimals.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(a.position);
                        if (vector.z > 0f)
                        {
                            int animal_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, a.position);

                            if (animal_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", a.name, animal_distance), Color_ESPAnimal, true, 12);
                            }
                        }

                    }
                }


                if (ESP_Dropped == true && dictDropped.Count > 0)
                {
                    foreach (Dropped d in dictDropped.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(d.position);
                        if (vector.z > 0f)
                        {
                            int dropped_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, d.position);

                            if (dropped_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", d.name, dropped_distance), Color_ESPDropped, true, 12);
                            }
                        }

                    }
                }

                if (Misc_AutoLock && dictCodelocks.Count > 0 && localplayer != null)
                {
                    foreach (CLock cl in dictCodelocks.Values)
                    {
                        int lock_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, cl.position);
                        CodeLock component = cl.entity.GetComponent<CodeLock>();
                        var lock_hascode = typeof(CodeLock).GetField("hasCode", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                        var bool_hascode = lock_hascode.GetValue(component);

                        MethodInfo point2point = localplayer.GetType().GetMethod("PointSeePoint", BindingFlags.NonPublic | BindingFlags.Instance);
                        bool canSeeLock = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, cl.position, 0f, false });

                        if (component.IsLocked() == false && (bool)bool_hascode == false && lock_distance <= 3f && canSeeLock)
                        {
                            cl.entity.ServerRPC("RPC_ChangeCode", Misc_LockPIN, false, null, null, null);
                        }
                    }

                }

                if (Misc_AutoUnlock && dictCodelocks.Count > 0 && localplayer != null)
                {
                    foreach (CLock cl in dictCodelocks.Values)
                    {
                        int lock_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, cl.position);

                        MethodInfo point2point = localplayer.GetType().GetMethod("PointSeePoint", BindingFlags.NonPublic | BindingFlags.Instance);
                        bool canSeeLock = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, cl.position, 0f, false });

                        if (cl.entity.IsLocked() && lock_distance <= 3f && canSeeLock)
                        {
                            cl.entity.ServerRPC("UnlockWithCode", Misc_UnlockPIN, false, null, null, null);
                        }
                    }

                }

                if (ESP_Heli && heliObject != null)
                {

                    int heli_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, heliObject.transform.position);
                    Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(heliObject.transform.position);
                    if (vector.z > 0f)
                    {
                        vector.x += 3f;
                        vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                        Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", "heli", heli_distance), Color_ESPHeli, true, 12);
                    }
                }

                if (ESP_Airdrop == true && dictAirdrops.Count > 0)
                {
                    foreach (Airdrop ad in dictAirdrops.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(ad.position);
                        if (vector.z > 0f)
                        {
                            int airdrop_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, ad.position);

                            if (airdrop_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", ad.name, airdrop_distance), Color_ESPAirdrop, true, 12);
                            }
                        }

                    }
                }


                if (ESP_Barrel == true && dictBarrels.Count > 0)
                {
                    foreach (Barrel b in dictBarrels.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(b.position);
                        if (vector.z > 0f)
                        {
                            int barrel_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, b.position);

                            if (barrel_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", b.name, barrel_distance), Color_ESPBarrel, true, 12);
                            }
                        }

                    }
                }

                if (ESP_Crate == true && dictCrates.Count > 0)
                {
                    foreach (Crate c in dictCrates.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(c.position);
                        if (vector.z > 0f)
                        {
                            int create_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, c.position);

                            if (create_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", c.name, create_distance), Color_ESPCrate, true, 12);
                            }
                        }

                    }
                }

                if (ESP_Stash == true && dictCrates.Count > 0)
                {
                    foreach (Stash s in dictStashes.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(s.position);
                        if (vector.z > 0f)
                        {
                            int stash_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, s.position);

                            if (stash_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", s.name, stash_distance), Color_ESPStash, true, 12);
                            }
                        }

                    }
                }



                if (ESP_Hemp == true && dictHemp.Count > 0)
                {
                    foreach (Hemp h in dictHemp.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(h.position);
                        if (vector.z > 0f)
                        {
                            int hemp_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, h.position);

                            if (hemp_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", h.name, hemp_distance), Color_ESPHemp, true, 12);
                            }
                        }

                    }
                }

                if (ESP_TC == true && dictTC.Count > 0)
                {
                    foreach (TC t in dictTC.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(t.position);
                        if (vector.z > 0f)
                        {
                            int tc_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, t.position);

                            if (tc_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", t.name, tc_distance), Color_ESPTC, true, 12);
                            }


                            if (ESP_ShowTCAuth)
                            {
                                BuildingPrivlidge bp = t.entity.GetComponent<BuildingPrivlidge>();
                                List<PlayerNameID> authedPlayers = new List<PlayerNameID>();
                                authedPlayers = bp.authorizedPlayers;

                                for (int x = 0; x < authedPlayers.Count; x++)
                                {
                                    Renders.DrawString(new Vector2(vector.x, vector.y - (x + 1) * 15f), authedPlayers[x].username, Color_ESPTC, true, 12);
                                }

                            }

                        }

                    }
                }


                if (ESP_Corpse == true && dictCorpses.Count > 0)
                {
                    foreach (Corpse c in dictCorpses.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(c.position);
                        if (vector.z > 0f)
                        {
                            int corpse_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, c.position);

                            if (corpse_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", c.name, corpse_distance), Color_ESPCorpse, true, 12);
                            }
                        }

                    }
                }


                if (ESP_BearTrap == true && dictBeartraps.Count > 0)
                {
                    foreach (Beartrap b in dictBeartraps.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(b.position);
                        if (vector.z > 0f)
                        {
                            int beartrap_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, b.position);

                            if (beartrap_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", b.name, beartrap_distance), Color_ESPBearTrap, true, 12);
                            }
                        }

                    }
                }


                if (ESP_Landmine == true && dictLandmines.Count > 0)
                {
                    foreach (Landmine m in dictLandmines.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(m.position);
                        if (vector.z > 0f)
                        {
                            int mine_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, m.position);

                            if (mine_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", m.name, mine_distance), Color_ESPLandmine, true, 12);
                            }
                        }

                    }
                }


                if (ESP_Autoturret == true && dictTurrets.Count > 0)
                {
                    foreach (Autoturret t in dictTurrets.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(t.position);
                        if (vector.z > 0f)
                        {
                            int turret_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, t.position);

                            if (turret_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", t.name, turret_distance), Color_ESPAutoturret, true, 12);
                            }
                        }

                    }
                }


                if (ESP_Flameturret == true && dictFlames.Count > 0)
                {
                    foreach (Flameturret f in dictFlames.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(f.position);
                        if (vector.z > 0f)
                        {
                            int flame_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, f.position);

                            if (flame_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", f.name, flame_distance), Color_ESPFlameturret, true, 12);
                            }
                        }

                    }
                }

                if (ESP_Shotgun == true && dictShotguns.Count > 0)
                {
                    foreach (Shotguntrap s in dictShotguns.Values)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(s.position);
                        if (vector.z > 0f)
                        {
                            int shotgun_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, s.position);

                            if (shotgun_distance <= ESP_ActiveRange)
                            {
                                vector.x += 3f;
                                vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                                Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", s.name, shotgun_distance), Color_ESPShotgun, true, 12);
                            }
                        }

                    }
                }

                if (ESP_Locations == true && dictLocations.Count > 0)
                {
                    List<string> locNames = new List<string>(dictLocations.Keys);
                    List<Vector3> locV3 = new List<Vector3>(dictLocations.Values);

                    for (int x = 0; x < locNames.Count; x++)
                    {

                        Vector3 vector = MainCamera.mainCamera.WorldToScreenPoint(locV3[x]);
                        if (vector.z > 0f)
                        {
                            int loc_distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, locV3[x]);


                            vector.x += 3f;
                            vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                            Renders.DrawString(new Vector2(vector.x, vector.y), string.Format("{0} [{1}]", locNames[x], loc_distance), Color_ESPLocations, true, 12);

                        }

                    }

                }


                if (ESP_ShowInventory)
                {

                    Dictionary<BasePlayer, int> inventoryList = new Dictionary<BasePlayer, int> { };
                    Vector2 centerScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);

                    foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
                    {
                        if (player != null)
                        {
                            int distanceFromCenter = (int)(Vector2.Distance(MainCamera.mainCamera.WorldToScreenPoint(player.transform.position), centerScreen));
                            Vector3 onScreen = player.transform.position - MainCamera.mainCamera.transform.position;

                            if (!player.IsLocalPlayer() && player.health > 0f && Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onScreen) > 0)
                                inventoryList.Add(player, distanceFromCenter);
                        }
                    }

                    if (inventoryList.Count > 0)
                    {

                        inventoryList = inventoryList.OrderBy(pair => pair.Value)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value);

                        BasePlayer closestPlayer = inventoryList.Keys.First();

                        if (closestPlayer != null)
                        { 

                            Item[] allItems = closestPlayer.inventory.AllItems();
                           
                                Rect bgRect = new Rect(Screen.width - 250f, 60f, 200f, 35f + (float)(allItems.Length * 16));
                                Renders.DrawRadarBackground(bgRect);
                                Renders.DrawString(new Vector2(Screen.width - 240f, 70f), closestPlayer.displayName, UnityEngine.Color.white, false, 14, true);


                            for (int x = 0; x < allItems.Length; x++)
                            {
                                if(allItems[x] != null)
                                    Renders.DrawString(new Vector2(Screen.width - 240f, 70f + (x + 1) * 16), allItems[x].amount.ToString() + "x " + allItems[x].info.displayName.english, UnityEngine.Color.white, false, 14, true);
                            }


                        }


                    }




                }

                foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
                {


                    if ((player != null) && (player.health > 0f) && !player.IsLocalPlayer())
                    {

                        Vector3 position = player.transform.position;
                        Vector3 vector3 = MainCamera.mainCamera.WorldToScreenPoint(position);


                        if(Misc_InstantRevive)
                        {
                            MethodInfo point2point = localplayer.GetType().GetMethod("PointSeePoint", BindingFlags.NonPublic | BindingFlags.Instance);
                            bool canSeePlayer = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, player.transform.position, 0f, false });

                            if (player != null && player.HasPlayerFlag(BasePlayer.PlayerFlags.Wounded) && Vector3.Distance(localplayer.transform.position, player.transform.position) <= 3f && Whitelist.Contains(player.userID.ToString()) && canSeePlayer)
                            {
                                player.ServerRPC("RPC_Assist", null, null, null, null, null);
                            }
                        }





                        if (vector3.z > 0f)
                        {
                            int distance = (int)Vector3.Distance(LocalPlayer.Entity.transform.position, position);
                            int cameradistance = (int)Vector3.Distance(MainCamera.mainCamera.transform.position, position);

                            Vector2 screenPos = vector3;
                            screenPos.y = UnityEngine.Screen.height - screenPos.y;


                            if (!player.IsSleeping() && ESP_OnlinePlayers)
                            {

                                if (ESP_Far)
                                {
                                    if (cameradistance <= ESP_FarRange)
                                    {

                                        Renders.DrawString(new Vector2(vector3.x, Screen.height - vector3.y), string.Format("{0} [{1}]", player.displayName, distance), Color_ESPOnlinePlayers, true, 12, true);

                                        Renders.DrawHealth(screenPos, player.Health(), true);

                                        if (player.GetHeldEntity() != null)
                                        {
                                            Renders.DrawWeapon(new Vector2(vector3.x, Screen.height - vector3.y), player.GetHeldEntity().ShortPrefabName.Replace(".prefab", ""), Color_ESPOnlinePlayers, true, 12, true);
                                        }
                                        else
                                        {
                                            Renders.DrawWeapon(new Vector2(vector3.x, Screen.height - vector3.y), "empty", Color_ESPOnlinePlayers, true, 12, true);
                                        }

                                        if (ESP_Boxes)
                                        {
                                            if (ESP_Boxes3D)
                                                DrawBoundingBox(player, Color_ESPOnlinePlayers, true);
                                            else
                                                DrawBoundingBox(player, Color_ESPOnlinePlayers, false);
                                        }

                                        if (ESP_Bones)
                                            DrawBones(player, Color_ESPBones);



                                    }
                                    else
                                    {
                                        Renders.DrawString(new Vector2(vector3.x, Screen.height - vector3.y), string.Format("{0} [{1}]", player.displayName, distance), Color_ESPFar, true, 11, true);
                                    }
                                }
                                else
                                {
                                    Renders.DrawString(new Vector2(vector3.x, Screen.height - vector3.y), string.Format("{0} [{1}]", player.displayName, distance), Color_ESPOnlinePlayers, true, 12, true);

                                    Renders.DrawHealth(screenPos, player.Health(), true);

                                    if (player.GetHeldEntity() != null)
                                    {
                                        Renders.DrawWeapon(new Vector2(vector3.x, Screen.height - vector3.y), player.GetHeldEntity().ShortPrefabName.Replace(".prefab", ""), Color_ESPOnlinePlayers, true, 12, true);
                                    }
                                    else
                                    {
                                        Renders.DrawWeapon(new Vector2(vector3.x, Screen.height - vector3.y), "empty", Color_ESPOnlinePlayers, true, 12, true);
                                    }

                                    if (ESP_Boxes)
                                    {
                                        if (ESP_Boxes3D)
                                            DrawBoundingBox(player, Color_ESPOnlinePlayers, true);
                                        else
                                            DrawBoundingBox(player, Color_ESPOnlinePlayers, false);
                                    }

                                    if (ESP_Bones)
                                        DrawBones(player, Color_ESPBones);
                                }



                            }
                            else
                            {
                                if (player.IsSleeping() && ESP_Sleepers)
                                    Renders.DrawString(new Vector2(vector3.x, Screen.height - vector3.y), string.Format("{0} [{1}]", player.displayName, distance), Color_ESPSleepers, true, 11, true);
                            }
                        }
                    }
                }


            }

            if (Aim_DrawFov)
            {
                FovRadius = (int)((float)Screen.width * ((float)Aim_Fov / ConVar.Graphics.fov)) / 2;
                Drawing.DrawCircle(new Vector2(Screen.width / 2, Screen.height / 2), FovRadius, Color_AimDrawFov, 1f, true, 30);
            }

            if (Aim_Xhair)
            {
                Drawing.DrawLine(new Vector2(Screen.width / 2, Screen.height / 2 - 9), new Vector2(Screen.width / 2, Screen.height / 2 + 9), Color_AimXhair, 1f, true);
                Drawing.DrawLine(new Vector2(Screen.width / 2 - 9, Screen.height / 2), new Vector2(Screen.width / 2 + 9, Screen.height / 2), Color_AimXhair, 1f, true);
            }


        }
        catch
        {
        }

    }





    private void Update()
    {
        //if (UnityEngine.Input.GetKeyDown(KeyCode.I))
        //{
        // bool_menu = !bool_menu;
        // }



    }




    public bool CanAttack()
    {
        return true;
    }

    public bool CanAttackTrampoline()
    {
        //trash code
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
        return false; //arbitrary return value
    }

    public float GetSpeed(float running, float ducking)
    {
        return 5f;
    }

    public float GetSpeedTrampoline(float running, float ducking)
    {
        //trash code
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
        return 0f; //arbitrary return value
    }



    private BaseEntity CreateOrUpdateEntity(ProtoBuf.Entity info, long size)
    {
        return CreateOrUpdateEntityTrampoline(info, size);
    }

    private BaseEntity CreateOrUpdateEntityTrampoline(ProtoBuf.Entity info, long size)
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
        return new BaseEntity(); //arbitrary return value
    }

    public virtual void UpdatePositionFromNetwork(Vector3 vPos)
    {

        try
        {
            BaseEntity BaseEnt = base.GetComponent<BaseEntity>();


            if (Type.Equals(base.GetType(), typeof(OreResourceEntity)))
            {


                if (dictResources.ContainsKey(base.GetInstanceID()))
                {
                    Resource update = new Resource();
                    update.name = dictResources[base.GetInstanceID()].name;
                    update.entity = dictResources[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictResources[base.GetInstanceID()] = update;
                }
                else
                {
                    Resource add = new Resource();
                    if (base.name.Contains("sulfur"))
                    {
                        add.name = "sulfur";
                    }
                    else if (base.name.Contains("metal"))
                    {
                        add.name = "metal";
                    }
                    else if (base.name.Contains("stone"))
                    {
                        add.name = "stone";
                    }

                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictResources.Add(base.GetInstanceID(), add);
                }
            }

            if (Type.Equals(base.GetType(), typeof(BaseHelicopter)))
            {
                heliObject = BaseEnt.GetComponent<BaseHelicopter>();
                helirotortop = new Vector3(base.GetComponent<BaseHelicopter>().mainRotor.transform.position.x, base.GetComponent<BaseHelicopter>().mainRotor.transform.position.y, base.GetComponent<BaseHelicopter>().mainRotor.transform.position.z);
                helirotorback = new Vector3(base.GetComponent<BaseHelicopter>().tailRotor.transform.position.x, base.GetComponent<BaseHelicopter>().tailRotor.transform.position.y, base.GetComponent<BaseHelicopter>().tailRotor.transform.position.z);
            }

            if (BaseEnt.HasTrait(BaseEntity.TraitFlag.Animal))
            {

                if (dictAnimals.ContainsKey(base.GetInstanceID()))
                {
                    Animal update = new Animal();
                    update.name = dictAnimals[base.GetInstanceID()].name;
                    update.entity = dictAnimals[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictAnimals[base.GetInstanceID()] = update;
                }
                else
                {
                    Animal add = new Animal();
                    if (base.name.Contains("bear"))
                    {
                        add.name = "bear";
                    }
                    else if (base.name.Contains("boar"))
                    {
                        add.name = "pig";
                    }
                    else if (base.name.Contains("wolf"))
                    {
                        add.name = "wolf";
                    }
                    else if (base.name.Contains("stag"))
                    {
                        add.name = "stag";
                    }
                    else if (base.name.Contains("chicken"))
                    {
                        add.name = "chicken";
                    }
                    else if (base.name.Contains("horse"))
                    {
                        add.name = "horse";
                    }

                    add.position = vPos;
                    add.entity = BaseEnt; ;
                    dictAnimals.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.gameObject.layer == 26 && BaseEnt.name.Contains("world"))
            {
                if (dictDropped.ContainsKey(base.GetInstanceID()))
                {
                    Dropped update = new Dropped();
                    update.name = dictDropped[base.GetInstanceID()].name;
                    update.entity = dictDropped[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictDropped[base.GetInstanceID()] = update;
                }
                else
                {
                    Dropped add = new Dropped();
                    add.name = BaseEnt.name;
                    add.position = vPos;
                    add.entity = BaseEnt; ;
                    dictDropped.Add(base.GetInstanceID(), add);
                }
            }


            if (Type.Equals(base.GetType(), typeof(CodeLock)))
            {

                if (dictCodelocks.ContainsKey(base.GetInstanceID()))
                {
                    CLock update = new CLock();
                    update.name = dictCodelocks[base.GetInstanceID()].name;
                    update.entity = dictCodelocks[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictCodelocks[base.GetInstanceID()] = update;
                }
                else
                {
                    CLock add = new CLock();
                    add.name = BaseEnt.name;
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictCodelocks.Add(base.GetInstanceID(), add);
                }
            }



            if (Type.Equals(base.GetType(), typeof(SupplyDrop)))
            {

                if (dictAirdrops.ContainsKey(base.GetInstanceID()))
                {
                    Airdrop update = new Airdrop();
                    update.name = dictAirdrops[base.GetInstanceID()].name;
                    update.entity = dictAirdrops[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictAirdrops[base.GetInstanceID()] = update;
                }
                else
                {
                    Airdrop add = new Airdrop();
                    add.name = "airdrop";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictAirdrops.Add(base.GetInstanceID(), add);
                }
            }


            if (BaseEnt.PrefabName.Contains("loot_barrel") || BaseEnt.PrefabName.Contains("oil_barrel") || BaseEnt.PrefabName.Contains("loot-barrel"))
            {
                if (dictBarrels.ContainsKey(base.GetInstanceID()))
                {
                    Barrel update = new Barrel();
                    update.name = dictBarrels[base.GetInstanceID()].name;
                    update.entity = dictBarrels[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictBarrels[base.GetInstanceID()] = update;
                }
                else
                {
                    Barrel add = new Barrel();
                    add.name = "barrel";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictBarrels.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("small_stash"))
            {
                if (dictStashes.ContainsKey(base.GetInstanceID()))
                {
                    Stash update = new Stash();
                    update.name = dictStashes[base.GetInstanceID()].name;
                    update.entity = dictStashes[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictStashes[base.GetInstanceID()] = update;
                }
                else
                {
                    Stash add = new Stash();
                    add.name = "Stash";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictStashes.Add(base.GetInstanceID(), add);
                }
            }


            if (BaseEnt.PrefabName.Contains("radtown/crate") || BaseEnt.PrefabName.Contains("heli_crate"))
            {
                if (dictCrates.ContainsKey(base.GetInstanceID()))
                {
                    Crate update = new Crate();
                    update.name = dictCrates[base.GetInstanceID()].name;
                    update.entity = dictCrates[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictCrates[base.GetInstanceID()] = update;
                }
                else
                {
                    Crate add = new Crate();
                    add.name = "crate";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictCrates.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("hemp"))
            {
                if (dictHemp.ContainsKey(base.GetInstanceID()))
                {
                    Hemp update = new Hemp();
                    update.name = dictHemp[base.GetInstanceID()].name;
                    update.entity = dictHemp[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictHemp[base.GetInstanceID()] = update;
                }
                else
                {
                    Hemp add = new Hemp();
                    add.name = "hemp";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictHemp.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("cupboard"))
            {
                if (dictTC.ContainsKey(base.GetInstanceID()))
                {
                    TC update = new TC();
                    update.name = dictTC[base.GetInstanceID()].name;
                    update.entity = dictTC[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictTC[base.GetInstanceID()] = update;
                }
                else
                {
                    TC add = new TC();
                    add.name = "cupboard";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictTC.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("player_corpse"))
            {

                if (dictCorpses.ContainsKey(base.GetInstanceID()))
                {
                    Corpse update = new Corpse();
                    update.name = dictCorpses[base.GetInstanceID()].name;
                    update.entity = dictCorpses[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictCorpses[base.GetInstanceID()] = update;
                }
                else
                {
                    Corpse add = new Corpse();
                    add.name = "corpse";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictCorpses.Add(base.GetInstanceID(), add);
                }
            }


            if (BaseEnt.PrefabName.Contains("flameturret"))
            {

                if (dictFlames.ContainsKey(base.GetInstanceID()))
                {
                    Flameturret update = new Flameturret();
                    update.name = dictFlames[base.GetInstanceID()].name;
                    update.entity = dictFlames[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictFlames[base.GetInstanceID()] = update;
                }
                else
                {
                    Flameturret add = new Flameturret();
                    add.name = "Flame Turret";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictFlames.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("guntrap"))
            {

                if (dictShotguns.ContainsKey(base.GetInstanceID()))
                {
                    Shotguntrap update = new Shotguntrap();
                    update.name = dictShotguns[base.GetInstanceID()].name;
                    update.entity = dictShotguns[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictShotguns[base.GetInstanceID()] = update;
                }
                else
                {
                    Shotguntrap add = new Shotguntrap();
                    add.name = "Shotgun Trap";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictShotguns.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("beartrap"))
            {

                if (dictBeartraps.ContainsKey(base.GetInstanceID()))
                {
                    Beartrap update = new Beartrap();
                    update.name = dictBeartraps[base.GetInstanceID()].name;
                    update.entity = dictBeartraps[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictBeartraps[base.GetInstanceID()] = update;
                }
                else
                {
                    Beartrap add = new Beartrap();
                    add.name = "Bear Trap";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictBeartraps.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("landmine"))
            {

                if (dictLandmines.ContainsKey(base.GetInstanceID()))
                {
                    Landmine update = new Landmine();
                    update.name = dictLandmines[base.GetInstanceID()].name;
                    update.entity = dictLandmines[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictLandmines[base.GetInstanceID()] = update;
                }
                else
                {
                    Landmine add = new Landmine();
                    add.name = "Landmine";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictLandmines.Add(base.GetInstanceID(), add);
                }
            }

            if (BaseEnt.PrefabName.Contains("autoturret"))
            {

                if (dictTurrets.ContainsKey(base.GetInstanceID()))
                {
                    Autoturret update = new Autoturret();
                    update.name = dictTurrets[base.GetInstanceID()].name;
                    update.entity = dictTurrets[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictTurrets[base.GetInstanceID()] = update;
                }
                else
                {
                    Autoturret add = new Autoturret();
                    add.name = "Auto Turret";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictTurrets.Add(base.GetInstanceID(), add);
                }
            }

            if (Type.Equals(base.GetType(), typeof(MeshPaintable)))
            {

                if (dictPaintings.ContainsKey(base.GetInstanceID()))
                {
                    Painting update = new Painting();
                    update.name = dictPaintings[base.GetInstanceID()].name;
                    update.entity = dictPaintings[base.GetInstanceID()].entity;
                    update.position = vPos;
                    dictPaintings[base.GetInstanceID()] = update;
                }
                else
                {
                    Painting add = new Painting();
                    add.name = "painting";
                    add.position = vPos;
                    add.entity = BaseEnt;
                    dictPaintings.Add(base.GetInstanceID(), add);
                }
            }



        }
        catch (Exception ex)
        {

        }

        if (base.transform.localPosition == vPos)
        {
            return;
        }
        base.transform.localPosition = vPos;
    }

    public virtual void UpdatePositionFromNetworkTrampoline(Vector3 vPos)
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
    }



    public virtual void ProjOnDeploy()
    {
        ProjOnDeployTrampoline();
    }

    public virtual void ProjOnDeployTrampoline()
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
    }


    //public static Dictionary<Projectile, BasePlayer> projlist;
    //public static List<BasePlayer> dictBasePlayer;
    //public static List<Projectile> dictProjectile;

    public struct RageProjectileInfo
    {
        public float timeCreated;
        public float timeToTarget;
        public BasePlayer target;
        public bool heli;
        public float distance;
    }


    public static List<Projectile> projlist;
    public static Dictionary<Projectile, RageProjectileInfo> rageProjectiles;
    public static Vector3 helirotortop = new Vector3(0f, 0f, 0f);
    public static Vector3 helirotorback = new Vector3(0f, 0f, 0f);

    private IEnumerator teleport()
    {

        while (true)
        {
           

            if(rageProjectiles.ToList().Count > 0)
            {

                foreach(KeyValuePair<Projectile, RageProjectileInfo> kvpRageProjectile in rageProjectiles.ToList())
                {

                    if (kvpRageProjectile.Key.integrity > 0f)
                    {

                        if (kvpRageProjectile.Value.heli != false)
                        {
                            if (Time.time - kvpRageProjectile.Value.timeCreated >= kvpRageProjectile.Value.timeToTarget)
                            {

                                kvpRageProjectile.Key.transform.LookAt(helirotortop);
                                var proj_cvelocity = typeof(Projectile).GetField("currentVelocity", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                                proj_cvelocity.SetValue(kvpRageProjectile.Key, kvpRageProjectile.Key.transform.forward * 5000);
                                rageProjectiles.Remove(kvpRageProjectile.Key);

                            }
                        }
                        else
                        {
                            if (Time.time - kvpRageProjectile.Value.timeCreated >= kvpRageProjectile.Value.timeToTarget)
                            {
                                if (kvpRageProjectile.Value.target.IsValid())
                                {

                                    kvpRageProjectile.Key.transform.LookAt(kvpRageProjectile.Value.target.GetModel().headBone);
                                    var proj_cvelocity = typeof(Projectile).GetField("currentVelocity", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                                    proj_cvelocity.SetValue(kvpRageProjectile.Key, kvpRageProjectile.Key.transform.forward * 5000);
                                    rageProjectiles.Remove(kvpRageProjectile.Key);

                                }
                                else
                                {
                                    rageProjectiles.Remove(kvpRageProjectile.Key);
                                }
                            }
                        }

                    }
                    else
                    {
                        rageProjectiles.Remove(kvpRageProjectile.Key);
                    }


                }

            }


            yield return new WaitForSeconds(0.02f);
        }
    }

    public static List<Projectile> plist;
    

    private IEnumerator GetSpeeds()
    {
        int ticks = 0;

        while(true)
        {
            foreach (Projectile p in plist.ToArray())
            {
                if (ticks < 4)
                {
                    var t_dist = typeof(Projectile).GetField("traveledDistance", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                    var v_dist = t_dist.GetValue(p);

                    var t_time = typeof(Projectile).GetField("traveledTime", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                    var v_time = t_time.GetValue(p);

                    ticks++;
                    UnityEngine.Debug.Log("Tick " + ticks.ToString() + "    Distance: " + v_dist.ToString() + " Time: " + v_time.ToString());
                } else
                {
                    ticks = 0;
                    plist.Clear();
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private Projectile CreateProjectile(string prefabPath, Vector3 pos, Vector3 forward, Vector3 velocity)
    {
        MethodInfo point2point = localplayer.GetType().GetMethod("PointSeePoint", BindingFlags.NonPublic | BindingFlags.Instance);

        Dictionary<BasePlayer, int> tempRage = new Dictionary<BasePlayer, int>();
        BasePlayer targetPlayer = null;

        if (rageTargets.Count > 0)
            targetPlayer = rageTargets.Keys.First();

        bool instaSpawn = false;

        if (AimMode == 2 && Input.GetMouseButton(1) && Aim_Active)
        {


            if (targetPlayer != null && rageHeli == false)
            {
               
                    if (Vector3.Distance(localplayer.transform.position, targetPlayer.transform.position) <= (GetProjectileSpeed() / 5) && (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, targetPlayer.GetModel().headBone.position, 0f, true }) == true)
                    {
                        pos = targetPlayer.GetModel().headBone.position;
                        instaSpawn = true;
                        velocity = new Vector3(0f, 0.1f, 0f);
                     }

            }
            


            if (targetPlayer != null && instaSpawn == false && rageHeli == false)
            {
                bool myPointVisible = (bool)point2point.Invoke(localplayer, new object[] { new Vector3(targetPlayer.GetModel().headBone.position.x, targetPlayer.GetModel().headBone.position.y + 1.5f, targetPlayer.GetModel().headBone.position.z), targetPlayer.GetModel().headBone.position, 0f, true });
                bool firstPointVisible = (bool)point2point.Invoke(localplayer, new object[] { new Vector3(pos.x, pos.y + 10f, pos.z), targetPlayer.GetModel().headBone.position, 0f, true });
                bool secondPointVisible = (bool)point2point.Invoke(localplayer, new object[] { new Vector3(pos.x, pos.y + 20f, pos.z), targetPlayer.GetModel().headBone.position, 0f, true });
                bool thirdPointVisible = (bool)point2point.Invoke(localplayer, new object[] { new Vector3(pos.x, pos.y + 30f, pos.z), targetPlayer.GetModel().headBone.position, 0f, true });

                /*  Vector3 pos1 = new Vector3(pos.x, pos.y + 50f, pos.z);
                  Vector3 pos2 = new Vector3(tempRage.Keys.First().GetModel().headBone.position.x, tempRage.Keys.First().GetModel().headBone.position.y + 50f, tempRage.Keys.First().GetModel().headBone.position.z);
                  Vector3 dir = pos2 - pos1;
                  float distance = Vector3.Distance(pos1, pos2);
                  Vector3 midpoint = pos1 + dir * (distance * 0.75f);
                  bool midPointVisible = (bool)point2point.Invoke(localplayer, new object[] { midpoint, tempRage.Keys.First().GetModel().headBone.position, 0f, true });
                  */

             if(myPointVisible)
                {
                    pos = new Vector3(targetPlayer.GetModel().headBone.position.x, targetPlayer.GetModel().headBone.position.y + 1.5f, targetPlayer.GetModel().headBone.position.z);
                    forward = targetPlayer.transform.forward;
                    velocity = new Vector3(0f, 0.01f, 0f);
                }
            }

            if (rageHeli)
            {
                if((bool)point2point.Invoke(localplayer, new object[] { pos, heliObject.transform.position, 0f, true }) == true || (bool)point2point.Invoke(localplayer, new object[] { pos, helirotortop, 0f, true }) == true || (bool)point2point.Invoke(localplayer, new object[] { pos, helirotorback, 0f, true }) == true)
                {
                    velocity = new Vector3(0f, 0.01f, 0f);
                    pos = new Vector3(helirotortop.x, helirotortop.y + 10f, helirotortop.z);
                }
                else
                {
                    rageHeli = false;
                }
            }

        }



        Projectile proj = CreateProjectileTrampoline(prefabPath, pos, forward, velocity);

        //var currentvelocity = typeof(Projectile).GetField("currentVelocity", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
        //var velocityvalue = currentvelocity.GetValue(proj);

        if(Aim_NoDrop || AimMode == 2)
            proj.gravityModifier = 0f;

        if (Aim_NoDrag || AimMode == 2)
            proj.drag = 0f;

        if (AimMode == 2 && Input.GetMouseButton(1) && instaSpawn == false && (targetPlayer != null || rageHeli) && Aim_Active)
        {

            proj.initialDistance = 0f;

            RageProjectileInfo rpi = new RageProjectileInfo();
            if (!rageHeli)
            {
                rpi.heli = false;
                rpi.target = targetPlayer;
                rpi.timeCreated = Time.time;
                rpi.timeToTarget = (Vector3.Distance(localplayer.transform.position, targetPlayer.FindBone("head").position) / GetProjectileSpeed()) * 1.20f;
                rpi.distance = Vector3.Distance(localplayer.transform.position, targetPlayer.FindBone("head").position);
            }
            else
            {
                rpi.heli = true;
                rpi.target = null;
                rpi.timeCreated = Time.time;
                rpi.timeToTarget = (Vector3.Distance(localplayer.transform.position, helirotortop) / GetProjectileSpeed()) * 1.50f;
                rpi.distance = Vector3.Distance(localplayer.transform.position, helirotortop);
            }
            rageProjectiles.Add(proj, rpi);
        }

        //plist.Add(proj);
        return proj;
    }

    private Projectile CreateProjectileTrampoline(string prefabPath, Vector3 pos, Vector3 foward, Vector3 velocity)
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
        return new Projectile();
    }



    private bool CanJump()
    {
        return true;
    }


    private bool CanJumpTrampoline()
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
        return true;
    }

    public bool isGatherWeapon(int id)
    {
        if (id == -1289478934 || id == 698310895 || id == 790921853 || id == -1440143841 || id == -578028723 || id == 789892804 || id == 776005741 || id == 3506021)
            return true;
        else
            return false;
    }


    protected void StartAttackCooldown(float cooldown)
    {
        if (Misc_FastGather)
        {
            if (isGatherWeapon((int)localplayer.GetHeldEntity().GetOwnerItemDefinition().itemid))
                cooldown = cooldown * 0.5f;
        }

        StartAttackCooldownTrampoline(cooldown);
    }

    protected void StartAttackCooldownTrampoline(float cooldown)
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
    }

    

    public void DrawImage(Texture2D texture)
    {


        if (Misc_DrawImage)
        {
            try
            {
                if (File.Exists(Misc_ImgPath))
                {
                    BaseEntity lookingAt = localplayer.lookingAtEntity;
                    Signage s = lookingAt.GetComponent<Signage>();

                    byte[] imgbytes = System.IO.File.ReadAllBytes(Misc_ImgPath);
                    Texture2D imgtexture = new Texture2D(1, 1, TextureFormat.ARGB32, true);
                    imgtexture.LoadImage(imgbytes);

                    float divideby = 1f;

                    if (imgtexture.width > 450 || imgtexture.height > 450)
                    {
                        if (imgtexture.width > imgtexture.height)
                        {
                            divideby = imgtexture.width / 450;
                        }
                        else if (imgtexture.height > imgtexture.width)
                        {
                            divideby = imgtexture.height / 450;
                        }
                        else
                        {
                            divideby = imgtexture.width / 450;
                        }
                    }


                    TextureScaler.scale(imgtexture, (int)(imgtexture.width / divideby), (int)(imgtexture.height / divideby), FilterMode.Trilinear);
                    s.paintableSource.Load(imgtexture.EncodeToPNG());

                    byte[] array = s.paintableSource.texture.EncodeToPNG();
                    using (MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, true, true))
                    {
                        FileStorage.client.Store(memoryStream, FileStorage.Type.png, s.net.ID, 0u);
                    }
                    lookingAt.ServerRPC("UpdateSign", (uint)array.Length, array, null, null, null);

                }
            }
            catch (Exception ex)
            {
                DrawImageTrampoline(texture);
            }
        }
        else
        {
            DrawImageTrampoline(texture);
        }



    }


    public void DrawImageTrampoline(Texture2D texture)
    {
        int a = 12;
        int b = 9;
        int c = 12 * 9 - 4;
        int d = c * a - 15;
        int e = d + a;
        int f = b + c;
        a = b + 12;
        b = c - 4;
        d = a + b;
        e = a + c + d;
    }

    

    DumbHook speed2;

    DumbHook canAttack;

    DumbHook CreateOrUpdate;
    DumbHook UpdatePositionFromNetwork_BaseEntity;

    DumbHook createproj;

    DumbHook createprojmelee;

    DumbHook jump;
    DumbHook attackcd;

    DumbHook drawImg;


    private void Start()
    {

        LoadSettings();
        StartCoroutine(UpdateSettings());

        Drawing.Initialize();

        byte[] CanAttackBytes = { 0x55, 0x48, 0x8b, 0xec, 0x56, 0x57, 0x41, 0x56, 0x48, 0x83, 0xec, 0x08 };
        canAttack = new DumbHook(typeof(BasePlayer), "CanAttack", typeof(Mystique), "CanAttack", typeof(Mystique), "CanAttackTrampoline", CanAttackBytes);

        byte[] GetSpeedBytes = { 0x55, 0x48, 0x8b, 0xec, 0x48, 0x83, 0xec, 0x20, 0xf3, 0x0f, 0x11, 0x4d, 0xf0, 0x90 };
        speed2 = new DumbHook(typeof(BasePlayer), "GetSpeed", typeof(Mystique), "GetSpeed", typeof(Mystique), "GetSpeedTrampoline", GetSpeedBytes);

        byte[] CreateUpdateBytes = { 0x55, 0x48, 0x8b, 0xec, 0x53, 0x56, 0x57, 0x41, 0x54, 0x41, 0x55, 0x41, 0x56 };
        CreateOrUpdate = new DumbHook(typeof(Client), "CreateOrUpdateEntity", typeof(Mystique), "CreateOrUpdateEntity", typeof(Mystique), "CreateOrUpdateEntityTrampoline", CreateUpdateBytes);
        CreateOrUpdate.Hook();

        byte[] BaseEntity_UpdatePosBytes = { 0x55, 0x48, 0x8b, 0xec, 0x56, 0x48, 0x83, 0xec, 0x38, 0x48, 0x8b, 0xf1 };
        UpdatePositionFromNetwork_BaseEntity = new DumbHook(typeof(BaseEntity), "UpdatePositionFromNetwork", typeof(Mystique), "UpdatePositionFromNetwork", typeof(Mystique), "UpdatePositionFromNetworkTrampoline", BaseEntity_UpdatePosBytes);
        UpdatePositionFromNetwork_BaseEntity.Hook();

        byte[] CreateProjectileBytes = { 0x55, 0x48, 0x8b, 0xec, 0x56, 0x57, 0x41, 0x57, 0x48, 0x83, 0xec, 0x28 };
        createproj = new DumbHook(typeof(BaseProjectile), "CreateProjectile", typeof(Mystique), "CreateProjectile", typeof(Mystique), "CreateProjectileTrampoline", CreateProjectileBytes);
        createproj.Hook();


        byte[] canJumpBytes = { 0x55, 0x48, 0x8b, 0xec, 0x56, 0x48, 0x83, 0xec, 0x08, 0x48, 0x8b, 0xf1 };
        jump = new DumbHook(typeof(PlayerWalkMovement), "CanJump", typeof(Mystique), "CanJump", typeof(Mystique), "CanJumpTrampoline", canJumpBytes);

        byte[] startAttackCdBytes = { 0x55, 0x48, 0x8b, 0xec, 0x56, 0x48, 0x83, 0xec, 0x08, 0x48, 0x8b, 0xf1};
        attackcd = new DumbHook(typeof(AttackEntity), "StartAttackCooldown", typeof(Mystique), "StartAttackCooldown", typeof(Mystique), "StartAttackCooldownTrampoline", startAttackCdBytes);
        attackcd.Hook();

  

        byte[] drawImgBytes = { 0x55, 0x48, 0x8b, 0xec, 0x57, 0x41, 0x57, 0x48, 0x83, 0xec, 0x40, 0x48, 0x8b, 0xf9 };
        drawImg = new DumbHook(typeof(Signage), "OnTextureWasEdited", typeof(Mystique), "DrawImage", typeof(Mystique), "DrawImageTrampoline", drawImgBytes);
        drawImg.Hook();


     



        projlist = new List<Projectile>();
        plist = new List<Projectile>();
        rageProjectiles = new Dictionary<Projectile, RageProjectileInfo> { };

        StartCoroutine(aim());
        StartCoroutine(teleport());
        StartCoroutine(Removals());

        StartCoroutine(WriteOutput());
        StartCoroutine(CalculatePositions());

        StartCoroutine(CheckObjectValid());
        StartCoroutine(MiscFuncs());

        //StartCoroutine(GetSpeeds());

    }


    public static Dictionary<BasePlayer, int> rageTargets;
    public static bool rageHeli;


    private IEnumerator aim()
    {

        Vector3 targetLastPosition = Vector3.zero;
        Vector3 targetVelocity = Vector3.zero;
        BasePlayer aimTarget = null;
        bool aimHeli = false;
        float currenttime = 0f;
        float lasttime = 0f;
        Vector2 centerScreen = Vector2.zero;
        Vector3 target_AimPos = Vector3.zero;

        rageTargets = new Dictionary<BasePlayer, int> { };
        rageHeli = false;

        Dictionary<BasePlayer, int> playerList = new Dictionary<BasePlayer, int> { };

        while (true)
        {

            while (localplayer == null || !localplayer || !Aim_Active || !Input.GetMouseButton(1))
            {
                aimHeli = false;
                aimTarget = null;
                yield return new WaitForSeconds(0.01f);
            }


            MethodInfo point2point = localplayer.GetType().GetMethod("PointSeePoint", BindingFlags.NonPublic | BindingFlags.Instance);
            centerScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);


            if (AimMode == 1 && validAimWeapon())
            {

                if(!aimTarget.IsValid() || aimTarget.health == 0f)
                {
                    aimTarget = null;
                }

                if(heliObject != null)
                {
                    Vector3 onScreen = heliObject.transform.position - MainCamera.mainCamera.transform.position;
                    int distanceFromCenter = (int)(Vector2.Distance(MainCamera.mainCamera.WorldToScreenPoint(helirotortop), centerScreen));

                    if (Aim_Heli)
                    {
                        if (distanceFromCenter <= FovRadius && Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onScreen) > 0)
                            aimHeli = true;
                        else
                            aimHeli = false;
                    }
                    else
                        aimHeli = false;
                }
                else
                {
                    aimHeli = false;
                }

                if (aimTarget == null && aimHeli == false)
                {
                    playerList.Clear();
                    targetLastPosition = Vector3.zero;
                    targetVelocity = Vector3.zero;
                    currenttime = 0f;
                    lasttime = 0f;

                    foreach (BasePlayer p in BasePlayer.VisiblePlayerList)
                    {
                        int distanceFromCenter = (int)(Vector2.Distance(MainCamera.mainCamera.WorldToScreenPoint(p.transform.position), centerScreen));
                        int distanceFromMe = (int)(Vector3.Distance(localplayer.transform.position, p.transform.position));
                        Vector3 onScreen = p.GetModel().eyeBone.position - MainCamera.mainCamera.transform.position;

                        if (distanceFromMe <= Aim_Range && distanceFromCenter <= FovRadius && !p.IsLocalPlayer() && !p.IsSleeping() && p.health > 0f && !Whitelist.Contains(p.userID.ToString()) && Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onScreen) > 0)
                            playerList.Add(p, distanceFromCenter);
                    }

                    if (playerList.Count > 0)
                    {


                        var sortList = playerList.OrderBy(pair => pair.Value)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value);


                        if (!Aim_VisCheck)
                            aimTarget = sortList.Keys.First();
                        else
                        {
                            List<BasePlayer> dictKeys = new List<BasePlayer>(sortList.Keys);

                            foreach (BasePlayer p in dictKeys)
                            {
                                bool canSeeAimPos = false;

                                if (Aim_Position == 0)
                                {
                                    canSeeAimPos = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, p.GetModel().headBone.position, 0f, true });
                                }
                                else if (Aim_Position == 1)
                                {
                                    canSeeAimPos = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, p.FindBone("spine3").position, 0f, true });
                                }
                                else
                                {
                                    canSeeAimPos = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, p.GetModel().headBone.position, 0f, true });
                                    if (!canSeeAimPos)
                                        canSeeAimPos = (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, p.FindBone("spine3").position, 0f, true });
                                }
 

                                if (!canSeeAimPos)
                                    continue;
                                else
                                {
                                    aimTarget = p;
                                    break;
                                }

                            }

                        }

                    }
                }

                if (aimTarget != null || aimHeli == true)
                {
                    Vector3 unlerped = Vector3.zero;
                    Vector3 inverse;

                    if(aimHeli)
                        inverse = base.transform.InverseTransformDirection(helirotortop - targetLastPosition);
                    else
                        inverse = base.transform.InverseTransformDirection(aimTarget.transform.position - targetLastPosition);


                    currenttime = Time.time;
                    if (lasttime != 0F && currenttime != lasttime)
                    {
                        unlerped = inverse / (currenttime - lasttime);
                        targetVelocity = Vector3.Lerp(targetVelocity, unlerped, 0.1f);
                        //targetVelocity = unlerped;
                    }

                    lasttime = currenttime;

                    if (aimHeli)
                        targetLastPosition = helirotortop;
                    else
                         targetLastPosition = aimTarget.transform.position;

                    if (aimHeli)
                        target_AimPos = helirotortop;
                    else
                    {
                        if (Aim_Position == 0)
                        {
                            target_AimPos = aimTarget.GetModel().headBone.position;
                        }
                        else if (Aim_Position == 1)
                        {
                            target_AimPos = aimTarget.FindBone("spine3").position;
                        }
                        else
                        {
                            System.Random rand = new System.Random();
                            int randomSpot = rand.Next(0, 4);
                            switch (randomSpot)
                            {
                                case 0:
                                    target_AimPos = aimTarget.GetModel().headBone.position;
                                    break;
                                case 1:
                                    target_AimPos = aimTarget.FindBone("spine3").position;
                                    break;
                                case 2:
                                    target_AimPos = aimTarget.FindBone("pelvis").position;
                                    break;
                                case 3:
                                    target_AimPos = aimTarget.FindBone("l_upperarm").position;
                                    break;
                                case 4:
                                    target_AimPos = aimTarget.FindBone("r_upperarm").position;
                                    break;
                            }
                        }
                    }


                    float traveltime = Vector3.Distance(LocalPlayer.Entity.transform.position, target_AimPos) / GetProjectileSpeed();

                    target_AimPos.x += (float)(targetVelocity.x * traveltime);
                    target_AimPos.y += (float)(targetVelocity.y * traveltime);
                    target_AimPos.z += (float)(targetVelocity.z * traveltime);


                    if (!Aim_NoDrop)
                        target_AimPos.y += (float)(0.5 * 9.81f * traveltime * traveltime);

                    Vector3 relative = MainCamera.mainCamera.transform.position - target_AimPos;
                    double pitch = Math.Asin(relative.y / relative.magnitude);
                    double yaw = -Math.Atan2(relative.x, -relative.z);

                    yaw = yaw * Mathf.Rad2Deg;
                    pitch = pitch * Mathf.Rad2Deg;

                    Vector3 viewangles = new Vector3((float)pitch, (float)yaw, 0f);
                    viewangles = ClampAngles(viewangles);


                    LocalPlayer.Entity.input.SetViewVars(viewangles);
                }


            }
            else if(AimMode == 2)
            {
                rageTargets.Clear();

                if (heliObject != null)
                {
                    Vector3 onScreen = heliObject.transform.position - MainCamera.mainCamera.transform.position;
                    int distanceFromCenter = (int)(Vector2.Distance(MainCamera.mainCamera.WorldToScreenPoint(helirotortop), centerScreen));

                    if (Aim_Heli)
                    {
                        if (distanceFromCenter <= FovRadius && Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onScreen) > 0)
                            rageHeli = true;
                        else
                            rageHeli = false;
                    }
                    else
                        rageHeli = false;
                }
                else
                {
                    rageHeli = false;
                }


                if(rageHeli == false)
                {
                    foreach (BasePlayer p in BasePlayer.VisiblePlayerList)
                    {
                        int distanceFromCenter = (int)(Vector2.Distance(MainCamera.mainCamera.WorldToScreenPoint(p.transform.position), centerScreen));
                        int distanceFromMe = (int)(Vector3.Distance(localplayer.transform.position, p.transform.position));
                        Vector3 onScreen = p.GetModel().eyeBone.position - MainCamera.mainCamera.transform.position;

                        if (distanceFromMe <= Aim_Range && distanceFromCenter <= FovRadius && !p.IsLocalPlayer() && !p.IsSleeping() && p.health > 0f && !Whitelist.Contains(p.userID.ToString()) && Vector3.Dot(MainCamera.mainCamera.transform.TransformDirection(Vector3.forward), onScreen) > 0 && (bool)point2point.Invoke(localplayer, new object[] { localplayer.GetModel().eyeBone.position, p.GetModel().headBone.position, 0f, false }) == true)
                            rageTargets.Add(p, distanceFromCenter);

                        if(rageTargets.Count > 0)
                        {
                            rageTargets = rageTargets.OrderBy(pair => pair.Value)
                                      .ToDictionary(pair => pair.Key, pair => pair.Value);
                        }
                    }

                }

            }


            yield return new WaitForSeconds(0.075f);
        }

    }

   
    public bool validAimWeapon()
    {

        if(localplayer.GetHeldEntity() == null)
        {
            return false;
        }


        int itemID = (int)localplayer.GetHeldEntity().GetOwnerItemDefinition().itemid;
        bool valid = false;

        switch (itemID)
        {
            case -1461508848:
                valid = true;
                break;
            case -1716193401:
                valid = true;
                break;
            case 193190034:
                valid = true;
                break;
            case -55660037:
                valid = true;
                break;
            case 109552593:
                valid = true;
                break;
            case -2094080303:
                valid = true;
                break;
            case 2033918259:
                valid = true;
                break;
            case 371156815:
                valid = true;
                break;
            case -930579334:
                valid = true;
                break;
            case -1745053053:
                valid = true;
                break;
            case 548699316:
                valid = true;
                break;
            case 456448245:
                valid = true;
                break;
            case -853695669:
                valid = true;
                break;
            case 2123300234:
                valid = true;
                break;
        }

        return valid;
    }


    public float GetProjectileSpeed()
    {

        if (localplayer.GetHeldEntity() == null)
        {
            return 375f;
        }


        int itemID = (int)localplayer.GetHeldEntity().GetOwnerItemDefinition().itemid;
        float speed = 300f;

        switch(itemID)
        {
            case -1461508848:
                speed = 375f;
                break;
            case -1716193401:
                speed = 375f;
                break;
            case 193190034:
                speed = 375f;
                break;
            case -55660037:
                if (!Aim_BoltFast)
                    speed = 375f;
                else
                    speed = 1875f;
                break;
            case 109552593:
                speed = 240f;
                break;
            case -2094080303:
                speed = 240f;
                break;
            case 2033918259:
                speed = 300f;
                break;
            case 371156815:
                speed = 300f;
                break;
            case -930579334:
                speed = 300f;
                break;
            case -1745053053:
                speed = 375f;
                break;
            case 548699316:
                speed = 300f;
                break;
            case 456448245:
                speed = 300f;
                break;
            case -853695669:
                speed = 59f;
                break;
            case 2123300234:
                speed = 59f;
                break;
        }

        if (localplayer.GetHeldEntity().GetComponent<BaseProjectile>().IsSilenced())
            speed = speed * 0.745f;

        return speed;
    }


    unsafe void FlickerHook(bool set)
    {
        MethodInfo envSync = typeof(EnvSync).GetMethod("Update", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { }, null);
        RuntimeHelpers.PrepareMethod(envSync.MethodHandle);
        IntPtr envPtr = envSync.MethodHandle.GetFunctionPointer();
        uint oldProt = 0;
        DumbHook.Import.VirtualProtect(envPtr, 1, 0x40, out oldProt);
        if (set == true)
        {
            {
                byte* ptr = (byte*)envPtr;
                *(ptr) = 0xc3;
            }
        } 
        else
        {
            {
                byte* ptr = (byte*)envPtr;
                *(ptr) = 0x55;
            }
        }
        DumbHook.Import.VirtualProtect(envPtr, 1, oldProt, out oldProt);
    }

    internal struct emptyStruct
    {

    }

    unsafe void VoiceRecvHook(bool set)
    {
        try {
            MethodInfo p2p_req = typeof(Facepunch.Steamworks.Networking).GetMethod("onP2PConnectionRequest", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new Type[] { typeof(ValueType), typeof(bool) }, null);
            RuntimeHelpers.PrepareMethod(p2p_req.MethodHandle);
            IntPtr recvptr = p2p_req.MethodHandle.GetFunctionPointer();
            uint oldProt = 0;
            DumbHook.Import.VirtualProtect(recvptr, 1, 0x40, out oldProt);
            if (set == true)
            {
                {
                    byte* ptr = (byte*)recvptr;
                    *(ptr) = 0xc3;
                }
            }
            else
            {
                {
                    byte* ptr = (byte*)recvptr;
                    *(ptr) = 0x55;
                }
            }
            DumbHook.Import.VirtualProtect(recvptr, 1, oldProt, out oldProt);
            
            UnityEngine.Debug.Log(recvptr.ToString("X"));
        } catch (Exception ex)
        {
            UnityEngine.Debug.Log(ex.Message);
        }
    }

    unsafe void SendP2PHook(bool set)
    {
        MethodInfo p2p_req = typeof(Facepunch.Steamworks.Networking).GetMethod("SendP2PPacket", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new Type[] { typeof(ulong), typeof(byte[]), typeof(int), typeof(Networking.SendType), typeof(int) }, null);
        RuntimeHelpers.PrepareMethod(p2p_req.MethodHandle);
        IntPtr recvptr = p2p_req.MethodHandle.GetFunctionPointer();
        uint oldProt = 0;
        DumbHook.Import.VirtualProtect(recvptr, 1, 0x40, out oldProt);
        if (set == true)
        {
            {
                byte* ptr = (byte*)recvptr;
                *(ptr) = 0xc3;
            }
        }
        else
        {
            {
                byte* ptr = (byte*)recvptr;
                *(ptr) = 0x55;
            }
        }
        DumbHook.Import.VirtualProtect(recvptr, 1, oldProt, out oldProt);
        //UnityEngine.Debug.Log(recvptr.ToString("X"));
    }

    [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    unsafe void P2PUpdate(bool set)
    {

       

    }


    private IEnumerator MiscFuncs()
    {

        BasePlayer.PlayerFlags oldFlags = (BasePlayer.PlayerFlags)0;
        bool flickerHooked = false;
        float oldGravity = 0f;
        float oldSwimGravity = 0f;

        bool attackAnywhere_Hooked = false;
        bool multiJump_Hooked = false;
        bool speed_Hooked = false;

        bool p2p_Hooked = false;

        while (true)
        {
            try
            {

                if(Misc_ShootAnywhere)
                {
                    if (!attackAnywhere_Hooked)
                    {
                        canAttack.Hook();
                        attackAnywhere_Hooked = true;
                    }
                } 
                else
                {
                    if (attackAnywhere_Hooked)
                    {
                        canAttack.Unhook();
                        attackAnywhere_Hooked = false;
                    }
                }

                if (Misc_MultiJump)
                {
                    if (!multiJump_Hooked)
                    {
                        jump.Hook();
                        multiJump_Hooked = true;
                    }
                }
                else
                {
                    if (multiJump_Hooked)
                    {
                        jump.Unhook();
                        multiJump_Hooked = false;
                    }
                }

                if (Misc_Speed)
                {
                    if (!speed_Hooked)
                    {
                        speed2.Hook();
                        speed_Hooked = true;
                    }
                }
                else
                {
                    if (speed_Hooked)
                    {
                        speed2.Unhook();
                        speed_Hooked = false;
                    }
                }

                if (Misc_DisableP2P)
                {
                    if (!p2p_Hooked)
                    {
                        //voiceCanTalk.Hook();
                        //VoiceRecvHook(true);
                        //SendP2PHook(true);
                       // P2PUpdate(true);
                        //p2p_Hooked = true;
                    }
                }
                else
                {
                    if (p2p_Hooked)
                    {
                        //voiceCanTalk.Unhook();
                        // VoiceRecvHook(false);
                        //SendP2PHook(false);
                        //P2PUpdate(false);
                        //p2p_Hooked = false;
                    }
                }


                if (localplayer != null)
                {

                    if (Misc_AdminPriv)
                    {
                        if (localplayer.playerFlags != (BasePlayer.PlayerFlags)260)
                        {
                            oldFlags = localplayer.playerFlags;
                            localplayer.playerFlags = (BasePlayer.PlayerFlags)260;
                        }
                    }
                    else
                    {
                        if (localplayer.playerFlags == (BasePlayer.PlayerFlags)260 && oldFlags != (BasePlayer.PlayerFlags)0)
                            localplayer.playerFlags = oldFlags;
                    }


                    if (Misc_Spider)
                    {
                          var getGroundAngle = typeof(PlayerWalkMovement).GetField("groundAngleNew", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                          getGroundAngle.SetValue(localplayer.movement, 0f);
                    }

                    if (Misc_Freeze)
                    {
                        if(!flickerHooked)
                        {
                            FlickerHook(true);
                            flickerHooked = true;
                        }
                        TOD_Sky.Instance.Cycle.Hour = (float)Misc_FreezeValue;
                    }
                    else
                    {
                        if(flickerHooked)
                        {
                            FlickerHook(false);
                            flickerHooked = false;
                        }
                       
                    }

                    if(Misc_LowGravity)
                    {
                        if (oldGravity == 0f)
                            oldGravity = localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplier;
                        localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplier = oldGravity / 2f;
                    }
                    else
                    {
                        if (oldGravity != 0f)
                            localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplier = oldGravity;
                    }

                    if (Misc_NoSink)
                    {
                        if (oldSwimGravity == 0f)
                            oldSwimGravity = localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplierSwimming;
                        localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplierSwimming = 0f;
                    }
                    else
                    {
                        if (oldSwimGravity != 0f)
                            localplayer.movement.GetComponent<PlayerWalkMovement>().gravityMultiplier = oldSwimGravity;
                    }

                    if(Misc_InstantRevive)
                    {

                        BasePlayer targetPlayer = null;

                        if (localplayer.lookingAt.GetComponent<BasePlayer>() != null)
                        {
                            targetPlayer = localplayer.lookingAt.GetComponent<BasePlayer>();
                        }

                        if (targetPlayer != null && targetPlayer.HasPlayerFlag(BasePlayer.PlayerFlags.Wounded) && Vector3.Distance(localplayer.transform.position, targetPlayer.transform.position) <= 2f && Input.GetKey(KeyCode.E))
                        {                           
                            targetPlayer.ServerRPC("RPC_Assist", null, null, null, null, null);
                        }
                        
                    }
                   




                }
            }
            catch (Exception ex)
            {

            }

            yield return new WaitForSeconds(0.01f);

        }

    }



    private IEnumerator CheckObjectValid()
    {

        while (true)
        {

            List<int> tempResources = new List<int> { };
            List<int> resourcekeys = new List<int>(dictResources.Keys);

            foreach (int key_resource in resourcekeys)
            {
                if (!dictResources[key_resource].entity.IsValid())
                {
                    tempResources.Add(key_resource);
                }
            }

            if (tempResources.Count > 0)
            {
                foreach (int key_resource in tempResources)
                {
                    dictResources.Remove(key_resource);
                }
            }


            List<int> tempAnimals = new List<int> { };
            List<int> animalkeys = new List<int>(dictAnimals.Keys);

            foreach (int key_animal in animalkeys)
            {
                if (!dictAnimals[key_animal].entity.IsValid())
                {
                    tempAnimals.Add(key_animal);
                }
            }

            if (tempAnimals.Count > 0)
            {
                foreach (int key_animal in tempAnimals)
                {
                    dictAnimals.Remove(key_animal);
                }
            }

            List<int> tempDropped = new List<int> { };
            List<int> droppedkeys = new List<int>(dictDropped.Keys);

            foreach (int key_dropped in droppedkeys)
            {
                if (!dictDropped[key_dropped].entity.IsValid())
                {
                    tempDropped.Add(key_dropped);
                }
            }

            if (tempDropped.Count > 0)
            {
                foreach (int key_dropped in tempDropped)
                {
                    dictDropped.Remove(key_dropped);
                }
            }

            List<int> tempLock = new List<int> { };
            List<int> lockkeys = new List<int>(dictCodelocks.Keys);

            foreach (int key_lock in lockkeys)
            {
                if (!dictCodelocks[key_lock].entity.IsValid())
                {
                    tempLock.Add(key_lock);
                }
            }

            if (tempLock.Count > 0)
            {
                foreach (int key_lock in tempLock)
                {
                    dictCodelocks.Remove(key_lock);
                }
            }


            List<int> tempAirdrop = new List<int> { };
            List<int> adkeys = new List<int>(dictAirdrops.Keys);

            foreach (int key_ad in adkeys)
            {
                if (!dictAirdrops[key_ad].entity.IsValid())
                {
                    tempAirdrop.Add(key_ad);
                }
            }

            if (tempAirdrop.Count > 0)
            {
                foreach (int key_ad in tempAirdrop)
                {
                    dictAirdrops.Remove(key_ad);
                }
            }


            List<int> tempBarrels = new List<int> { };
            List<int> barrelkeys = new List<int>(dictBarrels.Keys);

            foreach (int key_b in barrelkeys)
            {
                if (!dictBarrels[key_b].entity.IsValid())
                {
                    tempBarrels.Add(key_b);
                }
            }

            if (tempBarrels.Count > 0)
            {
                foreach (int key_b in tempBarrels)
                {
                    dictBarrels.Remove(key_b);
                }
            }


            List<int> tempCrates = new List<int> { };
            List<int> cratekeys = new List<int>(dictCrates.Keys);

            foreach (int key_c in cratekeys)
            {
                if (!dictCrates[key_c].entity.IsValid())
                {
                    tempCrates.Add(key_c);
                }
            }

            if (tempCrates.Count > 0)
            {
                foreach (int key_c in tempCrates)
                {
                    dictCrates.Remove(key_c);
                }
            }


            List<int> tempStashes = new List<int> { };
            List<int> stashkeys = new List<int>(dictStashes.Keys);

            foreach (int key_s in stashkeys)
            {
                if (!dictStashes[key_s].entity.IsValid())
                {
                    tempStashes.Add(key_s);
                }
            }

            if (tempStashes.Count > 0)
            {
                foreach (int key_s in tempStashes)
                {
                    dictStashes.Remove(key_s);
                }
            }

            List<int> tempHemp = new List<int> { };
            List<int> hempkeys = new List<int>(dictHemp.Keys);

            foreach (int key_h in hempkeys)
            {
                if (!dictHemp[key_h].entity.IsValid())
                {
                    tempHemp.Add(key_h);
                }
            }

            if (tempHemp.Count > 0)
            {
                foreach (int key_h in tempHemp)
                {
                    dictHemp.Remove(key_h);
                }
            }

            List<int> tempTC = new List<int> { };
            List<int> tckeys = new List<int>(dictTC.Keys);

            foreach (int key_t in tckeys)
            {
                if (!dictTC[key_t].entity.IsValid())
                {
                    tempTC.Add(key_t);
                }
            }

            if (tempTC.Count > 0)
            {
                foreach (int key_t in tempTC)
                {
                    dictTC.Remove(key_t);
                }
            }

            List<int> tempCorpses = new List<int> { };
            List<int> corpsekeys = new List<int>(dictCorpses.Keys);

            foreach (int key_c in corpsekeys)
            {
                if (!dictCorpses[key_c].entity.IsValid())
                {
                    tempCorpses.Add(key_c);
                }
            }

            if (tempCorpses.Count > 0)
            {
                foreach (int key_c in tempCorpses)
                {
                    dictCorpses.Remove(key_c);
                }
            }

            List<int> tempBears = new List<int> { };
            List<int> bearkeys = new List<int>(dictBeartraps.Keys);

            foreach (int key_b in bearkeys)
            {
                if (!dictBeartraps[key_b].entity.IsValid())
                {
                    tempBears.Add(key_b);
                }
            }

            if (tempBears.Count > 0)
            {
                foreach (int key_b in tempBears)
                {
                    dictBeartraps.Remove(key_b);
                }
            }


            List<int> tempMines = new List<int> { };
            List<int> minekeys = new List<int>(dictLandmines.Keys);

            foreach (int key_m in minekeys)
            {
                if (!dictLandmines[key_m].entity.IsValid())
                {
                    tempMines.Add(key_m);
                }
            }

            if (tempMines.Count > 0)
            {
                foreach (int key_m in tempMines)
                {
                    dictLandmines.Remove(key_m);
                }
            }

            List<int> tempTurrets = new List<int> { };
            List<int> turretkeys = new List<int>(dictTurrets.Keys);

            foreach (int key_t in turretkeys)
            {
                if (!dictTurrets[key_t].entity.IsValid())
                {
                    tempTurrets.Add(key_t);
                }
            }

            if (tempTurrets.Count > 0)
            {
                foreach (int key_t in tempTurrets)
                {
                    dictTurrets.Remove(key_t);
                }
            }



            List<int> tempFlames = new List<int> { };
            List<int> flamekeys = new List<int>(dictFlames.Keys);

            foreach (int key_f in flamekeys)
            {
                if (!dictFlames[key_f].entity.IsValid())
                {
                    tempFlames.Add(key_f);
                }
            }

            if (tempFlames.Count > 0)
            {
                foreach (int key_f in tempFlames)
                {
                    dictFlames.Remove(key_f);
                }
            }


            List<int> tempShotguns = new List<int> { };
            List<int> shotgunkeys = new List<int>(dictShotguns.Keys);

            foreach (int key_s in shotgunkeys)
            {
                if (!dictShotguns[key_s].entity.IsValid())
                {
                    tempShotguns.Add(key_s);
                }
            }

            if (tempShotguns.Count > 0)
            {
                foreach (int key_s in tempShotguns)
                {
                    dictShotguns.Remove(key_s);
                }
            }


            List<int> tempPaintings = new List<int> { };
            List<int> paintkeys = new List<int>(dictPaintings.Keys);

            foreach (int key_p in shotgunkeys)
            {
                if (!dictPaintings[key_p].entity.IsValid())
                {
                    tempPaintings.Add(key_p);
                }
            }

            if (tempPaintings.Count > 0)
            {
                foreach (int key_p in tempPaintings)
                {
                    dictPaintings.Remove(key_p);
                }
            }


            if (!heliObject.IsValid())
            {
                heliObject = null;
            }


            yield return new WaitForSeconds(0.5f);
        }

    }


    private IEnumerator UpdateSettings()
    {
        while (true)
        {
            LoadSettings();
            LoadLocations();
            yield return new WaitForSeconds(0.5f);
        }
    }



    public void LoadLocations()
    {
        try
        {
            if (File.Exists("C:\\Users\\Admin\\Desktop\\settings\\" + Network.Net.cl.connectedAddress + "-" + Network.Net.cl.connectedPort + ".txt") == false)
            {
                return;
            }
            else
            {
                string loadSettings = System.IO.File.ReadAllText("C:\\Users\\Admin\\Desktop\\settings\\" + Network.Net.cl.connectedAddress + "-" + Network.Net.cl.connectedPort + ".txt");
                loadSettings = loadSettings.Replace("%", "a");
                loadSettings = loadSettings.Replace("^", "b");
                loadSettings = loadSettings.Replace("&", "1");
                loadSettings = loadSettings.Replace("*", "2");

                byte[] b = Convert.FromBase64String(loadSettings);
                loadSettings = Encoding.Unicode.GetString(b);

                string[] splitSettings = loadSettings.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, Vector3> tempLocations = new Dictionary<string, Vector3> { };

                foreach (string setting in splitSettings)
                {
                    string[] strparams = setting.Split(new string[] { " >> " }, StringSplitOptions.None);
                    string[] splitv3 = strparams[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    tempLocations.Add(strparams[0], new Vector3(Convert.ToSingle(splitv3[0]), Convert.ToSingle(splitv3[1]), Convert.ToSingle(splitv3[2])));
                   
                }

                dictLocations = tempLocations;

            }
        }
        catch (Exception ex)
        {

        }
    }


    public void LoadSettings()
    {
        try
        {

            if (File.Exists("C:\\Users\\Admin\\Desktop\\settings\\settings.txt") == false)
            {
                Application.Quit();
            }

            List<string> tempWhitelist = new List<string> { };

            string loadSettings = System.IO.File.ReadAllText("C:\\Users\\Admin\\Desktop\\settings\\settings.txt");
            loadSettings = loadSettings.Replace("%", "a");
            loadSettings = loadSettings.Replace("^", "b");
            loadSettings = loadSettings.Replace("&", "1");
            loadSettings = loadSettings.Replace("*", "2");

            byte[] b = Convert.FromBase64String(loadSettings);
            loadSettings = Encoding.Unicode.GetString(b);

            string[] splitSettings = loadSettings.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string setting in splitSettings)
            {
                string[] strparams = setting.Split(new string[] { " " }, StringSplitOptions.None);

                switch (strparams[0])
                {
                    case "esp":
                        if (strparams[1] == "1")
                        {
                            ESP_Active = true;
                        }
                        else
                        {
                            ESP_Active = false;
                        }
                        break;

                    case "online":
                        if (strparams[1] == "1")
                        {
                            ESP_OnlinePlayers = true;
                        }
                        else
                        {
                            ESP_OnlinePlayers = false;
                        }
                        break;
                    case "far":
                        if (strparams[1] == "1")
                        {
                            ESP_Far = true;
                        }
                        else
                        {
                            ESP_Far = false;
                        }
                        break;
                    case "farrange":
                        ESP_FarRange = Convert.ToInt32(strparams[1]);
                        break;
                    case "sleeper":
                        if (strparams[1] == "1")
                        {
                            ESP_Sleepers = true;
                        }
                        else
                        {
                            ESP_Sleepers = false;
                        }
                        break;
                    case "skeleton":
                        if (strparams[1] == "1")
                        {
                            ESP_Bones = true;
                        }
                        else
                        {
                            ESP_Bones = false;
                        }
                        break;
                    case "bounding":
                        if (strparams[1] == "1")
                        {
                            ESP_Boxes = true;
                        }
                        else
                        {
                            ESP_Boxes = false;
                        }
                        break;
                    case "bbstyle":
                        if (strparams[1] == "1")
                        {
                            ESP_Boxes3D = true;
                        }
                        else
                        {
                            ESP_Boxes3D = false;
                        }
                        break;
                    case "objrange":
                        ESP_ActiveRange = Convert.ToInt32(strparams[1]);
                        break;
                    case "heli":
                        if (strparams[1] == "1")
                        {
                            ESP_Heli = true;
                        }
                        else
                        {
                            ESP_Heli = false;
                        }
                        break;
                    case "node":
                        if (strparams[1] == "1")
                        {
                            ESP_Node = true;
                        }
                        else
                        {
                            ESP_Node = false;
                        }
                        break;
                    case "animal":
                        if (strparams[1] == "1")
                        {
                            ESP_Animal = true;
                        }
                        else
                        {
                            ESP_Animal = false;
                        }
                        break;
                    case "dropped":
                        if (strparams[1] == "1")
                        {
                            ESP_Dropped = true;
                        }
                        else
                        {
                            ESP_Dropped = false;
                        }
                        break;
                    case "airdrop":
                        if (strparams[1] == "1")
                        {
                            ESP_Airdrop = true;
                        }
                        else
                        {
                            ESP_Airdrop = false;
                        }
                        break;
                    case "barrel":
                        if (strparams[1] == "1")
                        {
                            ESP_Barrel = true;
                        }
                        else
                        {
                            ESP_Barrel = false;
                        }
                        break;
                    case "crate":
                        if (strparams[1] == "1")
                        {
                            ESP_Crate = true;
                        }
                        else
                        {
                            ESP_Crate = false;
                        }
                        break;
                    case "stash":
                        if (strparams[1] == "1")
                        {
                            ESP_Stash = true;
                        }
                        else
                        {
                            ESP_Stash = false;
                        }
                        break;
                    case "hemp":
                        if (strparams[1] == "1")
                        {
                            ESP_Hemp = true;
                        }
                        else
                        {
                            ESP_Hemp = false;
                        }
                        break;
                    case "tcs":
                        if (strparams[1] == "1")
                        {
                            ESP_TC = true;
                        }
                        else
                        {
                            ESP_TC = false;
                        }
                        break;
                    case "corpse":
                        if (strparams[1] == "1")
                        {
                            ESP_Corpse = true;
                        }
                        else
                        {
                            ESP_Corpse = false;
                        }
                        break;
                    case "traprange":
                        ESP_TrapRange = Convert.ToInt32(strparams[1]);
                        break;
                    case "bear":
                        if (strparams[1] == "1")
                        {
                            ESP_BearTrap = true;
                        }
                        else
                        {
                            ESP_BearTrap = false;
                        }
                        break;
                    case "mine":
                        if (strparams[1] == "1")
                        {
                            ESP_Landmine = true;
                        }
                        else
                        {
                            ESP_Landmine = false;
                        }
                        break;
                    case "turret":
                        if (strparams[1] == "1")
                        {
                            ESP_Autoturret = true;
                        }
                        else
                        {
                            ESP_Autoturret = false;
                        }
                        break;
                    case "flame":
                        if (strparams[1] == "1")
                        {
                            ESP_Flameturret = true;
                        }
                        else
                        {
                            ESP_Flameturret = false;
                        }
                        break;
                    case "shotgun":
                        if (strparams[1] == "1")
                        {
                            ESP_Shotgun = true;
                        }
                        else
                        {
                            ESP_Shotgun = false;
                        }
                        break;
                    case "tcauth":
                        if (strparams[1] == "1")
                        {
                            ESP_ShowTCAuth = true;
                        }
                        else
                        {
                            ESP_ShowTCAuth = false;
                        }
                        break;
                    case "inventory":
                        if (strparams[1] == "1")
                        {
                            ESP_ShowInventory = true;
                        }
                        else
                        {
                            ESP_ShowInventory = false;
                        }
                        break;
                    case "onlinecolor":
                        Color_ESPOnlinePlayers = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "farcolor":
                        Color_ESPFar = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "sleepercolor":
                        Color_ESPSleepers = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "skeletoncolor":
                        Color_ESPBones = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "helicolor":
                        Color_ESPHeli = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "nodecolor":
                        Color_ESPNode = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "animalcolor":
                        Color_ESPAnimal = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "droppedcolor":
                        Color_ESPDropped = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "airdropcolor":
                        Color_ESPAirdrop = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "barrelcolor":
                        Color_ESPBarrel = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "cratecolor":
                        Color_ESPCrate = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "stashcolor":
                        Color_ESPStash = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "hempcolor":
                        Color_ESPHemp = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "tcscolor":
                        Color_ESPTC = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "corpsecolor":
                        Color_ESPCorpse = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "bearcolor":
                        Color_ESPBearTrap = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "minecolor":
                        Color_ESPLandmine = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "turretcolor":
                        Color_ESPAutoturret = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "flamecolor":
                        Color_ESPFlameturret = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "shotguncolor":
                        Color_ESPShotgun = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "aim":
                        if (strparams[1] == "1")
                        {
                            Aim_Active = true;
                        }
                        else
                        {
                            Aim_Active = false;
                        }
                        break;
                    case "aimmode":
                        if (strparams[1] == "1")
                        {
                            AimMode = 1;
                        }
                        else
                        {
                            AimMode = 2;
                        }
                        break;
                    case "smooth":
                        if (strparams[1] == "1")
                        {
                            Aim_Smooth = true;
                        }
                        else
                        {
                            Aim_Smooth = false;
                        }
                        break;
                    case "vischeck":
                        if (strparams[1] == "1")
                        {
                            Aim_VisCheck = true;
                        }
                        else
                        {
                            Aim_VisCheck = false;
                        }
                        break;
                    case "heliaim":
                        if (strparams[1] == "1")
                        {
                            Aim_Heli = true;
                        }
                        else
                        {
                            Aim_Heli = false;
                        }
                        break;
                    case "forceauto":
                        if (strparams[1] == "1")
                        {
                            Aim_ForceAuto = true;
                        }
                        else
                        {
                            Aim_ForceAuto = false;
                        }
                        break;
                    case "ignore":
                        if (strparams[1] == "1")
                        {
                            Aim_Whitelist = true;
                        }
                        else
                        {
                            Aim_Whitelist = false;
                        }
                        break;
                    case "bolt5":
                        if (strparams[1] == "1")
                        {
                            Aim_BoltFast = true;
                        }
                        else
                        {
                            Aim_BoltFast = false;
                        }
                        break;
                    case "aimrange":
                        Aim_Range = Convert.ToInt32(strparams[1]);
                        break;
                    case "fov":
                        Aim_Fov = Convert.ToInt32(strparams[1]);
                        break;
                    case "fovdraw":
                        if (strparams[1] == "1")
                        {
                            Aim_DrawFov = true;
                        }
                        else
                        {
                            Aim_DrawFov = false;
                        }
                        break;
                    case "xhair":
                        if (strparams[1] == "1")
                        {
                            Aim_Xhair = true;
                        }
                        else
                        {
                            Aim_Xhair = false;
                        }
                        break;
                    case "aimpos":
                        Aim_Position = Convert.ToInt32(strparams[1]);
                        break;
                    case "norecoil":
                        if (strparams[1] == "1")
                        {
                            Aim_NoRecoil = true;
                        }
                        else
                        {
                            Aim_NoRecoil = false;
                        }
                        break;
                    case "nospread":
                        if (strparams[1] == "1")
                        {
                            Aim_NoSpread = true;
                        }
                        else
                        {
                            Aim_NoSpread = false;
                        }
                        break;
                    case "nosway":
                        if (strparams[1] == "1")
                        {
                            Aim_NoSway = true;
                        }
                        else
                        {
                            Aim_NoSway = false;
                        }
                        break;
                    case "nodrop":
                        if (strparams[1] == "1")
                        {
                            Aim_NoDrop = true;
                        }
                        else
                        {
                            Aim_NoDrop = false;
                        }
                        break;
                    case "nodrag":
                        if (strparams[1] == "1")
                        {
                            Aim_NoDrag = true;
                        }
                        else
                        {
                            Aim_NoDrag = false;
                        }
                        break;
                    case "fovcolor":
                        Color_AimDrawFov = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "xhaircolor":
                        Color_AimXhair = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "radar":
                        if (strparams[1] == "1")
                        {
                            Radar_Active = true;
                        }
                        else
                        {
                            Radar_Active = false;
                        }
                        break;
                    case "radarenemies":
                        if (strparams[1] == "1")
                        {
                            Radar_Enemies = true;
                        }
                        else
                        {
                            Radar_Enemies = false;
                        }
                        break;
                    case "radarfriends":
                        if (strparams[1] == "1")
                        {
                            Radar_Friends = true;
                        }
                        else
                        {
                            Radar_Enemies = false;
                        }
                        break;
                    case "radaranimals":
                        if (strparams[1] == "1")
                        {
                            Radar_Animals = true;
                        }
                        else
                        {
                            Radar_Animals = false;
                        }
                        break;
                    case "radarx":
                        Radar_X = Convert.ToInt32(strparams[1]);
                        break;
                    case "radary":
                        Radar_Y = Convert.ToInt32(strparams[1]);
                        break;
                    case "radarsize":
                        Radar_Size = Convert.ToInt32(strparams[1]);
                        break;
                    case "radarrange":
                        Radar_Range = Convert.ToInt32(strparams[1]);
                        break;
                    case "radarenemycolor":
                        Color_RadarEnemies = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "radarfriendcolor":
                        Color_RadarFriends = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "radaranimalcolor":
                        Color_RadarAnimals = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "locations":
                        if (strparams[1] == "1")
                        {
                            ESP_Locations = true;
                        }
                        else
                        {
                            ESP_Locations = false;
                        }
                        break;
                    case "locationscolor":
                        Color_ESPLocations = new UnityEngine.Color(Convert.ToSingle(strparams[1]) / 255f, Convert.ToSingle(strparams[2]) / 255f, Convert.ToSingle(strparams[3]) / 255f);
                        break;
                    case "adminpriv":
                        if (strparams[1] == "1")
                        {
                            Misc_AdminPriv = true;
                        }
                        else
                        {
                            Misc_AdminPriv = false;
                        }
                        break;
                    case "spider":
                        if (strparams[1] == "1")
                        {
                            Misc_Spider = true;
                        }
                        else
                        {
                            Misc_Spider = false;
                        }
                        break;
                    case "speed":
                        if (strparams[1] == "1")
                        {
                            Misc_Speed = true;
                        }
                        else
                        {
                            Misc_Speed = false;
                        }
                        break;
                    case "freeze":
                        if (strparams[1] == "1")
                        {
                            Misc_Freeze = true;
                        }
                        else
                        {
                            Misc_Freeze = false;
                        }
                        break;
                    case "timeval":
                        Misc_FreezeValue = Convert.ToInt32(strparams[1]);
                        break;
                    case "fastgather":
                        if (strparams[1] == "1")
                        {
                            Misc_FastGather = true;
                        }
                        else
                        {
                            Misc_FastGather = false;
                        }
                        break;
                    case "lowgravity":
                        if (strparams[1] == "1")
                        {
                            Misc_LowGravity = true;
                        }
                        else
                        {
                            Misc_LowGravity = false;
                        }
                        break;
                    case "nosink":
                        if (strparams[1] == "1")
                        {
                            Misc_NoSink = true;
                        }
                        else
                        {
                            Misc_NoSink = false;
                        }
                        break;
                    case "multijump":
                        if (strparams[1] == "1")
                        {
                            Misc_MultiJump = true;
                        }
                        else
                        {
                            Misc_MultiJump = false;
                        }
                        break;
                    case "anywhere":
                        if (strparams[1] == "1")
                        {
                            Misc_ShootAnywhere = true;
                        }
                        else
                        {
                            Misc_ShootAnywhere = false;
                        }
                        break;
                    case "disarm":
                        if (strparams[1] == "1")
                        {
                            Misc_DisarmBearTraps = true;
                        }
                        else
                        {
                            Misc_DisarmBearTraps = false;
                        }
                        break;
                    case "autolock":
                        if (strparams[1] == "1")
                        {
                            Misc_AutoLock = true;
                        }
                        else
                        {
                            Misc_AutoLock = false;
                        }
                        break;
                    case "lpin":
                        Misc_LockPIN = strparams[1];
                        break;
                    case "autounlock":
                        if (strparams[1] == "1")
                        {
                            Misc_AutoUnlock = true;
                        }
                        else
                        {
                            Misc_AutoUnlock = false;
                        }
                        break;
                    case "upin":
                        Misc_LockPIN = strparams[1];
                        break;
                    case "drawimage":
                        if (strparams[1] == "1")
                        {
                            Misc_DrawImage = true;
                        }
                        else
                        {
                            Misc_DrawImage = false;
                        }
                        break;
                    case "imgpath":
                        if (System.IO.File.Exists(strparams[1].Replace("*", " ")))
                        {
                            Misc_ImgPath = strparams[1].Replace("*", " ");
                        }
                        else
                        {
                            Misc_ImgPath = "";
                        }
                        break;
                    case "disablep2p":
                        if (strparams[1] == "1")
                        {
                            Misc_DisableP2P = true;
                        }
                        else
                        {
                            Misc_DisableP2P = false;
                        }
                        break;
                    case "friendentry":
                        tempWhitelist.Add(strparams[1]);
                        break;
                    case "revive":
                        if (strparams[1] == "1")
                        {
                            Misc_InstantRevive = true;
                        }
                        else
                        {
                            Misc_InstantRevive = false;
                        }
                        break;
                }
            }
            Whitelist = tempWhitelist;
        }
        catch (Exception ex)
        {

        }
    }


    public struct BonePositions
    {
        public Vector2 head;
        public Vector2 spine;
        public Vector2 l_shoulder;
        public Vector2 r_shoulder;
        public Vector2 l_elbow;
        public Vector2 r_elbow;
        public Vector2 l_hand;
        public Vector2 r_hand;
        public Vector2 pelvis;
        public Vector2 l_hip;
        public Vector2 r_hip;
        public Vector2 l_knee;
        public Vector2 r_knee;
        public Vector2 l_foot;
        public Vector2 r_foot;
    }

    public struct BoxPositions
    {
        public Vector2 frontTopleft;
        public Vector2 frontTopright;
        public Vector2 frontBottomleft;
        public Vector2 frontBottomright;
        public Vector2 backTopleft;
        public Vector2 backTopright;
        public Vector2 backBottomleft;
        public Vector2 backBottomright;
    }


    public static Dictionary<string, BonePositions> PlayerBones = new Dictionary<string, BonePositions>();
    public static Dictionary<string, BoxPositions> PlayerBoxes = new Dictionary<string, BoxPositions>();

    private IEnumerator CalculatePositions()
    {
        while (true)
        {

            PlayerBones.Clear();
            PlayerBoxes.Clear();

            foreach (BasePlayer p in BasePlayer.VisiblePlayerList)
            {
                BonePositions bp = new BonePositions();

                Vector3 head = p.FindBone("head").position;
                Vector3 spine = p.FindBone("spine4").position;
                Vector3 l_clav = p.FindBone("l_clavicle").position;
                Vector3 l_upper = p.FindBone("l_upperarm").position;
                Vector3 l_fore = p.FindBone("l_forearm").position;
                Vector3 l_hand = p.FindBone("l_hand").position;
                Vector3 r_clav = p.FindBone("r_clavicle").position;
                Vector3 r_upper = p.FindBone("r_upperarm").position;
                Vector3 r_fore = p.FindBone("r_forearm").position;
                Vector3 r_hand = p.FindBone("r_hand").position;
                Vector3 pelvis = p.FindBone("pelvis").position;
                Vector3 l_hip = p.FindBone("l_hip").position;
                Vector3 l_knee = p.FindBone("l_knee").position;
                Vector3 l_ankle = p.FindBone("l_ankle_scale").position;
                Vector3 l_foot = p.FindBone("l_foot").position;
                Vector3 r_hip = p.FindBone("r_hip").position;
                Vector3 r_knee = p.FindBone("r_knee").position;
                Vector3 r_ankle = p.FindBone("r_ankle_scale").position;
                Vector3 r_foot = p.FindBone("r_foot").position;

                if (VisibleOnScreen(head) && VisibleOnScreen(spine) && VisibleOnScreen(l_upper) && VisibleOnScreen(r_upper) && VisibleOnScreen(l_fore) && VisibleOnScreen(r_fore) && VisibleOnScreen(l_hand) && VisibleOnScreen(r_hand) && VisibleOnScreen(pelvis) && VisibleOnScreen(l_hip) && VisibleOnScreen(r_hip) && VisibleOnScreen(l_knee) && VisibleOnScreen(r_knee) && VisibleOnScreen(l_foot) && VisibleOnScreen(r_foot))
                {
                    Vector2 head2 = MainCamera.mainCamera.WorldToScreenPoint(head);
                    head2.y = UnityEngine.Screen.height - head2.y;
                    Vector2 spine2 = MainCamera.mainCamera.WorldToScreenPoint(spine);
                    spine2.y = UnityEngine.Screen.height - spine2.y;
                    Vector2 l_upper2 = MainCamera.mainCamera.WorldToScreenPoint(l_upper);
                    l_upper2.y = UnityEngine.Screen.height - l_upper2.y;
                    Vector2 r_upper2 = MainCamera.mainCamera.WorldToScreenPoint(r_upper);
                    r_upper2.y = UnityEngine.Screen.height - r_upper2.y;
                    Vector2 l_fore2 = MainCamera.mainCamera.WorldToScreenPoint(l_fore);
                    l_fore2.y = UnityEngine.Screen.height - l_fore2.y;
                    Vector2 r_fore2 = MainCamera.mainCamera.WorldToScreenPoint(r_fore);
                    r_fore2.y = UnityEngine.Screen.height - r_fore2.y;
                    Vector2 l_hand2 = MainCamera.mainCamera.WorldToScreenPoint(l_hand);
                    l_hand2.y = UnityEngine.Screen.height - l_hand2.y;
                    Vector2 r_hand2 = MainCamera.mainCamera.WorldToScreenPoint(r_hand);
                    r_hand2.y = UnityEngine.Screen.height - r_hand2.y;
                    Vector2 l_hip2 = MainCamera.mainCamera.WorldToScreenPoint(l_hip);
                    l_hip2.y = UnityEngine.Screen.height - l_hip2.y;
                    Vector2 r_hip2 = MainCamera.mainCamera.WorldToScreenPoint(r_hip);
                    r_hip2.y = UnityEngine.Screen.height - r_hip2.y;
                    Vector2 l_knee2 = MainCamera.mainCamera.WorldToScreenPoint(l_knee);
                    l_knee2.y = UnityEngine.Screen.height - l_knee2.y;
                    Vector2 r_knee2 = MainCamera.mainCamera.WorldToScreenPoint(r_knee);
                    r_knee2.y = UnityEngine.Screen.height - r_knee2.y;
                    Vector2 l_foot2 = MainCamera.mainCamera.WorldToScreenPoint(l_foot);
                    l_foot2.y = UnityEngine.Screen.height - l_foot2.y;
                    Vector2 r_foot2 = MainCamera.mainCamera.WorldToScreenPoint(r_foot);
                    r_foot2.y = UnityEngine.Screen.height - r_foot2.y;
                    Vector2 pelvis2 = MainCamera.mainCamera.WorldToScreenPoint(pelvis);
                    pelvis2.y = UnityEngine.Screen.height - pelvis2.y;

                    bp.head = head2;
                    bp.spine = spine2;
                    bp.l_shoulder = l_upper2;
                    bp.r_shoulder = r_upper2;
                    bp.l_elbow = l_fore2;
                    bp.r_elbow = r_fore2;
                    bp.l_hand = l_hand2;
                    bp.r_hand = r_hand2;
                    bp.pelvis = pelvis2;
                    bp.l_hip = l_hip2;
                    bp.r_hip = r_hip2;
                    bp.l_knee = l_knee2;
                    bp.r_knee = r_knee2;
                    bp.l_foot = l_foot2;
                    bp.r_foot = r_foot2;

                    PlayerBones.Add(p.userID.ToString(), bp);

                }


                BoxPositions bxp = new BoxPositions();

                Vector2 v2FrontTopLeft;
                Vector2 v2FrontTopRight;
                Vector2 v2FrontBottomLeft;
                Vector2 v2FrontBottomRight;
                Vector2 v2BackTopLeft;
                Vector2 v2BackTopRight;
                Vector2 v2BackBottomLeft;
                Vector2 v2BackBottomRight;

                Bounds BoundsBox = new Bounds();

                if (p.IsDucked())
                {
                    BoundsBox.center = p.transform.position + new Vector3(0f, 0.55f, 0f);
                    BoundsBox.extents = new Vector3(0.4f, 0.65f, 0.4f);
                }
                else
                {
                    BoundsBox.center = p.transform.position + new Vector3(0f, 0.85f, 0f);
                    BoundsBox.extents = new Vector3(0.4f, 0.9f, 0.4f);
                }


                float angles = EulerAngles(p.GetModel().headBone.rotation).y;

                Vector3 v3Center = BoundsBox.center;
                Vector3 v3Extents = BoundsBox.extents;

                Vector3 v3FrontTopLeft = RotatePoint(v3Center, new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z), angles);  // Front top left corner
                Vector3 v3FrontTopRight = RotatePoint(v3Center, new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z), angles);  // Front top right corner
                Vector3 v3FrontBottomLeft = RotatePoint(v3Center, new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z), angles);  // Front bottom left corner
                Vector3 v3FrontBottomRight = RotatePoint(v3Center, new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z), angles);  // Front bottom right corner
                Vector3 v3BackTopLeft = RotatePoint(v3Center, new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z), angles);  // Back top left corner
                Vector3 v3BackTopRight = RotatePoint(v3Center, new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z), angles);  // Back top right corner
                Vector3 v3BackBottomLeft = RotatePoint(v3Center, new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z), angles);  // Back bottom left corner
                Vector3 v3BackBottomRight = RotatePoint(v3Center, new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z), angles);  // Back bottom right corner

                v2FrontTopLeft = MainCamera.mainCamera.WorldToScreenPoint(v3FrontTopLeft);
                v2FrontTopLeft.y = UnityEngine.Screen.height - v2FrontTopLeft.y;

                v2FrontTopRight = MainCamera.mainCamera.WorldToScreenPoint(v3FrontTopRight);
                v2FrontTopRight.y = UnityEngine.Screen.height - v2FrontTopRight.y;

                v2FrontBottomLeft = MainCamera.mainCamera.WorldToScreenPoint(v3FrontBottomLeft);
                v2FrontBottomLeft.y = UnityEngine.Screen.height - v2FrontBottomLeft.y;

                v2FrontBottomRight = MainCamera.mainCamera.WorldToScreenPoint(v3FrontBottomRight);
                v2FrontBottomRight.y = UnityEngine.Screen.height - v2FrontBottomRight.y;

                v2BackTopLeft = MainCamera.mainCamera.WorldToScreenPoint(v3BackTopLeft);
                v2BackTopLeft.y = UnityEngine.Screen.height - v2BackTopLeft.y;

                v2BackTopRight = MainCamera.mainCamera.WorldToScreenPoint(v3BackTopRight);
                v2BackTopRight.y = UnityEngine.Screen.height - v2BackTopRight.y;

                v2BackBottomLeft = MainCamera.mainCamera.WorldToScreenPoint(v3BackBottomLeft);
                v2BackBottomLeft.y = UnityEngine.Screen.height - v2BackBottomLeft.y;

                v2BackBottomRight = MainCamera.mainCamera.WorldToScreenPoint(v3BackBottomRight);
                v2BackBottomRight.y = UnityEngine.Screen.height - v2BackBottomRight.y;

                if (VisibleOnScreen(v3FrontTopLeft) && VisibleOnScreen(v3FrontTopRight) && VisibleOnScreen(v3FrontBottomLeft) && VisibleOnScreen(v3FrontBottomRight) && VisibleOnScreen(v3BackTopLeft) && VisibleOnScreen(v3BackTopRight) && VisibleOnScreen(v3BackBottomLeft) && VisibleOnScreen(v3BackBottomRight))
                {
                    bxp.backBottomleft = v2BackBottomLeft;
                    bxp.backBottomright = v2BackBottomRight;
                    bxp.backTopleft = v2BackTopLeft;
                    bxp.backTopright = v2BackTopRight;
                    bxp.frontBottomleft = v2FrontBottomLeft;
                    bxp.frontBottomright = v2FrontBottomRight;
                    bxp.frontTopleft = v2FrontTopLeft;
                    bxp.frontTopright = v2FrontTopRight;

                    PlayerBoxes.Add(p.userID.ToString(), bxp);
                }
            }


            yield return new WaitForSeconds(0.005f);
        }

    }



    private IEnumerator WriteOutput()
    {
        while (true)
        {
            try
            {
                StringBuilder output = new StringBuilder();

                output.AppendLine("fov " + ConVar.Graphics.fov.ToString());
                output.AppendLine("pos " + localplayer.transform.position.x.ToString() + " " + localplayer.transform.position.y.ToString() + " " + localplayer.transform.position.z.ToString());
                output.AppendLine("width " + UnityEngine.Screen.width.ToString());
                output.AppendLine("height " + UnityEngine.Screen.height.ToString());
                output.AppendLine("addr " + Network.Net.cl.connectedAddress + ":" + Network.Net.cl.connectedPort);

                foreach (BasePlayer player in BasePlayer.VisiblePlayerList)
                {
                    output.AppendLine(player.displayName + " " + player.userID.ToString());
                }

                byte[] b = Encoding.Unicode.GetBytes(output.ToString());
                string out_enc = Convert.ToBase64String(b);
                out_enc = out_enc.Replace("a", "%");
                out_enc = out_enc.Replace("b", "^");
                out_enc = out_enc.Replace("1", "&");
                out_enc = out_enc.Replace("2", "*");

                System.IO.File.WriteAllText("C:\\Users\\Admin\\Desktop\\settings\\out.txt", out_enc);

            }
            catch (Exception ex)
            {

            }

            yield return new WaitForSeconds(1.25f);
        }
    }

    public struct RemovalInfo
    {
        public float recoilPitchMax;
        public float recoilPitchMin;
        public float recoilYawMax;
        public float recoilYawMin;
        public float movementPenalty;
        public float aimSway;
        public float aimSwaySpeed;
        public bool automatic;
        public float aimCone;
        public float aimConeHip;
        public float aimConePenaltyMax;
        public float aimConePenaltyPerShot;
    }


    private IEnumerator Removals()
    {
        Dictionary<int, RemovalInfo> removalDict = new Dictionary<int, RemovalInfo>();

        while (true)
        {

            if (localplayer != null && localplayer.GetHeldEntity() != null)
            {

                BaseProjectile bp = LocalPlayer.GetHeldEntity().GetComponent<BaseProjectile>();

                if (bp != null)
                {

                    int itemID = (int)localplayer.GetHeldEntity().GetOwnerItemDefinition().itemid;

                    if (itemID == -55660037 && Aim_BoltFast)
                    {
                        if (bp.projectileVelocityScale == 1f)
                            bp.projectileVelocityScale = 5f;
                    }
                    else
                    {
                        if (bp.projectileVelocityScale != 1f)
                            bp.projectileVelocityScale = 1f;
                    }


                    if (Aim_NoRecoil)
                    {
                        if (bp.recoil.recoilPitchMax != 0f)
                        {
                            if(!removalDict.ContainsKey(itemID))
                            {
                                RemovalInfo newinfo = new RemovalInfo();
                                newinfo.recoilPitchMax = bp.recoil.recoilPitchMax;
                                newinfo.recoilPitchMin = bp.recoil.recoilPitchMin;
                                newinfo.recoilYawMax = bp.recoil.recoilYawMax;
                                newinfo.recoilYawMin = bp.recoil.recoilYawMin;
                                newinfo.movementPenalty = bp.recoil.movementPenalty;
                                removalDict.Add(itemID, newinfo);
                            }
                            else
                            {
                                if (bp.recoil.recoilPitchMax != 0f)
                                {
                                    RemovalInfo updateinfo;
                                    updateinfo = removalDict[itemID];
                                    updateinfo.recoilPitchMax = bp.recoil.recoilPitchMax;
                                    updateinfo.recoilPitchMin = bp.recoil.recoilPitchMin;
                                    updateinfo.recoilYawMax = bp.recoil.recoilYawMax;
                                    updateinfo.recoilYawMin = bp.recoil.recoilYawMin;
                                    updateinfo.movementPenalty = bp.recoil.movementPenalty;
                                    removalDict[itemID] = updateinfo;
                                }

                            }
                            bp.recoil.recoilPitchMax = 0f;
                            bp.recoil.recoilPitchMin = 0f;
                            bp.recoil.recoilYawMax = 0f;
                            bp.recoil.recoilYawMin = 0f;
                            bp.recoil.movementPenalty = 0f;
                        }
                    }
                    else
                    {
                        if (bp.recoil.recoilPitchMax == 0f)
                        {
                            bp.recoil.recoilPitchMax = removalDict[itemID].recoilPitchMax;
                            bp.recoil.recoilPitchMin = removalDict[itemID].recoilPitchMin;
                            bp.recoil.recoilYawMax = removalDict[itemID].recoilYawMax;
                            bp.recoil.recoilYawMin = removalDict[itemID].recoilYawMin;
                            bp.recoil.movementPenalty = removalDict[itemID].movementPenalty;
                        }
                    }

                    if (Aim_NoSway)
                    {
                        if (bp.aimSway != 0f)
                        {
                            if (!removalDict.ContainsKey(itemID))
                            {
                                RemovalInfo newinfo = new RemovalInfo();
                                newinfo.aimSway = bp.aimSway;
                                newinfo.aimSwaySpeed = bp.aimSwaySpeed;
                                removalDict.Add(itemID, newinfo);
                            }
                            else
                            {
                                if (bp.aimSway != 0f)
                                {
                                    RemovalInfo updateinfo;
                                    updateinfo = removalDict[itemID];
                                    updateinfo.aimSway = bp.aimSway;
                                    updateinfo.aimSwaySpeed = bp.aimSwaySpeed;
                                    removalDict[itemID] = updateinfo;
                                }

                            }
                            bp.aimSway = 0f;
                            bp.aimSwaySpeed = 0f;
                        }
                    }
                    else
                    {
                        if (bp.aimSway == 0f)
                        {
                            bp.aimSway = removalDict[itemID].aimSway;
                            bp.aimSwaySpeed = removalDict[itemID].aimSwaySpeed;
                        }
                    }

                    if (Aim_ForceAuto)
                    {
                        if (!bp.automatic)
                        {

                            if (!removalDict.ContainsKey(itemID))
                            {
                                RemovalInfo newinfo = new RemovalInfo();
                                newinfo.automatic = bp.automatic;
                                removalDict.Add(itemID, newinfo);
                            }
                            else
                            {
                                if (!bp.automatic)
                                {
                                    RemovalInfo updateinfo;
                                    updateinfo = removalDict[itemID];
                                    updateinfo.automatic = bp.automatic;
                                    removalDict[itemID] = updateinfo;
                                }

                            }

                            bp.automatic = true;
                        }
                    }
                    else
                    {
                        bp.automatic = removalDict[itemID].automatic;
                    }

                    if (Aim_NoSpread)
                    {
                        if (bp.aimCone != 0f)
                        {


                            if (!removalDict.ContainsKey(itemID))
                            {
                                RemovalInfo newinfo = new RemovalInfo();
                                newinfo.aimCone = bp.aimCone;
                                newinfo.aimConeHip = bp.hipAimCone;
                                newinfo.aimConePenaltyMax = bp.aimConePenaltyMax;
                                newinfo.aimConePenaltyPerShot = bp.aimconePenaltyPerShot;
                                removalDict.Add(itemID, newinfo);
                            }
                            else
                            {
                                if (bp.aimCone != 0f)
                                {
                                    RemovalInfo updateinfo;
                                    updateinfo = removalDict[itemID];
                                    updateinfo.aimCone = bp.aimCone;
                                    updateinfo.aimConeHip = bp.hipAimCone;
                                    updateinfo.aimConePenaltyMax = bp.aimConePenaltyMax;
                                    updateinfo.aimConePenaltyPerShot = bp.aimconePenaltyPerShot;
                                    removalDict[itemID] = updateinfo;
                                }

                            }

                            bp.aimCone = 0f;
                            bp.hipAimCone = 0f;
                            bp.aimConePenaltyMax = 0f;
                            bp.aimconePenaltyPerShot = 0f;
                        }
                    }
                    else
                    {
                        if(bp.aimCone == 0f)
                        {
                            bp.aimCone = removalDict[itemID].aimCone;
                            bp.hipAimCone = removalDict[itemID].aimConeHip;
                            bp.aimConePenaltyMax = removalDict[itemID].aimConePenaltyMax;
                            bp.aimconePenaltyPerShot = removalDict[itemID].aimConePenaltyPerShot;
                        }
                    }

                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }









}

