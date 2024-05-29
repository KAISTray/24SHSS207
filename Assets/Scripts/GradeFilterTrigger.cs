using System.Collections;
using System.Collections.Generic;
using RayHSS207;
using UnityEngine;

public class GradeFilterTrigger : MonoBehaviour
{
    [SerializeField] CurriculumGrade grade;


    public void CategoryChange(bool _grade)
    {
        GameManager.Instance.SetGradeFilter(grade, _grade);
    }
}
