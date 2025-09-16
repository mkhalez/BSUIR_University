namespace _353503_Бахмат_Lab5.Domain
{
    [Serializable]
    public class FilmCharacter : IEquatable<FilmCharacter>
    {
        public string Name { get; set; }        
        public string MovieTitle { get; set; }  
        public Actor Actor { get; set; }

        public bool Equals(FilmCharacter other)
        {
            if (other == null) return false;
            return Name == other.Name && MovieTitle == other.MovieTitle && Actor.Equals(other.Actor);
        }

        public override bool Equals(object obj) => Equals(obj as FilmCharacter);
        public override int GetHashCode() => HashCode.Combine(Name, MovieTitle, Actor);
    }
}
