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
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamPortals();
    }
    public void ControlCamPortals()
    {
        foreach (Portal item in ListPortals)
        {
            float distance = Vector3.Distance(Player.transform.position, item.transform.position);
            if (DistanceActivation > distance)
            {
                CurrentCamera.transform.position = Tools.ConvertLocalPosition(Player.GetFirstPersonCamera().transform.position, item.gameObject, item.Target.gameObject);
                CurrentCamera.transform.rotation = Tools.ConvertLocalRotation(Player.GetFirstPersonCamera().transform.rotation, item.gameObject, item.Target.gameObject);
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
