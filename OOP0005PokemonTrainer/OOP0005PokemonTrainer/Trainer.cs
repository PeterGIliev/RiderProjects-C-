namespace OOP0005PokemonTrainer
{
    public class Trainer
    {
        public string TrainerName;
        public int NumberOfBadges;
        public string CollectionOfPokemon;

        public Trainer(string trainerName, int numberOfBadges, string collectionOfPokemon)
            : this(trainerName, 0, collectionOfPokemon)
        {
            
        }
    }
}