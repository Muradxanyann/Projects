namespace StructuralTask6
{
    interface IBulletType
    {
        string Name { get; }

        int Damage{get;}
        void Render();
    }
    class BulletType : IBulletType
    {
        private readonly string _name;
        private readonly int _damage;

        public BulletType(string name, int damage)
        {
            _name = name;
            _damage = damage;
        }

        public string Name => _name;

        public int Damage => _damage;

        public void Render()
        {
            Console.WriteLine($"Rendering bullet with name {_name} and damage {_damage}");
        }
    }   

    class BulletFactory
    {
        private readonly Dictionary<string, BulletType> factory = new();
        public IBulletType GetBulletType(string name, int damage)
        {
            string key = $"{name}_{damage}";
            if (!factory.ContainsKey(key))
            {
                Console.WriteLine($"Creating new type of bullet - {key}");
                factory[key] = new BulletType(name, damage);
            }
            return factory[key];
        }
    }

    class Bullet
    {
        private readonly IBulletType bulletType;
        private readonly int x;
        private readonly int y;
        private readonly int speed;
        public Bullet (int x, int y, int speed, IBulletType bulletType)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.bulletType = bulletType;
        }
        public void Draw()
        {
            bulletType.Render();
        }

    }

    
}