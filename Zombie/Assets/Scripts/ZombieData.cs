using UnityEngine;

// 좀비 생성시 사용할 셋업 데이터
[CreateAssetMenu(menuName = "ZombieDatas", fileName = "ZombieDatasFile")]
public class ZombieData : ScriptableObject {
    
    public float health = default; // 체력
    public float damage = default; // 공격력
    public float speed = default; // 이동 속도
    public Color skinColor = default; // 피부색

    enum ZombieLoadIndex
    {
        ZOMBIE_HEALTH = 1,
        ZOMBIE_DAMAGE,
        ZOMBIE_SPEED,
        ZOMBIE_COLOR
    }

    public ZombieData(string zombieDataStr)
    {
        // TODO: 데이터 넘겨 받아서 초기화 할 예정
        string[] zombieDatas_str = zombieDataStr.Split(',');

        // { Zombie data 를 초기화 하는 로직
        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_HEALTH], out health);
        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_DAMAGE], out damage);
        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_SPEED], out speed);

        // { colorHtmlCode 를 불러 왔을 때 존재하는 쓰레기 값을 제거하는 로직
        string colorHtmlCode = zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_COLOR];
        colorHtmlCode = colorHtmlCode.Substring(0, 6);
        colorHtmlCode = string.Format("#{0}FF", colorHtmlCode);
        // } colorHtmlCode 를 불러 왔을 때 존재하는 쓰레기 값을 제거하는 로직

        ColorUtility.TryParseHtmlString(colorHtmlCode, out skinColor);
        // } Zombie data 를 초기화 하는 로직

        // { 예외 처리
        bool isInvalid = Mathf.Approximately(health, 0f) || (Mathf.Approximately(damage, 0f) && Mathf.Approximately(speed, 0f));

        if (isInvalid == true)
        {
            Debug.LogErrorFormat("[ZombieData can't initialize ZombieData");
            Debug.Assert(isInvalid);
        }
        // } 예외 처리

    }   // ZombieData()
}
