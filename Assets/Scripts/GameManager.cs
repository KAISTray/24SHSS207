using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayHSS207;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{


    public Dictionary<Curriculum, GradeSlots> gradeSlots = new Dictionary<Curriculum, GradeSlots>();
    
    public Dictionary<Category, bool> categorySearchFilter = new Dictionary<Category, bool>();
    public Dictionary<CurriculumGrade, bool> gradeSearchFilter = new Dictionary<CurriculumGrade, bool>();

    public Image image;

    void Awake()
    {
        gradeSlots.Add(Curriculum.ROK22, transform.Find("Texts").Find("22ROK").GetComponent<GradeSlots>());
        gradeSlots.Add(Curriculum.ROK09, transform.Find("Texts").Find("09ROK").GetComponent<GradeSlots>());
        gradeSlots.Add(Curriculum.ROK92, transform.Find("Texts").Find("92ROK").GetComponent<GradeSlots>());
        gradeSlots.Add(Curriculum.DPRK10, transform.Find("Texts").Find("10DPRK").GetComponent<GradeSlots>());
        gradeSlots.Add(Curriculum.DPRK90, transform.Find("Texts").Find("90DPRK").GetComponent<GradeSlots>());

        foreach (GradeSlots gradeSlot in gradeSlots.Values)
        {
            gradeSlot.Init();
        }

        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            categorySearchFilter.Add(category, false);
        }

        foreach (CurriculumGrade curriculumGrade in Enum.GetValues(typeof(CurriculumGrade)))
        {
            gradeSearchFilter.Add(curriculumGrade, false);
        }

        image = transform.Find("Problems").GetComponent<Image>();
    }

    public void SetCategoryFilter(Category category, bool filter)
    {
        categorySearchFilter[category] = filter;
    }

    public void SetGradeFilter(CurriculumGrade curriculumGrade, bool filter)
    {
        gradeSearchFilter[curriculumGrade] = filter;
    }

    public void SetImage(string path)
    {
        image.sprite = Resources.Load<Sprite>("Problems/" + path);
    }

    //int tick = 0;

    void Update()
    {
        /*
        tick++;
        if (tick < 120)
        {
            return;
        }


        string categoryString = "Category : ";
        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            if (categorySearchFilter[category])
            {
                categoryString += category.ToString() + " ";
            }
        }
        string gradeString = "Grade : ";
        foreach (CurriculumGrade grade in Enum.GetValues(typeof(CurriculumGrade)))
        {
            if (gradeSearchFilter[grade])
            {
                gradeString += grade.ToString() + " ";
            }
        }
        Debug.Log(categoryString);
        Debug.Log(gradeString);
        tick = 0;
        */
    }
}
