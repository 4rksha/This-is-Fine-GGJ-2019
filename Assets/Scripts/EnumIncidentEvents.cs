using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumIncidentEvents : MonoBehaviour
{
    public enum IncidentEvent { Fire, Leak };

    public static string ToString(IncidentEvent ie)
    {       
        return ie.ToString() + "PrefabV2";
    }

}
