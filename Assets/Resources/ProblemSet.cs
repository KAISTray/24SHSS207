using System.Collections;
using System.Collections.Generic;
using RayHSS207;
using UnityEngine;

[CreateAssetMenu(fileName = "Problems", menuName = "ScriptableObject/Problems", order = int.MaxValue)]
public class ProblemSet : ScriptableObject
{
    public List<Problem> problems;
}
