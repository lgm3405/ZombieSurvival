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
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<ResourceManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
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
