using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using UnityEditor;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance;
    public static ResourceManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static string zombieDataPath = default;
    public ZombieData zombieData_default = default;

    public List<ZombieData> zombieDatas = default;

    private void Awake()
    {
        zombieDatas = new List<ZombieData>();

        zombieDataPath = "ZombieDatas";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "ZombieDatasFile");

        TextAsset csvZombieData = Resources.Load<TextAsset>(zombieDataPath);

        string[] zombieDatas_str = csvZombieData.text.Split('\n');
        ZombieData loadZombieData = default;
        for(int i = 1; i < zombieDatas_str.Length; i++)
        {
            loadZombieData = new ZombieData(zombieDatas_str[i]);
            zombieDatas.Add(loadZombieData);
        }
    }
}
