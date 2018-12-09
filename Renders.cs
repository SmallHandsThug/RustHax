using UnityEngine;

public class Renders
{

    public static bool initialized = false;

    private static UnityEngine.Color color_0;
    private static GUIStyle guistyle_0 = new GUIStyle(GUI.skin.label);
    private static Texture2D texture2D_0 = new Texture2D(1, 1);


    public static void Initialize()
    {
        guistyle_0.font = Font.CreateDynamicFontFromOSFont("SegoeUI", 12);
        initialized = true;
    }


    public static void BoxRect(Rect rect, Color color)
    {

       texture2D_0.SetPixel(0, 0, color);
       texture2D_0.Apply();
       color_0 = color;
       GUI.color = color;

       GUI.DrawTexture(rect, texture2D_0);
    }

    public static void DrawRadarBackground(Rect rect)
    {

        Color backgroundColor = new UnityEngine.Color(0f, 0f, 0f, 0.5f);
        texture2D_0.SetPixel(0, 0, backgroundColor);
        texture2D_0.Apply();
        GUI.color = backgroundColor;

        GUI.DrawTexture(rect, texture2D_0);
    }

    public static void DrawESPBox(BasePlayer player, float thick, Color color)
    {
        Vector3 pos = player.transform.position;
        Vector3 postop = player.transform.position + new Vector3(0f, 1.8f, 0f);

        Vector3 pos_v2 = MainCamera.mainCamera.WorldToScreenPoint(pos);
        Vector3 postop_v2 = MainCamera.mainCamera.WorldToScreenPoint(postop);

        float height = Mathf.Abs(pos_v2.y - postop_v2.y);
        float width = height / 2;

        Vector2 size;

        if(player.IsDucked())
        {
            size = new Vector2(width, height / 2);
        }
        else
        {
            size = new Vector2(width, height);
        }

        if (pos_v2.x > 0 && pos_v2.x < Screen.width && postop_v2.x > 0 && postop_v2.x < Screen.width && pos_v2.y > 0 && pos_v2.y < Screen.height && postop_v2.y > 0 && postop_v2.y < Screen.height)
        {
            if (postop_v2.x - pos_v2.x > 10)
                pos_v2.x += (postop_v2.x - pos_v2.x) / 2;

            if (pos_v2.x - postop_v2.x > 10)
                pos_v2.x -= (pos_v2.x - postop_v2.x) / 2;

            BoxRect(new Rect(pos_v2.x - width / 2, Screen.height - pos_v2.y, width, thick), color);
            BoxRect(new Rect(pos_v2.x - width / 2, Screen.height - pos_v2.y - height, width, thick), color);
            BoxRect(new Rect(pos_v2.x - width / 2, Screen.height - pos_v2.y - height, thick, height), color);
            BoxRect(new Rect(pos_v2.x + width / 2, Screen.height - pos_v2.y - height, thick, height), color);
        }


    }


    public static void DrawBox(Vector2 pos, Vector2 size, float thick, Color color)
    {
        BoxRect(new Rect(pos.x, pos.y, size.x, thick), color);
        BoxRect(new Rect(pos.x, pos.y, thick, size.y), color);
        BoxRect(new Rect(pos.x + size.x, pos.y, thick, size.y), color);
        BoxRect(new Rect(pos.x, pos.y + size.y, size.x + thick, thick), color);
    }

    public static void DrawHealth(Vector2 pos, float health, bool center = false)
    {
        if (center)
        {
            pos -= new Vector2(26f, 0f);
        }

        pos += new Vector2(0f, 18f);
        BoxRect(new Rect(pos.x, pos.y, 52f, 5f), UnityEngine.Color.black);
        pos += new Vector2(1f, 1f);

        Color hpcolor = UnityEngine.Color.green;

        if (health <= 50f)
        {
            hpcolor = UnityEngine.Color.yellow;
        }

        if (health <= 25f)
        {
            hpcolor = UnityEngine.Color.red;
        }

        BoxRect(new Rect(pos.x, pos.y, 0.5f * health, 3f), hpcolor);
    }


    


    public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12, bool stroke = true)
    {

        guistyle_0.fontSize = size;
        guistyle_0.fontStyle = FontStyle.Bold;

        GUIContent content = new GUIContent(text);
        if (center)
        {
            pos.x -= guistyle_0.CalcSize(content).x / 2f;
        }

        if (stroke)
        {
            GUI.color = UnityEngine.Color.black;
            GUI.Label(new Rect(pos.x - 1, pos.y, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x + 1, pos.y, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x, pos.y - 1, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x, pos.y + 1, 300f, 25f), content, guistyle_0);
        }

        GUI.color = color;
        GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, guistyle_0);

       

    }

    public static void DrawWeapon(Vector2 pos, string text, Color color, bool center = true, int size = 12, bool stroke = true)
    {

        guistyle_0.fontSize = size;
        guistyle_0.fontStyle = FontStyle.Bold;

        GUIContent content = new GUIContent(text);
        if (center)
        {
            pos.x -= guistyle_0.CalcSize(content).x / 2f;
        }

        pos += new Vector2(0, 21f);

        if (stroke)
        {
            GUI.color = UnityEngine.Color.black;
            GUI.Label(new Rect(pos.x - 1, pos.y, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x + 1, pos.y, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x, pos.y - 1, 300f, 25f), content, guistyle_0);
            GUI.Label(new Rect(pos.x, pos.y + 1, 300f, 25f), content, guistyle_0);
        }

        GUI.color = color;
        GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, guistyle_0);


    }






}

