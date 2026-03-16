

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
    HOW THIS WORKS
    - Uses JSON serialization
    - Supports primitives, arrays, lists, and dictionaries
    - Dictionary keys must be string or convertible to string
*/

public class SavingSystem 
{

    private static readonly string SavePath = Path.Combine(Application.persistentDataPath, "Nessie.json");

    // =========================
    // PUBLIC API
    // =========================

    public static void Save<T>(T data)
    {
        try
        {
            string json = JsonUtility.ToJson(new Wrapper<T>(data), true);
            File.WriteAllText(SavePath, json);
            Debug.Log($"Saved to {SavePath}");
        }
        catch (Exception e)
        {
            Debug.LogError("Save failed: " + e);
        }
    }

    public static T Load<T>() where T : new()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log("No save file found, creating new one");
                return new T();
            }

            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<Wrapper<T>>(json).Data;
        }
        catch (Exception e)
        {
            Debug.LogError("Load failed: " + e);
            return new T();
        }
    }

    public static bool SaveExists()
    {
        return File.Exists(SavePath);
    }

    public static void DeleteSave()
    {
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }

    // =========================
    // INTERNAL WRAPPER
    // =========================

    [Serializable]
    private class Wrapper<T>
    {
        public T Data;
        public Wrapper(T data) => Data = data;
    }
}

// =========================
// EXAMPLE SAVE DATA CLASS
// =========================

[Serializable]
public class GameSaveData
{
    public int playerLevel;
    public float health;

    public int[] unlockedLevels;
    public List<string> inventory;

    public float SFXLevel;
    public float MusicLevel;


    // Unity JsonUtility DOES NOT support Dictionary directly
    // So we wrap it using SerializableDictionary
    public SerializableDictionary<string, int> resources = new();
}

// =========================
// SERIALIZABLE DICTIONARY
// =========================

[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new();
    [SerializeField] private List<TValue> values = new();

    private Dictionary<TKey, TValue> dictionary = new();

    public Dictionary<TKey, TValue> Dictionary => dictionary;

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (var pair in dictionary)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        dictionary = new Dictionary<TKey, TValue>();
        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            dictionary[keys[i]] = values[i];
        }
    }

    public TValue this[TKey key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }

    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
    public void Add(TKey key, TValue value) => dictionary.Add(key, value);
}

// =========================
// USAGE EXAMPLE (MonoBehaviour)
// =========================

public class SaveExample : MonoBehaviour
{
    private GameSaveData data;

    void Start()
    {
        data = SavingSystem.Load<GameSaveData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavingSystem.Save(data);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            data = SavingSystem.Load<GameSaveData>();
        }
    }
}

