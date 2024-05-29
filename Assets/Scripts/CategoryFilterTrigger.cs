using System.Collections;
using System.Collections.Generic;
using RayHSS207;
using UnityEngine;

public class CategoryFilterTrigger : MonoBehaviour
{
    [SerializeField] Category category;


    public void CategoryChange(bool _category)
    {
        GameManager.Instance.SetCategoryFilter(category, _category);
    }
}
