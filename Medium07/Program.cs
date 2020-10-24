using System;
using System.IO;

namespace Medium07
{
    class Program
    {
        static void Main()
        {
            
        }
    }

    class Player
    {
        private float _health;
        private float _armor;
        private int _id;

        public float Health => _health;

        public Player(float health, float armor, int id)
        {
            _health = PlayerPrefs.GetFloat($"user_{_id}.data", health);
            _armor = armor;
            _id = id;
        }

        public void ApplyDamage(float damage)
        {
            float healthDelta = damage - _armor;
            _health -= healthDelta;
            _armor /= 2;

            Console.WriteLine($"Вы получили урона - {healthDelta}");

            PlayerPrefs.SetFloat($"user_{_id}.data", _health);
        }
    }

    class PlayerPrefs
    {
        public static void SetFloat(string key, float value)
        {
            File.WriteAllText(key, value.ToString());
        }

        public static float GetFloat(string key,float defaultValue)
        {
            if (File.Exists(key))
            {
                var data = File.ReadAllText(key);
                return float.Parse(data);
            }
            else
                return defaultValue;
        }

        public static float GetFloat(string key)
        {
            if (File.Exists(key))
            {
                var data = File.ReadAllText(key);
                return float.Parse(data);
            }
            else
                return 0;
        }
    }
}
