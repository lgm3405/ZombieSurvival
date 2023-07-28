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

    //private string dataPath = default;


    private static string zombieDataPath = default;
    public ZombieData zombieData_default = default;

    private void Awake()
    {
        zombieDataPath = "Scriptables";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "zombie Data Default");

        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        Debug.LogFormat("���� Save data �� ���⿡�ٰ� �����ϴ� ���� ����̴�. -> {0}", Application.persistentDataPath);

        //dataPath = Application.dataPath;
        //zombieDataPath = string.Format("{0}/{1}", Application.dataPath, "01.UnityProject/Scriptables");

        //byte[] byteZombieData = File.ReadAllBytes(zombieDataPath + "/Zombie Data Default");

        //Debug.LogFormat("Data path : {0}", zombieDataPath);

        //zombieData_default = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);
        //ZombieData zombieData_ = Resources.Load<ZombieData>(zombieDataPath);

        //Debug.LogFormat("zombie data path: {0}", zombieDataPath);
        //Debug.LogFormat("zombie data: {0}, {1}, {2}", zombieData_.health, zombieData_.damage, zombieData_.speed);

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
