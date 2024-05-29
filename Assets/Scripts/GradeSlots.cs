using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayHSS207;
using TMPro;


public class GradeSlots : MonoBehaviour
{
    [SerializeField] public Curriculum curriculum;
    TextMeshProUGUI gradeText;

    public void Init()
    {
        gradeText = transform.Find("Slot/Grade").GetComponent<TextMeshProUGUI>();
    }

    public void SetGrade(CurriculumGrade curriculumGrade)
    {
        SetGrade((int)curriculumGrade);
    }

    public void SetGrade(int intGrade)
    {
        gradeText.text = intGrade.ToString();
    }

}
