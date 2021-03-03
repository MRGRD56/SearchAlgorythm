namespace SearchAlgorythm
{
    public class SomeObject
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public SomeObject(string name)
        {
            Id = ++_lastId;
            Name = name;
        }
        
        private static int _lastId = 0;

        public override string ToString() => Name;
    }
}