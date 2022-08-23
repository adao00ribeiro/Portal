using UnityEngine;

public static class Tools
{

    public static Vector3 ConvertLocalPosition(Vector3 position, GameObject Reference, GameObject Target)
    {
        if (Reference == null || Target == null)
        {
            return Vector3.zero;
        }
        Vector3 Direction = position - Reference.transform.position;
        Vector3 TargetLocation = Target.transform.position;
        Vector3 Dots;
        Dots.x = Vector3.Dot(Direction, Reference.transform.forward);
        Dots.y = Vector3.Dot(Direction, Reference.transform.right);
        Dots.z = Vector3.Dot(Direction, Reference.transform.up);
        Vector3 NewDirection = Dots.x * Target.transform.forward
                                + Dots.y * Target.transform.right
                                + Dots.z * Target.transform.up;
        return TargetLocation + NewDirection;
    }

    public static Quaternion ConvertLocalRotation(Quaternion rotation, GameObject Reference, GameObject Target)
    {
        if (Reference == null || Target == null)
        {
            return Quaternion.identity;
        }

        Quaternion LocalQuat = Quaternion.Inverse(Reference.transform.rotation) * rotation;
        Quaternion NewWorldQuat = Target.transform.rotation * LocalQuat;

        return NewWorldQuat;
    }
}
