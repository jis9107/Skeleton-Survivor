using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

public class InGameItem : MonoBehaviour
{
   public enum Type
    {
        bomb,
        coin,
        mag
    }

    public Type itemTpye;

}
