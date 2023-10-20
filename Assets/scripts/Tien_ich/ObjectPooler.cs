using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ObjectPooler;
using UnityEngine.Pool;
using UnityEditor.EditorTools;

public class ObjectPooler : MonoBehaviour
{
    public float time = 0;
    private float Time_ton_tai = 1f;
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject Prefabs;
        public int size;

    }
    public List<Pool> ListPool;
    Dictionary<string, Queue<GameObject>> DictionaryPool;// dùng để khai gọi danh sach theo tên

    private void Start()
    {
        DictionaryPool = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool Pool in ListPool)
        {
            Queue<GameObject> HangdoichuaDoiTuongtrongPrefabs = new Queue<GameObject>();
            for (int i = 0; i < Pool.size; i++)
            {
                GameObject obj = Instantiate(Pool.Prefabs);// khởi tạo 1 đối tượng để cho vào Hàn đợi Queue
                obj.SetActive(false);// cho nó dừng hoạt động
                HangdoichuaDoiTuongtrongPrefabs.Enqueue(obj);
            }
            DictionaryPool.Add(Pool.name, HangdoichuaDoiTuongtrongPrefabs);
        }
    }
    public GameObject spamObject(string name, Vector3 position, Quaternion rotation)
    {

        GameObject doi_tuong_Spam = DictionaryPool[name].Dequeue();//lấy ra 
        doi_tuong_Spam.SetActive(true);
        doi_tuong_Spam.transform.position = position;
        doi_tuong_Spam.transform.rotation = rotation;


        DictionaryPool[name].Enqueue(doi_tuong_Spam);// cho vào lại ditionary

        return doi_tuong_Spam;
    }
}
