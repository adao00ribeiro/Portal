using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Camera PrefabCamera;
    public Camera CurrentCamera;
    public float DistanceActivation;
    public Player Player;
    public List<Portal> ListPortals = new List<Portal>();
    private static PortalManager _instance;
    public static PortalManager Instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        CurrentCamera = CreateCamera();

        foreach (Portal portal in ListPortals)
        {
            portal.CreateMaterial(CurrentCamera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Portal portal in ListPortals)
        {
            float distance = Vector3.Distance(Player.transform.position, portal.transform.position);

            if (DistanceActivation > distance)
            {
                CurrentCamera.transform.position = Tools.ConvertLocalPosition(Player.GetFirstPersonCamera().transform.position, portal.gameObject, portal.Target.gameObject);
                CurrentCamera.transform.rotation = Tools.ConvertLocalRotation(Player.GetFirstPersonCamera().transform.rotation, portal.gameObject, portal.Target.gameObject);


                if (portal.IsCollisionBox(Player.GetFirstPersonCamera().transform.position))
                {
                    if (portal.IsCrossedPortal(Player.GetFirstPersonCamera().transform.position))
                    {
                        Player.GetComponent<CharacterController>().enabled = false;
                        Player.GetComponent<Player>().GetFirstPersonCamera().enabled = false;
                        Vector3 NewLocation = Tools.ConvertLocalPosition(Player.transform.position, portal.gameObject, portal.Target.gameObject);
                        Player.transform.position = NewLocation;
                        Quaternion NewRotation = Tools.ConvertLocalRotation(Player.transform.rotation, portal.gameObject, portal.Target.gameObject);
                        //Apply new rotation
                        Player.GetComponent<Player>().GetFirstPersonCamera().SetRotationX(NewRotation.eulerAngles.y);
                        Player.GetComponent<CharacterController>().enabled = true;
                    }
                }
            }
        }
    }

    public Player GetPlayer()
    {
        return Player;
    }

    public Camera CreateCamera()
    {
        Camera TempCam = Instantiate(PrefabCamera);
        TempCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        return TempCam;
    }

    public Camera GetCamera()
    {
        return CurrentCamera;
    }
}
