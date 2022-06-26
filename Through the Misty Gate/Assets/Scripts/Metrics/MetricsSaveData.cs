

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsSaveData : MonoBehaviour
{
    #region Singleton
    public static MetricsSaveData instance;

    private void Awake()
    {
        instance = this;

    }
    #endregion

    public MetricsData metricsData;
    public string fileName;
    private bool needsToSave;


    // Start is called before the first frame update
    void Start()
    {
        needsToSave = true;
        metricsData = new MetricsData();
        fileName = "demo_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
    }

    // Update is called once per frame
    void Update()
    {
        //Each 5s save data to file;
        if (needsToSave)
        {
            needsToSave = false;
            StartCoroutine(SaveData());
        }

        metricsData.AddToTime(Time.deltaTime);


    }

    private IEnumerator SaveData()
    {
        yield return new WaitForSeconds(10f);
        string jsonString = JsonConvert.SerializeObject(metricsData);
        Debug.Log("Save data to file - " + fileName);
        Debug.Log(jsonString);

        needsToSave = true;
    }

    public class MetricsData
    {
        //Extra Metrics
        public float elapsedTime;
        public int deathCount;

        public List<SpellData> listSpellData;
        public List<ItemData> listItemData;
        public List<Position> listPlayerPositions;
        public List<EnemyData> listEnemyData;
        
        public MetricsData()
        {
            elapsedTime = 0;
            deathCount = 0;

            listSpellData       = new List<SpellData>();
            listItemData        = new List<ItemData>();
            listPlayerPositions = new List<Position>();
            listEnemyData       = new List<EnemyData>();

        }

        //SpellMetrics

        #region extraMetricsFunctions
        public void AddToTime(float time)
        {
            elapsedTime += time;
        }

        public void AddDeathCount()
        {
            deathCount += 1;
        }

        #endregion

        #region positionMetricsFunctions
        public void AddPosition(Vector2 position)
        {
            listPlayerPositions.Add(new Position(position.x, position.y));
        }

        public class Position
        {
            public Position(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
            public float x;
            public float y;
        }

        #endregion

        #region spellMetricsFunctions
        public void AddSpellUse(string spellName)
        {
            SpellData spell = FindSpellData(spellName);
            spell.numberOfUses += 1;
            
        }

        public void AddSpellDamage(string spellName, float damage)
        {
            SpellData spell = FindSpellData(spellName);
            spell.totalDamageDealt += damage;
        }

        public void AddSpellTimeInHorBar(string spellName, float time)
        {
            SpellData spell = FindSpellData(spellName);
            spell.timeInHotBar += time;
        }

        public void AddSpellEnemyHit(string spellName)
        {
            SpellData spell = FindSpellData(spellName);
            spell.enemiesHit += 1;
        }

        public void AddSpellHeal(string spellName, float heal)
        {
            SpellData spell = FindSpellData(spellName);
            spell.restoredHealthPoints += heal;
        }


        private SpellData FindSpellData( string spellName)
        {
            for (int i = 0; i < listSpellData.Count; i++)
            {
                if (listSpellData[i].spellName == spellName)
                {
                    return listSpellData[i];
                }
            }
            SpellData newSpellData = new SpellData(spellName);
            listSpellData.Add(newSpellData);
            return newSpellData;
        }

        public class SpellData
        {

            public SpellData(string spellName)
            {
                this.spellName = spellName;
                numberOfUses = 0;
                timeInHotBar = 0;
                totalDamageDealt = 0;
                enemiesHit = 0;
                restoredHealthPoints = 0;
            }

            public string spellName;
            public int numberOfUses;
            public float timeInHotBar;
            public float totalDamageDealt;
            public int enemiesHit;
            public float restoredHealthPoints;
        }

        #endregion

        #region itemMetricsFunctions

        public void AddEquipmetnTimeEquiped(string equipmentName, float time)
        {
            ItemData equipment = FindItemData(equipmentName);
            equipment.timeEquiped += time;
        }

        public void AddEquipmentDamageDealt(string equipmentName, float damage)
        {
            ItemData equipment = FindItemData(equipmentName);
            equipment.damageDealtWhileEquiped += damage;
        }

        private ItemData FindItemData(string itemName)
        {
            for (int i = 0; i < listItemData.Count; i++)
            {
                if (listItemData[i].itemName == itemName)
                {
                    return listItemData[i];
                }
            }
            ItemData newItemData = new ItemData(itemName);
            listItemData.Add(newItemData);
            return newItemData;
        }

        public class ItemData
        {
            public ItemData(string name)
            {
                itemName = name;
                timeEquiped = 0;
                damageDealtWhileEquiped = 0;
            }

            public string itemName;
            public float timeEquiped;
            public float damageDealtWhileEquiped;
        }

        #endregion

        #region enemyMetricsFunctions

        public void AddEnemyDamage(string enemyType, float damage)
        {
            EnemyData enemy = FindEnemyData(enemyType);
            enemy.damageDealtToPlayer += damage;

        }

        public void AddEnemyKills(string enemyType)
        {
            EnemyData enemy = FindEnemyData(enemyType);
            enemy.timesPlayerGotKilled += 1;

        }

        private EnemyData FindEnemyData(string enemyType)
        {
            for (int i = 0; i < listEnemyData.Count; i++)
            {
                if (listEnemyData[i].enemyType == enemyType)
                {
                    return listEnemyData[i];
                }
            }
            EnemyData newEnemyData = new EnemyData(enemyType);
            listEnemyData.Add(newEnemyData);
            return newEnemyData;
        }
        public class EnemyData
        {
            public EnemyData(string name)
            {
                enemyType = name;
                damageDealtToPlayer = 0;
                timesPlayerGotKilled = 0;
            }
            public string enemyType;
            public float damageDealtToPlayer;
            public int timesPlayerGotKilled;
        }

        #endregion
    }
}
