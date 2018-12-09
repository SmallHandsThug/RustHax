using UnityEngine;

internal class Dynamic2D
{
    public bool IsValid;
    public Vector3 Position = Vector3.zero;
    public Vector3 Position2D = Vector3.zero;

    public Dynamic2D(Vector3 position)
    {
        this.Position = position;
        this.Position2D = MainCamera.mainCamera.WorldToScreenPoint(this.Position);
        if (this.Position2D.z > 0f)
        {
            this.IsValid = true;
        }
    }
}