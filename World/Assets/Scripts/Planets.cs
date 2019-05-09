using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "Planet")]
public class Planets : ScriptableObject
{
    public new string name;
    public int price;
    public Sprite artwork;
}
