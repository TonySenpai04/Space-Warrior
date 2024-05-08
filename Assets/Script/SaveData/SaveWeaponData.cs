using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public float FireRate;
    public int AmmoCount;
    public int CurrentAmmo;
    public int level;
    public bool isUnlock;
    public float DamageRate;
    public int slot;
    public int WeaponIndex;


}
public class SaveWeaponData : MonoBehaviour
{
    [SerializeField] private List<WeaponControllerBase.WeaponSlot> Slots;
    
    private const string weaponDataFileName = "weapon_data.json";
    private void Awake()
    {
        LoadWeaponData();
    }
    public void SaveData()
    {
        //List<WeaponData> weaponDataList = new List<WeaponData>();

        //// Duyệt qua danh sách Slots và lấy dữ liệu của từng Weapon để lưu vào weaponDataList
        //int slotIndex = 0;

        //foreach (var slot in Slots)
        //{
        //    int weaponIndex = 0;
        //    foreach (var weapon in slot.Weapons)
        //    {
        //        WeaponData weaponData = new WeaponData
        //        {
        //            FireRate = weapon.FireRate,
        //            AmmoCount = weapon.AmmoCount,
        //            CurrentAmmo = weapon.CurrentAmmo,
        //            //LeftHandId = weapon.LeftHandId,
        //            //RightHandId = weapon.RightHandId,
        //            level = weapon.level,
        //            isUnlock = weapon.isUnlock,
        //            DamageRate = weapon.DamageRate,
        //            slot = slotIndex,    
        //            WeaponIndex = weaponIndex
        //        };

        //        weaponDataList.Add(weaponData);
        //        weaponIndex++;
        //    }
        //    slotIndex++;
        //}

        //string jsonData = JsonUtility.ToJson(weaponDataList);
        //string filePath = Path.Combine(Application.persistentDataPath, weaponDataFileName);

        //File.WriteAllText(filePath, jsonData);

        //Debug.Log("Weapon data saved to: " + filePath);
        foreach (var slot in Slots)
        {
            foreach (var weapon in slot.Weapons)
            {
                string weaponKey = "Weapon_" + weapon.name;

                // Lưu các thuộc tính của vũ khí
                PlayerPrefs.SetFloat(weaponKey + "_FireRate", weapon.FireRate);
                PlayerPrefs.SetInt(weaponKey + "_AmmoCount", weapon.AmmoCount);
                PlayerPrefs.SetInt(weaponKey + "_LeftHandId", weapon.LeftHandId);
                PlayerPrefs.SetInt(weaponKey + "_RightHandId", weapon.RightHandId);
                PlayerPrefs.SetInt(weaponKey + "_Level", weapon.level);
                PlayerPrefs.SetFloat(weaponKey + "_DamageRate", weapon.DamageRate);
                PlayerPrefs.SetInt(weaponKey + "_IsUnlock", weapon.isUnlock ? 1 : 0);
            }
        }

        PlayerPrefs.Save();
    }

    public void LoadWeaponData()
    {
        //string filePath = Path.Combine(Application.persistentDataPath, weaponDataFileName);

        //if (File.Exists(filePath))
        //{
        //    string jsonData = File.ReadAllText(filePath);

        //    // Chuyển JSON string thành danh sách WeaponData
        //    List<WeaponData> weaponDataList = JsonUtility.FromJson<List<WeaponData>>(jsonData);

        //    foreach (var weaponData in weaponDataList)
        //    {
        //        // Lấy vũ khí từ slot và chỉ số của vũ khí trong slot
        //        var slot = Slots[weaponData.slot];
        //        var weapon = slot.Weapons[weaponData.WeaponIndex];

        //        // Cập nhật thông tin của vũ khí từ WeaponData
        //        weapon.FireRate = weaponData.FireRate;
        //        weapon.AmmoCount = weaponData.AmmoCount;
        //        weapon.CurrentAmmo = weaponData.CurrentAmmo;
        //        //weapon.LeftHandId = weaponData.LeftHandId;
        //        //weapon.RightHandId = weaponData.RightHandId;
        //        weapon.level = weaponData.level;
        //        weapon.isUnlock = weaponData.isUnlock;
        //        weapon.DamageRate = weaponData.DamageRate;
        //    }

        //    Debug.Log("Weapon data loaded from: " + filePath);
        //}
        //else
        //{
        //    Debug.LogWarning("Weapon data file not found at: " + filePath);
        //}
        foreach (var slot in Slots)
        {
            foreach (var weapon in slot.Weapons)
            {
                string weaponKey = "Weapon_" + weapon.name;

                // Đọc các thuộc tính của vũ khí từ PlayerPrefs
                weapon.FireRate = PlayerPrefs.GetFloat(weaponKey + "_FireRate", weapon.FireRate);
                weapon.AmmoCount = PlayerPrefs.GetInt(weaponKey + "_AmmoCount", weapon.AmmoCount);
                weapon.CurrentAmmo = PlayerPrefs.GetInt(weaponKey + "_CurrentAmmo", weapon.AmmoCount);
                weapon.LeftHandId = PlayerPrefs.GetInt(weaponKey + "_LeftHandId", weapon.LeftHandId);
                weapon.RightHandId = PlayerPrefs.GetInt(weaponKey + "_RightHandId", weapon.RightHandId);
                weapon.level = PlayerPrefs.GetInt(weaponKey + "_Level", weapon.level);
                weapon.DamageRate = PlayerPrefs.GetFloat(weaponKey + "_DamageRate", weapon.DamageRate);
                weapon.isUnlock = PlayerPrefs.GetInt(weaponKey + "_IsUnlock", weapon.isUnlock ? 1 : 0) == 1;
            }
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }

}
