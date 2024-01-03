using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAnimalsCont : MonoBehaviour
{

    [System.Serializable]
    public class section {
        public GameObject sectionObject;
        public string sectionText;
        public List<question> sectionQuestions;
    }


    [System.Serializable]
    public class question {

        public string questionText;

        public List<string> answers;

        public string correctAnswer;
    
    }

    public List<section> sections = new List<section>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
