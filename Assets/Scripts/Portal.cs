using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private MeshRenderer RenderPlane;
    [SerializeField] private BoxCollider Collider;
    public float DistanceToPlayer { get => DistanceToPlayer; set => DistanceToPlayer = value; }
    public bool LastInFront;
    public Portal Target;



    void Start()
    {
        RenderPlane = transform.Find("RenderPlane").GetComponent<MeshRenderer>();
        Collider = transform.Find("ColliderPlane").GetComponent<BoxCollider>();

    }

    public void CreateMaterial(Camera currentCamera)
    {
        RenderPlane.material = new Material(Shader.Find("Unlit/ScreenCutoutShader"));
        RenderPlane.material.mainTexture = currentCamera.targetTexture;
    }
    public bool IsCrossedPortal(Vector3 Point)
    {
        Plane plane = new Plane(Collider.transform.forward, Collider.transform.position);
        bool IsCrossing = false;
        bool IsInFront = !plane.GetSide(Point);
        float distance = 0;
        bool IsIntersect = plane.Raycast(new Ray(Point, -Collider.transform.forward), out distance);
        if (IsIntersect && !IsInFront && LastInFront)
        {
            IsCrossing = true;
        }
        LastInFront = IsInFront;
        return IsCrossing;
    }

    public bool IsCollisionBox(Vector3 Point)
    {
        if (Collider == null)
        {
            return false;
        }
        Vector3 Position = Collider.transform.position;
        Vector3 Size = Collider.size / 2;
        Vector3 DirectionX = Collider.transform.right;
        Vector3 DirectionY = Collider.transform.up;
        Vector3 DirectionZ = Collider.transform.forward;

        Vector3 Direction = Point - Position;

        bool IsInside = Mathf.Abs(Vector3.Dot(Direction, DirectionX)) <= Size.x &&
                    Mathf.Abs(Vector3.Dot(Direction, DirectionY)) <= Size.y &&
                    Mathf.Abs(Vector3.Dot(Direction, DirectionZ)) <= Size.z;

        return IsInside;
    }

}
