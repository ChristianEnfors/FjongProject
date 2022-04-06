using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    [TextArea(10, 20)] [SerializeField] string comment = default;
}
