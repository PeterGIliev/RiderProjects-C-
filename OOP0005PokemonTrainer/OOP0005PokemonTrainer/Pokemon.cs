namespace OOP0005PokemonTrainer
{
    public class Pokemon
    {
        public string PokemonName;
        public string Element;
        public string Health;

        public Pokemon(string pokemonName, string element, string health)
        {
            this.PokemonName = pokemonName;
            this.Element = element;
            this.Health = health;
        }
    }
}