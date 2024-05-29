using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayHSS207
{

    public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<T>();
                if (_instance != null) return _instance;
                
                var obj = new GameObject();
                obj.AddComponent<T>();
                obj.name = typeof(T).Name;
                DontDestroyOnLoad(obj);
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            if (_instance == null)
            {
                _instance = this as T;
            }

            OnAwake();
        }
        
        protected virtual void OnAwake() {}
    }



    public enum Category
    {
        Algebra,
        Geometry,
        Arithmetic,
        Combinatorics,
        Analysis,
        SetTheories,
        Statistics,
        ComputerScience,
    }

    public enum CurriculumGrade
    {
        Secondary1 = 1,
        Secondary2 = 2,
        Secondary3 = 3,
        Secondary4 = 4,
        Secondary5 = 5,
        Secondary6 = 6,
    }

    [System.Serializable]
    public class Problem
    {
        public string path;
        public string content;
    }

    public enum Curriculum
    {
        ROK22,
        ROK09,
        ROK92,
        DPRK10,
        DPRK90
    }



}

