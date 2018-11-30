//Copyright Nov 2018 Denise S Davis

using System.Collections;
using UnityEngine;

public class SwitchMaterial : MonoBehaviour
{

    public Material BlackMat;
    public Material BlueMat;
    public Material GreenMat;
    public Material RedMat;

    Renderer thisobj;

    void Start()

    { thisobj = GetComponent<Renderer>(); }

    void OnMouseDown()
    {
        if (thisobj.material=BlackMat)
        {
            thisobj.material = BlueMat;
        }
        else if (thisobj.material = BlueMat)
        {
            thisobj.material = GreenMat;
        }
        else if (thisobj.material = GreenMat)
        {
            thisobj.material = RedMat;
        }
        else if (thisobj.material = RedMat)
        {
            thisobj.material = BlackMat;
        }

    }

}
