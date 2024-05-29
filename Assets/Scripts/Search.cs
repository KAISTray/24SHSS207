using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayHSS207;
using System;
using UnityEngine.UI;


public class Search : MonoBehaviour
{
    List<Problem> problems; // todo

    MathCurri mathCurri;


    Dictionary<string, Category> categoryCache = new Dictionary<string, Category>();

    Dictionary<string, List<CurriculumGrade>> gradeCache = new Dictionary<string, List<CurriculumGrade>>();

    public void SearchProblem()
    {
        List<int> idxList = new List<int>();
        for (int i = 0; i < problems.Count; i++)
        {
            idxList.Add(i);
        }

        for (int i = 0; i < problems.Count * 5; i++)
        {
            int a = UnityEngine.Random.Range(0, problems.Count);
            int b = UnityEngine.Random.Range(0, problems.Count);
            (idxList[b], idxList[a]) = (idxList[a], idxList[b]);
        }
        int problemidx = 0;
        foreach (int i in idxList)
        {
            problemidx = i;
            string content = problems[problemidx].content;

            bool success = true;

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                if (!GameManager.Instance.categorySearchFilter[category]) continue;

                if (!CategoryTest(category, content))
                {
                    success = false;
                    break;
                }
            }

            if (!success) continue;

            foreach (CurriculumGrade grade in Enum.GetValues(typeof(CurriculumGrade)))
            {
                if (!GameManager.Instance.gradeSearchFilter[grade]) continue;

                if (!GradeTest(grade, content))
                {
                    success = false;
                    break;
                }
            }

            if (!success) continue;

            if (success) break;
        }

        // Display Problem

        string pContent = problems[problemidx].content;
        string path = problems[problemidx].path;

        GameManager.Instance.SetImage(path);

        foreach (Curriculum curriculum in Enum.GetValues(typeof(Curriculum)))
        {
            GameManager.Instance.gradeSlots[curriculum].SetGrade(FindGrade(pContent, curriculum));
        }

    }

    void Awake()
    {
        mathCurri = Resources.Load<MathCurri>("MathCurri");

        problems = Resources.Load<ProblemSet>("Problems").problems;

        foreach (MathCurriculumEntity mEntity in mathCurri.Entities)
        {
            if (gradeCache.ContainsKey(mEntity.content))
            {
                gradeCache[mEntity.content].Add((CurriculumGrade)(mEntity.grade - 6));
            }
            else
            {
                List<CurriculumGrade> tmpGrades = new List<CurriculumGrade>();
                tmpGrades.Add((CurriculumGrade)(mEntity.grade - 6));
                gradeCache.Add(mEntity.content, tmpGrades);
            }

            categoryCache.TryAdd(mEntity.content, STC(mEntity.category));
        }
        
    }

    /*
    void Start()
    {
        
        Debug.Log(mathCurri.Entities[0].curriculumString);
    }
    */

    bool GradeTest(CurriculumGrade grade, string content)
    {
        return gradeCache[content].Contains(grade);
    }

    bool CategoryTest(Category category, string content)
    {
        return categoryCache[content] == category;
    }

    int FindGrade(string pContent, Curriculum curriculum)
    {
        foreach (MathCurriculumEntity entity in mathCurri.Entities)
        {
            if (entity.content == pContent && STCU(entity.curriculumString) == curriculum)
            {
                return entity.grade - 6;
            }
        }

        return 0;
    }

    Category STC(string s)
    {
        return s switch
        {
            "대수" => Category.Algebra,
            "기하" => Category.Geometry,
            "산수" => Category.Arithmetic,
            "조합" => Category.Combinatorics,
            "해석" => Category.Analysis,
            "전산학" => Category.ComputerScience,
            "집합론" => Category.SetTheories,
            "통계" => Category.Statistics,
            _ => Category.Algebra,
        };
    }

    Curriculum STCU(string s)
    {
        return s switch
        {
            "22ROK" => Curriculum.ROK22,
            "9ROK" => Curriculum.ROK09,
            "92ROK" => Curriculum.ROK92,
            "10DPRK" => Curriculum.DPRK10,
            "90DPRK" => Curriculum.DPRK90,
            _ => Curriculum.ROK22,
        };
    }

}
