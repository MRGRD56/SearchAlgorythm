namespace SearchAlgorythm
{
    public class Matching<T>
    {
        public T Item { get; set; }
        
        public int Matches { get; set; }

        public Matching(T item, int matches = 0)
        {
            Item = item;
            Matches = matches;
        }

        public override string ToString() =>
            $"{Matches} | {Item}";
    }
}