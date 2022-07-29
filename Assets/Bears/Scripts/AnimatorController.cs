using UnityEngine;
using System;

public class AnimatorController : MonoBehaviour
{
    public Animator[] animators;
    static char[] separator;
    static string parameter;
    static string[] param;

    static AnimatorController()
    {
        separator = new char [] { ',', ';' };
        parameter = "key,value";
        param = parameter.Split(separator);
    }

    public void SwapVisibility(GameObject @object) => @object.SetActive(!@object.activeSelf); //local active state

    public void SetFloat()
    {
        string name = param[0];
        float value = (float)Convert.ToDouble(param[1]);

        print($"{name} {value}");

        foreach (Animator a in animators)
        {
            a.SetFloat(name, value); //send values to animation transitions
        }
    }
    public void SetInt()
    {
        string[] param = parameter.Split(separator);

        string name = param[0];
        int value = Convert.ToInt32(param[1]);

        print($"{name} {value}");

        foreach (Animator a in animators)
        {
            a.SetInteger(name, value);
        }
    }

    public void SetBool()
    {
        string name = param[0];
        bool value = Convert.ToBoolean(param[1]);

        print($"{name} {value}");

        foreach (Animator a in animators)
        {
            a.SetBool(name, value);
        }
    }

    public void SetTrigger()
    {
        string name = param[0];

        print(name);

        foreach (Animator a in animators)
        {
            a.SetTrigger(name);
        }
    }
}
