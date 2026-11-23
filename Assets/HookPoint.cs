using UnityEngine;

public class HookPoint : MonoBehaviour
{
    [Header("Analytics")]
    [SerializeField] private int hookId;
    [SerializeField] private string sectionId;

    private bool used;

    public int HookId => hookId;
    public string SectionId => sectionId;
    public bool Used => used;

    public void MarkAsUsed()
    {
        used = true;
    }

    public void ResetUsage()
    {
        used = false;
    }
}