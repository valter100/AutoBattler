using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSkillHandler : MonoBehaviour
{
    [SerializeField] List<AutoSkill> equippedSkills = new List<AutoSkill>();

    private void Update()
    {
        foreach(AutoSkill skill in equippedSkills)
        {
            skill.UpdateTimer();
        }
    }
}
